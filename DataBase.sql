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
) ENGINE=InnoDB AUTO_INCREMENT=2293 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attendance`
--

LOCK TABLES `attendance` WRITE;
/*!40000 ALTER TABLE `attendance` DISABLE KEYS */;
INSERT INTO `attendance` VALUES (1,2,1,25),(2,2,2,22),(3,2,3,23),(4,2,4,33),(5,2,5,30),(6,2,6,29),(7,2,7,0),(8,2,8,0),(9,2,9,0),(10,2,10,0),(11,5,1,0),(12,5,2,0),(13,5,3,0),(14,5,4,0),(15,5,5,0),(16,5,6,0),(17,5,7,0),(18,5,8,0),(19,5,9,0),(20,5,10,0),(21,6,1,0),(22,6,2,0),(23,6,3,0),(24,6,4,0),(25,6,5,0),(26,6,6,0),(27,6,7,0),(28,6,8,0),(29,6,9,0),(30,6,10,0),(31,7,1,0),(32,7,2,0),(33,7,3,0),(34,7,4,0),(35,7,5,0),(36,7,6,0),(37,7,7,0),(38,7,8,0),(39,7,9,0),(40,7,10,0),(41,8,1,0),(42,8,2,0),(43,8,3,0),(44,8,4,0),(45,8,5,0),(46,8,6,0),(47,8,7,0),(48,8,8,0),(49,8,9,0),(50,8,10,0),(51,9,1,0),(52,9,2,0),(53,9,3,0),(54,9,4,0),(55,9,5,0),(56,9,6,0),(57,9,7,0),(58,9,8,0),(59,9,9,0),(60,9,10,0),(61,10,1,0),(62,10,2,0),(63,10,3,0),(64,10,4,0),(65,10,5,0),(66,10,6,0),(67,10,7,0),(68,10,8,0),(69,10,9,0),(70,10,10,0),(71,11,1,0),(72,11,2,0),(73,11,3,0),(74,11,4,0),(75,11,5,0),(76,11,6,0),(77,11,7,0),(78,11,8,0),(79,11,9,0),(80,11,10,0),(81,12,1,0),(82,12,2,0),(83,12,3,0),(84,12,4,0),(85,12,5,0),(86,12,6,0),(87,12,7,0),(88,12,8,0),(89,12,9,0),(90,12,10,0),(91,13,1,0),(92,13,2,0),(93,13,3,0),(94,13,4,0),(95,13,5,0),(96,13,6,0),(97,13,7,0),(98,13,8,0),(99,13,9,0),(100,13,10,0),(101,14,1,0),(102,14,2,0),(103,14,3,0),(104,14,4,0),(105,14,5,0),(106,14,6,0),(107,14,7,0),(108,14,8,0),(109,14,9,0),(110,14,10,0),(1751,14,1,0),(1752,14,2,0),(1753,14,3,0),(1754,14,4,0),(1755,14,5,0),(1756,14,6,0),(1757,14,7,0),(1758,14,8,0),(1759,14,9,0),(1760,14,10,0),(1761,14,1,0),(1762,14,2,0),(1763,14,3,0),(1764,14,4,0),(1765,14,5,0),(1766,14,6,0),(1767,14,7,0),(1768,14,8,0),(1769,14,9,0),(1770,14,10,0),(1771,14,1,0),(1772,14,2,0),(1773,14,3,0),(1774,14,4,0),(1775,14,5,0),(1776,14,6,0),(1777,14,7,0),(1778,14,8,0),(1779,14,9,0),(1780,14,10,0),(1781,14,1,0),(1782,14,2,0),(1783,14,3,0),(1784,14,4,0),(1785,14,5,0),(1786,14,6,0),(1787,14,7,0),(1788,14,8,0),(1789,14,9,0),(1790,14,10,0),(1791,14,1,0),(1792,14,2,0),(1793,14,3,0),(1794,14,4,0),(1795,14,5,0),(1796,14,6,0),(1797,14,7,0),(1798,14,8,0),(1799,14,9,0),(1800,14,10,0),(1801,14,1,0),(1802,14,2,0),(1803,14,3,0),(1804,14,4,0),(1805,14,5,0),(1806,14,6,0),(1807,14,7,0),(1808,14,8,0),(1809,14,9,0),(1810,14,10,0),(1811,14,1,0),(1812,14,2,0),(1813,14,3,0),(1814,14,4,0),(1815,14,5,0),(1816,14,6,0),(1817,14,7,0),(1818,14,8,0),(1819,14,9,0),(1820,14,10,0),(1821,14,1,0),(1822,14,2,0),(1823,14,3,0),(1824,14,4,0),(1825,14,5,0),(1826,14,6,0),(1827,14,7,0),(1828,14,8,0),(1829,14,9,0),(1830,14,10,0),(1831,14,1,0),(1832,14,2,0),(1833,14,3,0),(1834,14,4,0),(1835,14,5,0),(1836,14,6,0),(1837,14,7,0),(1838,14,8,0),(1839,14,9,0),(1840,14,10,0),(1841,14,1,0),(1842,14,2,0),(1843,14,3,0),(1844,14,4,0),(1845,14,5,0),(1846,14,6,0),(1847,14,7,0),(1848,14,8,0),(1849,14,9,0),(1850,14,10,0),(1851,14,1,0),(1852,14,2,0),(1853,14,3,0),(1854,14,4,0),(1855,14,5,0),(1856,14,6,0),(1857,14,7,0),(1858,14,8,0),(1859,14,9,0),(1860,14,10,0),(1861,14,1,0),(1862,14,2,0),(1863,14,3,0),(1864,14,4,0),(1865,14,5,0),(1866,14,6,0),(1867,14,7,0),(1868,14,8,0),(1869,14,9,0),(1870,14,10,0),(1871,14,1,0),(1872,14,2,0),(1873,14,3,0),(1874,14,4,0),(1875,14,5,0),(1876,14,6,0),(1877,14,7,0),(1878,14,8,0),(1879,14,9,0),(1880,14,10,0),(1881,14,1,0),(1882,14,2,0),(1883,14,3,0),(1884,14,4,0),(1885,14,5,0),(1886,14,6,0),(1887,14,7,0),(1888,14,8,0),(1889,14,9,0),(1890,14,10,0),(1891,14,1,0),(1892,14,2,0),(1893,14,3,0),(1894,14,4,0),(1895,14,5,0),(1896,14,6,0),(1897,14,7,0),(1898,14,8,0),(1899,14,9,0),(1900,14,10,0),(1901,14,1,0),(1902,14,2,0),(1903,14,3,0),(1904,14,4,0),(1905,14,5,0),(1906,14,6,0),(1907,14,7,0),(1908,14,8,0),(1909,14,9,0),(1910,14,10,0),(1911,14,1,0),(1912,14,2,0),(1913,14,3,0),(1914,14,4,0),(1915,14,5,0),(1916,14,6,0),(1917,14,7,0),(1918,14,8,0),(1919,14,9,0),(1920,14,10,0),(1921,14,1,0),(1922,14,2,0),(1923,14,3,0),(1924,14,4,0),(1925,14,5,0),(1926,14,6,0),(1927,14,7,0),(1928,14,8,0),(1929,14,9,0),(1930,14,10,0),(1931,14,1,0),(1932,14,2,0),(1933,14,3,0),(1934,14,4,0),(1935,14,5,0),(1936,14,6,0),(1937,14,7,0),(1938,14,8,0),(1939,14,9,0),(1940,14,10,0),(1941,14,1,0),(1942,14,2,0),(1943,14,3,0),(1944,14,4,0),(1945,14,5,0),(1946,14,6,0),(1947,14,7,0),(1948,14,8,0),(1949,14,9,0),(1950,14,10,0),(1951,14,1,0),(1952,14,2,0),(1953,14,3,0),(1954,14,4,0),(1955,14,5,0),(1956,14,6,0),(1957,14,7,0),(1958,14,8,0),(1959,14,9,0),(1960,14,10,0),(2054,14,1,0),(2055,14,2,0),(2056,14,3,0),(2057,14,4,0),(2058,14,5,0),(2059,14,6,0),(2060,14,7,0),(2061,14,8,0),(2062,14,9,0),(2063,14,10,0),(2064,14,1,0),(2065,14,2,0),(2066,14,3,0),(2067,14,4,0),(2068,14,5,0),(2069,14,6,0),(2070,14,7,0),(2071,14,8,0),(2072,14,9,0),(2073,14,10,0),(2074,14,1,0),(2075,14,2,0),(2076,14,3,0),(2077,14,4,0),(2078,14,5,0),(2079,14,6,0),(2080,14,7,0),(2081,14,8,0),(2082,14,9,0),(2083,14,10,0),(2084,14,1,0),(2085,14,2,0),(2086,14,3,0),(2087,14,4,0),(2088,14,5,0),(2089,14,6,0),(2090,14,7,0),(2091,14,8,0),(2092,14,9,0),(2093,14,10,0),(2094,14,1,0),(2095,14,2,0),(2096,14,3,0),(2097,14,4,0),(2098,14,5,0),(2099,14,6,0),(2100,14,7,0),(2101,14,8,0),(2102,14,9,0),(2103,14,10,0),(2104,14,1,0),(2105,14,2,0),(2106,14,3,0),(2107,14,4,0),(2108,14,5,0),(2109,14,6,0),(2110,14,7,0),(2111,14,8,0),(2112,14,9,0),(2113,14,10,0),(2114,14,1,0),(2115,14,2,0),(2116,14,3,0),(2117,14,4,0),(2118,14,5,0),(2119,14,6,0),(2120,14,7,0),(2121,14,8,0),(2122,14,9,0),(2123,14,10,0),(2124,14,1,0),(2125,14,2,0),(2126,14,3,0),(2127,14,4,0),(2128,14,5,0),(2129,14,6,0),(2130,14,7,0),(2131,14,8,0),(2132,14,9,0),(2133,14,10,0),(2134,14,1,0),(2135,14,2,0),(2136,14,3,0),(2137,14,4,0),(2138,14,5,0),(2139,14,6,0),(2140,14,7,0),(2141,14,8,0),(2142,14,9,0),(2143,14,10,0),(2144,14,1,0),(2145,14,2,0),(2146,14,3,0),(2147,14,4,0),(2148,14,5,0),(2149,14,6,0),(2150,14,7,0),(2151,14,8,0),(2152,14,9,0),(2153,14,1,0),(2154,14,2,0),(2155,14,3,0),(2156,14,4,0),(2157,14,5,0),(2158,14,6,0),(2159,14,7,0),(2160,14,8,0),(2161,14,9,0),(2162,14,10,0),(2163,225,1,0),(2164,225,2,0),(2165,225,3,0),(2166,225,4,0),(2167,225,5,0),(2168,225,6,0),(2169,225,7,0),(2170,225,8,0),(2171,225,9,0),(2172,225,10,0),(2173,226,1,0),(2174,226,2,0),(2175,226,3,0),(2176,226,4,0),(2177,226,5,0),(2178,226,6,0),(2179,226,7,0),(2180,226,8,0),(2181,226,9,0),(2182,226,10,0),(2183,227,1,0),(2184,227,2,0),(2185,227,3,0),(2186,227,4,0),(2187,227,5,0),(2188,227,6,0),(2189,227,7,0),(2190,227,8,0),(2191,227,9,0),(2192,227,10,0),(2193,228,1,0),(2194,228,2,0),(2195,228,3,0),(2196,228,4,0),(2197,228,5,0),(2198,228,6,0),(2199,228,7,0),(2200,228,8,0),(2201,228,9,0),(2202,228,10,0),(2203,229,1,0),(2204,229,2,0),(2205,229,3,0),(2206,229,4,0),(2207,229,5,0),(2208,229,6,0),(2209,229,7,0),(2210,229,8,0),(2211,229,9,0),(2212,229,10,0),(2213,230,1,0),(2214,230,2,0),(2215,230,3,0),(2216,230,4,0),(2217,230,5,0),(2218,230,6,0),(2219,230,7,0),(2220,230,8,0),(2221,230,9,0),(2222,230,10,0),(2223,231,1,0),(2224,231,2,0),(2225,231,3,0),(2226,231,4,0),(2227,231,5,0),(2228,231,6,0),(2229,231,7,0),(2230,231,8,0),(2231,231,9,0),(2232,231,10,0),(2233,232,1,0),(2234,232,2,0),(2235,232,3,0),(2236,232,4,0),(2237,232,5,0),(2238,232,6,0),(2239,232,7,0),(2240,232,8,0),(2241,232,9,0),(2242,232,10,0),(2243,233,1,0),(2244,233,2,0),(2245,233,3,0),(2246,233,4,0),(2247,233,5,0),(2248,233,6,0),(2249,233,7,0),(2250,233,8,0),(2251,233,9,0),(2252,233,10,0),(2253,234,1,0),(2254,234,2,0),(2255,234,3,0),(2256,234,4,0),(2257,234,5,0),(2258,234,6,0),(2259,234,7,0),(2260,234,8,0),(2261,234,9,0),(2262,234,10,0),(2263,235,1,0),(2264,235,2,0),(2265,235,3,0),(2266,235,4,0),(2267,235,5,0),(2268,235,6,0),(2269,235,7,0),(2270,235,8,0),(2271,235,9,0),(2272,235,10,0),(2273,236,1,0),(2274,236,2,0),(2275,236,3,0),(2276,236,4,0),(2277,236,5,0),(2278,236,6,0),(2279,236,7,0),(2280,236,8,0),(2281,236,9,0),(2282,236,10,0),(2283,237,1,0),(2284,237,2,0),(2285,237,3,0),(2286,237,4,0),(2287,237,5,0),(2288,237,6,0),(2289,237,7,0),(2290,237,8,0),(2291,237,9,0),(2292,237,10,0);
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
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `childrens`
--

LOCK TABLES `childrens` WRITE;
/*!40000 ALTER TABLE `childrens` DISABLE KEYS */;
INSERT INTO `childrens` VALUES (1,1,1,'Александров','Вася',NULL),(3,1,2,'Смирнов','Павел','Дминтриевич'),(4,2,6,'Каверин','Толик','Анатольевиич'),(7,2,2,'Пупкин','Вася',NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=238 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `date`
--

LOCK TABLES `date` WRITE;
/*!40000 ALTER TABLE `date` DISABLE KEYS */;
INSERT INTO `date` VALUES (1,'2019-03-28'),(2,'2019-03-29'),(5,'2019-03-30'),(6,'2019-03-31'),(7,'2019-04-01'),(8,'2019-04-02'),(9,'2019-04-03'),(10,'2019-04-04'),(11,'2019-04-05'),(12,'2019-04-07'),(13,'2019-04-08'),(14,'2019-04-09'),(225,'2019-04-10'),(226,'2019-04-11'),(227,'2019-04-12'),(228,'2019-04-13'),(229,'2019-04-14'),(230,'2019-04-15'),(231,'2019-04-16'),(232,'2019-04-17'),(233,'2019-04-18'),(234,'2019-04-19'),(235,'2019-04-20'),(236,'2019-04-21'),(237,'2019-04-22');
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
  `ID` int(11) NOT NULL AUTO_INCREMENT,
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredients_composition`
--

