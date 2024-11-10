Desenvolva um cadastro de fabricantes de notebooks

````SQL
CREATE TABLE [dbo].[fabricantes](

   [id] [int] IDENTITY(1,1) NOT NULL Primary key,

    [descricao] [varchar](50) NULL)


GO

Create table Notebooks
(
id int primary key IDENTITY (1,1),
dataCompra datetime not null,
marcaProcessador int not null,
fabricanteId int not null,
foto varbinary(max) not null,
VelocidadeProcessador numeric(18,2) not null,
placaGrafica bit not null,
Observacoes varchar(max) null
)
GO

````

O cadastro de fabricantes é o mesmo que usamos no cadastro de ferramentas.

O cadastro de notebooks possui os seguintes detalhes e validações:

* id - autonumeração, não é editável.

* dataCompra data obrigatória

* marcaProcessador (valores possível:  1 = AMD / 2 = Intel)
* fabricanteId - deve-se informar o código de um fabricante válido. Utilizar caixa combo.
* foto - campo obrigatório.
* VelocidadeProcessador - campo obrigatório e pode ser um número fracionado. EX: 3,16
* placaGrafica - campo booleano, obrigatório.
* Observacoes - campo opcional. Utilizar o campo <textArea> do html

Utilizar herança. 

Colocar as opões no meu para acessar ambos os cadastros.

Adicione o Script do banco de dados juntamente com o seu projeto.

Utilize herança 

