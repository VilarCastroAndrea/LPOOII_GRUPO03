using ClasesBase;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Vistas.UserControl.Proyeccion

{
    /// <summary>
    /// Lógica de interacción para WPFAltaProyeccion.xaml
    /// </summary>
    public partial class WPFMostrarProyeccion
    {
        ClasesBase.Proyeccion proyeccionMostrar;

        public WPFMostrarProyeccion(ClasesBase.Proyeccion verProyeccion)
        {
            proyeccionMostrar = verProyeccion;
            InitializeComponent();
            txtFecha.Text = proyeccionMostrar.Proy_Fecha;
            txtHora.Text = proyeccionMostrar.Proy_Hora;
            txtSala.Text = proyeccionMostrar.Sla_NroSala.ToString();
            txtTitulo.Text = proyeccionMostrar.Peli_Codigo.ToString();

        }

        
        


    }
}
