CREATE PROCEDURE altaCliente
	@dni int,
	@nombre varchar(30),
	@apellido varchar(30),
	@telefono varchar(15),
	@email varchar (50),
	@disponible bit

AS
	INSERT INTO
	Cliente(CLI_DNI, CLI_Nombre, CLI_Apellido, CLI_Telefono, CLI_Email, CLI_Disponible)
	values (@dni, @nombre, @apellido, @telefono, @email, @disponible)
RETURN 0
