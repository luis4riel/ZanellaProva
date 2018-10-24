CREATE TABLE [dbo].[TBContato]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] VARCHAR(60) NOT NULL, 
    [Email] VARCHAR(60) NOT NULL, 
    [Departamento] VARCHAR(30) NOT NULL, 
    [Endereco] VARCHAR(60) NOT NULL, 
    [Telefone] VARCHAR(20) NOT NULL
)
