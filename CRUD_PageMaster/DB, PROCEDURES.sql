
Create database Contactos

use Contactos

create table Usuarios(
IdUsuario int primary key identity(1,1),
Nombre varchar(30),
Edad int,
Correo varchar(max),
FechaNac date
)

GO

-- ******************** CARGAR REGISTROS DE TABLA ******************** --
create or alter proc sp_load
as
begin
	select * from Usuarios
end

GO

-- ******************** CREAR REGISTROS ******************** --
create proc sp_create
(
	@nombre varchar(30),
	@edad int,
	@correo varchar(max),
	@fecha date
)
as
begin
	insert into Usuarios values (@nombre, @edad, @correo, @fecha)
end

GO

-- ******************** LEER REGISTROS ******************** --
create proc sp_read
(
	@id int
)
as
begin
	select * from Usuarios where IdUsuario = @id
end

GO

-- ******************** ACTUALIZAR REGISTROS ******************** --
create proc sp_update
(
	@id int,
	@nombre varchar(30),
	@edad int,
	@correo varchar(max),
	@fecha date
)
as
begin
	update Usuarios set Nombre = @nombre, Edad = @edad, Correo = @correo, FechaNac = @fecha
	where IdUsuario = @id
end

GO

-- ******************** ELIMINAR REGISTROS ******************** --
create proc sp_delete
@id int
as
begin
	delete from Usuarios where IdUsuario = @id
end


select * from Usuarios


