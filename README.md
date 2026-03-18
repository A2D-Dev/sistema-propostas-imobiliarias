# 🏢 Sistema de Propostas Imobiliárias

Projeto desenvolvido como parte do meu aprendizado em desenvolvimento de software, com foco em banco de dados e lógica de negócio do mercado imobiliário.

---

## 🎯 Objetivo

Simular o fluxo de propostas imobiliárias, incluindo:

- Cadastro de clientes
- Cadastro de unidades
- Controle de status de proposta
- Registro de propostas
- Consulta de dados com JOIN

---

## 🧱 Estrutura do Banco

- cliente
- unidade
- status_proposta
- proposta

---

## 🧠 Conceitos aplicados

- CREATE TABLE
- PRIMARY KEY
- FOREIGN KEY
- NOT NULL
- DEFAULT
- JOIN
- Integridade de dados

---

## 💡 Exemplo de consulta

```sql
SELECT 
    c.nome,
    u.empreendimento,
    u.numero,
    p.valor_proposta,
    s.nome AS status
FROM proposta p
JOIN cliente c ON p.cliente_id = c.id
JOIN unidade u ON p.unidade_id = u.id
JOIN status_proposta s ON p.status_id = s.id;
