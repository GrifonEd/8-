using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.IO;

namespace Laba8_oop
{
    public class CCircle : Shape
    {
        public CCircle()
        {
            id = ID;
            ++ID;
            code = 'C';
            path = new GraphicsPath();
        }

        public CCircle(int x, int y, RectangleF boarders)
        {
            id = ID;
            ++ID;
            code = 'C';
            minGenLength = 5;
            genLength = 35;
            this.x = x;
            this.y = y;
            this.boarders = boarders;
            path = new GraphicsPath();
            lastCommand = "Constructor";
            updateBoarders(boarders);
            relocate();
        }

        public override void fillPath()
        {
            path.Reset();
            path.AddEllipse(x - genLength, y - genLength, genLength * 2, genLength * 2);
        }

        ~CCircle()
        {
            --ID;
        }

    }
}
