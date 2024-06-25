# TechChallenge - Grupo 20

![Badge Status](https://img.shields.io/badge/status-active-brightgreen)
[![.NET Core Build, Test, and SonarCloud Analysis](https://github.com/danielts90/TechChallenge/actions/workflows/dotnet-desktop.yml/badge.svg)](https://github.com/danielts90/TechChallenge/actions/workflows/dotnet-desktop.yml)
[![codecov](https://codecov.io/gh/danielts90/TechChallenge/branch/master/graph/badge.svg?token=G4NANCJ6XZ)](https://codecov.io/gh/danielts90/TechChallenge)

## Tabela de Conteúdos

1. [Escopo](#Escopo)
2. [Instalação](#uso)
3. [Configuração](#configuração)
4. [Exemplos](#exemplos)


## Escopo 
### Requisitos Funcionais
Cadastro de contatos: permitir o cadastro de novos contatos, incluindo nome, telefone e e-mail. Associe cada contato a um DDD correspondente à região.

Consulta de contatos: implementar uma funcionalidade para consultar e visualizar os contatos cadastrados, os quais podem ser filtrados pelo DDD da região.

Atualização e exclusão: possibilitar a atualização e exclusão de contatos previamente cadastrados.

### Requisitos Técnicos
Persistência de Dados: utilizar um banco de dados para armazenar as informações dos contatos. Escolha entre Entity Framework Core ou Dapper para a camada de acesso a dados.

Validações: implementar validações para garantir dados consistentes (por exemplo: validação de formato de e-mail, telefone, campos obrigatórios).

Testes Unitários: desenvolver testes unitários utilizando xUnit ou NUnit.

## Instalação

Para a execução do projeto é necessário o SDK .NET 8 e um banco de dados Postgres.

## Configuração 
Para a execução dos testes de integração, é necessário criar um novo container,

```docker
docker run --env=POSTGRES_PASSWORD=102030 --env=POSTGRES_DB=testdb --env=POSTGRES_USER=testuser -p 5432:5432 -d postgres:latest
```

Criação das tabelas da aplicação, elas também podem ser encontradas no arquivo setup.sql
```sql 
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
```

