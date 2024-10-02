﻿CREATE TABLE [JDPodrozeDB].[dbo].[Visits] (
    Id UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Visits_Id DEFAULT NEWID(),
    TypeId INT NULL,
    Description NVARCHAR(256) NULL,
    IP NVARCHAR(40) NULL,
    DateAndTime DATETIME2(7) NULL,
    CONSTRAINT PK_Visits PRIMARY KEY CLUSTERED (Id)
);