namespace rknRallySlotApp.Vistas
{
    partial class FormCoche
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
            tboxMarca = new TextBox();
            label8 = new Label();
            label10 = new Label();
            tboxModelo = new TextBox();
            SuspendLayout();
            // 
            // botonCancel
            // 
            botonCancel.BackColor = Color.FromArgb(52, 73, 94);
            botonCancel.BackgroundImageLayout = ImageLayout.Zoom;
            botonCancel.Cursor = Cursors.Hand;
            botonCancel.FlatStyle = FlatStyle.Flat;
            botonCancel.ForeColor = Color.Transparent;
            botonCancel.Location = new Point(549, 155);
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
            botonSave.Location = new Point(508, 155);
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
            lblForm.Location = new Point(58, 42);
            lblForm.Name = "lblForm";
            lblForm.Size = new Size(2, 30);
            lblForm.TabIndex = 9;
            // 
            // tboxMarca
            // 
            tboxMarca.BackColor = Color.White;
            tboxMarca.BorderStyle = BorderStyle.FixedSingle;
            tboxMarca.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            tboxMarca.ForeColor = SystemColors.WindowText;
            tboxMarca.Location = new Point(409, 110);
            tboxMarca.Name = "tboxMarca";
            tboxMarca.Size = new Size(175, 27);
            tboxMarca.TabIndex = 2;
            tboxMarca.KeyDown += All_tbox_KeyDown;
            tboxMarca.Leave += TboxMarca_Leave;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(409, 92);
            label8.Name = "label8";
            label8.Size = new Size(45, 17);
            label8.TabIndex = 11;
            label8.Text = "Marca";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label10.ForeColor = Color.Lime;
            label10.Location = new Point(58, 92);
            label10.Name = "label10";
            label10.Size = new Size(54, 17);
            label10.TabIndex = 12;
            label10.Text = "Modelo";
            // 
            // tboxModelo
            // 
            tboxModelo.BackColor = Color.White;
            tboxModelo.BorderStyle = BorderStyle.FixedSingle;
            tboxModelo.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            tboxModelo.ForeColor = SystemColors.WindowText;
            tboxModelo.Location = new Point(58, 110);
            tboxModelo.Name = "tboxModelo";
            tboxModelo.Size = new Size(345, 27);
            tboxModelo.TabIndex = 1;
            tboxModelo.TextChanged += TboxCoche_TextChanged;
            tboxModelo.KeyDown += All_tbox_KeyDown;
            tboxModelo.Leave += TboxModelo_Leave;
            // 
            // FormCoche
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(52, 73, 94);
            ClientSize = new Size(664, 234);
            ControlBox = false;
            Controls.Add(tboxModelo);
            Controls.Add(tboxMarca);
            Controls.Add(label8);
            Controls.Add(label10);
            Controls.Add(lblForm);
            Controls.Add(botonCancel);
            Controls.Add(botonSave);
            ForeColor = SystemColors.WindowText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormCoche";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button botonCancel;
        private Button botonSave;
        private Label lblForm;
        private TextBox tboxMarca;
        private Label label8;
        private Label label10;
        private TextBox tboxModelo;
    }
}