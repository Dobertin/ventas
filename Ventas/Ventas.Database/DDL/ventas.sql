CREATE TABLE [dbo].[ventas] (
    [idVenta]           INT             IDENTITY (1, 1) NOT NULL,
    [idCliente]         INT             NULL,
    [idAsesor]          INT             NULL,
    [idProducto]        INT             NULL,
    [periodo]           CHAR (6)        NULL,
    [puntosObtenidos]   INT             NULL,
    [fechaVenta]        DATETIME        NULL default GETDATE(),
    [montoDesembolsado] DECIMAL (10, 4) NULL,
    [estado_registro]   INT             NULL default 1,
    PRIMARY KEY CLUSTERED ([idVenta] ASC),
    FOREIGN KEY ([idAsesor]) REFERENCES [dbo].[asesores] ([idAsesor]),
    FOREIGN KEY ([idCliente]) REFERENCES [dbo].[cliente] ([idCliente]),
    FOREIGN KEY ([idProducto]) REFERENCES [dbo].[productos] ([idProducto])
);

