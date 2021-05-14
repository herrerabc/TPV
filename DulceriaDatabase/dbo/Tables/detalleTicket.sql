CREATE TABLE [dbo].[detalleTicket] (
    [idDetalle]  INT             NOT NULL,
    [idTicket]   INT             NOT NULL,
    [fecha]      DATETIME        NOT NULL,
    [idProducto] INT             NOT NULL,
    [cantidad]   NUMERIC (12, 4) NOT NULL,
    [precio]     MONEY           NOT NULL,
    [total]      MONEY           NOT NULL,
    PRIMARY KEY CLUSTERED ([idDetalle] ASC),
    FOREIGN KEY ([idProducto]) REFERENCES [dbo].[productos] ([idProducto]),
    FOREIGN KEY ([idTicket]) REFERENCES [dbo].[ticket] ([idTicket])
);

