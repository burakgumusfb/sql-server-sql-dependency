# Microsft.SqlServer.SqlDependency

1) CREATE DATABASE [MyDatabase];

2) CREATE TABLE [dbo].[Messages] (
[Id] int IDENTITY(1, 1) NOT NULL,
[Message] varchar(MAX) NULL)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]
WITH (DATA_COMPRESSION = NONE);

3) ALTER DATABASE [MyDatabase] SET ENABLE_BROKER with rollback immediate;

