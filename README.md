
# 🏢  `<A2D-Dev />` 
## Sistema de Propostas Imobiliárias

Projeto desenvolvido como parte da transição para a área de desenvolvimento, com foco na aplicação de conceitos de banco de dados em cenários reais do mercado imobiliário.

---

## 📌 Sobre o projeto

Este projeto é uma aplicação para gestão de propostas imobiliárias, desenvolvida como parte do portfólio A2D-Dev.

O objetivo é simular um fluxo real do mercado imobiliário, permitindo o cadastro e acompanhamento de propostas de forma simples e organizada.

Projeto focado em prática de desenvolvimento, modelagem de dados e estruturação de sistemas reais.

---

## 🧠 Visão do Sistema

Este sistema representa uma etapa inicial de uma aplicação completa para gestão de propostas imobiliárias.

O foco atual está na modelagem de dados e estruturação da base do sistema, com evolução futura para backend e frontend.

---

## 🚀 Tecnologias utilizadas

- C#
- ASP.NET (futuro)
- PostgreSQL
- SQL
- DBeaver

---

## 🧩 Funcionalidades

- Cadastro de clientes
- Cadastro de unidades
- Cadastro de propostas
- Controle de status da proposta

---

## 🗄️ Banco de Dados

O banco foi modelado com foco em simplicidade e representação de um cenário real de propostas imobiliárias.

Entidades principais:

- Cliente
- Unidade
- Proposta
- StatusProposta

O objetivo é manter uma estrutura limpa e escalável para evolução futura.

---

## ▶️ Como executar o projeto

1. Criar o banco de dados no PostgreSQL
2. Executar o script `database.sql`
3. Inserir dados nas tabelas
4. Executar consultas com JOIN para visualizar os dados

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
---

## 📈 Aprendizados

Este projeto consolidou na prática:

- Criação de tabelas com SQL (CREATE TABLE)
- Definição de chaves primárias (PRIMARY KEY)
- Relacionamento entre tabelas (FOREIGN KEY)
- Tratamento de dados obrigatórios (NOT NULL)
- Uso de valores padrão (DEFAULT / NOW())
- Execução de consultas com múltiplas tabelas (JOIN)
- Resolução de erro real de integridade (Foreign Key)

---
```

---

## 🧱 Estrutura do Banco

- cliente
- unidade
- status_proposta
- proposta

---

## 🧩 Diagrama do Banco de Dados

Representação das tabelas e seus relacionamentos (chaves estrangeiras).

<img width="397" height="551" alt="image" src="https://github.com/user-attachments/assets/410e9993-fa62-47f2-9992-2cbc301314cd" />

---

## 🧠 Conceitos aplicados

- CREATE TABLE (Criar tabela)
- PRIMARY KEY (Chave primária)
- FOREIGN KEY (Chave estrangeira)
- NOT NULL (Não nulo / obrigatório)
- DEFAULT (Valor padrão)
- JOIN (Junção de tabelas)
- Data Integrity (Integridade de dados)

---

## 👨‍💻 Autor

Desenvolvido por **A2D-Dev**

Em transição para desenvolvimento com foco em soluções reais para o mercado imobiliário.
