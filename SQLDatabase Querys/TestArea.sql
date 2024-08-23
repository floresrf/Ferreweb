use Webshop

create database Webshop

--TEST AREA

exec list_Employee
exec list_User
exec list_Product
exec list_Orders

exec insert_Employee 'Carl','Johnson','07-19-1969',5551245,'carl.johnson.1969@hotmail.com','Ganton 4, Los Santos',2950

exec insert_Order 2,1,1,'Avenida Siempre Viva 1234',3
