

-- Create tables
CREATE TABLE IF NOT EXISTS regiao (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    created_at DATE
);

CREATE TABLE IF NOT EXISTS ddd (
    id SERIAL PRIMARY KEY,
    codigo VARCHAR(2) NOT NULL,
    regiao_id INTEGER NOT NULL,
    created_at DATE,
    CONSTRAINT fk_ddd_regiao FOREIGN KEY (regiao_id) REFERENCES regiao(id)
);

CREATE TABLE IF NOT EXISTS contato (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    telefone VARCHAR(9) NOT NULL,
    ddd_id INTEGER NOT NULL,
    created_at DATE,
    CONSTRAINT fk_contato_ddd FOREIGN KEY (ddd_id) REFERENCES ddd(id)
);

-- Insert initial data
INSERT INTO regiao (nome, created_at) VALUES ('Sul', CURRENT_DATE) ON CONFLICT DO NOTHING;
INSERT INTO regiao (nome, created_at) VALUES ('Sudeste', CURRENT_DATE) ON CONFLICT DO NOTHING;
INSERT INTO regiao (nome, created_at) VALUES ('Centro-Oeste', CURRENT_DATE) ON CONFLICT DO NOTHING;
INSERT INTO regiao (nome, created_at) VALUES ('Norte', CURRENT_DATE) ON CONFLICT DO NOTHING;

INSERT INTO ddd (codigo, regiao_id, created_at) VALUES ('31', 2, CURRENT_DATE) ON CONFLICT DO NOTHING;
INSERT INTO ddd (codigo, regiao_id, created_at) VALUES ('51', 1, CURRENT_DATE) ON CONFLICT DO NOTHING;
INSERT INTO ddd (codigo, regiao_id, created_at) VALUES ('38', 2, CURRENT_DATE) ON CONFLICT DO NOTHING;
INSERT INTO ddd (codigo, regiao_id, created_at) VALUES ('44', 1, CURRENT_DATE) ON CONFLICT DO NOTHING;

INSERT INTO contato (nome, email, telefone, ddd_id, created_at) VALUES ('Eddie Vedder', 'eddie.vedder@pearljam.com', '123456789', 1, CURRENT_DATE) ON CONFLICT DO NOTHING;
INSERT INTO contato (nome, email, telefone, ddd_id, created_at) VALUES ('Eloy Casagrande', 'eloy.bighouse@slipknot.com', '123456789', 2, CURRENT_DATE) ON CONFLICT DO NOTHING;
INSERT INTO contato (nome, email, telefone, ddd_id, created_at) VALUES ('Contato para Delete', 'delete@contato.com', '123456789', 2, CURRENT_DATE) ON CONFLICT DO NOTHING;



