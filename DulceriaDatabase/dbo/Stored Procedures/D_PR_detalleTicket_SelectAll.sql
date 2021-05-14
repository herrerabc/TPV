CREATE PROCEDURE D_PR_detalleTicket_SelectAll
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
END
