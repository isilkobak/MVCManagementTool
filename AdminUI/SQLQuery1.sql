SET IDENTITY_INSERT dbo.Departman OFF;
INSERT INTO dbo.Departman(Ad) VALUES ('Departman A')

SET IDENTITY_INSERT dbo.Departman ON;
INSERT INTO dbo.Departman(Id, Ad) VALUES (1, 'Departman B')

SELECT * FROM dbo.Departman

SET IDENTITY_INSERT dbo.Personel ON;

INSERT INTO dbo.Personel(Ad, Soyad, Telefon, DepartmanId, YoneticiMi) VALUES ('Isil', 'Kobak', '05353491333', 8, 'True')
INSERT INTO dbo.Personel(Ad, Soyad, Telefon, DepartmanId, YoneticiId, YoneticiMi) VALUES ('Berk', 'Dogru', '05556664444', 8, 7, 'True')
INSERT INTO dbo.Personel(Ad, Soyad, Telefon, DepartmanId, YoneticiId, YoneticiMi) VALUES ('Selma', 'Bahar', '05556664444', 8, 8, 'False')
INSERT INTO dbo.Personel(Ad, Soyad, Telefon, DepartmanId, YoneticiMi) VALUES ('Derin', 'Saymaz', '05444441111', 7, 'True')
INSERT INTO dbo.Personel(Ad, Soyad, Telefon, DepartmanId, YoneticiId, YoneticiMi) VALUES ('Cengiz', 'Sahin', '05444441111', 7, 10, 'False')

SET IDENTITY_INSERT dbo.Personel ON;
INSERT INTO dbo.Personel(Id, Ad, Soyad, Telefon, DepartmanId, YoneticiMi) VALUES (5, 'Kaan', 'Yılmaz', '05325553663', 7, 'True')

DELETE FROM dbo.Personel where id = 6;
SELECT * FROM dbo.Personel