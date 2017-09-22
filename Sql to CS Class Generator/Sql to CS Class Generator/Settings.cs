using System;
using System.IO;

namespace Sql_to_CS_Class_Generator
{
    public class Settings
    {
        public static string FileName = "settings.xml";

        public string Server { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ClassName { get; set; }
        public GenerateTo GenerateTo { get; set; }
    }
}