-- Data Select for Views, User_Tables,  
SELECT o.name as object_name
	,o.type_desc
	,s.name as schema_name
FROM sys.all_objects o
INNER JOIN sys.schemas s on s.schema_id = o.schema_id
WHERE o.type in ( 'V', 'U') 
ORDER BY o.type_desc
	,o.NAME

-- Data Select for Inline_Table_Valued_Functions
SELECT par.parameter_id
	,par.NAME as [column_name]
	,obj.object_id AS [object_id]
	,obj.parent_object_id AS [parent_object_id]
	,obj.NAME AS [object_name]
	,obj.type_desc
FROM sys.all_objects obj
INNER JOIN sys.all_parameters par ON obj.object_id = par.object_id
WHERE obj.type = 'IF'
ORDER BY obj.type_desc
	,obj.NAME
	,par.parameter_id

--select * from sys.system_sql_modules where object_id = -333557461
go
select * from sys.dm_db_script_level