LOCK TABLES `ingredients_composition` WRITE;
/*!40000 ALTER TABLE `ingredients_composition` DISABLE KEYS */;
INSERT INTO `ingredients_composition` VALUES (1,2,100,100,'70',10,100,100),(3,2,100,100,NULL,NULL,NULL,NULL);
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
  `DateID` int(11) NOT NULL,
  `DishId` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `DIT_idx` (`DishId`),
  KEY `DID_idx` (`DateID`),
  KEY `DateID_idx` (`DateID`),
  CONSTRAINT `DIT` FOREIGN KEY (`DishId`) REFERENCES `dishs` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `DateID` FOREIGN KEY (`DateID`) REFERENCES `attendance` (`DateID`) ON DELETE CASCADE ON UPDATE CASCADE
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
  PRIMARY KEY (`GroupID`),
  CONSTRAINT `Groups` FOREIGN KEY (`GroupID`) REFERENCES `groups` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `totalchildren`
--

LOCK TABLES `totalchildren` WRITE;
/*!40000 ALTER TABLE `totalchildren` DISABLE KEYS */;
INSERT INTO `totalchildren` VALUES (1,30),(2,30),(3,30),(4,30),(5,30),(6,30),(7,1),(8,30),(9,30),(10,30);
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

-- Dump completed on 2019-04-22  9:41:50
