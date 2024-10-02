CREATE TABLE [JDPodrozeDB].[dbo].[ExcursionsPickupPoints] (
    Id UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_ExcursionsPickupPoints_Id DEFAULT NEWID(),
    ExcursionId INT NOT NULL,
    Name NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_ExcursionsPickupPoints PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_ExcursionsPickupPoints_Excursions FOREIGN KEY (ExcursionId)
        REFERENCES [JDPodrozeDB].[dbo].[Excursions] (Id)
);