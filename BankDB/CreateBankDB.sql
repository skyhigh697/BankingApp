USE master

if DB_ID ('Bank') IS NOT NULL
	DROP DATABASE Bank
GO

CREATE DATABASE Bank
GO

USE Bank

CREATE TABLE Customer
(
	CustomerID		int			PRIMARY KEY IDENTITY
	,Name			varchar(70)	NOT NULL
)
GO

INSERT INTO Customer (Name)
	VALUES ('Joe Programmer'), ('Derek McFarland'), ('Peter Griffin'), ('John Doe')
