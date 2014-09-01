/*
Navicat SQL Server Data Transfer

Source Server         : db
Source Server Version : 110000
Source Host           : (LocalDB)\v11.0:1433
Source Database       : D:\DOCUMENTS\VISUAL STUDIO 2012\PROJECTS\NPOTATO\WHQWEB\NUI\APP_DATA\DB.MDF
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 110000
File Encoding         : 65001

Date: 2014-09-01 23:31:29
*/


-- ----------------------------
-- Table structure for T_Article
-- ----------------------------
DROP TABLE [dbo].[T_Article]
GO
CREATE TABLE [dbo].[T_Article] (
[ArticleID] uniqueidentifier NOT NULL ,
[CreateDate] datetime NOT NULL ,
[UpdateDate] datetime NOT NULL ,
[Name] nvarchar(50) NOT NULL ,
[NameEn] nvarchar(50) NOT NULL ,
[Content] nvarchar(MAX) NULL ,
[ContentEn] nvarchar(MAX) NULL ,
[Keyword] nvarchar(100) NULL ,
[KeywordEn] nvarchar(100) NULL ,
[Description] nvarchar(500) NULL ,
[DescriptionEn] nvarchar(500) NULL ,
[IsEnabled] bit NOT NULL ,
[IsFirst] bit NOT NULL ,
[From] nvarchar(50) NOT NULL ,
[BuyLink] nvarchar(256) NULL ,
[ViewCount] int NOT NULL ,
[CategoryID] uniqueidentifier NOT NULL ,
[PImagea] nvarchar(128) NULL ,
[PImageb] nvarchar(128) NULL ,
[PImagec] nvarchar(128) NULL ,
[PImaged] nvarchar(128) NULL ,
[PImagee] nvarchar(128) NULL 
)


GO

