CREATE TABLE [dbo].[Rooms] (
    [RoomID]                   UNIQUEIDENTIFIER NOT NULL,
    [Number]                   INT              NOT NULL,
    [IsAvailable]              BIT              NOT NULL,
    [DailyRate]                DECIMAL (18)     NOT NULL,
    [NextBookingAvailableDate] DATETIME2 (7)    NOT NULL,
    [CreatedDate]              DATETIME2 (7)    NOT NULL,
    [LastUpdate]               DATETIME2 (7)    NOT NULL,
    [HotelID]                  UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED ([RoomID] ASC),
    CONSTRAINT [FK_Rooms_Hotels_HotelID] FOREIGN KEY ([HotelID]) REFERENCES [dbo].[Hotels] ([HotelID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Rooms_HotelID]
    ON [dbo].[Rooms]([HotelID] ASC);

