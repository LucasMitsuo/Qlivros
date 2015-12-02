USE DB_9E447A_projetoqlivros
SELECT * FROM TabEstado
INSERT INTO TabEstado VALUES
('AC'),
('AL'),
('AP'),
('AM'),
('BA'),
('CE'),
('DF'),
('ES'),
('GO'),
('MA'),
('MT'),
('MS'),
('MG'),
('PA'),
('PB'),
('PR'),
('PE'),
('PI'),
('RJ'),
('RN'),
('RS'),
('R0'),
('RR'),
('SC'),
('SP'),
('SE'),
('TO')

SELECT * FROM TabCidade 
INSERT INTO TabCidade VALUES
('São Bernardo do Campo',25),
('São Paulo',25),
('Ipanema',19),
('Belo Horizonte',13),
('Salvador',5),
('Palmas',27),
('Aracaju',26),
('Rio Branco',1)

SELECT * FROM TabBairro
INSERT INTO TabBairro VALUES
('Vila Pauliceia',1),
('Freguesia do Ó',2),
('Vila Iara',3),
('Acapulco',4),
('Rio das pedras',5),
('Vila juçara',6),
('Bairro nobre',7),
('Palafita ville',8)

SELECT * FROM TabLogradouroEnd
INSERT INTO TabLogradouroEnd VALUES
('Rua Joaquinha Mancha',1),
('Av. Pereira Macedo',2),
('Rua Marechal Chapecó',3),
('Rua itanhaém',4),
('Avenida Vicente de paula',5),
('Rua dos boitacás',6),
('Rua pedrolina',7),
('Rua Jair rodriguez',8)

SELECT * FROM TabLeitor
INSERT INTO TabLeitor VALUES 
('mitsuo@gmail.com','mitsuo','123','Lucas Mitsuo','M',CONVERT(DATETIME,'21/09/2001',103),'98976-0862','78654782-9','11','','','',1,1),
('thays@gmail.com','thays','123','Thays Boschi','M',CONVERT(DATETIME,'01/11/2000',103),'97892-1162','89773823-9','42','','','',2,1),
('jobson@gmail.com','jobson','123','Jobson Rodriguez','M',CONVERT(DATETIME,'09/02/2005',103),'99873-0862','36137841-0','198','','','',3,1),
('edjorge@gmail.com','edjorge','123','Edjorge Mariano','M',CONVERT(DATETIME,'09/02/2005',103),'99873-0862','36137841-0','984','','','',4,1),
('carla@gmail.com','carla','123','Carla Joaquina','F',CONVERT(DATETIME,'21/09/2001',103),'91192-3123','37889982-9','903','','','',5,1),
('anajulia@gmail.com','anajulia','123','Ana Julia','F',CONVERT(DATETIME,'01/11/2000',103),'97892-1162','89773823-9','42','','','',6,1),
('lilica@gmail.com','lilica','123','Lilica Ripilica','F',CONVERT(DATETIME,'09/02/2005',103),'1898-8983','32898651-0','09','','','',7,1),
('barbie@gmail.com','barbie','123','Barbie moda verão','F',CONVERT(DATETIME,'09/02/2005',103),'91983-8897','36137841-0','76','','','',8,1)

SELECT * FROM TabTitulo
INSERT INTO TabTitulo VALUES
('Engenharia de Software'),
('Banco de dados'),
('Molejo'),
('Futebol'),
('Pensamentos de mulher'),
('Corações partidos'),
('Sql'),
('Programação')

SELECT * FROM TabExemplar
INSERT INTO TabExemplar VALUES
('Ática','Shigueo Tomomitsu','2',1,1,''),
('Universal','Murilo Gun','1',2,1,''),
('Globo','Fábio Moura','1',3,1,''),
('Record','Shigueo Tomomitsu','3',4,1,''),
('Esportiva','Edson Arantes','1',5,1,''),
('Estilo','Maria Godoy','3',6,1,''),
('Florestal','Francisco Cuoco','2',7,1,''),
('Livre','Reginaldo Arantes','1',8,1,''),
('Praga','Kiko Meirelles','2',1,1,''),
('Louva','Lucas Jumbo','2',1,1,''),
('Porti','Jefferson Maguila','4',2,1,'')


SELECT * FROM TabHistorico
-- Status 1 = Cadastrado, 2 = Pendente, 3 = Aceito, 4 = Recusado.
INSERT INTO TabHistorico VALUES 
(CONVERT(DATETIME,'14/11/2015',103),1,1,1,null),
(CONVERT(DATETIME,'22/07/2015',103),1,2,2,null),
(CONVERT(DATETIME,'11/10/2015',103),1,3,3,null),
(CONVERT(DATETIME,'13/10/2015',103),1,4,4,null),
(CONVERT(DATETIME,'14/11/2015',103),1,5,5,null),
(CONVERT(DATETIME,'22/07/2015',103),1,6,6,null),
(CONVERT(DATETIME,'11/10/2015',103),1,7,7,null),
(CONVERT(DATETIME,'13/10/2015',103),1,8,8,null),
(CONVERT(DATETIME,'13/10/2015',103),1,9,1,null),
(CONVERT(DATETIME,'13/10/2015',103),1,10,2,null),
(CONVERT(DATETIME,'13/10/2015',103),1,11,3,null),

-- O leitor 1 manda solicitação pro leitor 3 -> Status PENDENTE
(CONVERT(DATETIME,'15/10/2015',103),2,1,1,3),
-- O leitor 3 aceita a solicitação -> Status ACEITO
(CONVERT(DATETIME,'15/10/2015',103),3,1,1,3),
-- O leitor 3 passa a ser o proprietário -> Status DOADO
(CONVERT(DATETIME,'13/10/2015',103),5,1,3,null),


-- O leitor 3 manda solicitação pro 4 ........
(CONVERT(DATETIME,'13/10/2015',103),2,1,3,4),
(CONVERT(DATETIME,'13/10/2015',103),3,1,3,4),
(CONVERT(DATETIME,'13/10/2015',103),5,1,4,null),

-- O leitor 2 manda solicitação pro leitor 1 -> Status PENDENTE
(CONVERT(DATETIME,'13/10/2015',103),2,2,2,1),
-- O leitor 1 aceita a solicitação -> ACEITO
(CONVERT(DATETIME,'13/10/2015',103),3,2,2,1),
-- O leitor 1 passa a ser o proprietário -> Status DOADO
(CONVERT(DATETIME,'13/10/2015',103),5,2,1,null),

-- O leitor 2 manda solicitação pro leitor 1 -> Status PENDENTE
(CONVERT(DATETIME,'13/10/2015',103),2,7,7,8),
-- O leitor 1 aceita a solicitação -> ACEITO
(CONVERT(DATETIME,'13/10/2015',103),3,7,7,8),
-- O leitor 1 passa a ser o proprietário -> Status DOADO
(CONVERT(DATETIME,'13/10/2015',103),5,7,8,null),

-- Leitor 6 possui 2 notificações pendentes
(CONVERT(DATETIME,'14/11/2015',103),2,4,4,6),
(CONVERT(DATETIME,'14/11/2015',103),2,5,5,6)


SELECT * FROM TabHistorico WHERE fkIdExemplar = 1 and (dsStatus = 1 or dsStatus = 5)
SELECT * FROM TabHistorico WHERE fkIdLeitor = 1 and (dsStatus = 1 or dsStatus = 5)
SELECT * FROM TabSalaChat
INSERT INTO TabSalaChat VALUES
(1,2),
(1,3),
(4,1)
