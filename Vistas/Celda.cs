using ClasesBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Vistas
{
    class Celda
    {
        private int fila;
        private int columna;
        private Butaca butaca;
        private Button botonAsociado;

        public Celda()
        {
            butaca = new Butaca();
            botonAsociado = new Button();
        }

        public Butaca Butaca { get => butaca; set => butaca = value; }
        public Button BotonAsociado { get => botonAsociado; set => botonAsociado = value; }
        public int Fila { get => fila; set => fila = value; }
        public int Columna { get => columna; set => columna = value; }

        /// <summary>
        /// Inicializa la butaca con su boton correspondiente.
        /// </summary>
        /// <param name="butaca">Objeto butaca asociado</param>
        /// <param name="boton">Objeto boton asociado</param>
        public void IniciarButaca(Butaca butaca, Button boton)
        {
            this.butaca = butaca;
            this.botonAsociado = boton;
            botonAsociado.Content = butaca.But_Fila + butaca.But_Nro;

            if (butaca.But_Disponible)
            {
                LiberarButaca();
            }
            else
            {
                OcuparButaca();
            }
            
        }

        /// <summary>
        /// Inicializa la butaca con su boton correspondiente. Los parametros se asignan como propiedades
        /// </summary>
        public void IniciarButaca()
        {
            botonAsociado.Content = butaca.But_Fila + butaca.But_Nro;

            if (butaca.But_Disponible)
            {
                botonAsociado.Background = Brushes.Gray;
            }
            else
            {
                OcuparButaca();
            }

        }

        /// <summary>
        /// Valida la butaca y la pone en gris si esta libre o roja si esta ocupada.
        /// </summary>
        public void ValidarButaca()
        {
            if (butaca.But_Disponible)
            {
                botonAsociado.Background = Brushes.Gray;
            }
            else
            {
                OcuparButaca();
            }
        }

        /// <summary>
        /// Cambia el color del boton asociado a VERDE
        /// </summary>
        public void SeleccionarButaca()
        {
            botonAsociado.Background = Brushes.Green;
        }

        /// <summary>
        /// Cambia el color del boton asociado a ROJO
        /// </summary>
        public void OcuparButaca()
        {
            botonAsociado.Background = Brushes.Red;
        }

        /// <summary>
        /// Cambia el color del boton asociado a GRIS
        /// </summary>
        public void LiberarButaca()
        {
            botonAsociado.Background = Brushes.Gray;
        }
    }
}
