﻿CREATE TABLE [dbo].[Categories]
(
	[CategorySeq] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Key1] NVARCHAR(50) NULL, 
    [Key2] NVARCHAR(50) NULL, 
    [Key3] NVARCHAR(50) NULL,
    [Key4] NVARCHAR(50) NULL, 
    [Key5] NVARCHAR(50) NULL, 
    [Key6] NVARCHAR(50) NULL,
    [Key7] NVARCHAR(50) NULL, 
    [Key8] NVARCHAR(50) NULL, 
    [Key9] NVARCHAR(50) NULL,
    [Value1] NVARCHAR(250) NULL, 
    [Value2] NVARCHAR(250) NULL, 
    [Value3] NVARCHAR(250) NULL,
    [Value4] NVARCHAR(250) NULL, 
    [Value5] NVARCHAR(250) NULL, 
    [Value6] NVARCHAR(250) NULL,
    [Value7] NVARCHAR(250) NULL, 
    [Value8] NVARCHAR(250) NULL, 
    [Value9] NVARCHAR(250) NULL, 
    [IsEnabled] BIT NOT NULL DEFAULT 1,
)
