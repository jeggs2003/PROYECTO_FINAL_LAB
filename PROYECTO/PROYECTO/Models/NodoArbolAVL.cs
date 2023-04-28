namespace PROYECTO.Models
{
    public class NodoArbolAVL
    {
        public Paciente InfoPaciente { get; set; }
        public NodoArbolAVL izquierda { get; set; }
        public NodoArbolAVL derecha { get; set; }
        public int Altura { get; set; }

        public NodoArbolAVL(Paciente Data)
        {
            this.InfoPaciente = Data;
            this.Altura = 0;
        }
    }
}
