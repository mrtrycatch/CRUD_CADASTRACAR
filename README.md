# Cadastracar
CRUD para cadastro de veículos com ASP NET Core MVC (C#).

## Descrição do projeto
<p align="justify">
Neste projeto, em <b>ASP NET Core</b>, no padrão <b>MVC</b>, desenvolvi um CRUD para cadastro
de veículos.<br>
Na solução há dois projetos com as seguintes responsabilidades:
O projeto <b>Cadastracar.DATA</b> é responsável por acessar os dados com o <b>Entity Framework</b>.
O mapeamento das classes, na pasta Models, foi feito com a extensão <b>EF Core Power Tools</b>
que gerou o contexto. Na pasta Interfaces criei algumas interfaces para definir
os métodos dos repositórios encontrados na pasta Repositories. Para facilitar, usei o <b>Generics</b>
para criar os repositórios (utilização de classe genérica). <br>
No projeto <b>Cadastracar.WEB</b>, em ASP NET Core, no padrão MVC, faz referência ao projeto de acesso aos
dados. Na pasta Controllers, terão as classes com os métodos retornando as Views presentes na pasta Views.<br>
Práticas com <b>bootstrap</b> para estilização do layout foi aplicada. Para melhor visualização dos itens
da lista, implementei o <b>DataTables</b>, plugin de tabelas (listas) para <b>JQuery</b> com as funcionalidades de filtro
por pesquisa, quantidade de itens a serem exibidos e paginação.
</p>

## Descrição dos arquivos
<p align="justify">
:point_right: O Arquivo DER_CADASTRACAR.asta é o diagrama de entidade e relacionamento desenvolvido no Astah. <br>
:point_right: O Arquivo DER_CADASTRACAR.jpg é a imagem do diagrama de entidade e relacionamento desenvolvido no Astah. <br>
:point_right: O Arquivo cadastracar_scripts.sql contém os Scripts SQL Server para criação das tabelas, regras, views etc. <br>
:point_right: O Arquivo CADASTRACAR.bak é o backup do banco de dados do projeto <br>
</p>

## Capturas das telas do veículo
### Veículos
![alt text](https://github.com/mrtrycatch/CRUD_CADASTRACAR/blob/master/Arquivos/Screenshots/localhost_44331_Veiculo.png)
## Incluir Veículo
![alt text](https://github.com/mrtrycatch/CRUD_CADASTRACAR/blob/master/Arquivos/Screenshots/localhost_44331_Veiculo_Create.png)
Para conferir as demais capturas de tela <a target="_blank" href="https://github.com/mrtrycatch/CRUD_CADASTRACAR/tree/master/Arquivos/Screenshots">Clique aqui</a>.
