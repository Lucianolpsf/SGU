
use SGU

create table TipoServico
(
	ID int primary key identity(1,1),
	Tipo varchar(50)
);

alter table Servico
add ID_Tipo_Servico int;

go

alter table Servico
add constraint FK_ID_Tipo_Servico
foreign key (ID_Tipo_Servico)
References TipoServico(ID)
on delete cascade;

exec sp_rename 'Servico.Descricao', 'Tecnica', 'COLUMN';

alter table Servico
alter column Valor float;

create table Comentario
(
	ID int primary key identity (1,1),
	Descricao text,
	ID_Usuario int
);

alter table Comentario
add constraint FK_ID_Usuario
foreign key (ID_Usuario)
references Usuario(ID)
on delete cascade;


alter table Usuario
alter column TipoUsuario varchar(50);

alter table Usuario
alter column Telefone varchar(50);

alter table Agendamento
drop column Tipo;

alter table Agendamento
add AgendarData Date not null;

alter table Agendamento
add Horario tinyint not null;

alter table Agendamento
add Satisfacao tinyint;

alter table Agendamento
add Confirmacao bit;