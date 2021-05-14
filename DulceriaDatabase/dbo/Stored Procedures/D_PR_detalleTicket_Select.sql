CREATE PROCEDURE D_PR_detalleTicket_Select
		--Parameters
			@idDetalle int

AS
BEGIN
SET NOCOUNT ON;
		SELECT
			[idDetalle],
			[idTicket],
			[fecha],
			[idProducto],
			[cantidad],
			[precio],
			[total]
		FROM 
			[dbo].[detalleTicket]
		WHERE 
			[idDetalle] = @idDetalle
END
