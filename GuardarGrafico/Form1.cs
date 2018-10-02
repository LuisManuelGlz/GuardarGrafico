using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuardarGrafico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // creo objeto Graphics que es el encargado de trazar las líneas
            Graphics g = CreateGraphics();

            // creo dos objetos lápices que recibe como parámetros el color y grosor del trazo
            Pen lapizNegro = new Pen(Color.Black, 2); // lapiz negro
            Pen lapizVerde = new Pen(Color.Green, 2); // lapiz verde

            // dibujamos la cruz
            g.DrawLine(lapizNegro, 250, 50, 250, 450);
            g.DrawLine(lapizNegro, 50, 250, 450, 250);

            // ciclo for que generará las líneas del gráfico
            // la viriable i representa la distancia que se le agragará a las líneas
            for (int i = 0; i < 195; i+=15)
            {
                if (i%2 == 0) // si la línea es par
                {
                    // dibuja líneas verdes
                    g.DrawLine(lapizVerde, 250, 50 + i, 250 + i, 250);
                    g.DrawLine(lapizVerde, 250, 50 + i, 250 - i, 250);
                    g.DrawLine(lapizVerde, 250, 450 - i, 250 - i, 250);
                    g.DrawLine(lapizVerde, 250, 450 - i, 250 + i, 250);
                }
                else // si la línea es impar
                {
                    // dibuja líneas negras
                    g.DrawLine(lapizNegro, 250, 50 + i, 250 + i, 250);
                    g.DrawLine(lapizNegro, 250, 50 + i, 250 - i, 250);
                    g.DrawLine(lapizNegro, 250, 450 - i, 250 - i, 250);
                    g.DrawLine(lapizNegro, 250, 450 - i, 250 + i, 250);
                } // fin del if
            } // fin del for
        } // fin del evento Paint

        private void button1_Click(object sender, EventArgs e)
        {
            // creo el objeto bitmap y almacena el tamaño de la captura (form)
            Bitmap bmpScreenshot = new Bitmap(Bounds.Width, Bounds.Height);

            // creo objeto Graphics de bitmap
            Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);

            // toma captura desde la esquina superior izquierda hasta la esquina inferior derecha
            gfxScreenshot.CopyFromScreen(Bounds.X, Bounds.Y, 0, 0, Bounds.Size, CopyPixelOperation.SourceCopy);

            // creo objeto SaveFileDialog que contendrá los datos de la imagen
            SaveFileDialog guardar = new SaveFileDialog();

            // título de la ventana
            guardar.Title = "Guardar como";

            // tipos de formatos disponibles para la imagen
            guardar.Filter = "JPeg Image|*.jpg|Png Image|*.png|Bitmap Image|*.bmp|Gif Image|*.gif";

            // si el usuario presiona el butón "OK"
            if (guardar.ShowDialog() == DialogResult.OK)
            {
                // guarda la captura en la ruta que indicó el usuario
                bmpScreenshot.Save(guardar.FileName);
            } // fin del if
        } // fin del evento Click
    } // fin del form
} // fin del namespace
