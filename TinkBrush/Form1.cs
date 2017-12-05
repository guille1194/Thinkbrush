using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TinkBrush
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        //generar variable de graficos
        Graphics g;

        //generar pluma con color negro por defecto
        Pen p = new Pen(Color.Black, 1);
        //punto de inicio del trazo
        Point sp = new Point(0, 0);
        //punto final del trazo
        Point ep = new Point(0, 0);
        //deteccion movimiento del mouse
        int k = 0;
        //variable figura
        int figura;
        private int cX, cY, x, y, dX, dY;
        //declarar variable color para modificar valores
        Color color;

        public Form1()
        {
            InitializeComponent();
            color = Color.Black;
        }

        //click para cambiar a color rojo
        private void Red_Click(object sender, EventArgs e)
        {
            color = Color.Red;
            Default1.BackColor = color;
        }
        //click para cambiar a color blanco
        private void blanco_Click(object sender, EventArgs e)
        {
            color = Color.White;
            Default1.BackColor = color;
        }
        //click para cambiar a color rosa
        private void Pink_Click(object sender, EventArgs e)
        {
            color = Color.Pink;
            Default1.BackColor = color;
        }
        //click para cambiar a color etc..
        private void Yellow_Click(object sender, EventArgs e)
        {
            color = Color.OrangeRed;
            Default1.BackColor = color;
        }

        private void OrangeRed_Click(object sender, EventArgs e)
        {
            color = Color.Yellow;
            Default1.BackColor = color;
        }

        private void Gold_Click(object sender, EventArgs e)
        {
            color = Color.Gold;
            Default1.BackColor = color;
        }

        private void LightSalmon_Click(object sender, EventArgs e)
        {
            color = Color.LightSalmon;
            Default1.BackColor = color;
        }

        private void Green_Click(object sender, EventArgs e)
        {
            color = Color.Green;
            Default1.BackColor = color;
        }

        private void YellowGreen_Click(object sender, EventArgs e)
        {
            color = Color.YellowGreen;
            Default1.BackColor = color;
        }

        private void SteelBlue_Click(object sender, EventArgs e)
        {
            color = Color.SteelBlue;
            Default1.BackColor = color;
        }

        private void Aqua_Click(object sender, EventArgs e)
        {
            color = Color.Aqua;
            Default1.BackColor = color;
        }

        private void MediumSlateBlue_Click(object sender, EventArgs e)
        {
            color = Color.MediumSlateBlue;
            Default1.BackColor = color;
        }

        private void RoyalBlue_Click(object sender, EventArgs e)
        {
            color = Color.RoyalBlue;
            Default1.BackColor = color;
        }

        private void Purple_Click(object sender, EventArgs e)
        {
            color = Color.Purple;
            Default1.BackColor = color;
        }

        private void Bisque_Click(object sender, EventArgs e)
        {
            color = Color.Bisque;
            Default1.BackColor = color;
        }

        private void negro_Click(object sender, EventArgs e)
        {
            color = Color.Black;
            Default1.BackColor = color;
        }

        private void DarkGray_Click(object sender, EventArgs e)
        {
            color = Color.DarkGray;
            Default1.BackColor = color;
        }

        private void Brown_Click(object sender, EventArgs e)
        {
            color = Color.Brown;
            Default1.BackColor = color;
        }

        private void Gray_Click(object sender, EventArgs e)
        {
            color = Color.Gray;
            Default1.BackColor = color;
        }

        private void Maroon_Click(object sender, EventArgs e)
        {
            color = Color.Maroon;
            Default1.BackColor = color;
        }

        //
        private void Pantalla_MouseDown(object sender, MouseEventArgs e)
        {
            sp = e.Location;
            //si se presiona clic izquierdo, se inicializa el trazo
            if (e.Button == MouseButtons.Left)
            {
                k = 1;
            }
            cX = e.X;
            cY = e.Y;
        }

        //definir movimientos con la pantalla
        private void Pantalla_MouseMove(object sender, MouseEventArgs e)
        {
            //si se inicializa el trazo se aplican condiciones de que figura se presiono, y se aplican sus parametros
            if (k == 1)
            {
                ep = e.Location;
                x = e.X;
                y = e.Y;

                if (figura == 1)
                {
                    g.DrawLine(new Pen(color), sp, ep);
                }
                else if (figura == 2)
                {
                    g.FillEllipse(new SolidBrush(color), e.X, e.Y, 60, 60);
                }
                else if (figura == 6)
                {
                    g.FillEllipse(new SolidBrush(color), e.X, e.Y, 60, 60);
                }
                else if (figura == 7)
                {
                    g.FillEllipse(new SolidBrush(color), e.X, e.Y, 5, 5);
                }
                else if (figura == 8)
                {
                    g.FillEllipse(new SolidBrush(color), e.X, e.Y, 15, 15);
                }
                else if (figura == 9)
                {
                    g.FillEllipse(new SolidBrush(color), e.X, e.Y, 25, 25);
                }
                else if (figura == 10)
                {
                    g.FillEllipse(new SolidBrush(color), e.X, e.Y, 35, 35);
                }
                else if (figura == 12)
                {
                    th = new Thread(thread);
                    th.Start();
                }
                sp = ep;
            }
        }

        private void thread()
        {
            int width = 1000, height = 1000;

            //bitmap
            Bitmap bmp = new Bitmap(width, height);

            //numero aleatorio
            Random rand = new Random();

            //crear pixeles aleatorios
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //generar valores aleatorios ARGB 
                    int a = rand.Next(256);
                    int r = rand.Next(256);
                    int g = rand.Next(256);
                    int b = rand.Next(256);

                    //establecer valores ARGB
                    bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }

            //cargar bmp en picturebox1
            Pantalla.Image = bmp;
        }

        private void Pantalla_MouseUp(object sender, MouseEventArgs e)
        {
            k = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //se crea la pantalla de graficos en la forma
            g = Pantalla.CreateGraphics();
            rdm = new Random();
        }

        private void Pantalla_Click(object sender, EventArgs e)
        {

        }

        //boton trazo lapiz
        private void button7_Click(object sender, EventArgs e)
        {   
            figura = 1;
        }

        //boton borrador
        private void button8_Click(object sender, EventArgs e)
        {
            figura = 2;
            color = Color.White;
        }

        //boton limpiar pantalla
        private void button5_Click(object sender, EventArgs e)
        {
            Pantalla.Refresh();
            Pantalla.Image = null;
        }

        //boton figura linea
        private void button1_Click(object sender, EventArgs e)
        {
            figura = 3;
        }

        //boton figura circulo
        private void button3_Click(object sender, EventArgs e)
        {
            figura = 4;
        }

        //boton figura cuadrado
        private void button2_Click(object sender, EventArgs e)
        {
            figura = 5;
        }

        private void Pantalla_MouseClick(object sender, MouseEventArgs e)
        {
            if (k == 1)
            {
                x = e.X;
                y = e.Y;
                dX = e.X - cX;
                dY = e.Y - cY;
                if (figura == 3)
                {
                    g.DrawLine(new Pen(color), cX, cY, e.X, e.Y);
                }
                if (figura == 4)
                {
                    g.DrawEllipse(new Pen(color), cX, cY, dX, dY);
                }
                if (figura == 5)
                {
                    g.DrawRectangle(new Pen(color), cX, cY, dX, dY);
                }
            }
        }

        //boton pincel
        private void button4_Click(object sender, EventArgs e)
        {
            figura = 6;
        }
        //menu guardar
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Png files|*.png|jpeg files|*jpg|bitmaps|*.bmp";
            if (o.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Pantalla.Image = (Image)Image.FromFile(o.FileName).Clone();
            }
        }
        //menu guardar
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(Pantalla.Width, Pantalla.Height);
            Graphics g = Graphics.FromImage(bmp);
            Rectangle rect = Pantalla.RectangleToScreen(Pantalla.ClientRectangle);
            g.CopyFromScreen(rect.Location, Point.Empty, Pantalla.Size);
            g.Dispose();
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Png files|*.png|jpeg files|*jpg|bitmaps|*.bmp";
            if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(s.FileName))
                {
                    File.Delete(s.FileName);
                }
                if (s.FileName.Contains(".jpg"))
                {
                    bmp.Save(s.FileName, ImageFormat.Jpeg);
                }
                else if (s.FileName.Contains(".png"))
                {
                    bmp.Save(s.FileName, ImageFormat.Png);
                }
                else if (s.FileName.Contains(".bmp"))
                {
                    bmp.Save(s.FileName, ImageFormat.Bmp);
                }
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pantalla.Refresh();
            Pantalla.Image = null;
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tinkbrush Team \nTopicos Avanzados de Programacion ", "Info", MessageBoxButtons.OK);
        }

        //mensaje forma cerrada
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Thinkbrush", "Thinkbrush", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        //cerrar la forma
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Esta seguro de que desea salir?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                e.Cancel = false;
            else e.Cancel = true;
        }

        //boton grosor 2
        private void button9_Click(object sender, EventArgs e)
        {
            figura = 8;
        }
        //boton grosor 3
        private void button10_Click(object sender, EventArgs e)
        {
            figura = 9;
        }
        //boton grosor 4
        private void button11_Click(object sender, EventArgs e)
        {
            figura = 10;
        }

        //boton grosor
        private void button6_Click(object sender, EventArgs e)
        {
            figura = 7;
        }

        Thread th;
        Random rdm;

        //boton generar random
        private void button12_Click(object sender, EventArgs e)
        {
            figura = 12;
        }
    }
}
