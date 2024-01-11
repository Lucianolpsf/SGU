select  * from Servico
select * from Contato
select * from Usuario


create table Manutencao
(
	ID int primary key identity(1,1),
	Tecnica varchar (100),
	Valor_Manutencao decimal (10,2)
);

select * from Manutencao
truncate table Servico

ALTER TABLE Agendamento
DROP CONSTRAINT FK_Agendamento_2;

ALTER TABLE Agendamento
ADD CONSTRAINT FK_Agendamento_Agendamento
FOREIGN KEY (fk_Servico_ID)
REFERENCES Servico (ID)
ON DELETE CASCADE;

alter table Manutencao
add fk_Agendamento_ID int

ALTER TABLE Manutencao
ADD CONSTRAINT FK_Manutencao
FOREIGN KEY (fk_Agendamento_ID)
REFERENCES Agendamento (ID)
ON DELETE CASCADE;

ALTER TABLE Servico
ALTER COLUMN Descricao VARCHAR(100); -- Altere para o tamanho desejado


insert into Servico (ID,Descricao, Valor) 
	Values 
		( 1,'Volume Brasileiro', 120.00)
		,(2,'Volume 5D', 140)
		,(3,'Alongamento Express', 115)
		,(4,'Efeito Sirena', 90)
		,(5,'Hidra Gloss', 85);

insert Manutencao (Tecnica, Valor_Manutencao)
Values
	('Volume Brasileiro', 85)
	,('Volume 5D', 100)
	,('Efeito Sirena', 60);
