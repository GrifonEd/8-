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
    public class CRectangle : Shape
    {

        public CRectangle()
        {
            id = ID;
            ++ID;
            code = 'R';
            path = new GraphicsPath();
        }

        public CRectangle(int x, int y, RectangleF boarders)
        {
            id = ID;
            ++ID;
            code = 'R';
            genLength = 50;
            minGenLength = 5;
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
            path.AddRectangle(new RectangleF((x - ((genLength * 2) / 2)), (y - (genLength / 2)), genLength * 2, genLength));
        }

        ~CRectangle()
        {
            --ID;
        }

    }
}
