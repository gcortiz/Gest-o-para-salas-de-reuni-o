IF EXISTS (SELECT 1 FROM SYS.tables T WHERE T.name ='Reservas')
BEGIN
   DROP TABLE dbo.Reservas
END
GO

CREATE TABLE dbo.Reservas (
             IdReserva     INT PRIMARY KEY IDENTITY(1,1),
             DtDaReserva   DATETIME,
             DtReservada   DATETIME,
             IdFuncionario INT,
             Funcionario   VARCHAR(255),
             IdSala        INT,
             Sala          VARCHAR(255),
             IdPeriodo     INT,
             Periodo       VARCHAR(50),
 )
 GO

CREATE INDEX IDX_IdReserva ON Reservas(IdReserva)
GO

CREATE INDEX IDX_IdFuncionario ON Reservas(IdFuncionario)


CREATE INDEX IDX_IdSala ON Reservas(IdSala)
GO

CREATE INDEX IDX_IdPeriodo ON Reservas(IdPeriodo)
GO
