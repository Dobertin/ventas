CREATE TABLE [dbo].[asesores] (
    [idAsesor]      INT          IDENTITY (1, 1) NOT NULL,
    [usuario]       VARCHAR (20) NULL,
    [nombres]       VARCHAR (30) NULL,
    [apellido]      VARCHAR (30) NULL,
    [tipoDoc]       CHAR (4)     NULL,
    [nroDoc]        CHAR (10)    NULL,
    [cantVentas]    INT          NULL,
    [metaPropuesta] INT          NULL,
    PRIMARY KEY CLUSTERED ([idAsesor] ASC)
);

