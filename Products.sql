CREATE TABLE Products
(
ProductId int IDENTITY PRIMARY KEY,
CategoryId int NOT NULL,
Name Varchar(255) NOT NULL,
ShortDescription Varchar(512) NOT NULL,
LongDescription Varchar(MAX) NOT NULL,
Price decimal NOT NULL,
SalePrice decimal NOT NULL,
IsOnSale bit NOT NULL,
ImageName Varchar(255) NOT NULL
);