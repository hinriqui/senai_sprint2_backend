USE SENAI_HROADS_MANHA
GO

INSERT INTO Classe (nomeClasse)
VALUES('Bárbaro'), ('Cruzado'), ('Caçadora de Demônios'), ('Monge'), ('Necromante'), ('Feiticeiro'), ('Arcanista')

INSERT INTO TipoHab (nomeTipo)
VALUES('Ataque'), ('Defesa'), ('Cura'), ('Magia')
GO

INSERT INTO Personagem (idClasse, nomePerso, vidaMax, manaMax, dataAtua, dataCria)
VALUES( 1, 'DeuBug', 100, 80, '2021-08-10', '2019-01-18' ), ( 4, 'BitBug', 70, 100, '2021-08-10', '2016-03-17' ), ( 7, 'Fer8', 75, 60, '2021-08-10', '2018-03-18' )

INSERT INTO Habilidade (idTipo, nomeHab)
VALUES( 1, 'Lança Mortal' ), ( 2, 'Escudo Supremo' ), ( 3, 'Recuperar Vida' )
GO

INSERT INTO Classe_Habilidade (idClasse, idHab)
VALUES( 1, 1 ), ( 1, 2 ), ( 2, 2 ), ( 3, 1 ), ( 4, 3 ), ( 4, 2 ), ( 5, NULL ), ( 6, 3 ), ( 7, NULL )

UPDATE Personagem
SET nomePerso = 'Fer7'
WHERE nomePerso = 'Fer8'

UPDATE Classe
SET nomeClasse = 'Necromancer'
WHERE nomeClasse = 'Necromante'

INSERT INTO TipoUsuario (titulo)
VALUES ('Administrador'), ('Jogador')