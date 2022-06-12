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
    public partial class Administrador : Form
    {
        DBAccess objDBAccess = new DBAccess();
        DataTable DTcaso = new DataTable();
        DataTable DTestado = new DataTable();
        public Administrador()
        {
            InitializeComponent();
        }

        private void Administrador_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.TCaso' Puede moverla o quitarla según sea necesario.
            //this.tCasoTableAdapter.Fill(this.dataSet1.TCaso);
            // TODO: esta línea de código carga datos en la tabla 'casosDataSet.TCaso' Puede moverla o quitarla según sea necesario.

            string queryEstado = "select * from TEstado";

            objDBAccess.readDatathroughAdapter(queryEstado, DTestado);

            bxAdmin.DataSource = DTestado;
            bxAdmin.DisplayMember = "Nombre";
            bxAdmin.ValueMember = "IdEstado";
            objDBAccess.closeConn();

            int estado = (int)bxAdmin.SelectedValue;


            //string queryCasos = "select c.IdCaso, c.NombreUsuario, ca.nombre as Categoria, e.Nombre as Estado, c.Correo, c.Detalle, c.Fecha, c.Observaciones, u.Nombre + ' ' + u.Apellido as Tecnico from TCaso c inner join TCategoria ca  on c.IdCategoria = ca.IdCategoria inner join TEstado e   on c.IdEstado = e.IdEstado inner join TUsuario u   on c.IdUsuario = u.IdUsuario where c.idEstado = '" + estado + "'";
            string queryCasos = "select * from TCaso c where c.idEstado = '" + estado + "'";
            objDBAccess.readDatathroughAdapter(queryCasos, DTcaso);

            dataGridView1.DataSource = DTcaso;

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int estado = (int)bxAdmin.SelectedValue;

           
           // string queryCasos = "select * from TCaso where idEstado = '" + estado + "'";

           // objDBAccess.readDatathroughAdapter(queryCasos, DTcaso);

           //dataGridView1.DataSource = DTcaso;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Modificar m = new Modificar();
            m.lblCaso.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            m.lblUsuario.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            m.lblEstado.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            m.lblCategoria.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            m.txtCorreo.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            m.lblDetalle.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            m.lblFecha.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            m.lblTecnico.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            m.txtObservaciones.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
            m.ShowDialog();
        }
    }
}
