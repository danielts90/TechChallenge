DROP TABLE IF EXISTS contato;
DROP TABLE IF EXISTS ddd;
DROP TABLE IF EXISTS regiao;

CREATE TABLE IF NOT EXISTS regiao (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(100) not null,
	created_at Date
);

CREATE TABLE IF NOT EXISTS ddd (
	id Serial Primary Key,
	codigo varchar(2) not null,
	regiao_id integer not null,
	created_at Date,
	CONSTRAINT fk_ddd_regiao FOREIGN KEY (regiao_id) REFERENCES regiao(id)
);

CREATE TABLE IF NOT EXISTS contato (
	id Serial Primary Key, 
	nome varchar(100) not null, 
	email varchar(100) not null, 
	telefone varchar(9) not null,
	ddd_id integer not null,
	created_at Date, 
	CONSTRAINT fk_contato_ddd FOREIGN KEY (ddd_id) REFERENCES ddd(id)
);


INSERT INTO regiao (nome, created_at) VALUES ('Sul', CURRENT_DATE);
INSERT INTO regiao (nome, created_at) VALUES ('Sudeste', CURRENT_DATE);
INSERT INTO regiao (nome, created_at) VALUES ('Centro-Oeste', CURRENT_DATE);
INSERT INTO regiao (nome, created_at) VALUES ('Norte', CURRENT_DATE);
