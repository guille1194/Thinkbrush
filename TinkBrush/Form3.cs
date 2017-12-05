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

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Form2 r = new Form2();
            r.Show();
            this.Hide();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-Q20NC8P\\SQLEXPRESS ; database=PaintDB ; integrated security = true");
            con.Open();
            string newcon = "select nombreusuario from login where correo='"+metroTextBox2.Text+"' and contrasena='"+metroTextBox3.Text+"'";
            SqlDataAdapter adp = new SqlDataAdapter(newcon, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt = ds.Tables[0];
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
