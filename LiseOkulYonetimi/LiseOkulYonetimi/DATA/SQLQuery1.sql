CREATE DATABASE LiseOkulYonetimSistemi

CREATE TABLE Duyurular 
(
	DuyuruID int IDENTITY(1,1) PRIMARY KEY,
	DuyuruBaslik nvarchar(MAX) NOT NULL,
	DuyuruMetni nvarchar(MAX) NOT NULL,
	KacinciSiniflar int NOT NULL, 
	DuyuruTarih datetime NOT NULL
)

CREATE TABLE Mudur 
(
	MudurAdi nvarchar(50) NOT NULL,
	MudurSoyadi nvarchar(50) NOT NULL
)

CREATE TABLE MudurYardimcisi
(
	MudurYardID int IDENTITY(1,1) PRIMARY KEY,
	MudurYardAdi nvarchar(MAX) NOT NULL,
	MudurYardSoyadi nvarchar(MAX) NOT NULL
)


CREATE TABLE Ogretmen
(
	OgretmenNo int IDENTITY(1,1) PRIMARY KEY,
	OgretmenAd nvarchar(MAX) NOT NULL,
	OgretmenSoyad nvarchar(MAX) NOT NULL,
	OgretmenAlani nvarchar(MAX) NOT NULL
)

CREATE TABLE Dersler
(
	DersID int IDENTITY(1,1) PRIMARY KEY,
	OgretmenNo int NOT NULL,
	DersAdi nvarchar(MAX) NOT NULL,
	DonemAraligi nvarchar(MAX) NOT NULL,
	DersKredisi int NOT NULL,
	CONSTRAINT fk_ogretmenno FOREIGN KEY(OgretmenNo) REFERENCES Ogretmen(OgretmenNo)
)



CREATE TABLE DersProgrami
(
	ProgramID int IDENTITY(1,1) PRIMARY KEY,
	DersID int NOT NULL,
	DersGun nvarchar(50) NOT NULL,
	DersSaat nvarchar(50) NOT NULL,
	HangiSinif int NOT NULL,
	CONSTRAINT fk_dersid FOREIGN KEY(DersID) REFERENCES Dersler(DersID)
)




CREATE TABLE Sinif
(
	SinifID int IDENTITY(1,1) PRIMARY KEY,
	SinifinOgretmenNo int NOT NULL,
	SinifAdi nvarchar(MAX) NOT NULL,
	CONSTRAINT Fk_SinifinOgretmenNo FOREIGN KEY(SinifinOgretmenNo) REFERENCES Ogretmen(OgretmenNo)
)

CREATE TABLE Ogrenci
(
	OgrenciNo int IDENTITY(1,1) PRIMARY KEY,
	SinifID int NOT NULL,
	OgrenciAd nvarchar(MAX) NOT NULL,
	OgrenciSoyad nvarchar(MAX) NOT NULL,
	CONSTRAINT FK_SinifID FOREIGN KEY(SinifID) REFERENCES Sinif(SinifID)
)

CREATE TABLE Devamsizlik
(
	DevamsizlikID int IDENTITY(1,1) PRIMARY KEY,
	OgrenciNo int NOT NULL,
	Gun int NOT NULL,
	Ay int NOT NULL,
	Yil int NOT NULL,
	DevamDurumu nvarchar(50) NOT NULL,
	CONSTRAINT FK_OgrenciNo FOREIGN KEY(OgrenciNo) REFERENCES Ogrenci(OgrenciNo)
)



CREATE TABLE Belgeler
(
	BelgeID int IDENTITY(1,1) PRIMARY KEY,
	OgrenciNo int NOT NULL,
	BelgeTuru nvarchar(MAX) NOT NULL,
	DonemAraligi nvarchar(MAX) NOT NULL,
	CONSTRAINT FK_Belgeler_OgrenciNo FOREIGN KEY(OgrenciNo) REFERENCES Ogrenci(OgrenciNo)
)


CREATE TABLE DerslerinSiniflari
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	DersID int NOT NULL,
	SinifID int NOT NULL,
	CONSTRAINT FK_Dersler_DerslerinSiniflari FOREIGN KEY(DersID) REFERENCES Dersler(DersID),
	CONSTRAINT FK_Sinif_DerslerinSiniflari FOREIGN KEY(SinifID) REFERENCES Sinif(SinifID)
)

CREATE TABLE IslemListesi
(
	IslemListesi nvarchar(MAX)
)

CREATE TABLE NotBilgisi
(
	NotID int IDENTITY(1,1) PRIMARY KEY,
	DersID int NOT NULL,
	OgrenciNo int NOT NULL,
	SinavNumarasi int NOT NULL,
	Notu int NOT NULL
	CONSTRAINT FK_Dersler_NotBilgisi FOREIGN KEY(DersID) REFERENCES Dersler(DersID),
	CONSTRAINT FK_Ogrenci_NotBilgisi FOREIGN KEY(OgrenciNo) REFERENCES Ogrenci(OgrenciNo)
)


CREATE TABLE SinavTarihleri
(
	SinavTarihiID int IDENTITY(1,1) PRIMARY KEY,
	SinifID int NOT NULL,
	DersID int NOT NULL,
	SinavTarihi nvarchar(50) NOT NULL,
	CONSTRAINT FK_Dersler_SinavTarihleri FOREIGN KEY(DersID) REFERENCES Dersler(DersID),
	CONSTRAINT FK_Sinif_SinavTarihleri FOREIGN KEY(SinifID) REFERENCES Sinif(SinifID)
)


CREATE TABLE YilSonuNotlari
(
	YilSonuID int IDENTITY(1,1) PRIMARY KEY,
	OgrenciNo int NOT NULL,
	Notu int NOT NULL,
	OgretimYili nvarchar(MAX) NOT NULL,
	DersID int NOT NULL,

	CONSTRAINT FK_OgrenciNo_YilSonu FOREIGN KEY(OgrenciNo) REFERENCES Ogrenci(OgrenciNo),
)