using Cadastro_de_notebooks_e_fabricantes.Models;
using System.Data;
using System.Data.SqlClient;

namespace Cadastro_de_notebooks_e_fabricantes.DAO
{
	public class NotebooksDAO : PadraoDAO<NotebooksViewModel>
	{
		public enum marcas { AMD, Intel }

		protected override void SetTabela()
		{
			tabela = "notebooks";
		}

		protected override SqlParameter[] CriarParametros(NotebooksViewModel model)
		{
			object imgByte = model.fotoBytes;
			if (imgByte == null) imgByte = DBNull.Value;

			SqlParameter[] sp;
			if (model.id == null || model.id == 0)
			{
				sp = new SqlParameter[]
				{
					new SqlParameter("dataCompra",model.dataCompra),
					new SqlParameter("marcaProcessador",model.marcaProcessador),
					new SqlParameter("fabricanteId",model.fabricanteId),
					new SqlParameter("foto",imgByte),
					new SqlParameter("VelocidadeProcessador", model.valocidadeProcessador),
					new SqlParameter("placaGrafica",model.placaGrafica),
					new SqlParameter("observacoes",model.observacoes ?? (object)DBNull.Value)


				};
			}
			else
			{
				sp = new SqlParameter[]
				{
					new SqlParameter("id",model.id),
					new SqlParameter("dataCompra",model.dataCompra),
					new SqlParameter("marcaProcessador",model.marcaProcessador),
					new SqlParameter("fabricanteId",model.fabricanteId),
					new SqlParameter("foto",imgByte),
					new SqlParameter("VelocidadeProcessador",model.valocidadeProcessador),
					new SqlParameter("placaGrafica",model.placaGrafica),
					new SqlParameter("observacoes",model.observacoes ?? (object)DBNull.Value)


				};
			}
			return sp;

		}

		protected override NotebooksViewModel MontarModel(DataRow registro)
		{
			NotebooksViewModel model = new NotebooksViewModel();

			model.id = Convert.ToInt32(registro["id"]);
			model.dataCompra = Convert.ToDateTime(registro["dataCompra"]);
			model.marcaProcessador = Convert.ToInt32(registro["marcaProcessador"]);
			model.fabricanteId = Convert.ToInt32(registro["fabricanteId"]);
			model.fotoBytes = registro["foto"] as byte[];
			model.valocidadeProcessador = Convert.ToDecimal(registro["VelocidadeProcessador"]);
			model.placaGrafica = Convert.ToBoolean(registro["marcaProcessador"]);
			model.observacoes = Convert.ToString(registro["observacoes"]);

			FabricantesDAO fDao = new FabricantesDAO();
			model.nomeFabricante = fDao.Consulta(model.fabricanteId).descricao;

			model.nomeProcessador = Enum.GetName(typeof(marcas), model.marcaProcessador);


			return model;
		}
	}
}
