using Cadastro_de_notebooks_e_fabricantes.Models;
using System.Data;
using System.Data.SqlClient;

namespace Cadastro_de_notebooks_e_fabricantes.DAO
{
    public class FabricantesDAO : PadraoDAO<FabricantesViewModel>
    {
		public enum Marcas { AMD, Intel }

		protected override void SetTabela()
        {
            tabela = "fabricantes";
        }
        protected override SqlParameter[] CriarParametros(FabricantesViewModel model)
        {
            SqlParameter[] sp;

            if (model.id == null || model.id == 0) {
                sp = new SqlParameter[]
                {
                    new SqlParameter("descricao",model.descricao)   
                };

            }
            else
            {
                sp = new SqlParameter[]
                {   
                    new SqlParameter("id",model.id),
                    new SqlParameter("descricao",model.descricao)
                };
            }
            return sp;

        }

        protected override FabricantesViewModel MontarModel(DataRow registro)
        {
            FabricantesViewModel model = new FabricantesViewModel();

            model.id = Convert.ToInt32(registro["id"]);
            model.descricao = Convert.ToString(registro["descricao"]);

            return model;
        }
    }
}
