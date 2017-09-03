using System.Collections.Generic;

namespace gorina_helpers
{
    public class AppState
    {
        static private AppState instance;
        private AppState()
        {
            MapsFile = @"./maps.json";
            InputFile = "files/input.txt";
            OutputFile = "files/output.txt";
            Lines = new List<string[]>();
        }
        static public AppState Instance
        {
            get
            {
                if (instance == null) instance = new AppState();
                return instance;
            }
        }
        public string InputFile { get; set; }
        public string OutputFile { get; set; }
        public string MapsFile { get; set; }
        public List<CSVMap> Maps { get; set; }
        public List<string[]> Lines { get; set; }
    }
}