namespace Cadastro_de_notebooks_e_fabricantes.Models
{
	public class NotebooksViewModel : PadraoViewModel
	{
		public DateTime dataCompra {  get; set; }
		public int marcaProcessador { get; set; }
		public string nomeProcessador { get; set; }
		public int fabricanteId { get; set; }
		public string nomeFabricante { get; set; }
		public IFormFile foto { get; set; }
		public byte[] fotoBytes { get; set; }
		public decimal valocidadeProcessador { get; set; }
		public string observacoes { get; set; }
		public bool placaGrafica { get; set; }
		public string foto64
		{
			get
			{
				if (fotoBytes != null)
					return Convert.ToBase64String(fotoBytes);
				else
					return string.Empty;

			}
		}

		public byte[] ConvertImageToByte(IFormFile file)
		{
			if (file != null)
				using (var ms = new MemoryStream())
				{
					file.CopyTo(ms);
					return ms.ToArray();
				}
			else
				return null;
		}
	}
}
