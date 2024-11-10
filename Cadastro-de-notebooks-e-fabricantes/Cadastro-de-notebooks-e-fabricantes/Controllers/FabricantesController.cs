using Cadastro_de_notebooks_e_fabricantes.DAO;
using Cadastro_de_notebooks_e_fabricantes.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro_de_notebooks_e_fabricantes.Controllers
{
    public class FabricantesController : PadraoController<FabricantesViewModel>
    {
        public FabricantesController() { dao = new FabricantesDAO(); }
    }
}
