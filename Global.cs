using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CSVRearrange
{
    public static class Global
    {

        public static void log(string text)
        {
            Console.WriteLine(DateTime.Now.ToString("hh:mm:ss") + " - " + text);
            Debug.WriteLine(DateTime.Now.ToString("hh:mm:ss") + " - " + text);
        }

        public static void error(string text, Exception ex)
        {
            string line = DateTime.Now.ToString("hh:mm:ss") + " - Error: " + text;

            Console.WriteLine(line);

            if (ex != null)
                Console.WriteLine(ex);

            Debug.WriteLine(line);

            if (ex != null)
                Debug.WriteLine(ex);
        }
    }
}