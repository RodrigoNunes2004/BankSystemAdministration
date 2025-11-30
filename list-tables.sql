-- List all tables in the database
SELECT 
    TABLE_SCHEMA,
    TABLE_NAME,
    TABLE_TYPE
FROM 
    INFORMATION_SCHEMA.TABLES
WHERE 
    TABLE_TYPE = 'BASE TABLE'
ORDER BY 
    TABLE_SCHEMA, TABLE_NAME;

-- Alternative: List all user tables (excludes system tables)
SELECT 
    s.name AS SchemaName,
    t.name AS TableName,
    t.create_date AS CreatedDate
FROM 
    sys.tables t
INNER JOIN 
    sys.schemas s ON t.schema_id = s.schema_id
WHERE 
    t.is_ms_shipped = 0  -- Exclude system tables
ORDER BY 
    s.name, t.name;

-- Show table details with row counts
SELECT 
    s.name AS SchemaName,
    t.name AS TableName,
    p.rows AS RowCount,
    t.create_date AS CreatedDate
FROM 
    sys.tables t
INNER JOIN 
    sys.schemas s ON t.schema_id = s.schema_id
INNER JOIN 
    sys.partitions p ON t.object_id = p.object_id
WHERE 
    t.is_ms_shipped = 0
    AND p.index_id IN (0, 1)  -- 0 = heap, 1 = clustered index
ORDER BY 
    s.name, t.name;

