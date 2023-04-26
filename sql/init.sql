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
	[amount] INT,
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
(N'Nguyễn Thanh Thúy', 'nguyenthanhthuy', '$2a$11$Dxv02GFIM7gw6MzbfLTnRe4dDFqEpIRtOJF.l/hxfyunq5gnbIF/i', 'nguyenthanhthuy@gmail.com', N'142 Đ. Ba Đình, Phường 10, Quận 8, Hồ Chí Minh', '0826361554', '1998-03-02'),
(N'Phạm Minh Trí', 'phamminhtri', '$2a$11$VtvLM6NGKxqOlRGsqAEYx.lCz9iP.0Kamv4xtXeUqWSFTBj/kwVcu', 'phamminhtri@gmail.com', N'587 Lê Văn Lương, Phường Tân Phong, Quận 7, Hồ Chí Minh', '03348152847', '1995-07-16'),
(N'Nguyễn Thị Hương Giang', 'nguyenthihuonggiang', '$2a$11$rtY.5stvL5TnXykoSpf5yeNCn.lrbLkQew4jJRoawGzt7R.IYMtMm', 'nguyenthihuonggiang@gmail.com', N'142 Đ. Ba Đình, Phường 10, Quận 8, Hồ Chí Minh', '0826361554', '1999-09-23')
GO

INSERT INTO [Customer] ([name], [username], [password], [email], [address], [phone], [birthday]) VALUES 
(N'Trần Hủ Nữ', 'tranhunu', '$2a$11$nFdtU2ynrHDz2sEb4ae.n.pYbclWQpdv8DrvMPRgBgwiiMef8PtA2', 'tranhunu@gmail.com', N'328 Đường Võ Văn Kiệt, Phường Cô Giang, Quận 3, Hồ Chí Minh', '0825165948', '2003-05-12'),
(N'Đào Nữ Huế', 'daonuhue', '$2a$11$lq4xsC2cG.mEeTqgYwReVeBYDzRQLQTv4Bk1zZFHZtN1UypzgQs5q', 'daonuhue@gmail.com', N'59 Pasteur, Phường Bến Nghé, Quận 1, Hồ Chí Minh', '03315244859', '1997-01-21'),
(N'Lê Sạt Boi', 'lesatboi', '$2a$11$CXBOWBfbN6FqJ6LcZRS/g.L3lSsbao0UbSNRgsbFjbwLJSXju7S8G', 'lesatboi@gmail.com', N'47 Đường Nguyễn Trãi, Phường Bến Thành, Quận 1, Hồ Chí Minh', '0823564548', '2001-11-06')
GO

INSERT INTO [Catalog] ([name], [type], [meta]) VALUES 
('Horror', 0, 'horror'),
('Comedy', 0, 'comedy'),
('Action', 0, 'action'),
('Naruto', 1, 'naruto'),
('One Piece', 1, 'one-piece'),
('Dragon Ball', 1, 'dragon-ball'),
('Re Zero', 1, 're-zero'),
('Fantasy', 0, 'fantasy'),
('Drama',0,'drama'),
('Science fiction',0,'science-fiction'),
('Romance', 0, 'romance')
GO

--SELECT * FROM [Catalog]

