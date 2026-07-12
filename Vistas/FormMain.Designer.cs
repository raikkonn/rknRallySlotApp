namespace rknRallySlotApp.Vistas
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            dgvCtoPrueba = new DataGridView();
            menuMain = new MenuStrip();
            gestionDeDatosToolStripMenuItem = new ToolStripMenuItem();
            campeonatosToolStripMenuItem = new ToolStripMenuItem();
            pruebasToolStripMenuItem = new ToolStripMenuItem();
            pilotosToolStripMenuItem = new ToolStripMenuItem();
            cochesToolStripMenuItem = new ToolStripMenuItem();
            inscripcionesToolStripMenuItem = new ToolStripMenuItem();
            statusStripMain = new StatusStrip();
            lblStatusMain = new ToolStripStatusLabel();
            cboxCto = new ComboBox();
            lblCto = new Label();
            btnNewCto = new Button();
            label1 = new Label();
            tboxPuntos = new TextBox();
            btnEditCto = new Button();
            btnDelCto = new Button();
            cboxPrueba = new ComboBox();
            label2 = new Label();
            btnNewPrueba = new Button();
            btnEditPrueba = new Button();
            btnDelPrueba = new Button();
            label3 = new Label();
            tboxEtapas = new TextBox();
            label4 = new Label();
            tboxTramos = new TextBox();
            label5 = new Label();
            tboxTmax = new TextBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvCtoPrueba).BeginInit();
            menuMain.SuspendLayout();
            statusStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // dgvCtoPrueba
            // 
            dgvCtoPrueba.AllowUserToAddRows = false;
            dgvCtoPrueba.AllowUserToDeleteRows = false;
            dgvCtoPrueba.AllowUserToOrderColumns = true;
            dgvCtoPrueba.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCtoPrueba.BackgroundColor = Color.FromArgb(52, 73, 94);
            dgvCtoPrueba.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvCtoPrueba.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCtoPrueba.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCtoPrueba.Location = new Point(0, 154);
            dgvCtoPrueba.Name = "dgvCtoPrueba";
            dgvCtoPrueba.ReadOnly = true;
            dgvCtoPrueba.Size = new Size(1264, 502);
            dgvCtoPrueba.TabIndex = 0;
            dgvCtoPrueba.TabStop = false;
            // 
            // menuMain
            // 
            menuMain.Items.AddRange(new ToolStripItem[] { gestionDeDatosToolStripMenuItem });
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Padding = new Padding(0);
            menuMain.RenderMode = ToolStripRenderMode.Professional;
            menuMain.Size = new Size(1264, 24);
            menuMain.TabIndex = 2;
            menuMain.Text = "menuStrip1";
            // 
            // gestionDeDatosToolStripMenuItem
            // 
            gestionDeDatosToolStripMenuItem.AutoToolTip = true;
            gestionDeDatosToolStripMenuItem.BackColor = Color.Transparent;
            gestionDeDatosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { campeonatosToolStripMenuItem, pruebasToolStripMenuItem, pilotosToolStripMenuItem, cochesToolStripMenuItem, inscripcionesToolStripMenuItem });
            gestionDeDatosToolStripMenuItem.ForeColor = Color.Black;
            gestionDeDatosToolStripMenuItem.Name = "gestionDeDatosToolStripMenuItem";
            gestionDeDatosToolStripMenuItem.Padding = new Padding(0);
            gestionDeDatosToolStripMenuItem.Size = new Size(100, 24);
            gestionDeDatosToolStripMenuItem.Text = "Gestion de Datos";
            // 
            // campeonatosToolStripMenuItem
            // 
            campeonatosToolStripMenuItem.Name = "campeonatosToolStripMenuItem";
            campeonatosToolStripMenuItem.Size = new Size(148, 22);
            campeonatosToolStripMenuItem.Text = "Campeonatos";
            // 
            // pruebasToolStripMenuItem
            // 
            pruebasToolStripMenuItem.Name = "pruebasToolStripMenuItem";
            pruebasToolStripMenuItem.Size = new Size(148, 22);
            pruebasToolStripMenuItem.Text = "Pruebas";
            // 
            // pilotosToolStripMenuItem
            // 
            pilotosToolStripMenuItem.Name = "pilotosToolStripMenuItem";
            pilotosToolStripMenuItem.Size = new Size(148, 22);
            pilotosToolStripMenuItem.Text = "Pilotos";
            // 
            // cochesToolStripMenuItem
            // 
            cochesToolStripMenuItem.Name = "cochesToolStripMenuItem";
            cochesToolStripMenuItem.Size = new Size(148, 22);
            cochesToolStripMenuItem.Text = "Coches";
            // 
            // inscripcionesToolStripMenuItem
            // 
            inscripcionesToolStripMenuItem.Name = "inscripcionesToolStripMenuItem";
            inscripcionesToolStripMenuItem.Size = new Size(148, 22);
            inscripcionesToolStripMenuItem.Text = "Inscripciones";
            // 
            // statusStripMain
            // 
            statusStripMain.GripMargin = new Padding(0);
            statusStripMain.Items.AddRange(new ToolStripItem[] { lblStatusMain });
            statusStripMain.Location = new Point(0, 659);
            statusStripMain.Name = "statusStripMain";
            statusStripMain.Size = new Size(1264, 22);
            statusStripMain.SizingGrip = false;
            statusStripMain.TabIndex = 0;
            // 
            // lblStatusMain
            // 
            lblStatusMain.BackColor = Color.Transparent;
            lblStatusMain.Name = "lblStatusMain";
            lblStatusMain.Size = new Size(79, 17);
            lblStatusMain.Text = "lblStatusMain";
            // 
            // cboxCto
            // 
            cboxCto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboxCto.DropDownStyle = ComboBoxStyle.DropDownList;
            cboxCto.FormattingEnabled = true;
            cboxCto.Location = new Point(6, 51);
            cboxCto.MaxLength = 50;
            cboxCto.Name = "cboxCto";
            cboxCto.Size = new Size(260, 23);
            cboxCto.TabIndex = 1;
            cboxCto.SelectedIndexChanged += CBoxCto_SelectedIndexChanged;
            // 
            // lblCto
            // 
            lblCto.AutoSize = true;
            lblCto.ForeColor = Color.White;
            lblCto.Location = new Point(6, 33);
            lblCto.Name = "lblCto";
            lblCto.Size = new Size(76, 15);
            lblCto.TabIndex = 0;
            lblCto.Text = "Campeonato";
            // 
            // btnNewCto
            // 
            btnNewCto.BackColor = Color.FromArgb(52, 73, 94);
            btnNewCto.BackgroundImageLayout = ImageLayout.Zoom;
            btnNewCto.Cursor = Cursors.Hand;
            btnNewCto.Enabled = false;
            btnNewCto.FlatStyle = FlatStyle.Flat;
            btnNewCto.ForeColor = Color.Transparent;
            btnNewCto.Location = new Point(549, 44);
            btnNewCto.Name = "btnNewCto";
            btnNewCto.Size = new Size(35, 35);
            btnNewCto.TabIndex = 0;
            btnNewCto.TabStop = false;
            btnNewCto.UseVisualStyleBackColor = false;
            btnNewCto.Click += btnNewCto_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(272, 33);
            label1.Name = "label1";
            label1.Size = new Size(247, 15);
            label1.TabIndex = 0;
            label1.Text = "Puntuación: ptos1º, ptos2º, ptos3º,...[ptos PS]";
            // 
            // tboxPuntos
            // 
            tboxPuntos.BackColor = Color.FromArgb(52, 73, 94);
            tboxPuntos.BorderStyle = BorderStyle.FixedSingle;
            tboxPuntos.ForeColor = Color.White;
            tboxPuntos.Location = new Point(272, 52);
            tboxPuntos.Name = "tboxPuntos";
            tboxPuntos.ReadOnly = true;
            tboxPuntos.Size = new Size(260, 23);
            tboxPuntos.TabIndex = 0;
            tboxPuntos.TabStop = false;
            // 
            // btnEditCto
            // 
            btnEditCto.BackColor = Color.FromArgb(52, 73, 94);
            btnEditCto.BackgroundImageLayout = ImageLayout.None;
            btnEditCto.Cursor = Cursors.Hand;
            btnEditCto.Enabled = false;
            btnEditCto.FlatStyle = FlatStyle.Flat;
            btnEditCto.ForeColor = Color.Transparent;
            btnEditCto.Location = new Point(590, 44);
            btnEditCto.Name = "btnEditCto";
            btnEditCto.Size = new Size(35, 35);
            btnEditCto.TabIndex = 0;
            btnEditCto.TabStop = false;
            btnEditCto.UseVisualStyleBackColor = false;
            // 
            // btnDelCto
            // 
            btnDelCto.BackColor = Color.FromArgb(52, 73, 94);
            btnDelCto.BackgroundImageLayout = ImageLayout.Zoom;
            btnDelCto.Cursor = Cursors.Hand;
            btnDelCto.Enabled = false;
            btnDelCto.FlatStyle = FlatStyle.Flat;
            btnDelCto.ForeColor = Color.Transparent;
            btnDelCto.Location = new Point(631, 44);
            btnDelCto.Name = "btnDelCto";
            btnDelCto.Size = new Size(35, 35);
            btnDelCto.TabIndex = 3;
            btnDelCto.UseVisualStyleBackColor = false;
            // 
            // cboxPrueba
            // 
            cboxPrueba.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboxPrueba.DropDownStyle = ComboBoxStyle.DropDownList;
            cboxPrueba.Enabled = false;
            cboxPrueba.FormattingEnabled = true;
            cboxPrueba.Location = new Point(6, 98);
            cboxPrueba.MaxLength = 50;
            cboxPrueba.Name = "cboxPrueba";
            cboxPrueba.Size = new Size(260, 23);
            cboxPrueba.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(6, 80);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 0;
            label2.Text = "Prueba (Rally)";
            // 
            // btnNewPrueba
            // 
            btnNewPrueba.BackColor = Color.FromArgb(52, 73, 94);
            btnNewPrueba.BackgroundImageLayout = ImageLayout.Zoom;
            btnNewPrueba.Cursor = Cursors.Hand;
            btnNewPrueba.Enabled = false;
            btnNewPrueba.FlatStyle = FlatStyle.Flat;
            btnNewPrueba.ForeColor = Color.Transparent;
            btnNewPrueba.Location = new Point(414, 91);
            btnNewPrueba.Name = "btnNewPrueba";
            btnNewPrueba.Size = new Size(35, 35);
            btnNewPrueba.TabIndex = 3;
            btnNewPrueba.UseVisualStyleBackColor = false;
            // 
            // btnEditPrueba
            // 
            btnEditPrueba.BackColor = Color.FromArgb(52, 73, 94);
            btnEditPrueba.BackgroundImageLayout = ImageLayout.Zoom;
            btnEditPrueba.Cursor = Cursors.Hand;
            btnEditPrueba.Enabled = false;
            btnEditPrueba.FlatStyle = FlatStyle.Flat;
            btnEditPrueba.ForeColor = Color.Transparent;
            btnEditPrueba.Location = new Point(455, 91);
            btnEditPrueba.Name = "btnEditPrueba";
            btnEditPrueba.Size = new Size(35, 35);
            btnEditPrueba.TabIndex = 3;
            btnEditPrueba.UseVisualStyleBackColor = false;
            // 
            // btnDelPrueba
            // 
            btnDelPrueba.BackColor = Color.FromArgb(52, 73, 94);
            btnDelPrueba.BackgroundImageLayout = ImageLayout.Zoom;
            btnDelPrueba.Cursor = Cursors.Hand;
            btnDelPrueba.Enabled = false;
            btnDelPrueba.FlatStyle = FlatStyle.Flat;
            btnDelPrueba.ForeColor = Color.Transparent;
            btnDelPrueba.Location = new Point(496, 91);
            btnDelPrueba.Name = "btnDelPrueba";
            btnDelPrueba.Size = new Size(35, 35);
            btnDelPrueba.TabIndex = 3;
            btnDelPrueba.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(272, 80);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 0;
            label3.Text = "Etapas";
            // 
            // tboxEtapas
            // 
            tboxEtapas.BackColor = Color.FromArgb(52, 73, 94);
            tboxEtapas.BorderStyle = BorderStyle.FixedSingle;
            tboxEtapas.ForeColor = Color.White;
            tboxEtapas.Location = new Point(272, 99);
            tboxEtapas.Name = "tboxEtapas";
            tboxEtapas.ReadOnly = true;
            tboxEtapas.Size = new Size(40, 23);
            tboxEtapas.TabIndex = 0;
            tboxEtapas.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(316, 80);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 0;
            label4.Text = "Tramos";
            // 
            // tboxTramos
            // 
            tboxTramos.BackColor = Color.FromArgb(52, 73, 94);
            tboxTramos.BorderStyle = BorderStyle.FixedSingle;
            tboxTramos.ForeColor = Color.White;
            tboxTramos.Location = new Point(318, 99);
            tboxTramos.Name = "tboxTramos";
            tboxTramos.ReadOnly = true;
            tboxTramos.Size = new Size(40, 23);
            tboxTramos.TabIndex = 0;
            tboxTramos.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(364, 80);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 0;
            label5.Text = "tº max.";
            // 
            // tboxTmax
            // 
            tboxTmax.BackColor = Color.FromArgb(52, 73, 94);
            tboxTmax.BorderStyle = BorderStyle.FixedSingle;
            tboxTmax.ForeColor = Color.White;
            tboxTmax.Location = new Point(364, 99);
            tboxTmax.Name = "tboxTmax";
            tboxTmax.ReadOnly = true;
            tboxTmax.Size = new Size(40, 23);
            tboxTmax.TabIndex = 0;
            tboxTmax.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.avslot_logo;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(925, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(185, 124);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            pictureBox1.WaitOnLoad = true;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.rkn;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(1116, 27);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(148, 124);
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 62, 80);
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1264, 681);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(tboxTmax);
            Controls.Add(tboxTramos);
            Controls.Add(label5);
            Controls.Add(tboxEtapas);
            Controls.Add(label4);
            Controls.Add(tboxPuntos);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(btnDelPrueba);
            Controls.Add(btnDelCto);
            Controls.Add(btnEditPrueba);
            Controls.Add(btnEditCto);
            Controls.Add(btnNewPrueba);
            Controls.Add(btnNewCto);
            Controls.Add(label2);
            Controls.Add(lblCto);
            Controls.Add(cboxPrueba);
            Controls.Add(cboxCto);
            Controls.Add(statusStripMain);
            Controls.Add(dgvCtoPrueba);
            Controls.Add(menuMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuMain;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "rkN RallySlot principal";
            Load += FormMain_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCtoPrueba).EndInit();
            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            statusStripMain.ResumeLayout(false);
            statusStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvCtoPrueba;
        private MenuStrip menuMain;
        private ToolStripMenuItem gestionDeDatosToolStripMenuItem;
        private ToolStripMenuItem campeonatosToolStripMenuItem;
        private ToolStripMenuItem pruebasToolStripMenuItem;
        private ToolStripMenuItem pilotosToolStripMenuItem;
        private ToolStripMenuItem cochesToolStripMenuItem;
        private ToolStripMenuItem inscripcionesToolStripMenuItem;
        private StatusStrip statusStripMain;
        private ToolStripStatusLabel lblStatusMain;
        private ComboBox cboxCto;
        private Label lblCto;
        private Button btnNewCto;
        private Label label1;
        private TextBox tboxPuntos;
        private Button btnEditCto;
        private Button btnDelCto;
        private ComboBox cboxPrueba;
        private Label label2;
        private Button btnNewPrueba;
        private Button btnEditPrueba;
        private Button btnDelPrueba;
        private Label label3;
        private TextBox tboxEtapas;
        private Label label4;
        private TextBox tboxTramos;
        private Label label5;
        private TextBox tboxTmax;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}