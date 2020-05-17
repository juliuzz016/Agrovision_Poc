CREATE TABLE [dbo].[SprayingAgents]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[AgentKey] UNIQUEIDENTIFIER NOT NULL,
	[AgentDescription] NVARCHAR(MAX) NOT NULL,
	[RecomendedDosage] decimal(16, 4) NOT NULL,
	[IsActive] BIT NOT NULL 

)
