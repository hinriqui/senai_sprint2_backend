USE inlock_games_manha;
GO

SELECT * FROM USUARIO

SELECT * FROM ESTUDIO

SELECT * FROM JOGO

SELECT nomeJogo, nomeEstudio
FROM JOGO
INNER JOIN ESTUDIO
ON JOGO.idEstudio = ESTUDIO.idEstudio

SELECT nomeEstudio, nomeJogo
FROM ESTUDIO
LEFT JOIN JOGO
ON ESTUDIO.idEstudio = JOGO.idEstudio

SELECT * FROM USUARIO
WHERE USUARIO.email = 'cliente@cliente.com' AND USUARIO.senha = 'cliente'

SELECT nomeJogo
FROM JOGO
WHERE JOGO.idJogo = 1

SELECT nomeEstudio
FROM ESTUDIO
WHERE ESTUDIO.idEstudio = 1


