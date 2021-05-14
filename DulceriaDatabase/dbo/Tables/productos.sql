CREATE TABLE [dbo].[productos] (
    [idProducto]   INT             NOT NULL,
    [idUnidad]     INT             NULL,
    [descripcion]  VARCHAR (50)    NOT NULL,
    [codigoBarras] VARCHAR (40)    NOT NULL,
	[precioReal]   MONEY          Default(0) NOT NULL,
    [precio]       MONEY           NOT NULL,
    [cantidad]     NUMERIC (12, 4) DEFAULT (0) NOT NULL,
    [estado] BIT NOT NULL DEFAULT (1), 
    PRIMARY KEY CLUSTERED ([idProducto] ASC),
    FOREIGN KEY ([idUnidad]) REFERENCES [dbo].[unidadMedida] ([idUnidad])
);

