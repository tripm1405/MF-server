USE [tempdb]
GO

DROP DATABASE IF EXISTS [MangaFigure]
GO

CREATE DATABASE [MangaFigure]
GO

USE [MangaFigure]
GO

DROP TABLE IF EXISTS [Navbar]
GO
CREATE TABLE [Navbar] (
	[id] INT IDENTITY(1, 1),
	[name] VARCHAR(256),
	[meta] VARCHAR(256),
	[active] BIT DEFAULT 1,
	[order] INT,
	[create_at] DATETIME DEFAULT GETDATE(),

	PRIMARY KEY ([id])
)
GO

DROP TABLE IF EXISTS [Admin]
GO
CREATE TABLE [Admin] (
	[id] INT IDENTITY(1, 1),
	[username] VARCHAR(256),
	[password] VARCHAR(256),

	PRIMARY KEY ([id])
)
GO

DROP TABLE IF EXISTS [Employee]
GO
CREATE TABLE [Employee] (
	[id] INT IDENTITY(1, 1),
	[name] NVARCHAR(256),
	[username] VARCHAR(256),
	[password] VARCHAR(256),
	[address] NVARCHAR(256),
	[email] VARCHAR(256),
	[phone] VARCHAR(16),
	[birthday] DATETIME,
	[meta] VARCHAR(256),
	[active] BIT DEFAULT 1,
	[order] INT,
	[create_at] DATETIME DEFAULT GETDATE(),

	PRIMARY KEY ([id])
)
GO

DROP TABLE IF EXISTS [Customer]
GO
CREATE TABLE [Customer] (
	[id] INT IDENTITY(1, 1),
	[name] NVARCHAR(256),
	[username] VARCHAR(256),
	[password] VARCHAR(256),
	[address] NVARCHAR(256),
	[email] VARCHAR(256),
	[phone] VARCHAR(16),
	[birthday] DATETIME,
	[meta] VARCHAR(256),
	[active] BIT DEFAULT 1,
	[order] INT,
	[create_at] DATETIME DEFAULT GETDATE(),

	PRIMARY KEY ([id])
)
GO

DROP TABLE IF EXISTS [Catalog]
GO
CREATE TABLE [Catalog] (
	[id] INT IDENTITY(1, 1),
	[name] NVARCHAR(256),
	[type] BIT,
	[meta] VARCHAR(256),
	[active] BIT DEFAULT 1,
	[order] INT,
	[create_at] DATETIME DEFAULT GETDATE(),

	PRIMARY KEY ([id])
)
GO

DROP TABLE IF EXISTS [Product]
GO
CREATE TABLE [Product] (
	[id] INT IDENTITY(1, 1),
	[name] NVARCHAR(256),
	[description] TEXT,
	[image] INT,
	[type] BIT,
	[catalog] INT,
	[price] INT,
	[discount] INT,
	[amount] INT,
	[sale] INT,
	[meta] VARCHAR(256),
	[active] BIT DEFAULT 1,
	[order] INT,
	[create_at] DATETIME DEFAULT GETDATE(),

	PRIMARY KEY ([id])
)
GO

DROP TABLE IF EXISTS [ProductReview]
GO
CREATE TABLE [ProductReview] (
	[id] INT IDENTITY(1, 1),
	[product] INT,
	[customer] INT,
	[content] TEXT,
	[rate] INT,
	[meta] VARCHAR(256),
	[active] BIT DEFAULT 1,
	[order] INT,
	[create_at] DATETIME DEFAULT GETDATE(),

	PRIMARY KEY ([id])
)

DROP TABLE IF EXISTS [ProductImage]
GO
CREATE TABLE [ProductImage] (
	[id] INT IDENTITY(1, 1),
	[product] INT,
	[link] NVARCHAR(256),
	[meta] VARCHAR(256),
	[active] BIT DEFAULT 1,
	[order] INT,
	[create_at] DATETIME DEFAULT GETDATE(),

	PRIMARY KEY ([id])
)
GO

DROP TABLE IF EXISTS [Transaction]
GO
CREATE TABLE [Transaction] (
	[id] INT IDENTITY(1, 1),
	[customer] INT,
	[employee] INT,
	[status] INT DEFAULT 1,
	[rate] INT,
	[meta] VARCHAR(256),
	[active] BIT DEFAULT 1,
	[order] INT,
	[create_at] DATETIME DEFAULT GETDATE(),

	PRIMARY KEY ([id])
)
GO

