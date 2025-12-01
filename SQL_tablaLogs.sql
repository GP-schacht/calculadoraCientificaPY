create database calculosReg


CREATE TABLE OperacionesLog (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Operacion NVARCHAR(255) NOT NULL,       -- Ejemplo: (1+2)
    TipoOperacion NVARCHAR(50) NOT NULL,    -- Ejemplo: suma
    FechaRegistro DATETIME DEFAULT GETDATE() -- Fecha y hora actual
);




