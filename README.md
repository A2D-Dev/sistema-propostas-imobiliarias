# 🏢 Sistema de Propostas Imobiliárias

Projeto desenvolvido como parte da minha transição para a área de desenvolvimento, aplicando conceitos de banco de dados com foco em problemas reais do mercado imobiliário.

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

### 🧩 Diagrama do Banco de Dados
---
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
## ▶️ Como executar o projeto

1. Criar o banco de dados no PostgreSQL
2. Executar o script `database.sql`
3. Inserir dados nas tabelas
4. Executar consultas com JOIN para visualizar os dados
