USE master
GO

CREATE TABLE dbo.TAB_CLI(
    ID_CLI varchar(50) NOT NULL,
    CPF varchar(11) NOT NULL,
    NM varchar(100) NOT NULL,
    TEL varchar(20) NOT NULL,
    EMAIL varchar(100) NOT NULL,
    CONSTRAINT PK_ID_CLI PRIMARY KEY (ID_CLI)
)
GO

CREATE TABLE dbo.TAB_END(
    ID_END varchar(50) NOT NULL,
    ID_CLI varchar(50) NOT NULL,
    CEP varchar(8) NOT NULL,
    CONSTRAINT PK_ID_END PRIMARY KEY (ID_END),
    CONSTRAINT FK_ID_CLI FOREIGN KEY (ID_CLI) REFERENCES dbo.TAB_CLI(ID_CLI)
)
GO