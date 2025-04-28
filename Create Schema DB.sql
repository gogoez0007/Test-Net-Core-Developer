-- --------------------------------------------------------
-- Host:                         localhost
-- Server version:               Microsoft SQL Server 2022 (RTM) - 16.0.1000.6
-- Server OS:                    Windows 10 Home 10.0 <X64> (Build 26100: ) (Hypervisor)
-- HeidiSQL Version:             12.8.0.6908
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES  */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for testNetCore
CREATE DATABASE IF NOT EXISTS "testNetCore";
USE "testNetCore";

-- Dumping structure for table testNetCore.registration
CREATE TABLE IF NOT EXISTS "registration" (
	"Id" INT NOT NULL,
	"CompanyName" NVARCHAR(255) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"NPWP" NVARCHAR(50) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"DirectorName" NVARCHAR(255) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"PICName" NVARCHAR(255) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"Email" NVARCHAR(255) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"PhoneNumber" NVARCHAR(15) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"NPWPFilePath" NVARCHAR(255) NULL DEFAULT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"PowerOfAttorneyFilePath" NVARCHAR(255) NULL DEFAULT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"AllowAccessAfterClosing" BIT NULL DEFAULT '(0)',
	"CreatedAt" DATETIME NULL DEFAULT 'getdate()',
	PRIMARY KEY ("Id")
);

-- Data exporting was unselected.

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
