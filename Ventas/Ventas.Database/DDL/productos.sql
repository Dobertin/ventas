CREATE TABLE [dbo].[productos] (
    [idProducto] INT            IDENTITY (1, 1) NOT NULL,
    [nombre_com] VARCHAR (70)   NULL,
    [tipo]       CHAR (7)       NULL,
    [puntos]     DECIMAL (7, 4) NULL,
    PRIMARY KEY CLUSTERED ([idProducto] ASC)
);

