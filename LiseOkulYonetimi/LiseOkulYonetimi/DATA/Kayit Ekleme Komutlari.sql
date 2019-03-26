INSERT INTO Ogretmen (OgretmenAd,OgretmenSoyad,OgretmenAlani) 
VALUES 
(
	'Sultan',
	'Baloðlu',
	'Bilgisayar'
)

INSERT INTO Ogretmen (OgretmenAd,OgretmenSoyad,OgretmenAlani) 
VALUES 
(
	'Servet',
	'Erdoðan',
	'Kimya'
)

INSERT INTO Ogretmen (OgretmenAd,OgretmenSoyad,OgretmenAlani) 
VALUES 
(
	'Faruk',
	'Yýlmaz',
	'Matematik'
)

INSERT INTO Ogretmen (OgretmenAd,OgretmenSoyad,OgretmenAlani) 
VALUES 
(
	'Celil',
	'Kaçmaz',
	'Beden Eðitimi'
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
	'ÝÞARETLER VE SÝSTEMLER',
	'Duyurularýn takip edilmediði anlaþýlýyor. Dün 17de kapatýlacaðýný söylememe raðmen, bugün (salý) 19:00da kapattýktan sonra bile dokümanlara eriþim isteði geliyor. Duyurularý takip etmeyenler için son bir kez daha yalnýzca 1 saat boyunca eriþim aktif hale gelecek daha sonra tekrar açýlmamak üzere kapatýlacaktýr.',
	12,
	SYSDATETIME()
)

INSERT INTO Duyurular (DuyuruBaslik,DuyuruMetni,KacinciSiniflar,DuyuruTarih) 
VALUES 
(
	'SASGEM',
	'Merhaba Arkadaþlar, Öncelikle yeni eðitim yýlýnýzýn hayýrlý olmasýný diliyoruz. Akademik ve sosyal geliþim için üniversite eðitimi hayati bir konuma sahiptir. Hem derslerinizdeki eðitim hem de sosyal-kültürel faaliyetlerle öðrencilerimizin geleceðe daha iyi hazýrlanmasý arzu edilmektedir. Bu çerçevede bazýlarýmýz için önceden bilinen bir yapý olan SASGEM (Sakarya Üniversitesi Akademik ve Sosyal Geliþim Merkezi) Akademi hakkýndaki yeni geliþmeleri paylaþmak istiyoruz. SASGEM geçmiþ yýllarda bütün fakülteleri kapsayacak þekilde faaliyette bulunuyordu.',
	9,
	SYSDATETIME()
)


INSERT INTO Mudur (MudurAdi,MudurSoyadi) 
VALUES 
(
	'Çaðrý','Kýrmýzý'	
)


INSERT INTO MudurYardimcisi (MudurYardAdi,MudurYardSoyadi) 
VALUES 
(
	'Yusuf','Demirtaþ'
)


INSERT INTO MudurYardimcisi (MudurYardAdi,MudurYardSoyadi) 
VALUES 
(
	'Seher','Gültaþ'
)




INSERT INTO Ogrenci (SinifID,OgrenciAd,OgrenciSoyad) 
VALUES 
(
	1,'Ozan Can','Cuyar'
)


INSERT INTO Ogrenci (SinifID,OgrenciAd,OgrenciSoyad) 
VALUES 
(
	1,'Emrah','Kýlýç'
)

INSERT INTO Ogrenci (SinifID,OgrenciAd,OgrenciSoyad) 
VALUES 
(
	1,'Erkan','Nas'
)


INSERT INTO Belgeler (OgrenciNo,BelgeTuru,DonemAraligi) 
VALUES 
(
	1,'Teþekkür Belgesi','2014/2015'
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
	3,'Salý','8.00',5	
)

INSERT INTO DersProgrami (DersID,DersGun,DersSaat,HangiSinif) 
VALUES 
(
	3,'Salý','9.00',5		
)

INSERT INTO DersProgrami (DersID,DersGun,DersSaat,HangiSinif) 
VALUES 
(
	3,'Salý','11.00',5	
)
INSERT INTO DersProgrami (DersID,DersGun,DersSaat,HangiSinif) 
VALUES 
(
	3,'Perþembe','13.45',6		
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