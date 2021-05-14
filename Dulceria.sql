if OBJECT_ID('MovimientoDetalle') is not null
	drop table MovimientoDetalle
go
if OBJECT_ID('Movimiento') is not null
	drop table Movimiento
go
if OBJECT_ID('tipoMovimiento') is not null
	drop table tipoMovimiento
go
if OBJECT_ID('detalleTicket') is not null
	drop table detalleTicket
go
if OBJECT_ID('ticket') is not null
	drop table ticket
go
if OBJECT_ID('productos') is not null
	drop table productos
go
if OBJECT_ID('unidadMedida') is not null
	drop table unidadMedida
go
if OBJECT_ID('usuarios') is not null
	drop table usuarios
go
Create table usuarios(
usuario			varchar(15) primary key not null
,passwd			varchar(20) not null
,nombre			varchar(25) not null
,apellidoP		varchar(25) not null
,apellidoM		varchar(25) not null
,roll			varchar(10) not null
,estatus		bit)
go
Create table unidadMedida(
idUnidad		int primary key not null
,descripcion	varchar(15) not null)
go
Create table productos(
idProducto		int primary key not null
,idUnidad		int
,descripcion    varchar(50) not null
,codigoBarras	varchar(40) not null
,precio			money	not null
,cantidad		numeric(10,2) default 0 not null
, FOREIGN KEY (idUnidad) references unidadMedida(idUnidad))
go
Create table ticket(
idTicket		int primary key not null
,fecha			date not null
,usuario		varchar(15) not null
,total			money not null
,foreign key(usuario) references usuarios(usuario))
go
create table detalleTicket(
idDetalle		int primary key not null
,idTicket		int not null
,fecha			date not null
,idProducto		int not null
,cantidad		numeric(10,2) not null
,precio			money not null
, foreign key(idTicket) references ticket(idTicket)
, foreign key(idProducto) references productos(idProducto))
go
create table tipoMovimiento(
idTipoMovimiento	varchar(4) primary key not null
,descripcion		varchar(40) not null)
go
create table Movimiento(
idMovimiento		int primary key not null
,fecha				date not null
,usuario			varchar(15) not null
,idTipoMovimiento	varchar(4) not null
, foreign key(usuario) references usuarios(usuario)
, foreign key(idTipoMovimiento) references tipoMovimiento(idTipoMovimiento))
go
create table MovimientoDetalle(
idDetalle			int primary key not null
,idMovimiento		int not null
,idProducto			int not null
,cantidad			numeric(10,2) not null
,tipoAfectacion		char(1) not null
, foreign key(idMovimiento) references Movimiento(idMovimiento)
, foreign key(idProducto) references productos(idProducto))



