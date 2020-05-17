CREATE TABLE [dbo].[Sprayers]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[SprayerKey] UNIQUEIDENTIFIER NOT NULL,
	[Description] NVARCHAR(MAX) NOT NULL,
	[SparyerVolumeL] Decimal(16,2) NOT NULL,
	[IsActive] BIT NOT NULL 
)
