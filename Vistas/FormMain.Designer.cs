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
            cBoxCto = new ComboBox();
            lblCto = new Label();
            btnNewCto = new Button();
            label1 = new Label();
            tBoxPuntua = new TextBox();
            btnEditCto = new Button();
            btnDelCto = new Button();
            boxPrueba = new ComboBox();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label3 = new Label();
            tBoxEtapas = new TextBox();
            label4 = new Label();
            tBoxTramos = new TextBox();
            label5 = new Label();
            tBoxTmax = new TextBox();
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
            // cBoxCto
            // 
            cBoxCto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cBoxCto.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxCto.FormattingEnabled = true;
            cBoxCto.Location = new Point(6, 51);
            cBoxCto.MaxLength = 50;
            cBoxCto.Name = "cBoxCto";
            cBoxCto.Size = new Size(260, 23);
            cBoxCto.TabIndex = 1;
            cBoxCto.SelectedIndexChanged += CBoxCto_SelectedIndexChanged;
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
            btnNewCto.BackgroundImage = Properties.Resources.new_w;
            btnNewCto.BackgroundImageLayout = ImageLayout.Zoom;
            btnNewCto.Cursor = Cursors.Hand;
            btnNewCto.Location = new Point(549, 44);
            btnNewCto.Name = "btnNewCto";
            btnNewCto.Size = new Size(35, 35);
            btnNewCto.TabIndex = 3;
            btnNewCto.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(272, 33);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 5;
            label1.Text = "Puntuación";
            // 
            // tBoxPuntua
            // 
            tBoxPuntua.BackColor = Color.FromArgb(52, 73, 94);
            tBoxPuntua.BorderStyle = BorderStyle.FixedSingle;
            tBoxPuntua.ForeColor = Color.White;
            tBoxPuntua.Location = new Point(272, 52);
            tBoxPuntua.Name = "tBoxPuntua";
            tBoxPuntua.ReadOnly = true;
            tBoxPuntua.Size = new Size(260, 23);
            tBoxPuntua.TabIndex = 6;
            tBoxPuntua.TabStop = false;
            tBoxPuntua.Text = "ptos1º, ptos2º, ptos3º,...[ptos PS]";
            // 
            // btnEditCto
            // 
            btnEditCto.BackColor = Color.FromArgb(52, 73, 94);
            btnEditCto.BackgroundImage = Properties.Resources.pencil_w;
            btnEditCto.BackgroundImageLayout = ImageLayout.Zoom;
            btnEditCto.Cursor = Cursors.Hand;
            btnEditCto.Location = new Point(590, 44);
            btnEditCto.Name = "btnEditCto";
            btnEditCto.Size = new Size(35, 35);
            btnEditCto.TabIndex = 3;
            btnEditCto.UseVisualStyleBackColor = false;
            // 
            // btnDelCto
            // 
            btnDelCto.BackColor = Color.FromArgb(52, 73, 94);
            btnDelCto.BackgroundImage = Properties.Resources.del_r;
            btnDelCto.BackgroundImageLayout = ImageLayout.Zoom;
            btnDelCto.Cursor = Cursors.Hand;
            btnDelCto.Location = new Point(631, 44);
            btnDelCto.Name = "btnDelCto";
            btnDelCto.Size = new Size(35, 35);
            btnDelCto.TabIndex = 3;
            btnDelCto.UseVisualStyleBackColor = false;
            // 
            // boxPrueba
            // 
            boxPrueba.AutoCompleteMode = AutoCompleteMode.Suggest;
            boxPrueba.AutoCompleteSource = AutoCompleteSource.CustomSource;
            boxPrueba.Enabled = false;
            boxPrueba.FormattingEnabled = true;
            boxPrueba.Location = new Point(6, 98);
            boxPrueba.MaxLength = 50;
            boxPrueba.Name = "boxPrueba";
            boxPrueba.Size = new Size(260, 23);
            boxPrueba.TabIndex = 1;
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
            // button1
            // 
            button1.BackColor = Color.FromArgb(52, 73, 94);
            button1.BackgroundImage = Properties.Resources.new_w;
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.Cursor = Cursors.Hand;
            button1.Location = new Point(414, 91);
            button1.Name = "button1";
            button1.Size = new Size(35, 35);
            button1.TabIndex = 3;
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(52, 73, 94);
            button2.BackgroundImage = Properties.Resources.pencil_w;
            button2.BackgroundImageLayout = ImageLayout.Zoom;
            button2.Cursor = Cursors.Hand;
            button2.Location = new Point(455, 91);
            button2.Name = "button2";
            button2.Size = new Size(35, 35);
            button2.TabIndex = 3;
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(52, 73, 94);
            button3.BackgroundImage = Properties.Resources.del_r;
            button3.BackgroundImageLayout = ImageLayout.Zoom;
            button3.Cursor = Cursors.Hand;
            button3.Location = new Point(496, 91);
            button3.Name = "button3";
            button3.Size = new Size(35, 35);
            button3.TabIndex = 3;
            button3.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(272, 80);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 5;
            label3.Text = "Etapas";
            // 
            // tBoxEtapas
            // 
            tBoxEtapas.BackColor = Color.FromArgb(52, 73, 94);
            tBoxEtapas.BorderStyle = BorderStyle.FixedSingle;
            tBoxEtapas.ForeColor = Color.White;
            tBoxEtapas.Location = new Point(272, 99);
            tBoxEtapas.Name = "tBoxEtapas";
            tBoxEtapas.ReadOnly = true;
            tBoxEtapas.Size = new Size(40, 23);
            tBoxEtapas.TabIndex = 6;
            tBoxEtapas.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(316, 80);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 5;
            label4.Text = "Tramos";
            // 
            // tBoxTramos
            // 
            tBoxTramos.BackColor = Color.FromArgb(52, 73, 94);
            tBoxTramos.BorderStyle = BorderStyle.FixedSingle;
            tBoxTramos.ForeColor = Color.White;
            tBoxTramos.Location = new Point(318, 99);
            tBoxTramos.Name = "tBoxTramos";
            tBoxTramos.ReadOnly = true;
            tBoxTramos.Size = new Size(40, 23);
            tBoxTramos.TabIndex = 6;
            tBoxTramos.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(364, 80);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 5;
            label5.Text = "tº max.";
            // 
            // tBoxTmax
            // 
            tBoxTmax.BackColor = Color.FromArgb(52, 73, 94);
            tBoxTmax.BorderStyle = BorderStyle.FixedSingle;
            tBoxTmax.ForeColor = Color.White;
            tBoxTmax.Location = new Point(364, 99);
            tBoxTmax.Name = "tBoxTmax";
            tBoxTmax.ReadOnly = true;
            tBoxTmax.Size = new Size(40, 23);
            tBoxTmax.TabIndex = 6;
            tBoxTmax.TabStop = false;
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
            Controls.Add(tBoxTmax);
            Controls.Add(tBoxTramos);
            Controls.Add(label5);
            Controls.Add(tBoxEtapas);
            Controls.Add(label4);
            Controls.Add(tBoxPuntua);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(btnDelCto);
            Controls.Add(button2);
            Controls.Add(btnEditCto);
            Controls.Add(button1);
            Controls.Add(btnNewCto);
            Controls.Add(label2);
            Controls.Add(lblCto);
            Controls.Add(boxPrueba);
            Controls.Add(cBoxCto);
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
        private ComboBox cBoxCto;
        private Label lblCto;
        private Button btnNewCto;
        private Label label1;
        private TextBox tBoxPuntua;
        private Button btnEditCto;
        private Button btnDelCto;
        private ComboBox boxPrueba;
        private Label label2;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label3;
        private TextBox tBoxEtapas;
        private Label label4;
        private TextBox tBoxTramos;
        private Label label5;
        private TextBox tBoxTmax;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}