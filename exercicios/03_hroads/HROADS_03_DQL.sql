USE SENAI_HROADS_MANHA
GO

SELECT * FROM Personagem

SELECT * FROM Classe

SELECT nomeClasse FROM Classe

SELECT * FROM Habilidade

SELECT COUNT(*) FROM Habilidade

SELECT idHab FROM Habilidade
ORDER BY idHab

SELECT * FROM TipoHab

SELECT nomeHab, nomeTipo FROM Habilidade
LEFT JOIN TipoHab
ON Habilidade.idTipo = TipoHab.idTipo

SELECT nomePerso, nomeClasse FROM Personagem
LEFT JOIN Classe
ON Personagem.idClasse = Classe.idClasse

SELECT nomePerso, nomeClasse FROM Personagem
FULL JOIN Classe
ON Personagem.idClasse = Classe.idClasse

SELECT nomeClasse, nomeHab FROM Classe
LEFT JOIN Classe_Habilidade
ON Classe.idClasse = Classe_Habilidade.idClasse 
LEFT JOIN Habilidade
ON Classe_Habilidade.idHab = Habilidade.idHab

SELECT nomeClasse, nomeHab FROM Habilidade
LEFT JOIN Classe_Habilidade
ON Classe_Habilidade.idHab = Habilidade.idHab
LEFT JOIN Classe
ON Classe_Habilidade.idClasse = Classe.idClasse 

SELECT nomeClasse, nomeHab FROM Habilidade
LEFT JOIN Classe_Habilidade
ON Classe_Habilidade.idHab = Habilidade.idHab
FULL JOIN Classe
ON Classe_Habilidade.idClasse = Classe.idClasse