USE inlock_games_manha;
GO

INSERT TipoUsuario(Titulo)
VALUES			  ('administrador')
				  ,('cliente');
GO

INSERT Usuario(NomeUsuario, Email, Senha, IdTipoUsuario)
VALUES		  ('Jailson Mendes', 'admin@admin.com', 'admin', 1)
			  ,('Michael Scott', 'cliente@cliente.com', 'cliente', 2);
GO

INSERT Estudio(NomeEstudio)
VALUES		  ('Blizzard')
			  ,('Rockstar Studios')
			  ,('Square Enix');
GO

INSERT Jogo(NomeJogo, Descricao, DataLancamento, Valor, IdEstudio)
VALUES	   ('Diablo 3', 'É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.', '20120515', 99.00, 1)
		  ,('Read Dead Redemption II', 'Jogo eletrônico de ação-aventura western.', '20181026', 120.00, 2);
GO