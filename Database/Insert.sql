INSERT INTO Cidades (Nome) VALUES ('Blumenau')
INSERT INTO Cidades (Nome) VALUES ('São José do Rio Preto')
GO

INSERT INTO Especialidades (Nome) VALUES ('Cardiologista')
INSERT INTO Especialidades (Nome) VALUES ('Neurologista')
GO

Insert Into Usuarios (Nome, Login, Senha, Email) Values ('Administrador', 'admin', '40BD001563085FC35165329EA1FF5C5ECBDBBEEF','admin@cdmm.com')
GO

INSERT INTO BannersPublicitarios (TituloCampanha, BannerCampanha, LinkBanner) VALUES
('Campanha Conio', 'logo-conio-cademeumedico.png','http://conio.com.br')
INSERT INTO BannersPublicitarios (TituloCampanha, BannerCampanha, LinkBanner) VALUES
('Campanha Casa do Código', 'banner-cdc-cademeumedico.png', 'http://casadocodigo.com.br')
GO