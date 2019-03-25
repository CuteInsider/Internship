CREATE DATABASE  IF NOT EXISTS `mdou_menu` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `mdou_menu`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: mdou_menu
-- ------------------------------------------------------
-- Server version	5.7.19-log

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
-- Table structure for table `agegroup`
--

DROP TABLE IF EXISTS `agegroup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `agegroup` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `AgeGroup` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agegroup`
--

LOCK TABLES `agegroup` WRITE;
/*!40000 ALTER TABLE `agegroup` DISABLE KEYS */;
INSERT INTO `agegroup` VALUES (1,'0-3 мес.'),(2,'4-6 мес.'),(3,'7-12 мес.'),(4,'1-2 г.'),(5,'2-3 г.'),(6,'3-7 г.');
/*!40000 ALTER TABLE `agegroup` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `attendance`
--

DROP TABLE IF EXISTS `attendance`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `attendance` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Date` date NOT NULL,
  `GroupID` int(11) NOT NULL,
  `ActuallyChildrenAmount` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `TC_idx` (`GroupID`),
  CONSTRAINT `Group` FOREIGN KEY (`GroupID`) REFERENCES `groups` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `TC` FOREIGN KEY (`GroupID`) REFERENCES `totalchildren` (`GroupID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attendance`
--

LOCK TABLES `attendance` WRITE;
/*!40000 ALTER TABLE `attendance` DISABLE KEYS */;
INSERT INTO `attendance` VALUES (1,'2019-03-25',2,25);
/*!40000 ALTER TABLE `attendance` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `childrens`
--

DROP TABLE IF EXISTS `childrens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `childrens` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `IDGroup` int(11) DEFAULT NULL,
  `IDAgeGroup` int(11) DEFAULT NULL,
  `SecondName` varchar(45) DEFAULT NULL,
  `FistName` varchar(45) DEFAULT NULL,
  `FatherName` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `CAG_idx` (`IDAgeGroup`),
  CONSTRAINT `CAG` FOREIGN KEY (`IDAgeGroup`) REFERENCES `agegroup` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `childrens`
--

LOCK TABLES `childrens` WRITE;
/*!40000 ALTER TABLE `childrens` DISABLE KEYS */;
INSERT INTO `childrens` VALUES (1,2,1,'Александров','Вася',NULL);
/*!40000 ALTER TABLE `childrens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `composition`
--

DROP TABLE IF EXISTS `composition`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `composition` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `DishID` int(11) NOT NULL,
  `IngredientID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `DID2_idx` (`DishID`),
  KEY `IID_idx` (`IngredientID`),
  CONSTRAINT `DID2` FOREIGN KEY (`DishID`) REFERENCES `dishs` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `IID` FOREIGN KEY (`IngredientID`) REFERENCES `ingredients` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `composition`
--

LOCK TABLES `composition` WRITE;
/*!40000 ALTER TABLE `composition` DISABLE KEYS */;
/*!40000 ALTER TABLE `composition` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dinnertype`
--

DROP TABLE IF EXISTS `dinnertype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dinnertype` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Type` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dinnertype`
--

LOCK TABLES `dinnertype` WRITE;
/*!40000 ALTER TABLE `dinnertype` DISABLE KEYS */;
/*!40000 ALTER TABLE `dinnertype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dishs`
--

DROP TABLE IF EXISTS `dishs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dishs` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `DinnerType` int(11) NOT NULL,
  `DishName` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `DID_idx` (`DinnerType`),
  CONSTRAINT `DTID` FOREIGN KEY (`DinnerType`) REFERENCES `dinnertype` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dishs`
--

LOCK TABLES `dishs` WRITE;
/*!40000 ALTER TABLE `dishs` DISABLE KEYS */;
/*!40000 ALTER TABLE `dishs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `groups`
--

DROP TABLE IF EXISTS `groups`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `groups` (
  `ID` int(11) NOT NULL,
  `GroupName` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `groups`
--

LOCK TABLES `groups` WRITE;
/*!40000 ALTER TABLE `groups` DISABLE KEYS */;
INSERT INTO `groups` VALUES (2,'№2 \"Кроха\"'),(3,'№3 \"Цыплята\"'),(5,'№5 \"Звездочки\"'),(6,'№6 \"Радуга\"'),(7,'№7 \"Капелька\"'),(9,'№9 \"Цветик-семицветик\"'),(10,'№10 \"Кораблик\"'),(12,'№12 \"Солнышко\"'),(13,'№13 \"Цветные карандаши\"'),(14,'№14 \"Пчелки\"');
/*!40000 ALTER TABLE `groups` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingredients`
--

DROP TABLE IF EXISTS `ingredients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ingredients` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Ingredient` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredients`
--

LOCK TABLES `ingredients` WRITE;
/*!40000 ALTER TABLE `ingredients` DISABLE KEYS */;
/*!40000 ALTER TABLE `ingredients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingredients_composition`
--

DROP TABLE IF EXISTS `ingredients_composition`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ingredients_composition` (
  `ID` int(11) NOT NULL,
  `ingredientID` int(11) NOT NULL,
  `Energy(kkal)` int(11) DEFAULT NULL,
  `Protein,g` int(11) DEFAULT NULL,
  `animalProtein(%)` varchar(3) DEFAULT NULL,
  `g/kg_BodyMass` float DEFAULT NULL,
  `Fat,g` float DEFAULT NULL,
  `Carbohydrates, g` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `IID2_idx` (`ingredientID`),
  CONSTRAINT `IID2` FOREIGN KEY (`ingredientID`) REFERENCES `ingredients` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredients_composition`
--

LOCK TABLES `ingredients_composition` WRITE;
/*!40000 ALTER TABLE `ingredients_composition` DISABLE KEYS */;
/*!40000 ALTER TABLE `ingredients_composition` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menu`
--

DROP TABLE IF EXISTS `menu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `menu` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `attendanceID` int(11) DEFAULT NULL,
  `DishId` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `DIT_idx` (`DishId`),
  CONSTRAINT `DIT` FOREIGN KEY (`DishId`) REFERENCES `dishs` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menu`
--

LOCK TABLES `menu` WRITE;
/*!40000 ALTER TABLE `menu` DISABLE KEYS */;
/*!40000 ALTER TABLE `menu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `normsforag`
--

DROP TABLE IF EXISTS `normsforag`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `normsforag` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `IDAgeGroup` int(11) NOT NULL,
  `Energy(kkal)` int(11) DEFAULT NULL,
  `Protein,g` int(11) DEFAULT NULL,
  `animalProtein(%)` varchar(3) DEFAULT NULL,
  `g/kg_BodyMass` float DEFAULT NULL,
  `Fat,g` float DEFAULT NULL,
  `Carbohydrates, g` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `AG_idx` (`IDAgeGroup`),
  CONSTRAINT `AG` FOREIGN KEY (`IDAgeGroup`) REFERENCES `agegroup` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `normsforag`
--

LOCK TABLES `normsforag` WRITE;
/*!40000 ALTER TABLE `normsforag` DISABLE KEYS */;
/*!40000 ALTER TABLE `normsforag` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `totalchildren`
--

DROP TABLE IF EXISTS `totalchildren`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `totalchildren` (
  `GroupID` int(11) NOT NULL,
  `TotalChildren` int(11) NOT NULL,
  PRIMARY KEY (`GroupID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `totalchildren`
--

LOCK TABLES `totalchildren` WRITE;
/*!40000 ALTER TABLE `totalchildren` DISABLE KEYS */;
INSERT INTO `totalchildren` VALUES (2,30),(3,30),(5,30),(6,30),(7,30),(9,30),(10,30),(12,30),(13,30),(14,30);
/*!40000 ALTER TABLE `totalchildren` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `Login` varchar(40) NOT NULL,
  `Password` varchar(45) NOT NULL,
  `Role` varchar(20) NOT NULL,
  `State` varchar(3) NOT NULL,
  PRIMARY KEY (`Login`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES ('Admin','qwerty','A','YES');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-03-26  1:10:10
