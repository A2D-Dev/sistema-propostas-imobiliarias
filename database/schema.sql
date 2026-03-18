-- ========================================
-- Sistema de Propostas Imobiliárias
-- Autor: Anderson Dias (A2D-Dev)
-- Versão: 1.0 (Portfólio - Clean)
-- Banco: PostgreSQL
-- ========================================

-- =========================
-- RESET DO BANCO (SAFE)
-- =========================
DROP TABLE IF EXISTS proposta CASCADE;
DROP TABLE IF EXISTS unidade CASCADE;
DROP TABLE IF EXISTS cliente CASCADE;
DROP TABLE IF EXISTS status_proposta CASCADE;

-- =========================
-- TABELA: cliente
-- =========================
CREATE TABLE cliente (
    id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,

    nome VARCHAR(150) NOT NULL,

    -- CPF, CNPJ ou futuro formato alfanumérico
    documento VARCHAR(20) NOT NULL UNIQUE,

    -- PF = Pessoa Física | PJ = Pessoa Jurídica
    tipo_pessoa CHAR(2) NOT NULL CHECK (tipo_pessoa IN ('PF', 'PJ')),

    email VARCHAR(150),
    telefone VARCHAR(20),

    data_cadastro TIMESTAMPTZ NOT NULL DEFAULT NOW()
);

-- =========================
-- TABELA: unidade
-- =========================
CREATE TABLE unidade (
    id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,

    empreendimento VARCHAR(150) NOT NULL,
    bloco VARCHAR(50),
    numero VARCHAR(20) NOT NULL,

    valor NUMERIC(18,2) NOT NULL,

    data_cadastro TIMESTAMPTZ NOT NULL DEFAULT NOW(),

    CONSTRAINT uq_unidade UNIQUE (empreendimento, bloco, numero)
);

-- =========================
-- TABELA: status_proposta
-- =========================
CREATE TABLE status_proposta (
    id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,

    nome VARCHAR(50) NOT NULL UNIQUE
);

-- =========================
-- TABELA: proposta
-- =========================
CREATE TABLE proposta (
    id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,

    cliente_id INTEGER NOT NULL,
    unidade_id INTEGER NOT NULL,
    status_id INTEGER NOT NULL,

    valor_proposta NUMERIC(18,2) NOT NULL,

    data_proposta TIMESTAMPTZ NOT NULL DEFAULT NOW(),

    CONSTRAINT fk_proposta_cliente
        FOREIGN KEY (cliente_id)
        REFERENCES cliente(id)
        ON DELETE RESTRICT
        ON UPDATE CASCADE,

    CONSTRAINT fk_proposta_unidade
        FOREIGN KEY (unidade_id)
        REFERENCES unidade(id)
        ON DELETE RESTRICT
        ON UPDATE CASCADE,

    CONSTRAINT fk_proposta_status
        FOREIGN KEY (status_id)
        REFERENCES status_proposta(id)
        ON DELETE RESTRICT
        ON UPDATE CASCADE
);

-- =========================
-- DADOS INICIAIS (SEED)
-- =========================
INSERT INTO status_proposta (nome) VALUES
('Em análise'),
('Aprovada'),
('Reprovada'),
('Cancelada');

-- =========================
-- ÍNDICES (PERFORMANCE)
-- =========================
CREATE INDEX idx_proposta_cliente_id ON proposta(cliente_id);
CREATE INDEX idx_proposta_unidade_id ON proposta(unidade_id);
CREATE INDEX idx_proposta_status_id ON proposta(status_id);
