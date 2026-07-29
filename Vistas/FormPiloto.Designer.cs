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
            botonCancel.BackColor = Color.FromArgb(52, 73, 94);
            botonCancel.BackgroundImageLayout = ImageLayout.Zoom;
            botonCancel.Cursor = Cursors.Hand;
            botonCancel.FlatStyle = FlatStyle.Flat;
            botonCancel.ForeColor = Color.Transparent;
            botonCancel.Location = new Point(509, 142);
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
            botonSave.Location = new Point(468, 142);
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
            lblForm.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblForm.ForeColor = Color.White;
            lblForm.Location = new Point(18, 29);
            lblForm.Name = "lblForm";
            lblForm.Size = new Size(2, 27);
            lblForm.TabIndex = 9;
            // 
            // tboxEscuderia
            // 
            tboxEscuderia.BackColor = Color.White;
            tboxEscuderia.BorderStyle = BorderStyle.FixedSingle;
            tboxEscuderia.ForeColor = Color.Black;
            tboxEscuderia.Location = new Point(331, 101);
            tboxEscuderia.Name = "tboxEscuderia";
            tboxEscuderia.Size = new Size(213, 23);
            tboxEscuderia.TabIndex = 3;
            tboxEscuderia.KeyDown += All_tbox_KeyDown;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.ForeColor = Color.White;
            label12.Location = new Point(331, 83);
            label12.Name = "label12";
            label12.Size = new Size(93, 15);
            label12.TabIndex = 0;
            label12.Text = "Club / Escudería";
            // 
            // tboxAlias
            // 
            tboxAlias.BackColor = Color.White;
            tboxAlias.BorderStyle = BorderStyle.FixedSingle;
            tboxAlias.ForeColor = Color.Black;
            tboxAlias.Location = new Point(285, 101);
            tboxAlias.Name = "tboxAlias";
            tboxAlias.Size = new Size(41, 23);
            tboxAlias.TabIndex = 2;
            tboxAlias.TextChanged += TboxAlias_TextChanged;
            tboxAlias.KeyDown += All_tbox_KeyDown;
            tboxAlias.Leave += TboxAlias_Leave;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.White;
            label9.Location = new Point(285, 83);
            label9.Name = "label9";
            label9.Size = new Size(32, 15);
            label9.TabIndex = 0;
            label9.Text = "Alias";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = Color.White;
            label11.Location = new Point(19, 83);
            label11.Name = "label11";
            label11.Size = new Size(38, 15);
            label11.TabIndex = 0;
            label11.Text = "Piloto";
            // 
            // tboxPiloto
            // 
            tboxPiloto.BackColor = Color.White;
            tboxPiloto.BorderStyle = BorderStyle.FixedSingle;
            tboxPiloto.ForeColor = Color.Black;
            tboxPiloto.Location = new Point(19, 101);
            tboxPiloto.Name = "tboxPiloto";
            tboxPiloto.Size = new Size(260, 23);
            tboxPiloto.TabIndex = 1;
            tboxPiloto.TextChanged += TboxPiloto_TextChanged;
            tboxPiloto.KeyDown += All_tbox_KeyDown;
            tboxPiloto.Leave += TboxPiloto_Leave;
            // 
            // FormPiloto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 62, 80);
            ClientSize = new Size(569, 199);
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