
CREATE PROC SP_SEPETTEKIURUNLER
AS
SELECT  U.UrunId, U.urunAdi, U.urunFiyati, T.SirketAdi, K.KategoriAdi
FROM Urunler AS U, Tedarikciler AS T, Kategoriler AS K
WHERE
U.TedarikciID=T.TedarikciID AND 
K.KategoriID=U.KategoriID
go;



CREATE PROCEDURE SP_SEPETDETAY
    @MusteriId INT
AS
BEGIN
    SELECT SU.UrunId, U.UrunAdi, SU.urunSayisi, U.Fiyat, U.urunResmi
    FROM Sepetler S
    JOIN SepetUrun SU ON S.sepetId = SU.SepetId
    JOIN Urunler U ON SU.UrunId = U.UrunId
    WHERE S.kullaniciId = @MusteriId;
END;