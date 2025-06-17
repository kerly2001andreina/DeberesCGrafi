using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AlgoritmosGraficos
{
    public static class AlgoritmosLinea
    {
        public static List<Point> DDA(int x1, int y1, int x2, int y2)
        {
            List<Point> puntos = new();
            int dx = x2 - x1, dy = y2 - y1;
            int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));
            float xInc = dx / (float)steps;
            float yInc = dy / (float)steps;
            float x = x1, y = y1;

            for (int i = 0; i <= steps; i++)
            {
                puntos.Add(new Point((int)Math.Round(x), (int)Math.Round(y)));
                x += xInc; y += yInc;
            }

            return puntos;
        }

        public static List<Point> Bresenham(int x1, int y1, int x2, int y2)
        {
            List<Point> puntos = new();
            int dx = Math.Abs(x2 - x1), dy = Math.Abs(y2 - y1);
            int sx = x1 < x2 ? 1 : -1;
            int sy = y1 < y2 ? 1 : -1;
            int err = dx - dy;

            while (true)
            {
                puntos.Add(new Point(x1, y1));
                if (x1 == x2 && y1 == y2) break;
                int e2 = 2 * err;
                if (e2 > -dy) { err -= dy; x1 += sx; }
                if (e2 < dx) { err += dx; y1 += sy; }
            }

            return puntos;
        }
    }
}

