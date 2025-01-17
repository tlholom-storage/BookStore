USE [master]
GO
/****** Object:  Database [dbBookStore]    Script Date: 2024/11/29 06:06:50 ******/
CREATE DATABASE [dbBookStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbBookStore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\dbBookStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbBookStore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\dbBookStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [dbBookStore] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbBookStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbBookStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbBookStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbBookStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbBookStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbBookStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbBookStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbBookStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbBookStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbBookStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbBookStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbBookStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbBookStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbBookStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbBookStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbBookStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbBookStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbBookStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbBookStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbBookStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbBookStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbBookStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbBookStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbBookStore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbBookStore] SET  MULTI_USER 
GO
ALTER DATABASE [dbBookStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbBookStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbBookStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbBookStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbBookStore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbBookStore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [dbBookStore] SET QUERY_STORE = OFF
GO
USE [dbBookStore]
GO
/****** Object:  Table [dbo].[tblBook]    Script Date: 2024/11/29 06:06:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBook](
	[book_id] [int] IDENTITY(2001,1) NOT NULL,
	[title] [varchar](100) NULL,
	[author] [varchar](100) NULL,
	[description] [varchar](500) NULL,
	[category_id] [int] NULL,
	[price_per_month] [decimal](10, 2) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
	[img] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblBookCategory]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBookCategory](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPayment]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPayment](
	[payment_id] [int] IDENTITY(1,1) NOT NULL,
	[subscription_id] [int] NULL,
	[payment_gateway_response] [text] NULL,
	[amount] [decimal](10, 2) NULL,
	[payment_date] [datetime] NULL,
	[payment_method] [varchar](20) NULL,
	[payment_status] [varchar](20) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[payment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSubscription]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSubscription](
	[subscription_id] [int] IDENTITY(1,1) NOT NULL,
	[start_date] [date] NULL,
	[end_date] [date] NULL,
	[user_id] [int] NULL,
	[book_id] [int] NULL,
	[status] [varchar](20) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[subscription_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[user_id] [int] IDENTITY(1010,1) NOT NULL,
	[username] [varchar](50) NULL,
	[first_name] [varchar](50) NULL,
	[last_name] [varchar](50) NULL,
	[email] [varchar](100) NULL,
	[user_type_id] [int] NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
	[password_hash] [varbinary](max) NULL,
	[password_salt] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUserType]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserType](
	[user_type_id] [int] IDENTITY(1,1) NOT NULL,
	[user_type_name] [varchar](50) NULL,
	[is_admin] [bit] NULL,
	[is_third_party] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[user_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblBook] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[tblBook] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[tblPayment] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[tblPayment] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[tblSubscription] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[tblSubscription] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[tblUser] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[tblUser] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[tblBook]  WITH CHECK ADD FOREIGN KEY([category_id])
REFERENCES [dbo].[tblBookCategory] ([category_id])
GO
ALTER TABLE [dbo].[tblPayment]  WITH CHECK ADD FOREIGN KEY([subscription_id])
REFERENCES [dbo].[tblSubscription] ([subscription_id])
GO
ALTER TABLE [dbo].[tblSubscription]  WITH CHECK ADD  CONSTRAINT [FK_Subscription_Book] FOREIGN KEY([book_id])
REFERENCES [dbo].[tblBook] ([book_id])
GO
ALTER TABLE [dbo].[tblSubscription] CHECK CONSTRAINT [FK_Subscription_Book]
GO
ALTER TABLE [dbo].[tblSubscription]  WITH CHECK ADD  CONSTRAINT [FK_Subscription_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[tblUser] ([user_id])
GO
ALTER TABLE [dbo].[tblSubscription] CHECK CONSTRAINT [FK_Subscription_User]
GO
ALTER TABLE [dbo].[tblUser]  WITH CHECK ADD FOREIGN KEY([user_type_id])
REFERENCES [dbo].[tblUserType] ([user_type_id])
GO
ALTER TABLE [dbo].[tblPayment]  WITH CHECK ADD CHECK  (([payment_method]='other' OR [payment_method]='paypal' OR [payment_method]='credit_card'))
GO
ALTER TABLE [dbo].[tblPayment]  WITH CHECK ADD CHECK  (([payment_status]='pending' OR [payment_status]='failed' OR [payment_status]='success'))
GO
ALTER TABLE [dbo].[tblSubscription]  WITH CHECK ADD CHECK  (([status]='expired' OR [status]='cancelled' OR [status]='active'))
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateBook]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CreateBook]
    @title VARCHAR(100),
    @author VARCHAR(100),
    @description VARCHAR(500),
    @category_id INT,
    @price_per_month DECIMAL(10, 2),
	@img varchar(max)
AS
BEGIN
    INSERT INTO tblBook (title, author, description, category_id, price_per_month, img)
    VALUES (@title, @author, @description, @category_id, @price_per_month, @img);

END
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateBookCategory]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CreateBookCategory]
    @category_name VARCHAR(50)
AS
BEGIN
    INSERT INTO tblBookCategory (category_name)
    VALUES (@category_name);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CreatePayment]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CreatePayment]
    @subscription_id INT,
    @payment_gateway_response TEXT,
    @amount DECIMAL(10,2),
    @payment_date DATETIME,
    @payment_method VARCHAR(20),
    @payment_status VARCHAR(20)
AS
BEGIN
    INSERT INTO tblPayment (subscription_id, payment_gateway_response, amount, payment_date, payment_method, payment_status)
    VALUES (@subscription_id, @payment_gateway_response, @amount, @payment_date, @payment_method, @payment_status);

END
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateSubscription]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CreateSubscription]
    @start_date DATE,
    @end_date DATE,
    @user_id INT,
    @book_id INT,
    @status VARCHAR(20)
AS
BEGIN
    INSERT INTO tblSubscription (start_date, end_date, user_id, book_id, status)
    VALUES (@start_date, @end_date, @user_id, @book_id, @status);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateUser]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CreateUser]
    @username VARCHAR(50),
    @first_name VARCHAR(50),
    @last_name VARCHAR(50),
    @email VARCHAR(100),
    @password_hash VARBINARY(MAX),
	@password_salt VARBINARY(MAX),
    @user_type_id INT
AS
BEGIN
    INSERT INTO tblUser (username, first_name, last_name, email, password_hash, user_type_id, password_salt)
    VALUES (@username, @first_name, @last_name, @email, @password_hash, @user_type_id, @password_salt);

END
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateUserType]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Creates a new user type
CREATE PROCEDURE [dbo].[sp_CreateUserType]
    @user_type_name VARCHAR(50),
    @is_admin BIT,
    @is_third_party BIT
AS
BEGIN
    INSERT INTO tblUserType (user_type_name, is_admin, is_third_party)
    VALUES (@user_type_name, @is_admin, @is_third_party);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteBook]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteBook]
    @book_id INT
AS
BEGIN
    DELETE FROM tblBook
    WHERE book_id = @book_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteBookCategory]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteBookCategory]
    @category_id INT
AS
BEGIN
    DELETE FROM tblBookCategory
    WHERE category_id = @category_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeletePayment]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeletePayment]
    @payment_id INT
AS
BEGIN
    DELETE FROM tblPayment
    WHERE payment_id = @payment_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteSubscription]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteSubscription]
    @subscription_id INT
AS
BEGIN
    DELETE FROM tblSubscription
    WHERE subscription_id = @subscription_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteUser]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteUser]
    @user_id INT
AS
BEGIN
    DELETE FROM tblUser
    WHERE user_id = @user_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteUserType]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Deletes a user type
CREATE PROCEDURE [dbo].[sp_DeleteUserType]
    @user_type_id INT
AS
BEGIN
    DELETE FROM tblUserType
    WHERE user_type_id = @user_type_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetBook]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetBook]
    @book_id INT
AS
BEGIN
    SELECT * FROM tblBook
    WHERE book_id = @book_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetBookCategory]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetBookCategory]
    @category_id INT
AS
BEGIN
    SELECT * FROM tblBookCategory
    WHERE category_id = @category_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPayment]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPayment]
    @payment_id INT
AS
BEGIN
    SELECT * FROM tblPayment
    WHERE payment_id = @payment_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSubscription]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetSubscription]
    @subscription_id INT
AS
BEGIN
    SELECT * FROM tblSubscription
    WHERE subscription_id = @subscription_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUser]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetUser]
    @user_id INT
AS
BEGIN
    SELECT * FROM tblUser
    WHERE user_id = @user_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserType]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Retrieves a user type
CREATE PROCEDURE [dbo].[sp_GetUserType]
    @user_type_id INT
AS
BEGIN
    SELECT * FROM tblUserType
    WHERE user_type_id = @user_type_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateBook]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateBook]
    @book_id INT,
    @title VARCHAR(100),
    @author VARCHAR(100),
    @description VARCHAR(500),
    @category_id INT,
    @price_per_month DECIMAL(10, 2),
	@img varchar(max)
AS
BEGIN
    UPDATE tblBook
    SET 
        title = @title,
        author = @author,
        description = @description,
        category_id = @category_id,
        price_per_month = @price_per_month,
		img = @img
    WHERE book_id = @book_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateBookCategory]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateBookCategory]
    @category_id INT,
    @category_name VARCHAR(50)
AS
BEGIN
    UPDATE tblBookCategory
    SET category_name = @category_name
    WHERE category_id = @category_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdatePayment]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdatePayment]
    @payment_id INT,
    @subscription_id INT,
    @payment_gateway_response TEXT,
    @amount DECIMAL(10,2),
    @payment_date DATETIME,
    @payment_method VARCHAR(20),
    @payment_status VARCHAR(20)
AS
BEGIN
    UPDATE tblPayment
    SET 
        subscription_id = @subscription_id,
        payment_gateway_response = @payment_gateway_response,
        amount = @amount,
        payment_date = @payment_date,
        payment_method = @payment_method,
        payment_status = @payment_status
    WHERE payment_id = @payment_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateSubscription]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UpdateSubscription]
    @subscription_id INT,
    @start_date DATE,
    @end_date DATE,
    @user_id INT,
    @book_id INT,
    @status VARCHAR(20)
AS
BEGIN
    UPDATE tblSubscription
    SET 
        start_date = @start_date,
        end_date = @end_date,
        user_id = @user_id,
        book_id = @book_id,
        status = @status
    WHERE subscription_id = @subscription_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateUser]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateUser]
    @user_id INT,
    @username VARCHAR(50),
    @first_name VARCHAR(50),
    @last_name VARCHAR(50),
    @email VARCHAR(100),
    @password_hash VARBINARY(MAX),
	@password_salt VARBINARY(MAX),
    @user_type_id INT
AS
BEGIN
    UPDATE tblUser
    SET 
        username = @username,
        first_name = @first_name,
        last_name = @last_name,
        email = @email,
        password_hash = @password_hash,
		password_salt = @password_salt,
        user_type_id = @user_type_id
    WHERE user_id = @user_id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateUserType]    Script Date: 2024/11/29 06:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateUserType]
    @user_type_id INT,
    @user_type_name VARCHAR(50),
    @is_admin BIT,
    @is_third_party BIT
AS
BEGIN
    UPDATE tblUserType
    SET user_type_name = @user_type_name,
        is_admin = @is_admin,
        is_third_party = @is_third_party
    WHERE user_type_id = @user_type_id;
END;
GO
USE [master]
GO
ALTER DATABASE [dbBookStore] SET  READ_WRITE 
GO
