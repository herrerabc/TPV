CREATE TABLE [dbo].[usuarios] (
    [usuario]   VARCHAR (15) NOT NULL,
    [passwd]    VARCHAR (20) NOT NULL,
    [nombre]    VARCHAR (25) NOT NULL,
    [apellidoP] VARCHAR (25) NOT NULL,
    [apellidoM] VARCHAR (25) NOT NULL,
    [roll]      VARCHAR (10) NOT NULL,
    [estatus]   BIT          NULL,
    PRIMARY KEY CLUSTERED ([usuario] ASC)
);

