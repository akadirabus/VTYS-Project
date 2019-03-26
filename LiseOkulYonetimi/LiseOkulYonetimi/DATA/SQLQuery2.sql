CREATE TRIGGER EklemeIslemiIcin ON NotBilgisi
FOR INSERT
AS
BEGIN
	INSERT INTO IslemListesi (IslemListesi) VALUES ('Müdür bey Not Bilgisi tablosuna bir kayýt ekledi!');
END