using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using PROYECTO.Models;
using PROYECTO.Servicios;
    
namespace PROYECTO.Controllers
{
    public class BusquedaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        



        [HttpPost]
        [Route("BuscarDPI")]
        public IActionResult BuscarDPI(string DPI)
        {
            List<Paciente> LISTADOPAC = new List<Paciente>();
            if (DPI == null)
            {
                DPI = "no";
            }
            var incognita = AVL.BusquedaDPI(DPI, AVL.raiz);
            if (incognita == null || DPI == "no")
            {
                return View();
            }
            LISTADOPAC.Add(incognita.InfoPaciente);
            return View(LISTADOPAC);
        }


        [Route("BuscarDPI")]
        public IActionResult BuscarDPI()
        {
            return View();
        }

        [HttpPost]
        [Route("EditarFecha")]
        public IActionResult EditarFecha(string DPI, string Nombre, DateTime FechaNueva, DateTime FechaNueva1)
        {
            DateTime FOficial;

            if (FechaNueva == null)
            {
                FOficial = FechaNueva1;
            }
            else
            {
                FOficial = FechaNueva;
            }

            List<Paciente> LISTADOPAC = new List<Paciente>();
            var incognita = AVL.BusquedaDPI(DPI, AVL.raiz);

            if (DPI == "")
            {
                //Falta Crear Metodo Busqueda Nombre
                incognita = AVL.BusquedaDPI(Nombre, AVL.raiz);
                incognita.InfoPaciente.ProxConsulta = FOficial;
            }
            else
            {
                incognita = AVL.BusquedaDPI(DPI, AVL.raiz);
                incognita.InfoPaciente.ProxConsulta = FOficial;
            }

            LISTADOPAC.Add(incognita.InfoPaciente);
            return View(LISTADOPAC);
        }


        [Route("EditarFecha")]
        public IActionResult EditarFecha()
        {
            return View();
        }
    }
}
