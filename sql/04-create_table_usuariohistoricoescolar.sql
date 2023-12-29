CREATE TABLE [dbo].[UsuarioHistoricoEscolar] (
    [IdUsuarioHistoricoEscolar] INT IDENTITY (1, 1) NOT NULL,
    [IdUsuario]                 INT NOT NULL,
    [IdHistoricoEscolar]        INT NOT NULL,
    CONSTRAINT [PK_UsuarioHistoricoEscolar] PRIMARY KEY CLUSTERED ([IdUsuarioHistoricoEscolar] ASC),
    CONSTRAINT [FK_UsuarioHistoricoEscolar_HistoricoEscolar] FOREIGN KEY ([IdHistoricoEscolar]) REFERENCES [dbo].[HistoricoEscolar] ([IdHistoricoEscolar]),
    CONSTRAINT [FK_UsuarioHistoricoEscolar_Usuario] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuario] ([IdUsuario])
);
