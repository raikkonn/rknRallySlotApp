namespace rknRallySlotApp.Vistas
{
    partial class FormCampeonato
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
            tboxPuntuacion = new TextBox();
            lblPtos1 = new Label();
            lblCto = new Label();
            botonCancel = new Button();
            botonSave = new Button();
            lblForm = new Label();
            tboxCampeonato = new TextBox();
            lblPtos2 = new Label();
            SuspendLayout();
            // 
            // tboxPuntuacion
            // 
            tboxPuntuacion.BackColor = Color.White;
            tboxPuntuacion.BorderStyle = BorderStyle.FixedSingle;
            tboxPuntuacion.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            tboxPuntuacion.ForeColor = Color.Black;
            tboxPuntuacion.Location = new Point(320, 120);
            tboxPuntuacion.Name = "tboxPuntuacion";
            tboxPuntuacion.Size = new Size(307, 27);
            tboxPuntuacion.TabIndex = 2;
            tboxPuntuacion.KeyDown += All_tbox_KeyDown;
            tboxPuntuacion.KeyPress += TboxPuntuacion_KeyPress;
            // 
            // lblPtos1
            // 
            lblPtos1.AutoSize = true;
            lblPtos1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblPtos1.ForeColor = Color.White;
            lblPtos1.Location = new Point(320, 84);
            lblPtos1.Name = "lblPtos1";
            lblPtos1.Size = new Size(80, 17);
            lblPtos1.TabIndex = 3;
            lblPtos1.Text = "Puntuación:";
            // 
            // lblCto
            // 
            lblCto.AutoSize = true;
            lblCto.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblCto.ForeColor = Color.Lime;
            lblCto.Location = new Point(30, 101);
            lblCto.Name = "lblCto";
            lblCto.Size = new Size(140, 17);
            lblCto.TabIndex = 4;
            lblCto.Text = "Nombre Campeonato";
            // 
            // botonCancel
            // 
            botonCancel.BackColor = Color.FromArgb(53, 53, 53);
            botonCancel.BackgroundImageLayout = ImageLayout.Zoom;
            botonCancel.Cursor = Cursors.Hand;
            botonCancel.FlatStyle = FlatStyle.Flat;
            botonCancel.ForeColor = Color.Transparent;
            botonCancel.Location = new Point(592, 165);
            botonCancel.Name = "botonCancel";
            botonCancel.Size = new Size(35, 35);
            botonCancel.TabIndex = 8;
            botonCancel.TabStop = false;
            botonCancel.UseVisualStyleBackColor = false;
            botonCancel.Click += BotonCancel_Click;
            // 
            // botonSave
            // 
            botonSave.BackColor = Color.FromArgb(53, 53, 53);
            botonSave.BackgroundImageLayout = ImageLayout.None;
            botonSave.Cursor = Cursors.Hand;
            botonSave.Enabled = false;
            botonSave.FlatStyle = FlatStyle.Flat;
            botonSave.ForeColor = Color.Transparent;
            botonSave.Location = new Point(551, 165);
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
            lblForm.Font = new Font("Segoe UI Black", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblForm.ForeColor = Color.FromArgb(255, 128, 0);
            lblForm.Location = new Point(30, 39);
            lblForm.Name = "lblForm";
            lblForm.Size = new Size(2, 30);
            lblForm.TabIndex = 9;
            // 
            // tboxCampeonato
            // 
            tboxCampeonato.BackColor = Color.White;
            tboxCampeonato.BorderStyle = BorderStyle.FixedSingle;
            tboxCampeonato.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            tboxCampeonato.ForeColor = Color.Black;
            tboxCampeonato.Location = new Point(30, 120);
            tboxCampeonato.Name = "tboxCampeonato";
            tboxCampeonato.Size = new Size(284, 27);
            tboxCampeonato.TabIndex = 1;
            tboxCampeonato.TextChanged += TboxCampeonato_TextChanged;
            tboxCampeonato.KeyDown += All_tbox_KeyDown;
            // 
            // lblPtos2
            // 
            lblPtos2.AutoSize = true;
            lblPtos2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblPtos2.ForeColor = Color.White;
            lblPtos2.Location = new Point(320, 102);
            lblPtos2.Name = "lblPtos2";
            lblPtos2.Size = new Size(276, 17);
            lblPtos2.TabIndex = 11;
            lblPtos2.Text = "ptos1º, ptos2º, ptos3º,...[ptos PS:1º, 2º, 3º, ...]";
            // 
            // FormCampeonato
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(53, 53, 53);
            ClientSize = new Size(664, 234);
            ControlBox = false;
            Controls.Add(lblPtos2);
            Controls.Add(tboxCampeonato);
            Controls.Add(lblForm);
            Controls.Add(botonCancel);
            Controls.Add(botonSave);
            Controls.Add(tboxPuntuacion);
            Controls.Add(lblPtos1);
            Controls.Add(lblCto);
            ForeColor = SystemColors.WindowText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormCampeonato";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tboxPuntuacion;
        private Label lblPtos1;
        private Label lblCto;
        private Button botonCancel;
        private Button botonSave;
        private Label lblForm;
        private TextBox tboxCampeonato;
        private Label lblPtos2;
    }
}