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
  KEY `Date_idx` (`Date`),
  CONSTRAINT `TC` FOREIGN KEY (`GroupID`) REFERENCES `totalchildren` (`GroupID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3503 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attendance`
--

LOCK TABLES `attendance` WRITE;
/*!40000 ALTER TABLE `attendance` DISABLE KEYS */;
INSERT INTO `attendance` VALUES (1,'2019-03-29',1,25),(2,'2019-03-29',2,22),(3,'2019-03-29',3,23),(4,'2019-03-29',4,33),(5,'2019-03-29',5,30),(6,'2019-03-29',6,29),(7,'2019-03-29',7,0),(8,'2019-03-29',8,0),(9,'2019-03-29',9,0),(10,'2019-03-29',10,0),(31,'2019-04-01',1,0),(32,'2019-04-01',2,0),(33,'2019-04-01',3,0),(34,'2019-04-01',4,0),(35,'2019-04-01',5,0),(36,'2019-04-01',6,0),(37,'2019-04-01',7,0),(38,'2019-04-01',8,0),(39,'2019-04-01',9,0),(40,'2019-04-01',10,0),(41,'2019-04-02',1,0),(42,'2019-04-02',2,0),(43,'2019-04-02',3,0),(44,'2019-04-02',4,0),(45,'2019-04-02',5,0),(46,'2019-04-02',6,0),(47,'2019-04-02',7,0),(48,'2019-04-02',8,0),(49,'2019-04-02',9,0),(50,'2019-04-02',10,0),(51,'2019-04-03',1,0),(52,'2019-04-03',2,0),(53,'2019-04-03',3,0),(54,'2019-04-03',4,0),(55,'2019-04-03',5,0),(56,'2019-04-03',6,0),(57,'2019-04-03',7,0),(58,'2019-04-03',8,0),(59,'2019-04-03',9,0),(60,'2019-04-03',10,0),(61,'2019-04-04',1,0),(62,'2019-04-04',2,0),(63,'2019-04-04',3,0),(64,'2019-04-04',4,0),(65,'2019-04-04',5,0),(66,'2019-04-04',6,0),(67,'2019-04-04',7,0),(68,'2019-04-04',8,0),(69,'2019-04-04',9,0),(70,'2019-04-04',10,0),(71,'2019-04-05',1,0),(72,'2019-04-05',2,0),(73,'2019-04-05',3,0),(74,'2019-04-05',4,0),(75,'2019-04-05',5,0),(76,'2019-04-05',6,0),(77,'2019-04-05',7,0),(78,'2019-04-05',8,0),(79,'2019-04-05',9,0),(80,'2019-04-05',10,0),(91,'2019-04-08',1,0),(92,'2019-04-08',2,0),(93,'2019-04-08',3,0),(94,'2019-04-08',4,0),(95,'2019-04-08',5,0),(96,'2019-04-08',6,0),(97,'2019-04-08',7,0),(98,'2019-04-08',8,0),(99,'2019-04-08',9,0),(100,'2019-04-08',10,0),(101,'2019-04-09',1,0),(102,'2019-04-09',2,0),(103,'2019-04-09',3,0),(104,'2019-04-09',4,0),(105,'2019-04-09',5,0),(106,'2019-04-09',6,0),(107,'2019-04-09',7,0),(108,'2019-04-09',8,0),(109,'2019-04-09',9,0),(110,'2019-04-09',10,0),(2163,'2019-04-10',1,0),(2164,'2019-04-10',2,0),(2165,'2019-04-10',3,0),(2166,'2019-04-10',4,0),(2167,'2019-04-10',5,0),(2168,'2019-04-10',6,0),(2169,'2019-04-10',7,0),(2170,'2019-04-10',8,0),(2171,'2019-04-10',9,0),(2172,'2019-04-10',10,0),(2173,'2019-04-11',1,0),(2174,'2019-04-11',2,0),(2175,'2019-04-11',3,0),(2176,'2019-04-11',4,0),(2177,'2019-04-11',5,0),(2178,'2019-04-11',6,0),(2179,'2019-04-11',7,0),(2180,'2019-04-11',8,0),(2181,'2019-04-11',9,0),(2182,'2019-04-11',10,0),(2183,'2019-04-12',1,0),(2184,'2019-04-12',2,0),(2185,'2019-04-12',3,0),(2186,'2019-04-12',4,0),(2187,'2019-04-12',5,0),(2188,'2019-04-12',6,0),(2189,'2019-04-12',7,0),(2190,'2019-04-12',8,0),(2191,'2019-04-12',9,0),(2192,'2019-04-12',10,0),(2213,'2019-04-15',1,0),(2214,'2019-04-15',2,0),(2215,'2019-04-15',3,0),(2216,'2019-04-15',4,0),(2217,'2019-04-15',5,0),(2218,'2019-04-15',6,0),(2219,'2019-04-15',7,0),(2220,'2019-04-15',8,0),(2221,'2019-04-15',9,0),(2222,'2019-04-15',10,0),(2223,'2019-04-16',1,0),(2224,'2019-04-16',2,0),(2225,'2019-04-16',3,0),(2226,'2019-04-16',4,0),(2227,'2019-04-16',5,0),(2228,'2019-04-16',6,0),(2229,'2019-04-16',7,0),(2230,'2019-04-16',8,0),(2231,'2019-04-16',9,0),(2232,'2019-04-16',10,0),(2233,'2019-04-17',1,0),(2234,'2019-04-17',2,0),(2235,'2019-04-17',3,0),(2236,'2019-04-17',4,0),(2237,'2019-04-17',5,0),(2238,'2019-04-17',6,0),(2239,'2019-04-17',7,0),(2240,'2019-04-17',8,0),(2241,'2019-04-17',9,0),(2242,'2019-04-17',10,0),(2243,'2019-04-18',1,0),(2244,'2019-04-18',2,0),(2245,'2019-04-18',3,0),(2246,'2019-04-18',4,0),(2247,'2019-04-18',5,0),(2248,'2019-04-18',6,0),(2249,'2019-04-18',7,0),(2250,'2019-04-18',8,0),(2251,'2019-04-18',9,0),(2252,'2019-04-18',10,0),(2253,'2019-04-19',1,0),(2254,'2019-04-19',2,0),(2255,'2019-04-19',3,0),(2256,'2019-04-19',4,0),(2257,'2019-04-19',5,0),(2258,'2019-04-19',6,0),(2259,'2019-04-19',7,0),(2260,'2019-04-19',8,0),(2261,'2019-04-19',9,0),(2262,'2019-04-19',10,0),(2283,'2019-04-22',1,0),(2284,'2019-04-22',2,0),(2285,'2019-04-22',3,0),(2286,'2019-04-22',4,0),(2287,'2019-04-22',5,0),(2288,'2019-04-22',6,0),(2289,'2019-04-22',7,0),(2290,'2019-04-22',8,0),(2291,'2019-04-22',9,0),(2292,'2019-04-22',10,0),(2293,'2019-04-23',1,0),(2294,'2019-04-23',2,0),(2295,'2019-04-23',3,0),(2296,'2019-04-23',4,0),(2297,'2019-04-23',5,0),(2298,'2019-04-23',6,0),(2299,'2019-04-23',7,0),(2300,'2019-04-23',8,0),(2301,'2019-04-23',9,0),(2302,'2019-04-23',10,0),(2303,'2019-04-24',1,0),(2304,'2019-04-24',2,0),(2305,'2019-04-24',3,0),(2306,'2019-04-24',4,0),(2307,'2019-04-24',5,0),(2308,'2019-04-24',6,0),(2309,'2019-04-24',7,0),(2310,'2019-04-24',8,0),(2311,'2019-04-24',9,0),(2312,'2019-04-24',10,0),(2313,'2019-04-25',1,0),(2314,'2019-04-25',2,0),(2315,'2019-04-25',3,0),(2316,'2019-04-25',4,0),(2317,'2019-04-25',5,0),(2318,'2019-04-25',6,0),(2319,'2019-04-25',7,0),(2320,'2019-04-25',8,0),(2321,'2019-04-25',9,0),(2322,'2019-04-25',10,0),(2323,'2019-04-26',1,0),(2324,'2019-04-26',2,0),(2325,'2019-04-26',3,0),(2326,'2019-04-26',4,0),(2327,'2019-04-26',5,0),(2328,'2019-04-26',6,0),(2329,'2019-04-26',7,0),(2330,'2019-04-26',8,0),(2331,'2019-04-26',9,0),(2332,'2019-04-26',10,0),(2353,'2019-04-29',1,0),(2354,'2019-04-29',2,0),(2355,'2019-04-29',3,0),(2356,'2019-04-29',4,0),(2357,'2019-04-29',5,0),(2358,'2019-04-29',6,0),(2359,'2019-04-29',7,0),(2360,'2019-04-29',8,0),(2361,'2019-04-29',9,0),(2362,'2019-04-29',10,0),(2363,'2019-04-30',1,0),(2364,'2019-04-30',2,0),(2365,'2019-04-30',3,0),(2366,'2019-04-30',4,0),(2367,'2019-04-30',5,0),(2368,'2019-04-30',6,0),(2369,'2019-04-30',7,0),(2370,'2019-04-30',8,0),(2371,'2019-04-30',9,0),(2372,'2019-04-30',10,0),(2373,'2019-05-01',1,0),(2374,'2019-05-01',2,0),(2375,'2019-05-01',3,0),(2376,'2019-05-01',4,0),(2377,'2019-05-01',5,0),(2378,'2019-05-01',6,0),(2379,'2019-05-01',7,0),(2380,'2019-05-01',8,0),(2381,'2019-05-01',9,0),(2382,'2019-05-01',10,0),(2383,'2019-05-02',1,0),(2384,'2019-05-02',2,0),(2385,'2019-05-02',3,0),(2386,'2019-05-02',4,0),(2387,'2019-05-02',5,0),(2388,'2019-05-02',6,0),(2389,'2019-05-02',7,0),(2390,'2019-05-02',8,0),(2391,'2019-05-02',9,0),(2392,'2019-05-02',10,0),(3112,'2019-05-03',1,0),(3113,'2019-05-03',2,0),(3114,'2019-05-03',3,0),(3115,'2019-05-03',4,0),(3116,'2019-05-03',5,0),(3117,'2019-05-03',6,0),(3118,'2019-05-03',7,0),(3119,'2019-05-03',8,0),(3120,'2019-05-03',9,0),(3121,'2019-05-03',10,0),(3143,'2019-05-06',1,0),(3144,'2019-05-06',2,0),(3145,'2019-05-06',3,0),(3146,'2019-05-06',4,0),(3147,'2019-05-06',5,0),(3148,'2019-05-06',6,0),(3149,'2019-05-06',7,0),(3150,'2019-05-06',8,0),(3151,'2019-05-06',9,0),(3152,'2019-05-06',10,0),(3153,'2019-05-07',1,0),(3154,'2019-05-07',2,0),(3155,'2019-05-07',3,0),(3156,'2019-05-07',4,0),(3157,'2019-05-07',5,0),(3158,'2019-05-07',6,0),(3159,'2019-05-07',7,0),(3160,'2019-05-07',8,0),(3161,'2019-05-07',9,0),(3162,'2019-05-07',10,0),(3163,'2019-05-08',1,0),(3164,'2019-05-08',2,0),(3165,'2019-05-08',3,0),(3166,'2019-05-08',4,0),(3167,'2019-05-08',5,0),(3168,'2019-05-08',6,0),(3169,'2019-05-08',7,0),(3170,'2019-05-08',8,0),(3171,'2019-05-08',9,0),(3172,'2019-05-08',10,0),(3173,'2019-05-09',1,0),(3174,'2019-05-09',2,0),(3175,'2019-05-09',3,0),(3176,'2019-05-09',4,0),(3177,'2019-05-09',5,0),(3178,'2019-05-09',6,0),(3179,'2019-05-09',7,0),(3180,'2019-05-09',8,0),(3181,'2019-05-09',9,0),(3182,'2019-05-09',10,0),(3183,'2019-05-10',1,0),(3184,'2019-05-10',2,0),(3185,'2019-05-10',3,0),(3186,'2019-05-10',4,0),(3187,'2019-05-10',5,0),(3188,'2019-05-10',6,0),(3189,'2019-05-10',7,0),(3190,'2019-05-10',8,0),(3191,'2019-05-10',9,0),(3192,'2019-05-10',10,0),(3213,'2019-05-13',1,0),(3214,'2019-05-13',2,0),(3215,'2019-05-13',3,0),(3216,'2019-05-13',4,0),(3217,'2019-05-13',5,0),(3218,'2019-05-13',6,0),(3219,'2019-05-13',7,0),(3220,'2019-05-13',8,0),(3221,'2019-05-13',9,0),(3222,'2019-05-13',10,0),(3223,'2019-05-14',1,0),(3224,'2019-05-14',2,0),(3225,'2019-05-14',3,0),(3226,'2019-05-14',4,0),(3227,'2019-05-14',5,0),(3228,'2019-05-14',6,0),(3229,'2019-05-14',7,0),(3230,'2019-05-14',8,0),(3231,'2019-05-14',9,0),(3232,'2019-05-14',10,0),(3233,'2019-05-15',1,0),(3234,'2019-05-15',2,0),(3235,'2019-05-15',3,0),(3236,'2019-05-15',4,0),(3237,'2019-05-15',5,0),(3238,'2019-05-15',6,0),(3239,'2019-05-15',7,0),(3240,'2019-05-15',8,0),(3241,'2019-05-15',9,0),(3242,'2019-05-15',10,0),(3243,'2019-05-16',1,0),(3244,'2019-05-16',2,0),(3245,'2019-05-16',3,0),(3246,'2019-05-16',4,0),(3247,'2019-05-16',5,0),(3248,'2019-05-16',6,0),(3249,'2019-05-16',7,0),(3250,'2019-05-16',8,0),(3251,'2019-05-16',9,0),(3252,'2019-05-16',10,0),(3253,'2019-05-17',1,0),(3254,'2019-05-17',2,0),(3255,'2019-05-17',3,0),(3256,'2019-05-17',4,0),(3257,'2019-05-17',5,0),(3258,'2019-05-17',6,0),(3259,'2019-05-17',7,0),(3260,'2019-05-17',8,0),(3261,'2019-05-17',9,0),(3262,'2019-05-17',10,0),(3283,'2019-05-20',1,0),(3284,'2019-05-20',2,0),(3285,'2019-05-20',3,0),(3286,'2019-05-20',4,0),(3287,'2019-05-20',5,0),(3288,'2019-05-20',6,0),(3289,'2019-05-20',7,0),(3290,'2019-05-20',8,0),(3291,'2019-05-20',9,0),(3292,'2019-05-20',10,0),(3293,'2019-05-21',1,0),(3294,'2019-05-21',2,0),(3295,'2019-05-21',3,0),(3296,'2019-05-21',4,0),(3297,'2019-05-21',5,0),(3298,'2019-05-21',6,0),(3299,'2019-05-21',7,0),(3300,'2019-05-21',8,0),(3301,'2019-05-21',9,0),(3302,'2019-05-21',10,0),(3303,'2019-05-22',1,0),(3304,'2019-05-22',2,0),(3305,'2019-05-22',3,0),(3306,'2019-05-22',4,0),(3307,'2019-05-22',5,0),(3308,'2019-05-22',6,0),(3309,'2019-05-22',7,0),(3310,'2019-05-22',8,0),(3311,'2019-05-22',9,0),(3312,'2019-05-22',10,0),(3313,'2019-05-23',1,0),(3314,'2019-05-23',2,0),(3315,'2019-05-23',3,0),(3316,'2019-05-23',4,0),(3317,'2019-05-23',5,0),(3318,'2019-05-23',6,0),(3319,'2019-05-23',7,0),(3320,'2019-05-23',8,0),(3321,'2019-05-23',9,0),(3322,'2019-05-23',10,0),(3323,'2019-05-24',1,0),(3324,'2019-05-24',2,0),(3325,'2019-05-24',3,0),(3326,'2019-05-24',4,0),(3327,'2019-05-24',5,0),(3328,'2019-05-24',6,0),(3329,'2019-05-24',7,0),(3330,'2019-05-24',8,0),(3331,'2019-05-24',9,0),(3332,'2019-05-24',10,0),(3353,'2019-05-27',1,0),(3354,'2019-05-27',2,0),(3355,'2019-05-27',3,0),(3356,'2019-05-27',4,0),(3357,'2019-05-27',5,0),(3358,'2019-05-27',6,0),(3359,'2019-05-27',7,0),(3360,'2019-05-27',8,0),(3361,'2019-05-27',9,0),(3362,'2019-05-27',10,0),(3363,'2019-05-28',1,0),(3364,'2019-05-28',2,0),(3365,'2019-05-28',3,0),(3366,'2019-05-28',4,0),(3367,'2019-05-28',5,0),(3368,'2019-05-28',6,0),(3369,'2019-05-28',7,0),(3370,'2019-05-28',8,0),(3371,'2019-05-28',9,0),(3372,'2019-05-28',10,0),(3373,'2019-05-29',1,0),(3374,'2019-05-29',2,0),(3375,'2019-05-29',3,0),(3376,'2019-05-29',4,0),(3377,'2019-05-29',5,0),(3378,'2019-05-29',6,0),(3379,'2019-05-29',7,0),(3380,'2019-05-29',8,0),(3381,'2019-05-29',9,0),(3382,'2019-05-29',10,0),(3383,'2019-05-30',1,0),(3384,'2019-05-30',2,0),(3385,'2019-05-30',3,0),(3386,'2019-05-30',4,0),(3387,'2019-05-30',5,0),(3388,'2019-05-30',6,0),(3389,'2019-05-30',7,0),(3390,'2019-05-30',8,0),(3391,'2019-05-30',9,0),(3392,'2019-05-30',10,0),(3393,'2019-05-31',1,0),(3394,'2019-05-31',2,0),(3395,'2019-05-31',3,0),(3396,'2019-05-31',4,0),(3397,'2019-05-31',5,0),(3398,'2019-05-31',6,0),(3399,'2019-05-31',7,0),(3400,'2019-05-31',8,0),(3401,'2019-05-31',9,0),(3402,'2019-05-31',10,0),(3423,'2019-06-03',1,0),(3424,'2019-06-03',2,0),(3425,'2019-06-03',3,0),(3426,'2019-06-03',4,0),(3427,'2019-06-03',5,0),(3428,'2019-06-03',6,0),(3429,'2019-06-03',7,0),(3430,'2019-06-03',8,0),(3431,'2019-06-03',9,0),(3432,'2019-06-03',10,0),(3433,'2019-06-04',1,0),(3434,'2019-06-04',2,0),(3435,'2019-06-04',3,0),(3436,'2019-06-04',4,0),(3437,'2019-06-04',5,0),(3438,'2019-06-04',6,0),(3439,'2019-06-04',7,0),(3440,'2019-06-04',8,0),(3441,'2019-06-04',9,0),(3442,'2019-06-04',10,0),(3443,'2019-06-05',1,0),(3444,'2019-06-05',2,0),(3445,'2019-06-05',3,0),(3446,'2019-06-05',4,0),(3447,'2019-06-05',5,0),(3448,'2019-06-05',6,0),(3449,'2019-06-05',7,0),(3450,'2019-06-05',8,0),(3451,'2019-06-05',9,0),(3452,'2019-06-05',10,0),(3453,'2019-06-06',1,0),(3454,'2019-06-06',2,0),(3455,'2019-06-06',3,0),(3456,'2019-06-06',4,0),(3457,'2019-06-06',5,0),(3458,'2019-06-06',6,0),(3459,'2019-06-06',7,0),(3460,'2019-06-06',8,0),(3461,'2019-06-06',9,0),(3462,'2019-06-06',10,0),(3463,'2019-06-07',1,0),(3464,'2019-06-07',2,0),(3465,'2019-06-07',3,0),(3466,'2019-06-07',4,0),(3467,'2019-06-07',5,0),(3468,'2019-06-07',6,0),(3469,'2019-06-07',7,0),(3470,'2019-06-07',8,0),(3471,'2019-06-07',9,0),(3472,'2019-06-07',10,0),(3493,'2019-06-10',1,0),(3494,'2019-06-10',2,0),(3495,'2019-06-10',3,0),(3496,'2019-06-10',4,0),(3497,'2019-06-10',5,0),(3498,'2019-06-10',6,0),(3499,'2019-06-10',7,0),(3500,'2019-06-10',8,0),(3501,'2019-06-10',9,0),(3502,'2019-06-10',10,0);
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
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `composition`
--

LOCK TABLES `composition` WRITE;
/*!40000 ALTER TABLE `composition` DISABLE KEYS */;
INSERT INTO `composition` VALUES (2,1,2),(3,1,3),(4,4,4),(5,4,5),(6,4,6),(7,6,7),(8,6,8);
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
  `DishName` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dishs`
--

LOCK TABLES `dishs` WRITE;
/*!40000 ALTER TABLE `dishs` DISABLE KEYS */;
INSERT INTO `dishs` VALUES (1,'Каша'),(2,'Компот'),(3,'Суп'),(4,'Чай'),(5,'Картошка с Котлетами'),(6,'Сок');
/*!40000 ALTER TABLE `dishs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dishs_for_dinnertype`
--

DROP TABLE IF EXISTS `dishs_for_dinnertype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dishs_for_dinnertype` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `DishID` int(11) DEFAULT NULL,
  `DinnerTypeID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `DFDTDI_idx` (`DishID`),
  KEY `DFDTDTI_idx` (`DinnerTypeID`),
  CONSTRAINT `DFDTDI` FOREIGN KEY (`DishID`) REFERENCES `dishs` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `DFDTDTI` FOREIGN KEY (`DinnerTypeID`) REFERENCES `dinnertype` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dishs_for_dinnertype`
--

LOCK TABLES `dishs_for_dinnertype` WRITE;
/*!40000 ALTER TABLE `dishs_for_dinnertype` DISABLE KEYS */;
INSERT INTO `dishs_for_dinnertype` VALUES (3,4,3),(5,1,1),(8,4,2),(10,4,1),(11,6,1),(13,6,2);
/*!40000 ALTER TABLE `dishs_for_dinnertype` ENABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredients`
--

LOCK TABLES `ingredients` WRITE;
/*!40000 ALTER TABLE `ingredients` DISABLE KEYS */;
INSERT INTO `ingredients` VALUES (2,'Крупа'),(3,'Молоко'),(4,'Вода'),(5,'Сахар'),(6,'Трава'),(7,'Лимон'),(8,'Вода');
/*!40000 ALTER TABLE `ingredients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingredients_composition`
--

DROP TABLE IF EXISTS `ingredients_composition`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ingredients_composition` (
  `ingredientID` int(11) NOT NULL,
  `Energy(kkal)` int(11) DEFAULT NULL,
  `Protein,g` int(11) DEFAULT NULL,
  `animalProtein(%)` varchar(3) DEFAULT NULL,
  `g/kg_BodyMass` float DEFAULT NULL,
  `Fat,g` float DEFAULT NULL,
  `Carbohydrates, g` int(11) DEFAULT NULL,
  PRIMARY KEY (`ingredientID`),
  KEY `IID2_idx` (`ingredientID`),
  CONSTRAINT `IID2` FOREIGN KEY (`ingredientID`) REFERENCES `ingredients` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredients_composition`
--

LOCK TABLES `ingredients_composition` WRITE;
/*!40000 ALTER TABLE `ingredients_composition` DISABLE KEYS */;
INSERT INTO `ingredients_composition` VALUES (2,100,100,'70',10,100,100),(3,100,90,'20',500,10,40),(6,10,2,NULL,10,NULL,40);
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
  `Date` date NOT NULL,
  `SelectedDiinerType` int(11) DEFAULT NULL,
  `DishId` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `DIT_idx` (`DishId`),
  KEY `Date_idx` (`Date`),
  KEY `SDT_idx` (`SelectedDiinerType`),
  CONSTRAINT `DIT` FOREIGN KEY (`DishId`) REFERENCES `dishs` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `Date` FOREIGN KEY (`Date`) REFERENCES `attendance` (`Date`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `SDT` FOREIGN KEY (`SelectedDiinerType`) REFERENCES `dinnertype` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menu`
--

LOCK TABLES `menu` WRITE;
/*!40000 ALTER TABLE `menu` DISABLE KEYS */;
INSERT INTO `menu` VALUES (8,'2019-03-29',1,1),(9,'2019-03-29',1,6);
/*!40000 ALTER TABLE `menu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `normsforag`
--

DROP TABLE IF EXISTS `normsforag`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `normsforag` (
  `IDAgeGroup` int(11) NOT NULL,
  `Energy(kkal)` int(11) DEFAULT NULL,
  `Protein,g` int(11) DEFAULT NULL,
  `animalProtein(%)` varchar(3) DEFAULT NULL,
  `g/kg_BodyMass` float DEFAULT NULL,
  `Fat,g` float DEFAULT NULL,
  `Carbohydrates, g` int(11) DEFAULT NULL,
  PRIMARY KEY (`IDAgeGroup`),
  KEY `AG_idx` (`IDAgeGroup`),
  CONSTRAINT `AG` FOREIGN KEY (`IDAgeGroup`) REFERENCES `agegroup` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `normsforag`
--

LOCK TABLES `normsforag` WRITE;
/*!40000 ALTER TABLE `normsforag` DISABLE KEYS */;
INSERT INTO `normsforag` VALUES (1,115,0,'0',1,0,1800),(2,0,0,'1.1',1,0,0),(3,0,0,'0',0,0,0),(4,0,0,'0',0,0,0),(5,0,0,'0',0,0,0),(6,0,0,'0',0,0,0);
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
  `TotalChildren` int(11) DEFAULT NULL,
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

-- Dump completed on 2019-06-10 10:30:52
