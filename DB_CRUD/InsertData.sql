use DB_CRUD
INSERT INTO dbo.Users (
      Login
      ,Password
      ,FirstName
      ,LastName
      ,DateOfBirth
      ,Gender)
VALUES ( 'user1', 'password1', 'den', 'red', '2002-12-11' , 'M'),
       ( 'user2', 'password2', 'de1', 're1', '2002-12-11' , 'M'),
       ( 'user3', 'password2', 'de2', 'red2', '2002-12-11' , 'M'); 