Create Database QLivros
GO
Use QLivros
GO
-- Gerado por Oracle SQL Developer Data Modeler 4.0.3.853
--   em:        2015-11-07 17:45:19 BRST
--   site:      SQL Server 2008
--   tipo:      SQL Server 2008




CREATE
  TABLE TabBairro
  (
    idBairro   INTEGER NOT NULL ,
    nmBairro   VARCHAR (100) NOT NULL ,
    fkIdCidade INTEGER NOT NULL ,
    CONSTRAINT TabBairro_PK PRIMARY KEY CLUSTERED (idBairro)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE TabCidade
  (
    idCidade   INTEGER NOT NULL ,
    nmCidade   VARCHAR (100) NOT NULL ,
    fkIdEstado INTEGER NOT NULL ,
    CONSTRAINT TabCidade_PK PRIMARY KEY CLUSTERED (idCidade)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE TabEstado
  (
    idEstado INTEGER NOT NULL ,
    nmEstado VARCHAR (100) NOT NULL ,
    CONSTRAINT TabEstado_PK PRIMARY KEY CLUSTERED (idEstado)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE TabExemplar
  (
    idExemplar INTEGER NOT NULL ,
    nmEditora  VARCHAR (70) NOT NULL ,
    nmAutor    VARCHAR (100) NOT NULL ,
    dsEdicao   VARCHAR (10) NOT NULL ,
    fkIdTitulo INTEGER NOT NULL ,
    dsStatus   INTEGER NOT NULL ,
    dsObs      VARCHAR (200) ,
    CONSTRAINT TabExemplar_PK PRIMARY KEY CLUSTERED (idExemplar)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE TabHistorico
  (
    idHistorico  INTEGER NOT NULL ,
    dtHistorico  DATE NOT NULL DEFAULT 'getdate' ,
    dsStatus     INTEGER NOT NULL ,
    idReceptor	 INTEGER NOT NULL ,
    fkIdExemplar INTEGER NOT NULL ,
    fkIdLeitor   INTEGER NOT NULL ,
    CONSTRAINT TabHistorico_PK PRIMARY KEY CLUSTERED (idHistorico)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE TabLeitor
  (
    idLeitor         INTEGER NOT NULL ,
    dsEmail          VARCHAR (40) NOT NULL ,
    dsLogin          VARCHAR (20) NOT NULL ,
    dsSenha          VARCHAR (20) NOT NULL ,
    nmLeitor         VARCHAR (70) NOT NULL ,
    dsSexo           CHAR (1) NOT NULL ,
    dtNasc           DATE NOT NULL ,
    numCel           VARCHAR (11) NOT NULL ,
    dsRgLeitor       VARCHAR (10) NOT NULL ,
    noEnd            INTEGER NOT NULL ,
    dsComplementoEnd VARCHAR (70) ,
    dsReferenciaEnd  VARCHAR (70) ,
    imFoto           VARCHAR (300) ,
    fkIdCepEnd       INTEGER NOT NULL ,
    dsStatus         INTEGER NOT NULL ,
    CONSTRAINT TabLeitor_PK PRIMARY KEY CLUSTERED (idLeitor)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE TabLog
  (
    idLog      INTEGER NOT NULL ,
    dtLog      DATETIME NOT NULL ,
    fkIdLeitor INTEGER NOT NULL ,
    CONSTRAINT TabLog_PK PRIMARY KEY CLUSTERED (idLog)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE TabLogradouroEnd
  (
    idCepEnd     INTEGER NOT NULL ,
    nmLogradouro VARCHAR (100) NOT NULL ,
    fkIdBairro   INTEGER NOT NULL ,
    CONSTRAINT TabLogradouroEnd_PK PRIMARY KEY CLUSTERED (idCepEnd)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE TabMensagem
  (
    idMensagem  INTEGER NOT NULL ,
    dsMensagem  VARCHAR (300) NOT NULL ,
    fkIdLeitor2 INTEGER NOT NULL ,
    fkIdLeitor1 INTEGER NOT NULL ,
    fkIdSala    INTEGER NOT NULL ,
    dtMensagem  DATETIME NOT NULL ,
    CONSTRAINT TabMensagem_PK PRIMARY KEY CLUSTERED (idMensagem)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE TabResenha
  (
    idResenha     INTEGER NOT NULL ,
    dsResenha     VARCHAR (300) NOT NULL ,
    dsTipoResenha CHAR (1) NOT NULL ,
    fkIdLeitor    INTEGER NOT NULL ,
    fkIdExemplar  INTEGER NOT NULL ,
    CONSTRAINT TabResenha_PK PRIMARY KEY CLUSTERED (idResenha)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE TabSalaChat
  (
    idSala      INTEGER NOT NULL ,
    fkIdLeitor  INTEGER NOT NULL ,
    fkIdLeitor2 INTEGER NOT NULL ,
    CONSTRAINT TabSalaChat_PK PRIMARY KEY CLUSTERED (fkIdLeitor, fkIdLeitor2,
    idSala)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE TabTitulo
  (
    idTitulo INTEGER NOT NULL ,
    nmTitulo VARCHAR (70) NOT NULL ,
    CONSTRAINT TabTitulo_PK PRIMARY KEY CLUSTERED (idTitulo)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

ALTER TABLE TabBairro
ADD CONSTRAINT TabBairro_TabCidade_FK FOREIGN KEY
(
fkIdCidade
)
REFERENCES TabCidade
(
idCidade
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE TabCidade
ADD CONSTRAINT TabCidade_TabEstado_FK FOREIGN KEY
(
fkIdEstado
)
REFERENCES TabEstado
(
idEstado
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE TabExemplar
ADD CONSTRAINT TabExemplar_TabTitulo_FK FOREIGN KEY
(
fkIdTitulo
)
REFERENCES TabTitulo
(
idTitulo
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE TabHistorico
ADD CONSTRAINT TabHistorico_TabExemplar_FK FOREIGN KEY
(
fkIdExemplar
)
REFERENCES TabExemplar
(
idExemplar
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE TabHistorico
ADD CONSTRAINT TabHistorico_TabLeitor_FK FOREIGN KEY
(
fkIdLeitor
)
REFERENCES TabLeitor
(
idLeitor
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE TabLeitor
ADD CONSTRAINT TabLeitor_TabLogradouroEnd_FK FOREIGN KEY
(
fkIdCepEnd
)
REFERENCES TabLogradouroEnd
(
idCepEnd
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE TabLog
ADD CONSTRAINT TabLog_TabLeitor_FK FOREIGN KEY
(
fkIdLeitor
)
REFERENCES TabLeitor
(
idLeitor
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE TabLogradouroEnd
ADD CONSTRAINT TabLogradouroEnd_TabBairro_FK FOREIGN KEY
(
fkIdBairro
)
REFERENCES TabBairro
(
idBairro
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE TabMensagem
ADD CONSTRAINT TabMensagem_TabSalaChat_FK FOREIGN KEY
(
fkIdLeitor2,
fkIdLeitor1,
fkIdSala
)
REFERENCES TabSalaChat
(
fkIdLeitor ,
fkIdLeitor2 ,
idSala
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE TabResenha
ADD CONSTRAINT TabResenha_TabExemplar_FK FOREIGN KEY
(
fkIdExemplar
)
REFERENCES TabExemplar
(
idExemplar
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE TabResenha
ADD CONSTRAINT TabResenha_TabLeitor_FK FOREIGN KEY
(
fkIdLeitor
)
REFERENCES TabLeitor
(
idLeitor
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE TabSalaChat
ADD CONSTRAINT TabSalaChat_TabLeitor_FK FOREIGN KEY
(
fkIdLeitor
)
REFERENCES TabLeitor
(
idLeitor
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE TabSalaChat
ADD CONSTRAINT TabSalaChat_TabLeitor_FKv2 FOREIGN KEY
(
fkIdLeitor2
)
REFERENCES TabLeitor
(
idLeitor
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO


-- Relatório do Resumo do Oracle SQL Developer Data Modeler: 
-- 
-- CREATE TABLE                            12
-- CREATE INDEX                             0
-- ALTER TABLE                             13
-- CREATE VIEW                              0
-- CREATE PACKAGE                           0
-- CREATE PACKAGE BODY                      0
-- CREATE PROCEDURE                         0
-- CREATE FUNCTION                          0
-- CREATE TRIGGER                           0
-- ALTER TRIGGER                            0
-- CREATE DATABASE                          0
-- CREATE DEFAULT                           0
-- CREATE INDEX ON VIEW                     0
-- CREATE ROLLBACK SEGMENT                  0
-- CREATE ROLE                              0
-- CREATE RULE                              0
-- CREATE PARTITION FUNCTION                0
-- CREATE PARTITION SCHEME                  0
-- 
-- DROP DATABASE                            0
-- 
-- ERRORS                                   0
-- WARNINGS                                 0
