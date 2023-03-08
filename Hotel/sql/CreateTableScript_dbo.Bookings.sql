CREATE TABLE [dbo].[Bookings] (
    [BookingID]    UNIQUEIDENTIFIER NOT NULL,
    [CheckinDate]  DATETIME2 (7)    NOT NULL,
    [CheckoutDate] DATETIME2 (7)    NOT NULL,
    [TotalCost]    DECIMAL (18)     NOT NULL,
    [CreatedDate]  DATETIME2 (7)    NOT NULL,
    [LastUpdate]   DATETIME2 (7)    NOT NULL,
    [CustomerID]   UNIQUEIDENTIFIER NOT NULL,
    [RoomID]       UNIQUEIDENTIFIER NOT NULL,
    [HotelID]      UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED ([BookingID] ASC),
    CONSTRAINT [FK_Bookings_Customers_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers] ([CustomerID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Bookings_Hotels_HotelID] FOREIGN KEY ([HotelID]) REFERENCES [dbo].[Hotels] ([HotelID]),
    CONSTRAINT [FK_Bookings_Rooms_RoomID] FOREIGN KEY ([RoomID]) REFERENCES [dbo].[Rooms] ([RoomID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Bookings_CustomerID]
    ON [dbo].[Bookings]([CustomerID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Bookings_HotelID]
    ON [dbo].[Bookings]([HotelID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Bookings_RoomID]
    ON [dbo].[Bookings]([RoomID] ASC);

