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
    public abstract class Shape : ISerializable, ISubject, IObserver
    {
        protected int id;
        protected char code;
        protected bool groupFlag = false;
        protected bool marked = true;
        protected string lastCommand;
        protected RectangleF boarders;
        protected GraphicsPath path;
        protected int genLength;
        protected int minGenLength;
        protected int x;
        protected int y;
        protected SolidBrush brush;
        public static int ID = 0;
        protected List<IObserver> observers = new List<IObserver>();

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public string getLastCommand()
        {
            return lastCommand;
        }

        public virtual bool intersectWith(GraphicsPath _path)
        {
            return path.GetBounds().IntersectsWith(_path.GetBounds());
        }

        public virtual void setMarked(bool value)
        {
            marked = value;
            if (!groupFlag)
            {
                notifyEveryone();
            }
        }

        public bool getMarked()
        {
            return marked;
        }
        public virtual void onSubjectChanged(ISubject subject)
        {
            if (subject is StickyRectangle)
            {
                if (!groupFlag)
                {
                    offset((subject as StickyRectangle).deltaX, (subject as StickyRectangle).deltaY);
                }
                else
                {
                    subject.removeObserver(this);
                }
            }
        }

        public void addObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void removeObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void notifyEveryone()
        {
            for (int i = 0; i < observers.Count(); ++i)
            {
                observers[i].onSubjectChanged(this);
            }
        }

        public int getID()
        {
            return id;
        }

        public RectangleF getBoarders()
        {
            return boarders;
        }

        public void writingCommonParams(StreamWriter writer)
        {
            float x = boarders.X;
            float y = boarders.Y;
            float height = boarders.Height;
            float width = boarders.Width;

            string color = brush.Color.ToString().Substring(7);
            color = color.Remove(color.Length - 1);

            writer.WriteLine("relocateFlag: " + groupFlag.ToString());
            writer.WriteLine("marked: " + marked.ToString());
            writer.WriteLine("lastCommand: " + lastCommand);
            writer.WriteLine("boarders:");
            writer.WriteLine("x: " + x.ToString());
            writer.WriteLine("y: " + y.ToString());
            writer.WriteLine("width: " + width.ToString());
            writer.WriteLine("height: " + height.ToString());
            writer.WriteLine("");
            writer.WriteLine("genLength: " + genLength.ToString());
            writer.WriteLine("minGenLength: " + minGenLength.ToString());
            writer.WriteLine("xCoord: " + this.x.ToString());
            writer.WriteLine("yCoord: " + this.y.ToString());
            writer.WriteLine("color: " + color);
        }

        protected string extractInfo(string line)
        {
            string[] parts = line.Split(' ');
            return parts[1];
        }

        public void readingCommonParas(StreamReader reader)
        {
            groupFlag = bool.Parse(extractInfo(reader.ReadLine()));
            marked = bool.Parse(extractInfo(reader.ReadLine()));
            lastCommand = extractInfo(reader.ReadLine());
            reader.ReadLine();
            float x = float.Parse(extractInfo(reader.ReadLine()));
            float y = float.Parse(extractInfo(reader.ReadLine()));
            float width = float.Parse(extractInfo(reader.ReadLine()));
            float height = float.Parse(extractInfo(reader.ReadLine()));
            boarders = new RectangleF(x, y, width, height);
            reader.ReadLine();
            genLength = int.Parse(extractInfo(reader.ReadLine()));
            minGenLength = int.Parse(extractInfo(reader.ReadLine()));
            this.x = int.Parse(extractInfo(reader.ReadLine()));
            this.y = int.Parse(extractInfo(reader.ReadLine()));
            switch (extractInfo(reader.ReadLine()))
            {
                case "White":
                    {
                        brush = new SolidBrush(Color.White);
                        break;
                    }
                case "Black":
                    {
                        brush = new SolidBrush(Color.Black);
                        break;
                    }
                case "Green":
                    {
                        brush = new SolidBrush(Color.LightGreen);
                        break;
                    }
                case "Yellow":
                    {
                        brush = new SolidBrush(Color.Yellow);
                        break;
                    }
            }
        }

        public virtual void save(StreamWriter writer)
        {
            writer.WriteLine(code);
            writingCommonParams(writer);
        }

        public virtual void load(StreamReader reader)
        {
            readingCommonParas(reader);
            fillPath();
        }

        public virtual bool isPointed(int x, int y)
        {
            return path.IsVisible(x, y);
        }

        public virtual void setGroupFlag(bool value)
        {
            groupFlag = value;
        }

        public virtual bool getGroupFlag()
        {
            return groupFlag;
        }

        public GraphicsPath getPath()
        {
            return path;
        }

        public virtual void draw(Graphics graphics, SolidBrush brush)
        {
            Pen pen;
            if (marked == true)
            {
                pen = new Pen(Color.Red);
                this.brush = brush;
            }
            else
            {
                pen = new Pen(Color.Black);
            }
            pen.Width = 2;
            graphics.DrawPath(pen, path);
            graphics.FillPath(this.brush, path);

        }

        public virtual void updateBoarders(RectangleF boarders)
        {
            this.boarders = boarders;
        }

        public virtual bool checkBoarders()
        {
            return boarders.Contains(path.GetBounds());
        }

        public virtual void scale(int delta)
        {
            genLength += delta;
            if (genLength < minGenLength)
            {
                genLength = minGenLength;
            }

            lastCommand = "scale";
            relocate();
            if (!groupFlag)
            {
                notifyEveryone();
            }
        }
        public virtual void offset(int deltaX, int deltaY)
        {
            x += deltaX;
            y += deltaY;
            lastCommand = "offset";
            relocate();
            if (!groupFlag)
            {
                notifyEveryone();
            }
        }

        public abstract void fillPath();

        protected virtual void relocate()
        {
            fillPath();

            if (groupFlag == false)
            {
                while (!checkBoarders())
                {
                    RectangleF boundsRec = path.GetBounds();
                    PointF left = boundsRec.Location;
                    PointF right = new PointF(boundsRec.Right, boundsRec.Y);
                    PointF bLeft = new PointF(boundsRec.X, boundsRec.Bottom);
                    PointF bRight = new PointF(boundsRec.Right, boundsRec.Bottom);

                    if (lastCommand == "Constructor" || lastCommand == "offset")
                    {
                        if (!boarders.Contains(left) && !boarders.Contains(bLeft))
                        {
                            x += 1;
                        }

                        if (!boarders.Contains(left) && !boarders.Contains(right))
                        {
                            y += 1;
                        }

                        if (!boarders.Contains(right) && !boarders.Contains(bRight))
                        {
                            x -= 1;
                        }

                        if (!boarders.Contains(bLeft) && !boarders.Contains(bRight))
                        {
                            y -= 1;
                        }
                    }
                    else
                    {
                        scale(-1);
                    }

                    fillPath();
                }
            }

        }

        ~Shape()
        {

        }

    }
}
