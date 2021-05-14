CREATE TABLE [dbo].[Movimiento] (
    [idMovimiento]     INT          NOT NULL,
    [fecha]            DATETIME     NOT NULL,
    [usuario]          VARCHAR (15) NOT NULL,
    [idTipoMovimiento] VARCHAR (4)  NOT NULL,
    [observacion] VARCHAR(250) NULL, 
    PRIMARY KEY CLUSTERED ([idMovimiento] ASC),
    FOREIGN KEY ([idTipoMovimiento]) REFERENCES [dbo].[tipoMovimiento] ([idTipoMovimiento]),
    FOREIGN KEY ([usuario]) REFERENCES [dbo].[usuarios] ([usuario])
);

