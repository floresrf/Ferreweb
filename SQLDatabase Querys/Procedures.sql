use Webshop

GO

-- PRODUCTS

CREATE PROCEDURE list_Product
AS
BEGIN
	SELECT * FROM Products
END

GO

CREATE PROCEDURE search_Product
	@ID int
AS
BEGIN
	SELECT * FROM Products
	WHERE
	ID = @ID
END

GO

CREATE PROCEDURE insert_Product
(
	@Name nvarchar(50),
	@Price decimal(18,2),
	@Description nvarchar(250) = null,
	@Picture nvarchar(MAX) = null
)
AS
BEGIN
	INSERT INTO Products VALUES
	(
	@Name,
	@Price,
	@Description,
	@Picture
	)
END

GO

CREATE PROCEDURE edit_Product
(
	@ID	int,
	@Name nvarchar(50),
	@Price decimal(18,2),
	@Description nvarchar(250) = null,
	@Picture nvarchar(MAX) = null
)
AS
BEGIN
	UPDATE Products
    SET
	Name = @Name,
	Price = @Price,
	Description = @Description,
	Picture = @Picture
	WHERE
	ID = @ID
END

GO

CREATE PROCEDURE delete_Product
    @ID INT
AS
BEGIN
		DELETE FROM Products WHERE ID = @ID
END

GO

--Employees

CREATE PROCEDURE list_Employee
AS
BEGIN
	SELECT * FROM Employees
END

GO

CREATE PROCEDURE search_Employee
	@ID int
AS
BEGIN
	SELECT * FROM Employees
	WHERE
	ID = @ID
END

GO

CREATE PROCEDURE insert_Employee
(
	@FirstName nvarchar(30),
	@LastName nvarchar(30),
	@BDate date,
	@PhoneNumber decimal(10,0),
	@Email nvarchar(50),
	@Direction nvarchar (250),
	@Salary decimal(10,2)
)
AS
BEGIN
	INSERT INTO Employees VALUES
	(
	@FirstName,
	@LastName,
	@BDate,
	@PhoneNumber,
	@Email,
	@Direction,
	@Salary
	)
END

GO

CREATE PROCEDURE edit_Employee
(
	@ID int,
	@FirstName nvarchar(30),
	@LastName nvarchar(30),
	@BDate date,
	@PhoneNumber decimal(10,0),
	@Email nvarchar(50),
	@Direction nvarchar (250),
	@Salary decimal(10,2)
)
AS
BEGIN
	UPDATE Employees
    SET
	FirstName = @FirstName,
	LastName = @LastName,
	BDate = @BDate,
	PhoneNumber = @PhoneNumber,
	Email = @Email,
	Direction = @Direction,
	Salary = @Salary
	WHERE
	ID = @ID
END

GO

CREATE PROCEDURE delete_Employee
    @ID INT
AS
BEGIN
		DELETE FROM Employees WHERE ID = @ID
END

GO

--USERS

CREATE PROCEDURE list_User
AS
BEGIN
	SELECT * FROM Users
END

GO

CREATE PROCEDURE search_User
	@ID int
AS
BEGIN
	SELECT * FROM Users
	WHERE
	ID = @ID
END

GO

CREATE PROCEDURE insert_User
(
	@FirstName nvarchar(30),
	@LastName nvarchar(30),
	@PhoneNumber decimal(10,0),
	@Email nvarchar(50),
	@Password nvarchar(20)
)
AS
BEGIN
	INSERT INTO Users VALUES
	(
	@FirstName,
	@LastName,
	@PhoneNumber,
	@Email,
	@Password
	)
END

GO

CREATE PROCEDURE edit_User
(
	@ID int,
	@FirstName nvarchar(30),
	@LastName nvarchar(30),
	@PhoneNumber decimal(10,0),
	@Email nvarchar(50),
	@Password nvarchar(20)
)
AS
BEGIN
	UPDATE Users
    SET
	FirstName = @FirstName,
	LastName = @LastName,
	PhoneNumber = @PhoneNumber,
	Email = @Email,
	Password = @Password
	WHERE
	ID = @ID
END

GO

CREATE PROCEDURE delete_User
    @ID INT
AS
BEGIN
		DELETE FROM Users WHERE ID = @ID
END

GO

--Orders

CREATE PROCEDURE list_Orders
AS
BEGIN
	SELECT Orders.OrderID, Products.ID AS ProductID, Products.Name AS Product, 
	Orders.Quantity, (Products.Price * Orders.Quantity) AS Total_Price, Users.ID AS UserID, 
	Users.FirstName AS U_FirstName, Users.LastName AS U_LastName,
	Users.PhoneNumber AS U_Phone, Orders.Direction,
	Employees.ID AS EmployeeID, Employees.FirstName AS E_FirstName, 
	Employees.LastName AS E_LastName
	FROM Orders
	INNER JOIN Employees
	ON Employees.ID = Orders.EmployeeID
	INNER JOIN Products
	ON Products.ID = Orders.ProductID
	INNER JOIN Users
	ON Users.ID = Orders.UserID
END

GO

CREATE PROCEDURE insert_Order
(
	@ProductID int,
	@UserID int,
	@EmployeeID int,
	@Direction nvarchar(300),
	@Quantity int
)
AS
BEGIN
	INSERT INTO Orders VALUES
	(
	@ProductID,
	@UserID,
	@EmployeeID,
	@Direction,
	@Quantity
	)
END

GO

CREATE PROCEDURE delete_Order
    @OrderID INT
AS
BEGIN
		DELETE FROM Orders WHERE OrderID = @OrderID
END

