use ShopCart;


ALTER TABLE Urunler
ADD CONSTRAINT FK_Urunler_Kategoriler
FOREIGN KEY (kategoriId)
REFERENCES Kategoriler(kategoriId)
ON DELETE CASCADE; -- Cascade Delete ayarı

ALTER TABLE Urunler
DROP CONSTRAINT FK_Urunler_Kategoriler; -- Cascade Delete ayarını kaldırma

ALTER TABLE Urunler
ADD CONSTRAINT FK_Urunler_Kategoriler
FOREIGN KEY (kategoriId)
REFERENCES Kategoriler(kategoriId);



ALTER TABLE Sepetler
ADD CONSTRAINT FK_Sepetler_Kullanicilar
FOREIGN KEY (musteriId)
REFERENCES Kullanicilar(kullaniciId)
ON DELETE CASCADE; -- Cascade Delete ayarı



ALTER TABLE Favoriler
ADD CONSTRAINT FK_Favoriler_Kullanicilar
FOREIGN KEY (musteriId)
REFERENCES Kullanicilar(kullaniciId)
ON DELETE CASCADE; -- Cascade Delete ayarı	


ALTER TABLE SepetUrun
ADD CONSTRAINT FK_SepetUrun_Sepetler
FOREIGN KEY (sepetId)
REFERENCES Sepetler(sepetId)
ON DELETE CASCADE; -- Cascade Delete ayarı

ALTER TABLE SepetUrun
DROP CONSTRAINT FK_SepetUrun_Urunler; -- Eski kısıtlamayı kaldır

ALTER TABLE SepetUrun
ADD CONSTRAINT FK_SepetUrun_Urunler
FOREIGN KEY (urunId)
REFERENCES Urunler(urunId)
ON DELETE CASCADE; -- Cascade Delete ayarı

-- KargoBilgileri tablosundaki teslimatAdresi FOREIGN KEY kısıtlamasına CASCADE DELETE ayarını yapın
ALTER TABLE KargoBilgileri
DROP CONSTRAINT FK_KargoBilgileri_Adresler; -- Eski kısıtlamayı kaldır

ALTER TABLE KargoBilgileri
ADD CONSTRAINT FK_KargoBilgileri_Adresler
FOREIGN KEY (teslimatAdresi)
REFERENCES Adresler(adresId)
ON DELETE CASCADE; -- Cascade Delete ayarı

-- Satislar tablosundaki sepetId FOREIGN KEY kısıtlamasına CASCADE DELETE ayarını yapın
ALTER TABLE Satislar
DROP CONSTRAINT FK_Satislar_Sepetler; -- Eski kısıtlamayı kaldır

ALTER TABLE Satislar
ADD CONSTRAINT FK_Satislar_Sepetler
FOREIGN KEY (sepetId)
REFERENCES Sepetler(sepetId)
ON DELETE CASCADE; -- Cascade Delete ayarı

-- Satislar tablosundaki kargoId FOREIGN KEY kısıtlamasına CASCADE DELETE ayarını yapın
ALTER TABLE Satislar
DROP CONSTRAINT FK_Satislar_KargoBilgisi; -- Eski kısıtlamayı kaldır


-- burda hata aldim


ALTER TABLE Satislar
ADD CONSTRAINT FK_Satislar_KargoBilgisi
FOREIGN KEY (kargoBilgisiId)
REFERENCES KargoBilgisi(kargoBilgisiId)
ON DELETE CASCADE;

ALTER TABLE Satislar
ADD CONSTRAINT FK_Satislar_OdemeYontemleri
FOREIGN KEY (odemeYontemiId)
REFERENCES OdemeYontemleri(odemeYontemiId)
ON DELETE CASCADE; -- Cascade Delete ayarı

-- Satislar tablosundaki bolgeId FOREIGN KEY kısıtlamasına CASCADE DELETE ayarını yapın
ALTER TABLE Satislar
DROP CONSTRAINT FK_Satislar_Bolgeler; -- Eski kısıtlamayı kaldır

ALTER TABLE Satislar
ADD CONSTRAINT FK_Satislar_Bolgeler
FOREIGN KEY (bolgeId)
REFERENCES Bolgeler(bolgeId)
ON DELETE CASCADE; -- Cascade Delete ayarı

-- ... Diğer ilişkili tabloların Cascade Delete ayarlarını da aynı şekilde yapabilirsiniz ...



ALTER TABLE FavoriUrun
DROP CONSTRAINT FK_FavoriUrun_Favoriler;

-- FavoriUrun tablosundaki CASCADE DELETE işlemi (Favoriler ve Urunler)
ALTER TABLE FavoriUrun
ADD CONSTRAINT FK_FavoriUrun_Favoriler
FOREIGN KEY (favoriId)
REFERENCES Favoriler(favoriId)
ON DELETE CASCADE;

ALTER TABLE FavoriUrun
ADD CONSTRAINT FK_FavoriUrun_Urunler
FOREIGN KEY (urunId)
REFERENCES Urunler(urunId)
ON DELETE CASCADE;

-- Yorumlar tablosu için FOREIGN KEY kısıtını oluşturma
ALTER TABLE Yorumlar ADD CONSTRAINT FK_Yorumlar_Kullanicilar FOREIGN KEY (kullaniciId) REFERENCES Kullanicilar(kullaniciId) ON DELETE CASCADE;
ALTER TABLE Yorumlar ADD CONSTRAINT FK_Yorumlar_Urunler FOREIGN KEY (urunId) REFERENCES Urunler(urunId) ON DELETE CASCADE;

ALTER TABLE UrunOzellikleri
DROP CONSTRAINT FK_UrunOzellikleri_Urunler;
-- CASCADE DELETE işlemini ekle
ALTER TABLE UrunOzellikleri
ADD CONSTRAINT FK_UrunOzellikleri_Urunler FOREIGN KEY (urunOzellikId)
REFERENCES Urunler(urunId)
ON DELETE CASCADE;


ALTER TABLE Urunler
ADD CONSTRAINT FK_Urunler_Markalar
FOREIGN KEY (markaId)
REFERENCES Markalar(markaId)
ON DELETE CASCADE;

ALTER TABLE Urunler
DROP CONSTRAINT FK_Urunler_Markalar;
