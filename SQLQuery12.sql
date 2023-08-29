use ShopCart;

Go
CREATE PROCEDURE GetUrunDetayWithUrunId
    @urunId INT
AS
BEGIN
    SELECT
        U.urunAdi,
        U.urunStokMiktari,  
        M.markaAdi,
        U.urunFiyati,
        U.urunResmi,
        Y.yorumMetni,
        K.kullaniciAdi,
        UO.aciklama AS urunAciklamasi
    FROM Urunler U
    INNER JOIN Markalar M ON U.markaId = M.markaId
    LEFT JOIN Yorumlar Y ON U.urunId = Y.urunId
    LEFT JOIN Kullanicilar K ON Y.kullaniciId = K.kullaniciId
    LEFT JOIN UrunOzellikleri UO ON U.urunId = UO.urunOzellikId
    WHERE U.urunId = @urunId;
END;
Go