DROP TABLE IF EXISTS [TransactionDetail]
GO
CREATE TABLE [TransactionDetail] (
	[id] INT IDENTITY(1, 1),
	[transaction] INT,
	[product] INT,
	[meta] VARCHAR(256),
	[active] BIT DEFAULT 1,
	[order] INT,
	[create_at] DATETIME DEFAULT GETDATE(),

	PRIMARY KEY ([id])
)
GO

DROP TABLE IF EXISTS [TransactionStatus]
GO
CREATE TABLE [TransactionStatus] (
	[id] INT IDENTITY(1, 1),
	[content] NVARCHAR(128),
	[meta] VARCHAR(256),
	[active] BIT DEFAULT 1,
	[order] INT,
	[create_at] DATETIME DEFAULT GETDATE(),

	PRIMARY KEY ([id])
)
GO

DROP TABLE IF EXISTS [Voucher]
GO
CREATE TABLE [Voucher] (
	[id] INT IDENTITY(1, 1),
	[name] NVARCHAR(256),
	[description] TEXT,
	[condition] TEXT,
	[type] INT,
	[percent] INT,
	[money] INT,
	[meta] VARCHAR(256),
	[active] BIT DEFAULT 1,
	[order] INT,
	[create_at] DATETIME DEFAULT GETDATE(),

	PRIMARY KEY ([id])
)
GO

DROP TABLE IF EXISTS [Cart]
GO
CREATE TABLE [Cart] (
	[id] INT IDENTITY(1, 1),
	[customer] INT,
	[product] INT,
	[meta] VARCHAR(256),
	[active] BIT DEFAULT 1,
	[order] INT,
	[create_at] DATETIME DEFAULT GETDATE(),

	PRIMARY KEY ([id])
)
GO

DROP TABLE IF EXISTS [Announcement]
GO
CREATE TABLE [Announcement] (
	[id] INT IDENTITY(1, 1),
	[title] NVARCHAR(128),
	[content] TEXT,
	[image] VARCHAR(256),
	[meta] VARCHAR(256),
	[active] BIT DEFAULT 1,
	[order] INT,
	[create_at] DATETIME DEFAULT GETDATE(),

	PRIMARY KEY ([id])
)
GO

DROP TABLE IF EXISTS [Header]
GO
CREATE TABLE [Header] (
	[id] INT IDENTITY(1, 1),
	[description] TEXT,
	[logo] VARCHAR(256),
	[meta] VARCHAR(256),
	[active] BIT DEFAULT 1,
	[order] INT,
	[create_at] DATETIME DEFAULT GETDATE(),

	PRIMARY KEY ([id])
)
GO

DROP TABLE IF EXISTS [SlideShow]
GO
CREATE TABLE [SlideShow] (
	[id] INT IDENTITY(1, 1),
	[image] VARCHAR(256),
	[meta] VARCHAR(256),
	[active] BIT DEFAULT 1,
	[order] INT,
	[create_at] DATETIME DEFAULT GETDATE(),

	PRIMARY KEY ([id])
)
GO

DROP TABLE IF EXISTS [Contact]
GO
CREATE TABLE [Contact] (
	[id] INT IDENTITY(1, 1),
	[name] VARCHAR(256),
	[link] VARCHAR(256),
	[meta] VARCHAR(256),
	[active] BIT DEFAULT 1,
	[order] INT,
	[create_at] DATETIME DEFAULT GETDATE(),

	PRIMARY KEY ([id])
)
GO

DROP TABLE IF EXISTS [Footer]
GO
CREATE TABLE [Footer] (
	[id] INT IDENTITY(1, 1),
	[description] TEXT,
	[logo] VARCHAR(256),
	[meta] VARCHAR(256),
	[active] BIT DEFAULT 1,
	[order] INT,
	[create_at] DATETIME DEFAULT GETDATE(),

	PRIMARY KEY ([id])
)
GO

INSERT INTO [Admin] ([username], [password]) VALUES 
('admin', '123456')
GO

