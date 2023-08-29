use ShopCart;

go
CREATE PROCEDURE SP_GetSalesInfo
AS
BEGIN
    SELECT
        K.kullaniciAdi + ' ' + K.kullaniciSoyadi AS KullaniciAdi,
        ST.satisTutari,
        ST.satisTarihi,
        SUM(SU.urunSayisi) AS urunSayisi,
        U.urunAdi,
        U.urunFiyati,
        B.bolgeTanimi
    FROM
        SatislarTablosu ST
        INNER JOIN Sepetler SE ON ST.sepetId = SE.sepetId
        INNER JOIN Kullanicilar K ON SE.musteriId = K.kullaniciId
        INNER JOIN SepetUrun SU ON SE.sepetId = SU.sepetId
        INNER JOIN Urunler U ON SU.urunId = U.urunId
        INNER JOIN Bolgeler B ON ST.bolgeId = B.bolgeId
    GROUP BY
        K.kullaniciAdi, K.kullaniciSoyadi, ST.satisTutari, ST.satisTarihi, U.urunAdi, U.urunFiyati, B.bolgeTanimi
    ORDER BY
        ST.satisTarihi DESC;
END;
go