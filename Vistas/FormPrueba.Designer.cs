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
            tbox_PwrStg = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // lblPrueba
            // 
            lblPrueba.AutoSize = true;
            lblPrueba.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblPrueba.ForeColor = Color.Lime;
            lblPrueba.Location = new Point(59, 88);
            lblPrueba.Name = "lblPrueba";
            lblPrueba.Size = new Size(145, 17);
            lblPrueba.TabIndex = 0;
            lblPrueba.Text = "Nombre Prueba (Rally)";
            // 
            // botonCancel
            // 
            botonCancel.BackColor = Color.FromArgb(52, 73, 94);
            botonCancel.BackgroundImageLayout = ImageLayout.Zoom;
            botonCancel.Cursor = Cursors.Hand;
            botonCancel.FlatStyle = FlatStyle.Flat;
            botonCancel.ForeColor = Color.Transparent;
            botonCancel.Location = new Point(562, 163);
            botonCancel.Name = "botonCancel";
            botonCancel.Size = new Size(35, 35);
            botonCancel.TabIndex = 0;
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
            botonSave.Location = new Point(521, 163);
            botonSave.Name = "botonSave";
            botonSave.Size = new Size(35, 35);
            botonSave.TabIndex = 0;
            botonSave.TabStop = false;
            botonSave.UseVisualStyleBackColor = false;
            botonSave.Click += BotonSave_Click;
            // 
            // lblForm
            // 
            lblForm.AutoSize = true;
            lblForm.BorderStyle = BorderStyle.FixedSingle;
            lblForm.Font = new Font("Segoe UI Black", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblForm.ForeColor = Color.FromArgb(255, 128, 0);
            lblForm.Location = new Point(59, 36);
            lblForm.Name = "lblForm";
            lblForm.Size = new Size(2, 30);
            lblForm.TabIndex = 9;
            // 
            // tbox_Prueba
            // 
            tbox_Prueba.BackColor = Color.White;
            tbox_Prueba.BorderStyle = BorderStyle.FixedSingle;
            tbox_Prueba.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            tbox_Prueba.ForeColor = Color.Black;
            tbox_Prueba.Location = new Point(59, 106);
            tbox_Prueba.Name = "tbox_Prueba";
            tbox_Prueba.Size = new Size(277, 27);
            tbox_Prueba.TabIndex = 1;
            tbox_Prueba.TextChanged += All_tbox_TextChanged;
            tbox_Prueba.KeyDown += All_tbox_KeyDown;
            // 
            // tbox_nEtapas
            // 
            tbox_nEtapas.BackColor = Color.White;
            tbox_nEtapas.BorderStyle = BorderStyle.FixedSingle;
            tbox_nEtapas.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            tbox_nEtapas.ForeColor = Color.Black;
            tbox_nEtapas.Location = new Point(342, 106);
            tbox_nEtapas.Name = "tbox_nEtapas";
            tbox_nEtapas.Size = new Size(61, 27);
            tbox_nEtapas.TabIndex = 2;
            tbox_nEtapas.TextAlign = HorizontalAlignment.Right;
            tbox_nEtapas.TextChanged += All_tbox_TextChanged;
            tbox_nEtapas.KeyDown += All_tbox_KeyDown;
            tbox_nEtapas.Leave += Tbox_nEtapas_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.Lime;
            label1.Location = new Point(342, 88);
            label1.Name = "label1";
            label1.Size = new Size(66, 17);
            label1.TabIndex = 0;
            label1.Text = "nº Etapas";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbox_nTramos
            // 
            tbox_nTramos.BackColor = Color.White;
            tbox_nTramos.BorderStyle = BorderStyle.FixedSingle;
            tbox_nTramos.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            tbox_nTramos.ForeColor = Color.Black;
            tbox_nTramos.Location = new Point(409, 106);
            tbox_nTramos.Name = "tbox_nTramos";
            tbox_nTramos.Size = new Size(70, 27);
            tbox_nTramos.TabIndex = 3;
            tbox_nTramos.TextAlign = HorizontalAlignment.Right;
            tbox_nTramos.TextChanged += All_tbox_TextChanged;
            tbox_nTramos.KeyDown += All_tbox_KeyDown;
            tbox_nTramos.Leave += Tbox_nTramos_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.ForeColor = Color.Lime;
            label2.Location = new Point(409, 88);
            label2.Name = "label2";
            label2.Size = new Size(70, 17);
            label2.TabIndex = 0;
            label2.Text = "nº Tramos";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbox_tMaxSeg
            // 
            tbox_tMaxSeg.BackColor = Color.White;
            tbox_tMaxSeg.BorderStyle = BorderStyle.FixedSingle;
            tbox_tMaxSeg.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            tbox_tMaxSeg.ForeColor = Color.Black;
            tbox_tMaxSeg.Location = new Point(485, 106);
            tbox_tMaxSeg.Name = "tbox_tMaxSeg";
            tbox_tMaxSeg.Size = new Size(78, 27);
            tbox_tMaxSeg.TabIndex = 4;
            tbox_tMaxSeg.TextAlign = HorizontalAlignment.Right;
            tbox_tMaxSeg.TextChanged += All_tbox_TextChanged;
            tbox_tMaxSeg.KeyDown += All_tbox_KeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.ForeColor = Color.Lime;
            label3.Location = new Point(485, 88);
            label3.Name = "label3";
            label3.Size = new Size(72, 17);
            label3.TabIndex = 0;
            label3.Text = "tº máximo";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(569, 118);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 16;
            label4.Text = "seg.";
            // 
            // tbox_PwrStg
            // 
            tbox_PwrStg.BackColor = Color.White;
            tbox_PwrStg.BorderStyle = BorderStyle.FixedSingle;
            tbox_PwrStg.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            tbox_PwrStg.ForeColor = Color.Black;
            tbox_PwrStg.Location = new Point(59, 153);
            tbox_PwrStg.Name = "tbox_PwrStg";
            tbox_PwrStg.Size = new Size(218, 27);
            tbox_PwrStg.TabIndex = 5;
            tbox_PwrStg.Enter += Tbox_PwrStg_Enter;
            tbox_PwrStg.KeyDown += All_tbox_KeyDown;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(59, 135);
            label5.Name = "label5";
            label5.Size = new Size(84, 17);
            label5.TabIndex = 0;
            label5.Text = "Power Stage";
            // 
            // FormPrueba
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(52, 73, 94);
            ClientSize = new Size(664, 234);
            ControlBox = false;
            Controls.Add(tbox_PwrStg);
            Controls.Add(label5);
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
            ForeColor = SystemColors.WindowText;
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
        private TextBox tbox_PwrStg;
        private Label label5;
    }
}