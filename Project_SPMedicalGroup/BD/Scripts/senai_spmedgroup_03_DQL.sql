USE SPMedicalGroup
GO

--Mostra todos os tipos de usuários
SELECT * FROM tipoUsuario;

--Mostra todas as clinicas cadastradas
SELECT * FROM clinicas;

--Mostra todas as especilidades
SELECT * FROM especialidades;

--Mostra todos os usuários cadastrados
SELECT * FROM usuarios;

--Mostra todos os prontuarios
SELECT * FROM prontuarios;

--Mostra todos os médicos
SELECT * FROM medicos;

--Mostra todas as consultas já realizadas,canceladas e agendadas
SELECT * FROM consultas;


--Mostra Pacientes e suas consultas (Para a Recpcionista cpm)
SELECT nomePaciente AS Nome,telefonePaciente AS Telefone,dataConsulta AS [Data],situacao AS Situação  FROM prontuarios
INNER JOIN consultas
ON consultas.idProntuario = prontuarios.idProntuario;

--Mostra médicos e clínica em que trabalha
SELECT crm AS CRM,nomeMedico AS Médico,email AS Email,nomeEspecialidade AS Especialidade,nomeClinica AS Clinica,cnpj AS CNPJ,razaoSocial AS [Razão Social],enderecoClinica AS Endereço  FROM medicos
INNER JOIN usuarios
ON usuarios.idUsuario = medicos.idUsuario
INNER JOIN especialidades
ON especialidades.idEspecialidade = medicos.idEspecialidade
INNER JOIN clinicas
ON clinicas.idClinica = medicos.idClinica;


--Mostra as consultas com nome do Paciente, médico que irá atende-lô e a situação da consulta
SELECT nomepaciente,nomeMedico,dataConsulta,situacao FROM consultas
INNER JOIN prontuarios
ON prontuarios.idProntuario = consultas.idProntuario
INNER JOIN medicos
ON medicos.idMedico = consultas.idMedico;

--Mostra os Prontuarios
SELECT nomePaciente AS Nome,email AS Email,dataNascimento AS [Data de Nascimento],telefonePaciente AS Telefone,rg AS RG,cpf AS CPF,enderecoPaciente AS Endereço FROM prontuarios
INNER JOIN usuarios
ON usuarios.idUsuario = prontuarios.idUsuario;

--Mostra todas as Especialidades
SELECT nomeEspecialidade AS Especialidades FROM especialidades;