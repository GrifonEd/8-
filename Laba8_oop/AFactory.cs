using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba8_oop
{
    public abstract class ShapeFactory
    {
        public abstract Shape createShape(char code);
    }

    public class MyShapeFactory : ShapeFactory
    {
        public override Shape createShape(char code)
        {
            switch (code)
            {
                case 'C':
                    {
                        return new CCircle();
                    }
                case 'R':
                    {
                        return new CRectangle();
                    }
                case 'S':
                    {
                        return new CSquare();
                    }
                case 'T':
                    {
                        return new CTriangle();
                    }
                case 'G':
                    {
                        return new CGroup();
                    }
                case 'L':
                    {
                        return new StickyRectangle();
                    }

                default:
                    {
                        return null;
                    }
            }
        }
    }
}
