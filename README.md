# EmprestimoJogos
Sistema de empréstimo de jogos

Package utilizados:
* Entity Framework;
* Ninject;
* Razor;
* MVC;
* MSTest;
* JQuery;

Técnicas e Padrões de projeto utilizados;
* Repository (genérico);
* Service;
* TDD;
* Code First.

Instruções para compilar a solução:

* Restaure os Packages através do nuget package;

* Edite o arquivo "EmprestimoJogos.Web\Web.config", modificando o "Server" e "Password" de acordo o servidor SQL Server instalado.
 Ex.:
  <connectionStrings>
    <add name="Emprestimo" connectionString="Server=xxxxxx;Database=Emprestimo;User ID=sa;Password=xxxxx;" providerName="System.Data.SqlClient" />
  </connectionStrings>


* No visual studio, abra o arquivo "EmprestimoJogos.sln", defina o "EmprestimoJogos.Web" como projeto de inicialização, compile e execute.

Ao executar a aplicação deverá preencher os seguintes dados:
Email: sidcleym@gmail.com
Senha: 123456

Projetos na Solução :

* EmprestimoJogos.Domain: Aplicação em Class Library com Modelos, infraestrutura de banco, repositorio e services utilizados para persistência das entidades;
* EmprestimoJogos.Tests: Aplicação de Testes de unidade;
* EmprestimoJogos.Web: Interface web (Views e Controlers).
