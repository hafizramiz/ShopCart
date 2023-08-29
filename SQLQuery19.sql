use ShopCart;

ALTER TABLE Urunler
DROP CONSTRAINT FK_Urunler_Markalar;

ALTER TABLE Urunler
ADD CONSTRAINT FK_Urunler_Markalar
FOREIGN KEY (markaId)
REFERENCES Markalar(markaId)
ON DELETE CASCADE;
