use ShopCart;

Go
CREATE PROCEDURE SP_GETFAVORIDETAYWITHID
    @MusteriId INT
AS
BEGIN
    SELECT FU.urunId, U.urunAdi, F.favoriId, U.urunFiyati, U.urunResmi,U.markaId,U.saticiId,F.eklenmeTarihi
    FROM Favoriler F
    JOIN FavoriUrun FU ON F.favoriId = FU.favoriId
    JOIN Urunler U ON FU.urunId = U.urunId
    WHERE F.musteriId = @MusteriId;
END;
Go