<h1 align="center">
  <br>
  Relatórios Web API
  <br>
</h1>

<h4 align="center">Web API em .NET 8 para geração de relatórios em PDF, Excel e CSV utilizando AdventureWorks como exemplo.</h4>

<p align="center">
  <a href="#descrição">Descrição</a> •
  <a href="#tecnologias-utilizadas">Tecnologias</a> •
  <a href="#estrutura-do-projeto">Estrutura</a> •
  <a href="#configuração">Configuração</a> •
  <a href="#instalação-do-wkhtmltopdf">Instalação</a> •
  <a href="#licença">Licença</a>
</p>

---

## 📖 Descrição
Web API para gerar relatórios em três formatos: PDF, Excel (*.xlsx) e CSV utilizando o banco de dados AdventureWorks como exemplo.

---

## 🛠 Tecnologias Utilizadas
- .NET 8
- EntityFramework Core
- AutoMapper
- FluentValidation
- DinkToPdf
- EPPlus
- CsvHelper
- SQL Server

---

## 📂 Estrutura do Projeto
- **Domain:** Entidades, interfaces e serviços do domínio.
- **Application:** DTOs, serviços de aplicação e interfaces de uso.
- **Infrastructure:** Implementação da camada de dados e serviços externos.
- **Presentation:** Controladores e configuração da API.

---

## ⚙️ Configuração

1. Clone o repositório:

    ```sh
    git clone https://github.com/stanycruz/RelatoriosAPI.git
    cd RelatoriosAPI
    ```

2. Configure a string de conexão no `appsettings.json`.

3. Execute os comandos abaixo para restaurar as dependências e rodar o projeto:

    ```sh
    dotnet restore
    dotnet run
    ```

---

## 📦 Instalação do wkhtmltopdf

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
```

---

## 📜 Licença
Este projeto é distribuído sob a licença **MIT**.

---

## 🤝 Contribuições

Contribuições são sempre bem-vindas!  
Sinta-se à vontade para abrir uma *issue* ou enviar um *pull request* com melhorias, correções ou novas ideias para este projeto.
