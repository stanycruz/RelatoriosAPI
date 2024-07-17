# RelatoriosAPI

## Descrição
API para gerar relatórios em três formatos: PDF, Excel (*.xlsx) e CSV utilizando o banco de dados AdventureWorks como exemplo.

## Tecnologias Utilizadas
- .NET 8
- EntityFramework Core
- AutoMapper
- FluentValidation
- DinkToPdf
- EPPlus
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
    ```

## Instalação do wkhtmltopdf

### Linux

Para instalar o `wkhtmltopdf` no Linux, siga as instruções abaixo:

```sh
sudo apt update
sudo apt install -y software-properties-common
sudo apt-key adv --keyserver keyserver.ubuntu.com --recv-keys 3B4FE6ACC0B21F32
sudo add-apt-repository "deb http://security.ubuntu.com/ubuntu bionic-security main"
sudo apt update

wget https://github.com/wkhtmltopdf/packaging/releases/download/0.12.6-1/wkhtmltox_0.12.6-1.bionic_amd64.deb
sudo apt install -y ./wkhtmltox_0.12.6-1.bionic_amd64.deb
