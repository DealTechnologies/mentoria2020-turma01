CREATE TABLE Voto
(
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	IdUsuario INT NOT NULL,
	IdFilme INT NOT NULL,
	CONSTRAINT IdUsuario FOREIGN KEY (IdUsuario) REFERENCES  Usuario (Id),
	CONSTRAINT IdFilme FOREIGN KEY (IdFilme) REFERENCES  Filme (Id),
);

USE Votacao;