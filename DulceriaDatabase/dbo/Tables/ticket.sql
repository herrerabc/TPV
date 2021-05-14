CREATE TABLE [dbo].[ticket] (
    [idTicket] INT          NOT NULL,
    [fecha]    DATETIME     NOT NULL,    
    [total]    MONEY        NOT NULL,
	[cancelado] bit not null default(0),
	[observacion] varchar(250) Null, 
	[usuario]  VARCHAR (15) NOT NULL,
    PRIMARY KEY CLUSTERED ([idTicket] ASC),
    FOREIGN KEY ([usuario]) REFERENCES [dbo].[usuarios] ([usuario])
);

