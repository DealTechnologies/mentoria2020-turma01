SELECT u.Nome, F.Titulo FROM Usuario u
INNER JOIN Voto v  ON u.Id = v.IdUsuario 
INNER JOIN Filme F ON v.IdFilme =F.Id


select * from Filme


SELECT * FROM Voto