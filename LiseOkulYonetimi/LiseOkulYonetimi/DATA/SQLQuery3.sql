INSERT INTO Ogretmen (OgretmenAd,OgretmenSoyad,OgretmenAlani) 
VALUES 
(
	'Sultan',
	'Baloglu',
	'Bilgisayar'
)

INSERT INTO Ogretmen (OgretmenAd,OgretmenSoyad,OgretmenAlani) 
VALUES 
(
	'Servet',
	'Erdogan',
	'Kimya'
)

INSERT INTO Ogretmen (OgretmenAd,OgretmenSoyad,OgretmenAlani) 
VALUES 
(
	'Faruk',
	'Yilmaz',
	'Matematik'
)

INSERT INTO Ogretmen (OgretmenAd,OgretmenSoyad,OgretmenAlani) 
VALUES 
(
	'Celil',
	'Kacmaz',
	'Beden Egitimi'
)




INSERT INTO Dersler (OgretmenNo,DersAdi,DonemAraligi,DersKredisi) 
VALUES 
(
	3,
	'Kimya',
	'2015/2016',
	4
)


INSERT INTO Dersler (OgretmenNo,DersAdi,DonemAraligi,DersKredisi) 
VALUES 
(
	4,
	'Matematik',
	'2015/2016',
	5
)

INSERT INTO Dersler (OgretmenNo,DersAdi,DonemAraligi,DersKredisi) 
VALUES 
(
	1,
	'B.T.T',
	'2015/2016',
	10
)




INSERT INTO Sinif (SinifinOgretmenNo,SinifAdi) 
VALUES 
(
	1,
	'12A'
)
INSERT INTO Sinif (SinifinOgretmenNo,SinifAdi) 
VALUES 
(
	3,
	'12B'
)
INSERT INTO Sinif (SinifinOgretmenNo,SinifAdi) 
VALUES 
(
	4,
	'11A'
)
INSERT INTO Sinif (SinifinOgretmenNo,SinifAdi) 
VALUES 
(
	1,
	'10B'
)
INSERT INTO Sinif (SinifinOgretmenNo,SinifAdi) 
VALUES 
(
	3,
	'11B'
)
INSERT INTO Sinif (SinifinOgretmenNo,SinifAdi) 
VALUES 
(
	4,
	'9A'
)


INSERT INTO Duyurular (DuyuruBaslik,DuyuruMetni,KacinciSiniflar,DuyuruTarih) 
VALUES 
(
	'ISARETLER VE SISTEMLER',
	'Duyurularin takip edilmedigi anlasiliyor. Dün 17de kapatilacagi söylememe ragmen, bugün (sali) 19:00da kapattiktan 
	sonra bile dokümanlara erisim istegi geliyor. Duyurulari takip etmeyenler için son bir kez daha yalnizca 1 saat boyunca 
	erisim aktif hale gelecek daha sonra tekrar açilmamak üzere kapatilacaktir.',
	12,
	SYSDATETIME()
)

INSERT INTO Duyurular (DuyuruBaslik,DuyuruMetni,KacinciSiniflar,DuyuruTarih) 
VALUES 
(
	'SASGEM',
	'Merhaba Arkadaslar, Öncelikle yeni egitim yilinizin hayirli olmasini diliyoruz. Akademik ve sosyal 
	gelisim için üniversite egitimi hayati bir konuma sahiptir. Hem derslerinizdeki egitim hem de sosyal-kültürel 
	faaliyetlerle ogrencilerimizin gelecege daha iyi hazirlanmasi arzu edilmektedir. Bu cercevede bazilarimiz için 
	önceden bilinen bir yapi olan SASGEM (Sakarya Üniversitesi Akademik ve Sosyal Gelisim Merkezi) Akademi hakkinda 
	yeni gelismeleri paylasmak istiyoruz. SASGEM gecmis yillarda bütün fakulteleri kapsayacak sekilde faaliyette bulunuyordu.',
	9,
	SYSDATETIME()
)


INSERT INTO Mudur (MudurAdi,MudurSoyadi) 
VALUES 
(
	'Cagri','Kirmizi'	
)


INSERT INTO MudurYardimcisi (MudurYardAdi,MudurYardSoyadi) 
VALUES 
(
	'Yusuf','Demirtas'
)


INSERT INTO MudurYardimcisi (MudurYardAdi,MudurYardSoyadi) 
VALUES 
(
	'Seher','Gultas'
)




