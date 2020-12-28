using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba8_oop
{
    public partial class Form1 : Form, ISerializable
    {
        Container container;
        Bitmap bitmap;
        Graphics graphics;
        RectangleF boarders;
        bool isControlPressed;
        int deltaX, deltaY;
        Button lastShapeButton;
        SolidBrush brush;
        string pathToTheFileOfShapes = @"C:\Users\Asus\Desktop\Laba8_OOP\Saves.txt";
        string pathToTheFileOfFormsParams = @"C:\Users\Asus\Desktop\Laba8_OOP\FormsParams.txt";
        private CustomTreeView treeView;

        public Form1()
        {
            InitializeComponent();
            this.treeView = new CustomTreeView(this);
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.CheckBoxes = false;
            this.treeView.Location = new System.Drawing.Point(533, 10);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(278, 339);
            this.treeView.TabIndex = 9;
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_AfterCheck);
            this.Controls.Add(this.treeView);

            brush = new SolidBrush(Color.White);
            lastShapeButton = btn_circle;
            deltaX = deltaY = 0;
            isControlPressed = false;
            container = new Container();
            container.addObserver(treeView);
            treeView.addObserver(container);
            boarders = new RectangleF(canvas.Location.X - 8, canvas.Location.Y - 8, canvas.Width - 5, canvas.Height - 5);
            bitmap = new Bitmap(canvas.Width, canvas.Height);
            graphics = Graphics.FromImage(bitmap);
            canvas.Image = bitmap;
        }

        public virtual void save(StreamWriter writer)
        {
            writer.WriteLine(this.Width.ToString());
            writer.WriteLine(this.Height.ToString());

            string color = brush.Color.ToString().Substring(7);
            color = color.Remove(color.Length - 1);
            writer.WriteLine(color);
        }

        public virtual void load(StreamReader reader)
        {
            this.Width = int.Parse(reader.ReadLine());
            this.Height = int.Parse(reader.ReadLine());

            switch (reader.ReadLine())
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

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graphics.Clear(Color.White);
            for (ContainerIterator it = container.Begin(); it != container.End(); ++it)
            {
                it.getNode().key.draw(graphics, brush);
            }
            canvas.Image = bitmap;
        }
        private void unmarkAll()
        {
            for (ContainerIterator it = container.Begin(); it != container.End(); ++it)
            {
                it.getNode().key.setMarked(false);
            }
        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ContainerIterator it = container.Last();
                while (it != container.End())
                {
                    Shape current = it.getNode().key;
                    if (current.isPointed(e.X, e.Y))
                    {
                        if (!isControlPressed)
                        {
                            bool tmp = (current.getMarked() == true ? false : true);
                            unmarkAll();
                            current.setMarked(tmp);
                        }
                        else
                        {
                            current.setMarked((current.getMarked() ? false : true));
                        }

                        this.Invalidate();
                        return;
                    }

                    if (it == container.Begin())
                    {
                        break;
                    }
                    --it;
                }


                unmarkAll();
                Shape newShape = null;
                switch (lastShapeButton.Text)
                {
                    case "Круг":
                        {
                            newShape = new CCircle(e.X, e.Y, boarders);
                            break;
                        }
                    case "Прямоугольник":
                        {
                            newShape = new CRectangle(e.X, e.Y, boarders);
                            break;
                        }
                    case "Квадрат":
                        {
                            newShape = new CSquare(e.X, e.Y, boarders);
                            break;
                        }
                    case "Треугольник":
                        {
                            newShape = new CTriangle(e.X, e.Y, boarders);
                            break;
                        }
                    case "Липкая фигура":
                        {
                            newShape = new StickyRectangle(e.X, e.Y, boarders);
                            break;
                        }

                }
                container.Push_back(newShape);

                this.Invalidate();
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                isControlPressed = true;
            }

            if (e.KeyCode == Keys.Delete)
            {
                for (ContainerIterator it = container.Begin(); it != container.End(); ++it)
                {
                    if ((it.getNode().key.getMarked()))
                    {
                        container.Remove(it.getNode().key);
                    }
                }
            }

            if (e.KeyCode == Keys.L || e.KeyCode == Keys.K)
            {
                for (ContainerIterator it = container.Begin(); it != container.End(); ++it)
                {
                    if (it.getNode().key.getMarked() == true)
                    {
                        if (e.KeyCode == Keys.L)
                        {
                            it.getNode().key.scale(1);
                        }
                        else
                        {
                            it.getNode().key.scale(-1);
                        }

                    }
                }
            }

            if (e.KeyCode == Keys.A || e.KeyCode == Keys.D || e.KeyCode == Keys.S || e.KeyCode == Keys.W)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        deltaX = -10;
                        break;
                    case Keys.D:
                        deltaX = 10;
                        break;
                    case Keys.W:
                        deltaY = -10;
                        break;
                    case Keys.S:
                        deltaY = 10;
                        break;
                }

                for (ContainerIterator it = container.Begin(); it != container.End(); ++it)
                {
                    if (it.getNode().key.getMarked() == true)
                    {
                        it.getNode().key.offset(deltaX, deltaY);
                    }
                }
            }
            else
            {
                deltaX = deltaY = 0;
            }

            this.Invalidate();
        }
    }
