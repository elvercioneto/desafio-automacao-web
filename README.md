# Desafio de Automação Selenium WebDriver - Base2 
  
Esse projeto tem 9 metas propostas e faz parte do Desafio Web: Selenium WebDriver da Base2.
# SUT (Software Under Test)
O sistema escolhido para a realização dos testes será o Mantis Bug Tracker.  

# Tecnologias Utilizadas 
- [Docker](https://www.docker.com/) - Ferramenta para levantar containers através de imagens
- [Azure](https://dev.azure.com) - Ferramenta para realizar a integracão contínua do projeto na pipeline
- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/) - Linguagem utilizada para o projeto
- [.NET Core 3.1 ](https://dotnet.microsoft.com/learn) - Plataforma de desenvolvimento
- [NUnit](https://nunit.org/) - Framework .NET que auxilia na construção de testes  
- [ExtentReports](https://www.extentreports.com/) - Biblioteca de relatórios de código aberto

# Setup 
Serão necessárias as seguintes configurações para iniciar o projeto:

# 1. Preparação do ambiente Mantis

No repositório do projeto existe um arquivo chamado **docker-compose.yml**, este arquivo contém um grupo de imagens do Mantis
Crie o diretório local "C:\mantis", baixe o arquivo **docker-compose.yml** e cole neste diretório criado.

## **1.1 Setup Docker Mantis**

1.  Instalar [Docker Desktop](https://www.docker.com/products/docker-desktop) e reiniciar a máquina
2.  Caso apresente o erro "WSL 2 installation is incomplete", [baixe e instale o WSL2 Kernel](https://docs.microsoft.com/pt-br/windows/wsl/wsl2-kernel) e clique em Restart

![](https://i.imgur.com/4wHESjW.png)

3.  Abra o aplicativo Docker Desktop

![](https://i.imgur.com/cyAeSa2.png)

4.  Deverá ser apresentado o tutorial, basta dar skip que você terá esta tela

![](https://i.imgur.com/Myxqwmv.png)

5.  Abra um terminal e acesse o diretório recém criado: "C:/mantis"

6.  No diretório haverá o arquivo **docker-compose.yml**

7.  Execute o comando> `docker-compose.exe up -d`

8.  Após o processamento se tudo correr bem, as imagens serão baixadas e novos contêineres criados:

![](https://i.imgur.com/TPbVjVQ.png)

9.  Para validar a criação e execução dos execute o comando `docker ps -a` e os contêineres estarão disponíveis e executando:

![](https://i.imgur.com/4pZ3IEQ.png)

10. No aplicativo do Docker Desktop apresentará os containeres ativos conforme imagem:

![docker](https://user-images.githubusercontent.com/6169190/157925806-1220a888-7b7a-4dd5-a3c8-6a79c6609eee.png)

  
## **1.2 Configuração inicial Mantis**

Faça o seu primeiro acesso ao Mantis pelo endereço http://127.0.0.1:8989

Após acessar será necessário configurar o banco de dados conforme tabela e valores abaixo:

| Variável | Valor |
|-----|------|
| Type of Database | MySQL Improved |
| Hostname (for Database Server) | mantis_db_1 |
| Username (for Database) | mantisbt |
| Password (for Database) | mantisbt |
| Database name (for Database) | bugtracker |
| Admin Username (to create Database if required) | root |
| Admin Password (to create Database if required) | root |

Após preencher, clicar em **Login/Continue** e aguardar o processamento.

O primeiro acesso deverá ser feito utilizando as credenciais *administrator/root*. Redefinir a senha para o valor *elvercioneto* para rodar os testes.


## **1.3 Acessar banco de dados Mantis/MariaDB**

Para acessar ao banco de dados do Mantis (MariaDB) siga os passos abaixo:

1. Baixe e instale o [software HeidiSQL](https://www.heidisql.com/download.php)

2. Ao abrir o Gerenciador de sessões, preencha com os valores abaixo:

![](https://i.imgur.com/AhKMxvu.png)

3. Abra a conexão e será possível verificar todas as tabelas e registros:

![](https://i.imgur.com/EnYk6Md.png)



*Para esse setup, utilizei como referência o Github do Saymon*
[Mantis4Testers-Docker]https://github.com/saymowan/Mantis4Testers-Docker


## Arquitetura do Projeto

| Diretório         | Funcionalidade     |
| ------------      | ------------ |
| **Bases**         | Contém as classes *PageBase.cs* e *TestBase.cs*, classes de apoio, com objetos de suporte e criação de Relatórios. | 
| **DataBaseSteps** | Contém os métdos de manipulação do banco de dados que serão usados durante o fluxo dos casos de testes. | 
| **DataDriven**    | Em DataDriven/Files existe o arquivo *Issues.csv*. que serve como massa de dados para a execução de testes com Data Driven|
| **Flows**         | Classes que contém os métodos que agrupam as ações em um fluxo que pode ser exercitado em vários casos de teste. |
| **Helpers**       | Classes de apoio para a execução de comandos e uso do WebDriver/RemoteDriver, além de configurações do projeto.| 
| **Pages**         | Classes quem contém o mapeamento dos elementos e ações correspondentes à uma página/tela do sistema. | 
| **Queries**       | Classes e arquivos quem contém consultas ao banco de dados que retornam parâmetros da base para executar o fluxo dos casos de testes. | 
| **Tests**         | Classes quem contémos métodos correspondentes aos testes de uma funcionalidade. | 

## Executando os testes na Pipeline do Azure 

### **1. Subir o projeto para o Github**
### **2. Criar a Pipeline no AzureDevOps**
![pipeline1](https://user-images.githubusercontent.com/6169190/158688930-c487cd38-e021-48f7-8042-7d34262f8245.png)
### **3. Alterar o job Test para rodar somente os testes com a categoria TesteCI**
![jobTest](https://user-images.githubusercontent.com/6169190/158689050-3acb3bd8-7561-4474-930f-efe8df48eac4.png)
### **4. Criar um agent pool pra utilizar a máquina local como runner no Azure**
![agent](https://user-images.githubusercontent.com/6169190/158689104-05325f91-0c12-4728-b7e0-4064605c2ed0.png) 
### **5 Executar o runner**
![runner](https://user-images.githubusercontent.com/6169190/158689258-cd3aeedd-545e-4f29-be09-af5f98330377.png)
### **6. Fazer qualquer alteração no código para a pipeline rodar automaticamente e verificar os resultados**
https://user-images.githubusercontent.com/6169190/158722226-d88b9ebf-607a-4ee1-a2fc-d81ff10a35b4.mp4




## Metas
- [x] 1) Implementar 50 scripts de testes que manipulem uma aplicação web (sugestões: Mantis ou TestLink) com Page Objects.
> Foram implementados as seguintes classes de teste: `IssueTests`, `LoginTests`, `ManageProjectsTests`, `ManageTagsTests`, `ManageUserTests`. Utilizando algumas estratégias, como por exemplo, validação de CRUD, validação de parâmetros obrigatórios, parâmetros de entrada válidos, parâmetros de entrada inválidos, e também a validação de dados enviados com o que foi inserido no banco de dados.
- [x] 2) Alguns scripts devem ler dados de uma planilha Excel para implementar Data-Driven.
 + Quem utilizar Cucumber, SpecFlow ou outra ferramenta de BDD não precisa implementar lendo de uma planilha Excel. Pode ser a implementação de um Scenario Outline.
- [x] 3) Notem que 50 scripts podem cobrir mais de 50 casos de testes se usarmos Data-Driven. Em outras palavras, implementar 50 CTs usando data-driven não é a mesma coisa que implementar 50 scripts
> A classe `DataDrivenTests` implementa a criação de um cenário lendo dados da planilha `Issues.csv` para testes Data-Driven. 
 - [x]  4) Os casos de testes precisam ser executados em no mínimo três navegadores. Utilizando o Selenium Grid.
+ Não é necessário executar em paralelo. Pode ser demonstrada a execução dos
browsers separadamente. 
 > As chaves `Browser` e `Execution` presentes no arquivo `appsettings.json` controlam as configurações de navegador utilizado na execução dos testes e se é uma execução remota (remota) ou WebDriver (local).
 A classe `Browsers` dentro de `Helpers` possui as configurações tanto para rodar nos 03 navegadores (Chrome, Edge, Firefox) que estão aptos a serem executados, quanto para o controlar se a execução será realizada via Grid ou localmente.   
 - [x] 5) Gravar screenshots ou vídeo automaticamente dos casos de testes.
 > O método `GetScreenshot` na classe *ExtentReports.cs* realiza os screenshots durante a execução de cada step em um cenário de testes.
 - [x] 6) O projeto deverá gerar um relatório de testes automaticamente com screenshots ou vídeos
embutidos. Sugestões: Allure Report ou ExtentReport.
 > O relatório de testes é gerado tanto para a execução local quanto remota no formato HTML através dos métodos da classe *ExtentReports.cs*.
 - [x] 7) A massa de testes deve ser preparada neste projeto, seja com scripts carregando massa nova no BD ou com restore de banco de dados.
 > A massa de dados está sendo tratada através do método `ResetMantisDatabase()` na classe `DatabaseHelper` que realiza o restore do Banco de Dados antes da execução dos testes.
 - [x] 8) Um dos scripts deve injetar Javascript para executar alguma operação na tela. O objetivo
aqui é exercitar a injeção de Javascript dentro do código do Selenium.
> No próprio template da Base2 existe um método `SendKeysJavaScript()` na classe *PageBase.cs* que realiza o preenchimento de um campo por ação de JavaScript. Na classe *LoginPage.cs*, o método `InserirLogin` implementa esse script. O método foi utilizado no cenário `RealizarLoginComSucesso()` dentro da classe *LoginTests.cs*
 - [x] 9) Testes deverão ser agendados pelo Gitlab-CI, Azure DevOps, Jenkins, CircleCI, TFS,
TeamCity ou outra ferramenta de CI que preferir
> Os testes estão implementados na pipeline do AzureDevOps. Nele tem uma configuração chamada *Enable continuous integration* que faz com que a cada push realizado no repositório do GitHub, a Pipeline seja disparada automaticamente.

## Referências
- [Data-Driven Testing (DDT) e o reaproveitamento dos testes automatizados](https://medium.com/@saymowan/data-driven-testing-ddt-e-o-reaproveitamento-dos-testes-automatizados-8c8d67cc211c)
- [Run only specific tests when using dotnet test?](https://github.com/nunit/nunit3-vs-adapter/issues/425)
- [Docker Selenium](https://github.com/SeleniumHQ/docker-selenium)
- [Azure DevOps](https://dev.azure.com)
- [GitHub da Daniela Pochini](https://github.com/danielapochini/desafio-automacao-web)
- Meetup Base2(interno) - Implementando pipelines de testes automatizados no Azure DevOps.
