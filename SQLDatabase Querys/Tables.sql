use Webshop

GO

create table Products(
	ID int identity Primary key,
	Name nvarchar(50) not null,
	Price decimal(18,2) not null,
	Description nvarchar(250),
	Picture nvarchar(MAX)
)

GO

create table Employees(
	ID int identity Primary key,
	FirstName nvarchar(30) not null,
	LastName nvarchar(30) not null,
	BDate date not null,
	PhoneNumber decimal(10,0) not null,
	Email nvarchar(50) not null,
	Direction nvarchar (250) not null,
	Salary decimal(10,2) not null
)

GO

create table Users(
	ID int identity Primary key,
	FirstName nvarchar(30) not null,
	LastName nvarchar(30) not null,
	PhoneNumber decimal(10,0) not null,
	Email nvarchar(50) not null,
	Password nvarchar(20) not null
)

GO

create table Orders(
	OrderID int identity PRIMARY KEY,
	ProductID int FOREIGN KEY REFERENCES Products(ID),
	UserID int FOREIGN KEY REFERENCES Users(ID),
	EmployeeID int FOREIGN KEY REFERENCES Employees(ID),
	Direction nvarchar(300),
	Quantity int
)

