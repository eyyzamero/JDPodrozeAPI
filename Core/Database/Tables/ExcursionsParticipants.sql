CREATE TABLE [JDPodrozeDB].[dbo].[ExcursionsParticipants] (
    Id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ExcursionsParticipants PRIMARY KEY CLUSTERED,
    BookerId INT NULL,
    OrderId UNIQUEIDENTIFIER NOT NULL,
    Name NVARCHAR(50) NOT NULL,
    Surname NVARCHAR(50) NOT NULL,
    Email NVARCHAR(150) NULL,
    TelephoneNumber NVARCHAR(12) NULL,
    BirthDate DATE NOT NULL,
    UserId INT NULL,
    Discount BIT NOT NULL CONSTRAINT DF_ExcursionsParticipants_Discount DEFAULT 0,
    CONSTRAINT FK_ExcursionsParticipants_ExcursionsOrders FOREIGN KEY (OrderId)
        REFERENCES [JDPodrozeDB].[dbo].[ExcursionsOrders] (OrderId),
    CONSTRAINT FK_ExcursionsParticipants_Users FOREIGN KEY (UserId)
        REFERENCES [JDPodrozeDB].[dbo].[Users] (Id)
);