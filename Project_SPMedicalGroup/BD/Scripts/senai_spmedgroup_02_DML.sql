USE SPMedicalGroup
GO

--Insere os tipos de usuário
INSERT INTO tipoUsuario(tituloTipoUsuario)
VALUES		('Administrador')
			,('Médico')
			,('Paciente');
GO

--Insere as clinicas
INSERT INTO clinicas(nomeClinica,cnpj,razaoSocial,enderecoClinica)
VALUES		('Clinica Possarle',86400902000130,'SP Medical Group','Av. Barão Limeira, 532, São Paulo, SP');
GO

--Insere as especialidades
INSERT INTO especialidades(nomeEspecialidade)
VALUES		('Acupuntura')
			,('Anestesiologia')
			,('Angiologia')
			,('Cardiologia')
			,('Cirurgia Cardiovascular')
			,('Cirurgia da Mão')
			,('Cirurgia do Aparelho Digestivo')
			,('Cirurgia Geral')
			,('Cirurgia Pediátrica')
			,('Cirurgia Plástica')
			,('Cirurgia Torácica')
			,('Cirurgia Vascular')
			,('Dermatologia')
			,('Radioterapia')
			,('Urologia')
			,('Pediatria')
			,('Psiquiatria');
GO

--Insere os usuários
INSERT INTO usuarios(idTipoUsuario,nomeUsuario,email,senha)
VALUES		(1,'admin','admin@spmedicalgroup.com.br','admin1234')
			,(2,'ricardo.lemos','ricardo.lemos@spmedicalgroup.com.br','ricardo1234')
			,(2,'roberto.possarle','roberto.possarle@spmedicalgroup.com.br','roberto1234')
			,(2,'helena.strada','helena.souza@spmedicalgroup.com.br','helena1234')
			,(3,'ligia','ligia@gmail.com','ligia1234')
			,(3,'alexandre','alexandre@gmail.com','alexandre1234')
			,(3,'fernando','fernando@gmail.com','fernando1234')
			,(3,'henrique','henrique@gmail.com','henrique1234')
			,(3,'joao','joao@hotmail.com','joao1234')
			,(3,'bruno','bruno@gmail.com','bruno1234')
			,(3,'mariana','mariana@outlook.com','mariana1234');
GO

--Insere os prontuarios
INSERT INTO prontuarios(idUsuario,nomePaciente,rg,cpf,enderecoPaciente,dataNascimento,telefonePaciente)
VALUES		(5,'Ligia','435225435','94839859000','Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000','13/10/1983','1134567654')
			,(6,'Alexandre','326543457','73556944057','Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200','23/07/2001','11987656543')
			,(7,'Fernando','546365253','16839338002','Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200','10/10/1978','11972084453')
			,(8,'Henrique','543663625','14332654765','R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030','13/10/1985','1134566543')
			,(9,'João','325444441','91305348010','R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380','27/08/1975','1176566377')
			,(10,'Bruno','545662667','79799299004','Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001','21/03/1972','11954368769')
			,(11,'Mariana','545662668','13771913039','R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140','05/03/2018','');
GO

--Insere os médicos
INSERT INTO medicos(idClinica,idUsuario,idEspecialidade,nomeMedico,crm)
VALUES		(1,2,2,'Ricardo Lemos','54356SP')
			,(1,3,17,'Roberto Possarle','53452SP')
			,(1,4,16,'Helena Strada','65463SP');
GO

--Insere as consultas
INSERT INTO consultas(idProntuario,idMedico,dataConsulta,situacao)
VALUES		(7,3,'20/01/2020  15:00:00','Realizada')
			,(2,2,'20/01/2020  15:00:00','Cancelada')
			,(3,2,'07/02/2020  11:00:00','Realizada')
			,(2,2,'06/02/2018  10:00:00','Realizada')
			,(4,1,'07/02/2019  11:00:45','Cancelada')
			,(7,3,'08/03/2020  15:00:00','Agendada')
			,(4,1,'09/03/2020  11:00:45','Agendada');
GO
