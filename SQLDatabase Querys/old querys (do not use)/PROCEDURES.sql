BEGIN
	USE Northwind
END
GO
-- =============================================

-- Autor: Angel Rene Flores Rivera

-- Fecha de Creación: 01/07/2024

-- Description de tarea: SQL PARA NORTHWIND PROCEDURES

-- =============================================

--1. Elaborar un SP para consultar todos los datos de la tabla
CREATE PROCEDURE ConsultCustomers
AS
BEGIN
	SELECT * FROM Customers
END
GO
--2. Elaborar un SP para insertar un registro a la tabla
CREATE PROCEDURE InsertCustomer
(
	@CustomerID nchar(5),
	@CompanyName nvarchar(40),
	@ContactName nvarchar(40) = null,
	@ContactTitle nvarchar(30) = null,
	@Address nvarchar(60) = null,
	@City nvarchar(15) = null,
	@Region nvarchar(15) = null,
	@PostalCode nvarchar(10) = null,
	@Country nvarchar(15) = null,
	@Phone nvarchar(24) = null,
	@Fax nvarchar(24) = null
)
AS
BEGIN
	INSERT INTO Customers VALUES
	(@CustomerID,
	@CompanyName,
	@ContactName,
	@ContactTitle,
	@Address,
	@City,
	@Region,
	@PostalCode,
	@Country,
	@Phone,
	@Fax)
END
GO
--3. Elaborar un SP para modificar un registro de la tabla
CREATE PROCEDURE UpdateCustomer
(
	@CustomerID nchar(5),
	@CompanyName nvarchar(40),
	@ContactName nvarchar(40) = null,
	@ContactTitle nvarchar(30) = null,
	@Address nvarchar(60) = null,
	@City nvarchar(15) = null,
	@Region nvarchar(15) = null,
	@PostalCode nvarchar(10) = null,
	@Country nvarchar(15) = null,
	@Phone nvarchar(24) = null,
	@Fax nvarchar(24) = null
)
AS
BEGIN
	UPDATE Customers SET
	[CompanyName] = @CompanyName,
	[ContactName] = @ContactName,
	[ContactTitle] = @ContactTitle,
	[Address] = @Address,
	[City] = @City,
	[Region] = @Region,
	[PostalCode] = @PostalCode,
	[Country] = @Country,
	[Phone] = @Phone,
	[Fax] = @Fax
	WHERE [CustomerID] = @CustomerID
END
GO
--4. Elaborar un SP para eliminar un registro de la tabla
CREATE PROCEDURE DeleteCustomer
(
	@CustomerID nchar(5)
)
AS
BEGIN
	DELETE FROM Customers
	WHERE [CustomerID] = @CustomerID
END
GO

--5. Elaborar un SP que regrese todos los registros de “Customers” que pertenezcan a la misma ciudad  (utilizar el campo “City” como parámetro).
CREATE PROCEDURE ConsultCustomersByCity
(
	@City nvarchar(15) = null
)
AS
BEGIN
	SELECT * FROM Customers
	WHERE [City] = @City
END

EXEC ConsultCustomersByCity 'México D.F.'