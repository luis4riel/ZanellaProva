CREATE TABLE [dbo].[TBCompromisso]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Assunto] VARCHAR(100) NOT NULL, 
    [Local] VARCHAR(100) NOT NULL, 
    [DataInicial] DATE NULL, 
    [DataFinal] DATE NULL, 
    [isDiaTodo] BIT NOT NULL, 
 
)
