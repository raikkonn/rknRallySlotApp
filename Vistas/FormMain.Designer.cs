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
            DataGridInscripcion = new DataGridView();
            menuMain = new MenuStrip();
            gestionDeDatosToolStripMenuItem = new ToolStripMenuItem();
            campeonatosToolStripMenuItem = new ToolStripMenuItem();
            pruebasToolStripMenuItem = new ToolStripMenuItem();
            pilotosToolStripMenuItem = new ToolStripMenuItem();
            cochesToolStripMenuItem = new ToolStripMenuItem();
            inscripcionesToolStripMenuItem = new ToolStripMenuItem();
            statusStripMain = new StatusStrip();
            labelStatus = new ToolStripStatusLabel();
            comboCampeonatos = new ComboBox();
            lblCto = new Label();
            botonNuevoCampeonato = new Button();
            label1 = new Label();
            tboxPuntuaciones = new TextBox();
            botonEditaCampeonato = new Button();
            botonBorraCampeonato = new Button();
            comboPruebas = new ComboBox();
            label2 = new Label();
            botonNuevaPrueba = new Button();
            botonEditaPrueba = new Button();
            botonBorraPrueba = new Button();
            label3 = new Label();
            tboxEtapas = new TextBox();
            label4 = new Label();
            tboxTramos = new TextBox();
            label5 = new Label();
            tboxTmax = new TextBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)DataGridInscripcion).BeginInit();
            menuMain.SuspendLayout();
            statusStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // datagridPrueba
            // 
            DataGridInscripcion.AllowUserToAddRows = false;
            DataGridInscripcion.AllowUserToDeleteRows = false;
            DataGridInscripcion.AllowUserToOrderColumns = true;
            DataGridInscripcion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridInscripcion.BackgroundColor = Color.FromArgb(52, 73, 94);
            DataGridInscripcion.CellBorderStyle = DataGridViewCellBorderStyle.None;
            DataGridInscripcion.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DataGridInscripcion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridInscripcion.Location = new Point(0, 154);
            DataGridInscripcion.Name = "datagridPrueba";
            DataGridInscripcion.ReadOnly = true;
            DataGridInscripcion.Size = new Size(1264, 502);
            DataGridInscripcion.TabIndex = 0;
            DataGridInscripcion.TabStop = false;
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
            statusStripMain.Items.AddRange(new ToolStripItem[] { labelStatus });
            statusStripMain.Location = new Point(0, 659);
            statusStripMain.Name = "statusStripMain";
            statusStripMain.Size = new Size(1264, 22);
            statusStripMain.SizingGrip = false;
            statusStripMain.TabIndex = 0;
            // 
            // labelStatusMain
            // 
            labelStatus.BackColor = Color.Transparent;
            labelStatus.DisplayStyle = ToolStripItemDisplayStyle.Text;
            labelStatus.ForeColor = Color.FromArgb(192, 0, 0);
            labelStatus.Name = "labelStatusMain";
            labelStatus.Size = new Size(0, 17);
            // 
            // comboCampeonatos
            // 
            comboCampeonatos.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboCampeonatos.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCampeonatos.FormattingEnabled = true;
            comboCampeonatos.Location = new Point(6, 51);
            comboCampeonatos.MaxLength = 50;
            comboCampeonatos.Name = "comboCampeonatos";
            comboCampeonatos.Size = new Size(260, 23);
            comboCampeonatos.TabIndex = 1;
            comboCampeonatos.SelectedIndexChanged += ComboCampeonatos_SelectedIndexChanged;
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
            // botonNuevoCampeonato
            // 
            botonNuevoCampeonato.BackColor = Color.FromArgb(52, 73, 94);
            botonNuevoCampeonato.BackgroundImageLayout = ImageLayout.Zoom;
            botonNuevoCampeonato.Cursor = Cursors.Hand;
            botonNuevoCampeonato.Enabled = false;
            botonNuevoCampeonato.FlatStyle = FlatStyle.Flat;
            botonNuevoCampeonato.ForeColor = Color.Transparent;
            botonNuevoCampeonato.Location = new Point(549, 44);
            botonNuevoCampeonato.Name = "botonNuevoCampeonato";
            botonNuevoCampeonato.Size = new Size(35, 35);
            botonNuevoCampeonato.TabIndex = 0;
            botonNuevoCampeonato.TabStop = false;
            botonNuevoCampeonato.UseVisualStyleBackColor = false;
            botonNuevoCampeonato.Click += BotonNuevoCampeonato_Click;
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
            tboxPuntuaciones.BackColor = Color.FromArgb(52, 73, 94);
            tboxPuntuaciones.BorderStyle = BorderStyle.FixedSingle;
            tboxPuntuaciones.ForeColor = Color.White;
            tboxPuntuaciones.Location = new Point(272, 52);
            tboxPuntuaciones.Name = "tboxPuntos";
            tboxPuntuaciones.ReadOnly = true;
            tboxPuntuaciones.Size = new Size(260, 23);
            tboxPuntuaciones.TabIndex = 0;
            tboxPuntuaciones.TabStop = false;
            // 
            // botonEditaCampeonato
            // 
            botonEditaCampeonato.BackColor = Color.FromArgb(52, 73, 94);
            botonEditaCampeonato.BackgroundImageLayout = ImageLayout.None;
            botonEditaCampeonato.Cursor = Cursors.Hand;
            botonEditaCampeonato.Enabled = false;
            botonEditaCampeonato.FlatStyle = FlatStyle.Flat;
            botonEditaCampeonato.ForeColor = Color.Transparent;
            botonEditaCampeonato.Location = new Point(590, 44);
            botonEditaCampeonato.Name = "botonEditaCampeonato";
            botonEditaCampeonato.Size = new Size(35, 35);
            botonEditaCampeonato.TabIndex = 0;
            botonEditaCampeonato.TabStop = false;
            botonEditaCampeonato.UseVisualStyleBackColor = false;
            botonEditaCampeonato.Click += BotonEditaCampeonato_Click;
            // 
            // botonBorraCampeonato
            // 
            botonBorraCampeonato.BackColor = Color.FromArgb(52, 73, 94);
            botonBorraCampeonato.BackgroundImageLayout = ImageLayout.Zoom;
            botonBorraCampeonato.Cursor = Cursors.Hand;
            botonBorraCampeonato.Enabled = false;
            botonBorraCampeonato.FlatStyle = FlatStyle.Flat;
            botonBorraCampeonato.ForeColor = Color.Transparent;
            botonBorraCampeonato.Location = new Point(631, 44);
            botonBorraCampeonato.Name = "botonBorraCampeonato";
            botonBorraCampeonato.Size = new Size(35, 35);
            botonBorraCampeonato.TabIndex = 3;
            botonBorraCampeonato.UseVisualStyleBackColor = false;
            botonBorraCampeonato.Click += BotonBorraCampeonato_Click;
            // 
            // cboxPrueba
            // 
            comboPruebas.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboPruebas.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPruebas.Enabled = false;
            comboPruebas.FormattingEnabled = true;
            comboPruebas.Location = new Point(6, 98);
            comboPruebas.MaxLength = 50;
            comboPruebas.Name = "cboxPrueba";
            comboPruebas.Size = new Size(260, 23);
            comboPruebas.TabIndex = 2;
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
            // botonNuevaPrueba
            // 
            botonNuevaPrueba.BackColor = Color.FromArgb(52, 73, 94);
            botonNuevaPrueba.BackgroundImageLayout = ImageLayout.Zoom;
            botonNuevaPrueba.Cursor = Cursors.Hand;
            botonNuevaPrueba.Enabled = false;
            botonNuevaPrueba.FlatStyle = FlatStyle.Flat;
            botonNuevaPrueba.ForeColor = Color.Transparent;
            botonNuevaPrueba.Location = new Point(414, 91);
            botonNuevaPrueba.Name = "botonNuevaPrueba";
            botonNuevaPrueba.Size = new Size(35, 35);
            botonNuevaPrueba.TabIndex = 3;
            botonNuevaPrueba.UseVisualStyleBackColor = false;
            // 
            // botonEditaPrueba
            // 
            botonEditaPrueba.BackColor = Color.FromArgb(52, 73, 94);
            botonEditaPrueba.BackgroundImageLayout = ImageLayout.Zoom;
            botonEditaPrueba.Cursor = Cursors.Hand;
            botonEditaPrueba.Enabled = false;
            botonEditaPrueba.FlatStyle = FlatStyle.Flat;
            botonEditaPrueba.ForeColor = Color.Transparent;
            botonEditaPrueba.Location = new Point(455, 91);
            botonEditaPrueba.Name = "botonEditaPrueba";
            botonEditaPrueba.Size = new Size(35, 35);
            botonEditaPrueba.TabIndex = 3;
            botonEditaPrueba.UseVisualStyleBackColor = false;
            // 
            // botonBorraPrueba
            // 
            botonBorraPrueba.BackColor = Color.FromArgb(52, 73, 94);
            botonBorraPrueba.BackgroundImageLayout = ImageLayout.Zoom;
            botonBorraPrueba.Cursor = Cursors.Hand;
            botonBorraPrueba.Enabled = false;
            botonBorraPrueba.FlatStyle = FlatStyle.Flat;
            botonBorraPrueba.ForeColor = Color.Transparent;
            botonBorraPrueba.Location = new Point(496, 91);
            botonBorraPrueba.Name = "botonBorraPrueba";
            botonBorraPrueba.Size = new Size(35, 35);
            botonBorraPrueba.TabIndex = 3;
            botonBorraPrueba.UseVisualStyleBackColor = false;
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
            Controls.Add(tboxPuntuaciones);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(botonBorraPrueba);
            Controls.Add(botonBorraCampeonato);
            Controls.Add(botonEditaPrueba);
            Controls.Add(botonEditaCampeonato);
            Controls.Add(botonNuevaPrueba);
            Controls.Add(botonNuevoCampeonato);
            Controls.Add(label2);
            Controls.Add(lblCto);
            Controls.Add(comboPruebas);
            Controls.Add(comboCampeonatos);
            Controls.Add(statusStripMain);
            Controls.Add(DataGridInscripcion);
            Controls.Add(menuMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuMain;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "rkN RallySlot";
            ((System.ComponentModel.ISupportInitialize)DataGridInscripcion).EndInit();
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
        private DataGridView DataGridInscripcion;
        private MenuStrip menuMain;
        private ToolStripMenuItem gestionDeDatosToolStripMenuItem;
        private ToolStripMenuItem campeonatosToolStripMenuItem;
        private ToolStripMenuItem pruebasToolStripMenuItem;
        private ToolStripMenuItem pilotosToolStripMenuItem;
        private ToolStripMenuItem cochesToolStripMenuItem;
        private ToolStripMenuItem inscripcionesToolStripMenuItem;
        private StatusStrip statusStripMain;
        private ToolStripStatusLabel labelStatus;
        private ComboBox comboCampeonatos;
        private Label lblCto;
        private Button botonNuevoCampeonato;
        private Label label1;
        private TextBox tboxPuntuaciones;
        private Button botonEditaCampeonato;
        private Button botonBorraCampeonato;
        private ComboBox comboPruebas;
        private Label label2;
        private Button botonNuevaPrueba;
        private Button botonEditaPrueba;
        private Button botonBorraPrueba;
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