use DB_CRUD
INSERT INTO dbo.Users (
      Login
      ,Password
      ,FirstName
      ,LastName
      ,DateOfBirth
      ,Gender)
VALUES ( 'user1', 'password1', 'den', 'red', '2002-01-11' , 'M'),
       ( 'user2', 'password2', 'de1', 're1', '1998-07-10' , 'M'),
       ( 'user3', 'password3', 'de2', 'red2', '1991-09-19' , 'M'),
       ( 'user4', 'password4', 'de2', 'red2', '2003-12-23' , 'F'); 

INSERT INTO dbo.Orders(
      UserID
      ,OrderDate
      ,OrderCost
      ,ItemsDescription
      ,ShippingAddress)
VALUES ( 1,'2022-12-11', 23.00, 'Red mouse', 'Lviv'),
       ( 2,'2023-01-09', 26.00, 'Blue letter', 'Kyiv'),
       ( 3,'2023-04-15', 227.00, 'White pc', 'Ternopil'),
       ( 4,'2002-05-29', 400.00, 'Red headphones', 'London'); 