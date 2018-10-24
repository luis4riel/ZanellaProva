﻿CREATE TABLE [dbo].[TBResultado]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nota] NUMERIC(18, 2) NOT NULL, 
    [IdAluno] INT NOT NULL, 
    CONSTRAINT [FK_Resultado_TBAluno] FOREIGN KEY (IdAluno) REFERENCES TBAluno(Id) 
)
