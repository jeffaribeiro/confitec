CREATE TABLE [dbo].[HistoricoEscolar] (
    [IdHistoricoEscolar] INT           IDENTITY (1, 1) NOT NULL,
    [Formato]            VARCHAR (4)   NOT NULL,
    [Nome]               VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_HistoricoEscolar] PRIMARY KEY CLUSTERED ([IdHistoricoEscolar] ASC)
);