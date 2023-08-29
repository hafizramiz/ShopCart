use ShopCart;

CREATE TABLE Kargolar(
kargoId INT  IDENTITY(1,1) PRIMARY KEY,
kargoAdi NVARCHAR(50) NOT NULL
);

CREATE TABLE KargoBilgisi(
kargoBilgisiId INT IDENTITY(1,1) PRIMARY KEY,
kargoId INT FOREIGN KEY REFERENCES Kargolar(kargoId),
il NVARCHAR(50) NOT NULL,
ilce NVARCHAR(50) NOT NULL,
acikAdres NVARCHAR(50) NOT NULL,
kargoDurumu NVARCHAR(50) NOT NULL,
);


CREATE TABLE Satis(
satisId INT IDENTITY(1,1) PRIMARY KEY,
sepetId INT FOREIGN KEY REFERENCES Sepetler(sepetId),
kargoBilgisiId INT FOREIGN KEY REFERENCES KargoBilgisi(kargoBilgisiId),
odemeYontemiId INT FOREIGN KEY REFERENCES OdemeYontemleri(odemeYontemiId),
bolgeId INT FOREIGN KEY REFERENCES Bolgeler(bolgeId),
satisTutari INT NOT NULL,
satisTarihi DATE DEFAULT GETDATE(),
satisDurumu NVARCHAR NOT NULL, 
)