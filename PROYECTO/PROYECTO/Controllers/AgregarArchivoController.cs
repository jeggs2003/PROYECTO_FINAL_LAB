using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROYECTO.Models;
using PROYECTO.Servicios;

namespace PROYECTO.Controllers
{
    [Route("[controller]")]
    public class AgregarArchivoController : Controller

    {


        public static AVL arbolavl = new AVL();
        public static List<Paciente> LISTADOPAC = new List<Paciente>();

        public Paciente RegistrarPacienteArc(string Nombre, string DPI, int Edad, int Tel, DateTime Fu, DateTime Fp, string Tratamiento, string Modalidad)

        {
            Paciente pac = new Paciente();
            pac.Nombre_Comp = Nombre;
            pac.Num_DPI = DPI;
            pac.Edad = Edad;
            pac.Telefono = Tel;
            pac.UltimaConsulta = Fu;
            pac.ProxConsulta = Fp;
            pac.Tratamiento = Tratamiento;
            pac.modalidad = Modalidad;
            return pac;
        }



        [HttpPost("IngresoInformacion")]
        public IActionResult IngresoInformacion(IFormFile archivo)
        {
            if (archivo != null)
            {
                try
                {
                    //Crear una copia del archivo recibido
                    string ruta = Path.Combine(Path.GetTempPath(), archivo.Name);
                    using (var stream = new FileStream(ruta, FileMode.Create))
                    {
                        archivo.CopyTo(stream); //Copiar el contenido del archivo
                    }

                    //Leer el arhivo
                    string informacionArchivo = System.IO.File.ReadAllText(ruta);
                    //Obtener lineas del archivo y llenar lista
                    foreach (string linea in informacionArchivo.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(linea))
                        {
                            //Extraer la informacion de cada persona
                            string[] FilaActual = linea.Split(',');

                            LISTADOPAC.Add(RegistrarPacienteArc(FilaActual[0], FilaActual[1], Convert.ToInt32(FilaActual[2]), Convert.ToInt32(FilaActual[3]), Convert.ToDateTime(FilaActual[4]), Convert.ToDateTime(FilaActual[5]), FilaActual[6], FilaActual[7]));

                        }
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Error al leer el archivo" + e.Message;
                }
            }
            else
            {
                ViewBag.Error = "No se ha ingresado la ruta de archivo";
            }

            for (int i = 0; i < LISTADOPAC.Count(); i++)
            {
                arbolavl.InsertarDatosAVL(LISTADOPAC[i]);
            }

            List<Paciente> listaordenada = new List<Paciente>();
            listaordenada = arbolavl.InOrderAVL(arbolavl.raiz);
            return View("IngresoInformacion", listaordenada);

        }

        [Route("IngresoInformacion")]
        public IActionResult IngresoInformacion()
        {
            return View();


        }
    }
}
