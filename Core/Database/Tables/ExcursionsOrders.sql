CREATE TABLE [JDPodrozeDB].[dbo].[ExcursionsOrders] (
    OrderId UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_ExcursionsOrders_OrderId DEFAULT NEWID(),
    ExcursionId INT NOT NULL,
    PaymentMethod CHAR(1) NOT NULL CONSTRAINT DF_ExcursionsOrders_PaymentMethod DEFAULT 'T',
    PaymentStatus CHAR(1) NOT NULL CONSTRAINT DF_ExcursionsOrders_PaymentStatus DEFAULT 'N',
    BookerId INT NULL,
    Price DECIMAL(8, 2) NOT NULL CONSTRAINT DF_ExcursionsOrders_Price DEFAULT 0.00,
    PickupPointId UNIQUEIDENTIFIER NULL,
    CONSTRAINT PK_ExcursionsOrders PRIMARY KEY CLUSTERED (OrderId),
    CONSTRAINT FK_ExcursionsOrders_Excursions FOREIGN KEY (ExcursionId)
        REFERENCES [JDPodrozeDB].[dbo].[Excursions] (Id),
    CONSTRAINT CH_ExcursionsOrders_PaymentMethod CHECK (PaymentMethod = 'P' OR PaymentMethod = 'T'),
    CONSTRAINT CH_ExcursionsOrders_PaymentStatus CHECK (PaymentStatus = 'N' OR PaymentStatus = 'P')
);