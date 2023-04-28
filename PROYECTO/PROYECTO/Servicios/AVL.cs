using PROYECTO.Models;

namespace PROYECTO.Servicios
{
    public static class AVL
    {
      public static NodoArbolAVL raiz { get; set; }

        public static void InsertarDatosAVL(Paciente InfoPac)
        {
            raiz = Insertardpi(raiz, InfoPac);
        }

        public  static NodoArbolAVL Insertardpi(NodoArbolAVL nodo, Paciente InfoPac)
        {
            if (nodo == null)
            {
                return new NodoArbolAVL(InfoPac);
            }
            else if (string.Compare(InfoPac.Num_DPI, nodo.InfoPaciente.Num_DPI) < 0)
            {
                nodo.izquierda = Insertardpi(nodo.izquierda, InfoPac);
            }
            else if (string.Compare(InfoPac.Num_DPI, nodo.InfoPaciente.Num_DPI) > 0)
            {
                nodo.derecha = Insertardpi(nodo.derecha, InfoPac);
            }

            nodo.Altura = 1 + Math.Max(ObtenerAltura(nodo.izquierda), ObtenerAltura(nodo.derecha));

            int balance = BalanceoArbol(nodo);

            if (balance > 1 && string.Compare(InfoPac.Num_DPI, nodo.izquierda.InfoPaciente.Num_DPI) < 0)
            {
                return RotacionDerecha(nodo);
            }

            if (balance < -1 && string.Compare(InfoPac.Num_DPI, nodo.derecha.InfoPaciente.Num_DPI) > 0)
            {
                return RotacionIzquierda(nodo);
            }

            if (balance > 1 && string.Compare(InfoPac.Num_DPI, nodo.izquierda.InfoPaciente.Num_DPI) > 0)
            {
                nodo.izquierda = RotacionIzquierda(nodo.izquierda);
                return RotacionDerecha(nodo);
            }

            if (balance < -1 && string.Compare(InfoPac.Num_DPI, nodo.derecha.InfoPaciente.Num_DPI) < 0)
            {
                nodo.derecha = RotacionDerecha(nodo.derecha);
                return RotacionIzquierda(nodo);
            }

            return nodo;
        }


        private static int ObtenerAltura(NodoArbolAVL nodo)
        {
            if (nodo == null)
            {
                return 0;
            }
            return nodo.Altura;
        }
        private static int BalanceoArbol(NodoArbolAVL nodo)
        {
            if (nodo == null)
            {
                return 0;
            }
            return ObtenerAltura(nodo.izquierda) - ObtenerAltura(nodo.derecha);
        }

        public static List<Paciente> InOrderAVL(NodoArbolAVL nodoActual)
        {
            List<Paciente> nodosInOrder = new List<Paciente>();

            if (nodoActual != null)
            {
                nodosInOrder.AddRange(InOrderAVL(nodoActual.izquierda));
                nodosInOrder.Add(nodoActual.InfoPaciente);
                nodosInOrder.AddRange(InOrderAVL(nodoActual.derecha));
            }

            return nodosInOrder;
        }

        private static NodoArbolAVL RotacionDerecha(NodoArbolAVL y)
        {
            NodoArbolAVL x = y.izquierda;
            NodoArbolAVL T2 = x.derecha;

            x.derecha = y;
            y.izquierda = T2;

            y.Altura = 1 + Math.Max(ObtenerAltura(y.izquierda), ObtenerAltura(y.derecha));
            x.Altura = 1 + Math.Max(ObtenerAltura(x.izquierda), ObtenerAltura(x.derecha));

            return x;
        }
        private static NodoArbolAVL RotacionIzquierda(NodoArbolAVL x)
        {
            NodoArbolAVL y = x.derecha;
            NodoArbolAVL T2 = y.izquierda;

            y.izquierda = x;
            x.derecha = T2;

            x.Altura = 1 + Math.Max(ObtenerAltura(x.izquierda), ObtenerAltura(x.derecha));
            y.Altura = 1 + Math.Max(ObtenerAltura(y.izquierda), ObtenerAltura(y.derecha));

            return y;
        }

    }
}
