CREATE TABLE [dbo].[MeterData]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[TimeStart] DATETIME NOT NULL, 
    [TimeEnd] DATETIME NOT NULL, 
    [Unit] NVARCHAR(50) NOT NULL, 
    [Measurement] FLOAT NOT NULL, 
    [EnergyType] NVARCHAR(50) NOT NULL, 
    [MeterId] NVARCHAR(50) NOT NULL
)
