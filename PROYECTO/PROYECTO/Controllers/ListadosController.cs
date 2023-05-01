using Microsoft.AspNetCore.Mvc;
using PROYECTO.Models;
using PROYECTO.Servicios;

namespace PROYECTO.Controllers
{
    public class ListadosController : Controller
    {
        
        [Route("Listado1")]
        public IActionResult Listado1()
        {
            List<Paciente> listaordenada = new List<Paciente>();
            List<Paciente> listaPacientes = new List<Paciente>();
            listaordenada = AVL.InOrderAVL(AVL.raiz);
            DateTime date = DateTime.Now;
            DateTime Defecto = new DateTime(0001, 01, 01, 00, 00, 00);
            for (int i = 0; i < listaordenada.Count(); i++)
            {
                if (listaordenada[i].Tratamiento == "") {
                    if ((date - listaordenada[i].UltimaConsulta).Days >= 180){
                        if (listaordenada[i].ProxConsulta == Defecto)
                        {
                            listaPacientes.Add(listaordenada[i]);
                        }
                    }
                }
            } 
            return View(listaPacientes);
        }

       
        [Route("Listado2")]
        public IActionResult Listado2()
        {
            List<Paciente> listaordenada = new List<Paciente>();
            List<Paciente> listaPacientes = new List<Paciente>();
            listaordenada = AVL.InOrderAVL(AVL.raiz);
            DateTime date = DateTime.Now;
            DateTime Defecto = new DateTime(0001, 01, 01, 00, 00, 00);
            for (int i = 0; i < listaordenada.Count(); i++)
            {
                if (listaordenada[i].Tratamiento.Contains("cognitivo") || listaordenada[i].Tratamiento.Contains("conductual"))
                {
                    if ((date - listaordenada[i].UltimaConsulta).Days >= 31)
                    {
                        if (listaordenada[i].ProxConsulta == Defecto)
                        {
                            listaPacientes.Add(listaordenada[i]);
                        }
                    }
                }
            }
            return View(listaPacientes);
        }

        [HttpPost]
        [Route("Listado3")]
        public IActionResult Listado3()
        {
            List<Paciente> listaordenada = new List<Paciente>();
            listaordenada = AVL.InOrderAVL(AVL.raiz);
            return View(listaordenada);
        }

        [HttpPost]
        [Route("Listado4")]
        public IActionResult Listado4()
        {
            List<Paciente> listaordenada = new List<Paciente>();
            listaordenada = AVL.InOrderAVL(AVL.raiz);
            return View(listaordenada);
        }

		[Route("ListadoGesaltica")]
		public IActionResult ListadoGesaltica()
		{
			List<Paciente> listaordenada = new List<Paciente>();
			List<Paciente> listaPacientes = new List<Paciente>();
			listaordenada = AVL.InOrderAVL(AVL.raiz);
			DateTime date = DateTime.Now;
			DateTime Defecto = new DateTime(0001, 01, 01, 00, 00, 00);
			for (int i = 0; i < listaordenada.Count(); i++)
			{
				if (listaordenada[i].Tratamiento.Contains("gesáltica"))
				{
					if ((date - listaordenada[i].UltimaConsulta).Days >= 60)
					{
						if (listaordenada[i].ProxConsulta == Defecto)
						{
							listaPacientes.Add(listaordenada[i]);
						}
					}
				}
			}
			return View(listaPacientes);
		}

		[Route("ListadoOtros")]
		public IActionResult ListadoOtros()
		{
			List<Paciente> listaordenada = new List<Paciente>();
			List<Paciente> listaPacientes = new List<Paciente>();
			listaordenada = AVL.InOrderAVL(AVL.raiz);
			DateTime date = DateTime.Now;
			DateTime Defecto = new DateTime(0001, 01, 01, 00, 00, 00);
			for (int i = 0; i < listaordenada.Count(); i++)
			{
				if (!listaordenada[i].Tratamiento.Contains("gesáltica") || !listaordenada[i].Tratamiento.Contains("cognitivo") || !listaordenada[i].Tratamiento.Contains("conductual"))
				{
					if ((date - listaordenada[i].UltimaConsulta).Days >= 14)
					{
						if (listaordenada[i].ProxConsulta == Defecto)
						{
							listaPacientes.Add(listaordenada[i]);
						}
					}
				}
			}
			return View(listaPacientes);
		}

	}
}
