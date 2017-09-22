using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace Enums
{
	public class EnumerationsDll
	{
        private readonly AppDomain _appDomain = AppDomain.CurrentDomain;

	    public void Build()
	    {
            if (ConfigurationManager.ConnectionStrings != null)
	        {
	            var enumerator = ConfigurationManager.ConnectionStrings.GetEnumerator();
                while (enumerator.MoveNext())
	            {
                    var settings = enumerator.Current as ConnectionStringSettings;
                    if (settings != null && settings.Name != "LocalSqlServer")
	                {
	                    var builder = new SqlConnectionStringBuilder(settings.ConnectionString);
	                    var namePrefix = GetNamePrefix(builder, settings);
	                    CreateEnumerationsDll(
                            connectionString: settings.ConnectionString,
                            Namespace: string.Format("SqlEnums.{0}", namePrefix),
                            assemblyNameString: string.Format("SqlEnums.{0}", namePrefix));
                    }
                }
            }
        }

	    private string GetNamePrefix(SqlConnectionStringBuilder builder, ConnectionStringSettings settings)
	    {
            if (!string.IsNullOrEmpty(builder.ApplicationName) && 
                builder.ApplicationName != ".Net SqlClient Data Provider")
	        {
                return builder.ApplicationName;
	        }
            //else if (/*settings static class is not null*/)
            //{
            //    return /*where ConnectionStringSettings.Name = settings_static_class.name*/;
            //}
            else
            {
                return builder.InitialCatalog;
            }
	    }

	    #region helper
        private void CreateEnumerationsDll(string connectionString, string Namespace, string assemblyNameString)
        {
            var assemblyName = new AssemblyName(assemblyNameString);
            var builder = _appDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave, _appDomain.BaseDirectory);
            var module = builder.DefineDynamicModule(assemblyName.Name, assemblyName.Name + ".dll");
            {
                {
                    DefineAnEnumerationOfSqlObjects(
                        enumerationName: Namespace + "." + "Stored_Procedures",
                        moduleBuilder: module,
                        connectionString: connectionString,
                        sql: @"
                            SELECT o.object_id
	                            ,o.NAME
                            FROM sys.all_objects AS o
                            WHERE o.type = 'P'
                            ORDER BY o.type_desc
	                            ,o.NAME
                        ",
                        columnName: "name",
                        literalValue: "object_id");
                }
                {
                    DefineAnEnumerationOfSqlObjects(
                        enumerationName: Namespace + "." + "Views",
                        moduleBuilder: module,
                        connectionString: connectionString,
                        sql: @"
                            SELECT o.object_id
	                            ,o.NAME
                            FROM sys.all_objects AS o
                            WHERE o.type = 'V'
                            ORDER BY o.type_desc
	                            ,o.NAME
                        ",
                        columnName: "name",
                        literalValue: "object_id");
                }
                {
                    DefineAnEnumerationOfSqlObjects(
                        enumerationName: Namespace + "." + "System_Tables",
                        moduleBuilder: module,
                        connectionString: connectionString,
                        sql: @"
                            SELECT o.object_id
	                            ,o.NAME
                            FROM sys.all_objects AS o
                            WHERE o.type = 'S'
                            ORDER BY o.type_desc
	                            ,o.NAME
                        ",
                        columnName: "name",
                        literalValue: "object_id");
                }
                {
                    DefineAnEnumerationOfSqlObjects(
                        enumerationName: Namespace + "." + "User_Tables",
                        moduleBuilder: module,
                        connectionString: connectionString,
                        sql: @"
                            SELECT o.object_id
	                            ,o.NAME
                            FROM sys.all_objects AS o
                            WHERE o.type = 'U'
                            ORDER BY o.type_desc
	                            ,o.NAME
                        ",
                        columnName: "name",
                        literalValue: "object_id");
                }
                {
                    DefineAnEnumerationOfSqlObjects(
                        enumerationName: Namespace + "." + "Scalar_Functions",
                        moduleBuilder: module,
                        connectionString: connectionString,
                        sql: @"
                            SELECT o.object_id
	                            ,o.NAME
                            FROM sys.all_objects AS o
                            WHERE o.type = 'FN'
                            ORDER BY o.type_desc
	                            ,o.NAME
                        ",
                        columnName: "name",
                        literalValue: "object_id");
                }
                {
                    DefineAnEnumerationOfSqlObjects(
                        enumerationName: Namespace + "." + "Inline_Table_Valued_Functions",
                        moduleBuilder: module,
                        connectionString: connectionString,
                        sql: @"
                            SELECT o.object_id
	                            ,o.NAME
                            FROM sys.all_objects AS o
                            WHERE o.type = 'IF'
                            ORDER BY o.type_desc
	                            ,o.NAME
                        ",
                        columnName: "name",
                        literalValue: "object_id");
                }
                {
                    DefineAnEnumerationOfSqlObjects(
                        enumerationName: Namespace + "." + "Aggregate_Function",
                        moduleBuilder: module,
                        connectionString: connectionString,
                        sql: @"
                            SELECT o.object_id
	                            ,o.NAME
                            FROM sys.all_objects AS o
                            WHERE o.type = 'AF'
                            ORDER BY o.type_desc
	                            ,o.NAME
                        ",
                        columnName: "name",
                        literalValue: "object_id");
                }
                {
                    DefineAnEnumerationOfSqlObjects(
                        enumerationName: Namespace + "." + "Schemas",
                        moduleBuilder: module,
                        connectionString: connectionString,
                        sql: @"SELECT schema_id,NAME FROM sys.schemas",
                        columnName: "name",
                        literalValue: "schema_id");
                }
            }
            {
                {
                    DefineACollectionOfSqlSubObjects(
                        sqltablescolumnsEnumerationName1StPart: Namespace + "." + "Columns",
                        moduleBuilder: module,
                        connectionString: connectionString,
                        columnName: "NAME",
                        sql: @"
                            SELECT col.column_id
	                            ,col.NAME
	                            ,obj.NAME AS [object_name]
                            FROM sys.all_columns col
                            INNER JOIN sys.all_objects obj ON obj.object_id = col.object_id
                            ORDER BY obj.NAME
	                            ,col.column_id
                        ",
                        /*sql: @"SELECT c.ORDINAL_POSITION, c.COLUMN_NAME, c.TABLE_NAME FROM INFORMATION_SCHEMA.COLUMNS AS c ORDER BY c.TABLE_NAME, c.ORDINAL_POSITION",*/
                        groupingName: "object_name",
                        literal: "column_id");
                }
                {
                    DefineACollectionOfSqlSubObjects(
                        sqltablescolumnsEnumerationName1StPart: Namespace + "." + "Parameters",
                        moduleBuilder: module,
                        connectionString: connectionString,
                        columnName: "name",
                        sql: @"
                            SELECT par.parameter_id
	                            ,replace(par.NAME, '@', '') as name
	                            ,obj.NAME AS [object_name]
                            FROM sys.all_parameters par
                            INNER JOIN sys.all_objects obj ON obj.object_id = par.object_id
                            ORDER BY obj.NAME
	                            ,par.parameter_id
                        ",
                        /*sql: @"SELECT p.ORDINAL_POSITION ,replace(p.PARAMETER_NAME, '@', '') PARAMETER_NAME ,p.SPECIFIC_NAME FROM INFORMATION_SCHEMA.PARAMETERS AS p ORDER BY p.SPECIFIC_NAME ,p.ORDINAL_POSITION",*/
                        groupingName: "object_name",
                        literal: "parameter_id");
                }
            }
            builder.Save(assemblyName.Name + ".dll");
        }

	    private void DefineAnEnumerationOfSqlObjects(string enumerationName, ModuleBuilder moduleBuilder, string connectionString, string sql, string columnName, string literalValue)
        {
            var builder = moduleBuilder.DefineEnum(enumerationName, TypeAttributes.Public, typeof(int));
            var connections = new Connections(connectionString, CommandType.Text, sql);
	        foreach (DataRow row in connections.GetDataTable().AsEnumerable())
            {
                builder.DefineLiteral(row[columnName].ToString(), int.Parse(row[literalValue].ToString()));
            }
            builder.CreateType();
        }

	    private void DefineACollectionOfSqlSubObjects(string sqltablescolumnsEnumerationName1StPart, ModuleBuilder moduleBuilder, string connectionString, string columnName, string sql, string groupingName, string literal)
        {
            var tablesColumnsConn = new Connections(connectionString, CommandType.Text, sql);
            var tablesColumnsDataTable = tablesColumnsConn.GetDataTable();
	        foreach (var groupings in tablesColumnsDataTable.AsEnumerable().GroupBy(row => row[groupingName].ToString()))
            {
                var enumerationName = sqltablescolumnsEnumerationName1StPart + "." + groupings.Key;
                var builder = moduleBuilder.DefineEnum(enumerationName, TypeAttributes.Public, typeof(int));
                foreach (DataRow row in groupings)
                {
                    int literalValue = int.Parse(row[literal].ToString());
                    if (literalValue > 0)
                    {
                        builder.DefineLiteral(row[columnName].ToString(), literalValue);
                    }
                }
                builder.CreateType();
            }
        } 
        #endregion

	}
}