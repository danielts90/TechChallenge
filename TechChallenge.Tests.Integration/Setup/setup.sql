DROP TABLE IF EXISTS contato;
DROP TABLE IF EXISTS ddd;
DROP TABLE IF EXISTS regiao;

CREATE TABLE IF NOT EXISTS regiao (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(100) not null,
	created_at Date
);

INSERT INTO regiao (nome, created_at) VALUES ('Sul', CURRENT_DATE);
INSERT INTO regiao (nome, created_at) VALUES ('Sudeste', CURRENT_DATE);
INSERT INTO regiao (nome, created_at) VALUES ('Centro-Oeste', CURRENT_DATE);
INSERT INTO regiao (nome, created_at) VALUES ('Norte', CURRENT_DATE);


CREATE TABLE IF NOT EXISTS ddd (
	id Serial Primary Key,
	codigo varchar(2) not null,
	regiao_id integer not null,
	created_at Date,
	CONSTRAINT fk_ddd_regiao FOREIGN KEY (regiao_id) REFERENCES regiao(id)
);


INSERT INTO ddd (codigo, regiao_id, created_at) VALUES ('31', 2, CURRENT_DATE);
INSERT INTO ddd (codigo, regiao_id, created_at) VALUES ('51', 1,  CURRENT_DATE);
INSERT INTO ddd (codigo, regiao_id, created_at) VALUES ('38', 2, CURRENT_DATE);
INSERT INTO ddd (codigo, regiao_id, created_at) VALUES ('44', 1, CURRENT_DATE);

CREATE TABLE IF NOT EXISTS contato (
	id Serial Primary Key, 
	nome varchar(100) not null, 
	email varchar(100) not null, 
	telefone varchar(9) not null,
	ddd_id integer not null,
	created_at Date, 
	CONSTRAINT fk_contato_ddd FOREIGN KEY (ddd_id) REFERENCES ddd(id)
);

INSERT INTO contato (nome, email, telefone, ddd_id, created_at) VALUES ('Eddie Vedder', 'eddie.vedder@pearljam.com', '123456789', 1, CURRENT_DATE);
INSERT INTO contato (nome, email, telefone, ddd_id, created_at) VALUES ('Eloy Casagrande', 'eloy.bighouse@slipknot.com', '123456789', 2, CURRENT_DATE);