INSERT INTO [Announcement] ([title], [content],[image]) VALUES 
('Thong bao giam gia ngay 1/6', 'Thong bao giam gia ngay 1/6','1.jpg'),
('Thong bao giam gia ngay 1/4', 'Thong bao giam gia ngay 1/4','1.jpg'),
('Thong bao giam gia ngay 10/3 ', 'Thong bao giam gia ngay 10/3','1.jpg')
GO

INSERT INTO [Employee] ([name], [username], [password], [email], [address], [phone], [birthday]) VALUES 
(N'Nguyễn Thanh Thúy', 'nguyenthanhthuy', '123456', '', N'142 Đ. Ba Đình, Phường 10, Quận 8', '0826361554', '1998-03-02'),
(N'Phạm Minh Trí', 'phamminhtri', '123456', '', N'587 Lê Văn Lương, Tân Phong, Quận 7', '03348152847', '1995-07-16'),
(N'Nguyễn Thị Hương Giang', 'nguyenthihuonggiang', '', '123456', N'142 Đ. Ba Đình, Phường 10, Quận 8', '0826361554', '1999-09-23')
GO

INSERT INTO [Customer] ([name], [username], [password], [email], [address], [phone], [birthday]) VALUES 
(N'Trần Hủ Nữ', 'tranhunu', '123456', '', N'328 Đường Võ Văn Kiệt, Cô Giang, Quận 1', '0825165948', '2003-05-12'),
(N'Đào Nữ Huế', 'daonuhue', '123456', '', N'59 Pasteur, Bến Nghé, Quận 1', '03315244859', '1997-01-21'),
(N'Lê Sạt Boi', 'lesatboi', '123456', '', N'47 Đường Nguyễn Trãi, Bến Thành, Quận 1', '0823564548', '2001-11-06')
GO

INSERT INTO [Catalog] ([name], [type], [meta]) VALUES 
('Horror', 0, 'horror'),
('Comedy', 0, 'comedy'),
('Action', 0, 'action'),
('Naruto', 1, 'naruto'),
('One Piece', 1, 'one-piece'),
('Dragon Ball', 1, 'dragon-ball'),
('Re Zero', 1, 're-zero'),
('Fantasy', 0, 'fantasy')
GO

