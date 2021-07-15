CREATE DATABASE KingAkademija2021;
GO

USE KingAkademija2021;
GO

CREATE TABLE Akademija (
    Id int IDENTITY(1,1) PRIMARY KEY,
    AcademyName varchar(255)
);

INSERT INTO Akademija(AcademyName) VALUES ('KingICT ljetna akademija 2021');

CREATE TABLE [dbo].[User] (
    Id int IDENTITY(1,1) PRIMARY KEY,
    FirstName varchar(255),
	LastName varchar(255)
);

CREATE TABLE BlogPost (
	Id int IDENTITY(1,1) PRIMARY KEY,
	Title varchar(100),
	Text varchar (255),
	UserId int FOREIGN KEY REFERENCES User(Id)
)