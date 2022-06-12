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
    public partial class Registro : Form
    {
        DBAccess objDBAccess = new DBAccess();
        DataTable DTusuarios = new DataTable();
        public Registro()
        {
            InitializeComponent();
        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Form btnAtras = new Bienvenida();
            btnAtras.Show();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string Id  =   txtID.Text;
            string contraseña = txtContraseña.Text;

            if (Id.Equals(""))
            {
                MessageBox.Show("Por favor digite su Id");
            }
            else if (contraseña.Equals(""))
            {
                MessageBox.Show("Por favor digite su contraseña");
            }
            else
            {
                string query = "select EsAdmin from TUsuario where IdUsuario = '" + Id + "' and Contraseña = '" + contraseña + "'";

                objDBAccess.readDatathroughAdapter(query, DTusuarios);

                var isadmin = (bool)DTusuarios.Rows[0][0];

                if (isadmin == true)
                {
                    Administrador ventana = new Administrador();
                    ventana.Show();
                    this.Close();

                }
                else
                {
                    Tecnico ventana = new Tecnico();
                    ventana.Show();
                    this.Close();
                }

            }

        }
    }
} 