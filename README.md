---
Documentação da API de Cadastro de Pessoas
---

# API de Cadastro de Pessoas

Bem-vindo à documentação da API de Cadastro de Pessoas! Esta API foi desenvolvida utilizando o framework .NET Core, seguindo o padrão Repository Design Patterns. 
O banco de dados utilizado é o SQLite. O projeto foi configurado no Visual Studio e é executado em um ambiente Docker.

## Configuração do Ambiente

Certifique-se de ter o .NET Core SDK, o Docker e o Visual Studio instalados em sua máquina antes de prosseguir.

## Configuração do Projeto

1. Clone este repositório para a sua máquina local.
2. Abra e Execute o projeto no Visual Studio.
3. Certifique-se de que a conexão com o banco de dados SQLite está configurada corretamente no arquivo `appsettings.json`.
4. No terminal (Propmt de Comando), navegue até a pasta docker e rode o comando `docker compose up` para iniciar o container do banco de dados SQLite.
6. No terminal (Propmt de Comando), rode o comando `docker ps` para verificar se o container está em execução.


## Endpoints da API

A API oferece os seguintes endpoints para gerenciar o cadastro de pessoas:

- `GET /api/person`: Retorna a lista de todas as pessoas cadastradas.
- `GET /api/person/{id}`: Retorna os detalhes de uma pessoa específica com base no ID.
- `POST /api/person`: Cadastra uma nova pessoa. Envie os detalhes no corpo da solicitação.
- `PUT /api/person/{id}`: Atualiza os detalhes de uma pessoa existente com base no ID.
- `DELETE /api/person/{id}`: Remove uma pessoa do cadastro com base no ID.

## Dependências (Pacotes)

- Microsoft.AspNetCore.Mvc.NewtonsoftJson (6.0.7)
- Microsoft.EntityFrameworkCore (6.0.7)
- Microsoft.EntityFrameworkCore.Design (6.0.7)
- Microsoft.EntityFrameworkCore.Sqlite (6.0.7)
- Microsoft.EntityFrameworkCore.Tools (6.0.7)
- Microsoft.Extensions.DependencyInjection (6.0.1)
- AutoMapper (12.0.0)
- AutoMapper.Extensions.Microsoft.DependencyInjection (12.0.0)

## Migrations
- dotnet ef migrations add InitialCreate
- dotnet ef database update
