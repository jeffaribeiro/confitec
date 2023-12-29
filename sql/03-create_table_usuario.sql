CREATE TABLE [dbo].[Usuario] (
    [IdUsuario]      INT           IDENTITY (1, 1) NOT NULL,
    [Nome]           VARCHAR (20)  NOT NULL,
    [Sobrenome]      VARCHAR (100) NOT NULL,
    [Email]          VARCHAR (50)  NOT NULL,
    [DataNascimento] DATETIME      NOT NULL,
    [IdEscolaridade] INT           NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([IdUsuario] ASC),
    CONSTRAINT [FK_Usuario_Escolaridade] FOREIGN KEY ([IdEscolaridade]) REFERENCES [dbo].[Escolaridade] ([IdEscolaridade])
);