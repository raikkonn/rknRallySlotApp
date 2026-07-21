namespace rknRallySlotApp.Vistas
{
    partial class FormCto
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
            tboxPuntos = new TextBox();
            lblPtos1 = new Label();
            lblCto = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            lblFrmCto = new Label();
            tboxCto = new TextBox();
            lblPtos2 = new Label();
            SuspendLayout();
            // 
            // tboxPuntos
            // 
            tboxPuntos.BackColor = Color.White;
            tboxPuntos.BorderStyle = BorderStyle.FixedSingle;
            tboxPuntos.ForeColor = Color.Black;
            tboxPuntos.Location = new Point(284, 110);
            tboxPuntos.Name = "tboxPuntos";
            tboxPuntos.Size = new Size(260, 23);
            tboxPuntos.TabIndex = 2;
            tboxPuntos.KeyDown += TboxCto_KeyDown;
            // 
            // lblPtos1
            // 
            lblPtos1.AutoSize = true;
            lblPtos1.ForeColor = Color.White;
            lblPtos1.Location = new Point(284, 74);
            lblPtos1.Name = "lblPtos1";
            lblPtos1.Size = new Size(71, 15);
            lblPtos1.TabIndex = 3;
            lblPtos1.Text = "Puntuación:";
            // 
            // lblCto
            // 
            lblCto.AutoSize = true;
            lblCto.ForeColor = Color.White;
            lblCto.Location = new Point(18, 91);
            lblCto.Name = "lblCto";
            lblCto.Size = new Size(123, 15);
            lblCto.TabIndex = 4;
            lblCto.Text = "Nombre Campeonato";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(52, 73, 94);
            btnCancel.BackgroundImageLayout = ImageLayout.Zoom;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.Transparent;
            btnCancel.Location = new Point(509, 150);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(35, 35);
            btnCancel.TabIndex = 8;
            btnCancel.TabStop = false;
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(52, 73, 94);
            btnSave.BackgroundImageLayout = ImageLayout.None;
            btnSave.Cursor = Cursors.Hand;
            btnSave.Enabled = false;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.Transparent;
            btnSave.Location = new Point(468, 150);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(35, 35);
            btnSave.TabIndex = 6;
            btnSave.TabStop = false;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // lblFrmCto
            // 
            lblFrmCto.AutoSize = true;
            lblFrmCto.BorderStyle = BorderStyle.FixedSingle;
            lblFrmCto.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFrmCto.ForeColor = Color.White;
            lblFrmCto.Location = new Point(18, 29);
            lblFrmCto.Name = "lblFrmCto";
            lblFrmCto.Size = new Size(186, 27);
            lblFrmCto.TabIndex = 9;
            lblFrmCto.Text = "Alta de Campeonato";
            // 
            // tboxCto
            // 
            tboxCto.BackColor = Color.White;
            tboxCto.BorderStyle = BorderStyle.FixedSingle;
            tboxCto.ForeColor = Color.Black;
            tboxCto.Location = new Point(18, 110);
            tboxCto.Name = "tboxCto";
            tboxCto.Size = new Size(260, 23);
            tboxCto.TabIndex = 1;
            tboxCto.TextChanged += TboxCto_TextChanged;
            tboxCto.KeyDown += TboxCto_KeyDown;
            // 
            // lblPtos2
            // 
            lblPtos2.AutoSize = true;
            lblPtos2.ForeColor = Color.White;
            lblPtos2.Location = new Point(284, 92);
            lblPtos2.Name = "lblPtos2";
            lblPtos2.Size = new Size(243, 15);
            lblPtos2.TabIndex = 11;
            lblPtos2.Text = "ptos1º, ptos2º, ptos3º,...[ptos PS:1º, 2º, 3º, ...]";
            // 
            // FormCto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 62, 80);
            ClientSize = new Size(569, 211);
            ControlBox = false;
            Controls.Add(lblPtos2);
            Controls.Add(tboxCto);
            Controls.Add(lblFrmCto);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(tboxPuntos);
            Controls.Add(lblPtos1);
            Controls.Add(lblCto);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormCto";
            StartPosition = FormStartPosition.CenterParent;
            Load += FormCto_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tboxPuntos;
        private Label lblPtos1;
        private Label lblCto;
        private Button btnCancel;
        private Button btnSave;
        private Label lblFrmCto;
        private TextBox tboxCto;
        private Label lblPtos2;
    }
}