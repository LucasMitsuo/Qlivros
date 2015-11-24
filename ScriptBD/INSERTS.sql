USE QLivros
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
('S�o Bernardo do Campo',25),
('S�o Paulo',25),
('Ipanema',19)

SELECT * FROM TabBairro
INSERT INTO TabBairro VALUES
('Vila Pauliceia',1),
('Freguesia do �',2),
('Vila Iara',3)

SELECT * FROM TabLogradouroEnd
INSERT INTO TabLogradouroEnd VALUES
('Rua Joaquinha Mancha',1),
('Av. Pereira Macedo',2),
('Rua Marechal Chapec�',3)

SELECT * FROM TabLeitor
INSERT INTO TabLeitor VALUES 
('mitsuo@gmail.com','mitsuo','123','Lucas Mitsuo','M',CONVERT(DATETIME,'21/09/2001',103),'98976-0862','78654782-9','11','','','',1,1),
('thays@gmail.com','thays','123','Thays Boschi','M',CONVERT(DATETIME,'01/11/2000',103),'97892-1162','89773823-9','42','','','',2,1),
('jobson@gmail.com','jobson','123','Jobson Rodriguez','M',CONVERT(DATETIME,'09/02/2005',103),'99873-0862','36137841-0','98','','','',3,1),
('Edjorge@gmail.com','edjorge','123','Edjorge Mariano','M',CONVERT(DATETIME,'09/02/2005',103),'99873-0862','36137841-0','98','','','',2,1)

SELECT * FROM TabTitulo
INSERT INTO TabTitulo VALUES
('Engenharia de Software'),
('Mortos'),
('Molejo'),
('Futebol'),
('Pensamentos de mulher')

SELECT * FROM TabExemplar
INSERT INTO TabExemplar VALUES
('�tica','Shigueo Tomomitsu','2',1,1,''),
('Universal','Murilo Gun','1',2,1,''),
('Globo','F�bio Moura','1',3,1,''),
('Record','Shigueo Tomomitsu','3',1,1,''),
('Esportiva','Edson Arantes','1',4,1,''),
('Estilo','Maria Godoy','3',5,1,'')

SELECT * FROM TabHistorico
-- Status 1 = Cadastrado, 2 = Pendente, 3 = Aceito, 4 = Recusado.
INSERT INTO TabHistorico VALUES 
(CONVERT(DATETIME,'14/11/2015',103),1,1,1,null),
(CONVERT(DATETIME,'22/07/2015',103),1,2,2,null),
(CONVERT(DATETIME,'11/10/2015',103),1,3,3,null),
(CONVERT(DATETIME,'13/10/2015',103),1,4,4,null),

-- O leitor 1 manda solicita��o pro leitor 3 -> Status PENDENTE
(CONVERT(DATETIME,'15/10/2015',103),2,1,1,3),
-- O leitor 3 aceita a solicita��o -> Status ACEITO
(CONVERT(DATETIME,'15/10/2015',103),3,1,1,3),
-- O leitor 3 passa a ser o propriet�rio -> Status DOADO
(CONVERT(DATETIME,'13/10/2015',103),5,1,3,null),


-- O leitor 3 manda solicita��o pro 4 ........
(CONVERT(DATETIME,'13/10/2015',103),2,1,3,4),
(CONVERT(DATETIME,'13/10/2015',103),3,1,3,4),
(CONVERT(DATETIME,'13/10/2015',103),5,1,4,null),

-- O leitor 2 manda solicita��o pro leitor 1 -> Status PENDENTE
(CONVERT(DATETIME,'13/10/2015',103),2,2,2,1),
-- O leitor 1 aceita a solicita��o -> ACEITO
(CONVERT(DATETIME,'13/10/2015',103),3,2,2,1),
-- O leitor 1 passa a ser o propriet�rio -> Status DOADO
(CONVERT(DATETIME,'13/10/2015',103),5,2,1,null),

(CONVERT(DATETIME,'13/10/2015',103),1,5,3,null),
(CONVERT(DATETIME,'13/10/2015',103),1,6,3,null)


SELECT * FROM TabHistorico WHERE fkIdExemplar = 1 and (dsStatus = 1 or dsStatus = 5)
SELECT * FROM TabHistorico WHERE fkIdLeitor = 1 and (dsStatus = 1 or dsStatus = 5)
SELECT * FROM TabSalaChat
INSERT INTO TabSalaChat VALUES
(1,2),
(1,3),
(4,1)
