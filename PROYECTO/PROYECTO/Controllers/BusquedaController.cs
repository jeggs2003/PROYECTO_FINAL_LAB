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

        //Busqueda Mediante DPI

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



        //Codigo Busqueda por Nombres
        //Falta Arreglar Recorrido de Arbol
        [HttpPost]
        [Route("BuscarNombre")]
        public IActionResult BuscarNombre(string Nombre)
        {
            List<Paciente> LISTADOPAC = new List<Paciente>();
            if (Nombre == null)
            {
                Nombre = "no";
            }
            var incognita = AVL.BusquedaNombre(Nombre, AVL.raiz);
            if (incognita == null || Nombre == "no")
            {
                return View();
            }
            LISTADOPAC.Add(incognita.InfoPaciente);
            return View(LISTADOPAC);
        }

        [Route("BuscarNombre")]
        public IActionResult BuscarNombre()
        {
            return View();
        }




        //Edicion de Fechar mediante DPI

        [HttpPost]
        [Route("EditarFecha")]
        public IActionResult EditarFecha(string DPI,DateTime FechaNueva)
        {

            List<Paciente> LISTADOPAC = new List<Paciente>();
            var incognita = AVL.BusquedaDPI(DPI, AVL.raiz);
            int vecesFecha = AVL.ValidacionFechas(FechaNueva, AVL.raiz);

            if (vecesFecha < 12)
            {
                   incognita = AVL.BusquedaDPI(DPI, AVL.raiz);
                   incognita.InfoPaciente.ProxConsulta = FechaNueva;
            }
            else
            {
                //Me gustaria anadidir como un message box
            }
            LISTADOPAC.Add(incognita.InfoPaciente);
            return View(LISTADOPAC);
        }

        [Route("EditarFecha")]
        public IActionResult EditarFecha()
        {
            return View();
        }


        //Edicion de Fechar mediante Nombre

        [HttpPost]
        [Route("EditarFechaNombre")]
        public IActionResult EditarFechaNombre(string Nombre, DateTime FechaNueva)
        {

            List<Paciente> LISTADOPAC = new List<Paciente>();
            //Tiene que comenzar en otra cosa VAR
            var incognita = AVL.BusquedaNombre(Nombre, AVL.raiz);
            int vecesFecha = AVL.ValidacionFechas(FechaNueva, AVL.raiz);

            if (vecesFecha < 12)
            {
                incognita = AVL.BusquedaNombre(Nombre, AVL.raiz);
                incognita.InfoPaciente.ProxConsulta = FechaNueva;
            }
            else
            {
                //Me gustaria anadidir como un message box
            }
            LISTADOPAC.Add(incognita.InfoPaciente);
            return View(LISTADOPAC);
        }


        [Route("EditarFechaNombre")]
        public IActionResult EditarFechaNombre()
        {
            return View();
        }







    }
}
