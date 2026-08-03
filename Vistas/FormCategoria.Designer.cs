namespace rknRallySlotApp.Vistas
{
    partial class FormCategoria
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
            colorDialogCategoria = new ColorDialog();
            botonColorCategoria = new Button();
            tboxCategoria = new TextBox();
            SuspendLayout();
            // 
            // botonCancel
            // 
            botonCancel.BackColor = Color.FromArgb(52, 73, 94);
            botonCancel.BackgroundImageLayout = ImageLayout.Zoom;
            botonCancel.Cursor = Cursors.Hand;
            botonCancel.FlatStyle = FlatStyle.Flat;
            botonCancel.ForeColor = Color.Transparent;
            botonCancel.Location = new Point(157, 87);
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
            botonSave.Location = new Point(116, 87);
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
            lblForm.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            lblForm.ForeColor = Color.FromArgb(255, 128, 0);
            lblForm.Location = new Point(8, 11);
            lblForm.Name = "lblForm";
            lblForm.Size = new Size(2, 23);
            lblForm.TabIndex = 10;
            // 
            // colorDialogCategoria
            // 
            colorDialogCategoria.AnyColor = true;
            colorDialogCategoria.Color = Color.White;
            // 
            // botonColorCategoria
            // 
            botonColorCategoria.BackColor = Color.FromArgb(52, 73, 94);
            botonColorCategoria.BackgroundImageLayout = ImageLayout.Zoom;
            botonColorCategoria.Cursor = Cursors.Hand;
            botonColorCategoria.FlatStyle = FlatStyle.Flat;
            botonColorCategoria.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            botonColorCategoria.ForeColor = Color.Lime;
            botonColorCategoria.Location = new Point(8, 87);
            botonColorCategoria.Name = "botonColorCategoria";
            botonColorCategoria.Size = new Size(93, 35);
            botonColorCategoria.TabIndex = 12;
            botonColorCategoria.TabStop = false;
            botonColorCategoria.Text = "Color";
            botonColorCategoria.UseVisualStyleBackColor = false;
            botonColorCategoria.Click += BotonColorCategoria_Click;
            // 
            // tboxCategoria
            // 
            tboxCategoria.BackColor = Color.White;
            tboxCategoria.BorderStyle = BorderStyle.FixedSingle;
            tboxCategoria.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            tboxCategoria.ForeColor = Color.Black;
            tboxCategoria.Location = new Point(8, 44);
            tboxCategoria.Name = "tboxCategoria";
            tboxCategoria.Size = new Size(184, 27);
            tboxCategoria.TabIndex = 13;
            tboxCategoria.TextChanged += TboxCategoria_TextChanged;
            tboxCategoria.KeyDown += All_tbox_KeyDown;
            tboxCategoria.Leave += TboxCategoria_Leave;
            // 
            // FormCategoria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(52, 73, 94);
            ClientSize = new Size(200, 136);
            ControlBox = false;
            Controls.Add(tboxCategoria);
            Controls.Add(botonColorCategoria);
            Controls.Add(lblForm);
            Controls.Add(botonCancel);
            Controls.Add(botonSave);
            ForeColor = SystemColors.WindowText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Location = new Point(701, 3);
            Name = "FormCategoria";
            StartPosition = FormStartPosition.Manual;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button botonCancel;
        private Button botonSave;
        private Label lblForm;
        private ColorDialog colorDialogCategoria;
        private Button botonColorCategoria;
        private TextBox tboxCategoria;
    }
}