INSERT INTO [Product] ([name], [description], [type], [image], [catalog], [price]) VALUES 
('Naruto 1', 'naruto0.jpg', 0, 1, 3, 25600),
('Naruto 2', 'naruto1.jpg', 0, 2, 3, 25600),
('Naruto 3', 'naruto2.jpg', 0, 3, 3, 25600),
('Naruto 4', 'naruto3.jpg', 0, 4, 3, 25600),
('Naruto 5', 'naruto4.jpg', 0, 5, 3, 25600),
('Naruto 6', 'naruto5.jpg', 0, 6, 3, 25600),
('Naruto 7', 'naruto6.jpg', 0, 7, 3, 25600),
('Naruto 8', 'naruto7.jpg', 0, 8, 3, 25600),
('Goku SS3', 'naruto8.jpg', 1, 9, 6, 3200000),
('Naruto', 'naruto9.jpg', 1, 10, 3, 160000),
('Luffy', 'naruto10.jpg', 1, 11, 5, 256000),
('Nami', 'drama1.jpg', 1, 12, 5, 800000),
('Sasuke', 'drama2.jpg', 1, 13, 4, 512000),
('Kakashi', 'drama3.jpg', 1, 14, 4, 2048000),
('Kuruma', 'drama4.jpg', 1, 15, 4, 160000),
('Sakura', 'drama5.jpg', 1, 16, 4, 1280000),
('Doraemon 1', 'drama6.jpg', 0, 1, 8, 25600),
('Doraemon 2', 'drama7.jpg', 0, 2, 8, 25600),
('Doraemon 3', 'drama8.jpg', 0, 3, 8, 25600),
('Doraemon 4', 'drama9.jpg', 0, 4, 8, 25600),
('Doraemon 5', 'drama10.jpg', 0, 5, 8, 25600),
('Doraemon 6', 'drama11.jpg', 0, 6, 8, 25600),
('Doraemon 7', 'drama12.jpg', 0, 7, 8, 25600),
('Doraemon 8', 'drama13.jpg', 0, 8, 8, 25600),
('Mabu', 'dragonBall0.jpg', 1, 9, 6, 3200000),
('GenShin 1', 'dragonBall1.jpg', 1, 10, 4, 160000),
('GenShin 2', 'dragonBall2.jpg', 1, 11, 5, 256000),
('GenShin 3', 'dragonBall3.jpg', 1, 12, 5, 800000),
('Nezuko Kamado', 'dragonBall5.jpg', 1, 13, 4, 512000),
('Kimono', 'dragonBall6.jpg', 1, 14, 4, 2048000),
('Kimetsu', 'dragonBall7.jpg', 1, 15, 4, 160000),
('Marvel', 'dragonBall8.jpg', 1, 16, 4, 1280000),
('Goku SS3', 'dragonBall1.jpg', 1, 9, 6, 3200000),
('Naruto', 'naruto22.jpg', 1, 10, 4, 160000),
('Luffy', 'naruto22.jpg', 1, 11, 5, 256000),
('Nami', 'naruto24.jpg', 1, 12, 5, 800000),
('Sasuke', 'naruto25.jpg', 1, 13, 4, 512000),
('Kakashi', 'naruto21.jpg', 1, 14, 4, 2048000),
('Kuruma', 'naruto20.jpg', 1, 15, 4, 160000),
('Sakura', 'naruto18.jpg', 1, 16, 4, 1280000),
('Conan 1', 'scientfiction1.jpg', 0, 1, 1, 25600),
('Conan 2', 'scientfiction2.jpg', 0, 2, 1, 25600),
('Conan 3', 'scientfiction3.jpg', 0, 3, 1, 25600),
('Conan 4', 'scientfiction4.jpg', 0, 4, 1, 25600),
('Conan 5', 'scientfiction5.jpg', 0, 5, 1, 25600),
('Conan 6', 'scientfiction6.jpg', 0, 6, 1, 25600),
('Conan 7', 'scientfiction7.jpg', 0, 7, 1, 25600),
('Conan 8', 'scientfiction8.jpg', 0, 8, 1, 25600),
('Boa Hancock 2', 'romance1.jpg', 1, 9, 5, 3200000),
('Boa Hancock 4', 'romance2.jpg', 1, 10, 5, 160000),
('Boa Hancock 5', 'romance3.jpg', 1, 11, 5, 256000),
('Boa Hancock 6', 'romance4.jpg', 1, 12, 5, 800000),
('Dragon Ball 1', 'DragonBall0.jpg', 1, 13, 6, 512000),
('Dragon Ball 2', 'DragonBall1.jpg', 1, 14, 6, 2048000),
('Dragon Ball 3', 'DragonBall2.jpg', 1, 15, 6, 160000),
('Dragon Ball 4', 'DragonBall3.jpg', 1, 15, 6, 160000),
('Dragon Ball 5', 'DragonBall4.jpg', 1, 15, 6, 160000),
('Dragon Ball 6', 'DragonBall5.jpg', 1, 16, 6, 1280000)
GO

INSERT INTO [ProductImage] ([product], [link]) VALUES
(1, 'naruto0.jpg'),
(2, 'naruto2.jpg'),
(3, 'naruto3.jpg'),
(4, 'naruto4.jpg'),
(5, 'naruto5.jpg'),
(6, 'naruto6.jpg'),
(7, 'naruto7.jpg'),
(8, 'naruto8.jpg'),
(9, 'naruto10.jpg'),
(10, 'drama2.jpg'),
(11, 'drama3.jpg'),
(12, 'drama4.jpg'),
(13, 'drama5.jpg'),
(14, 'drama6.jpg'),
(15, 'drama7.jpg'),
(16, 'drama8.jpg'),
(1, 'naruto1.jpg')
GO

INSERT INTO [TransactionStatus] ([content]) VALUES 
(N'Chờ xử lý'),
(N'Đã xác nhận'),
(N'Đang vận chuyển'),
(N'Đã thanh toán'),
(N'Hủy')
GO

INSERT INTO [Transaction] ([customer], [employee],[status],[rate]) VALUES 
(1,1,1,5),
(2,1,1,4),
(3,1,2,5),
(1,2,1,4),
(2,2,1,5),
(3,2,1,4),
(3,3,2,5),
(1,3,1,4)
GO

