use AULADB

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

create or alter procedure sp_delete(
	@id int,
	@tabela varchar(max)
)
as
begin
	declare @sql varchar(max)
	set @sql = 'delete ' + @tabela + ' where id = ' + cast( @id as varchar(max))
	exec(@sql)
end
go

create or alter procedure sp_select(
	@id int,
	@tabela varchar(max)
)
as
begin
	declare @sql varchar(max)
	set @sql = 'select * from  ' + @tabela + ' where id = ' + cast( @id as varchar(max))
	exec(@sql)
end
go

create or alter procedure sp_list(
	@tabela varchar(max)
)
as
begin
	declare @sql varchar(max)
	set @sql = 'select * from  ' + @tabela
	exec(@sql)
end
go

create or alter procedure sp_insert_fabricantes(
	@descricao varchar(max)
)
as
begin
	insert into fabricantes (descricao) values (@descricao)
	
end
go

create or alter procedure sp_insert_fabricantes(
	@id int,
	@descricao varchar(max)
)
as
begin
	update fabricantes set descricao = @descricao where id = @id
	
end
go

create or alter procedure sp_insert_Notebooks(
	@dataCompra datetime,
	@marcaProcessador int,
	@fabricanteId int,
	@foto varbinary,
	@VelocidadeProcessador numeric,
	@PlacaGrafica bit,
	@Observacoes varchar(max)
)
as
begin
	insert into Notebooks
	(
		dataCompra,
		marcaProcessador,
		fabricanteId,
		foto,
		VelocidadeProcessador,
		placaGrafica,
		Observacoes

	)
	values(
		@dataCompra,
		@marcaProcessador,
		@fabricanteId,
		@foto,
		@VelocidadeProcessador,
		@PlacaGrafica,
		@Observacoes
	)
end
go

create or alter procedure sp_insert_Notebooks(
	@id int,
	@dataCompra datetime,
	@marcaProcessador int,
	@fabricanteId int,
	@foto varbinary,
	@VelocidadeProcessador numeric,
	@PlacaGrafica bit,
	@Observacoes varchar(max)
)
as
begin
	update Notebooks set
	dataCompra = @dataCompra,
	marcaProcessador = @marcaProcessador,
	fabricanteId = @fabricanteId,
	foto = @foto,
	VelocidadeProcessador = @VelocidadeProcessador,
	placaGrafica = @placaGrafica,
	Observacoes= @Observacoes
	where id = @id
end
go