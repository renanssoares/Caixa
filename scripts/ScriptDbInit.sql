USE master
CREATE DATABASE Caixa 
GO
USE Caixa
GO
CREATE TABLE Comerciante (
    Id INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    Nome VARCHAR(255) NOT NULL,
    Cnpj VARCHAR(14) NOT NULL,
	Ativo bit NOT NULL
);

GO

CREATE TABLE TipoTransacao (
    Id INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    Nome VARCHAR(50) NOT NULL    
);

GO

CREATE TABLE Transacao (
    Id INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    ComercianteId INT NOT NULL,
    TipoTransacaoId INT NOT NULL,
	valor DECIMAL(10, 2) NOT NULL,
    Data DATE NOT NULL,
    Descricao VARCHAR(255) NULL,

    FOREIGN KEY (ComercianteId) REFERENCES Comerciante(Id),
    FOREIGN KEY (TipoTransacaoId) REFERENCES TipoTransacao(Id)
);

GO

INSERT INTO TipoTransacao
(Nome) VALUES ('Débito'),('Crédito')
 
GO

INSERT INTO Comerciante
(Nome, Cnpj, Ativo) 
VALUES
('Comerciante Ativo', '00000000000191', 1),
('Comerciante Desativado', '00000000000191', 0)
