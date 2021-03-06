CREATE DATABASE data
GO 
USE [data]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 1/5/2019 10:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Accounts](
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[contact]    Script Date: 1/5/2019 10:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[contact](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NOT NULL,
	[company] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[subject] [varchar](100) NOT NULL,
	[message] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_contact] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[introduces]    Script Date: 1/5/2019 10:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[introduces](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[img] [nvarchar](100) NULL,
	[data] [float] NULL,
	[describe] [nvarchar](500) NULL,
	[color] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ListPro]    Script Date: 1/5/2019 10:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListPro](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idList] [int] NOT NULL,
	[doc] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ListPro] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[news]    Script Date: 1/5/2019 10:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[news](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NULL,
	[img] [nvarchar](100) NULL,
	[describe] [nvarchar](3000) NULL,
	[link] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[partners]    Script Date: 1/5/2019 10:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[partners](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[img] [nvarchar](100) NULL,
	[describe] [nvarchar](3000) NULL,
	[background] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 1/5/2019 10:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idList] [int] NOT NULL,
	[name] [nvarchar](20) NOT NULL,
	[doc] [nvarchar](1000) NOT NULL,
	[img] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Accounts] ([UserName], [Password]) VALUES (N'admin', N'123')
SET IDENTITY_INSERT [dbo].[introduces] ON 

INSERT [dbo].[introduces] ([id], [name], [img], [data], [describe], [color]) VALUES (2, N'checkout', N'/Data/images/Introduces/count-checkout.png', 64000, N'<p>Checkouts per Month</p>', N'#f9d545')
INSERT [dbo].[introduces] ([id], [name], [img], [data], [describe], [color]) VALUES (5, N'countcompanys', N'/Data/images/Introduces/count-companys.png', 5000, N'<p>Companys processed</p>', N'#68e3fd')
INSERT [dbo].[introduces] ([id], [name], [img], [data], [describe], [color]) VALUES (6, N'countsuccess', N'/Data/images/Introduces/count-success.png', 99.199996948242188, N'<p>Success rate of Processed invoices</p>', N'#a6c657')
INSERT [dbo].[introduces] ([id], [name], [img], [data], [describe], [color]) VALUES (7, N'countcountrys', N'/Data/images/Introduces/count-countrys.png', 172, N'<p>Countrys in accounting process</p>', N'#a473c4')
SET IDENTITY_INSERT [dbo].[introduces] OFF
SET IDENTITY_INSERT [dbo].[ListPro] ON 

INSERT [dbo].[ListPro] ([id], [idList], [doc]) VALUES (1, 1, N'Everything in your name')
INSERT [dbo].[ListPro] ([id], [idList], [doc]) VALUES (2, 1, N'Immediately noticeable reduction in process costs')
INSERT [dbo].[ListPro] ([id], [idList], [doc]) VALUES (3, 1, N'Travellers save time by not having to go through the check-out process in the hotel')
INSERT [dbo].[ListPro] ([id], [idList], [doc]) VALUES (4, 1, N'No paper-based travel costs claims ')
INSERT [dbo].[ListPro] ([id], [idList], [doc]) VALUES (5, 1, N'Audit-proof settlement process')
INSERT [dbo].[ListPro] ([id], [idList], [doc]) VALUES (6, 1, N'Monitoring of the payment process and invoicing')
INSERT [dbo].[ListPro] ([id], [idList], [doc]) VALUES (7, 1, N'Automated VAT reclaiming becomes possible')
INSERT [dbo].[ListPro] ([id], [idList], [doc]) VALUES (8, 2, N'Comparison with agreed RateGrids')
INSERT [dbo].[ListPro] ([id], [idList], [doc]) VALUES (9, 2, N'Audit-proof audit processes ')
INSERT [dbo].[ListPro] ([id], [idList], [doc]) VALUES (10, 2, N'Automatic monitoring and audit of the credit for incorrectly billed services')
INSERT [dbo].[ListPro] ([id], [idList], [doc]) VALUES (11, 3, N'Access online invoice and meeting data')
INSERT [dbo].[ListPro] ([id], [idList], [doc]) VALUES (12, 3, N'Exact comparison of booked and billed services')
INSERT [dbo].[ListPro] ([id], [idList], [doc]) VALUES (13, 3, N'Payment approval only after the bill has been checked')
INSERT [dbo].[ListPro] ([id], [idList], [doc]) VALUES (14, 4, N'Worldwide use of virtual credit cards for hotel payments')
INSERT [dbo].[ListPro] ([id], [idList], [doc]) VALUES (15, 4, N'Enrichment of the transaction to VAT level (Level 3)')
INSERT [dbo].[ListPro] ([id], [idList], [doc]) VALUES (18, 4, N'Review of the charge against the invoice amounts')
INSERT [dbo].[ListPro] ([id], [idList], [doc]) VALUES (19, 4, N'Automated correction requests in the case of incorrect charges ')
SET IDENTITY_INSERT [dbo].[ListPro] OFF
SET IDENTITY_INSERT [dbo].[news] ON 

