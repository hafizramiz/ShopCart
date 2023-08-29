use ShopCart;

CREATE TABLE Satislar(
satisId INT IDENTITY(1,1) PRIMARY KEY,
sepetId INT FOREIGN KEY REFERENCES Sepetler(sepetId),
kargoBilgisiId INT FOREIGN KEY REFERENCES KargoBilgisi(kargoBilgisiId),
odemeYontemiId INT FOREIGN KEY REFERENCES OdemeYontemleri(odemeYontemiId),
bolgeId INT FOREIGN KEY REFERENCES Bolgeler(bolgeId),
satisTutari INT NOT NULL,
satisTarihi DATE DEFAULT GETDATE(),
satisDurumu NVARCHAR NOT NULL, 
)