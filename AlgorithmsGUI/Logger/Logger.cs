using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsGUI
{
    public static class Logger
    {
        private static string _path = "C:\\Users\\m1a\\source\\repos\\Algorithms\\logs.txt";
        public static string Path 
        {
            get => _path;
            set => _path = value;
        }
        
        public static void Write(string message)
        {
            using (StreamWriter writer = new StreamWriter(Path, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message.Replace("\n", " ")}");
            }
        }
    }
}
