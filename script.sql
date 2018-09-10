 
CREATE DATABASE ProductBookingWebAPI
 
CREATE TABLE ActivityProduct(
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	EventName varchar(30) NOT NULL,
	FromTime varchar(15) NOT NULL,
	ToTime varchar(15) NOT NULL,
	Price int NOT NULL,
	Place varchar(50) NULL,
	isBooked bit NOT NULL DEFAULT 0,
	isSaved bit NOT NULL DEFAULT 0) 

INSERT INTO ActivityProduct VALUES ('BIRTHDAY','21-04-2018','22-08-2018',5000,'NAGPUR',0,0)
INSERT INTO ActivityProduct VALUES ('MOVIE','26-04-2018','02-08-2018',700,'RAIPUR',0,0)
INSERT INTO ActivityProduct VALUES ('TREK','21-08-2018','22-08-2018',7000,'PUNE',0,0)
INSERT INTO ActivityProduct VALUES ('HUNTING','21-04-2018','22-04-2018',1000,'MUMBAI',0,0)
INSERT INTO ActivityProduct VALUES ('RAFTING','19-04-2018','22-08-2018',10000,'DELHI',0,0)

	
CREATE TABLE AirProduct(
	Id int IDENTITY(1,1) NOT NULL,
	FlightCompany varchar(35) NOT NULL,
	DepartureDate datetime NOT NULL,
	ArrivalDate datetime NOT NULL,
	FromPlace varchar(50) NULL,
	ToPlace varchar(50) NULL,
	Price int NOT NULL,
	isBooked bit NOT NULL DEFAULT 0,
	isSavedbit bit NOT NULL DEFAULT 0) 

INSERT INTO AirProduct VALUES ('AIRASIA',12-08-2018,21-08-2018,'PUNE','DELHI',7500,0,0)	
INSERT INTO AirProduct VALUES ('INDIGO',21-04-2018,22-04-2018,'PUNE','NAGPUR',1500,0,0)	
INSERT INTO AirProduct VALUES ('JET',21-07-2018,21-07-2018,'PUNE','MUMBAI',3500,0,0)	 
	
CREATE TABLE CarProduct(
	Id int IDENTITY(1,1) NOT NULL,
	Company varchar(30) NOT NULL,
	Model varchar(30) NOT NULL,
	CarNumber varchar(30) NOT NULL,
	Price int NOT NULL,
	isBooked bit NOT NULL DEFAULT 0,
	isSaved bit NOT NULL DEFAULT 0)

INSERT INTO CarProduct VALUES ('AUDI','A4','MH49A6861',21000,0,0)
INSERT INTO CarProduct VALUES ('MARUTI SUZUKI','SWIFT DEZIRE','MH49A6061',25000,0,0)
INSERT INTO CarProduct VALUES ('MARUTI SUZUKI','ALTO','MH30A6861',11000,0,0)

	
CREATE TABLE HotelProduct(
	Id int IDENTITY(1,1) NOT NULL,
	FromDate varchar(10) NOT NULL,
	ToDate varchar(10) NOT NULL,
	City varchar(20) NOT NULL,
	Address varchar(50) NOT NULL,
	LandMark varchar(20) NOT NULL,
	Price int NOT NULL,
	isBooked bit NOT NULL DEFAULT 0,
	isSaved bit NOT NULL DEFAULT 0)
	
INSERT INTO HotelProduct VALUES ('21-04-2018','22-04-2018','NAGPUR','ROAD1','RADISON BLU',1500,0,0)	
INSERT INTO HotelProduct VALUES ('01-04-2018','02-04-2018','PUNE','ROAD2','HYATT',5500,0,0)	
INSERT INTO HotelProduct VALUES ('01-07-2018','22-07-2018','DELHI','ROAD3','TAJ',6500,0,0)	
