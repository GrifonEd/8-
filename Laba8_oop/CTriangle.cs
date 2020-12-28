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
    public class CTriangle : Shape
    {
        PointF[] vertices;

        public CTriangle()
        {
            id = ID;
            ++ID;
            code = 'T';
            path = new GraphicsPath();
            vertices = new PointF[3];
        }

        public CTriangle(int x, int y, RectangleF boarders)
        {
            marked = true;
            id = ID;
            ++ID;
            code = 'T';
            minGenLength = 5;
            genLength = 60;
            this.x = x;
            this.y = y;
            vertices = new PointF[3];
            path = new GraphicsPath();
            lastCommand = "Constructor";
            updateBoarders(boarders);
            relocate();
        }

        public override void save(StreamWriter writer)
        {
            writer.WriteLine("T");
            writingCommonParams(writer);
            writer.WriteLine("Vertices:");
            writer.WriteLine("vertex[0]x: " + vertices[0].X);
            writer.WriteLine("vertex[0]y: " + vertices[0].Y);
            writer.WriteLine("vertex[1]x: " + vertices[1].X);
            writer.WriteLine("vertex[1]y: " + vertices[1].Y);
            writer.WriteLine("vertex[2]x: " + vertices[2].X);
            writer.WriteLine("vertex[2]y: " + vertices[2].Y);
        }

        public override void load(StreamReader reader)
        {
            readingCommonParas(reader);
            reader.ReadLine();
            vertices[0].X = float.Parse(extractInfo(reader.ReadLine()));
            vertices[0].Y = float.Parse(extractInfo(reader.ReadLine()));
            vertices[1].X = float.Parse(extractInfo(reader.ReadLine()));
            vertices[1].Y = float.Parse(extractInfo(reader.ReadLine()));
            vertices[2].X = float.Parse(extractInfo(reader.ReadLine()));
            vertices[2].Y = float.Parse(extractInfo(reader.ReadLine()));
            fillPath();
        }

        private void calc()
        {
            vertices[0] = new PointF(x - (genLength / 2), y + (float)((1.73 / 6) * genLength));
            vertices[1] = new PointF(x, y - (float)((1.73 / 3) * genLength));
            vertices[2] = new PointF(x + (genLength / 2), y + (float)((1.73 / 6) * genLength));
        }

        public override void fillPath()
        {
            calc();
            path.Reset();
            path.AddPolygon(vertices);
        }

        ~CTriangle()
        {
            --ID;
        }

    }
}
