create database ShopCart;

use ShopCart;


CREATE TABLE Kullanicilar(
kullaniciId INT IDENTITY(1,1) PRIMARY KEY,
kullaniciAdi NVARCHAR(50) NOT NULL,
kullaniciSoyadi NVARCHAR(50) NOT NULL,
kullaniciMail NVARCHAR(50) NOT NULL,
kullaniciSifre NVARCHAR(50) NOT NULL,
olusturmaTarihi DATE DEFAULT GETDATE(),
kullaniciRolu NVARCHAR(10) NOT NULL,
);

CREATE TABLE Kategoriler(
kategoriId INT IDENTITY(1,1) PRIMARY KEY,
kategoriAdi NVARCHAR(50) NOT NULL,
);


--- Kullanici olusturulurken o Kullaniciya ait bir sepet de olusturup toplam tutari sifir yazmam gerekiyor.
--- Urunu sepete ekle dedigimde o kullaniciya ait sepet varsa onu bulacak ve ona ekleme yapacak.
CREATE TABLE Sepetler(
sepetId INT IDENTITY(1,1) PRIMARY KEY,
musteriId INT FOREIGN KEY REFERENCES Kullanicilar (kullaniciId),
toplamTutar INT NOT NULL,
eklenmeTarihi DATE DEFAULT GETDATE()
);

CREATE TABLE Adresler (
adresId INT IDENTITY(1,1) PRIMARY KEY,
musteriId INT FOREIGN KEY REFERENCES Kullanicilar(kullaniciId),
il NVARCHAR(50) NOT NULL,
ilce NVARCHAR(50) NOT NULL,
acikAdres NVARCHAR(200) NOT NULL,
);

CREATE TABLE Markalar (
markaId INT IDENTITY(1,1) PRIMARY KEY,
markaAdi NVARCHAR(50) NOT NULL
)

CREATE TABLE Bolgeler(
bolgeId INT  IDENTITY(1,1) PRIMARY KEY,
bolgeTanimi NVARCHAR(50) NOT NULL
);

CREATE TABLE OdemeYontemleri(
odemeYontemiId INT  IDENTITY(1,1) PRIMARY KEY,
odemeYontemiAdi NVARCHAR(50) NOT NULL
);

CREATE TABLE Favoriler(
favoriId INT IDENTITY(1,1) PRIMARY KEY,
musteriId INT FOREIGN KEY REFERENCES Kullanicilar (kullaniciId),
eklenmeTarihi DATE DEFAULT GETDATE()
);

CREATE TABLE KargoBilgileri(
kargoId INT IDENTITY(1,1) PRIMARY KEY,
teslimatAdresi INT FOREIGN KEY REFERENCES Adresler(adresId),
kargoAdi NVARCHAR(50) NOT NULL,
kargoTakipNo NVARCHAR(50) NOT NULL,
kargoDurumu NVARCHAR(50) NOT NULL,
);

CREATE TABLE Urunler(
urunId INT IDENTITY(1,1) PRIMARY KEY,
saticiId INT FOREIGN KEY REFERENCES Kullanicilar(kullaniciId),
kategoriId INT FOREIGN KEY REFERENCES Kategoriler(kategoriId),
markaId INT FOREIGN KEY REFERENCES Markalar(markaId),
urunAdi NVARCHAR(50) NOT NULL,
urunFiyati INT NOT NULL,
urunResmi NVARCHAR(50),
kayitTarihi DATE DEFAULT GETDATE(),
urunStokMiktari INT NOT NULL,
);


CREATE TABLE FavoriUrun(
favoriUrunId INT IDENTITY(1,1) PRIMARY KEY,
favoriId INT FOREIGN KEY REFERENCES Favoriler(favoriId),
urunId INT FOREIGN KEY REFERENCES Urunler(urunId),
);


CREATE TABLE Yorumlar(
yorumId INT IDENTITY(1,1) PRIMARY KEY,
kullaniciId INT FOREIGN KEY REFERENCES Kullanicilar (kullaniciId),
urunId INT FOREIGN KEY REFERENCES Urunler(urunId),
yorumMetni NVARCHAR(200) NOT NULL,
yorumTarihi DATE DEFAULT GETDATE(),
)

CREATE TABLE SepetUrun(
sepetUrunId INT IDENTITY(1,1) PRIMARY KEY,
sepetId INT FOREIGN KEY REFERENCES Sepetler(sepetId),
urunId INT FOREIGN KEY REFERENCES Urunler(urunId),
urunSayisi INT NOT NULL,
);


CREATE TABLE Satislar(
satisId INT IDENTITY(1,1) PRIMARY KEY,
sepetId INT FOREIGN KEY REFERENCES Sepetler(sepetId),
kargoId INT FOREIGN KEY REFERENCES KargoBilgileri(kargoId),
odemeYontemiId INT FOREIGN KEY REFERENCES OdemeYontemleri(odemeYontemiId),
bolgeId INT FOREIGN KEY REFERENCES Bolgeler(bolgeId),
satisTutari INT NOT NULL,
satisTarihi DATE DEFAULT GETDATE(),
satisDurumu NVARCHAR NOT NULL, 
)


CREATE TABLE UrunOzellikleri (
  urunOzellikId INT PRIMARY KEY,
  aciklama VARCHAR(255) NOT NULL,
  FOREIGN KEY (urunOzellikId) REFERENCES Urunler(urunId)
);