INSERT INTO [TransactionDetail] ([transaction], [product]) VALUES 
(1,1),
(2,1),
(3,2),
(4,1),
(1,5),
(3,4),
(3,5),
(7,3)
GO

INSERT INTO [ProductReview] ([product], [customer],[content],[rate]) VALUES 
(1,1,N'tuyet ca la voi',5),
(2,1,N'san pham dung qua oke',5),
(3,2,N'tam on',4),
(4,2,N'qua la hay',5),
(5,3,N'tuyet ca la voi',5),
(4,3,N'san pham dung qua oke',5),
(3,1,N'tam on',4),
(2,3,N'qua la hay',5)
GO

INSERT INTO [Voucher] ([name], [description],[condition],[type],[percent],[money]) VALUES 
(N'Giảm giá 10%',N'Sản phẩm được 10%',N'hóa đơn trên 100k',1,10,40000),
(N'Giảm giá 15%',N'Sản phẩm được 15%',N'hóa đơn trên 200k',1,15,40000),
(N'Giảm giá 20%',N'Sản phẩm được 20%',N'hóa đơn trên 400k',1,20,40000),
(N'Mua 1 tặng 1',N'Mua một sản phẩm bất kỳ được tặng thêm một cuốn sách Naruto shippuden Volume 1',N'hóa đơn trên 100k',1,0,40000),
(N'Giảm giá 5%',N'Sản phẩm được 5%',N'hóa đơn trên 50k',1,5,40000),
(N'Giảm giá 15%',N'Sản phẩm được 15%',N'hóa đơn trên 200k',1,10,40000),
(N'Giảm giá 20%',N'Sản phẩm được 20%',N'hóa đơn trên 400k',1,10,40000),
(N'Mua 1 tặng 1',N'Mua một sản phẩm bất kỳ được tặng thêm một cuốn sách Naruto shippuden Volume 1',N'hóa đơn trên 100k',1,10,40000)

GO

INSERT INTO [Header] ([logo]) VALUES
('1.png')
GO

INSERT INTO [SlideShow] ([image]) VALUES
('1.png'),
('2.png'),
('3.png'),
('4.png')
GO

INSERT INTO [Contact] ([link]) VALUES
('https://www.twitter.con'),
('https://www.facebook.com'),
('https://www.instagram.com')
GO

INSERT INTO [Footer] ([description], [logo]) VALUES
('Lorem ipsum dolor sit amet consectetur adipisicing elit. Quis', '1_white.jpg')
GO

ALTER TABLE [Product] ADD
CONSTRAINT [Product_catalog] FOREIGN KEY ([catalog]) REFERENCES [Catalog]([id]),
CONSTRAINT [Product_image] FOREIGN KEY ([image]) REFERENCES [ProductImage]([id])
GO

ALTER TABLE [ProductImage] ADD
CONSTRAINT [ProductImage_product] FOREIGN KEY ([product]) REFERENCES [Product]([id])
GO

ALTER TABLE [ProductReview] ADD
CONSTRAINT [ProductReview_customer] FOREIGN KEY ([customer]) REFERENCES [Customer]([id])
GO

ALTER TABLE [Transaction] ADD
CONSTRAINT [Transaction_status] FOREIGN KEY ([status]) REFERENCES [TransactionStatus]([id]),
CONSTRAINT [Transaction_employee] FOREIGN KEY ([employee]) REFERENCES [Employee]([id]),
CONSTRAINT [Transaction_customer] FOREIGN KEY ([customer]) REFERENCES [Customer]([id])
GO

ALTER TABLE [TransactionDetail] ADD
CONSTRAINT [TransactionDetail_transaction] FOREIGN KEY ([transaction]) REFERENCES [Transaction]([id]),
CONSTRAINT [TransactionDetail_product] FOREIGN KEY ([product]) REFERENCES [Product]([id])
GO

ALTER TABLE [Cart] ADD
CONSTRAINT [Cart_customer] FOREIGN KEY ([customer]) REFERENCES [Customer]([id]),
CONSTRAINT [Cart_product] FOREIGN KEY ([product]) REFERENCES [Product]([id])
GO