# Sistema-Test-Drive

Sistema web de uma concessionária que agenda test drive para os clientes experimentarem os automóveis da loja.

A ideia venho por causa de um projeto que eu fiz no meu curso, a gente desenvolveu toda a parte de casos de uso, prototipação e desenvolvimento do MER, porém, ficou apenas nisso, então, decidi eu mesmo criar esse projeto com algumas bases dessa versão mais antiga, adicionei algumas coisas e removi outras que ao meu ver eram irrelevantes ou não faziam sentido.

## Rodar localmente

É preciso ter instalado em sua máquina o banco de dados <strong>Mysql</strong>. Caso queira usar, também deixei alguns scripts que fazem inserts de registros referentes a cada uma das tabelas.
> Você pode encontrá-los em <ins>Analise-Sistema/banco-de-dados</ins>

É necessário instalar o <a href="https://dotnet.microsoft.com/en-us/download" target="_blank">.Net Core 6</a> para poder usar a API, após isso voce deve entrar no diretório do arquivo e dentro do terminal executar os seguintes comandos:

Para restaurar os arquivos do projeto.
```
dotnet restore
```
Para iniciar as migrações que criarão o banco de dados e as tabelas que o compõem.
```
dotnet ef database update
```
> Para o comando funcionar é necessário você alterar as chaves de acesso, para isso entre na pasta <ins>Api/Models/dbTestDriveContext.cs</ins> e na função OnConfiguring, altere o usuário e a senha para o seu respectivo banco de dados.

Para iniciar a API.
```
dotnet run
```
Depois disso você pode entrar no seguinte diretório <ins>Interface/Pages/Login/login.html</ins> e acessar o link html para ter acesso a interface do site.

<div height="auto" width="1000em" align="center" display="flex">
  <img src="https://user-images.githubusercontent.com/87936511/222870952-058dbe17-5dc5-4086-accd-75d7f49bc253.png" height="550em" width="900em">
</div>

## Funcionalidades

- [x] Login
- [x] Agendar
- [x] Consultar agendamentos
- [x] Desmarcar agendamento
- [x] Editar agendamento
- Feedback
  - [x] Ver avaliações
  - [x] Minhas avaliações
  - [x] Fazer avaliação
  - [x] Editar avaliação
  - [x] Excluir avaliação
- Conta
  - [x] Criar conta
  - [x] Excluir conta
  - [x] Editar conta 
- Gerente
  - [x] Marcar como realizado/não realizado
  - [x] Avaliações dos clientes
- Negocios
  - [x] Usuarios com mais agendamentos
  - [x] Carros mais populares
  - [x] Tests raelizados na semana
  - [x] Modelos mais populares

## Ferramentas utilizadas

<div display="flex" flex-direction="row">
  <img height="40em" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg" />
  <img height="40em" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/mysql/mysql-original.svg" />
  <img height="40em" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/html5/html5-original.svg" />
  <img height="40em" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/css3/css3-original.svg" />
  <img height="40em" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/javascript/javascript-original.svg" />
</div>
               
