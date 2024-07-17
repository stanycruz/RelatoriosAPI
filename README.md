# RelatoriosAPI

## Descrição
API para gerar relatórios em três formatos: PDF, Excel (*.xlsx) e CSV utilizando o banco de dados AdventureWorks como exemplo.

## Tecnologias Utilizadas
- .NET 8
- EntityFramework Core
- AutoMapper
- FluentValidation
- DinkToPdf
- ClosedXML
- CsvHelper
- SQL Server

## Estrutura do Projeto
- **Domain:** Entidades, interfaces e serviços do domínio.
- **Application:** DTOs, serviços de aplicação e interfaces de uso.
- **Infrastructure:** Implementação da camada de dados e serviços externos.
- **Presentation:** Controladores e configuração da API.

## Configuração
1. Clone o repositório.
2. Configure a string de conexão no `appsettings.json`.
3. Execute os comandos abaixo para restaurar as dependências e rodar o projeto:

```sh
dotnet restore
dotnet run