INSERT INTO Ogrenci (SinifID,OgrenciAd,OgrenciSoyad) 
VALUES 
(
	1,'Ozan Can','Cuyar'
)


INSERT INTO Ogrenci (SinifID,OgrenciAd,OgrenciSoyad) 
VALUES 
(
	1,'Emrah','Kilic'
)

INSERT INTO Ogrenci (SinifID,OgrenciAd,OgrenciSoyad) 
VALUES 
(
	1,'Erkan','Nas'
)


INSERT INTO Belgeler (OgrenciNo,BelgeTuru,DonemAraligi) 
VALUES 
(
	1,'Tesekkür Belgesi','2014/2015'
)
INSERT INTO Belgeler (OgrenciNo,BelgeTuru,DonemAraligi) 
VALUES 
(
	1,'Onur Belgesi','2015/2016'
)




INSERT INTO SinavTarihleri (SinifID,DersID,SinavTarihi) 
VALUES 
(
	1,3,'12:00'
)
INSERT INTO SinavTarihleri (SinifID,DersID,SinavTarihi) 
VALUES 
(
	6,2,'14:00'
)
INSERT INTO SinavTarihleri (SinifID,DersID,SinavTarihi) 
VALUES 
(
	3,1,'12:30'
)



INSERT INTO Devamsizlik (OgrenciNo,Gun,Ay,Yil,DevamDurumu) 
VALUES 
(
	1,5,12,2016,'Geldi'
)
INSERT INTO Devamsizlik (OgrenciNo,Gun,Ay,Yil,DevamDurumu) 
VALUES 
(
	2,15,1,2016,'Gelmedi'
)
INSERT INTO Devamsizlik (OgrenciNo,Gun,Ay,Yil,DevamDurumu) 
VALUES 
(
	3,14,3,2016,'Geldi'
)
INSERT INTO Devamsizlik (OgrenciNo,Gun,Ay,Yil,DevamDurumu) 
VALUES 
(
	1,4,2,2016,'Geldi'
)



INSERT INTO DersProgrami (DersID,DersGun,DersSaat,HangiSinif) 
VALUES 
(
	1,'Pazartesi','8.00',1	
)

INSERT INTO DersProgrami (DersID,DersGun,DersSaat,HangiSinif) 
VALUES 
(
	1,'Pazartesi','9.00',1	
)

INSERT INTO DersProgrami (DersID,DersGun,DersSaat,HangiSinif) 
VALUES 
(
	1,'Pazartesi','10.00',1	
)

INSERT INTO DersProgrami (DersID,DersGun,DersSaat,HangiSinif) 
VALUES 
(
	3,'Sali','8.00',5	
)

INSERT INTO DersProgrami (DersID,DersGun,DersSaat,HangiSinif) 
VALUES 
(
	3,'Sali','9.00',5		
)

INSERT INTO DersProgrami (DersID,DersGun,DersSaat,HangiSinif) 
VALUES 
(
	3,'Sali','11.00',5	
)
INSERT INTO DersProgrami (DersID,DersGun,DersSaat,HangiSinif) 
VALUES 
(
	3,'Persembe','13.45',6		
)




INSERT INTO NotBilgisi (DersID,OgrenciNo,SinavNumarasi,Notu) 
VALUES 
(
	1,1,1,50	
)

INSERT INTO NotBilgisi (DersID,OgrenciNo,SinavNumarasi,Notu) 
VALUES 
(
	1,1,2,80	
)

INSERT INTO NotBilgisi (DersID,OgrenciNo,SinavNumarasi,Notu) 
VALUES 
(
	1,2,1,90	
)
INSERT INTO NotBilgisi (DersID,OgrenciNo,SinavNumarasi,Notu) 
VALUES 
(
	1,2,2,40	
)
INSERT INTO NotBilgisi (DersID,OgrenciNo,SinavNumarasi,Notu) 
VALUES 
(
	3,1,1,100
)
INSERT INTO NotBilgisi (DersID,OgrenciNo,SinavNumarasi,Notu) 
VALUES 
(
	3,2,2,60
)
INSERT INTO NotBilgisi (DersID,OgrenciNo,SinavNumarasi,Notu) 
VALUES 
(
	1,1,3,60	
)
INSERT INTO NotBilgisi (DersID,OgrenciNo,SinavNumarasi,Notu) 
VALUES 
(
	1,1,4,80	
)