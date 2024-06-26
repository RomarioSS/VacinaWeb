Pré-requisitos
1.	Ambiente de Desenvolvimento
o	Certifique-se de ter o ambiente de desenvolvimento configurado com o ASP.NET Core 8.
o	Visual Studio 2022 .
2.	Banco de Dados
o	Certifique-se de ter um servidor SQL Server instalado e acessível.
o	O script para a criação do banco está disponível no projeto no caminho ~/scripts/script.sql
Configuração do Projeto

3.	Clone ou Baixe o Projeto
o	Clone o repositório do projeto .

5.	Configuração do Banco de Dados
o	Abra o projeto no Visual Studio .
o	No arquivo appsettings.json (ou similar, dependendo da configuração do seu projeto), ajuste a conexão com o banco de dados para apontar para    "ConnectionString"

7.	Execução do Projeto
o	Abra o terminal integrado no Visual Studio
o	Execute o comando para restaurar as dependências do projeto

9.	Teste dos Endpoints
o	Abra um navegador ou utilize ferramentas como Postman ou Swagger para testar os endpoints definidos nos controladores (PostoController, VacinaController, PostoVacinaController.)

10.	Verificação e Debugging
a.	Verifique o terminal para mensagens de log durante a execução.
b.	Utilize o Swagger para explorar e testar os endpoints de forma interativa.
Essas instruções devem ajudá-lo a configurar e executar o projeto localmente. Certifique-se de ajustar os detalhes específicos, como strings de conexão e configurações de ambiente, conforme necessário para o seu ambiente de desenvolvimento e requisitos do projeto.

12.	Estrutura da Solução 
A solução consiste em uma api com 3 controladores:
PostoController
Consiste em um conjunto de endpoints com a finalidade de incluir, editar, excluir e buscar registros da entidade Posto que corresponde ao posto de vacinação.
VacinaController
Consiste em um conjunto de endpoints com a finalidade de incluir, editar, excluir e buscar registros da entidade Vacina .
PostoVacinaController
Consiste em um conjunto de endpoints com a finalidade de incluir, editar, excluir e buscar registros da entidade PostoVacina que corresponde ao estoque de uma vacina em um posto específicos.

 Através dessas 3 entidades é possível controlar o cadastro de vacinação, de vacinas e do estoque das vacinas em cada posto.

O fluxo de cadastro consiste basicamente em 1: cadastrar um posto de vacinação, 2: cadastrar uma vacina, 3: Cadastrar o Estoque da vacina no posto de vacinação.

As restrições relacionadas a regra de negocio foram desenvolvidas através de restrições no banco de dados garantindo a integridade dos dados.
