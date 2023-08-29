use ShopCart;

Go
CREATE PROCEDURE SP_GETSEPETDETAYWITHID
    @MusteriId INT
AS
BEGIN
    SELECT SU.urunId, U.urunAdi, SU.urunSayisi,S.sepetId, U.urunFiyati, U.urunResmi,S.toplamTutar,U.markaId,U.saticiId,S.eklenmeTarihi
    FROM Sepetler S
    JOIN SepetUrun SU ON S.sepetId = SU.sepetId
    JOIN Urunler U ON SU.urunId = U.urunId
    WHERE S.musteriId = @MusteriId;
END;
Go