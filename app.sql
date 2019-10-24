-- MySQL dump 10.13  Distrib 5.7.17, for macos10.12 (x86_64)
--
-- Host: 127.0.0.1    Database: appserver
-- ------------------------------------------------------
-- Server version	5.7.26

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `mark`
--

DROP TABLE IF EXISTS `mark`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mark` (
  `mobile` varchar(45) NOT NULL,
  `mark` int(50) NOT NULL,
  `lastUpdate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `gps_x` double DEFAULT NULL,
  `gps_y` double DEFAULT NULL,
  PRIMARY KEY (`mobile`),
  CONSTRAINT `FK_mobile` FOREIGN KEY (`mobile`) REFERENCES `player` (`mobile`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mark`
--

LOCK TABLES `mark` WRITE;
/*!40000 ALTER TABLE `mark` DISABLE KEYS */;
INSERT INTO `mark` VALUES ('012345',800,'2019-10-23 06:41:02',37.79965,144.96182),('0434240637',100,'2019-10-23 06:40:21',-37.79971,144.96181),('123456',100,'2019-10-23 07:26:35',-37.79974,144.9619),('234567',3000,'2019-10-23 06:40:21',-37.79975,144.96181),('345678',500,'2019-10-23 06:41:02',37.79973,144.96179),('456789',200,'2019-10-23 06:40:21',-37.79985,144.96177),('567890',300,'2019-10-23 06:41:02',37.7999,144.96185),('678901',400,'2019-10-23 06:40:21',-37.79978,144.96188),('789012',500,'2019-10-23 06:41:02',37.79992,144.96151),('890123',600,'2019-10-23 06:40:21',-37.79975,144.96189),('901234',700,'2019-10-23 06:41:31',37.79978,144.9619);
/*!40000 ALTER TABLE `mark` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `player`
--

DROP TABLE IF EXISTS `player`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `player` (
  `mobile` varchar(45) NOT NULL,
  `username` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `available` tinyint(4) NOT NULL DEFAULT '0',
  `token` char(10) DEFAULT NULL,
  PRIMARY KEY (`mobile`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `player`
--

LOCK TABLES `player` WRITE;
/*!40000 ALTER TABLE `player` DISABLE KEYS */;
INSERT INTO `player` VALUES ('012345','Gigabyte','543210',1,'aaaa'),('0403408927','yiming','666666',1,'JdIUDu'),('0434240637','ddd','111',1,'0I4w8B'),('123456','LI','654321',1,'xg4W'),('234567','DENG','765432',1,'abcd'),('345678','SONG','876543',1,'bcde'),('456789','Alice','987654',1,'aaaa'),('567890','Bob','098765',1,'aaaa'),('678901','Casey','109876',1,'aaaa'),('789012','Devin','210987',1,'aaaa'),('890123','Emily','321098',1,'aaaa'),('901234','FANG','432109',1,'aaaa');
/*!40000 ALTER TABLE `player` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-23 18:55:53
