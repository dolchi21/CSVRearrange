using System.Collections.Generic;

namespace CSVRearrange
{
    public class AppState
    {
        static private AppState instance;
        private AppState()
        {
            ConfigurationFile = "config.json";
            InputFile = "input.txt";
            InputFileSeparator = ';';
            Lines = new List<string[]>();
            MapsFile = "maps.json";
            OutputFile = "output.txt";
            OutputFileSeparator = ';';
        }
        static public AppState Instance
        {
            get
            {
                if (instance == null) instance = new AppState();
                return instance;
            }
        }
        public string ConfigurationFile { get; set; }
        public string InputFile { get; set; }
        public char InputFileSeparator { get; set; }
        public List<string[]> Lines { get; set; }
        public List<CSVMap> Maps { get; set; }
        public string MapsFile { get; set; }
        public string OutputFile { get; set; }
        public int OutputFileColumns { get; set; }
        public char OutputFileSeparator { get; set; }
    }
}