INSERT [dbo].[news] ([id], [name], [img], [describe], [link]) VALUES (1, N'AirPlus launches proven, secured virtual payment in the USA', N'/Data/images/News/airplus.jpg', N'<p><strong>AirPlus International</strong> has announced the launch of A.I.D.A. Virtual Cards in the USA for the business travel market. The US launch of A.I.D.A. marks the 14th country to offer the AirPlus virtual payment product. AirPlus has been at the forefront of virtual <em>payment for over 10 years with launches in Europe and Asia Pacific.</em></p><p><a href="http://www.businesswire.com/news/home/20171002005223/en/AirPlus-Launches-Proven-Secured-Virtual-Payment-USA">http://www.businesswire.com/news/home/20171002005223/en/AirPlus-Launches-Proven-Secured-Virtual-Payment-USA</a></p>', N'null')
INSERT [dbo].[news] ([id], [name], [img], [describe], [link]) VALUES (6, N'AirPlus International significantly increases card sales with virtual credit cards', N'/Data/images/News/Fotolia_63740782_Subscription_Monthly_M.jpg', N'<p>Last year, card sales in the field of virtual credit cards rose disproportionately strongly. And the trend continues, says Patrick W. Diemer, CEO of AirPlus International. Since 2014 there has been an intensive cooperation between AirPlus and itelya. Through the licensing partnership and the integration of the smart.billing consolidator, the AirPlus product A.I.D.A. Hotel Data Enrichment could be pushed forward. As a result, AirPlus is able to provide its customers with a unique data quality also in hotel accounts. The goal of billing hotel bookings as easily as flight bookings was achieved. The cooperation with AirPlus will continue to be steadily driven forward, among other things through this year&rsquo;s introduction of car rental billing.</p>', N'null')
INSERT [dbo].[news] ([id], [name], [img], [describe], [link]) VALUES (7, N'Christopher Hecht is new Director Payment- and Customer Solutions at Itelya GmbH & Co. KG', N'/Data/images/News/09_corpcards_christopher-hecht-2.jpg', N'<p>Since October 2017, Christopher Hecht is the new Director Payment- and Customer Solutions at Itelya GmbH &amp; Co. KG. The creation of this new job enables Itelya to further improve and expand the payment- and billing solutions for the hotel industry. Mr. Hecht has been working in the Business Travel segment for over 10 years and has recently been responsible for the Europe-wide introduction of payment solutions for the HRS Group. He is regarded as an outstanding expert in the fields of payment and digitization as well as travel expenses accounting.</p>', N'null')
INSERT [dbo].[news] ([id], [name], [img], [describe], [link]) VALUES (8, N'Travelport Hotelzon launches smart.billing solution', N'/Data/images/News/Fotolia_77541828_Subscription_Monthly_M.jpg', N'<p>Together with itelya and the payment provider Airplus International, the online hotel booking tool Travelport Hotelzon introduced the smart.billing service of itelya GmbH &amp; Co. KG. As Christian Schultz, head of new market sales, said, Travelport will expand Payment Consolidation Service to include payments through Travelport&rsquo;s own eNett subsidiary and other virtual payment providers. According to Travelport, its clients spend an average of 24 minutes of manual admin on each hotel booking. This process can be reduced by the full automated end-to-end process smart.billing by itelya. The service collects all invoices for all hotel bookings made through Hotelzon, verifies they are presented correctly and consolidates them into a single statement for the client. Please read more hear.</p><p><a href="http://www.businesstravelnews.com/Global/Travelport-Hotel-Booking-Tool-Launches-Consolidated-Tax-Compliant-Invoicing">http://www.businesstravelnews.com/Global/Travelport-Hotel-Booking-Tool-Launches-Consolidated-Tax-Compliant-Invoicing</a></p>', N'null')
INSERT [dbo].[news] ([id], [name], [img], [describe], [link]) VALUES (9, N'HRS claims top position at itelya in the 1st Quarter of 2017', N'/Data/images/News/168308824.jpg', N'<p>The HRS group (HRS, hotel.de) continues to maintain its top position among the itelya licence partners. Therefore, the over four-year cooperation between HRS and itelya is constantly developing positive. HRS has a worldwide smart.billing licence and achieves international success with its customers. The smart.billing products are marketed under the HRS brand names Paperless.Travel and Central.Billing. Both in terms of billing volume as well as on the basis of pure bookings, HRS has the top position among the licence partners. In addition, the module Meeting &amp; Groups (in cooperation with meetago) was successfully introduced at the ITB 2017. Again, itelya provides its smart.billing technology. Partner: HRS (licence partner of itelya) / meetago / AirPlus (licence partner of itelya)</p><p><br></p><p><span class="fr-video fr-fvc fr-dvb fr-draggable" contenteditable="false" draggable="true"><iframe src="https://www.youtube.com/embed/9JubX7DwOsA?wmode=opaque" frameborder="0" allowfullscreen="" class="fr-draggable" style="width: 640px; height: 360px;"></iframe></span><br></p>', N'null')
INSERT [dbo].[news] ([id], [name], [img], [describe], [link]) VALUES (10, N'Voya is new licence partner of itelya', N'/Data/images/News/169609484.jpg', N'<p>As a new licence partner of itelya, the young business travel portal voya.ai introduces the payment and billing solutions smart.billing for hotel settlements of its customers. Since the mid of July, the voya team is testing the fully automated end-to-end process with selected customers. The itelya team wishes our new partner a successful product launch and good business. Partner: voya.ai (licence partner of itelya) / AirPlus (licence partner of itelya)</p>', N'null')
SET IDENTITY_INSERT [dbo].[news] OFF
SET IDENTITY_INSERT [dbo].[partners] ON 

