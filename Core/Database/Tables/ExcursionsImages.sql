CREATE TABLE [JDPodrozeDB].[dbo].[ExcursionsImages] (
    Id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ExcursionsImages PRIMARY KEY CLUSTERED,
    ExcursionId INT NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Type VARCHAR(4) NOT NULL,
    [Order] INT NOT NULL,
    CONSTRAINT FK_ExcursionsImages_Excursions FOREIGN KEY (ExcursionId)
        REFERENCES [JDPodrozeDB].[dbo].[Excursions] (Id)
);