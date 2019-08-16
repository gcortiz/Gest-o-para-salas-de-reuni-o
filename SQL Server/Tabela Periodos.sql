IF EXISTS (SELECT 1 FROM SYS.tables T WHERE T.name ='Periodos')
BEGIN
   DROP TABLE dbo.Periodos
END
GO

CREATE TABLE dbo.Periodos (
             IdPeriodo    INT PRIMARY KEY IDENTITY(1,1),
             NomePeriodo  VARCHAR(50)
 )
 GO

CREATE INDEX IDX_IdPeriodo ON Periodos(IdPeriodo)
GO