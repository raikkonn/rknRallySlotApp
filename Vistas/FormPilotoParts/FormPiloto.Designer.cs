namespace rknRallySlotApp.Vistas
{
    partial class FormPiloto
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
            botonCancel = new Button();
            botonSave = new Button();
            lblForm = new Label();
            tboxEscuderia = new TextBox();
            label12 = new Label();
            tboxAlias = new TextBox();
            label9 = new Label();
            label11 = new Label();
            tboxPiloto = new TextBox();
            SuspendLayout();
            // 
            // botonCancel
            // 
            botonCancel.BackColor = Color.FromArgb(53, 53, 53);
            botonCancel.BackgroundImageLayout = ImageLayout.Zoom;
            botonCancel.Cursor = Cursors.Hand;
            botonCancel.FlatStyle = FlatStyle.Flat;
            botonCancel.ForeColor = Color.Transparent;
            botonCancel.Location = new Point(583, 155);
            botonCancel.Name = "botonCancel";
            botonCancel.Size = new Size(35, 35);
            botonCancel.TabIndex = 0;
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
            botonSave.Location = new Point(542, 155);
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
            lblForm.Location = new Point(36, 43);
            lblForm.Name = "lblForm";
            lblForm.Size = new Size(2, 30);
            lblForm.TabIndex = 9;
            // 
            // tboxEscuderia
            // 
            tboxEscuderia.BackColor = Color.White;
            tboxEscuderia.BorderStyle = BorderStyle.FixedSingle;
            tboxEscuderia.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            tboxEscuderia.ForeColor = Color.Black;
            tboxEscuderia.Location = new Point(392, 114);
            tboxEscuderia.Name = "tboxEscuderia";
            tboxEscuderia.Size = new Size(226, 27);
            tboxEscuderia.TabIndex = 3;
            tboxEscuderia.KeyDown += All_tbox_KeyDown;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label12.ForeColor = Color.White;
            label12.Location = new Point(392, 96);
            label12.Name = "label12";
            label12.Size = new Size(105, 17);
            label12.TabIndex = 0;
            label12.Text = "Club / Escudería";
            // 
            // tboxAlias
            // 
            tboxAlias.BackColor = Color.White;
            tboxAlias.BorderStyle = BorderStyle.FixedSingle;
            tboxAlias.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            tboxAlias.ForeColor = Color.Black;
            tboxAlias.Location = new Point(325, 114);
            tboxAlias.Name = "tboxAlias";
            tboxAlias.Size = new Size(61, 27);
            tboxAlias.TabIndex = 2;
            tboxAlias.TextChanged += TboxAlias_TextChanged;
            tboxAlias.KeyDown += All_tbox_KeyDown;
            tboxAlias.Leave += TboxAlias_Leave;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label9.ForeColor = Color.Lime;
            label9.Location = new Point(325, 96);
            label9.Name = "label9";
            label9.Size = new Size(36, 17);
            label9.TabIndex = 0;
            label9.Text = "Alias";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label11.ForeColor = Color.Lime;
            label11.Location = new Point(36, 96);
            label11.Name = "label11";
            label11.Size = new Size(43, 17);
            label11.TabIndex = 0;
            label11.Text = "Piloto";
            // 
            // tboxPiloto
            // 
            tboxPiloto.BackColor = Color.White;
            tboxPiloto.BorderStyle = BorderStyle.FixedSingle;
            tboxPiloto.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            tboxPiloto.ForeColor = Color.Black;
            tboxPiloto.Location = new Point(36, 114);
            tboxPiloto.Name = "tboxPiloto";
            tboxPiloto.Size = new Size(283, 27);
            tboxPiloto.TabIndex = 1;
            tboxPiloto.TextChanged += TboxPiloto_TextChanged;
            tboxPiloto.KeyDown += All_tbox_KeyDown;
            tboxPiloto.Leave += TboxPiloto_Leave;
            // 
            // FormPiloto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(53, 53, 53);
            ClientSize = new Size(664, 234);
            ControlBox = false;
            Controls.Add(tboxPiloto);
            Controls.Add(tboxEscuderia);
            Controls.Add(label12);
            Controls.Add(tboxAlias);
            Controls.Add(label9);
            Controls.Add(label11);
            Controls.Add(lblForm);
            Controls.Add(botonCancel);
            Controls.Add(botonSave);
            ForeColor = SystemColors.WindowText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormPiloto";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button botonCancel;
        private Button botonSave;
        private Label lblForm;
        private TextBox tboxEscuderia;
        private Label label12;
        private TextBox tboxAlias;
        private Label label9;
        private Label label11;
        private TextBox tboxPiloto;
    }
}