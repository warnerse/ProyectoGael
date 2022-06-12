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
    public partial class CrearCaso : Form
    {
        DBAccess objDBAccess = new DBAccess();
        DataTable DTCategoria = new DataTable();    
        public CrearCaso()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CrearCaso_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.TCategoria' Puede moverla o quitarla según sea necesario.
            //this.tCategoriaTableAdapter.Fill(this.dataSet1.TCategoria);
            string query = "select * from TCategoria";

            objDBAccess.readDatathroughAdapter(query, DTCategoria);

            cboCategoria.DataSource = DTCategoria;
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "IdCategoria";
            objDBAccess.closeConn();

        }

        private void btnAtrasCrear_Click(object sender, EventArgs e)
        {
             Form btnAtrasCrear = new Bienvenida();
            btnAtrasCrear.Show();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            //tCasoTableAdapter1.InsertQuery(txtNombre.Text, (int)cboCategoria.SelectedValue, txtCorreo.Text, txtDetalle.Text);
            string nombre = txtNombre.Text;
            string correo = txtCorreo.Text;
            string detalle = txtDetalle.Text;
            int categoria = (int)cboCategoria.SelectedValue;
            int estado = 1;
            int usuario = 2;
            DateTime fecha = DateTime.Now;
            string Observaciones = "Oruebas";

            if (nombre.Equals(""))
            {
                MessageBox.Show("Por favor digite su nombre");
            }
            else if (correo.Equals(""))
            {
                MessageBox.Show("Por favor digite un correo");
            }
            else if (detalle.Equals(""))
            {
                MessageBox.Show("Por favor digite el detalle");
            }
            else
            {
                SqlCommand insertCaso = new SqlCommand("insert into TCaso(NombreUsuario,IdCategoria,IdEstado,Correo,Detalle,Fecha,IdUsuario,Observaciones) values(@nombre, @categoria, @estado, @correo, @detalle, @fecha, @usuario, @Observaciones)");

                insertCaso.Parameters.AddWithValue("@nombre", nombre);
                insertCaso.Parameters.AddWithValue("@categoria", categoria);
                insertCaso.Parameters.AddWithValue("@estado", estado);
                insertCaso.Parameters.AddWithValue("@correo", correo);
                insertCaso.Parameters.AddWithValue("@detalle", detalle);
                insertCaso.Parameters.AddWithValue("@fecha", fecha);
                insertCaso.Parameters.AddWithValue("@usuario", usuario);
                insertCaso.Parameters.AddWithValue("@Observaciones", Observaciones);


                objDBAccess.executeQuery(insertCaso);
                MessageBox.Show("Caso Creado");

            }
           
        }
    }
}
