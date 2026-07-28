namespace rknRallySlotApp.Vistas
{
    partial class FormPrueba
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
            lblPrueba = new Label();
            botonCancel = new Button();
            botonSave = new Button();
            lblForm = new Label();
            tbox_Prueba = new TextBox();
            tbox_nEtapas = new TextBox();
            label1 = new Label();
            tbox_nTramos = new TextBox();
            label2 = new Label();
            tbox_tMaxSeg = new TextBox();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // lblPrueba
            // 
            lblPrueba.AutoSize = true;
            lblPrueba.ForeColor = Color.White;
            lblPrueba.Location = new Point(27, 76);
            lblPrueba.Name = "lblPrueba";
            lblPrueba.Size = new Size(127, 15);
            lblPrueba.TabIndex = 4;
            lblPrueba.Text = "Nombre Prueba (Rally)";
            // 
            // botonCancel
            // 
            botonCancel.BackColor = Color.FromArgb(52, 73, 94);
            botonCancel.BackgroundImageLayout = ImageLayout.Zoom;
            botonCancel.Cursor = Cursors.Hand;
            botonCancel.FlatStyle = FlatStyle.Flat;
            botonCancel.ForeColor = Color.Transparent;
            botonCancel.Location = new Point(509, 150);
            botonCancel.Name = "botonCancel";
            botonCancel.Size = new Size(35, 35);
            botonCancel.TabIndex = 8;
            botonCancel.TabStop = false;
            botonCancel.UseVisualStyleBackColor = false;
            botonCancel.Click += BotonCancel_Click;
            // 
            // botonSave
            // 
            botonSave.BackColor = Color.FromArgb(52, 73, 94);
            botonSave.BackgroundImageLayout = ImageLayout.None;
            botonSave.Cursor = Cursors.Hand;
            botonSave.Enabled = false;
            botonSave.FlatStyle = FlatStyle.Flat;
            botonSave.ForeColor = Color.Transparent;
            botonSave.Location = new Point(468, 150);
            botonSave.Name = "botonSave";
            botonSave.Size = new Size(35, 35);
            botonSave.TabIndex = 6;
            botonSave.TabStop = false;
            botonSave.UseVisualStyleBackColor = false;
            botonSave.Click += BotonSave_Click;
            // 
            // lblForm
            // 
            lblForm.AutoSize = true;
            lblForm.BorderStyle = BorderStyle.FixedSingle;
            lblForm.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblForm.ForeColor = Color.White;
            lblForm.Location = new Point(27, 24);
            lblForm.Name = "lblForm";
            lblForm.Size = new Size(2, 27);
            lblForm.TabIndex = 9;
            // 
            // tbox_Prueba
            // 
            tbox_Prueba.BackColor = Color.White;
            tbox_Prueba.BorderStyle = BorderStyle.FixedSingle;
            tbox_Prueba.ForeColor = Color.Black;
            tbox_Prueba.Location = new Point(27, 94);
            tbox_Prueba.Name = "tbox_Prueba";
            tbox_Prueba.Size = new Size(260, 23);
            tbox_Prueba.TabIndex = 1;
            tbox_Prueba.TextChanged += All_tbox_TextChanged;
            tbox_Prueba.KeyDown += All_tbox_KeyDown;
            // 
            // tbox_nEtapas
            // 
            tbox_nEtapas.BackColor = Color.White;
            tbox_nEtapas.BorderStyle = BorderStyle.FixedSingle;
            tbox_nEtapas.ForeColor = Color.Black;
            tbox_nEtapas.Location = new Point(293, 94);
            tbox_nEtapas.Name = "tbox_nEtapas";
            tbox_nEtapas.Size = new Size(61, 23);
            tbox_nEtapas.TabIndex = 10;
            tbox_nEtapas.TextAlign = HorizontalAlignment.Right;
            tbox_nEtapas.TextChanged += All_tbox_TextChanged;
            tbox_nEtapas.KeyDown += All_tbox_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(293, 76);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 11;
            label1.Text = "nº Etapas";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbox_nTramos
            // 
            tbox_nTramos.BackColor = Color.White;
            tbox_nTramos.BorderStyle = BorderStyle.FixedSingle;
            tbox_nTramos.ForeColor = Color.Black;
            tbox_nTramos.Location = new Point(360, 94);
            tbox_nTramos.Name = "tbox_nTramos";
            tbox_nTramos.Size = new Size(61, 23);
            tbox_nTramos.TabIndex = 12;
            tbox_nTramos.TextAlign = HorizontalAlignment.Right;
            tbox_nTramos.TextChanged += All_tbox_TextChanged;
            tbox_nTramos.KeyDown += All_tbox_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(360, 76);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 13;
            label2.Text = "nº Tramos";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbox_tMaxSeg
            // 
            tbox_tMaxSeg.BackColor = Color.White;
            tbox_tMaxSeg.BorderStyle = BorderStyle.FixedSingle;
            tbox_tMaxSeg.ForeColor = Color.Black;
            tbox_tMaxSeg.Location = new Point(427, 94);
            tbox_tMaxSeg.Name = "tbox_tMaxSeg";
            tbox_tMaxSeg.Size = new Size(69, 23);
            tbox_tMaxSeg.TabIndex = 14;
            tbox_tMaxSeg.TextAlign = HorizontalAlignment.Right;
            tbox_tMaxSeg.TextChanged += All_tbox_TextChanged;
            tbox_tMaxSeg.KeyDown += All_tbox_KeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(427, 76);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 15;
            label3.Text = "tº máximno";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(502, 96);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 16;
            label4.Text = "seg.";
            // 
            // FormPrueba
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 62, 80);
            ClientSize = new Size(569, 211);
            ControlBox = false;
            Controls.Add(label4);
            Controls.Add(tbox_tMaxSeg);
            Controls.Add(label3);
            Controls.Add(tbox_nTramos);
            Controls.Add(label2);
            Controls.Add(tbox_nEtapas);
            Controls.Add(label1);
            Controls.Add(tbox_Prueba);
            Controls.Add(lblForm);
            Controls.Add(botonCancel);
            Controls.Add(botonSave);
            Controls.Add(lblPrueba);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormPrueba";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblPrueba;
        private Button botonCancel;
        private Button botonSave;
        private Label lblForm;
        private TextBox tbox_Prueba;
        private TextBox tbox_nEtapas;
        private Label label1;
        private TextBox tbox_nTramos;
        private Label label2;
        private TextBox tbox_tMaxSeg;
        private Label label3;
        private Label label4;
    }
}