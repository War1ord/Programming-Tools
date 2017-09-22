using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace SqlCsClasses
{
    public static class Program
    {
        static void Main(string[] args)
        {
            if (ConfigurationManager.ConnectionStrings != null)
            {
                Console.WriteLine("Please enter the namespace you want the classes to be generated under?");
                var readLine = Console.ReadLine();
                Console.WriteLine("Generating...");
                string namespace_name = !string.IsNullOrEmpty(readLine) ? readLine : "SqlClasses";
                var now = DateTime.Now;
                var enumerator = ConfigurationManager.ConnectionStrings.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    var class_generator = new Class_Generator();
                    var settings = enumerator.Current as ConnectionStringSettings;
                    if (settings != null && settings.Name != "LocalSqlServer")
                    {
                        using (var connection = new SqlConnection(settings.ConnectionString))
                        {
                            var builder = new SqlConnectionStringBuilder(settings.ConnectionString);

                            if (connection.State != ConnectionState.Open) connection.Open();

                            var command = connection.CreateCommand();
                            command.CommandText = 
                            #region sql
 @"SELECT o.name as object_name
	,o.type_desc
	,s.name as schema_name
FROM sys.all_objects o
INNER JOIN sys.schemas s on s.schema_id = o.schema_id
WHERE o.type in ( 'V', 'U') 
ORDER BY o.type_desc
	,o.NAME";
                            #endregion

                            #region data reader
                            var reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                var schema_name = reader["schema_name"].ToString();
                                var type_desc = reader["type_desc"].ToString();
                                var object_name = reader["object_name"].ToString();
                                string generatorPocoClass;
                                using (var conn = new SqlConnection(settings.ConnectionString))
                                {
                                    generatorPocoClass = class_generator.GeneratorPocoClass(conn, namespace_name, object_name,
                                        string.Format(@"select * from {0}.{1}", schema_name, object_name));
                                }
                                if (string.IsNullOrEmpty(generatorPocoClass)) continue;
                                //eg. desktop\datetime_now\type_desc\sqlCsClass.cs 
                                var root_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), string.Format("SqlCsClasses {0}", now.ToString("yyyy MM dd HH mm ss")));
                                var dbPath = Path.Combine(root_path, GetDbName(builder));
                                var full_path = Path.Combine(dbPath, type_desc);
                                var full_file_path = Path.Combine(full_path, string.Format("{0}.cs", object_name));
                                if (!Directory.Exists(full_path))
                                {
                                    var directoryInfo = Directory.CreateDirectory(full_path);
                                }
                                if (!File.Exists(full_file_path))
                                {
                                    File.WriteAllText(full_file_path, generatorPocoClass);
                                }
                                else
                                {
                                    // file exists already
                                }
                            }
                            #endregion

                            if (connection.State != ConnectionState.Closed) connection.Close();
                        }
                    }
                }
                Console.WriteLine("Done...");
            }
            else
            {
                Console.WriteLine("No connection strings to build with...");
            }
        }

        private static string GetDbName(SqlConnectionStringBuilder builder)
        {
            if (builder != null)
            {
                if (!string.IsNullOrEmpty(builder.ApplicationName))
                {
                    return builder.ApplicationName;
                }
                else
                {
                    return builder.DataSource;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
