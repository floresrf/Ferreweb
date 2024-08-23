--1,2,3
CREATE VIEW View_ProductoDescontinuado
AS
SELECT PRODUCTS.ProductName, Suppliers.CompanyName, Categories.CategoryName 
FROM Products JOIN Suppliers
ON Products.SupplierID = SupplierS.SupplierID
JOIN Categories
ON Products.CategoryID = Categories.CategoryID
WHERE Products.Discontinued = 1

SELECT * FROM View_ProductoDescontinuado

--4
SELECT Customers.ContactName, COUNT(ORDERID) AS Total_Orders
FROM Customers
JOIN Orders
ON Customers.CustomerID = Orders.CustomerID
GROUP BY ContactName
HAVING COUNT(ORDERID) = 0
ORDER BY ContactName ASC;

--5 Hacer una consulta avanzada para Obtener todos los productos de la Orden 10284 calcular el
--total que pago en esa orden (contemplar para el cálculo el descuento si aplica en algún
--producto)
SELECT * FROM [Order Details]
WHERE ORDERID = 10284

SELECT [Order Details].OrderID, SUM(UNITPRICE * QUANTITY * (1 - DISCOUNT)) AS TOTAL
FROM [Order Details]
GROUP BY OrderID
HAVING OrderID = 10284

--6 Seleccionar por cada cliente el total de pedidos realizados por cada uno, todos los clientes
--seleccionados tienen que tener por lo menos un pedido.

SELECT Customers.ContactName, COUNT(ORDERID) AS Total_Orders
FROM Customers
JOIN Orders
ON Customers.CustomerID = Orders.CustomerID
GROUP BY ContactName
HAVING COUNT(ORDERID) > 1
ORDER BY ContactName ASC;

--7 
SELECT * FROM [Order Details]
SELECT * FROM ORDERS

SELECT ORDERS.ORDERID, EMPLOYEES.EMPLOYEEID, (UNITPRICE * QUANTITY * (1 - DISCOUNT)) AS TOTAL
FROM ORDERS
JOIN EMPLOYEES
ON ORDERS.EMPLOYEEID = EMPLOYEES.EMPLOYEEID
JOIN [ORDER DETAILS]
ON [ORDER DETAILS].ORDERID = ORDERS.ORDERID
WHERE EMPLOYEES.EMPLOYEEID IN (1, 4, 7)
GROUP BY UNITPRICE, QUANTITY, DISCOUNT, ORDERS.ORDERID, EMPLOYEES.EMPLOYEEID
HAVING (UNITPRICE * QUANTITY * (1 - DISCOUNT)) > 50
ORDER BY EmployeeID ASC

--8 Hacer una consulta avanzada para Obtener la cantidad de productos por nombre de
--vendedor, región y categoría, además que la región no sea nula (utilizando having).

SELECT * FROM Suppliers
SELECT * FROM CATEGORIES
SELECT * FROM [ORDER DETAILS]
SELECT * FROM PRODUCTS

SELECT PRODUCTS.PRODUCTNAME, SUPPLIERS.COMPANYNAME, SUPPLIERS.REGION, CATEGORIES.CATEGORYNAME
FROM PRODUCTS
JOIN SUPPLIERS
ON PRODUCTS.SUPPLIERID = SUPPLIERS.SUPPLIERID
JOIN CATEGORIES
ON PRODUCTS.CATEGORYID = CATEGORIES.CATEGORYID
WHERE SUPPLIERS.REGION IS NOT NULL
