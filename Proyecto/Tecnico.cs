using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Tecnico : Form
    {
        public Tecnico()
        {
            InitializeComponent();
        }

        private void Tecnico_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet11.TEstado' Puede moverla o quitarla según sea necesario.
            this.tEstadoTableAdapter.Fill(this.dataSet11.TEstado);
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.TCaso' Puede moverla o quitarla según sea necesario.
            this.tCasoTableAdapter.Fill(this.dataSet1.TCaso);

        }
    }
}
