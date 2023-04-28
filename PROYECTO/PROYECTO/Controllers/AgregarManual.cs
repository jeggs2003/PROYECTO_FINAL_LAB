using Microsoft.AspNetCore.Mvc;
using PROYECTO.Models;
using PROYECTO.Servicios;

namespace PROYECTO.Controllers
{
    [Route("api/[controller]")]

    public class AgregarManual : Controller
    {
        [Route("Registro")]
        public IActionResult Manual(Paciente paci)
        {
            if (!ModelState.IsValid)
            {
                return View(paci);
            }
            ViewBag.mensaje = "Datos validos";
            AVL.InsertarDatosAVL(paci);
            return View(paci);
        }
    }
}