INSERT INTO [Product] ([name], [description], [type], [image], [catalog], [price], [discount], [amount], [meta]) VALUES 
('Naruto 1', '', 1, 1, 4, 25600, 0, 15, 'naruto-1'),
('Naruto 2', '', 1, 2, 4, 25600, 0, 15, 'naruto-2'),
('Naruto 3', '', 1, 3, 4, 25600, 0, 15, 'naruto-3'),
('Naruto 4', '', 1, 4, 4, 25600, 0, 15, 'naruto-4'),
('Naruto 5', '', 1, 5, 4, 25600, 0, 15, 'naruto-5'),
('Naruto 6', '', 1, 6, 4, 25600, 0, 15, 'naruto-6'),
('Naruto 7', '', 1, 7, 4, 25600, 0, 15, 'naruto-7'),
('Naruto 8', '', 1, 8, 4, 25600, 0, 15, 'naruto-8'),
('Naruto 9', '', 1, 9, 4, 3200000, 0, 15, 'naruto-9'),
('Naruto 10', '', 1, 10, 4, 160000, 0, 15, 'naruto-10'),
('Naruto 11', '', 1, 11, 4, 256000, 0, 15, 'naruto-11'),
('Me My husband and my husbands boyfriend', '', 0, 12, 9, 800000, 0, 15, 'me-my-husband-and-my-husbands-boyfriend'),
('Better or for worst', '', 0, 13, 9, 512000, 0, 15, 'better-or-for-worst'),
('Beneath the mask', '', 0, 14, 9, 2048000, 0, 15, 'beneath-the-mask'),
('Marry for love', '', 0, 15, 9, 160000, 0, 15, 'marry-for-love'),
('Playing house in the job', '', 0, 16, 9, 1280000, 0, 15, 'playing-house-in-the-job'),
('The earl want lady spitfire', '', 0, 17, 9, 25600, 0, 15, 'the-earl-want-lady-spitfire'),
('If it is chipped', '', 0, 18, 9, 25600, 0, 15, 'if-it-is-chipped'),
('Strawberry canyon', '', 0, 19, 9, 25600, 0, 15, 'strawberry-canyon'),
('Two-faced', '', 0, 20, 9, 25600, 0, 15, 'two-faced'),
('Place in life', '', 0, 21, 9, 25600, 0, 15, 'place-in-life'),
('My magnificent', '', 0, 22, 9, 25600, 0, 15, 'my-magnificent'),
('Eyeing shiba', '', 0, 23, 9, 25600, 0, 15, 'eyeing-shiba'),
('Live her new life', '', 0, 24, 9, 25600, 0, 15, 'live-her-new-life'),
('Dragon Ball 0', '', 1, 25, 6, 3200000, 0, 15, 'dragon-ball-0'),
('Dragon Ball 1', '', 1, 26, 6, 160000, 0, 15, 'dragon-ball-1'),
('Dragon Ball 2', '', 1, 27, 6, 256000, 0, 15, 'dragon-ball-2'),
('Dragon Ball 3', '', 1, 28, 6, 800000, 0, 15, 'dragon-ball-3'),
('Dragon Ball 4', '', 1, 29, 6, 512000, 0, 15, 'dragon-ball-4'),
('Dragon Ball 5', '', 1, 30, 6, 2048000, 0, 15, 'dragon-ball-5'),
('Dragon Ball 6', '', 1, 31, 6, 3200000, 0, 15, 'dragon-ball-6'),
('Dragon Ball 7', '', 1, 32, 6, 160000, 0, 15, 'dragon-ball-7'),
('Dragon Ball 8', '', 1, 33, 6, 256000, 0, 15, 'dragon-ball-8'),
('Naruto 18', '', 1, 34, 4, 25600, 0, 15, 'naruto-18'),
('Naruto 19', '', 1, 35, 4, 25600, 0, 15, 'naruto-19'),
('Naruto 20', '', 1, 36, 4, 25600, 0, 15, 'naruto-20'),
('Naruto 21', '', 1, 37, 4, 25600, 0, 15, 'naruto-21'),
('Naruto 22', '', 1, 38, 4, 25600, 0, 15, 'naruto-22'),
('Naruto 23', '', 1, 39, 4, 25600, 0, 15, 'naruto-23'),
('Naruto 24', '', 1, 40, 4, 25600, 0, 15, 'naruto-24'),
('Obey me', '', 0, 41,  1, 25600, 0, 15, 'obey-me'),
('It is because you keep doing', '', 0, 42, 10, 25600, 0, 15, 'it-because-you-keep-doing'),
('Beneath the mask', '', 0, 43, 10, 25600, 0, 15, 'beneath-the-mask'),
('Dont count your tanukis', '', 0, 44, 10, 25600, 0, 15, 'dont-count-your-tanukis'),
('Obey me 2', '', 0, 45, 10, 25600, 0, 15, 'obey-me-2'),
('Madly in love with you', '', 0, 46, 10, 25600, 0, 15, 'madly-in-love-with-you'),
('Out of the bad ending', '', 0, 47, 10, 25600, 0, 15, 'out-of-the-bad-ending'),
('Shotgun divorce', '', 0, 48, 10, 25600, 0, 15, 'shotgun-divorce'),
('Your voice is sour', '', 0, 49, 10, 3200000, 0, 15, 'your-voice-is-sour'),
('Down the rapid hole', '', 0, 50, 10, 160000, 0, 15, 'down-the-rapid-hole'),
('Madly in love with me', '', 0, 51, 10, 256000, 0, 15, 'madly-in-love-with-me'),
('Wedding night', '', 0, 52, 10, 800000, 0, 15, 'wedding-night'),
('Dragon Ball 10', '', 1, 53, 6, 512000, 0, 15, 'dragon-ball-10'),
('Dragon Ball 11', '', 1, 54, 6, 2048000, 0, 15, 'dragon-ball-11'),
('Dragon Ball 12', '', 1, 55, 6, 160000, 0, 15, 'dragon-ball-12'),
('Dragon Ball 13', '', 1, 56, 6, 160000, 0, 15, 'dragon-ball-13'),
('Dragon Ball 14', '', 1, 57, 6, 160000, 0, 15, 'dragon-ball-14'),
('Dragon Ball 15', '', 1, 58, 6, 1280000, 0, 15, 'dragon-ball-15'),
('But I want to survive', '', 0, 59, 3, 2048000, 0, 15, 'but-i-want-to-survive'),
('Fort of apocalypse', '', 0, 60, 3, 160000, 0, 15, 'fort-of-apocalypse'),
('Basilist', '', 0, 61, 3, 160000, 0, 15, 'basilist'),
('Attack on titan', '', 0, 62, 3, 160000, 0, 15, 'attack-on-titan'),
('Rave master', '', 0, 63, 3, 1280000, 0, 15, 'rave-master'),
('Fair tail 1', '', 0, 64, 3, 512000, 0, 15, 'fair-tail-1'),
('Fair tail 2', '', 0, 65, 3, 2048000, 0, 15, 'fair-tail-2'),
('Ice trail', '', 0, 66, 3, 160000, 0, 15, 'ice-trail'),
('100 years quest', '', 0, 67, 3, 160000, 0, 15, '100-years-quest'),
('Action 10', '', 0, 68, 3, 160000, 0, 15, 'action-10'),
('Action 11', '', 0, 69, 3, 2048000, 0, 15, 'action-11'),
('Action 12', '', 0, 70, 3, 160000, 0, 15, 'action-12'),
('Action 13', '', 0, 71, 3, 160000, 0, 15, 'action-13'),
('Action 14', '', 0, 72, 3, 160000, 0, 15, 'action-14'),
('Action 15', '', 0, 73, 3, 1280000, 0, 15, 'action-15'),
('Action 16', '', 0, 74, 3, 512000, 0, 15, 'action-16'),
('Action 17', '', 0, 75, 3, 2048000, 0, 15, 'action-17'),
('Action 18', '', 0, 76, 3, 160000, 0, 15, 'action-18'),
('Action 19', '', 0, 77, 3, 160000, 0, 15, 'action-19'),
('Action 20', '', 0, 78, 3, 160000, 0, 15, 'action-20'),
('Action 21', '', 0, 79, 3, 2048000, 0, 15, 'action-21'),
('Action 22', '', 0, 80, 3, 160000, 0, 15, 'action-22'),
('Action 23', '', 0, 81, 3, 160000, 0, 15, 'action-23'),
('Action 24', '', 0, 82, 3, 160000, 0, 15, 'action-24'),
('Action 25', '', 0, 83, 3, 1280000, 0, 15, 'action-25'),
('Naruto 11', '', 0, 84, 3, 512000, 0, 15, 'naruto-11'),
('Naruto 12', '', 0, 85, 3, 2048000, 0, 15, 'naruto-12'),
('Naruto 13', '', 0, 86, 3, 160000, 0, 15, 'naruto-13'),
('Naruto 14', '', 0, 87, 3, 160000, 0, 15, 'naruto-14'),
('Naruto 15', '', 0, 88, 3, 160000, 0, 15, 'naruto-15'),
('Naruto 16', '', 0, 89, 3, 2048000, 0, 15, 'naruto-16'),
('Drama 14', '', 0, 90, 9, 160000, 0, 15, 'drama-14'),
('Drama 15', '', 0, 91, 9, 2048000, 0, 15, 'drama-15'),
('Drama 16', '', 0, 92, 9, 160000, 0, 15, 'drama-16'),
('Drama 17', '', 0, 93, 9, 160000, 0, 15, 'drama-17'),
('Drama 18', '', 0, 94, 9, 160000, 0, 15, 'drama-18'),
('Drama 19', '', 0, 95, 9, 1280000, 0, 15, 'drama-19'),
('Drama 20', '', 0, 96, 9, 512000, 0, 15, 'drama-20'),
('Drama 21', '', 0, 97, 9, 2048000, 0, 15, 'drama-21'),
('Drama 22', '', 0, 98, 9, 160000, 0, 15, 'drama-22'),
('Drama 23', '', 0, 99, 9, 160000, 0, 15, 'drama-23'),
('Drama 24', '', 0, 100, 9, 160000, 0, 15, 'drama-24'),
('Drama 25', '', 0, 101, 9, 2048000, 0, 15, 'drama-25'),
('Drama 26', '', 0, 102, 9, 160000, 0, 15, 'drama-26'),
('Naruto 25', '', 1, 103, 4, 1280000, 0, 15, 'naruto-25'),
('Naruto 26', '', 1, 104, 4, 512000, 0, 15, 'naruto-26'),
('Naruto 27', '', 1, 105, 4, 2048000, 0, 15, 'naruto-27'),
('Naruto 28', '', 1, 106, 4, 160000, 0, 15, 'naruto-28'),
('Naruto 29', '', 1, 107, 4, 160000, 0, 15, 'naruto-29'),
('Naruto 30', '', 1, 108, 4, 160000, 0, 15, 'naruto-30'),
('Naruto 31', '', 1, 109, 4, 2048000, 0, 15, 'naruto-31'),
('Naruto 32', '', 1, 110, 4, 160000, 0, 15, 'naruto-32'),
('Naruto 17', '', 1, 111, 4, 160000, 0, 15, 'naruto-17'),
('OnePiece 1', '', 1, 112, 4, 1280000, 0, 15, 'onePiece-1'),
('OnePiece 2', '', 1, 113, 4, 512000, 0, 15, 'onePiece-2'),
('OnePiece 3', '', 1, 114, 4, 2048000, 0, 15, 'onePiece-3'),
('OnePiece 4', '', 1, 115, 4, 160000, 0, 15, 'onePiece-4'),
('OnePiece 5', '', 1, 116, 4, 160000, 0, 15, 'onePiece-5'),
('OnePiece 6', '', 1, 117, 4, 160000, 0, 15, 'onePiece-6'),
('OnePiece 7', '', 1, 118, 4, 2048000, 0, 15, 'onePiece-7'),
('OnePiece 8', '', 1, 119, 4, 160000, 0, 15, 'onePiece-8'),
('OnePiece 9', '', 1, 120, 4, 160000, 0, 15, 'onePiece-9'),
('OnePiece10', '', 1, 121, 4, 160000, 0, 15, 'onePiece-10'),
('OnePiece11', '', 1, 122, 4, 160000, 0, 15, 'onePiece-11'),
('Drama 12', '', 0, 123, 9, 160000, 0, 15, 'onePiece-11'),
('Drama 13', '', 0, 124, 9, 160000, 0, 15, 'onePiece-11'),
('Dragon Ball 16', '', 1, 125, 6, 160000, 0, 15, 'dragon-ball-16'),
('Dragon Ball 17', '', 1, 126, 6, 2048000, 0, 15, 'dragon-ball-17'),
('Dragon Ball 18', '', 1, 127, 6, 160000, 0, 15, 'dragon-ball-18'),
('Dragon Ball 19', '', 1, 128, 6, 160000, 0, 15, 'dragon-ball-19'),
('Dragon Ball 20', '', 1, 129, 6, 160000, 0, 15, 'dragon-ball-20'),
('Dragon Ball 21', '', 1, 130, 6, 1280000, 0, 15, 'dragon-ball-21'),
('Dragon Ball 22', '', 1, 131, 6, 512000, 0, 15, 'dragon-ball-22'),
('Dragon Ball 23', '', 1, 132, 6, 2048000, 0, 15, 'dragon-ball-23'),
('Dragon Ball 24', '', 1, 133, 6, 160000, 0, 15, 'dragon-ball-24'),
('Dragon Ball 25', '', 1, 134, 6, 160000, 0, 15, 'dragon-ball-25'),
('Dragon Ball 26', '', 1, 135, 6, 160000, 0, 15, 'dragon-ball-26'),
('Dragon Ball 27', '', 1, 136, 6, 2048000, 0, 15, 'dragon-ball-27'),
('Dragon Ball 28', '', 1, 137, 6, 160000, 0, 15, 'dragon-ball-28'),
('Dragon Ball 29', '', 1, 138, 6, 160000, 0, 15, 'dragon-ball-29'),
('Dragon Ball 30', '', 1, 139, 6, 160000, 0, 15, 'dragon-ball-30'),
('Dragon Ball 31', '', 1, 140, 6, 1280000, 0, 15, 'dragon-ball-31'),
('Dragon Ball 32', '', 1, 141, 6, 512000, 0, 15, 'dragon-ball-32'),
('Dragon Ball 33', '', 1, 142, 6, 2048000, 0, 15, 'dragon-ball-33'),
('Dragon Ball 34', '', 1, 143, 6, 160000, 0, 15, 'dragon-ball-34'),
('Dragon Ball 35', '', 1, 144, 6, 160000, 0, 15, 'dragon-ball-35'),
('Dragon Ball 36', '', 1, 145, 6, 160000, 0, 15, 'dragon-ball-36'),
('Scient Fiction 9', '', 0, 146, 10, 160000, 0, 15, 'scient-fiction-9'),
('Scient Fiction 10', '', 0, 147, 10, 160000, 0, 15, 'scient-fiction-10'),
('Scient Fiction 11', '', 0, 148, 10, 160000, 0, 15, 'scient-fiction-11'),
('Scient Fiction 12', '', 0, 149, 10, 1280000, 0, 15, 'scient-fiction-12'),
('Scient Fiction 13', '', 0, 150, 10, 512000, 0, 15, 'scient-fiction-13'),
('Scient Fiction 14', '', 0, 151, 10, 2048000, 0, 15, 'scient-fiction-14'),
('Scient Fiction 15', '', 0, 152, 10, 160000, 0, 15, 'scient-fiction-15'),
('Scient Fiction 16', '', 0, 153, 10, 160000, 0, 15, 'scient-fiction-16'),
('Scient Fiction 17', '', 0, 154, 10, 160000, 0, 15, 'scient-fiction-17'),
('Scient Fiction 18', '', 0, 155, 10, 2048000, 0, 15, 'scient-fiction-18'),
('Scient Fiction 19', '', 0, 156, 10, 160000, 0, 15, 'scient-fiction-19'),
('Scient Fiction 20', '', 0, 157, 10, 160000, 0, 15, 'scient-fiction-20'),
('Scient Fiction 21', '', 0, 158, 10, 160000, 0, 15, 'scient-fiction-21'),
('Scient Fiction 22', '', 0, 159, 10, 1280000, 0, 15, 'scient-fiction-22'),
('Scient Fiction 23', '', 0, 160, 10, 512000, 0, 15, 'scient-fiction-23'),
('Scient Fiction 24', '', 0, 161, 10, 2048000, 0, 15, 'scient-fiction-24'),
('Scient Fiction 25', '', 0, 162, 10, 160000, 0, 15, 'scient-fiction-25'),
('Romance 5', '', 0,  163, 11, 160000, 0, 15, 'romance-5'),
('Romance 6', '', 0,  164, 11, 2048000, 0, 15, 'romance-6'),
('Romance 7', '', 0,  165, 11, 160000, 0, 15, 'romance-7'),
('Romance 8', '', 0,  166, 11, 160000, 0, 15, 'romance-8'),
('Romance 9', '', 0,  167, 11, 160000, 0, 15, 'romance-9'),
('Romance 10', '', 0, 168, 11, 1280000, 0, 15, 'romance-10'),
('Romance 11', '', 0, 169, 11, 512000, 0, 15, 'romance-11'),
('Romance 12', '', 0, 170, 11, 2048000, 0, 15, 'romance-12'),
('Romance 13', '', 0, 171, 11, 160000, 0, 15, 'romance-13'),
('Romance 14', '', 0, 172, 11, 160000, 0, 15, 'romance-14'),
('Romance 15', '', 0, 173, 11, 160000, 0, 15, 'romance-15'),
('Romance 16', '', 0, 174, 11, 2048000, 0, 15, 'romance-16'),
('Romance 17', '', 0, 175, 11, 160000, 0, 15, 'romance-17'),
('Romance 18', '', 0, 176, 11, 160000, 0, 15, 'romance-18'),
('Romance 19', '', 0, 177, 11, 160000, 0, 15, 'romance-19'),
('Romance 20', '', 0, 178, 11, 1280000, 0, 15, 'romance-20')
GO


