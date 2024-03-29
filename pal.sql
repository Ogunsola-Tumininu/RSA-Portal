USE [master]
GO
/****** Object:  Database [PALSiteDB]    Script Date: 1/25/2016 2:25:56 PM ******/
CREATE DATABASE [PALSiteDB] ON  PRIMARY 
( NAME = N'PALSiteDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PALSiteDB.mdf' , SIZE = 7168KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PALSiteDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PALSiteDB_log.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PALSiteDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PALSiteDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PALSiteDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PALSiteDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PALSiteDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PALSiteDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PALSiteDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PALSiteDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PALSiteDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PALSiteDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PALSiteDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PALSiteDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PALSiteDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PALSiteDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PALSiteDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PALSiteDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PALSiteDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PALSiteDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PALSiteDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PALSiteDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PALSiteDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PALSiteDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PALSiteDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PALSiteDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PALSiteDB] SET  MULTI_USER 
GO
ALTER DATABASE [PALSiteDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PALSiteDB] SET DB_CHAINING OFF 
GO
USE [PALSiteDB]
GO
/****** Object:  Table [dbo].[AccountManager]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountManager](
	[ManagerId] [int] IDENTITY(1,1) NOT NULL,
	[Region] [nvarchar](255) NULL,
	[AccountManagers] [nvarchar](255) NULL,
	[Phonenumber] [float] NULL,
	[EMAIL] [nvarchar](255) NULL,
 CONSTRAINT [PK_AccountManager] PRIMARY KEY CLUSTERED 
(
	[ManagerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AssetAllocation]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetAllocation](
	[asset_allocation_id] [int] IDENTITY(1,1) NOT NULL,
	[date_created] [datetime] NULL,
	[equity] [float] NULL,
	[fixed_income] [float] NULL,
	[money_market] [float] NULL,
	[others] [float] NULL,
	[asset_allocation_type] [int] NULL,
 CONSTRAINT [PK_PalValueFund] PRIMARY KEY CLUSTERED 
(
	[asset_allocation_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AssetType]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[value] [nvarchar](50) NULL,
 CONSTRAINT [PK_AssetType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BenefitApplications]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BenefitApplications](
	[Employee_Pin] [nvarchar](128) NOT NULL,
	[BenefitSubClassId] [int] NOT NULL,
	[Status] [int] NULL,
	[DateApplied] [datetime] NOT NULL,
	[BenefitApplicationId] [int] IDENTITY(1,1) NOT NULL,
	[DocumentId] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[DateModified] [datetime] NULL,
 CONSTRAINT [PK_BenefitApplications] PRIMARY KEY CLUSTERED 
(
	[BenefitApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BenefitClass]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BenefitClass](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BenefitName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.BenefitClass] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BenefitDocument]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BenefitDocument](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocumentName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.BenefitDocument] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BenefitSubClass]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BenefitSubClass](
	[BenefitSubClassId] [int] IDENTITY(1,1) NOT NULL,
	[BenefitClassId] [int] NULL,
	[BenefitSubClassValue] [nvarchar](100) NULL,
 CONSTRAINT [PK_BenefitSubClass] PRIMARY KEY CLUSTERED 
(
	[BenefitSubClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CaseSummary]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CaseSummary](
	[CaseSummaryId] [int] IDENTITY(1,1) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[Summary] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CurrentStatus] [nvarchar](max) NULL,
	[CaseNumber] [nvarchar](max) NULL,
	[PIN] [nvarchar](max) NULL,
	[LastUpdated] [datetime] NOT NULL,
	[CaseType] [nvarchar](max) NULL,
	[CLosedBy] [nvarchar](max) NULL,
	[AssignedTo] [nvarchar](max) NULL,
	[IswebGenerated] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.CaseSummary] PRIMARY KEY CLUSTERED 
(
	[CaseSummaryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChangeOfAddressProfile]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChangeOfAddressProfile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Pin] [nvarchar](128) NULL,
	[OldAddress] [nvarchar](500) NULL,
	[NewAddress] [nvarchar](500) NULL,
	[Status] [nchar](10) NULL,
	[DateUploaded] [datetime] NULL,
	[DocumentId] [nvarchar](50) NULL,
	[Doc] [nvarchar](50) NULL,
	[Ext] [nchar](10) NULL,
 CONSTRAINT [PK_ChangeOfAddressProfile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChangeOfNameProfile]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChangeOfNameProfile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Pin] [nvarchar](128) NULL,
	[OldName] [nvarchar](100) NULL,
	[NewName] [nvarchar](100) NULL,
	[Doc1] [nvarchar](50) NULL,
	[Doc2] [nvarchar](50) NULL,
	[Ext1] [nchar](10) NULL,
	[Ext2] [nchar](10) NULL,
	[DocumentId] [nvarchar](50) NULL,
	[DateUploaded] [datetime] NULL,
	[Status] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[OldFirstName] [nvarchar](100) NULL,
	[NewFirstName] [nvarchar](100) NULL,
	[OldMiddleName] [nvarchar](100) NULL,
	[NewMiddleName] [nvarchar](100) NULL,
 CONSTRAINT [PK_ChangeOfName] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClientUpdate]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientUpdate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Pin] [nvarchar](max) NULL,
	[OldValue] [nvarchar](max) NULL,
	[NewValue] [nvarchar](max) NULL,
	[DateCreated] [datetime] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.ClientUpdate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contributions]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contributions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Recno] [nvarchar](128) NULL,
	[Employee_Pin] [nvarchar](128) NULL,
	[EmployeeContribution] [float] NULL,
	[EmployerContribution] [float] NULL,
	[ContributionDate] [datetime] NULL,
	[OtherContribution] [float] NULL,
	[EmployeeFee] [float] NULL,
	[EmployerFee] [float] NULL,
	[OtherFee] [float] NULL,
	[TotalUnits] [float] NULL,
	[TotalContribution] [float] NULL,
	[TotalFee] [float] NULL,
	[EmployeeBf] [float] NULL,
	[EmployerBf] [float] NULL,
	[PaymentDate] [datetime] NULL,
	[TransDate] [datetime] NULL,
	[SchemeId] [decimal](18, 5) NULL,
	[Price] [decimal](18, 5) NULL,
	[TransUnitsR] [decimal](18, 5) NULL,
	[TransUnitsV] [decimal](18, 5) NULL,
	[ValueDate] [datetime] NULL,
	[TransId] [nvarchar](50) NULL,
	[VatFee] [decimal](18, 5) NULL,
	[Flaguploaded] [tinyint] NULL,
	[FundId] [int] NULL,
	[ReconciliationTransid] [nvarchar](50) NULL,
	[Withdrawal] [float] NULL,
	[WithdrawalVc] [float] NULL,
 CONSTRAINT [PK_Contributions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeBenefitDocument]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeBenefitDocument](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Filename] [nvarchar](50) NULL,
	[DateUploaded] [datetime] NULL,
	[BenefitApplicationId] [int] NULL,
	[ext] [nvarchar](5) NULL,
 CONSTRAINT [PK_EmployeeBenefitDocument] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Pin] [nvarchar](128) NOT NULL,
	[RegistrationCode] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[OtherNames] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[DateOfBirth] [nvarchar](max) NULL,
	[MobileNumber] [nvarchar](max) NULL,
	[MobileNumber2] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Employer_Recno] [nvarchar](128) NULL,
	[HomeAddress] [nvarchar](max) NULL,
	[PermanentAddress] [nvarchar](max) NULL,
	[ManagerId] [int] NULL,
 CONSTRAINT [PK_dbo.Employees] PRIMARY KEY CLUSTERED 
(
	[Pin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployerDetails]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployerDetails](
	[Recno] [nvarchar](128) NOT NULL,
	[EmployerName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.EmployerDetails] PRIMARY KEY CLUSTERED 
(
	[Recno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExitProcessMaster]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExitProcessMaster](
	[Pin] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_dbo.ExitProcessMaster] PRIMARY KEY CLUSTERED 
(
	[Pin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoginTrail]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginTrail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NULL,
	[LoginDate] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.LoginTrail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NextOfKin]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NextOfKin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Employee_Pin] [nvarchar](128) NULL,
	[FirstName] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[OtherNames] [nvarchar](max) NULL,
	[Relation] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.NextOfKin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PriceHistory]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PriceHistory](
	[price_history_id] [int] IDENTITY(1,1) NOT NULL,
	[scheme_id] [float] NULL,
	[valuation_date] [datetime] NULL,
	[bid_price] [float] NULL,
	[offer_price] [float] NULL,
 CONSTRAINT [PK_PriceHistory] PRIMARY KEY CLUSTERED 
(
	[price_history_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Publications]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publications](
	[PublicationsId] [int] IDENTITY(1,1) NOT NULL,
	[UploadTypeId] [int] NULL,
	[DateUploaded] [datetime] NOT NULL,
	[PublicationName] [nvarchar](200) NULL,
	[Extension] [nchar](10) NULL,
 CONSTRAINT [PK_Publications] PRIMARY KEY CLUSTERED 
(
	[PublicationsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SecretQuestionsStore]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecretQuestionsStore](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](500) NULL,
 CONSTRAINT [PK_SecretQuestionsStore] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sheme]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sheme](
	[SCHEME_ID] [float] NULL,
	[SCHEME_NAME] [nvarchar](255) NULL,
	[REPORT_DATE] [datetime] NULL,
	[OFFER_PRICE] [float] NULL,
	[BID_PRICE] [float] NULL,
	[OFFER_FOR] [nvarchar](255) NULL,
	[BID_FOR] [nvarchar](255) NULL,
	[TOTAL_UNITS] [float] NULL,
	[TOTAL_RECEIVABLES] [nvarchar](255) NULL,
	[NAV] [float] NULL,
	[GAV] [float] NULL,
	[PAY_COT] [nvarchar](255) NULL,
	[COT_PERCENT] [nvarchar](255) NULL,
	[CALC_INTEREST] [nvarchar](255) NULL,
	[INTEREST_RATE] [nvarchar](255) NULL,
	[SCHEME_LOGO] [nvarchar](255) NULL,
	[START_DATE] [datetime] NULL,
	[LAST_PROC_DATE] [datetime] NULL,
	[UPDATE_SUCCESS] [nvarchar](255) NULL,
	[ACCRUED_DIVIDEND] [float] NULL,
	[ACCRUED_FEES] [nvarchar](255) NULL,
	[PAID_FEES] [nvarchar](255) NULL,
	[MANAGER_HEADER_PAGE] [nvarchar](255) NULL,
	[MANAGER_FOOTER_PAGE] [nvarchar](255) NULL,
	[PROMISE] [nvarchar](255) NULL,
	[SCHEME_TYPE] [nvarchar](255) NULL,
	[COMPANY_ID] [float] NULL,
	[LAST_POSTED] [nvarchar](255) NULL,
	[STAMP_DUTIES] [nvarchar](255) NULL,
	[NSE_CSCS_FEES] [nvarchar](255) NULL,
	[BROKERAGE_FEES] [nvarchar](255) NULL,
	[SEC_FEES] [nvarchar](255) NULL,
	[CODE] [nvarchar](255) NULL,
	[MGMT_FEE_PAYABLE_PERC] [nvarchar](255) NULL,
	[EXCESS_FEE_PAYABLE_PERC] [nvarchar](255) NULL,
	[VAT_ON_EXCESS_FEE] [nvarchar](255) NULL,
	[TRANS_FEE_PAYABLE_PERC] [nvarchar](255) NULL,
	[PERCENTAGE_ABOVE] [nvarchar](255) NULL,
	[FEE_TYPE] [nvarchar](255) NULL,
	[CONTRACT_BEGINS] [nvarchar](255) NULL,
	[CONTRACT_ENDS] [nvarchar](255) NULL,
	[ACCOUNT_STATUS] [nvarchar](255) NULL,
	[CSCS_CODE] [nvarchar](255) NULL,
	[ACCOUNT_CODE] [nvarchar](255) NULL,
	[TROI_CODE] [nvarchar](255) NULL,
	[OPENING_NAV] [float] NULL,
	[RATING_REQUIRMENT] [nvarchar](255) NULL,
	[POINT_TO_NOTE] [nvarchar](255) NULL,
	[INVEST_GUIDELINE] [nvarchar](255) NULL,
	[STANDING_ORDERS] [nvarchar](255) NULL,
	[REPORTING_FREQ] [nvarchar](255) NULL,
	[AGREEMENT_EXPIRY] [nvarchar](255) NULL,
	[SCHEME_TABLE_ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Sheme] PRIMARY KEY CLUSTERED 
(
	[SCHEME_TABLE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[State]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [nvarchar](max) NULL,
	[StateCode] [nvarchar](max) NULL,
	[ZoneCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Status]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[StatusValue] [nvarchar](50) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SupportCategories]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupportCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](50) NULL,
 CONSTRAINT [PK_SupportCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SupportLogs]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupportLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Pin] [nvarchar](128) NULL,
	[CategoryId] [int] NULL,
	[Summary] [nvarchar](128) NULL,
	[Explanation] [nvarchar](max) NULL,
	[DateSubmitted] [datetime] NULL,
 CONSTRAINT [PK_SupportLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TempCustomerInformation]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TempCustomerInformation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pin] [nvarchar](50) NULL,
	[mobile-number] [nvarchar](50) NULL,
	[email] [nvarchar](100) NULL,
	[parmanent-address] [nvarchar](500) NULL,
	[home-address] [nvarchar](500) NULL,
	[mobile-number2] [nvarchar](50) NULL,
	[date-created] [datetime] NULL,
	[name] [nvarchar](100) NULL,
	[status] [nvarchar](50) NULL,
 CONSTRAINT [PK_TempCustomerInformation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UploadType]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UploadType](
	[UploadTypeId] [int] IDENTITY(1,1) NOT NULL,
	[UploadTypeValue] [nvarchar](50) NULL,
 CONSTRAINT [PK_UploadType] PRIMARY KEY CLUSTERED 
(
	[UploadTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](56) NOT NULL,
	[SecretQuestionId] [int] NULL,
	[SecretQuestionAnswer] [nvarchar](max) NULL,
	[VerificationCode] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[InvestorId] [int] NULL,
	[Employee_Pin] [nvarchar](128) NULL,
	[LastLogin] [datetime] NULL,
	[QuestionKey] [nvarchar](50) NULL,
	[FirstSignOn] [bit] NULL,
 CONSTRAINT [PK__UserProf__1788CC4CF4F796E3] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserPublications]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPublications](
	[UserPublicationsId] [int] IDENTITY(1,1) NOT NULL,
	[PublicationsId] [int] NULL,
	[EmployeePin] [nvarchar](128) NULL,
 CONSTRAINT [PK_UserPublications] PRIMARY KEY CLUSTERED 
(
	[UserPublicationsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Membership](
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](128) NULL,
	[IsConfirmed] [bit] NULL DEFAULT ((0)),
	[LastPasswordFailureDate] [datetime] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL DEFAULT ((0)),
	[Password] [nvarchar](128) NOT NULL,
	[PasswordChangedDate] [datetime] NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[PasswordVerificationToken] [nvarchar](128) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_OAuthMembership](
	[Provider] [nvarchar](30) NOT NULL,
	[ProviderUserId] [nvarchar](100) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Provider] ASC,
	[ProviderUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 1/25/2016 2:25:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_UsersInRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[AccountManager] ON 

INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (1, N'Lagos', N'BARTH', 8174585633, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (2, N'Lagos', N'BUKOLA', 8174585616, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (3, N'Lagos', N'DAVID', 8174585631, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (4, N'Lagos', N'FUNMI BANJOKO', 8172161716, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (5, N'Lagos', N'FUNMI WILLIAMS', 9091020033, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (6, N'Lagos', N'JOSEPH', 8099900536, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (7, N'Lagos', N'KEMI', NULL, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (8, N'Lagos', N'ADAEZE', 8174585622, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (9, N'Lagos', N'MERCY', 9091020034, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (10, N'Lagos', N'RONKE BASHIR', 8187134826, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (11, N'Lagos', N'SCHOLASTICA', 8174585615, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (12, N'Lagos', N'TOSIN', 8093677800, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (13, N'Lagos', N'UDUAK', 8174585635, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (14, N'Lagos', N'LOVE', 8174585637, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (15, N'North', N'ABDUL ISHAQ', 8093677802, N'abdulishaq@palpensions.com')
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (16, N'North', N'Abdul''Azeez Hassan', 8174585651, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (17, N'North', N'ABDULRAHMAN ALIYU', 8093677804, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (18, N'North', N'ABDULWAHAB ALIYU', 8093679740, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (19, N'North', N'Adoyi, Oche', 7035594723, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (20, N'North', N'Ahmed Jibril Pate', 8093679746, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (21, N'North', N'Akaahar Stephanie Hambafan', 7034813517, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (22, N'North', N'ALIYU MUSA', 8076952006, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (23, N'North', N'ALPHA SAMUEL', 8059867727, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (24, N'North', N'Audu B Mohammed', 8035118898, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (25, N'North', N'BAKO SALIM SANI', 8037753353, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (26, N'North', N'Gabriel Joseph', 8093679744, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (27, N'North', N'Glory Ambrose (Miss)', 8093677806, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (28, N'North', N'Hassan Abdl''Azeez', 8174585651, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (29, N'North', N'Hassan Ahmed', 8093677795, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (30, N'North', N'Idris Abubakar Sadiq', 8093679738, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (31, N'North', N'Idris Tanko', 8093677807, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (32, N'North', N'Jibril Pate Ahmad', 8093679746, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (33, N'North', N'Joy', 8174585655, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (34, N'North', N'Kaka Grema Tijjani', 8093677803, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (35, N'North', N'KAKA YOBE', 8093677803, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (36, N'North', N'Madaki Danjuma', 8174585652, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (37, N'North', N'MICHAEL AGBOOLA', 8093679747, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (38, N'North', N'Mohammed Salman', 8093677805, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (39, N'North', N'Mohammed Shamsudeen', 8035647532, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (40, N'North', N'Akaabo Ade Patrick', 8093679743, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (41, N'North', N'Shehu Lawal Lere', 8093677808, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (42, N'North', N'Suleiman Aliyu', 8035004571, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (43, N'North', N'SYLVESTER NWUGO', 8172376090, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (44, N'North', N'Tonia', 8093679739, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (45, N'North', N'TUKUR', 8039745932, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (46, N'North', N'Umar Abubakar', 8067426268, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (47, N'North', N'Umar Buhari', 8067426268, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (48, N'North', N'Abdullahi Sunusi ', 8093679741, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (49, N'North', N'AUWAL ADAM', 8093679748, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (50, N'North', N'MAHMOUD AHMAD', 8093677796, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (51, N'West', N'ADEWALE SODIMU', 8174585640, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (52, N'West', N'Anna Igho Oraka', NULL, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (53, N'West', N'BUKOLA ODUNUGA', 8174585645, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (54, N'West', N'Joseph Omotoye', NULL, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (55, N'West', N'JOSEPH POPOOLA OMOTOYE', 8172238157, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (56, N'West', N'OLUWABAMIGBE KEMI', NULL, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (57, N'West', N'OMOLARA OGUNROUNBI', 8172238156, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (58, N'West', N'OMOTAYO ANTHONY EGUNJOBI', NULL, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (59, N'West', N'Pius Agbonavbare', 8172238144, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (60, N'West', N'QUEEN OBAZEE', 8172238146, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (61, N'West', N'SHOLA OGUNJOBI', 8172238150, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (62, N'West', N'Sylvia Iredia', 8172238145, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (63, N'West', N'Sylvia Ojugo', 8172238145, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (64, N'East', N'VICTOR EZE', 8172376095, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (65, N'East', N'STANLEY NGEJURU', 818102800, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (66, N'East', N'RAJIH SEMIU', 8172238148, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (67, N'East', N'OGE UHEGWU', 8172376091, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (68, N'East', N'NNEKA JIDEOBI', 9091997804, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (69, N'East', N'JACKSON PIOPAZIBAYANTA', 8036746729, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (70, N'East', N'ISAAC MECHARU', 8172238147, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (71, N'East', N'INIOBONG EKPE', 7039584298, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (72, N'East', N'IJEOMA OSUJI', 8172161710, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (73, N'East', N'IJEOMA AKUCHIE', 8172172881, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (74, N'East', N'EMEKA NNOROM', 7055445228, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (75, N'East', N'ELVIS MABUOGWU', 8172238149, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (76, N'East', N'Chinedu Agbara ', 8030582361, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (77, N'East', N'CHIKA  UCHEDIKE', 8030810630, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (78, N'East', N'CHIBUZOR GILBERT', 8172376097, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (79, N'East', N'CHARLES EJIEKPE', 8157711451, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (80, N'East', N'ARINZE UDECHUKWU', 8172376093, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (81, N'East', N'ANTHONY OKOI', 8172172872, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (82, N'East', N'ANIKWENWA NKECHI', 8098025037, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (83, N'East', N'ANIEDI AKPAN', 8172172875, NULL)
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (84, N'South', N'Seyi Pedro', 7055439630, N'seyipedro@gmail.com')
INSERT [dbo].[AccountManager] ([ManagerId], [Region], [AccountManagers], [Phonenumber], [EMAIL]) VALUES (85, N'Oyo', N'Seyi a', 7055439630, N'manasseh.mchiave@palpensions.com')
SET IDENTITY_INSERT [dbo].[AccountManager] OFF
SET IDENTITY_INSERT [dbo].[AssetAllocation] ON 

INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (1, CAST(N'2015-11-27 00:00:00.000' AS DateTime), 8.3, 71.22, 19.15, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (2, CAST(N'2015-11-28 00:00:00.000' AS DateTime), 8.32, 71.21, 19.15, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (3, CAST(N'2015-11-29 00:00:00.000' AS DateTime), 8.32, 71.21, 19.15, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (4, CAST(N'2015-11-30 00:00:00.000' AS DateTime), 8.25, 71.14, 19.28, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (5, CAST(N'2015-12-01 00:00:00.000' AS DateTime), 8.28, 71.13, 19.29, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (6, CAST(N'2015-12-02 00:00:00.000' AS DateTime), 8.16, 70.83, 19.69, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (7, CAST(N'2015-12-03 00:00:00.000' AS DateTime), 8.19, 70.63, 19.86, 0, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (8, CAST(N'2015-11-27 00:00:00.000' AS DateTime), 8.3, 71.22, 19.15, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (9, CAST(N'2015-11-28 00:00:00.000' AS DateTime), 8.32, 71.21, 19.15, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (10, CAST(N'2015-11-29 00:00:00.000' AS DateTime), 8.32, 71.21, 19.15, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (11, CAST(N'2015-11-30 00:00:00.000' AS DateTime), 8.25, 71.14, 19.28, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (12, CAST(N'2015-12-01 00:00:00.000' AS DateTime), 8.28, 71.13, 19.29, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (13, CAST(N'2015-12-02 00:00:00.000' AS DateTime), 8.16, 70.83, 19.69, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (14, CAST(N'2015-12-03 00:00:00.000' AS DateTime), 8.19, 70.63, 19.86, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (15, CAST(N'2015-11-27 00:00:00.000' AS DateTime), 8.3, 71.22, 19.15, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (16, CAST(N'2015-11-28 00:00:00.000' AS DateTime), 8.32, 71.21, 19.15, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (17, CAST(N'2015-11-29 00:00:00.000' AS DateTime), 8.32, 71.21, 19.15, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (18, CAST(N'2015-11-30 00:00:00.000' AS DateTime), 8.25, 71.14, 19.28, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (19, CAST(N'2015-12-01 00:00:00.000' AS DateTime), 8.28, 71.13, 19.29, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (20, CAST(N'2015-12-02 00:00:00.000' AS DateTime), 8.16, 70.83, 19.69, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (21, CAST(N'2015-12-03 00:00:00.000' AS DateTime), 8.19, 70.63, 19.86, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (22, CAST(N'2015-11-27 00:00:00.000' AS DateTime), 8.3, 71.22, 19.15, 0, 2)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (23, CAST(N'2015-11-28 00:00:00.000' AS DateTime), 8.32, 71.21, 19.15, 0, 2)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (24, CAST(N'2015-11-29 00:00:00.000' AS DateTime), 8.32, 71.21, 19.15, 0, 2)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (25, CAST(N'2015-11-30 00:00:00.000' AS DateTime), 8.25, 71.14, 19.28, 0, 2)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (26, CAST(N'2015-12-01 00:00:00.000' AS DateTime), 8.28, 71.13, 19.29, 0, 2)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (27, CAST(N'2015-12-02 00:00:00.000' AS DateTime), 8.16, 70.83, 19.69, 0, 2)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (28, CAST(N'2015-12-03 00:00:00.000' AS DateTime), 8.19, 70.63, 19.86, 0, 2)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (29, CAST(N'2015-11-27 00:00:00.000' AS DateTime), 8.3, 71.22, 19.15, 0, 2)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (30, CAST(N'2015-11-28 00:00:00.000' AS DateTime), 8.32, 71.21, 19.15, 0, 2)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (31, CAST(N'2015-11-29 00:00:00.000' AS DateTime), 8.32, 71.21, 19.15, 0, 2)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (32, CAST(N'2015-11-30 00:00:00.000' AS DateTime), 8.25, 71.14, 19.28, 0, 2)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (33, CAST(N'2015-12-01 00:00:00.000' AS DateTime), 8.28, 71.13, 19.29, 0, 2)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (34, CAST(N'2015-12-02 00:00:00.000' AS DateTime), 8.16, 70.83, 19.69, 0, 2)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (35, CAST(N'2015-12-03 00:00:00.000' AS DateTime), 8.19, 70.63, 19.86, 0, 2)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (36, CAST(N'2015-11-27 00:00:00.000' AS DateTime), 8.3, 71.22, 19.15, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (37, CAST(N'2015-11-28 00:00:00.000' AS DateTime), 8.32, 71.21, 19.15, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (38, CAST(N'2015-11-29 00:00:00.000' AS DateTime), 8.32, 71.21, 19.15, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (39, CAST(N'2015-11-30 00:00:00.000' AS DateTime), 8.25, 71.14, 19.28, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (40, CAST(N'2015-12-01 00:00:00.000' AS DateTime), 8.28, 71.13, 19.29, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (41, CAST(N'2015-12-02 00:00:00.000' AS DateTime), 8.16, 70.83, 19.69, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (42, CAST(N'2015-12-03 00:00:00.000' AS DateTime), 8.19, 70.63, 19.86, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (43, CAST(N'2015-11-27 00:00:00.000' AS DateTime), 8.3, 71.22, 19.15, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (44, CAST(N'2015-11-28 00:00:00.000' AS DateTime), 8.32, 71.21, 19.15, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (45, CAST(N'2015-11-29 00:00:00.000' AS DateTime), 8.32, 71.21, 19.15, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (46, CAST(N'2015-11-30 00:00:00.000' AS DateTime), 8.25, 71.14, 19.28, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (47, CAST(N'2015-12-01 00:00:00.000' AS DateTime), 8.28, 71.13, 19.29, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (48, CAST(N'2015-12-02 00:00:00.000' AS DateTime), 8.16, 70.83, 19.69, 1.33, 1)
INSERT [dbo].[AssetAllocation] ([asset_allocation_id], [date_created], [equity], [fixed_income], [money_market], [others], [asset_allocation_type]) VALUES (49, CAST(N'2015-12-03 00:00:00.000' AS DateTime), 8.19, 70.63, 19.86, 1.33, 1)
SET IDENTITY_INSERT [dbo].[AssetAllocation] OFF
SET IDENTITY_INSERT [dbo].[AssetType] ON 

INSERT [dbo].[AssetType] ([id], [value]) VALUES (1, N'Pal Value Fund')
INSERT [dbo].[AssetType] ([id], [value]) VALUES (2, N'Retiree Fund')
SET IDENTITY_INSERT [dbo].[AssetType] OFF
SET IDENTITY_INSERT [dbo].[BenefitApplications] ON 

INSERT [dbo].[BenefitApplications] ([Employee_Pin], [BenefitSubClassId], [Status], [DateApplied], [BenefitApplicationId], [DocumentId], [Description], [DateModified]) VALUES (N'PEN100752325918', 3, 4, CAST(N'2016-01-20 13:58:35.640' AS DateTime), 58, N'393c9818-4beb-4578-816c-3381e868b2a1', N'', CAST(N'2016-01-20 16:21:21.240' AS DateTime))
INSERT [dbo].[BenefitApplications] ([Employee_Pin], [BenefitSubClassId], [Status], [DateApplied], [BenefitApplicationId], [DocumentId], [Description], [DateModified]) VALUES (N'PEN100752325918', 5, 1008, CAST(N'2016-01-20 14:09:17.390' AS DateTime), 59, N'd16f9b23-4f77-4acf-918e-5befe6b6ba96', N'invalid', CAST(N'2016-01-20 16:23:20.773' AS DateTime))
SET IDENTITY_INSERT [dbo].[BenefitApplications] OFF
SET IDENTITY_INSERT [dbo].[BenefitClass] ON 

INSERT [dbo].[BenefitClass] ([Id], [BenefitName]) VALUES (1, N'Full Access')
INSERT [dbo].[BenefitClass] ([Id], [BenefitName]) VALUES (2, N'Voluntary Contribution')
SET IDENTITY_INSERT [dbo].[BenefitClass] OFF
SET IDENTITY_INSERT [dbo].[BenefitSubClass] ON 

INSERT [dbo].[BenefitSubClass] ([BenefitSubClassId], [BenefitClassId], [BenefitSubClassValue]) VALUES (1, 1, N'Lumpsum and Programmed Withdrawal')
INSERT [dbo].[BenefitSubClass] ([BenefitSubClassId], [BenefitClassId], [BenefitSubClassValue]) VALUES (2, 1, N'Lumpsum and Annuity')
INSERT [dbo].[BenefitSubClass] ([BenefitSubClassId], [BenefitClassId], [BenefitSubClassValue]) VALUES (3, 1, N'Enbloc')
INSERT [dbo].[BenefitSubClass] ([BenefitSubClassId], [BenefitClassId], [BenefitSubClassValue]) VALUES (4, 1, N'NSITF')
INSERT [dbo].[BenefitSubClass] ([BenefitSubClassId], [BenefitClassId], [BenefitSubClassValue]) VALUES (5, 1, N'Legacy')
INSERT [dbo].[BenefitSubClass] ([BenefitSubClassId], [BenefitClassId], [BenefitSubClassValue]) VALUES (6, 2, N'AVC')
INSERT [dbo].[BenefitSubClass] ([BenefitSubClassId], [BenefitClassId], [BenefitSubClassValue]) VALUES (7, 1, N'Death Benefit')
SET IDENTITY_INSERT [dbo].[BenefitSubClass] OFF
SET IDENTITY_INSERT [dbo].[ChangeOfAddressProfile] ON 

INSERT [dbo].[ChangeOfAddressProfile] ([Id], [Pin], [OldAddress], [NewAddress], [Status], [DateUploaded], [DocumentId], [Doc], [Ext]) VALUES (1, N'PEN100752325918', N'Just checking', N'no 44 epinpejo lane idumota lagos', N'Approved  ', CAST(N'2016-01-19 17:57:22.987' AS DateTime), N'bd3b9f4e-bb9b-4541-bcef-59bfa0aa5132', N'Utility Bill', N'.jpg      ')
INSERT [dbo].[ChangeOfAddressProfile] ([Id], [Pin], [OldAddress], [NewAddress], [Status], [DateUploaded], [DocumentId], [Doc], [Ext]) VALUES (2, N'PEN100752325918', N'no 44 epinpejo lane idumota lagos', N'No 55 Abba Johnston Off Adeniyi Jones ikeja', N'Approved  ', CAST(N'2016-01-20 13:45:27.030' AS DateTime), N'62755c6a-27f6-4fd3-b3be-e6bcadad1e5a', N'Utility Bill', N'.jpg      ')
SET IDENTITY_INSERT [dbo].[ChangeOfAddressProfile] OFF
SET IDENTITY_INSERT [dbo].[ChangeOfNameProfile] ON 

INSERT [dbo].[ChangeOfNameProfile] ([Id], [Pin], [OldName], [NewName], [Doc1], [Doc2], [Ext1], [Ext2], [DocumentId], [DateUploaded], [Status], [Description], [OldFirstName], [NewFirstName], [OldMiddleName], [NewMiddleName]) VALUES (4, N'PEN100752325918', N'Pedro', N'Qudus the badoo', N'Court Affidavit', N'Newspaper Publication', N'.jpg      ', N'.jpg      ', N'7f3ffa96-ad59-4545-b373-3d05ec789eab', CAST(N'2016-01-20 13:44:18.307' AS DateTime), N'Approved', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ChangeOfNameProfile] OFF
SET IDENTITY_INSERT [dbo].[Contributions] ON 

INSERT [dbo].[Contributions] ([Id], [Recno], [Employee_Pin], [EmployeeContribution], [EmployerContribution], [ContributionDate], [OtherContribution], [EmployeeFee], [EmployerFee], [OtherFee], [TotalUnits], [TotalContribution], [TotalFee], [EmployeeBf], [EmployerBf], [PaymentDate], [TransDate], [SchemeId], [Price], [TransUnitsR], [TransUnitsV], [ValueDate], [TransId], [VatFee], [Flaguploaded], [FundId], [ReconciliationTransid], [Withdrawal], [WithdrawalVc]) VALUES (1, N'123', N'PEN100752325918', 10560, 21120, CAST(N'2015-10-02 00:00:00.000' AS DateTime), 10560, 0, 0, 0, 0, 31680, 80, 0, 0, CAST(N'2015-10-26 00:00:00.000' AS DateTime), CAST(N'2015-10-26 00:00:00.000' AS DateTime), CAST(1.00000 AS Decimal(18, 5)), CAST(2.46580 AS Decimal(18, 5)), CAST(12813.69130 AS Decimal(18, 5)), CAST(0.00000 AS Decimal(18, 5)), CAST(N'2015-10-26 00:00:00.000' AS DateTime), N'521547300000206000', CAST(4.00000 AS Decimal(18, 5)), 0, 1, N'201510003925', 0, 0)
INSERT [dbo].[Contributions] ([Id], [Recno], [Employee_Pin], [EmployeeContribution], [EmployerContribution], [ContributionDate], [OtherContribution], [EmployeeFee], [EmployerFee], [OtherFee], [TotalUnits], [TotalContribution], [TotalFee], [EmployeeBf], [EmployerBf], [PaymentDate], [TransDate], [SchemeId], [Price], [TransUnitsR], [TransUnitsV], [ValueDate], [TransId], [VatFee], [Flaguploaded], [FundId], [ReconciliationTransid], [Withdrawal], [WithdrawalVc]) VALUES (2, N'124', N'PEN100752325918', 6537.14, 13074.28, CAST(N'2015-07-31 00:00:00.000' AS DateTime), 0, 0, 0, 0, 0, 19611.42, 80, 0, 0, CAST(N'2015-08-12 00:00:00.000' AS DateTime), CAST(N'2015-08-13 00:00:00.000' AS DateTime), CAST(1.00000 AS Decimal(18, 5)), CAST(2.42660 AS Decimal(18, 5)), CAST(8047.23480 AS Decimal(18, 5)), CAST(0.00000 AS Decimal(18, 5)), CAST(N'2015-08-12 00:00:00.000' AS DateTime), N'521546500000217000
', CAST(4.00000 AS Decimal(18, 5)), 0, 1, N'12', 0, 0)
SET IDENTITY_INSERT [dbo].[Contributions] OFF
SET IDENTITY_INSERT [dbo].[EmployeeBenefitDocument] ON 

INSERT [dbo].[EmployeeBenefitDocument] ([Id], [Filename], [DateUploaded], [BenefitApplicationId], [ext]) VALUES (179, N'ExitLetter', CAST(N'2016-01-20 13:57:44.607' AS DateTime), 58, N'.jpg')
INSERT [dbo].[EmployeeBenefitDocument] ([Id], [Filename], [DateUploaded], [BenefitApplicationId], [ext]) VALUES (180, N'PassportPhoto', CAST(N'2016-01-20 13:57:47.593' AS DateTime), 58, N'.jpg')
INSERT [dbo].[EmployeeBenefitDocument] ([Id], [Filename], [DateUploaded], [BenefitApplicationId], [ext]) VALUES (181, N'BirthCertificate', CAST(N'2016-01-20 13:57:52.417' AS DateTime), 58, N'.jpg')
INSERT [dbo].[EmployeeBenefitDocument] ([Id], [Filename], [DateUploaded], [BenefitApplicationId], [ext]) VALUES (182, N'RetireeDetailForm', CAST(N'2016-01-20 13:57:57.150' AS DateTime), 58, N'.jpg')
INSERT [dbo].[EmployeeBenefitDocument] ([Id], [Filename], [DateUploaded], [BenefitApplicationId], [ext]) VALUES (183, N'MeansOfId', CAST(N'2016-01-20 13:58:01.723' AS DateTime), 58, N'.jpg')
INSERT [dbo].[EmployeeBenefitDocument] ([Id], [Filename], [DateUploaded], [BenefitApplicationId], [ext]) VALUES (184, N'BankDetails', CAST(N'2016-01-20 13:58:32.553' AS DateTime), 58, N'.jpg')
INSERT [dbo].[EmployeeBenefitDocument] ([Id], [Filename], [DateUploaded], [BenefitApplicationId], [ext]) VALUES (185, N'ExitLetter', CAST(N'2016-01-20 13:59:18.707' AS DateTime), 59, N'.jpg')
INSERT [dbo].[EmployeeBenefitDocument] ([Id], [Filename], [DateUploaded], [BenefitApplicationId], [ext]) VALUES (186, N'PassportPhoto', CAST(N'2016-01-20 13:59:22.113' AS DateTime), 59, N'.jpg')
INSERT [dbo].[EmployeeBenefitDocument] ([Id], [Filename], [DateUploaded], [BenefitApplicationId], [ext]) VALUES (187, N'BirthCertificate', CAST(N'2016-01-20 13:59:26.017' AS DateTime), 59, N'.jpg')
INSERT [dbo].[EmployeeBenefitDocument] ([Id], [Filename], [DateUploaded], [BenefitApplicationId], [ext]) VALUES (188, N'RetireeDetailForm', CAST(N'2016-01-20 13:59:29.333' AS DateTime), 59, N'.jpg')
INSERT [dbo].[EmployeeBenefitDocument] ([Id], [Filename], [DateUploaded], [BenefitApplicationId], [ext]) VALUES (189, N'MeansOfId', CAST(N'2016-01-20 13:59:56.497' AS DateTime), 59, N'.jpg')
INSERT [dbo].[EmployeeBenefitDocument] ([Id], [Filename], [DateUploaded], [BenefitApplicationId], [ext]) VALUES (190, N'BankDetails', CAST(N'2016-01-20 13:59:59.580' AS DateTime), 59, N'.jpg')
INSERT [dbo].[EmployeeBenefitDocument] ([Id], [Filename], [DateUploaded], [BenefitApplicationId], [ext]) VALUES (191, N'BondSlip', CAST(N'2016-01-20 14:00:02.863' AS DateTime), 59, N'.jpg')
INSERT [dbo].[EmployeeBenefitDocument] ([Id], [Filename], [DateUploaded], [BenefitApplicationId], [ext]) VALUES (192, N'PencomForm', CAST(N'2016-01-20 14:00:07.663' AS DateTime), 59, N'.jpg')
SET IDENTITY_INSERT [dbo].[EmployeeBenefitDocument] OFF
INSERT [dbo].[Employees] ([Pin], [RegistrationCode], [FirstName], [Surname], [OtherNames], [Gender], [DateOfBirth], [MobileNumber], [MobileNumber2], [Email], [Employer_Recno], [HomeAddress], [PermanentAddress], [ManagerId]) VALUES (N'PEN100752325917
', N'123456', N'Seyi', N'Pedro', N'Ade', N'M', N'11-26-1985', N'07055439630', NULL, N'seyipedro@gmail.com', N'PR0000026425', NULL, NULL, 15)
INSERT [dbo].[Employees] ([Pin], [RegistrationCode], [FirstName], [Surname], [OtherNames], [Gender], [DateOfBirth], [MobileNumber], [MobileNumber2], [Email], [Employer_Recno], [HomeAddress], [PermanentAddress], [ManagerId]) VALUES (N'PEN100752325918', N'1234', N'Roronoa', N'Qudus the badoo', N'Zoro', N'M', N'11-26-1985', N'07055467890', N'09055678909', N'oluwaseyi@rightclick-ng.com', N'PR0000026425', N'Victoria Island', N'No 55 Abba Johnston Off Adeniyi Jones ikeja', 15)
INSERT [dbo].[Employees] ([Pin], [RegistrationCode], [FirstName], [Surname], [OtherNames], [Gender], [DateOfBirth], [MobileNumber], [MobileNumber2], [Email], [Employer_Recno], [HomeAddress], [PermanentAddress], [ManagerId]) VALUES (N'PEN100752325919', N'1234567', N'Ose', N'Agbadu', N'O', N'M', N'11-26-1985', N'08065478922', NULL, N'ose@rightclick-ng.com', N'PR0000026425', NULL, NULL, 16)
INSERT [dbo].[EmployerDetails] ([Recno], [EmployerName], [Address]) VALUES (N'PR0000026425', N'ASADA FARMS LIMITED', N'174 BROAD STR. LAGOS')
SET IDENTITY_INSERT [dbo].[NextOfKin] ON 

INSERT [dbo].[NextOfKin] ([Id], [Employee_Pin], [FirstName], [Gender], [Surname], [OtherNames], [Relation], [Address], [PhoneNumber], [Email]) VALUES (6, N'PEN100752325917
', N'seyi', N'm', N'pedro', N'ade', N'guy', N'13 kufeji', N'07088965432', N'seyi@seyi.com')
INSERT [dbo].[NextOfKin] ([Id], [Employee_Pin], [FirstName], [Gender], [Surname], [OtherNames], [Relation], [Address], [PhoneNumber], [Email]) VALUES (7, N'PEN100752325918', N'ade', N'f', N'saheed', N'juwon', N'snitch', N'15 ebutte metta', N'09088978967', N'ade@live.com')
INSERT [dbo].[NextOfKin] ([Id], [Employee_Pin], [FirstName], [Gender], [Surname], [OtherNames], [Relation], [Address], [PhoneNumber], [Email]) VALUES (8, N'PEN100752325919', N'ife', N'f', N'akinbode', N'olabiwanu', N'witch', N'36 aguda', N'09034523456', N'ife@ife.com')
SET IDENTITY_INSERT [dbo].[NextOfKin] OFF
SET IDENTITY_INSERT [dbo].[PriceHistory] ON 

INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2833, 10000073, CAST(N'2016-01-05 00:00:00.000' AS DateTime), 1.6802, 1.6802)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2834, 10000083, CAST(N'2016-01-05 00:00:00.000' AS DateTime), 1.7466, 1.7466)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2835, 10000093, CAST(N'2016-01-05 00:00:00.000' AS DateTime), 1.7354, 1.7354)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2836, 10000103, CAST(N'2016-01-05 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2837, 10000133, CAST(N'2016-01-05 00:00:00.000' AS DateTime), 1.2698, 1.2698)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2838, 10000133, CAST(N'2016-01-04 00:00:00.000' AS DateTime), 1.2695, 1.2695)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2839, 10000103, CAST(N'2016-01-04 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2840, 10000093, CAST(N'2016-01-04 00:00:00.000' AS DateTime), 1.7349, 1.7349)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2841, 10000083, CAST(N'2016-01-04 00:00:00.000' AS DateTime), 1.7461, 1.7461)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2842, 10000073, CAST(N'2016-01-04 00:00:00.000' AS DateTime), 1.6797, 1.6797)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2843, 1, CAST(N'2016-01-04 00:00:00.000' AS DateTime), 2.487, 2.487)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2844, 10000053, CAST(N'2016-01-04 00:00:00.000' AS DateTime), 2.0697, 2.0697)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2845, 10000053, CAST(N'2016-01-03 00:00:00.000' AS DateTime), 2.0691, 2.0691)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2846, 1, CAST(N'2016-01-03 00:00:00.000' AS DateTime), 2.4864, 2.4864)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2847, 10000073, CAST(N'2016-01-03 00:00:00.000' AS DateTime), 1.6793, 1.6793)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2848, 10000083, CAST(N'2016-01-03 00:00:00.000' AS DateTime), 1.7456, 1.7456)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2849, 10000093, CAST(N'2016-01-03 00:00:00.000' AS DateTime), 1.7343, 1.7343)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2850, 10000103, CAST(N'2016-01-03 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2851, 10000133, CAST(N'2016-01-03 00:00:00.000' AS DateTime), 1.2691, 1.2691)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2852, 10000133, CAST(N'2016-01-02 00:00:00.000' AS DateTime), 1.2688, 1.2688)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2853, 10000103, CAST(N'2016-01-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2854, 10000093, CAST(N'2016-01-02 00:00:00.000' AS DateTime), 1.7338, 1.7338)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2855, 10000083, CAST(N'2016-01-02 00:00:00.000' AS DateTime), 1.7451, 1.7451)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2856, 10000073, CAST(N'2016-01-02 00:00:00.000' AS DateTime), 1.6788, 1.6788)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2857, 1, CAST(N'2016-01-02 00:00:00.000' AS DateTime), 2.4858, 2.4858)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2858, 10000053, CAST(N'2016-01-02 00:00:00.000' AS DateTime), 2.0684, 2.0684)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2859, 10000053, CAST(N'2016-01-01 00:00:00.000' AS DateTime), 2.0678, 2.0678)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2860, 1, CAST(N'2016-01-01 00:00:00.000' AS DateTime), 2.4852, 2.4852)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2861, 10000073, CAST(N'2016-01-01 00:00:00.000' AS DateTime), 1.6784, 1.6784)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2862, 10000083, CAST(N'2016-01-01 00:00:00.000' AS DateTime), 1.7446, 1.7446)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2863, 10000093, CAST(N'2016-01-01 00:00:00.000' AS DateTime), 1.7332, 1.7332)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2864, 10000103, CAST(N'2016-01-01 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2865, 10000133, CAST(N'2016-01-01 00:00:00.000' AS DateTime), 1.2685, 1.2685)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2866, 10000133, CAST(N'2015-12-31 00:00:00.000' AS DateTime), 1.2681, 1.2681)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2867, 10000123, CAST(N'2015-12-31 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2868, 10000103, CAST(N'2015-12-31 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2869, 10000093, CAST(N'2015-12-31 00:00:00.000' AS DateTime), 1.7327, 1.7327)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2870, 10000083, CAST(N'2015-12-31 00:00:00.000' AS DateTime), 1.7442, 1.7442)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2871, 10000073, CAST(N'2015-12-31 00:00:00.000' AS DateTime), 1.6779, 1.6779)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2872, 1, CAST(N'2015-12-31 00:00:00.000' AS DateTime), 2.4846, 2.4846)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2873, 10000053, CAST(N'2015-12-31 00:00:00.000' AS DateTime), 2.0672, 2.0672)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2874, 10000010, CAST(N'2015-12-31 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2875, 10000053, CAST(N'2015-12-30 00:00:00.000' AS DateTime), 2.0663, 2.0663)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2876, 1, CAST(N'2015-12-30 00:00:00.000' AS DateTime), 2.4824, 2.4824)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2877, 10000073, CAST(N'2015-12-30 00:00:00.000' AS DateTime), 1.6771, 1.6771)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2878, 10000083, CAST(N'2015-12-30 00:00:00.000' AS DateTime), 1.7435, 1.7435)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2879, 10000093, CAST(N'2015-12-30 00:00:00.000' AS DateTime), 1.7321, 1.7321)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2880, 10000103, CAST(N'2015-12-30 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2881, 10000133, CAST(N'2015-12-30 00:00:00.000' AS DateTime), 1.2677, 1.2677)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2882, 10000133, CAST(N'2015-12-29 00:00:00.000' AS DateTime), 1.2674, 1.2674)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2883, 10000103, CAST(N'2015-12-29 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2884, 10000093, CAST(N'2015-12-29 00:00:00.000' AS DateTime), 1.7314, 1.7314)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2885, 10000083, CAST(N'2015-12-29 00:00:00.000' AS DateTime), 1.743, 1.743)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2886, 10000073, CAST(N'2015-12-29 00:00:00.000' AS DateTime), 1.6768, 1.6768)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2887, 1, CAST(N'2015-12-29 00:00:00.000' AS DateTime), 2.4737, 2.4737)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2888, 10000053, CAST(N'2015-12-29 00:00:00.000' AS DateTime), 2.0657, 2.0657)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2889, 10000010, CAST(N'2015-12-29 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2890, 10000053, CAST(N'2015-12-28 00:00:00.000' AS DateTime), 2.0651, 2.0651)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2891, 1, CAST(N'2015-12-28 00:00:00.000' AS DateTime), 2.4757, 2.4757)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2892, 10000073, CAST(N'2015-12-28 00:00:00.000' AS DateTime), 1.6766, 1.6766)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2893, 10000083, CAST(N'2015-12-28 00:00:00.000' AS DateTime), 1.7425, 1.7425)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2894, 10000093, CAST(N'2015-12-28 00:00:00.000' AS DateTime), 1.7309, 1.7309)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2895, 10000103, CAST(N'2015-12-28 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2896, 10000133, CAST(N'2015-12-28 00:00:00.000' AS DateTime), 1.2671, 1.2671)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2897, 10000133, CAST(N'2015-12-27 00:00:00.000' AS DateTime), 1.2667, 1.2667)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2898, 10000103, CAST(N'2015-12-27 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2899, 10000093, CAST(N'2015-12-27 00:00:00.000' AS DateTime), 1.7303, 1.7303)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2900, 10000083, CAST(N'2015-12-27 00:00:00.000' AS DateTime), 1.742, 1.742)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2901, 10000073, CAST(N'2015-12-27 00:00:00.000' AS DateTime), 1.676, 1.676)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2902, 1, CAST(N'2015-12-27 00:00:00.000' AS DateTime), 2.4751, 2.4751)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2903, 10000053, CAST(N'2015-12-27 00:00:00.000' AS DateTime), 2.0644, 2.0644)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2904, 10000053, CAST(N'2015-12-26 00:00:00.000' AS DateTime), 2.0638, 2.0638)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2905, 1, CAST(N'2015-12-26 00:00:00.000' AS DateTime), 2.4745, 2.4745)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2906, 10000073, CAST(N'2015-12-26 00:00:00.000' AS DateTime), 1.6754, 1.6754)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2907, 10000083, CAST(N'2015-12-26 00:00:00.000' AS DateTime), 1.7415, 1.7415)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2908, 10000093, CAST(N'2015-12-26 00:00:00.000' AS DateTime), 1.7297, 1.7297)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2909, 10000103, CAST(N'2015-12-26 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2910, 10000133, CAST(N'2015-12-26 00:00:00.000' AS DateTime), 1.2664, 1.2664)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2911, 10000133, CAST(N'2015-12-25 00:00:00.000' AS DateTime), 1.266, 1.266)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2912, 10000103, CAST(N'2015-12-25 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2913, 10000093, CAST(N'2015-12-25 00:00:00.000' AS DateTime), 1.7292, 1.7292)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2914, 10000083, CAST(N'2015-12-25 00:00:00.000' AS DateTime), 1.741, 1.741)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2915, 10000073, CAST(N'2015-12-25 00:00:00.000' AS DateTime), 1.6749, 1.6749)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2916, 1, CAST(N'2015-12-25 00:00:00.000' AS DateTime), 2.4739, 2.4739)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2917, 10000053, CAST(N'2015-12-25 00:00:00.000' AS DateTime), 2.0632, 2.0632)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2918, 10000053, CAST(N'2015-12-24 00:00:00.000' AS DateTime), 2.0626, 2.0626)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2919, 1, CAST(N'2015-12-24 00:00:00.000' AS DateTime), 2.4733, 2.4733)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2920, 10000073, CAST(N'2015-12-24 00:00:00.000' AS DateTime), 1.6744, 1.6744)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2921, 10000083, CAST(N'2015-12-24 00:00:00.000' AS DateTime), 1.7405, 1.7405)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2922, 10000093, CAST(N'2015-12-24 00:00:00.000' AS DateTime), 1.7286, 1.7286)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2923, 10000103, CAST(N'2015-12-24 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2924, 10000133, CAST(N'2015-12-24 00:00:00.000' AS DateTime), 1.2657, 1.2657)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2925, 10000133, CAST(N'2015-12-23 00:00:00.000' AS DateTime), 1.2654, 1.2654)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2926, 10000103, CAST(N'2015-12-23 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2927, 10000093, CAST(N'2015-12-23 00:00:00.000' AS DateTime), 1.728, 1.728)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2928, 10000083, CAST(N'2015-12-23 00:00:00.000' AS DateTime), 1.74, 1.74)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2929, 10000073, CAST(N'2015-12-23 00:00:00.000' AS DateTime), 1.6738, 1.6738)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2930, 1, CAST(N'2015-12-23 00:00:00.000' AS DateTime), 2.4727, 2.4727)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2931, 10000053, CAST(N'2015-12-23 00:00:00.000' AS DateTime), 2.0619, 2.0619)
GO
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2932, 10000053, CAST(N'2015-12-22 00:00:00.000' AS DateTime), 2.0613, 2.0613)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2933, 10000010, CAST(N'2015-12-22 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2934, 1, CAST(N'2015-12-22 00:00:00.000' AS DateTime), 2.4717, 2.4717)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2935, 10000073, CAST(N'2015-12-22 00:00:00.000' AS DateTime), 1.6733, 1.6733)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2936, 10000083, CAST(N'2015-12-22 00:00:00.000' AS DateTime), 1.7395, 1.7395)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2937, 10000093, CAST(N'2015-12-22 00:00:00.000' AS DateTime), 1.7275, 1.7275)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2938, 10000103, CAST(N'2015-12-22 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2939, 10000133, CAST(N'2015-12-22 00:00:00.000' AS DateTime), 1.265, 1.265)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2940, 10000133, CAST(N'2015-12-21 00:00:00.000' AS DateTime), 1.2647, 1.2647)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2941, 10000103, CAST(N'2015-12-21 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2942, 10000093, CAST(N'2015-12-21 00:00:00.000' AS DateTime), 1.7268, 1.7268)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2943, 10000083, CAST(N'2015-12-21 00:00:00.000' AS DateTime), 1.739, 1.739)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2944, 10000073, CAST(N'2015-12-21 00:00:00.000' AS DateTime), 1.6727, 1.6727)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2945, 1, CAST(N'2015-12-21 00:00:00.000' AS DateTime), 2.4716, 2.4716)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2946, 10000053, CAST(N'2015-12-21 00:00:00.000' AS DateTime), 2.0607, 2.0607)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2947, 10000053, CAST(N'2015-12-20 00:00:00.000' AS DateTime), 2.06, 2.06)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2948, 1, CAST(N'2015-12-20 00:00:00.000' AS DateTime), 2.4699, 2.4699)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2949, 10000073, CAST(N'2015-12-20 00:00:00.000' AS DateTime), 1.6722, 1.6722)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2950, 10000083, CAST(N'2015-12-20 00:00:00.000' AS DateTime), 1.7385, 1.7385)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2951, 10000093, CAST(N'2015-12-20 00:00:00.000' AS DateTime), 1.7265, 1.7265)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2952, 10000103, CAST(N'2015-12-20 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2953, 10000133, CAST(N'2015-12-20 00:00:00.000' AS DateTime), 1.2645, 1.2645)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2954, 10000133, CAST(N'2015-12-19 00:00:00.000' AS DateTime), 1.2641, 1.2641)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2955, 10000103, CAST(N'2015-12-19 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2956, 10000093, CAST(N'2015-12-19 00:00:00.000' AS DateTime), 1.7259, 1.7259)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2957, 10000083, CAST(N'2015-12-19 00:00:00.000' AS DateTime), 1.738, 1.738)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2958, 10000073, CAST(N'2015-12-19 00:00:00.000' AS DateTime), 1.6716, 1.6716)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2959, 1, CAST(N'2015-12-19 00:00:00.000' AS DateTime), 2.4692, 2.4692)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2960, 10000053, CAST(N'2015-12-19 00:00:00.000' AS DateTime), 2.0594, 2.0594)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2961, 10000053, CAST(N'2015-12-18 00:00:00.000' AS DateTime), 2.0588, 2.0588)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2962, 10000010, CAST(N'2015-12-18 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2963, 1, CAST(N'2015-12-18 00:00:00.000' AS DateTime), 2.4686, 2.4686)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2964, 10000073, CAST(N'2015-12-18 00:00:00.000' AS DateTime), 1.6711, 1.6711)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2965, 10000083, CAST(N'2015-12-18 00:00:00.000' AS DateTime), 1.7375, 1.7375)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2966, 10000093, CAST(N'2015-12-18 00:00:00.000' AS DateTime), 1.7254, 1.7254)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2967, 10000103, CAST(N'2015-12-18 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2968, 10000133, CAST(N'2015-12-18 00:00:00.000' AS DateTime), 1.2637, 1.2637)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2969, 10000133, CAST(N'2015-12-17 00:00:00.000' AS DateTime), 1.2633, 1.2633)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2970, 10000123, CAST(N'2015-12-17 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2971, 10000103, CAST(N'2015-12-17 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2972, 10000093, CAST(N'2015-12-17 00:00:00.000' AS DateTime), 1.7246, 1.7246)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2973, 10000083, CAST(N'2015-12-17 00:00:00.000' AS DateTime), 1.737, 1.737)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2974, 10000073, CAST(N'2015-12-17 00:00:00.000' AS DateTime), 1.6705, 1.6705)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2975, 1, CAST(N'2015-12-17 00:00:00.000' AS DateTime), 2.4715, 2.4715)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2976, 10000010, CAST(N'2015-12-17 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2977, 10000053, CAST(N'2015-12-17 00:00:00.000' AS DateTime), 2.0581, 2.0581)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2978, 10000053, CAST(N'2015-12-16 00:00:00.000' AS DateTime), 2.0575, 2.0575)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2979, 1, CAST(N'2015-12-16 00:00:00.000' AS DateTime), 2.4711, 2.4711)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2980, 10000073, CAST(N'2015-12-16 00:00:00.000' AS DateTime), 1.67, 1.67)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2981, 10000083, CAST(N'2015-12-16 00:00:00.000' AS DateTime), 1.7366, 1.7366)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2982, 10000093, CAST(N'2015-12-16 00:00:00.000' AS DateTime), 1.724, 1.724)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2983, 10000103, CAST(N'2015-12-16 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2984, 10000133, CAST(N'2015-12-16 00:00:00.000' AS DateTime), 1.2628, 1.2628)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2985, 10000133, CAST(N'2015-12-15 00:00:00.000' AS DateTime), 1.2624, 1.2624)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2986, 10000103, CAST(N'2015-12-15 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2987, 10000093, CAST(N'2015-12-15 00:00:00.000' AS DateTime), 1.7234, 1.7234)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2988, 10000083, CAST(N'2015-12-15 00:00:00.000' AS DateTime), 1.7361, 1.7361)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2989, 10000073, CAST(N'2015-12-15 00:00:00.000' AS DateTime), 1.6695, 1.6695)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2990, 1, CAST(N'2015-12-15 00:00:00.000' AS DateTime), 2.4705, 2.4705)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2991, 10000053, CAST(N'2015-12-15 00:00:00.000' AS DateTime), 2.0568, 2.0568)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2992, 10000010, CAST(N'2015-12-15 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2993, 10000053, CAST(N'2015-12-14 00:00:00.000' AS DateTime), 2.0562, 2.0562)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2994, 1, CAST(N'2015-12-14 00:00:00.000' AS DateTime), 2.4729, 2.4729)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2995, 10000073, CAST(N'2015-12-14 00:00:00.000' AS DateTime), 1.6689, 1.6689)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2996, 10000083, CAST(N'2015-12-14 00:00:00.000' AS DateTime), 1.7356, 1.7356)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2997, 10000093, CAST(N'2015-12-14 00:00:00.000' AS DateTime), 1.723, 1.723)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2998, 10000103, CAST(N'2015-12-14 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (2999, 10000133, CAST(N'2015-12-14 00:00:00.000' AS DateTime), 1.262, 1.262)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3000, 10000133, CAST(N'2015-12-13 00:00:00.000' AS DateTime), 1.2616, 1.2616)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3001, 10000103, CAST(N'2015-12-13 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3002, 10000093, CAST(N'2015-12-13 00:00:00.000' AS DateTime), 1.7225, 1.7225)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3003, 10000083, CAST(N'2015-12-13 00:00:00.000' AS DateTime), 1.7351, 1.7351)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3004, 10000073, CAST(N'2015-12-13 00:00:00.000' AS DateTime), 1.6684, 1.6684)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3005, 1, CAST(N'2015-12-13 00:00:00.000' AS DateTime), 2.4737, 2.4737)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3006, 10000053, CAST(N'2015-12-13 00:00:00.000' AS DateTime), 2.0555, 2.0555)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3007, 10000053, CAST(N'2015-12-12 00:00:00.000' AS DateTime), 2.0549, 2.0549)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3008, 1, CAST(N'2015-12-12 00:00:00.000' AS DateTime), 2.4731, 2.4731)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3009, 10000073, CAST(N'2015-12-12 00:00:00.000' AS DateTime), 1.6678, 1.6678)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3010, 10000083, CAST(N'2015-12-12 00:00:00.000' AS DateTime), 1.7346, 1.7346)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3011, 10000093, CAST(N'2015-12-12 00:00:00.000' AS DateTime), 1.7219, 1.7219)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3012, 10000103, CAST(N'2015-12-12 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3013, 10000133, CAST(N'2015-12-12 00:00:00.000' AS DateTime), 1.2612, 1.2612)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3014, 10000133, CAST(N'2015-12-11 00:00:00.000' AS DateTime), 1.2608, 1.2608)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3015, 10000103, CAST(N'2015-12-11 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3016, 10000093, CAST(N'2015-12-11 00:00:00.000' AS DateTime), 1.7213, 1.7213)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3017, 10000083, CAST(N'2015-12-11 00:00:00.000' AS DateTime), 1.7341, 1.7341)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3018, 10000073, CAST(N'2015-12-11 00:00:00.000' AS DateTime), 1.6673, 1.6673)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3019, 1, CAST(N'2015-12-11 00:00:00.000' AS DateTime), 2.4725, 2.4725)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3020, 10000053, CAST(N'2015-12-11 00:00:00.000' AS DateTime), 2.0542, 2.0542)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3021, 10000053, CAST(N'2015-12-10 00:00:00.000' AS DateTime), 2.0536, 2.0536)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3022, 10000010, CAST(N'2015-12-10 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3023, 1, CAST(N'2015-12-10 00:00:00.000' AS DateTime), 2.471, 2.471)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3024, 10000073, CAST(N'2015-12-10 00:00:00.000' AS DateTime), 1.6667, 1.6667)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3025, 10000083, CAST(N'2015-12-10 00:00:00.000' AS DateTime), 1.7336, 1.7336)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3026, 10000093, CAST(N'2015-12-10 00:00:00.000' AS DateTime), 1.7207, 1.7207)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3027, 10000103, CAST(N'2015-12-10 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3028, 10000133, CAST(N'2015-12-10 00:00:00.000' AS DateTime), 1.2604, 1.2604)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3029, 10000133, CAST(N'2015-12-09 00:00:00.000' AS DateTime), 1.26, 1.26)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3030, 10000103, CAST(N'2015-12-09 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3031, 10000093, CAST(N'2015-12-09 00:00:00.000' AS DateTime), 1.7199, 1.7199)
GO
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3032, 10000083, CAST(N'2015-12-09 00:00:00.000' AS DateTime), 1.7331, 1.7331)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3033, 10000073, CAST(N'2015-12-09 00:00:00.000' AS DateTime), 1.6662, 1.6662)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3034, 1, CAST(N'2015-12-09 00:00:00.000' AS DateTime), 2.468, 2.468)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3035, 10000053, CAST(N'2015-12-09 00:00:00.000' AS DateTime), 2.0529, 2.0529)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3036, 10000053, CAST(N'2015-12-08 00:00:00.000' AS DateTime), 2.0523, 2.0523)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3037, 1, CAST(N'2015-12-08 00:00:00.000' AS DateTime), 2.47, 2.47)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3038, 10000073, CAST(N'2015-12-08 00:00:00.000' AS DateTime), 1.6656, 1.6656)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3039, 10000083, CAST(N'2015-12-08 00:00:00.000' AS DateTime), 1.7327, 1.7327)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3040, 10000093, CAST(N'2015-12-08 00:00:00.000' AS DateTime), 1.7193, 1.7193)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3041, 10000103, CAST(N'2015-12-08 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3042, 10000133, CAST(N'2015-12-08 00:00:00.000' AS DateTime), 1.2595, 1.2595)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3043, 10000133, CAST(N'2015-12-07 00:00:00.000' AS DateTime), 1.2591, 1.2591)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3044, 10000103, CAST(N'2015-12-07 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3045, 10000093, CAST(N'2015-12-07 00:00:00.000' AS DateTime), 1.7187, 1.7187)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3046, 10000083, CAST(N'2015-12-07 00:00:00.000' AS DateTime), 1.7323, 1.7323)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3047, 10000073, CAST(N'2015-12-07 00:00:00.000' AS DateTime), 1.6651, 1.6651)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3048, 1, CAST(N'2015-12-07 00:00:00.000' AS DateTime), 2.4727, 2.4727)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3049, 10000053, CAST(N'2015-12-07 00:00:00.000' AS DateTime), 2.0516, 2.0516)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3050, 10000010, CAST(N'2015-12-07 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3051, 10000053, CAST(N'2015-12-06 00:00:00.000' AS DateTime), 2.051, 2.051)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3052, 1, CAST(N'2015-12-06 00:00:00.000' AS DateTime), 2.4749, 2.4749)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3053, 10000073, CAST(N'2015-12-06 00:00:00.000' AS DateTime), 1.6646, 1.6646)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3054, 10000083, CAST(N'2015-12-06 00:00:00.000' AS DateTime), 1.7317, 1.7317)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3055, 10000093, CAST(N'2015-12-06 00:00:00.000' AS DateTime), 1.7181, 1.7181)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3056, 10000103, CAST(N'2015-12-06 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3057, 10000133, CAST(N'2015-12-06 00:00:00.000' AS DateTime), 1.2587, 1.2587)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3058, 10000133, CAST(N'2015-12-05 00:00:00.000' AS DateTime), 1.2583, 1.2583)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3059, 10000103, CAST(N'2015-12-05 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3060, 10000093, CAST(N'2015-12-05 00:00:00.000' AS DateTime), 1.7175, 1.7175)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3061, 10000083, CAST(N'2015-12-05 00:00:00.000' AS DateTime), 1.7312, 1.7312)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3062, 10000073, CAST(N'2015-12-05 00:00:00.000' AS DateTime), 1.664, 1.664)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3063, 1, CAST(N'2015-12-05 00:00:00.000' AS DateTime), 2.4743, 2.4743)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3064, 10000053, CAST(N'2015-12-05 00:00:00.000' AS DateTime), 2.0503, 2.0503)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3065, 10000053, CAST(N'2015-12-04 00:00:00.000' AS DateTime), 2.0496, 2.0496)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3066, 10000010, CAST(N'2015-12-04 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3067, 1, CAST(N'2015-12-04 00:00:00.000' AS DateTime), 2.4736, 2.4736)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3068, 10000073, CAST(N'2015-12-04 00:00:00.000' AS DateTime), 1.6635, 1.6635)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3069, 10000083, CAST(N'2015-12-04 00:00:00.000' AS DateTime), 1.7306, 1.7306)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3070, 10000093, CAST(N'2015-12-04 00:00:00.000' AS DateTime), 1.7169, 1.7169)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3071, 10000103, CAST(N'2015-12-04 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3072, 10000133, CAST(N'2015-12-04 00:00:00.000' AS DateTime), 1.2579, 1.2579)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3073, 10000133, CAST(N'2015-12-03 00:00:00.000' AS DateTime), 1.2575, 1.2575)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3074, 10000103, CAST(N'2015-12-03 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3075, 10000093, CAST(N'2015-12-03 00:00:00.000' AS DateTime), 1.7163, 1.7163)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3076, 10000083, CAST(N'2015-12-03 00:00:00.000' AS DateTime), 1.73, 1.73)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3077, 10000073, CAST(N'2015-12-03 00:00:00.000' AS DateTime), 1.6629, 1.6629)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3078, 1, CAST(N'2015-12-03 00:00:00.000' AS DateTime), 2.4716, 2.4716)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3079, 10000010, CAST(N'2015-12-03 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3080, 10000053, CAST(N'2015-12-03 00:00:00.000' AS DateTime), 2.049, 2.049)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3081, 10000053, CAST(N'2015-12-02 00:00:00.000' AS DateTime), 2.0483, 2.0483)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3082, 10000010, CAST(N'2015-12-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3083, 1, CAST(N'2015-12-02 00:00:00.000' AS DateTime), 2.4695, 2.4695)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3084, 10000073, CAST(N'2015-12-02 00:00:00.000' AS DateTime), 1.6624, 1.6624)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3085, 10000083, CAST(N'2015-12-02 00:00:00.000' AS DateTime), 1.7295, 1.7295)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3086, 10000093, CAST(N'2015-12-02 00:00:00.000' AS DateTime), 1.7157, 1.7157)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3087, 10000103, CAST(N'2015-12-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3088, 10000133, CAST(N'2015-12-02 00:00:00.000' AS DateTime), 1.2571, 1.2571)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3089, 10000133, CAST(N'2015-12-01 00:00:00.000' AS DateTime), 1.2567, 1.2567)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3090, 10000103, CAST(N'2015-12-01 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3091, 10000093, CAST(N'2015-12-01 00:00:00.000' AS DateTime), 1.7151, 1.7151)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3092, 10000083, CAST(N'2015-12-01 00:00:00.000' AS DateTime), 1.729, 1.729)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3093, 10000073, CAST(N'2015-12-01 00:00:00.000' AS DateTime), 1.6618, 1.6618)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3094, 1, CAST(N'2015-12-01 00:00:00.000' AS DateTime), 2.4709, 2.4709)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3095, 10000010, CAST(N'2015-12-01 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3096, 10000053, CAST(N'2015-12-01 00:00:00.000' AS DateTime), 2.0476, 2.0476)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3097, 10000053, CAST(N'2015-11-30 00:00:00.000' AS DateTime), 2.047, 2.047)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3098, 10000010, CAST(N'2015-11-30 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3099, 1, CAST(N'2015-11-30 00:00:00.000' AS DateTime), 2.4696, 2.4696)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3100, 10000073, CAST(N'2015-11-30 00:00:00.000' AS DateTime), 1.6613, 1.6613)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3101, 10000083, CAST(N'2015-11-30 00:00:00.000' AS DateTime), 1.7284, 1.7284)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3102, 10000093, CAST(N'2015-11-30 00:00:00.000' AS DateTime), 1.7148, 1.7148)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3103, 10000103, CAST(N'2015-11-30 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3104, 10000133, CAST(N'2015-11-30 00:00:00.000' AS DateTime), 1.2562, 1.2562)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3105, 10000123, CAST(N'2015-11-30 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3106, 10000133, CAST(N'2015-11-29 00:00:00.000' AS DateTime), 1.2558, 1.2558)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3107, 10000103, CAST(N'2015-11-29 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3108, 10000093, CAST(N'2015-11-29 00:00:00.000' AS DateTime), 1.7141, 1.7141)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3109, 10000083, CAST(N'2015-11-29 00:00:00.000' AS DateTime), 1.7275, 1.7275)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3110, 10000073, CAST(N'2015-11-29 00:00:00.000' AS DateTime), 1.6607, 1.6607)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3111, 1, CAST(N'2015-11-29 00:00:00.000' AS DateTime), 2.4703, 2.4703)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3112, 10000053, CAST(N'2015-11-29 00:00:00.000' AS DateTime), 2.0478, 2.0478)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3113, 10000053, CAST(N'2015-11-28 00:00:00.000' AS DateTime), 2.0471, 2.0471)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3114, 1, CAST(N'2015-11-28 00:00:00.000' AS DateTime), 2.4696, 2.4696)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3115, 10000073, CAST(N'2015-11-28 00:00:00.000' AS DateTime), 1.6602, 1.6602)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3116, 10000083, CAST(N'2015-11-28 00:00:00.000' AS DateTime), 1.727, 1.727)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3117, 10000093, CAST(N'2015-11-28 00:00:00.000' AS DateTime), 1.7135, 1.7135)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3118, 10000103, CAST(N'2015-11-28 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3119, 10000133, CAST(N'2015-11-28 00:00:00.000' AS DateTime), 1.2554, 1.2554)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3120, 10000133, CAST(N'2015-11-27 00:00:00.000' AS DateTime), 1.255, 1.255)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3121, 10000103, CAST(N'2015-11-27 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3122, 10000093, CAST(N'2015-11-27 00:00:00.000' AS DateTime), 1.7129, 1.7129)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3123, 10000083, CAST(N'2015-11-27 00:00:00.000' AS DateTime), 1.7264, 1.7264)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3124, 10000073, CAST(N'2015-11-27 00:00:00.000' AS DateTime), 1.6596, 1.6596)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3125, 1, CAST(N'2015-11-27 00:00:00.000' AS DateTime), 2.469, 2.469)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3126, 10000053, CAST(N'2015-11-27 00:00:00.000' AS DateTime), 2.0465, 2.0465)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3127, 10000053, CAST(N'2015-11-26 00:00:00.000' AS DateTime), 2.0458, 2.0458)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3128, 10000010, CAST(N'2015-11-26 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3129, 1, CAST(N'2015-11-26 00:00:00.000' AS DateTime), 2.47, 2.47)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3130, 10000073, CAST(N'2015-11-26 00:00:00.000' AS DateTime), 1.6591, 1.6591)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3131, 10000083, CAST(N'2015-11-26 00:00:00.000' AS DateTime), 1.7258, 1.7258)
GO
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3132, 10000093, CAST(N'2015-11-26 00:00:00.000' AS DateTime), 1.7123, 1.7123)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3133, 10000103, CAST(N'2015-11-26 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3134, 10000133, CAST(N'2015-11-26 00:00:00.000' AS DateTime), 1.2546, 1.2546)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3135, 10000133, CAST(N'2015-11-25 00:00:00.000' AS DateTime), 1.2542, 1.2542)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3136, 10000103, CAST(N'2015-11-25 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3137, 10000093, CAST(N'2015-11-25 00:00:00.000' AS DateTime), 1.7123, 1.7123)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3138, 10000083, CAST(N'2015-11-25 00:00:00.000' AS DateTime), 1.7253, 1.7253)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3139, 10000073, CAST(N'2015-11-25 00:00:00.000' AS DateTime), 1.6586, 1.6586)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3140, 1, CAST(N'2015-11-25 00:00:00.000' AS DateTime), 2.4515, 2.4515)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3141, 10000010, CAST(N'2015-11-25 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3142, 10000053, CAST(N'2015-11-25 00:00:00.000' AS DateTime), 2.045, 2.045)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3143, 10000053, CAST(N'2015-11-24 00:00:00.000' AS DateTime), 2.0444, 2.0444)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3144, 10000010, CAST(N'2015-11-24 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3145, 1, CAST(N'2015-11-24 00:00:00.000' AS DateTime), 2.4682, 2.4682)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3146, 10000073, CAST(N'2015-11-24 00:00:00.000' AS DateTime), 1.658, 1.658)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3147, 10000083, CAST(N'2015-11-24 00:00:00.000' AS DateTime), 1.7247, 1.7247)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3148, 10000093, CAST(N'2015-11-24 00:00:00.000' AS DateTime), 1.7109, 1.7109)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3149, 10000103, CAST(N'2015-11-24 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3150, 10000133, CAST(N'2015-11-24 00:00:00.000' AS DateTime), 1.2538, 1.2538)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3151, 10000133, CAST(N'2015-11-23 00:00:00.000' AS DateTime), 1.2533, 1.2533)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3152, 10000103, CAST(N'2015-11-23 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3153, 10000093, CAST(N'2015-11-23 00:00:00.000' AS DateTime), 1.7103, 1.7103)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3154, 10000083, CAST(N'2015-11-23 00:00:00.000' AS DateTime), 1.7241, 1.7241)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3155, 10000073, CAST(N'2015-11-23 00:00:00.000' AS DateTime), 1.6575, 1.6575)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3156, 1, CAST(N'2015-11-23 00:00:00.000' AS DateTime), 2.4688, 2.4688)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3157, 10000053, CAST(N'2015-11-23 00:00:00.000' AS DateTime), 2.0437, 2.0437)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3158, 10000053, CAST(N'2015-11-22 00:00:00.000' AS DateTime), 2.043, 2.043)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3159, 10000010, CAST(N'2015-11-22 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3160, 1, CAST(N'2015-11-22 00:00:00.000' AS DateTime), 2.4716, 2.4716)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3161, 10000073, CAST(N'2015-11-22 00:00:00.000' AS DateTime), 1.6569, 1.6569)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3162, 10000083, CAST(N'2015-11-22 00:00:00.000' AS DateTime), 1.7235, 1.7235)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3163, 10000093, CAST(N'2015-11-22 00:00:00.000' AS DateTime), 1.7098, 1.7098)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3164, 10000103, CAST(N'2015-11-22 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3165, 10000133, CAST(N'2015-11-22 00:00:00.000' AS DateTime), 1.2529, 1.2529)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3166, 10000133, CAST(N'2015-11-21 00:00:00.000' AS DateTime), 1.2525, 1.2525)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3167, 10000103, CAST(N'2015-11-21 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3168, 10000093, CAST(N'2015-11-21 00:00:00.000' AS DateTime), 1.7092, 1.7092)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3169, 10000083, CAST(N'2015-11-21 00:00:00.000' AS DateTime), 1.723, 1.723)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3170, 10000073, CAST(N'2015-11-21 00:00:00.000' AS DateTime), 1.6564, 1.6564)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3171, 1, CAST(N'2015-11-21 00:00:00.000' AS DateTime), 2.471, 2.471)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3172, 10000053, CAST(N'2015-11-21 00:00:00.000' AS DateTime), 2.0424, 2.0424)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3173, 10000053, CAST(N'2015-11-20 00:00:00.000' AS DateTime), 2.0417, 2.0417)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3174, 10000010, CAST(N'2015-11-20 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3175, 1, CAST(N'2015-11-20 00:00:00.000' AS DateTime), 2.4703, 2.4703)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3176, 10000073, CAST(N'2015-11-20 00:00:00.000' AS DateTime), 1.6558, 1.6558)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3177, 10000083, CAST(N'2015-11-20 00:00:00.000' AS DateTime), 1.7224, 1.7224)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3178, 10000093, CAST(N'2015-11-20 00:00:00.000' AS DateTime), 1.7086, 1.7086)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3179, 10000103, CAST(N'2015-11-20 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3180, 10000133, CAST(N'2015-11-20 00:00:00.000' AS DateTime), 1.2521, 1.2521)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3181, 10000133, CAST(N'2015-11-19 00:00:00.000' AS DateTime), 1.2517, 1.2517)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3182, 10000103, CAST(N'2015-11-19 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3183, 10000093, CAST(N'2015-11-19 00:00:00.000' AS DateTime), 1.708, 1.708)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3184, 10000083, CAST(N'2015-11-19 00:00:00.000' AS DateTime), 1.7219, 1.7219)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3185, 10000073, CAST(N'2015-11-19 00:00:00.000' AS DateTime), 1.6553, 1.6553)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3186, 1, CAST(N'2015-11-19 00:00:00.000' AS DateTime), 2.471, 2.471)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3187, 10000010, CAST(N'2015-11-19 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3188, 10000053, CAST(N'2015-11-19 00:00:00.000' AS DateTime), 2.041, 2.041)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3189, 10000053, CAST(N'2015-11-18 00:00:00.000' AS DateTime), 2.0404, 2.0404)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3190, 10000010, CAST(N'2015-11-18 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3191, 1, CAST(N'2015-11-18 00:00:00.000' AS DateTime), 2.4707, 2.4707)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3192, 10000073, CAST(N'2015-11-18 00:00:00.000' AS DateTime), 1.6547, 1.6547)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3193, 10000083, CAST(N'2015-11-18 00:00:00.000' AS DateTime), 1.7213, 1.7213)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3194, 10000093, CAST(N'2015-11-18 00:00:00.000' AS DateTime), 1.7074, 1.7074)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3195, 10000103, CAST(N'2015-11-18 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3196, 10000133, CAST(N'2015-11-18 00:00:00.000' AS DateTime), 1.2513, 1.2513)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3197, 10000133, CAST(N'2015-11-17 00:00:00.000' AS DateTime), 1.2509, 1.2509)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3198, 10000103, CAST(N'2015-11-17 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3199, 10000093, CAST(N'2015-11-17 00:00:00.000' AS DateTime), 1.7068, 1.7068)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3200, 10000083, CAST(N'2015-11-17 00:00:00.000' AS DateTime), 1.7207, 1.7207)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3201, 10000073, CAST(N'2015-11-17 00:00:00.000' AS DateTime), 1.6542, 1.6542)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3202, 1, CAST(N'2015-11-17 00:00:00.000' AS DateTime), 2.4698, 2.4698)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3203, 10000010, CAST(N'2015-11-17 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3204, 10000053, CAST(N'2015-11-17 00:00:00.000' AS DateTime), 2.0397, 2.0397)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3205, 10000053, CAST(N'2015-11-16 00:00:00.000' AS DateTime), 2.0369, 2.0369)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3206, 10000010, CAST(N'2015-11-16 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3207, 1, CAST(N'2015-11-16 00:00:00.000' AS DateTime), 2.4717, 2.4717)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3208, 10000073, CAST(N'2015-11-16 00:00:00.000' AS DateTime), 1.6537, 1.6537)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3209, 10000083, CAST(N'2015-11-16 00:00:00.000' AS DateTime), 1.7201, 1.7201)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3210, 10000093, CAST(N'2015-11-16 00:00:00.000' AS DateTime), 1.7062, 1.7062)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3211, 10000103, CAST(N'2015-11-16 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3212, 10000133, CAST(N'2015-11-16 00:00:00.000' AS DateTime), 1.2505, 1.2505)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3213, 10000133, CAST(N'2015-11-15 00:00:00.000' AS DateTime), 1.25, 1.25)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3214, 10000103, CAST(N'2015-11-15 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3215, 10000093, CAST(N'2015-11-15 00:00:00.000' AS DateTime), 1.7058, 1.7058)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3216, 10000083, CAST(N'2015-11-15 00:00:00.000' AS DateTime), 1.7196, 1.7196)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3217, 10000073, CAST(N'2015-11-15 00:00:00.000' AS DateTime), 1.6531, 1.6531)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3218, 1, CAST(N'2015-11-15 00:00:00.000' AS DateTime), 2.4738, 2.4738)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3219, 10000010, CAST(N'2015-11-15 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3220, 10000053, CAST(N'2015-11-15 00:00:00.000' AS DateTime), 2.0363, 2.0363)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3221, 10000053, CAST(N'2015-11-14 00:00:00.000' AS DateTime), 2.0356, 2.0356)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3222, 1, CAST(N'2015-11-14 00:00:00.000' AS DateTime), 2.4732, 2.4732)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3223, 10000073, CAST(N'2015-11-14 00:00:00.000' AS DateTime), 1.6526, 1.6526)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3224, 10000083, CAST(N'2015-11-14 00:00:00.000' AS DateTime), 1.719, 1.719)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3225, 10000093, CAST(N'2015-11-14 00:00:00.000' AS DateTime), 1.7052, 1.7052)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3226, 10000103, CAST(N'2015-11-14 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3227, 10000133, CAST(N'2015-11-14 00:00:00.000' AS DateTime), 1.2496, 1.2496)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3228, 10000133, CAST(N'2015-11-13 00:00:00.000' AS DateTime), 1.2492, 1.2492)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3229, 10000103, CAST(N'2015-11-13 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3230, 10000093, CAST(N'2015-11-13 00:00:00.000' AS DateTime), 1.7046, 1.7046)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3231, 10000083, CAST(N'2015-11-13 00:00:00.000' AS DateTime), 1.7184, 1.7184)
GO
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3232, 10000073, CAST(N'2015-11-13 00:00:00.000' AS DateTime), 1.652, 1.652)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3233, 1, CAST(N'2015-11-13 00:00:00.000' AS DateTime), 2.4725, 2.4725)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3234, 10000053, CAST(N'2015-11-13 00:00:00.000' AS DateTime), 2.0349, 2.0349)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3235, 10000010, CAST(N'2015-11-13 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3236, 10000053, CAST(N'2015-11-12 00:00:00.000' AS DateTime), 2.0343, 2.0343)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3237, 1, CAST(N'2015-11-12 00:00:00.000' AS DateTime), 2.4721, 2.4721)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3238, 10000073, CAST(N'2015-11-12 00:00:00.000' AS DateTime), 1.6515, 1.6515)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3239, 10000083, CAST(N'2015-11-12 00:00:00.000' AS DateTime), 1.7178, 1.7178)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3240, 10000093, CAST(N'2015-11-12 00:00:00.000' AS DateTime), 1.7039, 1.7039)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3241, 10000103, CAST(N'2015-11-12 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3242, 10000133, CAST(N'2015-11-12 00:00:00.000' AS DateTime), 1.2488, 1.2488)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3243, 10000133, CAST(N'2015-11-11 00:00:00.000' AS DateTime), 1.2484, 1.2484)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3244, 10000103, CAST(N'2015-11-11 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3245, 10000093, CAST(N'2015-11-11 00:00:00.000' AS DateTime), 1.7033, 1.7033)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3246, 10000083, CAST(N'2015-11-11 00:00:00.000' AS DateTime), 1.7172, 1.7172)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3247, 10000073, CAST(N'2015-11-11 00:00:00.000' AS DateTime), 1.6509, 1.6509)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3248, 1, CAST(N'2015-11-11 00:00:00.000' AS DateTime), 2.4728, 2.4728)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3249, 10000053, CAST(N'2015-11-11 00:00:00.000' AS DateTime), 2.0336, 2.0336)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3250, 10000053, CAST(N'2015-11-10 00:00:00.000' AS DateTime), 2.033, 2.033)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3251, 10000010, CAST(N'2015-11-10 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3252, 1, CAST(N'2015-11-10 00:00:00.000' AS DateTime), 2.4732, 2.4732)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3253, 10000073, CAST(N'2015-11-10 00:00:00.000' AS DateTime), 1.6504, 1.6504)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3254, 10000083, CAST(N'2015-11-10 00:00:00.000' AS DateTime), 1.7167, 1.7167)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3255, 10000093, CAST(N'2015-11-10 00:00:00.000' AS DateTime), 1.7027, 1.7027)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3256, 10000103, CAST(N'2015-11-10 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3257, 10000133, CAST(N'2015-11-10 00:00:00.000' AS DateTime), 1.248, 1.248)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3258, 10000133, CAST(N'2015-11-09 00:00:00.000' AS DateTime), 1.2476, 1.2476)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3259, 10000123, CAST(N'2015-11-09 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3260, 10000103, CAST(N'2015-11-09 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3261, 10000093, CAST(N'2015-11-09 00:00:00.000' AS DateTime), 1.7021, 1.7021)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3262, 10000083, CAST(N'2015-11-09 00:00:00.000' AS DateTime), 1.7161, 1.7161)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3263, 10000073, CAST(N'2015-11-09 00:00:00.000' AS DateTime), 1.6499, 1.6499)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3264, 1, CAST(N'2015-11-09 00:00:00.000' AS DateTime), 2.4748, 2.4748)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3265, 10000010, CAST(N'2015-11-09 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3266, 10000053, CAST(N'2015-11-09 00:00:00.000' AS DateTime), 2.0323, 2.0323)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3267, 10000053, CAST(N'2015-11-08 00:00:00.000' AS DateTime), 2.0316, 2.0316)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3268, 10000010, CAST(N'2015-11-08 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3269, 1, CAST(N'2015-11-08 00:00:00.000' AS DateTime), 2.4724, 2.4724)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3270, 10000073, CAST(N'2015-11-08 00:00:00.000' AS DateTime), 1.6493, 1.6493)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3271, 10000083, CAST(N'2015-11-08 00:00:00.000' AS DateTime), 1.7155, 1.7155)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3272, 10000093, CAST(N'2015-11-08 00:00:00.000' AS DateTime), 1.7015, 1.7015)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3273, 10000103, CAST(N'2015-11-08 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3274, 10000133, CAST(N'2015-11-08 00:00:00.000' AS DateTime), 1.2471, 1.2471)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3275, 10000133, CAST(N'2015-11-07 00:00:00.000' AS DateTime), 1.2467, 1.2467)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3276, 10000103, CAST(N'2015-11-07 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3277, 10000093, CAST(N'2015-11-07 00:00:00.000' AS DateTime), 1.7009, 1.7009)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3278, 10000083, CAST(N'2015-11-07 00:00:00.000' AS DateTime), 1.7149, 1.7149)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3279, 10000073, CAST(N'2015-11-07 00:00:00.000' AS DateTime), 1.6488, 1.6488)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3280, 1, CAST(N'2015-11-07 00:00:00.000' AS DateTime), 2.4717, 2.4717)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3281, 10000053, CAST(N'2015-11-07 00:00:00.000' AS DateTime), 2.031, 2.031)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3282, 10000053, CAST(N'2015-11-06 00:00:00.000' AS DateTime), 2.0303, 2.0303)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3283, 1, CAST(N'2015-11-06 00:00:00.000' AS DateTime), 2.4711, 2.4711)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3284, 10000073, CAST(N'2015-11-06 00:00:00.000' AS DateTime), 1.6482, 1.6482)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3285, 10000083, CAST(N'2015-11-06 00:00:00.000' AS DateTime), 1.7144, 1.7144)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3286, 10000093, CAST(N'2015-11-06 00:00:00.000' AS DateTime), 1.7003, 1.7003)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3287, 10000103, CAST(N'2015-11-06 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3288, 10000133, CAST(N'2015-11-06 00:00:00.000' AS DateTime), 1.2463, 1.2463)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3289, 10000133, CAST(N'2015-11-05 00:00:00.000' AS DateTime), 1.2459, 1.2459)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3290, 10000103, CAST(N'2015-11-05 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3291, 10000093, CAST(N'2015-11-05 00:00:00.000' AS DateTime), 1.6998, 1.6998)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3292, 10000083, CAST(N'2015-11-05 00:00:00.000' AS DateTime), 1.7138, 1.7138)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3293, 10000073, CAST(N'2015-11-05 00:00:00.000' AS DateTime), 1.6477, 1.6477)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3294, 1, CAST(N'2015-11-05 00:00:00.000' AS DateTime), 2.4674, 2.4674)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3295, 10000053, CAST(N'2015-11-05 00:00:00.000' AS DateTime), 2.0296, 2.0296)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3296, 10000053, CAST(N'2015-11-04 00:00:00.000' AS DateTime), 2.029, 2.029)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3297, 10000010, CAST(N'2015-11-04 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3298, 1, CAST(N'2015-11-04 00:00:00.000' AS DateTime), 2.4645, 2.4645)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3299, 10000073, CAST(N'2015-11-04 00:00:00.000' AS DateTime), 1.6471, 1.6471)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3300, 10000083, CAST(N'2015-11-04 00:00:00.000' AS DateTime), 1.7133, 1.7133)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3301, 10000093, CAST(N'2015-11-04 00:00:00.000' AS DateTime), 1.6992, 1.6992)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3302, 10000103, CAST(N'2015-11-04 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3303, 10000133, CAST(N'2015-11-04 00:00:00.000' AS DateTime), 1.2455, 1.2455)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3304, 10000133, CAST(N'2015-11-03 00:00:00.000' AS DateTime), 1.2451, 1.2451)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3305, 10000103, CAST(N'2015-11-03 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3306, 10000093, CAST(N'2015-11-03 00:00:00.000' AS DateTime), 1.6986, 1.6986)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3307, 10000083, CAST(N'2015-11-03 00:00:00.000' AS DateTime), 1.7128, 1.7128)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3308, 10000073, CAST(N'2015-11-03 00:00:00.000' AS DateTime), 1.6466, 1.6466)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3309, 1, CAST(N'2015-11-03 00:00:00.000' AS DateTime), 2.4623, 2.4623)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3310, 10000053, CAST(N'2015-11-03 00:00:00.000' AS DateTime), 2.028, 2.028)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3311, 10000053, CAST(N'2015-11-02 00:00:00.000' AS DateTime), 2.0273, 2.0273)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3312, 1, CAST(N'2015-11-02 00:00:00.000' AS DateTime), 2.4626, 2.4626)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3313, 10000073, CAST(N'2015-11-02 00:00:00.000' AS DateTime), 1.646, 1.646)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3314, 10000083, CAST(N'2015-11-02 00:00:00.000' AS DateTime), 1.7123, 1.7123)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3315, 10000093, CAST(N'2015-11-02 00:00:00.000' AS DateTime), 1.6982, 1.6982)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3316, 10000103, CAST(N'2015-11-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3317, 10000133, CAST(N'2015-11-02 00:00:00.000' AS DateTime), 1.2447, 1.2447)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3318, 10000133, CAST(N'2015-11-01 00:00:00.000' AS DateTime), 1.2443, 1.2443)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3319, 10000103, CAST(N'2015-11-01 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3320, 10000093, CAST(N'2015-11-01 00:00:00.000' AS DateTime), 1.6976, 1.6976)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3321, 10000083, CAST(N'2015-11-01 00:00:00.000' AS DateTime), 1.7117, 1.7117)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3322, 10000073, CAST(N'2015-11-01 00:00:00.000' AS DateTime), 1.6455, 1.6455)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3323, 1, CAST(N'2015-11-01 00:00:00.000' AS DateTime), 2.462, 2.462)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3324, 10000053, CAST(N'2015-11-01 00:00:00.000' AS DateTime), 2.0267, 2.0267)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3325, 10000053, CAST(N'2015-10-31 00:00:00.000' AS DateTime), 2.026, 2.026)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3326, 10000010, CAST(N'2015-10-31 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3327, 1, CAST(N'2015-10-31 00:00:00.000' AS DateTime), 2.4613, 2.4613)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3328, 10000073, CAST(N'2015-10-31 00:00:00.000' AS DateTime), 1.645, 1.645)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3329, 10000083, CAST(N'2015-10-31 00:00:00.000' AS DateTime), 1.7111, 1.7111)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3330, 10000093, CAST(N'2015-10-31 00:00:00.000' AS DateTime), 1.697, 1.697)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3331, 10000103, CAST(N'2015-10-31 00:00:00.000' AS DateTime), 0, 0)
GO
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3332, 10000133, CAST(N'2015-10-31 00:00:00.000' AS DateTime), 1.2438, 1.2438)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3333, 10000123, CAST(N'2015-10-31 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3334, 10000133, CAST(N'2015-10-30 00:00:00.000' AS DateTime), 1.2434, 1.2434)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3335, 10000103, CAST(N'2015-10-30 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3336, 10000093, CAST(N'2015-10-30 00:00:00.000' AS DateTime), 1.6964, 1.6964)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3337, 10000083, CAST(N'2015-10-30 00:00:00.000' AS DateTime), 1.7105, 1.7105)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3338, 10000073, CAST(N'2015-10-30 00:00:00.000' AS DateTime), 1.6444, 1.6444)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3339, 1, CAST(N'2015-10-30 00:00:00.000' AS DateTime), 2.4607, 2.4607)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3340, 10000010, CAST(N'2015-10-30 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3341, 10000053, CAST(N'2015-10-30 00:00:00.000' AS DateTime), 2.0253, 2.0253)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3342, 10000053, CAST(N'2015-10-29 00:00:00.000' AS DateTime), 2.0252, 2.0252)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3343, 10000010, CAST(N'2015-10-29 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3344, 1, CAST(N'2015-10-29 00:00:00.000' AS DateTime), 2.4586, 2.4586)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3345, 10000073, CAST(N'2015-10-29 00:00:00.000' AS DateTime), 1.6437, 1.6437)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3346, 10000083, CAST(N'2015-10-29 00:00:00.000' AS DateTime), 1.7095, 1.7095)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3347, 10000093, CAST(N'2015-10-29 00:00:00.000' AS DateTime), 1.6954, 1.6954)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3348, 10000103, CAST(N'2015-10-29 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3349, 10000133, CAST(N'2015-10-29 00:00:00.000' AS DateTime), 1.2408, 1.2408)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3350, 10000133, CAST(N'2015-10-28 00:00:00.000' AS DateTime), 1.2404, 1.2404)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3351, 10000123, CAST(N'2015-10-28 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3352, 10000103, CAST(N'2015-10-28 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3353, 10000093, CAST(N'2015-10-28 00:00:00.000' AS DateTime), 1.6949, 1.6949)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3354, 10000083, CAST(N'2015-10-28 00:00:00.000' AS DateTime), 1.7089, 1.7089)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3355, 10000073, CAST(N'2015-10-28 00:00:00.000' AS DateTime), 1.6432, 1.6432)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3356, 1, CAST(N'2015-10-28 00:00:00.000' AS DateTime), 2.4626, 2.4626)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3357, 10000010, CAST(N'2015-10-28 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3358, 10000053, CAST(N'2015-10-28 00:00:00.000' AS DateTime), 2.0252, 2.0252)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3359, 10000053, CAST(N'2015-10-27 00:00:00.000' AS DateTime), 2.0245, 2.0245)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3360, 10000010, CAST(N'2015-10-27 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3361, 1, CAST(N'2015-10-27 00:00:00.000' AS DateTime), 2.4642, 2.4642)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3362, 10000073, CAST(N'2015-10-27 00:00:00.000' AS DateTime), 1.6426, 1.6426)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3363, 10000083, CAST(N'2015-10-27 00:00:00.000' AS DateTime), 1.7083, 1.7083)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3364, 10000093, CAST(N'2015-10-27 00:00:00.000' AS DateTime), 1.6945, 1.6945)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3365, 10000103, CAST(N'2015-10-27 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3366, 10000133, CAST(N'2015-10-27 00:00:00.000' AS DateTime), 1.24, 1.24)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3367, 10000133, CAST(N'2015-10-26 00:00:00.000' AS DateTime), 1.2395, 1.2395)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3368, 10000103, CAST(N'2015-10-26 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3369, 10000093, CAST(N'2015-10-26 00:00:00.000' AS DateTime), 1.6939, 1.6939)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3370, 10000083, CAST(N'2015-10-26 00:00:00.000' AS DateTime), 1.7077, 1.7077)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3371, 10000073, CAST(N'2015-10-26 00:00:00.000' AS DateTime), 1.6421, 1.6421)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3372, 1, CAST(N'2015-10-26 00:00:00.000' AS DateTime), 2.4658, 2.4658)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3373, 10000010, CAST(N'2015-10-26 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3374, 10000053, CAST(N'2015-10-26 00:00:00.000' AS DateTime), 2.0238, 2.0238)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3375, 10000053, CAST(N'2015-10-25 00:00:00.000' AS DateTime), 2.0232, 2.0232)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3376, 10000010, CAST(N'2015-10-25 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3377, 1, CAST(N'2015-10-25 00:00:00.000' AS DateTime), 2.4658, 2.4658)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3378, 10000073, CAST(N'2015-10-25 00:00:00.000' AS DateTime), 1.6417, 1.6417)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3379, 10000083, CAST(N'2015-10-25 00:00:00.000' AS DateTime), 1.7072, 1.7072)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3380, 10000093, CAST(N'2015-10-25 00:00:00.000' AS DateTime), 1.6933, 1.6933)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3381, 10000103, CAST(N'2015-10-25 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3382, 10000133, CAST(N'2015-10-25 00:00:00.000' AS DateTime), 1.2391, 1.2391)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3383, 10000133, CAST(N'2015-10-24 00:00:00.000' AS DateTime), 1.2387, 1.2387)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3384, 10000103, CAST(N'2015-10-24 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3385, 10000093, CAST(N'2015-10-24 00:00:00.000' AS DateTime), 1.6927, 1.6927)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3386, 10000083, CAST(N'2015-10-24 00:00:00.000' AS DateTime), 1.7066, 1.7066)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3387, 10000073, CAST(N'2015-10-24 00:00:00.000' AS DateTime), 1.6411, 1.6411)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3388, 1, CAST(N'2015-10-24 00:00:00.000' AS DateTime), 2.4652, 2.4652)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3389, 10000053, CAST(N'2015-10-24 00:00:00.000' AS DateTime), 2.0225, 2.0225)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3390, 10000053, CAST(N'2015-10-23 00:00:00.000' AS DateTime), 2.0219, 2.0219)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3391, 10000010, CAST(N'2015-10-23 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3392, 1, CAST(N'2015-10-23 00:00:00.000' AS DateTime), 2.4645, 2.4645)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3393, 10000073, CAST(N'2015-10-23 00:00:00.000' AS DateTime), 1.6406, 1.6406)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3394, 10000083, CAST(N'2015-10-23 00:00:00.000' AS DateTime), 1.706, 1.706)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3395, 10000093, CAST(N'2015-10-23 00:00:00.000' AS DateTime), 1.6921, 1.6921)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3396, 10000103, CAST(N'2015-10-23 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3397, 10000133, CAST(N'2015-10-23 00:00:00.000' AS DateTime), 1.2383, 1.2383)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3398, 10000133, CAST(N'2015-10-22 00:00:00.000' AS DateTime), 1.2379, 1.2379)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3399, 10000103, CAST(N'2015-10-22 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3400, 10000093, CAST(N'2015-10-22 00:00:00.000' AS DateTime), 1.6915, 1.6915)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3401, 10000083, CAST(N'2015-10-22 00:00:00.000' AS DateTime), 1.7053, 1.7053)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3402, 10000073, CAST(N'2015-10-22 00:00:00.000' AS DateTime), 1.64, 1.64)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3403, 1, CAST(N'2015-10-22 00:00:00.000' AS DateTime), 2.4637, 2.4637)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3404, 10000010, CAST(N'2015-10-22 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3405, 10000053, CAST(N'2015-10-22 00:00:00.000' AS DateTime), 2.0212, 2.0212)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3406, 10000053, CAST(N'2015-10-21 00:00:00.000' AS DateTime), 2.0206, 2.0206)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3407, 10000010, CAST(N'2015-10-21 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3408, 1, CAST(N'2015-10-21 00:00:00.000' AS DateTime), 2.4637, 2.4637)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3409, 10000073, CAST(N'2015-10-21 00:00:00.000' AS DateTime), 1.6395, 1.6395)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3410, 10000083, CAST(N'2015-10-21 00:00:00.000' AS DateTime), 1.7047, 1.7047)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3411, 10000093, CAST(N'2015-10-21 00:00:00.000' AS DateTime), 1.6909, 1.6909)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3412, 10000103, CAST(N'2015-10-21 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3413, 10000133, CAST(N'2015-10-21 00:00:00.000' AS DateTime), 1.2375, 1.2375)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3414, 10000133, CAST(N'2015-10-20 00:00:00.000' AS DateTime), 1.2371, 1.2371)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3415, 10000103, CAST(N'2015-10-20 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3416, 10000093, CAST(N'2015-10-20 00:00:00.000' AS DateTime), 1.6903, 1.6903)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3417, 10000083, CAST(N'2015-10-20 00:00:00.000' AS DateTime), 1.7041, 1.7041)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3418, 10000073, CAST(N'2015-10-20 00:00:00.000' AS DateTime), 1.639, 1.639)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3419, 1, CAST(N'2015-10-20 00:00:00.000' AS DateTime), 2.4625, 2.4625)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3420, 10000010, CAST(N'2015-10-20 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3421, 10000053, CAST(N'2015-10-20 00:00:00.000' AS DateTime), 2.0199, 2.0199)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3422, 10000053, CAST(N'2015-10-19 00:00:00.000' AS DateTime), 2.0193, 2.0193)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3423, 10000010, CAST(N'2015-10-19 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3424, 1, CAST(N'2015-10-19 00:00:00.000' AS DateTime), 2.4617, 2.4617)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3425, 10000073, CAST(N'2015-10-19 00:00:00.000' AS DateTime), 1.6386, 1.6386)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3426, 10000083, CAST(N'2015-10-19 00:00:00.000' AS DateTime), 1.7035, 1.7035)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3427, 10000093, CAST(N'2015-10-19 00:00:00.000' AS DateTime), 1.6897, 1.6897)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3428, 10000103, CAST(N'2015-10-19 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3429, 10000133, CAST(N'2015-10-19 00:00:00.000' AS DateTime), 1.2367, 1.2367)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3430, 10000133, CAST(N'2015-10-18 00:00:00.000' AS DateTime), 1.2363, 1.2363)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3431, 10000103, CAST(N'2015-10-18 00:00:00.000' AS DateTime), 0, 0)
GO
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3432, 10000093, CAST(N'2015-10-18 00:00:00.000' AS DateTime), 1.6891, 1.6891)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3433, 10000083, CAST(N'2015-10-18 00:00:00.000' AS DateTime), 1.7029, 1.7029)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3434, 10000073, CAST(N'2015-10-18 00:00:00.000' AS DateTime), 1.638, 1.638)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3435, 1, CAST(N'2015-10-18 00:00:00.000' AS DateTime), 2.4582, 2.4582)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3436, 10000053, CAST(N'2015-10-18 00:00:00.000' AS DateTime), 2.0189, 2.0189)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3437, 10000053, CAST(N'2015-10-17 00:00:00.000' AS DateTime), 2.0182, 2.0182)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3438, 1, CAST(N'2015-10-17 00:00:00.000' AS DateTime), 2.4576, 2.4576)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3439, 10000073, CAST(N'2015-10-17 00:00:00.000' AS DateTime), 1.6374, 1.6374)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3440, 10000083, CAST(N'2015-10-17 00:00:00.000' AS DateTime), 1.7024, 1.7024)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3441, 10000093, CAST(N'2015-10-17 00:00:00.000' AS DateTime), 1.6884, 1.6884)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3442, 10000103, CAST(N'2015-10-17 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3443, 10000133, CAST(N'2015-10-17 00:00:00.000' AS DateTime), 1.2359, 1.2359)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3444, 10000133, CAST(N'2015-10-16 00:00:00.000' AS DateTime), 1.2355, 1.2355)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3445, 10000103, CAST(N'2015-10-16 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3446, 10000093, CAST(N'2015-10-16 00:00:00.000' AS DateTime), 1.6878, 1.6878)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3447, 10000083, CAST(N'2015-10-16 00:00:00.000' AS DateTime), 1.7019, 1.7019)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3448, 10000073, CAST(N'2015-10-16 00:00:00.000' AS DateTime), 1.6369, 1.6369)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3449, 1, CAST(N'2015-10-16 00:00:00.000' AS DateTime), 2.4569, 2.4569)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3450, 10000053, CAST(N'2015-10-16 00:00:00.000' AS DateTime), 2.0175, 2.0175)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3451, 10000010, CAST(N'2015-10-16 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3452, 10000010, CAST(N'2015-10-15 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3453, 10000053, CAST(N'2015-10-15 00:00:00.000' AS DateTime), 2.0169, 2.0169)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3454, 1, CAST(N'2015-10-15 00:00:00.000' AS DateTime), 2.4534, 2.4534)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3455, 10000073, CAST(N'2015-10-15 00:00:00.000' AS DateTime), 1.6363, 1.6363)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3456, 10000083, CAST(N'2015-10-15 00:00:00.000' AS DateTime), 1.7014, 1.7014)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3457, 10000093, CAST(N'2015-10-15 00:00:00.000' AS DateTime), 1.6872, 1.6872)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3458, 10000103, CAST(N'2015-10-15 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3459, 10000133, CAST(N'2015-10-15 00:00:00.000' AS DateTime), 1.235, 1.235)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3460, 10000133, CAST(N'2015-10-14 00:00:00.000' AS DateTime), 1.2346, 1.2346)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3461, 10000103, CAST(N'2015-10-14 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3462, 10000093, CAST(N'2015-10-14 00:00:00.000' AS DateTime), 1.6864, 1.6864)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3463, 10000083, CAST(N'2015-10-14 00:00:00.000' AS DateTime), 1.7009, 1.7009)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3464, 10000073, CAST(N'2015-10-14 00:00:00.000' AS DateTime), 1.6357, 1.6357)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3465, 1, CAST(N'2015-10-14 00:00:00.000' AS DateTime), 2.4514, 2.4514)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3466, 10000053, CAST(N'2015-10-14 00:00:00.000' AS DateTime), 2.0162, 2.0162)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3467, 10000053, CAST(N'2015-10-13 00:00:00.000' AS DateTime), 2.0156, 2.0156)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3468, 10000010, CAST(N'2015-10-13 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3469, 1, CAST(N'2015-10-13 00:00:00.000' AS DateTime), 2.4542, 2.4542)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3470, 10000073, CAST(N'2015-10-13 00:00:00.000' AS DateTime), 1.6352, 1.6352)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3471, 10000083, CAST(N'2015-10-13 00:00:00.000' AS DateTime), 1.7003, 1.7003)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3472, 10000093, CAST(N'2015-10-13 00:00:00.000' AS DateTime), 1.6858, 1.6858)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3473, 10000103, CAST(N'2015-10-13 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3474, 10000133, CAST(N'2015-10-13 00:00:00.000' AS DateTime), 1.2342, 1.2342)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3475, 10000123, CAST(N'2015-10-13 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3476, 10000133, CAST(N'2015-10-12 00:00:00.000' AS DateTime), 1.2338, 1.2338)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3477, 10000103, CAST(N'2015-10-12 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3478, 10000093, CAST(N'2015-10-12 00:00:00.000' AS DateTime), 1.6851, 1.6851)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3479, 10000083, CAST(N'2015-10-12 00:00:00.000' AS DateTime), 1.6997, 1.6997)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3480, 10000073, CAST(N'2015-10-12 00:00:00.000' AS DateTime), 1.641, 1.641)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3481, 1, CAST(N'2015-10-12 00:00:00.000' AS DateTime), 2.4545, 2.4545)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3482, 10000053, CAST(N'2015-10-12 00:00:00.000' AS DateTime), 2.0149, 2.0149)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3483, 10000053, CAST(N'2015-10-11 00:00:00.000' AS DateTime), 2.0143, 2.0143)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3484, 1, CAST(N'2015-10-11 00:00:00.000' AS DateTime), 2.452, 2.452)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3485, 10000073, CAST(N'2015-10-11 00:00:00.000' AS DateTime), 1.6404, 1.6404)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3486, 10000083, CAST(N'2015-10-11 00:00:00.000' AS DateTime), 1.6991, 1.6991)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3487, 10000093, CAST(N'2015-10-11 00:00:00.000' AS DateTime), 1.6844, 1.6844)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3488, 10000103, CAST(N'2015-10-11 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3489, 10000133, CAST(N'2015-10-11 00:00:00.000' AS DateTime), 1.2336, 1.2336)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3490, 10000133, CAST(N'2015-10-10 00:00:00.000' AS DateTime), 1.2332, 1.2332)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3491, 10000103, CAST(N'2015-10-10 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3492, 10000093, CAST(N'2015-10-10 00:00:00.000' AS DateTime), 1.6838, 1.6838)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3493, 10000083, CAST(N'2015-10-10 00:00:00.000' AS DateTime), 1.6984, 1.6984)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3494, 10000073, CAST(N'2015-10-10 00:00:00.000' AS DateTime), 1.6398, 1.6398)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3495, 1, CAST(N'2015-10-10 00:00:00.000' AS DateTime), 2.4514, 2.4514)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3496, 10000053, CAST(N'2015-10-10 00:00:00.000' AS DateTime), 2.0136, 2.0136)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3497, 10000053, CAST(N'2015-10-09 00:00:00.000' AS DateTime), 2.0129, 2.0129)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3498, 1, CAST(N'2015-10-09 00:00:00.000' AS DateTime), 2.4507, 2.4507)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3499, 10000073, CAST(N'2015-10-09 00:00:00.000' AS DateTime), 1.6393, 1.6393)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3500, 10000083, CAST(N'2015-10-09 00:00:00.000' AS DateTime), 1.6978, 1.6978)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3501, 10000093, CAST(N'2015-10-09 00:00:00.000' AS DateTime), 1.6832, 1.6832)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3502, 10000103, CAST(N'2015-10-09 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3503, 10000133, CAST(N'2015-10-09 00:00:00.000' AS DateTime), 1.2328, 1.2328)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3504, 10000123, CAST(N'2015-10-09 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3505, 10000133, CAST(N'2015-10-08 00:00:00.000' AS DateTime), 1.2324, 1.2324)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3506, 10000103, CAST(N'2015-10-08 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3507, 10000093, CAST(N'2015-10-08 00:00:00.000' AS DateTime), 1.6826, 1.6826)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3508, 10000083, CAST(N'2015-10-08 00:00:00.000' AS DateTime), 1.6972, 1.6972)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3509, 10000073, CAST(N'2015-10-08 00:00:00.000' AS DateTime), 1.6387, 1.6387)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3510, 1, CAST(N'2015-10-08 00:00:00.000' AS DateTime), 2.4496, 2.4496)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3511, 10000053, CAST(N'2015-10-08 00:00:00.000' AS DateTime), 2.0123, 2.0123)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3512, 10000010, CAST(N'2015-10-08 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3513, 10000010, CAST(N'2015-10-07 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3514, 10000053, CAST(N'2015-10-07 00:00:00.000' AS DateTime), 2.0116, 2.0116)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3515, 1, CAST(N'2015-10-07 00:00:00.000' AS DateTime), 2.4494, 2.4494)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3516, 10000073, CAST(N'2015-10-07 00:00:00.000' AS DateTime), 1.6381, 1.6381)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3517, 10000083, CAST(N'2015-10-07 00:00:00.000' AS DateTime), 1.6966, 1.6966)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3518, 10000093, CAST(N'2015-10-07 00:00:00.000' AS DateTime), 1.682, 1.682)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3519, 10000103, CAST(N'2015-10-07 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3520, 10000133, CAST(N'2015-10-07 00:00:00.000' AS DateTime), 1.232, 1.232)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3521, 10000133, CAST(N'2015-10-06 00:00:00.000' AS DateTime), 1.2316, 1.2316)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3522, 10000103, CAST(N'2015-10-06 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3523, 10000093, CAST(N'2015-10-06 00:00:00.000' AS DateTime), 1.6814, 1.6814)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3524, 10000083, CAST(N'2015-10-06 00:00:00.000' AS DateTime), 1.6959, 1.6959)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3525, 10000073, CAST(N'2015-10-06 00:00:00.000' AS DateTime), 1.6376, 1.6376)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3526, 1, CAST(N'2015-10-06 00:00:00.000' AS DateTime), 2.4516, 2.4516)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3527, 10000053, CAST(N'2015-10-06 00:00:00.000' AS DateTime), 2.011, 2.011)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3528, 10000010, CAST(N'2015-10-06 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3529, 10000010, CAST(N'2015-10-05 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3530, 10000053, CAST(N'2015-10-05 00:00:00.000' AS DateTime), 2.0103, 2.0103)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3531, 1, CAST(N'2015-10-05 00:00:00.000' AS DateTime), 2.4533, 2.4533)
GO
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3532, 10000073, CAST(N'2015-10-05 00:00:00.000' AS DateTime), 1.637, 1.637)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3533, 10000083, CAST(N'2015-10-05 00:00:00.000' AS DateTime), 1.6954, 1.6954)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3534, 10000093, CAST(N'2015-10-05 00:00:00.000' AS DateTime), 1.6808, 1.6808)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3535, 10000103, CAST(N'2015-10-05 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3536, 10000133, CAST(N'2015-10-05 00:00:00.000' AS DateTime), 1.2311, 1.2311)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3537, 10000133, CAST(N'2015-10-04 00:00:00.000' AS DateTime), 1.2307, 1.2307)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3538, 10000103, CAST(N'2015-10-04 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3539, 10000093, CAST(N'2015-10-04 00:00:00.000' AS DateTime), 1.6802, 1.6802)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3540, 10000083, CAST(N'2015-10-04 00:00:00.000' AS DateTime), 1.6949, 1.6949)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3541, 10000073, CAST(N'2015-10-04 00:00:00.000' AS DateTime), 1.6364, 1.6364)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3542, 1, CAST(N'2015-10-04 00:00:00.000' AS DateTime), 2.4546, 2.4546)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3543, 10000053, CAST(N'2015-10-04 00:00:00.000' AS DateTime), 2.0097, 2.0097)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3544, 10000010, CAST(N'2015-10-04 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3545, 10000053, CAST(N'2015-10-03 00:00:00.000' AS DateTime), 2.009, 2.009)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3546, 1, CAST(N'2015-10-03 00:00:00.000' AS DateTime), 2.4539, 2.4539)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3547, 10000073, CAST(N'2015-10-03 00:00:00.000' AS DateTime), 1.6359, 1.6359)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3548, 10000083, CAST(N'2015-10-03 00:00:00.000' AS DateTime), 1.6942, 1.6942)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3549, 10000093, CAST(N'2015-10-03 00:00:00.000' AS DateTime), 1.6796, 1.6796)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3550, 10000103, CAST(N'2015-10-03 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3551, 10000133, CAST(N'2015-10-03 00:00:00.000' AS DateTime), 1.2303, 1.2303)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3552, 10000133, CAST(N'2015-10-02 00:00:00.000' AS DateTime), 1.2299, 1.2299)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3553, 10000103, CAST(N'2015-10-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3554, 10000093, CAST(N'2015-10-02 00:00:00.000' AS DateTime), 1.679, 1.679)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3555, 10000083, CAST(N'2015-10-02 00:00:00.000' AS DateTime), 1.6936, 1.6936)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3556, 10000073, CAST(N'2015-10-02 00:00:00.000' AS DateTime), 1.6353, 1.6353)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3557, 1, CAST(N'2015-10-02 00:00:00.000' AS DateTime), 2.4533, 2.4533)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3558, 10000053, CAST(N'2015-10-02 00:00:00.000' AS DateTime), 2.0084, 2.0084)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3559, 10000010, CAST(N'2015-10-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3560, 10000053, CAST(N'2015-10-01 00:00:00.000' AS DateTime), 2.0077, 2.0077)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3561, 1, CAST(N'2015-10-01 00:00:00.000' AS DateTime), 2.456, 2.456)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3562, 10000073, CAST(N'2015-10-01 00:00:00.000' AS DateTime), 1.6347, 1.6347)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3563, 10000083, CAST(N'2015-10-01 00:00:00.000' AS DateTime), 1.693, 1.693)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3564, 10000093, CAST(N'2015-10-01 00:00:00.000' AS DateTime), 1.6784, 1.6784)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3565, 10000103, CAST(N'2015-10-01 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3566, 10000133, CAST(N'2015-10-01 00:00:00.000' AS DateTime), 1.2295, 1.2295)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3567, 10000133, CAST(N'2015-09-30 00:00:00.000' AS DateTime), 1.2291, 1.2291)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3568, 10000123, CAST(N'2015-09-30 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3569, 10000103, CAST(N'2015-09-30 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3570, 10000093, CAST(N'2015-09-30 00:00:00.000' AS DateTime), 1.6777, 1.6777)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3571, 10000083, CAST(N'2015-09-30 00:00:00.000' AS DateTime), 1.6923, 1.6923)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3572, 10000073, CAST(N'2015-09-30 00:00:00.000' AS DateTime), 1.6342, 1.6342)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3573, 1, CAST(N'2015-09-30 00:00:00.000' AS DateTime), 2.4553, 2.4553)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3574, 10000053, CAST(N'2015-09-30 00:00:00.000' AS DateTime), 2.0071, 2.0071)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3575, 10000010, CAST(N'2015-09-30 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3576, 10000010, CAST(N'2015-09-29 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3577, 10000053, CAST(N'2015-09-29 00:00:00.000' AS DateTime), 2.0057, 2.0057)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3578, 1, CAST(N'2015-09-29 00:00:00.000' AS DateTime), 2.4554, 2.4554)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3579, 10000073, CAST(N'2015-09-29 00:00:00.000' AS DateTime), 1.6336, 1.6336)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3580, 10000083, CAST(N'2015-09-29 00:00:00.000' AS DateTime), 1.6913, 1.6913)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3581, 10000093, CAST(N'2015-09-29 00:00:00.000' AS DateTime), 1.6771, 1.6771)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3582, 10000103, CAST(N'2015-09-29 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3583, 10000133, CAST(N'2015-09-29 00:00:00.000' AS DateTime), 1.2286, 1.2286)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3584, 10000133, CAST(N'2015-09-28 00:00:00.000' AS DateTime), 1.2282, 1.2282)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3585, 10000103, CAST(N'2015-09-28 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3586, 10000093, CAST(N'2015-09-28 00:00:00.000' AS DateTime), 1.6765, 1.6765)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3587, 10000083, CAST(N'2015-09-28 00:00:00.000' AS DateTime), 1.6907, 1.6907)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3588, 10000073, CAST(N'2015-09-28 00:00:00.000' AS DateTime), 1.633, 1.633)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3589, 1, CAST(N'2015-09-28 00:00:00.000' AS DateTime), 2.4563, 2.4563)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3590, 10000053, CAST(N'2015-09-28 00:00:00.000' AS DateTime), 2.005, 2.005)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3591, 10000010, CAST(N'2015-09-28 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3592, 10000053, CAST(N'2015-09-27 00:00:00.000' AS DateTime), 2.0043, 2.0043)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3593, 1, CAST(N'2015-09-27 00:00:00.000' AS DateTime), 2.4542, 2.4542)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3594, 10000073, CAST(N'2015-09-27 00:00:00.000' AS DateTime), 1.6325, 1.6325)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3595, 10000083, CAST(N'2015-09-27 00:00:00.000' AS DateTime), 1.6901, 1.6901)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3596, 10000093, CAST(N'2015-09-27 00:00:00.000' AS DateTime), 1.6762, 1.6762)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3597, 10000103, CAST(N'2015-09-27 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3598, 10000133, CAST(N'2015-09-27 00:00:00.000' AS DateTime), 1.2278, 1.2278)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3599, 10000133, CAST(N'2015-09-26 00:00:00.000' AS DateTime), 1.2274, 1.2274)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3600, 10000103, CAST(N'2015-09-26 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3601, 10000093, CAST(N'2015-09-26 00:00:00.000' AS DateTime), 1.6756, 1.6756)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3602, 10000083, CAST(N'2015-09-26 00:00:00.000' AS DateTime), 1.6895, 1.6895)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3603, 10000073, CAST(N'2015-09-26 00:00:00.000' AS DateTime), 1.6319, 1.6319)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3604, 1, CAST(N'2015-09-26 00:00:00.000' AS DateTime), 2.4536, 2.4536)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3605, 10000053, CAST(N'2015-09-26 00:00:00.000' AS DateTime), 2.0037, 2.0037)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3606, 10000053, CAST(N'2015-09-25 00:00:00.000' AS DateTime), 2.003, 2.003)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3607, 1, CAST(N'2015-09-25 00:00:00.000' AS DateTime), 2.4529, 2.4529)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3608, 10000073, CAST(N'2015-09-25 00:00:00.000' AS DateTime), 1.6313, 1.6313)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3609, 10000083, CAST(N'2015-09-25 00:00:00.000' AS DateTime), 1.6889, 1.6889)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3610, 10000093, CAST(N'2015-09-25 00:00:00.000' AS DateTime), 1.675, 1.675)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3611, 10000103, CAST(N'2015-09-25 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3612, 10000133, CAST(N'2015-09-25 00:00:00.000' AS DateTime), 1.227, 1.227)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3613, 10000133, CAST(N'2015-09-24 00:00:00.000' AS DateTime), 1.2266, 1.2266)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3614, 10000103, CAST(N'2015-09-24 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3615, 10000093, CAST(N'2015-09-24 00:00:00.000' AS DateTime), 1.6744, 1.6744)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3616, 10000083, CAST(N'2015-09-24 00:00:00.000' AS DateTime), 1.6883, 1.6883)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3617, 10000073, CAST(N'2015-09-24 00:00:00.000' AS DateTime), 1.6308, 1.6308)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3618, 1, CAST(N'2015-09-24 00:00:00.000' AS DateTime), 2.4523, 2.4523)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3619, 10000053, CAST(N'2015-09-24 00:00:00.000' AS DateTime), 2.0024, 2.0024)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3620, 10000010, CAST(N'2015-09-24 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3621, 10000053, CAST(N'2015-09-23 00:00:00.000' AS DateTime), 2.0017, 2.0017)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3622, 1, CAST(N'2015-09-23 00:00:00.000' AS DateTime), 2.4517, 2.4517)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3623, 10000073, CAST(N'2015-09-23 00:00:00.000' AS DateTime), 1.6302, 1.6302)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3624, 10000083, CAST(N'2015-09-23 00:00:00.000' AS DateTime), 1.6878, 1.6878)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3625, 10000093, CAST(N'2015-09-23 00:00:00.000' AS DateTime), 1.6738, 1.6738)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3626, 10000103, CAST(N'2015-09-23 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3627, 10000133, CAST(N'2015-09-23 00:00:00.000' AS DateTime), 1.2261, 1.2261)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3628, 10000133, CAST(N'2015-09-22 00:00:00.000' AS DateTime), 1.2257, 1.2257)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3629, 10000103, CAST(N'2015-09-22 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3630, 10000093, CAST(N'2015-09-22 00:00:00.000' AS DateTime), 1.6732, 1.6732)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3631, 10000083, CAST(N'2015-09-22 00:00:00.000' AS DateTime), 1.6872, 1.6872)
GO
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3632, 10000073, CAST(N'2015-09-22 00:00:00.000' AS DateTime), 1.6297, 1.6297)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3633, 1, CAST(N'2015-09-22 00:00:00.000' AS DateTime), 2.451, 2.451)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3634, 10000053, CAST(N'2015-09-22 00:00:00.000' AS DateTime), 2.0011, 2.0011)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3635, 10000053, CAST(N'2015-09-21 00:00:00.000' AS DateTime), 2.0004, 2.0004)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3636, 10000010, CAST(N'2015-09-21 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3637, 1, CAST(N'2015-09-21 00:00:00.000' AS DateTime), 2.4493, 2.4493)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3638, 10000073, CAST(N'2015-09-21 00:00:00.000' AS DateTime), 1.6291, 1.6291)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3639, 10000083, CAST(N'2015-09-21 00:00:00.000' AS DateTime), 1.6866, 1.6866)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3640, 10000093, CAST(N'2015-09-21 00:00:00.000' AS DateTime), 1.6725, 1.6725)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3641, 10000103, CAST(N'2015-09-21 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3642, 10000133, CAST(N'2015-09-21 00:00:00.000' AS DateTime), 1.2253, 1.2253)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3643, 10000133, CAST(N'2015-09-20 00:00:00.000' AS DateTime), 1.2249, 1.2249)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3644, 10000103, CAST(N'2015-09-20 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3645, 10000093, CAST(N'2015-09-20 00:00:00.000' AS DateTime), 1.6716, 1.6716)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3646, 10000083, CAST(N'2015-09-20 00:00:00.000' AS DateTime), 1.686, 1.686)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3647, 10000073, CAST(N'2015-09-20 00:00:00.000' AS DateTime), 1.6285, 1.6285)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3648, 1, CAST(N'2015-09-20 00:00:00.000' AS DateTime), 2.4495, 2.4495)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3649, 10000010, CAST(N'2015-09-20 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3650, 10000053, CAST(N'2015-09-20 00:00:00.000' AS DateTime), 1.9997, 1.9997)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3651, 10000053, CAST(N'2015-09-19 00:00:00.000' AS DateTime), 1.9991, 1.9991)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3652, 1, CAST(N'2015-09-19 00:00:00.000' AS DateTime), 2.4488, 2.4488)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3653, 10000073, CAST(N'2015-09-19 00:00:00.000' AS DateTime), 1.628, 1.628)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3654, 10000083, CAST(N'2015-09-19 00:00:00.000' AS DateTime), 1.6854, 1.6854)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3655, 10000093, CAST(N'2015-09-19 00:00:00.000' AS DateTime), 1.6709, 1.6709)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3656, 10000103, CAST(N'2015-09-19 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3657, 10000133, CAST(N'2015-09-19 00:00:00.000' AS DateTime), 1.2245, 1.2245)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3658, 10000133, CAST(N'2015-09-18 00:00:00.000' AS DateTime), 1.2241, 1.2241)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3659, 10000103, CAST(N'2015-09-18 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3660, 10000093, CAST(N'2015-09-18 00:00:00.000' AS DateTime), 1.6703, 1.6703)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3661, 10000083, CAST(N'2015-09-18 00:00:00.000' AS DateTime), 1.6848, 1.6848)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3662, 10000073, CAST(N'2015-09-18 00:00:00.000' AS DateTime), 1.6274, 1.6274)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3663, 1, CAST(N'2015-09-18 00:00:00.000' AS DateTime), 2.4482, 2.4482)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3664, 10000053, CAST(N'2015-09-18 00:00:00.000' AS DateTime), 1.9984, 1.9984)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3665, 10000053, CAST(N'2015-09-17 00:00:00.000' AS DateTime), 1.9978, 1.9978)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3666, 1, CAST(N'2015-09-17 00:00:00.000' AS DateTime), 2.4479, 2.4479)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3667, 10000073, CAST(N'2015-09-17 00:00:00.000' AS DateTime), 1.6268, 1.6268)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3668, 10000083, CAST(N'2015-09-17 00:00:00.000' AS DateTime), 1.6842, 1.6842)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3669, 10000093, CAST(N'2015-09-17 00:00:00.000' AS DateTime), 1.6696, 1.6696)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3670, 10000103, CAST(N'2015-09-17 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3671, 10000133, CAST(N'2015-09-17 00:00:00.000' AS DateTime), 1.2236, 1.2236)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3672, 10000133, CAST(N'2015-09-16 00:00:00.000' AS DateTime), 1.2232, 1.2232)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3673, 10000103, CAST(N'2015-09-16 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3674, 10000093, CAST(N'2015-09-16 00:00:00.000' AS DateTime), 1.669, 1.669)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3675, 10000083, CAST(N'2015-09-16 00:00:00.000' AS DateTime), 1.6836, 1.6836)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3676, 10000073, CAST(N'2015-09-16 00:00:00.000' AS DateTime), 1.6263, 1.6263)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3677, 1, CAST(N'2015-09-16 00:00:00.000' AS DateTime), 2.4408, 2.4408)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3678, 10000053, CAST(N'2015-09-16 00:00:00.000' AS DateTime), 1.9955, 1.9955)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3679, 10000010, CAST(N'2015-09-16 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3680, 10000010, CAST(N'2015-09-15 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3681, 10000053, CAST(N'2015-09-15 00:00:00.000' AS DateTime), 1.9948, 1.9948)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3682, 1, CAST(N'2015-09-15 00:00:00.000' AS DateTime), 2.4397, 2.4397)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3683, 10000073, CAST(N'2015-09-15 00:00:00.000' AS DateTime), 1.6257, 1.6257)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3684, 10000083, CAST(N'2015-09-15 00:00:00.000' AS DateTime), 1.683, 1.683)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3685, 10000093, CAST(N'2015-09-15 00:00:00.000' AS DateTime), 1.6684, 1.6684)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3686, 10000103, CAST(N'2015-09-15 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3687, 10000133, CAST(N'2015-09-15 00:00:00.000' AS DateTime), 1.2228, 1.2228)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3688, 10000133, CAST(N'2015-09-14 00:00:00.000' AS DateTime), 1.2224, 1.2224)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3689, 10000103, CAST(N'2015-09-14 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3690, 10000093, CAST(N'2015-09-14 00:00:00.000' AS DateTime), 1.6677, 1.6677)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3691, 10000083, CAST(N'2015-09-14 00:00:00.000' AS DateTime), 1.6824, 1.6824)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3692, 10000073, CAST(N'2015-09-14 00:00:00.000' AS DateTime), 1.6251, 1.6251)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3693, 1, CAST(N'2015-09-14 00:00:00.000' AS DateTime), 2.4393, 2.4393)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3694, 10000053, CAST(N'2015-09-14 00:00:00.000' AS DateTime), 1.9942, 1.9942)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3695, 10000010, CAST(N'2015-09-14 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3696, 10000010, CAST(N'2015-09-13 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3697, 10000053, CAST(N'2015-09-13 00:00:00.000' AS DateTime), 1.9935, 1.9935)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3698, 1, CAST(N'2015-09-13 00:00:00.000' AS DateTime), 2.434, 2.434)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3699, 10000073, CAST(N'2015-09-13 00:00:00.000' AS DateTime), 1.6246, 1.6246)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3700, 10000083, CAST(N'2015-09-13 00:00:00.000' AS DateTime), 1.6818, 1.6818)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3701, 10000093, CAST(N'2015-09-13 00:00:00.000' AS DateTime), 1.6671, 1.6671)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3702, 10000103, CAST(N'2015-09-13 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3703, 10000133, CAST(N'2015-09-13 00:00:00.000' AS DateTime), 1.222, 1.222)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3704, 10000133, CAST(N'2015-09-12 00:00:00.000' AS DateTime), 1.2216, 1.2216)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3705, 10000103, CAST(N'2015-09-12 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3706, 10000093, CAST(N'2015-09-12 00:00:00.000' AS DateTime), 1.6665, 1.6665)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3707, 10000083, CAST(N'2015-09-12 00:00:00.000' AS DateTime), 1.6812, 1.6812)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3708, 10000073, CAST(N'2015-09-12 00:00:00.000' AS DateTime), 1.624, 1.624)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3709, 1, CAST(N'2015-09-12 00:00:00.000' AS DateTime), 2.4334, 2.4334)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3710, 10000053, CAST(N'2015-09-12 00:00:00.000' AS DateTime), 1.9929, 1.9929)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3711, 10000053, CAST(N'2015-09-11 00:00:00.000' AS DateTime), 1.9922, 1.9922)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3712, 1, CAST(N'2015-09-11 00:00:00.000' AS DateTime), 2.4327, 2.4327)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3713, 10000073, CAST(N'2015-09-11 00:00:00.000' AS DateTime), 1.6234, 1.6234)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3714, 10000083, CAST(N'2015-09-11 00:00:00.000' AS DateTime), 1.6806, 1.6806)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3715, 10000093, CAST(N'2015-09-11 00:00:00.000' AS DateTime), 1.6659, 1.6659)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3716, 10000103, CAST(N'2015-09-11 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3717, 10000133, CAST(N'2015-09-11 00:00:00.000' AS DateTime), 1.2211, 1.2211)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3718, 10000133, CAST(N'2015-09-10 00:00:00.000' AS DateTime), 1.2207, 1.2207)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3719, 10000103, CAST(N'2015-09-10 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3720, 10000093, CAST(N'2015-09-10 00:00:00.000' AS DateTime), 1.6653, 1.6653)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3721, 10000083, CAST(N'2015-09-10 00:00:00.000' AS DateTime), 1.68, 1.68)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3722, 10000073, CAST(N'2015-09-10 00:00:00.000' AS DateTime), 1.6229, 1.6229)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3723, 1, CAST(N'2015-09-10 00:00:00.000' AS DateTime), 2.4303, 2.4303)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3724, 10000053, CAST(N'2015-09-10 00:00:00.000' AS DateTime), 1.9915, 1.9915)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3725, 10000010, CAST(N'2015-09-10 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3726, 10000010, CAST(N'2015-09-09 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3727, 10000053, CAST(N'2015-09-09 00:00:00.000' AS DateTime), 1.9909, 1.9909)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3728, 1, CAST(N'2015-09-09 00:00:00.000' AS DateTime), 2.4286, 2.4286)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3729, 10000073, CAST(N'2015-09-09 00:00:00.000' AS DateTime), 1.6223, 1.6223)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3730, 10000083, CAST(N'2015-09-09 00:00:00.000' AS DateTime), 1.6794, 1.6794)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3731, 10000093, CAST(N'2015-09-09 00:00:00.000' AS DateTime), 1.6647, 1.6647)
GO
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3732, 10000103, CAST(N'2015-09-09 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3733, 10000133, CAST(N'2015-09-09 00:00:00.000' AS DateTime), 1.2203, 1.2203)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3734, 10000133, CAST(N'2015-09-08 00:00:00.000' AS DateTime), 1.2199, 1.2199)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3735, 10000103, CAST(N'2015-09-08 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3736, 10000093, CAST(N'2015-09-08 00:00:00.000' AS DateTime), 1.6641, 1.6641)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3737, 10000083, CAST(N'2015-09-08 00:00:00.000' AS DateTime), 1.6789, 1.6789)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3738, 10000073, CAST(N'2015-09-08 00:00:00.000' AS DateTime), 1.6217, 1.6217)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3739, 1, CAST(N'2015-09-08 00:00:00.000' AS DateTime), 2.4356, 2.4356)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3740, 10000053, CAST(N'2015-09-08 00:00:00.000' AS DateTime), 1.9903, 1.9903)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3741, 10000010, CAST(N'2015-09-08 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3742, 10000010, CAST(N'2015-09-07 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3743, 10000053, CAST(N'2015-09-07 00:00:00.000' AS DateTime), 1.9896, 1.9896)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3744, 1, CAST(N'2015-09-07 00:00:00.000' AS DateTime), 2.4339, 2.4339)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3745, 10000073, CAST(N'2015-09-07 00:00:00.000' AS DateTime), 1.6212, 1.6212)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3746, 10000083, CAST(N'2015-09-07 00:00:00.000' AS DateTime), 1.6782, 1.6782)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3747, 10000093, CAST(N'2015-09-07 00:00:00.000' AS DateTime), 1.6638, 1.6638)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3748, 10000103, CAST(N'2015-09-07 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3749, 10000133, CAST(N'2015-09-07 00:00:00.000' AS DateTime), 1.2195, 1.2195)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3750, 10000133, CAST(N'2015-09-06 00:00:00.000' AS DateTime), 1.2191, 1.2191)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3751, 10000103, CAST(N'2015-09-06 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3752, 10000093, CAST(N'2015-09-06 00:00:00.000' AS DateTime), 1.6629, 1.6629)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3753, 10000083, CAST(N'2015-09-06 00:00:00.000' AS DateTime), 1.6776, 1.6776)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3754, 10000073, CAST(N'2015-09-06 00:00:00.000' AS DateTime), 1.6206, 1.6206)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3755, 1, CAST(N'2015-09-06 00:00:00.000' AS DateTime), 2.4297, 2.4297)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3756, 10000053, CAST(N'2015-09-06 00:00:00.000' AS DateTime), 1.989, 1.989)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3757, 10000053, CAST(N'2015-09-05 00:00:00.000' AS DateTime), 1.9883, 1.9883)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3758, 1, CAST(N'2015-09-05 00:00:00.000' AS DateTime), 2.4291, 2.4291)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3759, 10000073, CAST(N'2015-09-05 00:00:00.000' AS DateTime), 1.62, 1.62)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3760, 10000083, CAST(N'2015-09-05 00:00:00.000' AS DateTime), 1.6769, 1.6769)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3761, 10000093, CAST(N'2015-09-05 00:00:00.000' AS DateTime), 1.6623, 1.6623)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3762, 10000103, CAST(N'2015-09-05 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3763, 10000133, CAST(N'2015-09-05 00:00:00.000' AS DateTime), 1.2186, 1.2186)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3764, 10000133, CAST(N'2015-09-04 00:00:00.000' AS DateTime), 1.2182, 1.2182)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3765, 10000103, CAST(N'2015-09-04 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3766, 10000093, CAST(N'2015-09-04 00:00:00.000' AS DateTime), 1.6617, 1.6617)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3767, 10000083, CAST(N'2015-09-04 00:00:00.000' AS DateTime), 1.6763, 1.6763)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3768, 10000073, CAST(N'2015-09-04 00:00:00.000' AS DateTime), 1.6195, 1.6195)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3769, 1, CAST(N'2015-09-04 00:00:00.000' AS DateTime), 2.4285, 2.4285)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3770, 10000053, CAST(N'2015-09-04 00:00:00.000' AS DateTime), 1.9877, 1.9877)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3771, 10000053, CAST(N'2015-09-03 00:00:00.000' AS DateTime), 1.987, 1.987)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3772, 1, CAST(N'2015-09-03 00:00:00.000' AS DateTime), 2.4252, 2.4252)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3773, 10000073, CAST(N'2015-09-03 00:00:00.000' AS DateTime), 1.6189, 1.6189)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3774, 10000083, CAST(N'2015-09-03 00:00:00.000' AS DateTime), 1.6757, 1.6757)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3775, 10000093, CAST(N'2015-09-03 00:00:00.000' AS DateTime), 1.6611, 1.6611)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3776, 10000103, CAST(N'2015-09-03 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3777, 10000133, CAST(N'2015-09-03 00:00:00.000' AS DateTime), 1.2178, 1.2178)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3778, 10000133, CAST(N'2015-09-02 00:00:00.000' AS DateTime), 1.2174, 1.2174)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3779, 10000103, CAST(N'2015-09-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3780, 10000093, CAST(N'2015-09-02 00:00:00.000' AS DateTime), 1.6605, 1.6605)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3781, 10000083, CAST(N'2015-09-02 00:00:00.000' AS DateTime), 1.675, 1.675)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3782, 10000073, CAST(N'2015-09-02 00:00:00.000' AS DateTime), 1.6183, 1.6183)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3783, 1, CAST(N'2015-09-02 00:00:00.000' AS DateTime), 2.4265, 2.4265)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3784, 10000053, CAST(N'2015-09-02 00:00:00.000' AS DateTime), 1.9864, 1.9864)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3785, 10000010, CAST(N'2015-09-02 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3786, 10000053, CAST(N'2015-09-01 00:00:00.000' AS DateTime), 1.9857, 1.9857)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3787, 1, CAST(N'2015-09-01 00:00:00.000' AS DateTime), 2.4306, 2.4306)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3788, 10000073, CAST(N'2015-09-01 00:00:00.000' AS DateTime), 1.6178, 1.6178)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3789, 10000083, CAST(N'2015-09-01 00:00:00.000' AS DateTime), 1.6744, 1.6744)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3790, 10000093, CAST(N'2015-09-01 00:00:00.000' AS DateTime), 1.6598, 1.6598)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3791, 10000103, CAST(N'2015-09-01 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3792, 10000133, CAST(N'2015-09-01 00:00:00.000' AS DateTime), 1.217, 1.217)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3793, 10000133, CAST(N'2015-08-31 00:00:00.000' AS DateTime), 1.2166, 1.2166)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3794, 10000123, CAST(N'2015-08-31 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3795, 10000103, CAST(N'2015-08-31 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3796, 10000093, CAST(N'2015-08-31 00:00:00.000' AS DateTime), 1.6592, 1.6592)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3797, 10000083, CAST(N'2015-08-31 00:00:00.000' AS DateTime), 1.6738, 1.6738)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3798, 10000073, CAST(N'2015-08-31 00:00:00.000' AS DateTime), 1.6172, 1.6172)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3799, 1, CAST(N'2015-08-31 00:00:00.000' AS DateTime), 2.4264, 2.4264)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3800, 10000053, CAST(N'2015-08-31 00:00:00.000' AS DateTime), 1.9851, 1.9851)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3801, 10000010, CAST(N'2015-08-31 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3802, 10000010, CAST(N'2015-08-30 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3803, 10000053, CAST(N'2015-08-30 00:00:00.000' AS DateTime), 1.982, 1.982)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3804, 1, CAST(N'2015-08-30 00:00:00.000' AS DateTime), 2.4141, 2.4141)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3805, 10000073, CAST(N'2015-08-30 00:00:00.000' AS DateTime), 1.6166, 1.6166)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3806, 10000083, CAST(N'2015-08-30 00:00:00.000' AS DateTime), 1.6909, 1.6909)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3807, 10000093, CAST(N'2015-08-30 00:00:00.000' AS DateTime), 1.6583, 1.6583)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3808, 10000103, CAST(N'2015-08-30 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3809, 10000133, CAST(N'2015-08-30 00:00:00.000' AS DateTime), 1.2161, 1.2161)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3810, 10000133, CAST(N'2015-08-29 00:00:00.000' AS DateTime), 1.2157, 1.2157)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3811, 10000103, CAST(N'2015-08-29 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3812, 10000093, CAST(N'2015-08-29 00:00:00.000' AS DateTime), 1.6577, 1.6577)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3813, 10000083, CAST(N'2015-08-29 00:00:00.000' AS DateTime), 1.6903, 1.6903)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3814, 10000073, CAST(N'2015-08-29 00:00:00.000' AS DateTime), 1.6161, 1.6161)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3815, 1, CAST(N'2015-08-29 00:00:00.000' AS DateTime), 2.4134, 2.4134)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3816, 10000053, CAST(N'2015-08-29 00:00:00.000' AS DateTime), 1.9813, 1.9813)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3817, 10000053, CAST(N'2015-08-28 00:00:00.000' AS DateTime), 1.9807, 1.9807)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3818, 1, CAST(N'2015-08-28 00:00:00.000' AS DateTime), 2.4128, 2.4128)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3819, 10000073, CAST(N'2015-08-28 00:00:00.000' AS DateTime), 1.6155, 1.6155)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3820, 10000083, CAST(N'2015-08-28 00:00:00.000' AS DateTime), 1.6897, 1.6897)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3821, 10000093, CAST(N'2015-08-28 00:00:00.000' AS DateTime), 1.6571, 1.6571)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3822, 10000103, CAST(N'2015-08-28 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3823, 10000133, CAST(N'2015-08-28 00:00:00.000' AS DateTime), 1.2153, 1.2153)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3824, 10000133, CAST(N'2015-08-27 00:00:00.000' AS DateTime), 1.2149, 1.2149)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3825, 10000103, CAST(N'2015-08-27 00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3826, 10000093, CAST(N'2015-08-27 00:00:00.000' AS DateTime), 1.6565, 1.6565)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3827, 10000083, CAST(N'2015-08-27 00:00:00.000' AS DateTime), 1.689, 1.689)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3828, 10000073, CAST(N'2015-08-27 00:00:00.000' AS DateTime), 1.6149, 1.6149)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3829, 1, CAST(N'2015-08-27 00:00:00.000' AS DateTime), 2.411, 2.411)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3830, 10000053, CAST(N'2015-08-27 00:00:00.000' AS DateTime), 1.98, 1.98)
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3831, 10000010, CAST(N'2015-08-27 00:00:00.000' AS DateTime), 0, 0)
GO
INSERT [dbo].[PriceHistory] ([price_history_id], [scheme_id], [valuation_date], [bid_price], [offer_price]) VALUES (3832, 10000010, CAST(N'2015-08-26 00:00:00.000' AS DateTime), 0, 0)
SET IDENTITY_INSERT [dbo].[PriceHistory] OFF
SET IDENTITY_INSERT [dbo].[Publications] ON 

INSERT [dbo].[Publications] ([PublicationsId], [UploadTypeId], [DateUploaded], [PublicationName], [Extension]) VALUES (4, 2, CAST(N'2015-12-17 11:30:48.703' AS DateTime), N'kpaggry', N'.pdf      ')
INSERT [dbo].[Publications] ([PublicationsId], [UploadTypeId], [DateUploaded], [PublicationName], [Extension]) VALUES (5, 1, CAST(N'2015-12-17 11:36:43.507' AS DateTime), N'Some Sample', N'.pdf      ')
INSERT [dbo].[Publications] ([PublicationsId], [UploadTypeId], [DateUploaded], [PublicationName], [Extension]) VALUES (6, 1, CAST(N'2016-01-20 17:15:18.033' AS DateTime), N'test', N'.pdf      ')
SET IDENTITY_INSERT [dbo].[Publications] OFF
SET IDENTITY_INSERT [dbo].[SecretQuestionsStore] ON 

INSERT [dbo].[SecretQuestionsStore] ([Id], [Value]) VALUES (1, N'What''s the name of your first Pet?')
INSERT [dbo].[SecretQuestionsStore] ([Id], [Value]) VALUES (2, N'What''s the name of your Secondary School?')
SET IDENTITY_INSERT [dbo].[SecretQuestionsStore] OFF
SET IDENTITY_INSERT [dbo].[Sheme] ON 

INSERT [dbo].[Sheme] ([SCHEME_ID], [SCHEME_NAME], [REPORT_DATE], [OFFER_PRICE], [BID_PRICE], [OFFER_FOR], [BID_FOR], [TOTAL_UNITS], [TOTAL_RECEIVABLES], [NAV], [GAV], [PAY_COT], [COT_PERCENT], [CALC_INTEREST], [INTEREST_RATE], [SCHEME_LOGO], [START_DATE], [LAST_PROC_DATE], [UPDATE_SUCCESS], [ACCRUED_DIVIDEND], [ACCRUED_FEES], [PAID_FEES], [MANAGER_HEADER_PAGE], [MANAGER_FOOTER_PAGE], [PROMISE], [SCHEME_TYPE], [COMPANY_ID], [LAST_POSTED], [STAMP_DUTIES], [NSE_CSCS_FEES], [BROKERAGE_FEES], [SEC_FEES], [CODE], [MGMT_FEE_PAYABLE_PERC], [EXCESS_FEE_PAYABLE_PERC], [VAT_ON_EXCESS_FEE], [TRANS_FEE_PAYABLE_PERC], [PERCENTAGE_ABOVE], [FEE_TYPE], [CONTRACT_BEGINS], [CONTRACT_ENDS], [ACCOUNT_STATUS], [CSCS_CODE], [ACCOUNT_CODE], [TROI_CODE], [OPENING_NAV], [RATING_REQUIRMENT], [POINT_TO_NOTE], [INVEST_GUIDELINE], [STANDING_ORDERS], [REPORTING_FREQ], [AGREEMENT_EXPIRY], [SCHEME_TABLE_ID]) VALUES (1, N'Pensions Alliance Value Fund', CAST(N'2011-06-27 00:00:00.000' AS DateTime), 1.6994, 1.6994, N'NULL', N'NULL', 30523210993.2517, N'0', 51872344332.37, 51962113834.08, N'NULL', N'2.125', N'NULL', N'NULL', N'NULL', CAST(N'2005-07-01 00:00:00.000' AS DateTime), CAST(N'2011-06-27 00:00:00.000' AS DateTime), N'NULL', 92403930.36, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'U', 2, N'00:00.0', N'0.075', N'1', N'0.525', N'1', N'PAVF', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', 51916825602.52, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', 1)
INSERT [dbo].[Sheme] ([SCHEME_ID], [SCHEME_NAME], [REPORT_DATE], [OFFER_PRICE], [BID_PRICE], [OFFER_FOR], [BID_FOR], [TOTAL_UNITS], [TOTAL_RECEIVABLES], [NAV], [GAV], [PAY_COT], [COT_PERCENT], [CALC_INTEREST], [INTEREST_RATE], [SCHEME_LOGO], [START_DATE], [LAST_PROC_DATE], [UPDATE_SUCCESS], [ACCRUED_DIVIDEND], [ACCRUED_FEES], [PAID_FEES], [MANAGER_HEADER_PAGE], [MANAGER_FOOTER_PAGE], [PROMISE], [SCHEME_TYPE], [COMPANY_ID], [LAST_POSTED], [STAMP_DUTIES], [NSE_CSCS_FEES], [BROKERAGE_FEES], [SEC_FEES], [CODE], [MGMT_FEE_PAYABLE_PERC], [EXCESS_FEE_PAYABLE_PERC], [VAT_ON_EXCESS_FEE], [TRANS_FEE_PAYABLE_PERC], [PERCENTAGE_ABOVE], [FEE_TYPE], [CONTRACT_BEGINS], [CONTRACT_ENDS], [ACCOUNT_STATUS], [CSCS_CODE], [ACCOUNT_CODE], [TROI_CODE], [OPENING_NAV], [RATING_REQUIRMENT], [POINT_TO_NOTE], [INVEST_GUIDELINE], [STANDING_ORDERS], [REPORTING_FREQ], [AGREEMENT_EXPIRY], [SCHEME_TABLE_ID]) VALUES (2, N'PA Income Fund', CAST(N'2006-09-03 00:00:00.000' AS DateTime), 0, 0, N'NULL', N'NULL', 0, N'NULL', 166619591.13, 166619591.13, N'NULL', N'2.125', N'NULL', N'NULL', N'NULL', CAST(N'2005-09-23 00:00:00.000' AS DateTime), CAST(N'2006-09-03 00:00:00.000' AS DateTime), N'NULL', 0, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'U', 1, N'NULL', N'0.075', N'1', N'1', N'1', N'2', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', 31292407.78, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', 2)
INSERT [dbo].[Sheme] ([SCHEME_ID], [SCHEME_NAME], [REPORT_DATE], [OFFER_PRICE], [BID_PRICE], [OFFER_FOR], [BID_FOR], [TOTAL_UNITS], [TOTAL_RECEIVABLES], [NAV], [GAV], [PAY_COT], [COT_PERCENT], [CALC_INTEREST], [INTEREST_RATE], [SCHEME_LOGO], [START_DATE], [LAST_PROC_DATE], [UPDATE_SUCCESS], [ACCRUED_DIVIDEND], [ACCRUED_FEES], [PAID_FEES], [MANAGER_HEADER_PAGE], [MANAGER_FOOTER_PAGE], [PROMISE], [SCHEME_TYPE], [COMPANY_ID], [LAST_POSTED], [STAMP_DUTIES], [NSE_CSCS_FEES], [BROKERAGE_FEES], [SEC_FEES], [CODE], [MGMT_FEE_PAYABLE_PERC], [EXCESS_FEE_PAYABLE_PERC], [VAT_ON_EXCESS_FEE], [TRANS_FEE_PAYABLE_PERC], [PERCENTAGE_ABOVE], [FEE_TYPE], [CONTRACT_BEGINS], [CONTRACT_ENDS], [ACCOUNT_STATUS], [CSCS_CODE], [ACCOUNT_CODE], [TROI_CODE], [OPENING_NAV], [RATING_REQUIRMENT], [POINT_TO_NOTE], [INVEST_GUIDELINE], [STANDING_ORDERS], [REPORTING_FREQ], [AGREEMENT_EXPIRY], [SCHEME_TABLE_ID]) VALUES (5000002, N'Pensions Alliance New Fund', CAST(N'2005-10-25 00:00:00.000' AS DateTime), 1, 1, N'NULL', N'NULL', 0, N'NULL', 7442611.72, 7442611.72, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', CAST(N'2005-10-25 15:00:08.000' AS DateTime), CAST(N'2005-10-25 00:00:00.000' AS DateTime), N'NULL', 0, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'U', 1, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'3', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', NULL, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', 3)
INSERT [dbo].[Sheme] ([SCHEME_ID], [SCHEME_NAME], [REPORT_DATE], [OFFER_PRICE], [BID_PRICE], [OFFER_FOR], [BID_FOR], [TOTAL_UNITS], [TOTAL_RECEIVABLES], [NAV], [GAV], [PAY_COT], [COT_PERCENT], [CALC_INTEREST], [INTEREST_RATE], [SCHEME_LOGO], [START_DATE], [LAST_PROC_DATE], [UPDATE_SUCCESS], [ACCRUED_DIVIDEND], [ACCRUED_FEES], [PAID_FEES], [MANAGER_HEADER_PAGE], [MANAGER_FOOTER_PAGE], [PROMISE], [SCHEME_TYPE], [COMPANY_ID], [LAST_POSTED], [STAMP_DUTIES], [NSE_CSCS_FEES], [BROKERAGE_FEES], [SEC_FEES], [CODE], [MGMT_FEE_PAYABLE_PERC], [EXCESS_FEE_PAYABLE_PERC], [VAT_ON_EXCESS_FEE], [TRANS_FEE_PAYABLE_PERC], [PERCENTAGE_ABOVE], [FEE_TYPE], [CONTRACT_BEGINS], [CONTRACT_ENDS], [ACCOUNT_STATUS], [CSCS_CODE], [ACCOUNT_CODE], [TROI_CODE], [OPENING_NAV], [RATING_REQUIRMENT], [POINT_TO_NOTE], [INVEST_GUIDELINE], [STANDING_ORDERS], [REPORTING_FREQ], [AGREEMENT_EXPIRY], [SCHEME_TABLE_ID]) VALUES (10000003, N'Pensions Alliance balanced Fund', CAST(N'2008-12-16 00:00:00.000' AS DateTime), 0, 0, N'NULL', N'NULL', 0, N'NULL', 0, 0, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', CAST(N'2006-09-08 17:10:18.000' AS DateTime), CAST(N'2008-12-16 00:00:00.000' AS DateTime), N'NULL', 0, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'U', NULL, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'4', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', 0, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', 4)
INSERT [dbo].[Sheme] ([SCHEME_ID], [SCHEME_NAME], [REPORT_DATE], [OFFER_PRICE], [BID_PRICE], [OFFER_FOR], [BID_FOR], [TOTAL_UNITS], [TOTAL_RECEIVABLES], [NAV], [GAV], [PAY_COT], [COT_PERCENT], [CALC_INTEREST], [INTEREST_RATE], [SCHEME_LOGO], [START_DATE], [LAST_PROC_DATE], [UPDATE_SUCCESS], [ACCRUED_DIVIDEND], [ACCRUED_FEES], [PAID_FEES], [MANAGER_HEADER_PAGE], [MANAGER_FOOTER_PAGE], [PROMISE], [SCHEME_TYPE], [COMPANY_ID], [LAST_POSTED], [STAMP_DUTIES], [NSE_CSCS_FEES], [BROKERAGE_FEES], [SEC_FEES], [CODE], [MGMT_FEE_PAYABLE_PERC], [EXCESS_FEE_PAYABLE_PERC], [VAT_ON_EXCESS_FEE], [TRANS_FEE_PAYABLE_PERC], [PERCENTAGE_ABOVE], [FEE_TYPE], [CONTRACT_BEGINS], [CONTRACT_ENDS], [ACCOUNT_STATUS], [CSCS_CODE], [ACCOUNT_CODE], [TROI_CODE], [OPENING_NAV], [RATING_REQUIRMENT], [POINT_TO_NOTE], [INVEST_GUIDELINE], [STANDING_ORDERS], [REPORTING_FREQ], [AGREEMENT_EXPIRY], [SCHEME_TABLE_ID]) VALUES (10000004, N'Pensions Alliance MTN Fund', CAST(N'2006-10-31 00:00:00.000' AS DateTime), 0, 0, N'NULL', N'NULL', 0, N'NULL', 606714133.06, 608156757.34, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', CAST(N'2006-09-08 17:08:38.000' AS DateTime), CAST(N'2006-10-31 00:00:00.000' AS DateTime), N'NULL', 670707.91, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'U', 3, N'00:00.0', N'NULL', N'NULL', N'NULL', N'NULL', N'PAMF', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', 607450763.76, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', 5)
INSERT [dbo].[Sheme] ([SCHEME_ID], [SCHEME_NAME], [REPORT_DATE], [OFFER_PRICE], [BID_PRICE], [OFFER_FOR], [BID_FOR], [TOTAL_UNITS], [TOTAL_RECEIVABLES], [NAV], [GAV], [PAY_COT], [COT_PERCENT], [CALC_INTEREST], [INTEREST_RATE], [SCHEME_LOGO], [START_DATE], [LAST_PROC_DATE], [UPDATE_SUCCESS], [ACCRUED_DIVIDEND], [ACCRUED_FEES], [PAID_FEES], [MANAGER_HEADER_PAGE], [MANAGER_FOOTER_PAGE], [PROMISE], [SCHEME_TYPE], [COMPANY_ID], [LAST_POSTED], [STAMP_DUTIES], [NSE_CSCS_FEES], [BROKERAGE_FEES], [SEC_FEES], [CODE], [MGMT_FEE_PAYABLE_PERC], [EXCESS_FEE_PAYABLE_PERC], [VAT_ON_EXCESS_FEE], [TRANS_FEE_PAYABLE_PERC], [PERCENTAGE_ABOVE], [FEE_TYPE], [CONTRACT_BEGINS], [CONTRACT_ENDS], [ACCOUNT_STATUS], [CSCS_CODE], [ACCOUNT_CODE], [TROI_CODE], [OPENING_NAV], [RATING_REQUIRMENT], [POINT_TO_NOTE], [INVEST_GUIDELINE], [STANDING_ORDERS], [REPORTING_FREQ], [AGREEMENT_EXPIRY], [SCHEME_TABLE_ID]) VALUES (10000010, N'Pensions Alliance NNPC Fund', CAST(N'2011-06-20 00:00:00.000' AS DateTime), 0, 0, N'NULL', N'NULL', 0, N'NULL', 8822318757.2, 8827361236.16, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', CAST(N'2006-12-01 00:00:00.000' AS DateTime), CAST(N'2011-06-20 00:00:00.000' AS DateTime), N'NULL', 39032660.07, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'U', 4, N'00:00.0', N'NULL', N'NULL', N'NULL', N'NULL', N'NNPC', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', 10025051400.9, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', 6)
INSERT [dbo].[Sheme] ([SCHEME_ID], [SCHEME_NAME], [REPORT_DATE], [OFFER_PRICE], [BID_PRICE], [OFFER_FOR], [BID_FOR], [TOTAL_UNITS], [TOTAL_RECEIVABLES], [NAV], [GAV], [PAY_COT], [COT_PERCENT], [CALC_INTEREST], [INTEREST_RATE], [SCHEME_LOGO], [START_DATE], [LAST_PROC_DATE], [UPDATE_SUCCESS], [ACCRUED_DIVIDEND], [ACCRUED_FEES], [PAID_FEES], [MANAGER_HEADER_PAGE], [MANAGER_FOOTER_PAGE], [PROMISE], [SCHEME_TYPE], [COMPANY_ID], [LAST_POSTED], [STAMP_DUTIES], [NSE_CSCS_FEES], [BROKERAGE_FEES], [SEC_FEES], [CODE], [MGMT_FEE_PAYABLE_PERC], [EXCESS_FEE_PAYABLE_PERC], [VAT_ON_EXCESS_FEE], [TRANS_FEE_PAYABLE_PERC], [PERCENTAGE_ABOVE], [FEE_TYPE], [CONTRACT_BEGINS], [CONTRACT_ENDS], [ACCOUNT_STATUS], [CSCS_CODE], [ACCOUNT_CODE], [TROI_CODE], [OPENING_NAV], [RATING_REQUIRMENT], [POINT_TO_NOTE], [INVEST_GUIDELINE], [STANDING_ORDERS], [REPORTING_FREQ], [AGREEMENT_EXPIRY], [SCHEME_TABLE_ID]) VALUES (10000013, N'TEST FUND', CAST(N'2011-04-08 00:00:00.000' AS DateTime), 1.1789, 1.1789, N'NULL', N'NULL', 100000000, N'NULL', 117888630.87, 117888630.87, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', CAST(N'2006-12-18 11:13:48.000' AS DateTime), CAST(N'2011-04-08 00:00:00.000' AS DateTime), N'NULL', 0, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'U', 3, N'NULL', N'0.075', N'1.5', N'1', N'1', N'TEST', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', 118294085.39, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', 7)
INSERT [dbo].[Sheme] ([SCHEME_ID], [SCHEME_NAME], [REPORT_DATE], [OFFER_PRICE], [BID_PRICE], [OFFER_FOR], [BID_FOR], [TOTAL_UNITS], [TOTAL_RECEIVABLES], [NAV], [GAV], [PAY_COT], [COT_PERCENT], [CALC_INTEREST], [INTEREST_RATE], [SCHEME_LOGO], [START_DATE], [LAST_PROC_DATE], [UPDATE_SUCCESS], [ACCRUED_DIVIDEND], [ACCRUED_FEES], [PAID_FEES], [MANAGER_HEADER_PAGE], [MANAGER_FOOTER_PAGE], [PROMISE], [SCHEME_TYPE], [COMPANY_ID], [LAST_POSTED], [STAMP_DUTIES], [NSE_CSCS_FEES], [BROKERAGE_FEES], [SEC_FEES], [CODE], [MGMT_FEE_PAYABLE_PERC], [EXCESS_FEE_PAYABLE_PERC], [VAT_ON_EXCESS_FEE], [TRANS_FEE_PAYABLE_PERC], [PERCENTAGE_ABOVE], [FEE_TYPE], [CONTRACT_BEGINS], [CONTRACT_ENDS], [ACCOUNT_STATUS], [CSCS_CODE], [ACCOUNT_CODE], [TROI_CODE], [OPENING_NAV], [RATING_REQUIRMENT], [POINT_TO_NOTE], [INVEST_GUIDELINE], [STANDING_ORDERS], [REPORTING_FREQ], [AGREEMENT_EXPIRY], [SCHEME_TABLE_ID]) VALUES (10000023, N'TRAINING F UND', CAST(N'2007-04-24 00:00:00.000' AS DateTime), 0, 0, N'NULL', N'NULL', 0, N'NULL', 485574364.45, 486356849.32, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', CAST(N'2007-04-23 15:49:13.000' AS DateTime), CAST(N'2007-04-24 00:00:00.000' AS DateTime), N'NULL', 0, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'U', 6, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'TF', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', 485582876.72, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', 8)
INSERT [dbo].[Sheme] ([SCHEME_ID], [SCHEME_NAME], [REPORT_DATE], [OFFER_PRICE], [BID_PRICE], [OFFER_FOR], [BID_FOR], [TOTAL_UNITS], [TOTAL_RECEIVABLES], [NAV], [GAV], [PAY_COT], [COT_PERCENT], [CALC_INTEREST], [INTEREST_RATE], [SCHEME_LOGO], [START_DATE], [LAST_PROC_DATE], [UPDATE_SUCCESS], [ACCRUED_DIVIDEND], [ACCRUED_FEES], [PAID_FEES], [MANAGER_HEADER_PAGE], [MANAGER_FOOTER_PAGE], [PROMISE], [SCHEME_TYPE], [COMPANY_ID], [LAST_POSTED], [STAMP_DUTIES], [NSE_CSCS_FEES], [BROKERAGE_FEES], [SEC_FEES], [CODE], [MGMT_FEE_PAYABLE_PERC], [EXCESS_FEE_PAYABLE_PERC], [VAT_ON_EXCESS_FEE], [TRANS_FEE_PAYABLE_PERC], [PERCENTAGE_ABOVE], [FEE_TYPE], [CONTRACT_BEGINS], [CONTRACT_ENDS], [ACCOUNT_STATUS], [CSCS_CODE], [ACCOUNT_CODE], [TROI_CODE], [OPENING_NAV], [RATING_REQUIRMENT], [POINT_TO_NOTE], [INVEST_GUIDELINE], [STANDING_ORDERS], [REPORTING_FREQ], [AGREEMENT_EXPIRY], [SCHEME_TABLE_ID]) VALUES (10000033, N'Pensions Alliance Value Fund New', NULL, 1, 1, N'NULL', N'NULL', NULL, N'NULL', NULL, NULL, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', CAST(N'2008-05-02 03:43:01.000' AS DateTime), NULL, N'NULL', NULL, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'U', NULL, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'PAVF1', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', NULL, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', 9)
INSERT [dbo].[Sheme] ([SCHEME_ID], [SCHEME_NAME], [REPORT_DATE], [OFFER_PRICE], [BID_PRICE], [OFFER_FOR], [BID_FOR], [TOTAL_UNITS], [TOTAL_RECEIVABLES], [NAV], [GAV], [PAY_COT], [COT_PERCENT], [CALC_INTEREST], [INTEREST_RATE], [SCHEME_LOGO], [START_DATE], [LAST_PROC_DATE], [UPDATE_SUCCESS], [ACCRUED_DIVIDEND], [ACCRUED_FEES], [PAID_FEES], [MANAGER_HEADER_PAGE], [MANAGER_FOOTER_PAGE], [PROMISE], [SCHEME_TYPE], [COMPANY_ID], [LAST_POSTED], [STAMP_DUTIES], [NSE_CSCS_FEES], [BROKERAGE_FEES], [SEC_FEES], [CODE], [MGMT_FEE_PAYABLE_PERC], [EXCESS_FEE_PAYABLE_PERC], [VAT_ON_EXCESS_FEE], [TRANS_FEE_PAYABLE_PERC], [PERCENTAGE_ABOVE], [FEE_TYPE], [CONTRACT_BEGINS], [CONTRACT_ENDS], [ACCOUNT_STATUS], [CSCS_CODE], [ACCOUNT_CODE], [TROI_CODE], [OPENING_NAV], [RATING_REQUIRMENT], [POINT_TO_NOTE], [INVEST_GUIDELINE], [STANDING_ORDERS], [REPORTING_FREQ], [AGREEMENT_EXPIRY], [SCHEME_TABLE_ID]) VALUES (10000043, N'Pensions Alliance NPA Fund', CAST(N'2011-06-24 00:00:00.000' AS DateTime), 0, 0, N'NULL', N'NULL', 0, N'NULL', 903169267.62, 903169267.62, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', CAST(N'2008-11-10 14:09:59.000' AS DateTime), CAST(N'2011-06-24 00:00:00.000' AS DateTime), N'NULL', 3303011.33, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'U', 7, N'00:00.0', N'NULL', N'NULL', N'NULL', N'NULL', N'NPA', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', 798268953.62, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', 10)
INSERT [dbo].[Sheme] ([SCHEME_ID], [SCHEME_NAME], [REPORT_DATE], [OFFER_PRICE], [BID_PRICE], [OFFER_FOR], [BID_FOR], [TOTAL_UNITS], [TOTAL_RECEIVABLES], [NAV], [GAV], [PAY_COT], [COT_PERCENT], [CALC_INTEREST], [INTEREST_RATE], [SCHEME_LOGO], [START_DATE], [LAST_PROC_DATE], [UPDATE_SUCCESS], [ACCRUED_DIVIDEND], [ACCRUED_FEES], [PAID_FEES], [MANAGER_HEADER_PAGE], [MANAGER_FOOTER_PAGE], [PROMISE], [SCHEME_TYPE], [COMPANY_ID], [LAST_POSTED], [STAMP_DUTIES], [NSE_CSCS_FEES], [BROKERAGE_FEES], [SEC_FEES], [CODE], [MGMT_FEE_PAYABLE_PERC], [EXCESS_FEE_PAYABLE_PERC], [VAT_ON_EXCESS_FEE], [TRANS_FEE_PAYABLE_PERC], [PERCENTAGE_ABOVE], [FEE_TYPE], [CONTRACT_BEGINS], [CONTRACT_ENDS], [ACCOUNT_STATUS], [CSCS_CODE], [ACCOUNT_CODE], [TROI_CODE], [OPENING_NAV], [RATING_REQUIRMENT], [POINT_TO_NOTE], [INVEST_GUIDELINE], [STANDING_ORDERS], [REPORTING_FREQ], [AGREEMENT_EXPIRY], [SCHEME_TABLE_ID]) VALUES (10000053, N'Pensions Alliance Retiree Fund', CAST(N'2011-06-27 00:00:00.000' AS DateTime), 1.2636, 1.2636, N'NULL', N'NULL', 5015171584.2204, N'NULL', 6336927379.42, 6339925553.87, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', CAST(N'2009-02-01 00:00:00.000' AS DateTime), CAST(N'2011-06-27 00:00:00.000' AS DateTime), N'NULL', 4562301.01, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'U', 9, N'00:00.0', N'NULL', N'NULL', N'NULL', N'NULL', N'PARF', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', 6172856751.26, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', 11)
INSERT [dbo].[Sheme] ([SCHEME_ID], [SCHEME_NAME], [REPORT_DATE], [OFFER_PRICE], [BID_PRICE], [OFFER_FOR], [BID_FOR], [TOTAL_UNITS], [TOTAL_RECEIVABLES], [NAV], [GAV], [PAY_COT], [COT_PERCENT], [CALC_INTEREST], [INTEREST_RATE], [SCHEME_LOGO], [START_DATE], [LAST_PROC_DATE], [UPDATE_SUCCESS], [ACCRUED_DIVIDEND], [ACCRUED_FEES], [PAID_FEES], [MANAGER_HEADER_PAGE], [MANAGER_FOOTER_PAGE], [PROMISE], [SCHEME_TYPE], [COMPANY_ID], [LAST_POSTED], [STAMP_DUTIES], [NSE_CSCS_FEES], [BROKERAGE_FEES], [SEC_FEES], [CODE], [MGMT_FEE_PAYABLE_PERC], [EXCESS_FEE_PAYABLE_PERC], [VAT_ON_EXCESS_FEE], [TRANS_FEE_PAYABLE_PERC], [PERCENTAGE_ABOVE], [FEE_TYPE], [CONTRACT_BEGINS], [CONTRACT_ENDS], [ACCOUNT_STATUS], [CSCS_CODE], [ACCOUNT_CODE], [TROI_CODE], [OPENING_NAV], [RATING_REQUIRMENT], [POINT_TO_NOTE], [INVEST_GUIDELINE], [STANDING_ORDERS], [REPORTING_FREQ], [AGREEMENT_EXPIRY], [SCHEME_TABLE_ID]) VALUES (10000063, N'Pensions Alliance FAAN Fund', CAST(N'2011-05-31 00:00:00.000' AS DateTime), 0, 0, N'NULL', N'NULL', 0, N'NULL', 27177254.94, 27177254.94, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', CAST(N'2009-11-24 00:00:00.000' AS DateTime), CAST(N'2011-05-31 00:00:00.000' AS DateTime), N'NULL', 151669.58, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'I', 8, N'00:00.0', N'NULL', N'NULL', N'NULL', N'NULL', N'FAAN', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', 27013849.73, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', 12)
INSERT [dbo].[Sheme] ([SCHEME_ID], [SCHEME_NAME], [REPORT_DATE], [OFFER_PRICE], [BID_PRICE], [OFFER_FOR], [BID_FOR], [TOTAL_UNITS], [TOTAL_RECEIVABLES], [NAV], [GAV], [PAY_COT], [COT_PERCENT], [CALC_INTEREST], [INTEREST_RATE], [SCHEME_LOGO], [START_DATE], [LAST_PROC_DATE], [UPDATE_SUCCESS], [ACCRUED_DIVIDEND], [ACCRUED_FEES], [PAID_FEES], [MANAGER_HEADER_PAGE], [MANAGER_FOOTER_PAGE], [PROMISE], [SCHEME_TYPE], [COMPANY_ID], [LAST_POSTED], [STAMP_DUTIES], [NSE_CSCS_FEES], [BROKERAGE_FEES], [SEC_FEES], [CODE], [MGMT_FEE_PAYABLE_PERC], [EXCESS_FEE_PAYABLE_PERC], [VAT_ON_EXCESS_FEE], [TRANS_FEE_PAYABLE_PERC], [PERCENTAGE_ABOVE], [FEE_TYPE], [CONTRACT_BEGINS], [CONTRACT_ENDS], [ACCOUNT_STATUS], [CSCS_CODE], [ACCOUNT_CODE], [TROI_CODE], [OPENING_NAV], [RATING_REQUIRMENT], [POINT_TO_NOTE], [INVEST_GUIDELINE], [STANDING_ORDERS], [REPORTING_FREQ], [AGREEMENT_EXPIRY], [SCHEME_TABLE_ID]) VALUES (10000073, N'PENSIONS ALLIANCE EMENITE GRATUITY', CAST(N'2011-06-27 00:00:00.000' AS DateTime), 1.0082, 1.0082, N'NULL', N'NULL', 96086655.3967, N'NULL', 96870730.14, 96922229.09, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', CAST(N'2011-04-06 18:29:38.000' AS DateTime), CAST(N'2011-06-27 00:00:00.000' AS DateTime), N'NULL', 112500, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'U', 10, N'00:00.0', N'0.75', N'1', N'0.525', N'1', N'EMEN', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', 96896008.88, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', 13)
INSERT [dbo].[Sheme] ([SCHEME_ID], [SCHEME_NAME], [REPORT_DATE], [OFFER_PRICE], [BID_PRICE], [OFFER_FOR], [BID_FOR], [TOTAL_UNITS], [TOTAL_RECEIVABLES], [NAV], [GAV], [PAY_COT], [COT_PERCENT], [CALC_INTEREST], [INTEREST_RATE], [SCHEME_LOGO], [START_DATE], [LAST_PROC_DATE], [UPDATE_SUCCESS], [ACCRUED_DIVIDEND], [ACCRUED_FEES], [PAID_FEES], [MANAGER_HEADER_PAGE], [MANAGER_FOOTER_PAGE], [PROMISE], [SCHEME_TYPE], [COMPANY_ID], [LAST_POSTED], [STAMP_DUTIES], [NSE_CSCS_FEES], [BROKERAGE_FEES], [SEC_FEES], [CODE], [MGMT_FEE_PAYABLE_PERC], [EXCESS_FEE_PAYABLE_PERC], [VAT_ON_EXCESS_FEE], [TRANS_FEE_PAYABLE_PERC], [PERCENTAGE_ABOVE], [FEE_TYPE], [CONTRACT_BEGINS], [CONTRACT_ENDS], [ACCOUNT_STATUS], [CSCS_CODE], [ACCOUNT_CODE], [TROI_CODE], [OPENING_NAV], [RATING_REQUIRMENT], [POINT_TO_NOTE], [INVEST_GUIDELINE], [STANDING_ORDERS], [REPORTING_FREQ], [AGREEMENT_EXPIRY], [SCHEME_TABLE_ID]) VALUES (10000083, N'PAL TRANSITIONAL FUND', CAST(N'2011-06-20 00:00:00.000' AS DateTime), 1.0017, 1.0017, N'NULL', N'NULL', 36223402, N'NULL', 36284187.49, 36284187.49, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', CAST(N'2011-06-06 17:39:34.000' AS DateTime), CAST(N'2011-06-20 00:00:00.000' AS DateTime), N'NULL', 0, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'U', 11, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'PATF', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', 36275503.85, N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', N'NULL', 14)
SET IDENTITY_INSERT [dbo].[Sheme] OFF
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([StatusId], [StatusValue]) VALUES (1, N'Not Complete')
INSERT [dbo].[Status] ([StatusId], [StatusValue]) VALUES (2, N'Submitted')
INSERT [dbo].[Status] ([StatusId], [StatusValue]) VALUES (3, N'Account Verification')
INSERT [dbo].[Status] ([StatusId], [StatusValue]) VALUES (4, N'Following up on Accrued Right')
INSERT [dbo].[Status] ([StatusId], [StatusValue]) VALUES (5, N'Process To BPD')
INSERT [dbo].[Status] ([StatusId], [StatusValue]) VALUES (6, N'Process to Pencom for Approval')
INSERT [dbo].[Status] ([StatusId], [StatusValue]) VALUES (7, N'Instruction sent to Bank')
INSERT [dbo].[Status] ([StatusId], [StatusValue]) VALUES (8, N'Rejected')
INSERT [dbo].[Status] ([StatusId], [StatusValue]) VALUES (1008, N'Completed')
SET IDENTITY_INSERT [dbo].[Status] OFF
SET IDENTITY_INSERT [dbo].[SupportCategories] ON 

INSERT [dbo].[SupportCategories] ([Id], [Value]) VALUES (1, N'Contribution')
INSERT [dbo].[SupportCategories] ([Id], [Value]) VALUES (2, N'Payment')
INSERT [dbo].[SupportCategories] ([Id], [Value]) VALUES (3, N'Information Update')
INSERT [dbo].[SupportCategories] ([Id], [Value]) VALUES (4, N'Others')
SET IDENTITY_INSERT [dbo].[SupportCategories] OFF
SET IDENTITY_INSERT [dbo].[SupportLogs] ON 

INSERT [dbo].[SupportLogs] ([Id], [Pin], [CategoryId], [Summary], [Explanation], [DateSubmitted]) VALUES (1, N'PEN100752325918', 1, N'Just a brief summary', N'I tried to make it work but it kept failing, what do i have to do to sort this out', CAST(N'2016-01-19 17:40:11.500' AS DateTime))
INSERT [dbo].[SupportLogs] ([Id], [Pin], [CategoryId], [Summary], [Explanation], [DateSubmitted]) VALUES (2, N'PEN100752325918', 1, N'This is a test', N'Tech support for the contribution was not handled properly', CAST(N'2016-01-20 15:02:12.900' AS DateTime))
SET IDENTITY_INSERT [dbo].[SupportLogs] OFF
SET IDENTITY_INSERT [dbo].[TempCustomerInformation] ON 

INSERT [dbo].[TempCustomerInformation] ([id], [pin], [mobile-number], [email], [parmanent-address], [home-address], [mobile-number2], [date-created], [name], [status]) VALUES (1, N'PEN100752325918', N'08099767543', N'seyipedro@gmail.com', N'Kufeji Street Alagomeji', N'Victoria Island', N'09055678909', CAST(N'2015-12-21 16:52:06.053' AS DateTime), NULL, N'Pending')
INSERT [dbo].[TempCustomerInformation] ([id], [pin], [mobile-number], [email], [parmanent-address], [home-address], [mobile-number2], [date-created], [name], [status]) VALUES (2, N'PEN100752325918', N'08099767543', N'seyipedro@gmail.com', N'Kufeji Street Alagomeji', N'Victoria Island', N'09055678909', CAST(N'2015-12-21 16:57:38.807' AS DateTime), N'Roronoa Kpaggry', N'Pending')
INSERT [dbo].[TempCustomerInformation] ([id], [pin], [mobile-number], [email], [parmanent-address], [home-address], [mobile-number2], [date-created], [name], [status]) VALUES (3, N'PEN100752325918', N'08099767543', N'oluwaseyi@rightclick-ng.com', N'Just checking', N'Victoria Island', N'09055678909', CAST(N'2015-12-29 15:52:20.467' AS DateTime), N'Roronoa Kpaggry', N'Pending')
INSERT [dbo].[TempCustomerInformation] ([id], [pin], [mobile-number], [email], [parmanent-address], [home-address], [mobile-number2], [date-created], [name], [status]) VALUES (4, N'PEN100752325918', N'08099767544', N'oluwaseyi@rightclick-ng.com', NULL, NULL, N'09055678909', CAST(N'2016-01-20 12:36:48.253' AS DateTime), N'Roronoa Pedro', N'Pending')
INSERT [dbo].[TempCustomerInformation] ([id], [pin], [mobile-number], [email], [parmanent-address], [home-address], [mobile-number2], [date-created], [name], [status]) VALUES (5, N'PEN100752325918', N'08099767544', N'oluwaseyi@rightclick-ng.com', NULL, NULL, N'09055678909', CAST(N'2016-01-20 12:55:44.957' AS DateTime), N'Roronoa Pedro', N'Pending')
INSERT [dbo].[TempCustomerInformation] ([id], [pin], [mobile-number], [email], [parmanent-address], [home-address], [mobile-number2], [date-created], [name], [status]) VALUES (6, N'PEN100752325918', N'08099767545', N'oluwaseyi@rightclick-ng.com', NULL, NULL, N'09055678909', CAST(N'2016-01-20 12:56:31.410' AS DateTime), N'Roronoa Pedro', N'Pending')
INSERT [dbo].[TempCustomerInformation] ([id], [pin], [mobile-number], [email], [parmanent-address], [home-address], [mobile-number2], [date-created], [name], [status]) VALUES (7, N'PEN100752325918', N'080997675456556565', N'oluwaseyi@rightclick-ng.com', NULL, NULL, N'09055678909', CAST(N'2016-01-20 12:57:12.733' AS DateTime), N'Roronoa Pedro', N'Pending')
INSERT [dbo].[TempCustomerInformation] ([id], [pin], [mobile-number], [email], [parmanent-address], [home-address], [mobile-number2], [date-created], [name], [status]) VALUES (8, N'PEN100752325918', N'07055439630', N'oluwaseyi@rightclick-ng.com', NULL, NULL, N'08099023467', CAST(N'2016-01-20 16:26:21.377' AS DateTime), N'Roronoa Pedro', N'Pending')
INSERT [dbo].[TempCustomerInformation] ([id], [pin], [mobile-number], [email], [parmanent-address], [home-address], [mobile-number2], [date-created], [name], [status]) VALUES (9, N'PEN100752325918', N'08023102861', N'oluwaseyi@rightclick-ng.com', NULL, NULL, NULL, CAST(N'2016-01-20 16:39:00.613' AS DateTime), N'Roronoa Pedro', N'Pending')
INSERT [dbo].[TempCustomerInformation] ([id], [pin], [mobile-number], [email], [parmanent-address], [home-address], [mobile-number2], [date-created], [name], [status]) VALUES (10, N'PEN100752325918', N'07055467890', N'oluwaseyi@rightclick-ng.com', NULL, NULL, N'09055678909', CAST(N'2016-01-20 16:40:30.500' AS DateTime), N'Roronoa Pedro', N'Approved')
SET IDENTITY_INSERT [dbo].[TempCustomerInformation] OFF
SET IDENTITY_INSERT [dbo].[UploadType] ON 

INSERT [dbo].[UploadType] ([UploadTypeId], [UploadTypeValue]) VALUES (1, N'News Letter')
INSERT [dbo].[UploadType] ([UploadTypeId], [UploadTypeValue]) VALUES (2, N'Contribution History')
SET IDENTITY_INSERT [dbo].[UploadType] OFF
SET IDENTITY_INSERT [dbo].[UserProfile] ON 

INSERT [dbo].[UserProfile] ([UserId], [UserName], [SecretQuestionId], [SecretQuestionAnswer], [VerificationCode], [Email], [InvestorId], [Employee_Pin], [LastLogin], [QuestionKey], [FirstSignOn]) VALUES (1, N'admin', NULL, NULL, NULL, N'seyipedro@gmail.com', NULL, N'PEN100752325917
', CAST(N'2016-01-22 10:18:04.170' AS DateTime), NULL, NULL)
INSERT [dbo].[UserProfile] ([UserId], [UserName], [SecretQuestionId], [SecretQuestionAnswer], [VerificationCode], [Email], [InvestorId], [Employee_Pin], [LastLogin], [QuestionKey], [FirstSignOn]) VALUES (2, N'kpaggry', 1, N'Rb/Nr5d/6wzUAf8Hlm4ZS/iBdr7Y9MipbZ5CyjXvKyYsbh39dY0SOOidTOUPfTLrXb2e9FbPwLOi2PEMtsXnK6ztE6Q6JbafdruZGcP4g0zEXPRY8GcLj1CsxEcNnseR', NULL, N'oluwaseyi@rightclick-ng.com', NULL, N'PEN100752325918', CAST(N'2016-01-25 12:32:31.977' AS DateTime), N'3e7ca536-0769-44a0-a900-3a3d4df6bf8d', NULL)
INSERT [dbo].[UserProfile] ([UserId], [UserName], [SecretQuestionId], [SecretQuestionAnswer], [VerificationCode], [Email], [InvestorId], [Employee_Pin], [LastLogin], [QuestionKey], [FirstSignOn]) VALUES (3, N'ose', NULL, NULL, NULL, N'ose@rightclick-ng.com', NULL, N'PEN100752325919
', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[UserProfile] OFF
SET IDENTITY_INSERT [dbo].[UserPublications] ON 

INSERT [dbo].[UserPublications] ([UserPublicationsId], [PublicationsId], [EmployeePin]) VALUES (1, 4, N'PEN100752325918')
INSERT [dbo].[UserPublications] ([UserPublicationsId], [PublicationsId], [EmployeePin]) VALUES (2, 5, N'PEN100752325918')
INSERT [dbo].[UserPublications] ([UserPublicationsId], [PublicationsId], [EmployeePin]) VALUES (3, 4, N'PEN100752325918')
INSERT [dbo].[UserPublications] ([UserPublicationsId], [PublicationsId], [EmployeePin]) VALUES (4, 6, N'PEN100752325918')
SET IDENTITY_INSERT [dbo].[UserPublications] OFF
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (1, CAST(N'2015-11-05 11:05:58.953' AS DateTime), NULL, 1, CAST(N'2016-01-20 11:23:46.557' AS DateTime), 0, N'ADKcLCLzVeXvk50lBPGqkbHOATJl3Pg5vjRK2q0BM7WUM+9fLDiPHezAH73/EpI9Iw==', CAST(N'2016-01-21 11:26:38.547' AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (2, CAST(N'2015-12-08 10:39:30.177' AS DateTime), NULL, 1, NULL, 0, N'AM4fJsXPUjEAozbqyQRmeUNZ550gN0n0Ew15W3+61pVRVKajGI4Pqbxq6ZH/SqrfGw==', CAST(N'2016-01-21 11:38:13.793' AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (3, CAST(N'2015-12-08 10:40:09.010' AS DateTime), NULL, 1, NULL, 0, N'AJ0tORGY4PhaZ6LzOcSt0+MxywhVd4LbbEeMBDtNO0hu5yAJMXV0wu6r9JpJ8O+jFQ==', CAST(N'2015-12-08 10:40:09.010' AS DateTime), N'', NULL, NULL)
SET IDENTITY_INSERT [dbo].[webpages_Roles] ON 

INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (1, N'Administrator')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (2, N'Customer')
SET IDENTITY_INSERT [dbo].[webpages_Roles] OFF
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 1)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (2, 2)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (3, 2)
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__UserProf__C9F28456117EA9C5]    Script Date: 1/25/2016 2:25:56 PM ******/
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [UQ__UserProf__C9F28456117EA9C5] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__webpages__8A2B61608767647D]    Script Date: 1/25/2016 2:25:56 PM ******/
ALTER TABLE [dbo].[webpages_Roles] ADD UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AssetAllocation]  WITH CHECK ADD  CONSTRAINT [FK_AssetAllocation_AssetType] FOREIGN KEY([asset_allocation_type])
REFERENCES [dbo].[AssetType] ([id])
GO
ALTER TABLE [dbo].[AssetAllocation] CHECK CONSTRAINT [FK_AssetAllocation_AssetType]
GO
ALTER TABLE [dbo].[BenefitApplications]  WITH CHECK ADD  CONSTRAINT [FK_BenefitApplications_Status] FOREIGN KEY([Status])
REFERENCES [dbo].[Status] ([StatusId])
GO
ALTER TABLE [dbo].[BenefitApplications] CHECK CONSTRAINT [FK_BenefitApplications_Status]
GO
ALTER TABLE [dbo].[BenefitApplications]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BenefitApplications_dbo.Employees_Employee_Pin] FOREIGN KEY([Employee_Pin])
REFERENCES [dbo].[Employees] ([Pin])
GO
ALTER TABLE [dbo].[BenefitApplications] CHECK CONSTRAINT [FK_dbo.BenefitApplications_dbo.Employees_Employee_Pin]
GO
ALTER TABLE [dbo].[ChangeOfAddressProfile]  WITH CHECK ADD  CONSTRAINT [FK_ChangeOfAddressProfile_Employees] FOREIGN KEY([Pin])
REFERENCES [dbo].[Employees] ([Pin])
GO
ALTER TABLE [dbo].[ChangeOfAddressProfile] CHECK CONSTRAINT [FK_ChangeOfAddressProfile_Employees]
GO
ALTER TABLE [dbo].[ChangeOfNameProfile]  WITH CHECK ADD  CONSTRAINT [FK_ChangeOfNameProfile_Employees] FOREIGN KEY([Pin])
REFERENCES [dbo].[Employees] ([Pin])
GO
ALTER TABLE [dbo].[ChangeOfNameProfile] CHECK CONSTRAINT [FK_ChangeOfNameProfile_Employees]
GO
ALTER TABLE [dbo].[Contributions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Contributions_dbo.Employees_Employee_Pin] FOREIGN KEY([Employee_Pin])
REFERENCES [dbo].[Employees] ([Pin])
GO
ALTER TABLE [dbo].[Contributions] CHECK CONSTRAINT [FK_dbo.Contributions_dbo.Employees_Employee_Pin]
GO
ALTER TABLE [dbo].[EmployeeBenefitDocument]  WITH NOCHECK ADD  CONSTRAINT [FK_EmployeeBenefitDocument_BenefitApplications] FOREIGN KEY([BenefitApplicationId])
REFERENCES [dbo].[BenefitApplications] ([BenefitApplicationId])
GO
ALTER TABLE [dbo].[EmployeeBenefitDocument] CHECK CONSTRAINT [FK_EmployeeBenefitDocument_BenefitApplications]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Employees_dbo.EmployerDetails_Employer_Recno] FOREIGN KEY([Employer_Recno])
REFERENCES [dbo].[EmployerDetails] ([Recno])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_dbo.Employees_dbo.EmployerDetails_Employer_Recno]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_AccountManager] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[AccountManager] ([ManagerId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_AccountManager]
GO
ALTER TABLE [dbo].[NextOfKin]  WITH CHECK ADD  CONSTRAINT [FK_dbo.NextOfKin_dbo.Employees_Employee_Pin] FOREIGN KEY([Employee_Pin])
REFERENCES [dbo].[Employees] ([Pin])
GO
ALTER TABLE [dbo].[NextOfKin] CHECK CONSTRAINT [FK_dbo.NextOfKin_dbo.Employees_Employee_Pin]
GO
ALTER TABLE [dbo].[Publications]  WITH CHECK ADD  CONSTRAINT [FK_Publications_Publications] FOREIGN KEY([UploadTypeId])
REFERENCES [dbo].[UploadType] ([UploadTypeId])
GO
ALTER TABLE [dbo].[Publications] CHECK CONSTRAINT [FK_Publications_Publications]
GO
ALTER TABLE [dbo].[SupportLogs]  WITH CHECK ADD  CONSTRAINT [FK_SupportLogs_Employees] FOREIGN KEY([Pin])
REFERENCES [dbo].[Employees] ([Pin])
GO
ALTER TABLE [dbo].[SupportLogs] CHECK CONSTRAINT [FK_SupportLogs_Employees]
GO
ALTER TABLE [dbo].[SupportLogs]  WITH CHECK ADD  CONSTRAINT [FK_SupportLogs_SupportCategories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[SupportCategories] ([Id])
GO
ALTER TABLE [dbo].[SupportLogs] CHECK CONSTRAINT [FK_SupportLogs_SupportCategories]
GO
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [FK_UserProfile_SecretQuestionsStore] FOREIGN KEY([SecretQuestionId])
REFERENCES [dbo].[SecretQuestionsStore] ([Id])
GO
ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [FK_UserProfile_SecretQuestionsStore]
GO
ALTER TABLE [dbo].[UserPublications]  WITH CHECK ADD  CONSTRAINT [FK_UserPublications_Employees] FOREIGN KEY([EmployeePin])
REFERENCES [dbo].[Employees] ([Pin])
GO
ALTER TABLE [dbo].[UserPublications] CHECK CONSTRAINT [FK_UserPublications_Employees]
GO
ALTER TABLE [dbo].[UserPublications]  WITH CHECK ADD  CONSTRAINT [FK_UserPublications_Publications] FOREIGN KEY([PublicationsId])
REFERENCES [dbo].[Publications] ([PublicationsId])
GO
ALTER TABLE [dbo].[UserPublications] CHECK CONSTRAINT [FK_UserPublications_Publications]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_RoleId]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_UserId]
GO
USE [master]
GO
ALTER DATABASE [PALSiteDB] SET  READ_WRITE 
GO
