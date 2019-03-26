CREATE TRIGGER EklemeIslemiIcin ON NotBilgisi
FOR INSERT
AS
BEGIN
	INSERT INTO IslemListesi (IslemListesi) VALUES ('Müdür bey Not Bilgisi tablosuna bir kayýt ekledi!');
END

CREATE TRIGGER SilmeIslemiIcin ON NotBilgisi
FOR DELETE
AS
BEGIN
	INSERT INTO IslemListesi (IslemListesi) VALUES ('Müdür bey Not Bilgisi tablosunda bir kayýt sildi!');
END

CREATE TRIGGER GuncellemeIslemiIcin ON NotBilgisi
FOR UPDATE
AS
BEGIN
	INSERT INTO IslemListesi (IslemListesi) VALUES ('Müdür bey Not Bilgisi tablosunda bir kayýt güncelledi!');
END





CREATE FUNCTION YilSonuBasariNotuEkle(@sinav1 int, @sinav2 int, @sinav3 int, @performans int)
Returns int
AS
Begin
    Return (@sinav1 + @sinav2 + @sinav3 + @performans)/4;
End






CREATE PROCEDURE dbo.YilSonuBasariNotuKayitEkle
(
 @OgrenciNo int,@Notu int,@OgretimYili nvarchar(MAX), @DersAdi nvarchar(MAX)
)
AS
INSERT INTO YilSonuNotlari(OgrenciNo,Notu,OgretimYili,DersID) VALUES (@OgrenciNo,@Notu,@OgretimYili,(SELECT DersID FROM Dersler WHERE DersAdi=@DersAdi))







DECLARE @NotOrtalamasi int SET @NotOrtalamasi = (SELECT dbo.YilSonuBasariNotuEkle((SELECT Notu FROM NotBilgisi WHERE OgrenciNo=1 AND SinavNumarasi=1 AND DersID=1),
(SELECT Notu FROM NotBilgisi WHERE OgrenciNo=1 AND SinavNumarasi=2 AND DersID=1),
(SELECT Notu FROM NotBilgisi WHERE OgrenciNo=1 AND SinavNumarasi=3 AND DersID=1),
(SELECT Notu FROM NotBilgisi WHERE OgrenciNo=1 AND SinavNumarasi=4 AND DersID=1))); EXEC YilSonuBasariNotuKayitEkle 1,@NotOrtalamasi,'2015/2016','Kimya'
