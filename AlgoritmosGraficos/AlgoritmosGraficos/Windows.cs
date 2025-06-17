using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmosGraficos
{
    public partial class Windows : Form
    {
        private readonly List<Point> pixelList = new();
        private readonly Bitmap canvas;
        private Color colorActual = Color.BlueViolet;
        private enum ModoFigura { Ninguno, DDA, Poligono, Circunferencia, Bresenham }
        private ModoFigura figuraActual = ModoFigura.Ninguno;
        private Point? centroCircunferencia = null;


        // funcion para delimitar los puntos de inicio y fin para dda y bresenham
        private Point? puntoInicio = null;
        private Point? puntoFin = null;

        // funcion que ndica si se usará DDA o Bresenham en los clics
        private enum ModoLinea { Ninguno, DDA, Bresenham }
        private ModoLinea modoActual = ModoLinea.Ninguno;

        public Windows()
        {
            InitializeComponent();
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = canvas;
        }

        private async Task EncenderPixeles(List<Point> puntos)
        {
            pixelList.Clear();
            foreach (var punto in puntos)
            {
                if (punto.X >= 0 && punto.X < canvas.Width && punto.Y >= 0 && punto.Y < canvas.Height)
                {
                    canvas.SetPixel(punto.X, punto.Y, Color.Black);
                    pixelList.Add(punto);
                    pictureBox1.Refresh();
                    await Task.Delay(10);
                    canvas.SetPixel(punto.X, punto.Y, colorActual);
                }
            }
            MostrarPixeles();
        }

        private void MostrarPixeles()
        {
            listBox1.Items.Clear();
            foreach (var punto in pixelList)
                listBox1.Items.Add($"({punto.X},{punto.Y})");
        }

        private void BtnDDA_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Haz clic en el PictureBox para seleccionar dos puntos y dibujar la línea con DDA.");
            figuraActual = ModoFigura.DDA;
        }

        private void BtnBresenham_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Haz clic en el PictureBox para seleccionar dos puntos y dibujar la línea con Bresenham.");
            figuraActual = ModoFigura.Bresenham;
        }

        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point clic = new Point(me.X, me.Y);

            if (figuraActual == ModoFigura.Ninguno)
            {
                // Relleno libre 
                AlgoritmoRelleno.Inundacion(canvas, clic.X, clic.Y, Color.Red, colorActual);
                pictureBox1.Refresh();
                return;
            }

            if (figuraActual == ModoFigura.Circunferencia)
            {
                if (centroCircunferencia == null)
                {
                    centroCircunferencia = clic;
                    MessageBox.Show($"Centro seleccionado en: ({clic.X}, {clic.Y})");
                }
                else
                {
                    int dx = clic.X - centroCircunferencia.Value.X;
                    int dy = clic.Y - centroCircunferencia.Value.Y;
                    int radio = (int)Math.Sqrt(dx * dx + dy * dy);

                    var puntos = AlgoritmosCircunferencia.BresenhamCircle(
                        centroCircunferencia.Value.X, centroCircunferencia.Value.Y, radio);

                    await EncenderPixeles(puntos);

                    centroCircunferencia = null;
                    figuraActual = ModoFigura.Ninguno;
                }

                return;
            }

            if (puntoInicio == null)
            {
                puntoInicio = clic;
                MessageBox.Show($"Punto inicial seleccionado en: ({clic.X}, {clic.Y})");
            }
            else
            {
                puntoFin = clic;
                MessageBox.Show($"Punto final seleccionado en: ({clic.X}, {clic.Y})");

                List<Point> puntos = new();
                if (figuraActual == ModoFigura.DDA)
                {
                    puntos = AlgoritmosLinea.DDA(puntoInicio.Value.X, puntoInicio.Value.Y, puntoFin.Value.X, puntoFin.Value.Y);
                }
                else if (figuraActual == ModoFigura.Bresenham)
                {
                    puntos = AlgoritmosLinea.Bresenham(puntoInicio.Value.X, puntoInicio.Value.Y, puntoFin.Value.X, puntoFin.Value.Y);
                }

                await EncenderPixeles(puntos);

                puntoInicio = null;
                puntoFin = null;
                figuraActual = ModoFigura.Ninguno;
            }
        }


        private void BtnCircunferencia_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Haz clic en el PictureBox para seleccionar el centro y un punto sobre el radio.");
            figuraActual = ModoFigura.Circunferencia;
        }


        private async void BtnPoligono_Click(object sender, EventArgs e)
        {
            figuraActual = ModoFigura.Poligono;
            int lados = (int)nudLados.Value;
            int radio = 80;
            int centroX = pictureBox1.Width / 2;
            int centroY = pictureBox1.Height / 2;

            List<Point> vertices = new();
            for (int i = 0; i < lados; i++)
            {
                double angulo = 2 * Math.PI * i / lados;
                int x = centroX + (int)(radio * Math.Cos(angulo));
                int y = centroY + (int)(radio * Math.Sin(angulo));
                vertices.Add(new Point(x, y));
            }

            List<Point> puntos = new();
            for (int i = 0; i < lados; i++)
            {
                puntos.AddRange(AlgoritmosLinea.Bresenham(
                    vertices[i].X, vertices[i].Y,
                    vertices[(i + 1) % lados].X, vertices[(i + 1) % lados].Y
                ));
            }

            await EncenderPixeles(puntos);
        }

        private async void BtnRelleno_Click(object sender, EventArgs e)
        {
            Point puntoInicio;

            if (figuraActual == ModoFigura.Poligono || figuraActual == ModoFigura.Circunferencia)
            {
                // Selecciona el centro de la figura como punto de partida para la circunferencia
                puntoInicio = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);

                await Task.Run(() =>
                {
                    try
                    {
                        Color colorObjetivo = canvas.GetPixel(puntoInicio.X, puntoInicio.Y);
                        if (colorObjetivo.ToArgb() != colorActual.ToArgb())
                        {
                            AlgoritmoRelleno.Inundacion(canvas, puntoInicio.X, puntoInicio.Y, colorObjetivo, colorActual);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al rellenar: " + ex.Message);
                    }
                });

                pictureBox1.Refresh();
            }
            else
            {
                MessageBox.Show("Primero dibuja una figura (poligono o circunferencia).");
            }
        }


        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorActual = colorDialog1.Color;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(Color.White); // Limpia 
            }

            pictureBox1.Image = canvas;
            pixelList.Clear();
            listBox1.Items.Clear();
            puntoInicio = null;
            puntoFin = null;
            centroCircunferencia = null;
            figuraActual = ModoFigura.Ninguno;
            pictureBox1.Refresh(); // refresca el PictureBox
        }

        private void Instructions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selecciona un modo (DDA o Bresenham) y luego haz clic dos veces sobre el lienzo para dibujar la línea.\nTambién puedes usar el botón de polígono o relleno.");
        }
    }
}


