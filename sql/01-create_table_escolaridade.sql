CREATE TABLE [dbo].[Escolaridade] (
    [IdEscolaridade] INT          NOT NULL,
    [Escolaridade]   VARCHAR (40) NOT NULL,
    CONSTRAINT [PK_Escolaridade] PRIMARY KEY CLUSTERED ([IdEscolaridade] ASC)
);