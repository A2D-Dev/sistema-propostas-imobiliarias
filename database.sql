-- ========================================
-- Sistema de Propostas Imobiliárias
-- Autor: Anderson Dias (A2D Dev)
-- Descrição: Estrutura de banco de dados
-- ========================================
-- =========================
-- TABELA CLIENTE
-- =========================
CREATE TABLE cliente (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(150) NOT NULL,
    cpf VARCHAR(11) NOT NULL,
    email VARCHAR(150),
    telefone VARCHAR(20),
    data_cadastro TIMESTAMP NOT NULL DEFAULT NOW()
);

-- =========================
-- TABELA UNIDADE
-- =========================
CREATE TABLE unidade (
    id SERIAL PRIMARY KEY,
    empreendimento VARCHAR(150) NOT NULL,
    bloco VARCHAR(50),
    numero VARCHAR(20) NOT NULL,
    valor DECIMAL(18,2) NOT NULL,
    data_cadastro TIMESTAMP NOT NULL DEFAULT NOW()
);

-- =========================
-- TABELA STATUS
-- =========================
CREATE TABLE status_proposta (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(50) NOT NULL
);

-- =========================
-- TABELA PROPOSTA
-- =========================
CREATE TABLE proposta (
    id SERIAL PRIMARY KEY,
    cliente_id INT NOT NULL,
    unidade_id INT NOT NULL,
    status_id INT NOT NULL,
    valor_proposta DECIMAL(18,2) NOT NULL,
    data_proposta TIMESTAMP NOT NULL DEFAULT NOW(),

    CONSTRAINT fk_proposta_cliente
        FOREIGN KEY (cliente_id) REFERENCES cliente(id),

    CONSTRAINT fk_proposta_unidade
        FOREIGN KEY (unidade_id) REFERENCES unidade(id),

    CONSTRAINT fk_proposta_status
        FOREIGN KEY (status_id) REFERENCES status_proposta(id)
);
