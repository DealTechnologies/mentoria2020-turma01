create table colaborador
(
	matricula INT IDENTITY(1,1) not null,
	nome	VARCHAR(50) NOT NULL,
	sobrenome VARCHAR(50) NOT NULL,
	endereco  VARCHAR(50),
	cidade    VARCHAR(50),
	pais	  VARCHAR(25),
	data_nasc DATE NOT NULL CHECK(data_nasc < GETDATE()),
	data_cadastro DATETIME DEFAULT GETDATE()
);

select * from colaborador

create table salario
(
	matricula INT PRIMARY KEY NOT NULL,
	salario DECIMAL(1,1) NOT NULL CHECK(salario < 0),
	FOREIGN KEY(matricula) REFERENCES colaborador(matricula)
);

ALTER TABLE colaborador ADD PRIMARY KEY(MATRICULA)

CREATE TABLE audi_salario
(
	transacao int identity(1,1) not null primary key,
	matricula int not null,
	data_trans DATETIME NOT NULL,
	sal_antigo DECIMAL(10,2),
	sal_novo DECIMAL(10,2),
	usuario VARCHAR(20) NOT NULL
);

ALTER TABLE	audi_salario
ADD FOREIGN KEY (matricula) REFERENCES colaborador(matricula)

alter table colaborador ADD situacao CHAR(1) DEFAULT ('A');
alter table colaborador ADD genero CHAR(1) 

alter table colaborador drop column genero

ALTER TABLE salario DROP CONSTRAINT FK__salario__matricu__7B5B524B

DROP TABLE salario