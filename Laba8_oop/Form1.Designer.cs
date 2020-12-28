namespace Laba8_oop
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.makeAGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.divideTheGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveShapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Загрузить = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_black = new System.Windows.Forms.Button();
            this.btn_white = new System.Windows.Forms.Button();
            this.btn_green = new System.Windows.Forms.Button();
            this.stickyShape_btn = new System.Windows.Forms.Button();
            this.btn_triangle = new System.Windows.Forms.Button();
            this.btn_square = new System.Windows.Forms.Button();
            this.btn_rec = new System.Windows.Forms.Button();
            this.btn_circle = new System.Windows.Forms.Button();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenu
            // 
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makeAGroupToolStripMenuItem,
            this.divideTheGroupToolStripMenuItem,
            this.saveShapesToolStripMenuItem,
            this.Загрузить});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(226, 132);
            this.contextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenu_ItemClicked);
            // 
            // makeAGroupToolStripMenuItem
            // 
            this.makeAGroupToolStripMenuItem.Name = "makeAGroupToolStripMenuItem";
            this.makeAGroupToolStripMenuItem.Size = new System.Drawing.Size(225, 32);
            this.makeAGroupToolStripMenuItem.Text = "Группировка";
            // 
            // divideTheGroupToolStripMenuItem
            // 
            this.divideTheGroupToolStripMenuItem.Name = "divideTheGroupToolStripMenuItem";
            this.divideTheGroupToolStripMenuItem.Size = new System.Drawing.Size(225, 32);
            this.divideTheGroupToolStripMenuItem.Text = "Разгруппировать";
            // 
            // saveShapesToolStripMenuItem
            // 
            this.saveShapesToolStripMenuItem.Name = "saveShapesToolStripMenuItem";
            this.saveShapesToolStripMenuItem.Size = new System.Drawing.Size(225, 32);
            this.saveShapesToolStripMenuItem.Text = "Сохранить";
            // 
            // Загрузить
            // 
            this.Загрузить.Name = "Загрузить";
            this.Загрузить.Size = new System.Drawing.Size(225, 32);
            this.Загрузить.Text = "Загрузить";
            // 
            // btn_black
            // 
            this.btn_black.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_black.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_black.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_black.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_black.Location = new System.Drawing.Point(729, 298);
            this.btn_black.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_black.Name = "btn_black";
            this.btn_black.Size = new System.Drawing.Size(68, 160);
            this.btn_black.TabIndex = 6;
            this.btn_black.Text = "Черный";
            this.btn_black.UseVisualStyleBackColor = false;
            this.btn_black.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btn_white
            // 
            this.btn_white.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_white.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_white.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_white.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_white.Location = new System.Drawing.Point(731, 14);
            this.btn_white.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_white.Name = "btn_white";
            this.btn_white.Size = new System.Drawing.Size(66, 128);
            this.btn_white.TabIndex = 7;
            this.btn_white.Text = "Белый";
            this.btn_white.UseVisualStyleBackColor = false;
            this.btn_white.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btn_green
            // 
            this.btn_green.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_green.BackColor = System.Drawing.Color.LightGreen;
            this.btn_green.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_green.ForeColor = System.Drawing.Color.LightGreen;
            this.btn_green.Location = new System.Drawing.Point(731, 152);
            this.btn_green.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_green.Name = "btn_green";
            this.btn_green.Size = new System.Drawing.Size(66, 136);
            this.btn_green.TabIndex = 8;
            this.btn_green.Text = "Зеленый";
            this.btn_green.UseVisualStyleBackColor = false;
            this.btn_green.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // stickyShape_btn
            // 
            this.stickyShape_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stickyShape_btn.BackColor = System.Drawing.Color.White;
            this.stickyShape_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.stickyShape_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stickyShape_btn.Location = new System.Drawing.Point(539, 591);
            this.stickyShape_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.stickyShape_btn.Name = "stickyShape_btn";
            this.stickyShape_btn.Size = new System.Drawing.Size(146, 83);
            this.stickyShape_btn.TabIndex = 9;
            this.stickyShape_btn.Text = "Липкая фигура";
            this.stickyShape_btn.UseVisualStyleBackColor = false;
            this.stickyShape_btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn_triangle
            // 
            this.btn_triangle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_triangle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_triangle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_triangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_triangle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_triangle.Location = new System.Drawing.Point(281, 591);
            this.btn_triangle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_triangle.Name = "btn_triangle";
            this.btn_triangle.Size = new System.Drawing.Size(125, 83);
            this.btn_triangle.TabIndex = 4;
            this.btn_triangle.Text = "Треугольник";
            this.btn_triangle.UseVisualStyleBackColor = false;
            this.btn_triangle.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn_square
            // 
            this.btn_square.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_square.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_square.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_square.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_square.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_square.Location = new System.Drawing.Point(150, 591);
            this.btn_square.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_square.Name = "btn_square";
            this.btn_square.Size = new System.Drawing.Size(123, 83);
            this.btn_square.TabIndex = 3;
            this.btn_square.Text = "Квадрат";
            this.btn_square.UseVisualStyleBackColor = false;
            this.btn_square.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn_rec
            // 
            this.btn_rec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_rec.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_rec.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_rec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_rec.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_rec.Location = new System.Drawing.Point(15, 591);
            this.btn_rec.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_rec.Name = "btn_rec";
            this.btn_rec.Size = new System.Drawing.Size(127, 83);
            this.btn_rec.TabIndex = 2;
            this.btn_rec.Text = "Прямоугольник";
            this.btn_rec.UseVisualStyleBackColor = false;
            this.btn_rec.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn_circle
            // 
            this.btn_circle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_circle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_circle.CausesValidation = false;
            this.btn_circle.Enabled = false;
            this.btn_circle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_circle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_circle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_circle.Location = new System.Drawing.Point(414, 591);
            this.btn_circle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_circle.Name = "btn_circle";
            this.btn_circle.Size = new System.Drawing.Size(117, 83);
            this.btn_circle.TabIndex = 1;
            this.btn_circle.TabStop = false;
            this.btn_circle.Text = "Круг";
            this.btn_circle.UseVisualStyleBackColor = false;
            this.btn_circle.Click += new System.EventHandler(this.btn_Click);
            // 
            // canvas
            // 
            this.canvas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.canvas.ContextMenuStrip = this.contextMenu;
            this.canvas.Location = new System.Drawing.Point(13, 14);
            this.canvas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(708, 523);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseClick);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.Yellow;
            this.button1.Location = new System.Drawing.Point(731, 468);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 162);
            this.button1.TabIndex = 10;
            this.button1.Text = "Жёлтый";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GreenYellow;
            this.ClientSize = new System.Drawing.Size(1282, 688);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.stickyShape_btn);
            this.Controls.Add(this.btn_green);
            this.Controls.Add(this.btn_white);
            this.Controls.Add(this.btn_black);
            this.Controls.Add(this.btn_triangle);
            this.Controls.Add(this.btn_square);
            this.Controls.Add(this.btn_rec);
            this.Controls.Add(this.btn_circle);
            this.Controls.Add(this.canvas);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1039, 585);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button btn_circle;
        private System.Windows.Forms.Button btn_rec;
        private System.Windows.Forms.Button btn_square;
        private System.Windows.Forms.Button btn_triangle;
        private System.Windows.Forms.Button btn_black;
        private System.Windows.Forms.Button btn_white;
        private System.Windows.Forms.Button btn_green;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem makeAGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem divideTheGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveShapesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Загрузить;
        private System.Windows.Forms.Button stickyShape_btn;
        private System.Windows.Forms.Button button1;
    }
}

