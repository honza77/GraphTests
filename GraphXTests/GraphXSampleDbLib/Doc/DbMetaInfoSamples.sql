-- TABLES:
select * from sys.tables
select name, * FROM sysobjects where xtype = 'U'

-- tables with schema:
select * from information_schema.tables
	where TABLE_TYPE = 'BASE TABLE'
	--where table_name like '%emplo%'
	order by TABLE_SCHEMA, TABLE_NAME



-- FKs:
-------
EXEC sp_fkeys 'TABLE NAME'
--  with schema:
EXEC sp_fkeys @pktable_name = N'TABLE_NAME'  ,@pktable_owner = N'TABLE_SCHEMA';  

-- find pointing tables:
select t.name as TableWithForeignKey, fk.constraint_column_id as FK_PartNo , c.name as ForeignKeyColumn 
from sys.foreign_key_columns as fk
inner join sys.tables as t on fk.parent_object_id = t.object_id
inner join sys.columns as c on fk.parent_object_id = c.object_id and fk.parent_column_id = c.column_id
where fk.referenced_object_id = (select object_id from sys.tables where name = 'TABLE NAME')
order by TableWithForeignKey, FK_PartNo

-- find FKs:
select distinct name from sys.objects where object_id in 
(   select fk.constraint_object_id from sys.foreign_key_columns as fk
    where fk.referenced_object_id = 
    	(select object_id from sys.tables where name = 'TABLE NAME')
)

-- find pointing to/form tables:
declare @table_name varchar(100)
set @table_name = 'Cars'

select fk.parent_object_id, 
	t1.name as TableWithForeignKey, 
	fk.referenced_object_id
	, t2.name
from sys.foreign_key_columns as fk
	left outer join sys.tables as t1 on fk.parent_object_id = t1.object_id 
	left outer join sys.tables as t2 on fk.referenced_object_id = t2.object_id 
	where t1.name =  @table_name
	or t2.name =  @table_name