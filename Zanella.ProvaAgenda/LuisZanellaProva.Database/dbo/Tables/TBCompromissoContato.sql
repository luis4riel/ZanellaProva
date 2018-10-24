CREATE TABLE [dbo].[TBCompromissoContato]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdCompromisso] INT NOT NULL, 
    [IdContato] INT NOT NULL 
)
