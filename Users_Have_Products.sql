CREATE TABLE Users_Have_Products
(
Id int IDENTITY PRIMARY KEY,
[User_Id] int FOREIGN KEY REFERENCES Users(Id),
[Product_Id] int FOREIGN KEY REFERENCES Products(ProductId)
);