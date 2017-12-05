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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-Q20NC8P\\SQLEXPRESS ; database=PaintDB ; integrated security = true");
            con.Open();
            string nuevacon = "insert into login(correo, Nombre, nombreusuario, contrasena) Values " +
            "('" + metroTextBox4.Text + "','" + metroTextBox1.Text+ "','"+metroTextBox2.Text+"','"+metroTextBox3.Text+"')";
            SqlCommand cmd = new SqlCommand(nuevacon, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Usuario Registrado");
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Form3 fm = new Form3();
            fm.Show();
            this.Hide();
        }

        private void metroTextBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
