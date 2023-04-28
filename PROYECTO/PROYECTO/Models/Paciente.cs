using System.Runtime.Intrinsics.Arm;

namespace PROYECTO.Models
{
    public class Paciente : IComparable<Paciente>
    {
        public string Nombre_Comp { get; set; }
        public string Num_DPI { get; set; }
        public int Edad { get; set; }
        public int Telefono { get; set; }
        public DateTime UltimaConsulta { get; set; }
        public DateTime ProxConsulta { get; set; }
        public string Tratamiento { get; set; }
        public string modalidad { get; set; }

        public int CompareTo(Paciente Paci)
        {
            // Se comparan mediantes DPI
            return Num_DPI.CompareTo(Paci.Num_DPI);
        }
    }
}
