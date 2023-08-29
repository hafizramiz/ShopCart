use ShopCart;

go
CREATE PROCEDURE GetUrunGuncelleDetayWithId
    @urunId INT
AS
BEGIN
    SELECT
        U.urunId,
        M.markaAdi,
        K.kategoriAdi,
        U.urunAdi,
        U.urunFiyati,
        U.urunResmi,
        U.saticiId,
        U.urunStokMiktari
    FROM Urunler AS U
    JOIN Markalar AS M ON U.markaId = M.markaId
    JOIN Kategoriler AS K ON U.kategoriId = K.kategoriId
    JOIN Kullanicilar AS KU ON U.saticiId = KU.kullaniciId;
END;
go








