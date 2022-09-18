CREATE PROCEDURE [dbo].[listarVentas]
AS
	select c.nombres cliente, p.nombreCom,a.usuario asesor,v.montoDesembolsado, 
	v.periodo, v.puntosObtenidos, v.fechaVenta 
	from ventas v inner join cliente c on v.idCliente = c.idCliente 
	inner join asesores a on v.idAsesor = a.idAsesor 
	inner join productos p on v.idProducto = p.idProducto where estado_registro = 1