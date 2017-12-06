using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TinkBrush
{
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection();
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        //boton de registro
        private void metroButton1_Click(object sender, EventArgs e)
        {   //creacion de conexion sql
            SqlConnection con = new SqlConnection("server=DESKTOP-Q20NC8P\\SQLEXPRESS ; database=PaintDB ; integrated security = true");
            //abrir conexion
            con.Open();
            //creacion de consulta donde los valores se esperan con el input
            string nuevacon = "insert into login(correo, Nombre, nombreusuario, contrasena) Values " +
            "('" + metroTextBox4.Text + "','" + metroTextBox1.Text+ "','"+metroTextBox2.Text+"','"+metroTextBox3.Text+"')";
            //comando para ejecutar la consulta
            SqlCommand cmd = new SqlCommand(nuevacon, con);
            //ejecucion de la consulta sql
            cmd.ExecuteNonQuery();
            MessageBox.Show("Usuario Registrado");
        }

        //boton cambio de forma
        private void metroButton2_Click(object sender, EventArgs e)
        {   //creacion objeto forma
            Form3 fm = new Form3();
            //mostrar nueva forma
            fm.Show();
            //ocultar forma anterior
            this.Hide();
        }

        private void metroTextBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
