CREATE TABLE [dbo].[Customers] (
    [CustomerID]  UNIQUEIDENTIFIER NOT NULL,
    [Name]        VARCHAR (100)    NOT NULL,
    [BirthDate]   DATE             NOT NULL,
    [Email]       VARCHAR (100)    NOT NULL,
    [SIN]         INT              NOT NULL,
    [CreatedDate] DATETIME2 (7)    NOT NULL,
    [LastUpdate]  DATETIME2 (7)    NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([CustomerID] ASC)
);

