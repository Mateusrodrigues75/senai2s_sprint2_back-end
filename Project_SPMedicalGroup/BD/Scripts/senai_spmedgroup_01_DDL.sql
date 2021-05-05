CREATE DATABASE SPMedicalGroup
GO

USE SPMedicalGroup
GO

--Cria a tabela de tipos de usuários
CREATE TABLE tipoUsuario
(
	idTipoUsuario INT PRIMARY KEY IDENTITY
	,tituloTipoUsuario VARCHAR(14) NOT NULL
);
GO

--Cria a tabela de Clinicas
CREATE TABLE clinicas
(
	idClinica INT PRIMARY KEY IDENTITY
	,nomeClinica VARCHAR(200) NOT NULL
	,cnpj VARCHAR(14) NOT NULL
	,razaoSocial VARCHAR(200) NOT NULL
	,enderecoClinica VARCHAR(250) NOT NULL
	,horarioFuncionamento VARCHAR NOT NULL
);
GO

--Cria a tabela de Especialidades
CREATE TABLE especialidades
(
	idEspecialidade INT PRIMARY KEY IDENTITY
	,nomeEspecialidade VARCHAR(200) NOT NULL
);
GO

--Cria a tabela de usuarios
CREATE TABLE usuarios
(
	idUsuario INT PRIMARY KEY IDENTITY
	,idTipoUsuario INT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario)
	,nomeUsuario VARCHAR(50) NOT NULL
	,email VARCHAR(200) NOT NULL
	,senha VARCHAR(15) NOT NULL
);
GO

--Cria a tablea de prontuarios
CREATE TABLE prontuarios
(
	idProntuario INT PRIMARY KEY IDENTITY
	,idUsuario INT FOREIGN KEY REFERENCES usuarios(idUsuario)
	,nomePaciente VARCHAR(200) NOT NULL
	,rg VARCHAR(9) NOT NULL
	,cpf VARCHAR(11) NOT NULL
	,enderecoPaciente VARCHAR(250) NOT NULL
	,dataNascimento DATE NOT NULL
	,telefonePaciente VARCHAR(11) NOT NULL
);
GO

--Cria a tabela de médicos
CREATE TABLE medicos
(
	idMedico INT PRIMARY KEY IDENTITY 
	,idClinica INT FOREIGN KEY REFERENCES clinicas(idClinica)
	,idUsuario INT FOREIGN KEY REFERENCES usuarios(idUsuario)
	,idEspecialidade INT FOREIGN KEY REFERENCES especialidades (idEspecialidade)
	,nomeMedico VARCHAR(200) NOT NULL
	,crm VARCHAR(7) NOT NULL
);
GO

--Cria a tabela de consultas
CREATE TABLE consultas
(
	idConsulta INT PRIMARY KEY IDENTITY
	,idProntuario INT FOREIGN KEY REFERENCES prontuarios(idProntuario)
	,idMedico INT FOREIGN KEY REFERENCES medicos(idMedico)
	,dataConsulta DATETIME NOT NULL
	,situacao VARCHAR(100) NOT NULL
	,descricao VARCHAR(255)
);
GO
