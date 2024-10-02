CREATE TABLE [JDPodrozeDB].[dbo].[Excursions] (
    Id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Excursions PRIMARY KEY CLUSTERED,
    Title NVARCHAR(255) NOT NULL,
    ShortDescription NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    Active BIT NOT NULL,
    InCarousel BIT NOT NULL,
    DateFrom DATE NULL,
    DateTo DATE NULL,
    PriceGross DECIMAL(8,2) NOT NULL,
    PriceNet DECIMAL(8, 2) NOT NULL,
    Discount BIT NOT NULL CONSTRAINT DF_Excursions_Discount DEFAULT 0,
    DiscountPriceGross DECIMAL(8,2) NOT NULL CONSTRAINT DF_Excursions_DiscountPriceGross DEFAULT 0.00,
    Seats INT NOT NULL CONSTRAINT DF_Excursions_Seats DEFAULT 0,
    IsTemplate BIT NOT NULL CONSTRAINT DF_Excursions_IsTemplate DEFAULT 0,
    IsDeleted BIT NOT NULL CONSTRAINT DF_Excursions_IsDeleted DEFAULT 0
);