-- ----------------------------
-- Records of T_Article
-- ----------------------------
INSERT INTO [dbo].[T_Article] ([ArticleID], [CreateDate], [UpdateDate], [Name], [NameEn], [Content], [ContentEn], [Keyword], [KeywordEn], [Description], [DescriptionEn], [IsEnabled], [IsFirst], [From], [BuyLink], [ViewCount], [CategoryID], [PImagea], [PImageb], [PImagec], [PImaged], [PImagee]) VALUES (N'CF43FE23-1424-4A9B-B53A-066C2B6D4DF8', N'2014-08-21 22:33:30.000', N'2014-08-21 22:33:30.000', N'KEIDI小米3手机保护壳 小米3手机壳 小米3手机套 m3保护套 触屏套 ', N'mitktk', N'<p>sdfsdfsdfs</p>', N'<p>sfsdfsdfsd</p>', N'sfsd', N'sdf', N'sdfsdf', N'sdfsd', N'1', N'0', N'本站', null, N'5', N'2C4771DB-9D37-4809-8E8B-0381C600194D', N'/userfiles/shouji/TB100XCFVXXXXbAXFXXXXXXXXXX_!!0-item_pic.jpg_180x180.jpg', N'/userfiles/shouji/T19jz0FqpXXXXXXXXX_!!0-item_pic.jpg_180x180.jpg', N'/userfiles/shouji/item-52943C52-35FBFE17000000000401000034F118CD.0.300x300.jpg', null, null)
GO
GO
INSERT INTO [dbo].[T_Article] ([ArticleID], [CreateDate], [UpdateDate], [Name], [NameEn], [Content], [ContentEn], [Keyword], [KeywordEn], [Description], [DescriptionEn], [IsEnabled], [IsFirst], [From], [BuyLink], [ViewCount], [CategoryID], [PImagea], [PImageb], [PImagec], [PImaged], [PImagee]) VALUES (N'CDD70B17-EF96-4CA2-A972-432E5EC2D7A9', N'2014-08-19 17:29:24.000', N'2014-08-19 17:29:24.000', N'红米Note手机壳红米1S手机套原装翻盖皮套官方正品后盖简', N'hongmi23423', null, null, N'红米2', N'hongmi2', N'中扥中3', N'234234', N'1', N'0', N'本站', null, N'7', N'2C4771DB-9D37-4809-8E8B-0381C600194D', N'/userfiles/shouji/T1qT56FS8XXXXXXXXX_!!0-item_pic.jpg_180x180.jpg', N'/userfiles/shouji/TB1sOxTFVXXXXbtXpXXXXXXXXXX_!!0-item_pic.jpg_180x180.jpg', N'/userfiles/shouji/d120876f6e5f0ad4019f09c5c2b0_500_500.jpg', N'/userfiles/shouji/8136e2f215a0b354cf8d62a726a1_600_600_1_1.jpeg', null)
GO
GO
INSERT INTO [dbo].[T_Article] ([ArticleID], [CreateDate], [UpdateDate], [Name], [NameEn], [Content], [ContentEn], [Keyword], [KeywordEn], [Description], [DescriptionEn], [IsEnabled], [IsFirst], [From], [BuyLink], [ViewCount], [CategoryID], [PImagea], [PImageb], [PImagec], [PImaged], [PImagee]) VALUES (N'30AFEC45-5214-4D3B-A816-4448D13A5B02', N'2014-08-21 22:37:01.000', N'2014-08-21 22:37:01.000', N'华为荣耀畅玩版3X手机套 荣耀3X手机壳 3X畅玩版皮套 新款保护套 ', N'dpyang', N'<p>32423</p>', N'<p>34sens</p>', N'2423', N'234', N'中扽', N'23423', N'1', N'0', N'本站', null, N'35', N'2C4771DB-9D37-4809-8E8B-0381C600194D', N'/userfiles/shouji/T1TJMHFPxcXXXXXXXX_!!0-item_pic_jpg_220x220.jpg', N'/userfiles/shouji/d120876f6e5f0ad4019f09c5c2b0_500_500.jpg', null, null, null)
GO
GO
INSERT INTO [dbo].[T_Article] ([ArticleID], [CreateDate], [UpdateDate], [Name], [NameEn], [Content], [ContentEn], [Keyword], [KeywordEn], [Description], [DescriptionEn], [IsEnabled], [IsFirst], [From], [BuyLink], [ViewCount], [CategoryID], [PImagea], [PImageb], [PImagec], [PImaged], [PImagee]) VALUES (N'DE9BA477-7279-4369-8AAE-5619371344C9', N'2014-08-19 17:27:52.000', N'2014-08-19 17:27:52.000', N'磨砂红米1s手机壳简约透明红米手机保护套塑料硬壳4.7寸', N'moshahongmi', null, null, N'红米', N'hongmi', null, null, N'1', N'0', N'本站', N'http://www.dtsca.cn/f/index.html', N'5', N'2C4771DB-9D37-4809-8E8B-0381C600194D', N'/userfiles/shouji/e40936477ba365a4aa4f6c7f9ea0_1000_1000.jpeg', N'/userfiles/shouji/item-52943C52-35FBFE17000000000401000034F118CD.0.300x300.jpg', N'/userfiles/shouji/TB1DBDqFVXXXXX_XpXXXXXXXXXX_!!0-item_pic.jpg_180x180.jpg', N'/userfiles/shouji/TB100XCFVXXXXbAXFXXXXXXXXXX_!!0-item_pic.jpg_180x180.jpg', null)
GO
GO
INSERT INTO [dbo].[T_Article] ([ArticleID], [CreateDate], [UpdateDate], [Name], [NameEn], [Content], [ContentEn], [Keyword], [KeywordEn], [Description], [DescriptionEn], [IsEnabled], [IsFirst], [From], [BuyLink], [ViewCount], [CategoryID], [PImagea], [PImageb], [PImagec], [PImaged], [PImagee]) VALUES (N'85FE4846-21B9-4F17-9E60-6D5104A4705F', N'2014-08-19 17:31:15.000', N'2014-08-19 17:31:15.000', N'小米3外壳专用小米3手机壳M3手机套小米3手机保护壳硬后', N'xiaomi3', null, null, N'小米3', N'xiaomi3', null, null, N'1', N'0', N'本站', null, N'4', N'B65CBBFA-A886-4CCD-9C3A-E171CB9C6747', N'/userfiles/shouji/TB14XtjFVXXXXXgapXXXXXXXXXX_!!0-item_pic.jpg_180x180.jpg', N'/userfiles/shouji/TB1DBDqFVXXXXX_XpXXXXXXXXXX_!!0-item_pic.jpg_180x180.jpg', N'/userfiles/shouji/TB1E.4kFVXXXXXlXVXXXXXXXXXX_!!0-item_pic.jpg_180x180.jpg', null, null)
GO
GO
INSERT INTO [dbo].[T_Article] ([ArticleID], [CreateDate], [UpdateDate], [Name], [NameEn], [Content], [ContentEn], [Keyword], [KeywordEn], [Description], [DescriptionEn], [IsEnabled], [IsFirst], [From], [BuyLink], [ViewCount], [CategoryID], [PImagea], [PImageb], [PImagec], [PImaged], [PImagee]) VALUES (N'8AC34A27-017B-496F-89DE-7484D3F51E0C', N'2014-08-21 22:38:27.000', N'2014-08-21 22:38:27.000', N'景为 华为Mate2手机套 华为Mate2手机壳 华为mate2手机皮套 保护 ', N'qianch', N'<p>中扥中d</p>', N'<p>123 123</p>', N'中扥', N'123123', N'12312', N'123123', N'1', N'0', N'本站', null, N'20', N'D0B47EF7-93E9-4A61-94EE-4E51A3CE3315', N'/userfiles/shouji/T1Bne7FK4XXXXXXXXX_!!0-item_pic_jpg_220x220.jpg', null, null, null, null)
GO
GO
INSERT INTO [dbo].[T_Article] ([ArticleID], [CreateDate], [UpdateDate], [Name], [NameEn], [Content], [ContentEn], [Keyword], [KeywordEn], [Description], [DescriptionEn], [IsEnabled], [IsFirst], [From], [BuyLink], [ViewCount], [CategoryID], [PImagea], [PImageb], [PImagec], [PImaged], [PImagee]) VALUES (N'9139C3A7-D164-4EC9-B114-7C953AF082E6', N'2014-08-19 12:16:27.000', N'2014-08-19 12:16:27.000', N'三星n9006高端超薄边框9002手机壳n9008保护套note3金属边框外壳', N'jfddfdfdfdfdfdfdfdf', null, null, null, null, null, null, N'1', N'1', N'本站', N'kkkkkkkk', N'2', N'8BE83074-84F2-47E6-B57B-C640C1D8D900', N'/userfiles/shouji/157c05e6cff3f53022e9c00d9f9b_400_400.jpeg', N'/userfiles/shouji/8136e2f215a0b354cf8d62a726a1_600_600_1_1.jpeg', null, null, null)
GO
GO
INSERT INTO [dbo].[T_Article] ([ArticleID], [CreateDate], [UpdateDate], [Name], [NameEn], [Content], [ContentEn], [Keyword], [KeywordEn], [Description], [DescriptionEn], [IsEnabled], [IsFirst], [From], [BuyLink], [ViewCount], [CategoryID], [PImagea], [PImageb], [PImagec], [PImaged], [PImagee]) VALUES (N'9A196B79-A316-4F1D-9E83-8E523E8713F3', N'2014-08-21 22:35:19.000', N'2014-08-21 22:35:19.000', N'索尼z2手机壳z2手机套l50w手机壳l50t手机套z2手机壳xl39h皮套 ', N'hongmi', N'<p>牵扯</p>', N'<p>3123123</p>', N'234234', N'qianch', N'234', N'qianweiche', N'1', N'0', N'本站', null, N'14', N'2C4771DB-9D37-4809-8E8B-0381C600194D', N'/userfiles/shouji/T1zcWPFApgXXXXXXXX_!!0-item_pic_jpg_220x220.jpg', N'/userfiles/shouji/f230be2c481657bf.jpg', null, null, null)
GO
GO
INSERT INTO [dbo].[T_Article] ([ArticleID], [CreateDate], [UpdateDate], [Name], [NameEn], [Content], [ContentEn], [Keyword], [KeywordEn], [Description], [DescriptionEn], [IsEnabled], [IsFirst], [From], [BuyLink], [ViewCount], [CategoryID], [PImagea], [PImageb], [PImagec], [PImaged], [PImagee]) VALUES (N'F19718CB-5E89-4A68-85C7-8F91854296D2', N'2014-08-21 22:40:04.000', N'2014-08-21 22:40:04.000', N'中兴Q301C手机套 中兴Q301C手机壳 中兴Q301T手机套皮套 保护套壳 ', N'123123', N'<p>&nbsp;中扥中de</p>', N'<p>234234234</p>', N'问', N'34534', N'中扥中', N'345', N'1', N'0', N'本站', null, N'13', N'D0B47EF7-93E9-4A61-94EE-4E51A3CE3315', N'/userfiles/shouji/T1Ng9jFNdXXXXXXXXX_!!0-item_pic_jpg_220x220.jpg', N'/userfiles/shouji/TB14XtjFVXXXXXgapXXXXXXXXXX_!!0-item_pic.jpg_180x180.jpg', null, null, null)
GO
GO
INSERT INTO [dbo].[T_Article] ([ArticleID], [CreateDate], [UpdateDate], [Name], [NameEn], [Content], [ContentEn], [Keyword], [KeywordEn], [Description], [DescriptionEn], [IsEnabled], [IsFirst], [From], [BuyLink], [ViewCount], [CategoryID], [PImagea], [PImageb], [PImagec], [PImaged], [PImagee]) VALUES (N'3F1D9125-C9EE-4C5E-90D0-979AD2A3AC44', N'2014-08-19 17:32:17.000', N'2014-08-19 17:32:17.000', N'小米3手机保护壳 男女个性硬外壳 小米3手机保护套超薄 简', N'shoujike', null, null, N'小心', N'xiaomi34', N'23423', null, N'1', N'0', N'本站', null, N'4', N'B65CBBFA-A886-4CCD-9C3A-E171CB9C6747', N'/userfiles/shouji/TB1zV42FVXXXXaqXXXXXXXXXXXX_!!0-item_pic.jpg_180x180.jpg', N'/userfiles/shouji/TB1DBDqFVXXXXX_XpXXXXXXXXXX_!!0-item_pic.jpg_180x180.jpg', N'/userfiles/shouji/TB1fVz2FVXXXXcVXpXXXXXXXXXX_!!0-item_pic.jpg_180x180.jpg', null, null)
GO
GO
INSERT INTO [dbo].[T_Article] ([ArticleID], [CreateDate], [UpdateDate], [Name], [NameEn], [Content], [ContentEn], [Keyword], [KeywordEn], [Description], [DescriptionEn], [IsEnabled], [IsFirst], [From], [BuyLink], [ViewCount], [CategoryID], [PImagea], [PImageb], [PImagec], [PImaged], [PImagee]) VALUES (N'564C7100-EA93-43CA-9783-D708630BC487', N'2014-08-19 12:05:26.000', N'2014-08-23 16:37:34.000', N'苹果4咳咳', N'pingguo4skeke', N'<p>&nbsp;中扥中嗲</p>
<p><img alt="" width="1000" height="482" src="/userfiles/643927692014072408175004.jpg" /></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><img width="1400" height="570" alt="" src="/userfiles/pic2.jpg" /></p>', null, null, null, null, null, N'1', N'0', N'本站', N'http://www.dtsca.cn/f/index.html', N'4', N'8BE83074-84F2-47E6-B57B-C640C1D8D900', N'/userfiles/shouji/20130731170757_NN8rz.thumb.600_0.jpeg', N'/userfiles/shouji/e40936477ba365a4aa4f6c7f9ea0_1000_1000.jpeg', N'/userfiles/shouji/item-52943C52-35FBFE17000000000401000034F118CD.0.300x300.jpg', N'/userfiles/643927692014072408175004.jpg', null)
GO
GO

-- ----------------------------
-- Indexes structure for table T_Article
-- ----------------------------
CREATE INDEX [PK_Article] ON [dbo].[T_Article]
([ArticleID] ASC) 
GO

-- ----------------------------
-- Primary Key structure for table T_Article
-- ----------------------------
ALTER TABLE [dbo].[T_Article] ADD PRIMARY KEY ([ArticleID])
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[T_Article]
-- ----------------------------
ALTER TABLE [dbo].[T_Article] ADD FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[T_Category] ([CategoryID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
