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
    public partial class Form3 : MetroFramework.Forms.MetroForm
    {
        public static string settexto = "";

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }

        //boton cambio de forma
        private void metroButton2_Click(object sender, EventArgs e)
        {    //creacion objeto forma
            Form2 r = new Form2();
            //mostrar nueva forma
            r.Show();
            //ocultar forma anterior
            this.Hide();
        }

        //boton inicio sesion
        private void metroButton1_Click(object sender, EventArgs e)
        {   //creacion de conexion sql
            SqlConnection con = new SqlConnection("server=DESKTOP-Q20NC8P\\SQLEXPRESS ; database=PaintDB ; integrated security = true");
            //abrir conexion
            con.Open();
            //creacion de consulta donde los valores se esperan con el input
            string newcon = "select nombreusuario from login where correo='"+metroTextBox2.Text+"' and contrasena='"+metroTextBox3.Text+"'";
            //son los datos establecidos para realizar una conexion
            SqlDataAdapter adp = new SqlDataAdapter(newcon, con);
            //a traves de dataset se almacenan los datos ingresados
            DataSet ds = new DataSet();
            //se actualizan los campos para iniciar sesion
            adp.Fill(ds);
            //se establece un arreglo de datos para ver si son correctos
            DataTable dt = ds.Tables[0];
            //en caso de que los dos datos coincidan, se cambia la forma
            if (dt.Rows.Count >= 1)
            {
                settexto = metroTextBox2.Text;
                Form1 fm1 = new Form1();
                fm1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Datos incorrectos");
            }
        }
    }
}
