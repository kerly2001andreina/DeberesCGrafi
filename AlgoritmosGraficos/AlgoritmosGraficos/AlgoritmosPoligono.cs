using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AlgoritmosGraficos
{
    public static class AlgoritmosPoligono
    {
        public static List<Point> DibujarPoligono(int cx, int cy, int radio, int lados)
        {
            List<Point> puntos = new();
            double angulo = 2 * Math.PI / lados;
            Point[] vertices = new Point[lados];

            for (int i = 0; i < lados; i++)
            {
                int x = cx + (int)(radio * Math.Cos(i * angulo));
                int y = cy + (int)(radio * Math.Sin(i * angulo));
                vertices[i] = new Point(x, y);
            }

            for (int i = 0; i < lados; i++)
            {
                puntos.AddRange(AlgoritmosLinea.Bresenham(
                    vertices[i].X, vertices[i].Y,
                    vertices[(i + 1) % lados].X, vertices[(i + 1) % lados].Y));
            }

            return puntos;
        }
    }
}

