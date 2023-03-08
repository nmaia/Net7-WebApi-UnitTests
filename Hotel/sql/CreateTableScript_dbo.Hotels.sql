CREATE TABLE [dbo].[Hotels] (
    [HotelID]     UNIQUEIDENTIFIER NOT NULL,
    [Name]        VARCHAR (50)     NOT NULL,
    [CreatedDate] DATETIME2 (7)    NOT NULL,
    [LastUpdate]  DATETIME2 (7)    NOT NULL,
    CONSTRAINT [PK_Hotels] PRIMARY KEY CLUSTERED ([HotelID] ASC)
);

