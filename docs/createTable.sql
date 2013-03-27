CREATE TABLE [EEInquery] (
[Id] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT,
[ClerkName] varCHAR(100)  NOT NULL,
[ProductName] varcha(255)  NULL,
[PlatFrom] varchar(20)  NULL,
[CustomName] varCHAR(100)  NULL
, CustomEmail varchar(100), inqueryTime datetime, CustomCountry varchar(100), CreationTime datetime);