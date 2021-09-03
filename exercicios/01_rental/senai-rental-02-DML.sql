USE M_Rental

INSERT INTO Empresa (nomeEmpresa)
VALUES('Beto Carrero'), ('Microsoft')

INSERT INTO Marca (nomeMarca)
VALUES('Fiat'), ('Honda')

INSERT INTO Modelo (nomeModelo, idMarca)
VALUES('Uno', 1), ('Civic', 2), ('Fit', 2)

INSERT INTO Cliente (nomeCliente, Sobrenome, cpfCliente)
VALUES('Saulo', 'Santos', 1111), ('Odirlei', 'Sabella', 2222), ('Thiago', 'Nascimento', 3333)

INSERT INTO Aluguel(idCliente, dataRetirada, dataDevolucao)
VALUES(1, '10/03/2020', '10/03/2022'), (2, '05/07/2021', '05/01/2022'), (3, '08/08/2020', '08/03/2021')

INSERT INTO Veiculo (idEmpresa, idModelo, idAluguel, placaVeiculo)
VALUES(1, 2, 3, 'ABC1234'), (2, 1, 1, 'CBA4321')