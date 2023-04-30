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
            
            List<Paciente> listaordenada = new List<Paciente>();
            Paciente Encontradop = BusquedaPac(Nombre);

            if (Encontradop != null)
            {
                listaordenada.Add(Encontradop);
                return View(listaordenada);
            }
           return View(listaordenada);
        }

        [Route("BuscarNombre")]
        public IActionResult BuscarNombre()
        {
            return View();
        }

        public static Paciente BusquedaPac(string nom)
        {
            List<Paciente> listaordenada = new List<Paciente>();
            
            listaordenada = AVL.InOrderAVL(AVL.raiz);

            for (int i = 0; i < listaordenada.Count; i++)
            {
                if (listaordenada[i].Nombre_Comp == nom)
                {
                    return listaordenada[i];
                }
            }
            return null;
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
            
            var BusquePac = BusquedaPac(Nombre);
            if (BusquePac != null)
            {
                int vecesFecha = AVL.ValidacionFechas(FechaNueva, AVL.raiz);
                string dpi = BusquePac.Num_DPI;
                var incognita = AVL.BusquedaDPI(dpi, AVL.raiz);

                if (vecesFecha < 12)
                {
                    incognita = AVL.BusquedaDPI(dpi, AVL.raiz);
                    incognita.InfoPaciente.ProxConsulta = FechaNueva;
                }
                else
                {
                    //Me gustaria anadidir como un message box
                }
                LISTADOPAC.Add(incognita.InfoPaciente);
                return View(LISTADOPAC);
            }
            else
            {
                return View();
            }
            
        }


        [Route("EditarFechaNombre")]
        public IActionResult EditarFechaNombre()
        {
            return View();
        }







    }
}
