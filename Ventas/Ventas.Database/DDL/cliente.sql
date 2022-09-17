CREATE TABLE [dbo].[cliente] (
    [idCliente] INT          IDENTITY (1, 1) NOT NULL,
    [nombres]   VARCHAR (30) NULL,
    [apellidos] VARCHAR (30) NULL,
    [tipoDoc]   CHAR (4)     NULL,
    [nroDoc]    CHAR (10)    NULL,
    [telefono]  CHAR (10)    NULL,
    [celular]   CHAR (10)    NULL,
    PRIMARY KEY CLUSTERED ([idCliente] ASC)
);

