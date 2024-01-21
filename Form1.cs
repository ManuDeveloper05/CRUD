using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tBPersonaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tBPersonaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cRUDDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'cRUDDataSet.TBPersona' Puede moverla o quitarla según sea necesario.
            this.tBPersonaTableAdapter.Fill(this.cRUDDataSet.TBPersona);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-MANUELC\\SQLEXPRESS02; Database=cRUD; Integrated Security=True");
            // conexion a la base de datos


            //Boton Guardar
            string consulta = "insert into TBPersona values('" + idTextBox.Text + "','" + nombreTextBox.Text + "', '" + apellidoTextBox.Text + "', '" + edadTextBox.Text + "','" + telefonoTextBox.Text + "')";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            conexion.Open();
            comando.ExecuteNonQuery();

            MessageBox.Show("Registro agregado");
            //refrescar el Datagridview

            this.tBPersonaTableAdapter.Fill(this.cRUDDataSet.TBPersona);
            tBPersonaDataGridView.Refresh();
            conexion.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Boton Eliminar
            SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-MANUELC\\SQLEXPRESS02; Database=cRUD; Integrated Security=True");
            // conexion a la base de datos

            string consulta = "delete from TBPersona where id='" + idTextBox.Text + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            conexion.Open();
            comando.ExecuteNonQuery();

            MessageBox.Show("Registro Eliminado");
            //refrescar el Datagridview

            this.tBPersonaTableAdapter.Fill(this.cRUDDataSet.TBPersona);
            tBPersonaDataGridView.Refresh();

            conexion.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // conexion a la base de datos
            SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-MANUELC\\SQLEXPRESS02; Database=cRUD; Integrated Security=True");
          
            // Boton modificar
            string consulta = "update TBPersona set nombre='" + nombreTextBox.Text + "', apellido= '" + apellidoTextBox.Text + "', edad= '" + edadTextBox.Text + "', telefono='" + telefonoTextBox.Text + "' where id='" + idTextBox.Text + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            conexion.Open();
            comando.ExecuteNonQuery();

            MessageBox.Show("Registro Modificado");
            //refrescar el Datagridview

            this.tBPersonaTableAdapter.Fill(this.cRUDDataSet.TBPersona);
            tBPersonaDataGridView.Refresh();

            conexion.Close();
        }
    }
}
