USE inlock_games_manha;
GO

INSERT INTO ESTUDIO (nomeEstudio)
VALUES ('Blizzard'), 
       ('Rockstar Studios'), 
	   ('Square Enix') 
GO

INSERT INTO JOGO (nomeJogo, descricao, dataLancamento, valor, idEstudio)
VALUES ('Diablo 3', '� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�', '15/05/2012', 99.00, 1), 
       ('Red Dead Redemption II', 'jogo eletr�nico de a��o-aventura western', '26/10/2018', 120.00, 2)
GO

INSERT INTO TIPOUSUARIO (titulo)
VALUES ('ADMINISTRADOR'), 
       ('CLIENTE')

INSERT INTO USUARIO (email, senha, idTipoUsuario)
VALUES ('admin@admin.com', 'admin', 1),
	   ('cliente@cliente.com', 'cliente', 2)
GO