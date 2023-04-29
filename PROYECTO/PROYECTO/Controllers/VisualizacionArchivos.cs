
using Microsoft.AspNetCore.Mvc;
using PROYECTO.Models;
using PROYECTO.Servicios;

namespace PROYECTO.Controllers
{
    public class VisualizacionArchivos : Controller
    {
        public IActionResult ImprimirInformacion()
        {
            List<Paciente> listaordenada = new List<Paciente>();
            listaordenada = AVL.InOrderAVL(AVL.raiz);
            return View("ImprimirInformacion", listaordenada);
        }
    }
}
