USE inlock_games_manha;
GO

SELECT * FROM Usuario;
GO

SELECT * FROM Estudio;
GO

SELECT * FROM Jogo;
GO

SELECT NomeJogo, NomeEstudio  FROM Jogo AS J
INNER JOIN Estudio AS E ON J.IdEstudio = E.IdEstudio;
GO

SELECT NomeEstudio, NomeJogo FROM Estudio AS E
LEFT JOIN Jogo AS J ON E.IdEstudio = J.IdEstudio;
GO

SELECT NomeUsuario, IdTipoUsuario FROM Usuario WHERE Email = 'admin@admin.com' AND Senha = 'admin';
GO

SELECT NomeJogo FROM Jogo WHERE IdJogo = 2;
GO

SELECT NomeEstudio FROM Estudio WHERE IdEstudio = 1;
GO