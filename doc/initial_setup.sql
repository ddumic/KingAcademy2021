CREATE DATABASE KingAkademija2021;
GO

USE KingAkademija2021;
GO

CREATE TABLE Akademija (
    Id int IDENTITY(1,1) PRIMARY KEY,
    AcademyName varchar(255)
);

INSERT INTO Akademija(AcademyName) VALUES ('KingICT ljetna akademija 2021');

