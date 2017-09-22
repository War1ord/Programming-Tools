using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sql_to_CS_Class_Generator
{
    public class Class_Generator
    {
        private readonly Dictionary<Type, string> TypeAliases = new Dictionary<Type, string>
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

        private readonly List<Type> NullableTypes = new List<Type>
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

        public string GeneratorPocoClass(IDbConnection connection, string class_name, string sql)
        {
            if (connection.State != ConnectionState.Open) connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            var reader = cmd.ExecuteReader();
            var builder = new StringBuilder();
            do
            {
                if (reader.FieldCount <= 0) continue;
                builder.AppendLine(string.Format("public class {0}", string.IsNullOrEmpty(class_name) ? "MyClass" : class_name));
                builder.AppendLine("{");
                var schema = reader.GetSchemaTable();
                foreach (DataRow row in schema.Rows)
                {
                    var type = (Type) row["DataType"];
                    var name = TypeAliases.ContainsKey(type) ? TypeAliases[type] : type.Name;
                    var isNullable = (bool) row["AllowDBNull"] && NullableTypes.Contains(type);
                    var collumnName = (string) row["ColumnName"];
                    builder.AppendLine(
                        string.Format("\tpublic {0}{1} {2} {3}", name, isNullable ? "?" : string.Empty, collumnName, "{ get; set; }"));
                }
                builder.AppendLine("}");
                builder.AppendLine();
            } while (reader.NextResult());
            return builder.ToString();
        }
    }
}