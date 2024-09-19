using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    public class Corcle
    {
        public Rectangle Rect;
        public Color color;

        public Corcle(Rectangle rect, Color color)
        {
            Rect = rect;
            this.color = color;
        }

        public void Draw(Graphics gfx)
        {
            gfx.FillEllipse(new SolidBrush(color), Rect);
        }
    }
}
