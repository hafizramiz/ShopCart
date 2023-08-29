use ShopCart

Go
CREATE VIEW URUNKATEGORIMARKA
AS
SELECT  U.UrunId, U.UrunAdi,U.urunFiyati,U.urunResmi, U.urunStokMiktari, K.kategoriAdi, M.markaAdi
FROM Urunler AS U, Markalar AS M, Kategoriler AS K
WHERE
U.markaId=M.markaId AND 
U.kategoriId=K.kategoriId
Go