using System.Data.SqlClient;

namespace Cadastro_de_notebooks_e_fabricantes.DAO
{
    public static class ConexaoBD
    {

        public static SqlConnection GetConexao()
        {
            string strCon = "Data Source=LOCALHOST\\sqlexpress; Database=AULADB; user id=sa; password=123456";
            SqlConnection conexao = new SqlConnection(strCon);
            conexao.Open();
            return conexao;
        }
    }
}
