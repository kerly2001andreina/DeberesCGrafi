using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AlgoritmosGraficos
{
    public static class AlgoritmosCircunferencia
    {
        public static List<Point> BresenhamCircle(int xc, int yc, int r)
        {
            List<Point> puntos = new();
            int x = 0, y = r;
            int d = 3 - 2 * r;

            void CirclePoints(int cx, int cy, int dx, int dy)
            {
                puntos.AddRange(new[] {
                    new Point(cx + dx, cy + dy), new Point(cx - dx, cy + dy),
                    new Point(cx + dx, cy - dy), new Point(cx - dx, cy - dy),
                    new Point(cx + dy, cy + dx), new Point(cx - dy, cy + dx),
                    new Point(cx + dy, cy - dx), new Point(cx - dy, cy - dx)
                });
            }

            while (y >= x)
            {
                CirclePoints(xc, yc, x, y);
                x++;
                if (d < 0) d += 4 * x + 6;
                else { d += 4 * (x - y) + 10; y--; }
            }

            return puntos;
        }
    }
}

