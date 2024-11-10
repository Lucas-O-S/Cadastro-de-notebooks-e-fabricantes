using Cadastro_de_notebooks_e_fabricantes.DAO;
using Cadastro_de_notebooks_e_fabricantes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace Cadastro_de_notebooks_e_fabricantes.Controllers
{
	public class NotebooksController : PadraoController<NotebooksViewModel>
	{
		public NotebooksController() { dao = new NotebooksDAO(); }

		private List<NotebooksDAO.marcas> GetMarcas()
		{
			return Enum.GetValues(typeof(NotebooksDAO.marcas)).Cast<NotebooksDAO.marcas>().ToList();
		}

		private List<FabricantesViewModel> GetFabricantes()
		{
			FabricantesDAO fDAO = new FabricantesDAO();
			List<FabricantesViewModel> fabricantes = fDAO.Listagem();
			return fabricantes;
		}

		public override IActionResult Create()
		{
			try
			{
				ViewBag.operacao = "I";
				NotebooksViewModel model = new NotebooksViewModel();
				ViewBag.marcas = GetMarcas();

				ViewBag.fabricantes = GetFabricantes();
				return View(NomeViewForm, model);
			}
			catch (Exception erro)
			{
				return View("Error", new ErrorViewModel(erro.ToString()));
			}
		}
		public override IActionResult Edit(int id)
		{
			try
			{
				ViewBag.operacao = "A";
				NotebooksViewModel model = dao.Consulta(id);
				ViewBag.marcas = GetMarcas();

				ViewBag.fabricantes = GetFabricantes();
				if (model == null)
					return RedirecionaParaIndex(model);
				else
					return View(NomeViewForm, model);
			}
			catch (Exception erro)
			{
				return View("Error", new ErrorViewModel(erro.ToString()));
			}


		}

        public override IActionResult Save(NotebooksViewModel model, string operacao)
        {
            try
            {
                ValidarDados(model, operacao);
                if (ModelState.IsValid == false)
                {
                    ViewBag.marcas = GetMarcas();
                    ViewBag.fabricantes = GetFabricantes();
                    ViewBag.operacao = operacao;
                    return View(NomeViewForm, model);
                }
                else
                {
                    if (operacao == "I")
                        dao.Insert(model);


                    else
                        dao.Update(model);
                    return RedirecionaParaIndex(model);
                }
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        protected override void ValidarDados(NotebooksViewModel model, string operacao)
		{

			base.ValidarDados(model, operacao);

			DateTime dataMinimaSql = new DateTime(1900, 1, 1);

			if (model.dataCompra < dataMinimaSql || model.dataCompra > DateTime.Today)
				ModelState.AddModelError("dataCompra", "Data inválida.");

			if(model.valocidadeProcessador == 0 || model.valocidadeProcessador == null)
				ModelState.AddModelError("valocidadeProcessador", "Valor inválida.");

			if (model.foto == null && operacao == "I")
					ModelState.AddModelError("foto", "Adicione uma imagem");

			if (model.foto != null && model.foto.Length / 1024 / 1024 >= 2)
				ModelState.AddModelError("foto", "Imagem limitada a 2 mb.");

			if (ModelState.IsValid)
			{
				if (operacao == "A" && model.foto == null)
				{
					NotebooksViewModel temp = dao.Consulta(model.id);
					model.fotoBytes = temp.fotoBytes;

				}
				else
				{
					model.fotoBytes = model.ConvertImageToByte(model.foto);

				}
			}
		}
	}
}

