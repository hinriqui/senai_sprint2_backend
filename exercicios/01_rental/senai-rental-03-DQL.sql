USE LOCADORA

SELECT dataRetirada, dataDevolucao, nomeCliente, nomeModelo, nomeMarca FROM Aluguel
LEFT JOIN Cliente
ON Aluguel.idCliente = Cliente.idCliente
LEFT JOIN Veiculo
ON Aluguel.idAluguel = Veiculo.idAluguel
LEFT JOIN Modelo
ON Veiculo.idModelo = Modelo.idModelo
LEFT JOIN Marca
ON Modelo.idMarca = Marca.idMarca

SELECT dataRetirada, dataDevolucao, nomeCliente, nomeModelo, nomeMarca FROM Aluguel
LEFT JOIN Cliente
ON Aluguel.idCliente = Cliente.idCliente
LEFT JOIN Veiculo
ON Aluguel.idAluguel = Veiculo.idAluguel
LEFT JOIN Modelo
ON Veiculo.idModelo = Modelo.idModelo
LEFT JOIN Marca
ON Modelo.idMarca = Marca.idMarca
WHERE Cliente.nomeCliente = 'Saulo'