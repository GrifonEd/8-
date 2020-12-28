using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba8_oop
{
    public class CGroup : Shape
    {
        protected int maxCount;
        protected int count;
        protected Container shapes;

        public CGroup()
        {
            id = ID;
            ++ID;
            code = 'G';
            shapes = new Container();
        }

        public CGroup(int maxCount, RectangleF boarders)
        {
            id = ID;
            ++ID;
            code = 'G';
            this.maxCount = maxCount;
            this.boarders = boarders;
            count = 0;
            shapes = new Container();
        }

        public override bool intersectWith(GraphicsPath _path)
        {
            for (ContainerIterator it = shapes.Begin(); it != shapes.End(); ++it)
            {
                if (it.getNode().key.intersectWith(_path))
                {
                    return true;
                }
            }
            return false;
        }

        public override void setMarked(bool value)
        {
            marked = value;

            for (ContainerIterator it = shapes.Begin(); it != shapes.End(); ++it)
            {
                it.getNode().key.setMarked(value);
            }

            if (!groupFlag)
            {
                notifyEveryone();
            }
        }


        public Container getShapes()
        {
            return shapes;
        }

        public override void save(StreamWriter writer)
        {
            writer.WriteLine(code);
            writer.WriteLine("maxCount: " + maxCount.ToString());
            writer.WriteLine("count: " + count.ToString());
            writer.WriteLine("relocateFlag: " + groupFlag.ToString());
            for (ContainerIterator it = shapes.Begin(); it != shapes.End(); ++it)
            {
                it.getNode().key.save(writer);
            }
            writer.WriteLine();
        }

        public void loadGroup(StreamReader reader, ShapeFactory factory)
        {
            maxCount = int.Parse(extractInfo(reader.ReadLine()));
            count = int.Parse(extractInfo(reader.ReadLine()));
            groupFlag = bool.Parse(extractInfo(reader.ReadLine()));
            shapes.loadShapes(reader, factory);
            this.boarders = shapes.Begin().getNode().key.getBoarders();
        }

        public int getCount()
        {
            return count;
        }

        public override bool checkBoarders()
        {
            for (ContainerIterator it = shapes.Begin(); it != shapes.End(); ++it)
            {
                if (!it.getNode().key.checkBoarders())
                {
                    path = it.getNode().key.getPath();
                    return false;
                }
            }

            return true;
        }

        public override void updateBoarders(RectangleF boarders)
        {
            this.boarders = boarders;
            for (ContainerIterator it = shapes.Begin(); it != shapes.End(); ++it)
            {
                it.getNode().key.updateBoarders(boarders);
            }

        }

        public override bool isPointed(int x, int y)
        {
            for (ContainerIterator it = shapes.Begin(); it != shapes.End(); ++it)
            {
                if (it.getNode().key.isPointed(x, y))
                {
                    return true;
                }
            }

            return false;
        }

        public override void draw(Graphics graphics, SolidBrush brush)
        {
            for (ContainerIterator it = shapes.Begin(); it != shapes.End(); ++it)
            {
                it.getNode().key.setMarked(this.marked);
                it.getNode().key.draw(graphics, brush);
            }
        }

    }
