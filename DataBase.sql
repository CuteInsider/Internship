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
  `DateID` int(11) DEFAULT NULL,
  `GroupID` int(11) NOT NULL,
  `ActuallyChildrenAmount` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `TC_idx` (`GroupID`),
  KEY `Date_idx` (`DateID`),
  KEY `DID_idx` (`DateID`),
  CONSTRAINT `DID` FOREIGN KEY (`DateID`) REFERENCES `date` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `TC` FOREIGN KEY (`GroupID`) REFERENCES `totalchildren` (`GroupID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=81 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attendance`
--

LOCK TABLES `attendance` WRITE;
/*!40000 ALTER TABLE `attendance` DISABLE KEYS */;
INSERT INTO `attendance` VALUES (1,2,1,25),(2,2,2,22),(3,2,3,23),(4,2,4,33),(5,2,5,30),(6,2,6,NULL),(7,2,7,NULL),(8,2,8,NULL),(9,2,9,NULL),(10,2,10,NULL),(11,5,1,NULL),(12,5,2,NULL),(13,5,3,NULL),(14,5,4,NULL),(15,5,5,NULL),(16,5,6,NULL),(17,5,7,NULL),(18,5,8,NULL),(19,5,9,NULL),(20,5,10,NULL),(21,6,1,NULL),(22,6,2,NULL),(23,6,3,NULL),(24,6,4,NULL),(25,6,5,NULL),(26,6,6,NULL),(27,6,7,NULL),(28,6,8,NULL),(29,6,9,NULL),(30,6,10,NULL),(31,7,1,NULL),(32,7,2,NULL),(33,7,3,NULL),(34,7,4,NULL),(35,7,5,NULL),(36,7,6,NULL),(37,7,7,NULL),(38,7,8,NULL),(39,7,9,NULL),(40,7,10,NULL),(41,8,1,NULL),(42,8,2,NULL),(43,8,3,NULL),(44,8,4,NULL),(45,8,5,NULL),(46,8,6,NULL),(47,8,7,NULL),(48,8,8,NULL),(49,8,9,NULL),(50,8,10,NULL),(51,9,1,NULL),(52,9,2,NULL),(53,9,3,NULL),(54,9,4,NULL),(55,9,5,NULL),(56,9,6,NULL),(57,9,7,NULL),(58,9,8,NULL),(59,9,9,NULL),(60,9,10,NULL),(61,10,1,NULL),(62,10,2,NULL),(63,10,3,NULL),(64,10,4,NULL),(65,10,5,NULL),(66,10,6,NULL),(67,10,7,NULL),(68,10,8,NULL),(69,10,9,NULL),(70,10,10,NULL),(71,11,1,NULL),(72,11,2,NULL),(73,11,3,NULL),(74,11,4,NULL),(75,11,5,NULL),(76,11,6,NULL),(77,11,7,NULL),(78,11,8,NULL),(79,11,9,NULL),(80,11,10,NULL);
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
  KEY `CGrouup_idx` (`IDGroup`),
  CONSTRAINT `CAG` FOREIGN KEY (`IDAgeGroup`) REFERENCES `agegroup` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `CGroups` FOREIGN KEY (`IDGroup`) REFERENCES `groups` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `childrens`
--

LOCK TABLES `childrens` WRITE;
/*!40000 ALTER TABLE `childrens` DISABLE KEYS */;
INSERT INTO `childrens` VALUES (1,1,1,'Александров','Вася',NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `composition`
--

LOCK TABLES `composition` WRITE;
/*!40000 ALTER TABLE `composition` DISABLE KEYS */;
INSERT INTO `composition` VALUES (2,1,2),(3,1,3);
/*!40000 ALTER TABLE `composition` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `date`
--

DROP TABLE IF EXISTS `date`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `date` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Date` date NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `date`
--

LOCK TABLES `date` WRITE;
/*!40000 ALTER TABLE `date` DISABLE KEYS */;
INSERT INTO `date` VALUES (1,'2019-03-28'),(2,'2019-03-29'),(5,'2019-03-30'),(6,'2019-03-31'),(7,'2019-04-01'),(8,'2019-04-02'),(9,'2019-04-03'),(10,'2019-04-04'),(11,'2019-04-05');
/*!40000 ALTER TABLE `date` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dinnertype`
--

DROP TABLE IF EXISTS `dinnertype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dinnertype` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Type` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dinnertype`
--

LOCK TABLES `dinnertype` WRITE;
/*!40000 ALTER TABLE `dinnertype` DISABLE KEYS */;
INSERT INTO `dinnertype` VALUES (1,'Завтрак'),(2,'Обед'),(3,'Ужин');
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
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dishs`
--

LOCK TABLES `dishs` WRITE;
/*!40000 ALTER TABLE `dishs` DISABLE KEYS */;
INSERT INTO `dishs` VALUES (1,1,'Каша'),(2,1,'Компот'),(3,2,'Суп'),(4,2,'Чай'),(5,3,'Картошка с Котлетами'),(6,3,'Чай');
/*!40000 ALTER TABLE `dishs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `groups`
--

DROP TABLE IF EXISTS `groups`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `groups` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `GroupName` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `groups`
--

LOCK TABLES `groups` WRITE;
/*!40000 ALTER TABLE `groups` DISABLE KEYS */;
INSERT INTO `groups` VALUES (1,'№2 \"Кроха\"'),(2,'№3 \"Цыплята\"'),(3,'№5 \"Звездочки\"'),(4,'№6 \"Радуга\"'),(5,'№7 \"Капелька\"'),(6,'№9 \"Цветик-семицветик\"'),(7,'№10 \"Кораблик\"'),(8,'№12 \"Солнышко\"'),(9,'№13 \"Цветные карандаши\"'),(10,'№14 \"Пчелки\"');
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredients`
--

LOCK TABLES `ingredients` WRITE;
/*!40000 ALTER TABLE `ingredients` DISABLE KEYS */;
INSERT INTO `ingredients` VALUES (2,'Крупа'),(3,'Молоко');
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
  KEY `AID_idx` (`attendanceID`),
  CONSTRAINT `AID` FOREIGN KEY (`attendanceID`) REFERENCES `attendance` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
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
INSERT INTO `totalchildren` VALUES (1,30),(2,30),(3,30),(4,30),(5,30),(6,30),(7,30),(8,30),(9,30),(10,30);
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

-- Dump completed on 2019-04-05 15:04:12