INSERT [dbo].[partners] ([id], [name], [img], [describe], [background]) VALUES (1, N'OTA – Online Travel Agency', N'/Data/images/Partners/smartbilling-s.png', N'<p><span style="color: rgb(0, 0, 0);">Many of the OTAs acting in the &quot;Corporate Travel&quot; segment are already able to offer central payment of hotel expenses in addition to booking the hotel rooms. smart.billing has been designed in close cooperation with leading OTAs and integrated into their booking processes. As a result, the online booking platforms are able to offer payment, billing, invoice auditing and accounting alongside their core business.</span></p>', N'/Data/images/Partners/travel-blue.jpg')
INSERT [dbo].[partners] ([id], [name], [img], [describe], [background]) VALUES (2, N'TMC – Travel Management Agency', N'/Data/images/Partners/smartbilling-s-333.png', N'<p>TMCs traditionally deal with many concerns their corporate clients have regarding business travel. The subjects of invoice processing and clearing have never been foreign subjects to these agents either. By integrating virtual credit card technology and the innovative services of the smart.billing product range, our TMC partners profit from the technical advantage in order to expand their services considerably for their clients.</p>', N'/Data/images/Partners/travel-yellow.jpg')
INSERT [dbo].[partners] ([id], [name], [img], [describe], [background]) VALUES (3, N'OBE – Online Booking Engine', N'/Data/images/Partners/smartbilling-s.png', N'<p>More and more companies are using Online Booking Engines so they can book all the areas of a business trip from one platform. With smart.billing, the automatic steering of the funds to the audit and accounting of the invoices as a genuine end-to-end process is now reality. If you have any questions about which OBEs you can use as a corporate client for our services, contact our OBE specialists here.</p>', N'/Data/images/Partners/travel-purple.jpg')
INSERT [dbo].[partners] ([id], [name], [img], [describe], [background]) VALUES (4, N'GDS – Global Distribution System', N'/Data/images/Partners/smartbilling-s.png', N'<p>GDS providers have been offering the opportunity to generate virtual credit cards when booking hotels for some time. In fact, the process is rarely offered with the necessary services &ndash; cost acceptances, hotel payment monitoring and invoice steering. The innovative GDS systems close these gaps by implementing our smart.billing services. If you have any questions about which GDS you can use as a corporate client for our services, contact our GDS specialists here.</p>', N'/Data/images/Partners/travel-green.jpg')
SET IDENTITY_INSERT [dbo].[partners] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([id], [idList], [name], [doc], [img]) VALUES (1, 1, N'SLEEP', N'Simple, paperless and efficient - smart.billing SLEEP allows drastically simplified hotel settlements – from payment to accounting – in a fully automated end-to-end process. ', N'sleep.jpg')
INSERT [dbo].[Products] ([id], [idList], [name], [doc], [img]) VALUES (2, 2, N'DRIVE', N'Non-transparent rental car payments are thanks to smart.billing DRIVE a thing of the past. smart.billing DRIVE checks your rental car bills and automatically contests unauthorised payments for you. The basis for this is your contract with the rental car providers. Profit today from this solution for all countries where you pay for rental car reservations using your virtual credit card account. ', N'rentalcar.jpg')
INSERT [dbo].[Products] ([id], [idList], [name], [doc], [img]) VALUES (3, 3, N'MEET', N'Organising a meeting is time-consuming. We support you at the end of the meeting with smart.billing MEET. Apart from requesting the invoice and checking if it is formally accurate, we check the invoice against the contract concluded with the organiser. You receive all the invoice information bundled and clear so you can approve the payment to the organiser. ', N'meeting.jpg')
INSERT [dbo].[Products] ([id], [idList], [name], [doc], [img]) VALUES (4, 4, N'CONSOLIDATOR', N'In cooperation with your payments service provider, the smart.billing Consolidator allows you to use the latest payment methods (virtual credit cards – VCC) and thus to consolidate and enrich the data in such a way that you can import it fully automatically. ', N'creditcard.jpg')
SET IDENTITY_INSERT [dbo].[Products] OFF
ALTER TABLE [dbo].[ListPro]  WITH CHECK ADD  CONSTRAINT [FK_ListPro_Products] FOREIGN KEY([idList])
REFERENCES [dbo].[Products] ([id])
GO
ALTER TABLE [dbo].[ListPro] CHECK CONSTRAINT [FK_ListPro_Products]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Account_Login]    Script Date: 1/5/2019 10:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_Account_Login]
	@UserName varchar(50),
	@Password varchar(50)
