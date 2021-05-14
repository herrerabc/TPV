CREATE TABLE [dbo].[MovimientoDetalle] (
    [idDetalle]      INT             NOT NULL,
    [idMovimiento]   INT             NOT NULL,
    [idProducto]     INT             NOT NULL,
    [cantidad]       NUMERIC (12, 4) NOT NULL,
    [tipoAfectacion] CHAR (1)        NOT NULL,
    PRIMARY KEY CLUSTERED ([idDetalle] ASC),
    FOREIGN KEY ([idMovimiento]) REFERENCES [dbo].[Movimiento] ([idMovimiento]),
    FOREIGN KEY ([idProducto]) REFERENCES [dbo].[productos] ([idProducto])
);


GO

CREATE TRIGGER Afectainventario  
ON dbo.movimientoDetalle  
AFTER INSERT
AS  
	Declare @tipoMovimiento varchar(10)
	
	Select @tipoMovimiento = idTipoMovimiento from Movimiento
	inner join inserted on inserted.idMovimiento  = Movimiento.idMovimiento

	If(@tipoMovimiento = 'VTA')
	Begin
	   UPDATE productos set productos.cantidad = productos.cantidad - inserted.cantidad 
	   from inserted 
	   where productos.idProducto = inserted.idProducto 
    End

	If(@tipoMovimiento = 'DEV')
	Begin
	   UPDATE productos set productos.cantidad = productos.cantidad + inserted.cantidad 
	   from inserted 
	   where productos.idProducto = inserted.idProducto 
    End
