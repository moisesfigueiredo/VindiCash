# Vindi Cash API

API simples em .NET 8 para gerenciar contas bancárias e transferências de valores conforme o enunciado.

## Como rodar

Pré-requisitos: .NET 8 SDK instalado.

1. Navegue até a pasta do projeto:
```bash
cd src/Vindi.Cash.Api
```

2. Rode a API:
```bash
dotnet run
```

3. A API estará disponível em `https://localhost:5001` (ou a porta indicada no console). Swagger em `/swagger`.

## Endpoints principais

- `POST /api/Accounts` - criar conta
  - body: `{ "name": "Nome", "document": "12345678900" }`
- `GET /api/Accounts?name=...&document=...` - listar contas (filtros opcionais)
- `POST /api/Accounts/deactivate` - desativar conta
  - body: `{ "document": "...", "performedBy": "usuario" }`
- `POST /api/Transfers` - efetuar transferência
  - body: `{ "fromDocument": "...", "toDocument": "...", "amount": 100, "performedBy": "usuario" }`

## Observações

- Saldo inicial: todas as contas recebem R$1000 ao serem criadas.
- Não há autenticação (segurança física conforme solicitado).
- Deativações são registradas em `DeactivationLogs`.
- Banco em memória (`Microsoft.EntityFrameworkCore.InMemory`) para facilitar execução local.

## Testes

Os testes simples estão em `tests/Vindi.Cash.Api.Tests`. Para rodar:
```bash
dotnet test
```
