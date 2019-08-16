IF EXISTS (SELECT 1 FROM SYS.tables T WHERE T.name ='Salas')
BEGIN
   DROP TABLE dbo.Salas
END
GO

CREATE TABLE dbo.Salas (
             IdSala       INT PRIMARY KEY IDENTITY(1,1),
             NomeSala     VARCHAR(50)
 )
 GO

CREATE INDEX IDX_IdSala ON Salas(IdSala)
GO