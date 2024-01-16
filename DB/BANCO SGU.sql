use SGU
go

select * from sys.tables;
GO
alter table Contato ADD Mensagem text;


GO

CREATE TABLE Usuario (
    ID int PRIMARY KEY,
    Nome varchar(120),
    Email varchar(120) UNIQUE,
    Senha varchar(32),
    Telefone varchar(15),
    TipoUsuario varchar(15)
);

CREATE TABLE Agendamento (
    ID int PRIMARY KEY,
    Tipo varchar(15),
    DtAgendamento datetime,
    fk_Servico_ID int,
    fk_Usuario_ID int
);

CREATE TABLE Servico (
    ID int PRIMARY KEY,
    Descricao varchar(15),
    Valor decimal
);
go



 
ALTER TABLE Agendamento ADD CONSTRAINT FK_Agendamento_2
    FOREIGN KEY (fk_Servico_ID)
    REFERENCES Servico (ID)
    ON DELETE CASCADE;
 
ALTER TABLE Agendamento ADD CONSTRAINT FK_Agendamento_3
    FOREIGN KEY (fk_Usuario_ID)
    REFERENCES Usuario (ID)
    ON DELETE CASCADE;

select * from Usuario
insert into Usuario (ID, Nome, Email, Senha, Telefone, TipoUsuario) 
Values
	(1, 'Gomes', 'karython.unai@gmail.com', 'admin', '61981035447', 'administrador');