using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba8_oop
{
    public class CSquare : CRectangle
    {

        public CSquare() : base()
        {
            code = 'S';
            path = new GraphicsPath();
        }

        public CSquare(int x, int y, RectangleF boarders) : base(x, y, boarders)
        {
            code = 'S';
        }

        public override void fillPath()
        {
            path.Reset();
            path.AddRectangle(new RectangleF((x - ((genLength * 2) / 2)), (y - (genLength / 2)), genLength, genLength));
        }

        ~CSquare()
        {

        }
    }
}
