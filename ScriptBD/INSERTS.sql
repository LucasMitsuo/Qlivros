USE QLivros
SELECT * FROM TabEstado
INSERT INTO TabEstado VALUES
(1,'AC'),
(2,'AL'),
(3,'AP'),
(4,'AM'),
(5,'BA'),
(6,'CE'),
(7,'DF'),
(8,'ES'),
(9,'GO'),
(10,'MA'),
(11,'MT'),
(12,'MS'),
(13,'MG'),
(14,'PA'),
(15,'PB'),
(16,'PR'),
(17,'PE'),
(18,'PI'),
(19,'RJ'),
(20,'RN'),
(21,'RS'),
(22,'R0'),
(23,'RR'),
(24,'SC'),
(25,'SP'),
(26,'SE'),
(27,'TO')

SELECT * FROM TabCidade 
INSERT INTO TabCidade VALUES
(1,'São Bernardo do Campo',25),
(2,'São Paulo',25),
(3,'Ipanema',19)

SELECT * FROM TabBairro
INSERT INTO TabBairro VALUES
(1,'Vila Pauliceia',1),
(2,'Freguesia do Ó',2),
(3,'Vila Iara',3)

SELECT * FROM TabLogradouroEnd
INSERT INTO TabLogradouroEnd VALUES
(1,'Rua Joaquinha Mancha',1),
(2,'Av. Pereira Macedo',2),
(3,'Rua Marechal Chapecó',3)

SELECT * FROM TabLeitor
INSERT INTO TabLeitor VALUES 
(1,'mitsuo@gmail.com','mitsuo','123','Lucas Mitsuo','M',CONVERT(DATETIME,'21/09/2001',103),'98976-0862','78654782-9','11','','','',1,1),
(2,'thays@gmail.com','thays','123','Thays Boschi','M',CONVERT(DATETIME,'01/11/2000',103),'97892-1162','89773823-9','42','','','',2,1),
(3,'jobson@gmail.com','jobson','123','Jobson Rodriguez','M',CONVERT(DATETIME,'09/02/2005',103),'99873-0862','36137841-0','98','','','',3,1),
(4,'Edjorge@gmail.com','edjorge','123','Edjorge Mariano','M',CONVERT(DATETIME,'09/02/2005',103),'99873-0862','36137841-0','98','','','',2,1)

SELECT * FROM TabTitulo
INSERT INTO TabTitulo VALUES
(1,'Engenharia de Software'),
(2,'Mortos'),
(3,'Molejo')

SELECT * FROM TabExemplar
INSERT INTO TabExemplar VALUES
(1,'Ática','Shigueo Tomomitsu','2',1,1,''),
(2,'Universal','Murilo Gun','1',2,1,''),
(3,'Globo','Fábio Moura','1',3,1,''),
(4,'Record','Shigueo Tomomitsu','3',1,1,'')

SELECT * FROM TabHistorico
INSERT INTO TabHistorico VALUES 
(1,CONVERT(DATETIME,'14/11/2015',103),'','',1,1),
(2,CONVERT(DATETIME,'22/07/2015',103),'','',2,2),
(3,CONVERT(DATETIME,'11/10/2015',103),'','',3,3),
(4,CONVERT(DATETIME,'13/10/2015',103),'','',4,4)
