use ShopCart;

Go
CREATE PROCEDURE SP_SEPETDETAY1
    @MusteriId INT
AS

    SELECT SU.urunId, U.urunAdi, SU.urunSayisi, U.urunFiyati, U.urunResmi
    FROM Sepetler S
    JOIN SepetUrun SU ON S.sepetId = SU.sepetId
    JOIN Urunler U ON SU.urunId = U.urunId
    WHERE S.musteriId = @MusteriId;

Go