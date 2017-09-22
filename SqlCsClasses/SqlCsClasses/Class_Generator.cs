using System;
using System.Collections.Generic;
using System.Data;

namespace SqlCsClasses
{
    public class Class_Generator
    {
        private readonly Dictionary<Type, string> _type_Aliases = new Dictionary<Type, string>
        {
            {typeof (int), "int"},
            {typeof (short), "short"},
            {typeof (byte), "byte"},
            {typeof (byte[]), "byte[]"},
            {typeof (long), "long"},
            {typeof (double), "double"},
            {typeof (decimal), "decimal"},
            {typeof (float), "float"},
            {typeof (bool), "bool"},
            {typeof (string), "string"}
        };

        private readonly List<Type> _nullable_Types = new List<Type>
        {
            typeof (int),
            typeof (short),
            typeof (long),
            typeof (double),
            typeof (decimal),
            typeof (float),
            typeof (bool),
            typeof (DateTime)
        };

        public string GeneratorPocoClass(IDbConnection connection, string namespace_name, string class_name, string sql)
        {
            try
            {
                if (connection.State != ConnectionState.Open) connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                var reader = cmd.ExecuteReader();
                var builder = new System.Text.StringBuilder();
                do
                {
                    if (reader.FieldCount <= 0) continue;
                    builder.AppendLine(string.Format("namespace {0}", !string.IsNullOrEmpty(namespace_name) ? namespace_name : "MyClass"));
                    builder.AppendLine("{");
                    builder.AppendLine(string.Format("\tpublic class {0}", !string.IsNullOrEmpty(class_name) ? class_name : "MyClass"));
                    builder.AppendLine("\t{");
                    var schema = reader.GetSchemaTable();
                    foreach (DataRow row in schema.Rows)
                    {
                        var type = (Type)row["DataType"];
                        var name = _type_Aliases.ContainsKey(type) ? _type_Aliases[type] : type.Name;
                        var isNullable = (bool)row["AllowDBNull"] && _nullable_Types.Contains(type);
                        var collumnName = (string)row["ColumnName"];
                        builder.AppendLine(
                            string.Format("\t\tpublic {0}{1} {2} {3}", name, isNullable ? "?" : string.Empty, collumnName, "{ get; set; }"));
                    }
                    builder.AppendLine("\t}");
                    builder.AppendLine("}");
                    builder.AppendLine();
                } while (reader.NextResult());
                return builder.ToString();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}