AS
BEGIN
	select * from Accounts where UserName = @UserName and Password = @Password
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Add_Introduces]    Script Date: 1/5/2019 10:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Add_Introduces] @name nvarchar(100), @img nvarchar(100), @data float, @describe nvarchar(500), @color nvarchar(100)
as
begin
	insert dbo.introduces VALUES( @name, @img, @data, @describe, @color)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Add_News]    Script Date: 1/5/2019 10:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[USP_Add_News] @name nvarchar(200),@img nvarchar(100),@describe nvarchar(3000),@link nvarchar(200)
as
begin
	insert into news values(@name,@img,@describe,@link)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Add_Partners]    Script Date: 1/5/2019 10:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_Add_Partners] @name nvarchar(100),@img nvarchar(100),@describe nvarchar(3000),@background nvarchar(100)
as
begin
	insert into partners values(@name,@img,@describe,@background)
end


GO
/****** Object:  StoredProcedure [dbo].[USP_Delete_Introduces]    Script Date: 1/5/2019 10:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Delete_Introduces] @id INT
AS
BEGIN
	declare @exit int = 0
	select @exit = count(*) from introduces where id = @id
	if(@exit = 1)
	BEGIN	
		delete introduces where id = @id
	end 
end

GO
/****** Object:  StoredProcedure [dbo].[USP_Delete_News]    Script Date: 1/5/2019 10:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_Delete_News] @id int
as
begin
	declare @exit int = 0
	select @exit = count(*) from news where id = @id
	if(@exit = 1)
	BEGIN	
		delete news where id = @id
	end 
end


GO
/****** Object:  StoredProcedure [dbo].[USP_Delete_Partners]    Script Date: 1/5/2019 10:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_Delete_Partners] @id int
as
begin
	declare @exit int = 0
	select @exit = count(*) from partners where id = @id
	if(@exit = 1)
	BEGIN	
		delete partners where id = @id
	end 
end


GO
/****** Object:  StoredProcedure [dbo].[USP_Edit_Introduces]    Script Date: 1/5/2019 10:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Edit_Introduces] @id int, @name nvarchar(100), @img nvarchar(100), @data float, @describe nvarchar(500), @color nvarchar(100)
as 
begin 
	declare @exit int = 0
	select @exit = count(*) from introduces where id = @id
	if(@exit = 1)
	begin
		update introduces set name = @name, img = @img, data = @data, describe = @describe, color = @color where id = @id
	end
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Edit_News]    Script Date: 1/5/2019 10:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_Edit_News] @id int, @name nvarchar(200),@img nvarchar(100),@describe nvarchar(3000),@link nvarchar(200)
as 
begin 
	declare @exit int = 0
	select @exit = count(*) from news where id = @id
	if(@exit = 1)
	begin
		update news set name = @name, img = @img, describe = @describe, link = @link where id = @id
	end
end


GO
/****** Object:  StoredProcedure [dbo].[USP_Edit_Partners]    Script Date: 1/5/2019 10:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_Edit_Partners] @id int, @name nvarchar(100),@img nvarchar(100),@describe nvarchar(3000),@background nvarchar(100)
as 
begin 
	declare @exit int = 0
	select @exit = count(*) from partners where id = @id
	if(@exit = 1)
	begin
		update partners set name = @name, img = @img, describe = @describe, background = @background where id = @id
	end
end


GO
/****** Object:  StoredProcedure [dbo].[USP_Get_Introduces]    Script Date: 1/5/2019 10:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Get_Introduces] @id int 
as
BEGIN
	declare @exit int = 0
	SELECT @exit = count(*) from introduces where id = @id
	if(@exit = 1)
	BEGIN
		select * from introduces where id = @id
	end
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Get_News]    Script Date: 1/5/2019 10:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_Get_News] @id int 
as
BEGIN
	declare @exit int = 0
	SELECT @exit = count(*) from news where id = @id
	if(@exit = 1)
	BEGIN
		select * from news where id = @id
	end
end


GO
/****** Object:  StoredProcedure [dbo].[USP_Get_Partners]    Script Date: 1/5/2019 10:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_Get_Partners] @id int 
as
BEGIN
	declare @exit int = 0
	SELECT @exit = count(*) from partners where id = @id
	if(@exit = 1)
	BEGIN
		select * from partners where id = @id
	end
end


GO
/****** Object:  StoredProcedure [dbo].[USP_GetAll_Introduces]    Script Date: 1/5/2019 10:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetAll_Introduces] 
as
begin
	select * from introduces
end 
GO
/****** Object:  StoredProcedure [dbo].[USP_GetAll_News]    Script Date: 1/5/2019 10:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_GetAll_News]
as
begin
	select * from news
end 
GO
/****** Object:  StoredProcedure [dbo].[USP_GetAll_Partners]    Script Date: 1/5/2019 10:54:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_GetAll_Partners]
as
begin
	select * from partners
end 
GO
