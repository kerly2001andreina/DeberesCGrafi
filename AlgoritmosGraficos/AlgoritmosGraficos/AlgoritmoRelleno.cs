using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AlgoritmosGraficos
{
    public static class AlgoritmoRelleno
    {
        public static void Inundacion(Bitmap bmp, int x, int y, Color objetivo, Color reemplazo)
        {
            if (objetivo.ToArgb() == reemplazo.ToArgb())
                return;

            Stack<Point> pila = new Stack<Point>();
            pila.Push(new Point(x, y));

            while (pila.Count > 0)
            {
                Point p = pila.Pop();
                if (p.X < 0 || p.X >= bmp.Width || p.Y < 0 || p.Y >= bmp.Height)
                    continue;

                if (bmp.GetPixel(p.X, p.Y).ToArgb() == objetivo.ToArgb())
                {
                    bmp.SetPixel(p.X, p.Y, reemplazo);
                    pila.Push(new Point(p.X + 1, p.Y));
                    pila.Push(new Point(p.X - 1, p.Y));
                    pila.Push(new Point(p.X, p.Y + 1));
                    pila.Push(new Point(p.X, p.Y - 1));
                }
            }
        }
    }
}

