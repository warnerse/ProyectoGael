using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Modificar : Form
    {
        DBAccess objDBAccess = new DBAccess();
        DataTable DTCategoria = new DataTable();
        DataTable DTEstado = new DataTable();
        DataTable DTUsuario = new DataTable();
        public Modificar()
        {
            InitializeComponent();
        }

        private void Modificar_Load(object sender, EventArgs e)
        {
            string qCategoria = "select * from TCategoria";
            string qEstado = "select * from TEstado";
            string qTecnico = "select IdUsuario, Nombre + ' ' + Apellido as Tecnico from TUsuario";

            objDBAccess.readDatathroughAdapter(qCategoria, DTCategoria);
            objDBAccess.readDatathroughAdapter(qEstado, DTEstado);
            objDBAccess.readDatathroughAdapter(qTecnico, DTUsuario);

            cboCategoria.DataSource = DTCategoria;
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "IdCategoria";

            cboEstado.DataSource = DTEstado;
            cboEstado.DisplayMember = "Nombre";
            cboEstado.ValueMember = "IdEstado";

            cboTecnico.DataSource = DTUsuario;
            cboTecnico.DisplayMember = "Tecnico";
            cboTecnico.ValueMember = "IdUsuario";

            objDBAccess.closeConn();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int categoria = (int)cboCategoria.SelectedValue;
            int estado = (int)cboEstado.SelectedValue;
            int tecnico = (int)cboTecnico.SelectedValue;
            int caso = Int32.Parse(lblCaso.Text);



            SqlCommand updateCaso = new SqlCommand("UPDATE TCaso SET IdCategoria = @categoria, IdEstado = @estado, IdUsuario = @tecnico where IdCaso = @caso");

            updateCaso.Parameters.AddWithValue("@categoria", categoria);
            updateCaso.Parameters.AddWithValue("@estado", estado);
            updateCaso.Parameters.AddWithValue("@tecnico", tecnico);
            updateCaso.Parameters.AddWithValue("@caso", caso);

            objDBAccess.executeQuery(updateCaso);
            MessageBox.Show("Caso Actualizado");





        }
    }
}
