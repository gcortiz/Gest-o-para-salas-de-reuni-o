IF EXISTS (SELECT 1 FROM SYS.tables T WHERE T.name ='Funcionarios')
BEGIN
   DROP TABLE dbo.Funcionarios
END
GO

CREATE TABLE dbo.Funcionarios (
             IdFuncionario INT PRIMARY KEY IDENTITY(1,1),
             Nome          VARCHAR(255),
             Cargo         VARCHAR(50),
             Setor         VARCHAR(50)
 )
 GO

CREATE INDEX IDX_IdFuncionario ON Funcionarios(IdFuncionario)
GO