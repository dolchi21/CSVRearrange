using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using NDesk.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CSVRearrange
{
    public class CSVMap
    {
        public int Source { get; set; }
        public int Target { get; set; }
    }
    class Program
    {
        static AppState state = AppState.Instance;
        static void Main(string[] args)
        {
            setup(args);
            loadConfigurationFile();
            loadMaps();
            process();
            Console.WriteLine(Encoding.Default.EncodingName);
            Console.WriteLine(state.MapsFile);
            Console.WriteLine(state.InputFile);
            Console.WriteLine(state.OutputFile);
            Console.WriteLine(Directory.GetCurrentDirectory());
        }
        static void process()
        {
            if (File.Exists(state.OutputFile)) File.Delete(state.OutputFile);

            var reader = new StreamReader(state.InputFile);
            var output = new StreamWriter(state.OutputFile);

            while (!reader.EndOfStream)
            {
                string[] newRow = new string[51];
                var line = reader.ReadLine();
                string[] row = line.Split(';');
                foreach (var map in state.Maps)
                {
                    if (map.Source < row.Length)
                    {
                        newRow[map.Target] = row[map.Source];
                    }
                }
                string newLine = String.Join(";", newRow);
                output.WriteLine(newLine);
            }

            reader.Dispose();
            output.Dispose();

        }
        static void setup(string[] args)
        {
            var p = new OptionSet(){
                {"input=", str => {
                    state.InputFile = str;
                }},
                {"maps=", str => {
                    state.MapsFile = str;
                }},
                {"output=", str => {
                    state.OutputFile = str;
                }}
            };
            List<string> extra = p.Parse(args);
        }
        static void loadMaps()
        {
            var maps = readMapsFromFile(state.MapsFile);
            state.Maps = maps;
        }
        static List<CSVMap> readMapsFromFile(string fileName)
        {
            string fileContent = File.ReadAllText(fileName);
            try
            {
                List<CSVMap> maps = JsonConvert.DeserializeObject<List<CSVMap>>(fileContent);
                return maps;
            }
            catch (Exception ex)
            {
                Global.error("JSON.parse failed.", ex);
                throw ex;
            }
        }
        static void loadConfigurationFile()
        {
            if (state.ConfigurationFile == null) return;
            string fileContent = File.ReadAllText(state.ConfigurationFile);
            JObject config = JObject.Parse(fileContent);
            if (config["output"]["columns"] != null)
            {
                state.OutputFileColumns = (int)config["output"]["columns"];
            }

        }
    }
}
