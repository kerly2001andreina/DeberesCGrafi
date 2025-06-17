namespace AlgoritmosGraficos
{
    partial class Windows
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Windows));
            pictureBox1 = new PictureBox();
            listBox1 = new ListBox();
            btnDDA = new Button();
            btnBresenham = new Button();
            btnCircunferencia = new Button();
            btnPoligono = new Button();
            btnRelleno = new Button();
            Title = new Label();
            nudLados = new NumericUpDown();
            btnLimpiar = new Button();
            colorDialog1 = new ColorDialog();
            btnColor = new Button();
            Instructions = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudLados).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(428, 312);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(824, 326);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(52, 35);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(273, 304);
            listBox1.TabIndex = 1;
            // 
            // btnDDA
            // 
            btnDDA.Location = new Point(52, 363);
            btnDDA.Name = "btnDDA";
            btnDDA.Size = new Size(112, 34);
            btnDDA.TabIndex = 2;
            btnDDA.Text = "DDA";
            btnDDA.UseVisualStyleBackColor = true;
            btnDDA.Click += BtnDDA_Click;
            // 
            // btnBresenham
            // 
            btnBresenham.Location = new Point(213, 363);
            btnBresenham.Name = "btnBresenham";
            btnBresenham.Size = new Size(112, 34);
            btnBresenham.TabIndex = 3;
            btnBresenham.Text = "Bresenham";
            btnBresenham.UseVisualStyleBackColor = true;
            btnBresenham.Click += BtnBresenham_Click;
            // 
            // btnCircunferencia
            // 
            btnCircunferencia.Location = new Point(52, 426);
            btnCircunferencia.Name = "btnCircunferencia";
            btnCircunferencia.Size = new Size(140, 34);
            btnCircunferencia.TabIndex = 4;
            btnCircunferencia.Text = "Circunferencia";
            btnCircunferencia.UseVisualStyleBackColor = true;
            btnCircunferencia.Click += BtnCircunferencia_Click;
            // 
            // btnPoligono
            // 
            btnPoligono.Location = new Point(52, 487);
            btnPoligono.Name = "btnPoligono";
            btnPoligono.Size = new Size(112, 34);
            btnPoligono.TabIndex = 5;
            btnPoligono.Text = "Polígono";
            btnPoligono.UseVisualStyleBackColor = true;
            btnPoligono.Click += BtnPoligono_Click;
            // 
            // btnRelleno
            // 
            btnRelleno.Location = new Point(52, 543);
            btnRelleno.Name = "btnRelleno";
            btnRelleno.Size = new Size(112, 34);
            btnRelleno.TabIndex = 6;
            btnRelleno.Text = "Rellenar";
            btnRelleno.UseVisualStyleBackColor = true;
            btnRelleno.Click += BtnRelleno_Click;
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new Font("Stencil", 11F, FontStyle.Italic, GraphicsUnit.Point, 0);
            Title.Location = new Point(52, 7);
            Title.Name = "Title";
            Title.Size = new Size(255, 26);
            Title.TabIndex = 7;
            Title.Text = "Algoritmos Gráficos";
            // 
            // nudLados
            // 
            nudLados.Location = new Point(213, 487);
            nudLados.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            nudLados.Name = "nudLados";
            nudLados.Size = new Size(180, 31);
            nudLados.TabIndex = 8;
            nudLados.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(213, 543);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(112, 34);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnColor
            // 
            btnColor.Location = new Point(213, 426);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(112, 34);
            btnColor.TabIndex = 10;
            btnColor.Text = "Color";
            btnColor.UseVisualStyleBackColor = true;
            btnColor.Click += btnColor_Click;
            // 
            // Instructions
            // 
            Instructions.AutoSize = true;
            Instructions.Font = new Font("Stencil", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            Instructions.Location = new Point(428, 4);
            Instructions.Name = "Instructions";
            Instructions.Size = new Size(289, 29);
            Instructions.TabIndex = 11;
            Instructions.Text = "Instrucciones de Uso:";
            Instructions.Click += Instructions_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sylfaen", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(428, 33);
            label1.Name = "label1";
            label1.Size = new Size(742, 260);
            label1.TabIndex = 11;
            label1.Text = resources.GetString("label1.Text");
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1286, 650);
            Controls.Add(label1);
            Controls.Add(Instructions);
            Controls.Add(btnColor);
            Controls.Add(btnLimpiar);
            Controls.Add(nudLados);
            Controls.Add(Title);
            Controls.Add(btnRelleno);
            Controls.Add(btnPoligono);
            Controls.Add(btnCircunferencia);
            Controls.Add(btnBresenham);
            Controls.Add(btnDDA);
            Controls.Add(listBox1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudLados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private ListBox listBox1;
        private Button btnDDA;
        private Button btnBresenham;
        private Button btnCircunferencia;
        private Button btnPoligono;
        private Button btnRelleno;
        private Label Title;
        private NumericUpDown nudLados;
        private Button btnLimpiar;
        private ColorDialog colorDialog1;
        private Button btnColor;
        private Label Instructions;
        private Label label1;
    }
}
