create database SGU
use SGU
go

CREATE TABLE TipoServico (
    ID int PRIMARY KEY identity (1,1),
    Tipo varchar(50)
);

CREATE TABLE Servico (
    ID int PRIMARY KEY identity (1,1),
    Tecnica varchar(50),
    Valor float,
    fk_TipoServico_ID int
);

CREATE TABLE Agendamento (
    ID int PRIMARY KEY identity (1,1),
    dtHoraAgendamento datetime default GETDATE(),
    AgendarData date not null,
    Horario tinyint not null,
    Satisfacao int,
    Confirmacao bit,
    fk_Usuario_ID int,
    fk_Servico_ID int
);

CREATE TABLE Usuario (
    ID int PRIMARY KEY identity (1,1),
    Nome varchar(200) not null,
    Email varchar(200) not null,
    Telefone varchar(50) not null,
	Senha varchar (50) not null,
    TipoUsuario BIT
);

CREATE TABLE Comentario (
    ID int PRIMARY KEY identity (1,1),
    Descricao text not null,
    fk_Usuario_ID int
);
 
ALTER TABLE Servico ADD CONSTRAINT FK_Servico_2
    FOREIGN KEY (fk_TipoServico_ID)
    REFERENCES TipoServico (ID)
    ON DELETE CASCADE;
 
ALTER TABLE Agendamento ADD CONSTRAINT FK_Agendamento_2
    FOREIGN KEY (fk_Usuario_ID)
    REFERENCES Usuario (ID)
    ON DELETE CASCADE;
 
ALTER TABLE Agendamento ADD CONSTRAINT FK_Agendamento_3
    FOREIGN KEY (fk_Servico_ID)
    REFERENCES Servico (ID)
    ON DELETE CASCADE;
 
ALTER TABLE Comentario ADD CONSTRAINT FK_Comentario_2
    FOREIGN KEY (fk_Usuario_ID)
    REFERENCES Usuario (ID)
    ON DELETE CASCADE;

go
insert into Usuario (Nome, Telefone, Email, Senha, TipoUsuario)
values
	('karython', '61981035447', 'karython.unai@gmail.com', 'admin', 'administrador')
go
