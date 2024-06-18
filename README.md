[![CI](https://github.com/Crauzer/XXHash3.NET/actions/workflows/ci.yml/badge.svg?branch=main)](https://github.com/Crauzer/XXHash3.NET/actions/workflows/ci.yml) ![Nuget](https://img.shields.io/nuget/dt/XXHash3.NET)

# SqlXXHash3NET

A SQLCLR SAFE implementation of XXHash3.NET, which returns a xxHash64 has a SqlInt64, that can be deployed to SQL Server or Azure SQL Managed Instance.

Note that only SAFE assemblies are supported on Linux and as such only [Supported Libraries](https://learn.microsoft.com/en-us/sql/relational-databases/clr-integration/database-objects/supported-net-framework-libraries?view=sql-server-ver16#supported-libraries) may be referenced in the assembly. XXHash3.NET's code base has been modififed to meet this requirement.

## Path to implementation

1. Compile the SqlXxHash3.sln to a .NET Framework 4.8 assembly named SqlXxHash3Net.dll
2. Copy SqlXxHash3Net.dll to a location accessible by SQL Server.
3. Create the assembly in a database:
```sql
create assembly xxhash64 from 'c:/tmp/CLR/SqlXxHash3Net.dll' with permission_set = safe;
```
4. Create a function referencing the method to be called:
```sql
create function dbo.XxHash64(@Value varbinary(max))
returns bigint
external name xxhash64.XXHash64Net.HashToInt64;
```
5. Test it...
```sql
declare @vb varbinary(max) = convert(varbinary, 'Hello World!');
select dbo.XxHash64(@vb);
```
6. Verfiy it...

--6545093196672709231 is a52b286a3e7f4d91, which matches the output from [Generate a xxh hash value](https://www.coderstool.com/xxh-hash-generator)

8. Declare (more) victory!
