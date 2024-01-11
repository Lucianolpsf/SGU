Create database SG_U
use SG_U
GO


CREATE TABLE Usuario (
    ID int PRIMARY KEY identity (1,1),
    Nome varchar(120),
    Email varchar(120) UNIQUE,
    Senha varchar(32),
    Telefone varchar(15),
    TipoUsuario varchar(15)
);

CREATE TABLE Agendamento (
    ID int PRIMARY KEY identity (1,1),
    Tipo varchar(15),
    DtAgendamento datetime,
    fk_Servico_ID int,
    fk_Usuario_ID int
);

CREATE TABLE Servico (
    ID int PRIMARY KEY identity (1,1),
    Descricao varchar(15),
    Valor decimal
);
go

CREATE TABLE Contato (
    ID int PRIMARY KEY identity (1,1),
    Nome varchar(120),
    Email varchar(120) UNIQUE,
    Telefone varchar(15),
    Mensagem text
);

 
ALTER TABLE Agendamento ADD CONSTRAINT FK_Agendamento_2
    FOREIGN KEY (fk_Servico_ID)
    REFERENCES Servico (ID)
    ON DELETE CASCADE;
 
ALTER TABLE Agendamento ADD CONSTRAINT FK_Agendamento_3
    FOREIGN KEY (fk_Usuario_ID)
    REFERENCES Usuario (ID)
    ON DELETE CASCADE;


	insert into Servico (Descricao, Valor) 
	Values 
		( 'Volume Brasileiro', 120.00)
		,('Volume 5D', 140)
		,('Alongamento Express', 115)
		,('Efeito Sirena', 90)
		,('Hidra Gloss', 85);

select * from Servico;

truncate table Servico

ALTER TABLE Agendamento
DROP CONSTRAINT FK_Agendamento_2;

ALTER TABLE Agendamento
ADD CONSTRAINT FK_Agendamento_Agendamento
FOREIGN KEY (fk_Servico_ID)
REFERENCES Servico (ID)
ON DELETE CASCADE;


create table Manutencao
(
	ID int primary key identity(1,1),
	Tecnica varchar (100),
	Valor_Manutencao decimal (10,2)
);

insert Manutencao (Tecnica, Valor_Manutencao)
Values
	('Volume Brasileiro', 85)
	,('Volume 5D', 100)
	,('Efeito Sirena', 60);

select * from Manutencao