INSERT INTO [ProductImage] ([product], [link]) VALUES
(1, 'naruto0.jpg'),
(2, 'naruto1.jpg'),
(3, 'naruto2.jpg'),
(4, 'naruto3.jpg'),
(5, 'naruto4.jpg'),
(6, 'naruto5.jpg'),
(7, 'naruto6.jpg'),
(8, 'naruto7.jpg'),
(9, 'naruto8.jpg'),
(10, 'naruto9.jpg'),
(11, 'naruto10.jpg'),
(12, 'drama1.jpg'),
(13, 'drama2.jpg'),
(14, 'drama3.jpg'),
(15, 'drama4.jpg'),
(16, 'drama5.jpg'),
(17, 'drama6.jpg'),
(18, 'drama7.jpg'),
(19, 'drama8.jpg'),
(20, 'drama9.jpg'),
(21, 'drama10.jpg'),
(22, 'drama11.jpg'),
(23, 'drama12.jpg'),
(24, 'drama13.jpg'),
(25, 'dragonBall0.jpg'),
(26, 'dragonBall1.jpg'),
(27, 'dragonBall2.jpg'),
(28, 'dragonBall3.jpg'),
(29, 'dragonBall5.jpg'),
(30, 'dragonBall6.jpg'),
(31, 'dragonBall7.jpg'),
(32, 'dragonBall8.jpg'),
(33, 'dragonBall9.jpg'),
(34, 'naruto22.jpg'),
(35, 'naruto23.jpg'),
(36, 'naruto24.jpg'),
(37, 'naruto19.jpg'),
(38, 'naruto21.jpg'),
(39, 'naruto20.jpg'),
(40, 'naruto18.jpg'),
(41, 'scientfiction1.jpg'),
(42, 'scientfiction2.jpg'),
(43, 'scientfiction3.jpg'),
(44, 'scientfiction4.jpg'),
(45, 'scientfiction5.jpg'),
(46, 'scientfiction6.jpg'),
(47, 'scientfiction7.jpg'),
(48, 'scientfiction8.jpg'),
(49, 'romance1.jpg'),
(50, 'romance2.jpg'),
(51, 'romance3.jpg'),
(52, 'romance4.jpg'),
(53, 'DragonBall10.jpg'),
(54, 'DragonBall11.jpg'),
(55, 'DragonBall12.jpg'),
(56, 'DragonBall13.jpg'),
(57, 'DragonBall14.jpg'),
(58, 'DragonBall15.jpg'),
(59, 'action1.jpg'),
(60, 'action2.jpg'),
(61, 'action3.jpg'),
(62, 'action4.jpg'),
(63, 'action5.jpg'),
(64, 'action6.jpg'),
(65, 'action7.jpg'),
(66, 'action8.jpg'),
(67, 'action9.jpg'),
(68, 'action10.jpg'),
(69, 'action11.jpg'),
(70, 'action12.jpg'),
(71, 'action13.jpg'),
(72, 'action14.jpg'),
(73, 'action15.jpg'),
(74, 'action16.jpg'),
(75, 'action17.jpg'),
(76, 'action18.jpg'),
(77, 'action19.jpg'),
(78, 'action20.jpg'),
(79, 'action21.jpg'),
(80, 'action22.jpg'),
(81, 'action23.jpg'),
(82, 'action24.jpg'),
(83, 'action25.jpg'),
(84, 'naruto11.jpg'),
(85, 'naruto12.jpg'),
(86, 'naruto13.jpg'),
(87, 'naruto14.jpg'),
(88, 'naruto15.jpg'),
(89, 'naruto16.jpg'),
(90, 'drama14.jpg'),
(91, 'drama15.jpg'),
(92, 'drama16.jpg'),
(93, 'drama17.jpg'),
(94, 'drama18.jpg'),
(95, 'drama19.jpg'),
(96, 'drama20.jpg'),
(97, 'drama21.jpg'),
(98, 'drama22.jpg'),
(99, 'drama23.jpg'),
(100, 'drama24.jpg'),
(101, 'drama25.jpg'),
(102, 'drama26.jpg'),
(103, 'naruto25.jpg'),
(104, 'naruto26.jpg'),
(105, 'naruto27.jpg'),
(106, 'naruto28.jpg'),
(107, 'naruto29.jpg'),
(108, 'naruto30.jpg'),
(109, 'naruto31.jpg'),
(110, 'naruto32.jpg'),
(111, 'naruto17.jpg'),
(112, 'onePiece1.jpg'),
(113, 'onePiece2.jpg'),
(114, 'onePiece3.jpg'),
(115, 'onePiece4.jpg'),
(116, 'onePiece5.jpg'),
(117, 'onePiece6.jpg'),
(118, 'onePiece7.jpg'),
(119, 'onePiece8.jpg'),
(120, 'onePiece9.jpg'),
(121, 'onePiece10.jpg'),
(122, 'onePiece11.jpg'),
(123, 'drama12.jpg'),
(124, 'drama13.jpg'),
(125, 'dragonBall16.jpg'),
(126, 'dragonBall17.jpg'),
(127, 'dragonBall18.jpg'),
(128, 'dragonBall19.jpg'),
(129, 'dragonBall20.jpg'),
(130, 'dragonBall21.jpg'),
(131, 'dragonBall22.jpg'),
(132, 'dragonBall23.jpg'),
(133, 'dragonBall24.jpg'),
(134, 'dragonBall25.jpg'),
(135, 'dragonBall26.jpg'),
(136, 'dragonBall27.jpg'),
(137, 'dragonBall28.jpg'),
(138, 'dragonBall29.jpg'),
(139, 'dragonBall30.jpg'),
(140, 'dragonBall31.jpg'),
(141, 'dragonBall32.jpg'),
(142, 'dragonBall33.jpg'),
(143, 'dragonBall34.jpg'),
(144, 'dragonBall35.jpg'),
(145, 'dragonBall36.jpg'),
(146, 'scientfiction9.jpg'),
(147, 'scientfiction10.jpg'),
(148, 'scientfiction11.jpg'),
(149, 'scientfiction12.jpg'),
(150, 'scientfiction13.jpg'),
(151, 'scientfiction14.jpg'),
(152, 'scientfiction15.jpg'),
(153, 'scientfiction16.jpg'),
(154, 'scientfiction17.jpg'),
(155, 'scientfiction18.jpg'),
(156, 'scientfiction19.jpg'),
(157, 'scientfiction20.jpg'),
(158, 'scientfiction21.jpg'),
(159, 'scientfiction22.jpg'),
(160, 'scientfiction23.jpg'),
(161, 'scientfiction24.jpg'),
(162, 'scientfiction25.jpg'),
(163, 'romance5.jpg'),
(164, 'romance6.jpg'),
(165, 'romance7.jpg'),
(166, 'romance8.jpg'),
(167, 'romance9.jpg'),
(168, 'romance10.jpg'),
(169, 'romance11.jpg'),
(170, 'romance12.jpg'),
(171, 'romance13.jpg'),
(172, 'romance14.jpg'),
(173, 'romance15.jpg'),
(174, 'romance16.jpg'),
(175, 'romance17.jpg'),
(176, 'romance18.jpg'),
(177, 'romance19.jpg'),
(178, 'romance20.jpg')
GO

INSERT INTO [TransactionStatus] ([content]) VALUES 
(N'Chưa thanh toán'),
(N'Đã thanh toán'),
(N'Đang vận chuyển'),
(N'Đã xác nhận'),
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
(1,3,1,4),
(3,1,3,5)
GO

INSERT INTO [TransactionDetail] ([transaction], [product], [amount]) VALUES 
(1,1,1),
(2,1,1),
(3,2,2),
(4,1,2),
(1,5,3),
(3,4,3),
(3,5,4),
(7,3,4)
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

INSERT INTO [Contact] ([name], [link]) VALUES
('Twitter', 'https://www.twitter.con'),
('Instagram', 'https://www.instagram.com'),
('Facebook', 'https://www.facebook.com'),
('Phone', '0356625002'),
('Email', '52000720@student.tdtu.edu.vn'),
('Address', 'A19, Nguyen Huu Tho, Tan Phong, Quan 7, TP.HCM')
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