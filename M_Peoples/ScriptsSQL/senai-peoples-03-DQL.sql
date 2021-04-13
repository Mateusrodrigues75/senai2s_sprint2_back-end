USE M_Peoples;

SELECT * FROM Funcionarios;

SELECT IdFuncionario, Nome, Sobrenome 
FROM Funcionarios;

SELECT IdFuncionario, Nome, Sobrenome 
FROM Funcionarios 
WHERE IdFuncionario = 1;

SELECT IdFuncionario, Nome, Sobrenome 
FROM Funcionarios 
WHERE Nome = 'Catarina';

SELECT IdFuncionario, CONCAT (Nome,' ',Sobrenome) AS [Nome Completo], 
DataNascimento FROM Funcionarios;

SELECT IdFuncionario, Nome, Sobrenome, DataNascimento 
FROM Funcionarios 
ORDER BY Nome DESC;