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
            archivoToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            statusStripMain = new StatusStrip();
            labelStatus = new ToolStripStatusLabel();
            panel1 = new Panel();
            groupBox2 = new GroupBox();
            tboxEscuderia = new TextBox();
            label12 = new Label();
            tboxMarca = new TextBox();
            tboxAlias = new TextBox();
            label8 = new Label();
            label9 = new Label();
            botonBorraCoche = new Button();
            botonBorraPiloto = new Button();
            botonEditaCoche = new Button();
            botonEditaPiloto = new Button();
            botonNuevoCoche = new Button();
            botonNuevoPiloto = new Button();
            label10 = new Label();
            label11 = new Label();
            comboCoches = new ComboBox();
            comboPilotos = new ComboBox();
            groupBox1 = new GroupBox();
            tboxTmax = new TextBox();
            tboxTramos = new TextBox();
            label5 = new Label();
            tboxEtapas = new TextBox();
            label4 = new Label();
            tboxPuntuaciones = new TextBox();
            label3 = new Label();
            label1 = new Label();
            botonBorraPrueba = new Button();
            botonBorraCampeonato = new Button();
            botonEditaPrueba = new Button();
            botonEditaCampeonato = new Button();
            botonNuevaPrueba = new Button();
            botonNuevoCampeonato = new Button();
            label2 = new Label();
            lblCto = new Label();
            comboPruebas = new ComboBox();
            comboCampeonatos = new ComboBox();
            panel3 = new Panel();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)DataGridInscripcion).BeginInit();
            menuMain.SuspendLayout();
            statusStripMain.SuspendLayout();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // DataGridInscripcion
            // 
            DataGridInscripcion.AllowUserToAddRows = false;
            DataGridInscripcion.AllowUserToDeleteRows = false;
            DataGridInscripcion.AllowUserToOrderColumns = true;
            DataGridInscripcion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridInscripcion.BackgroundColor = Color.FromArgb(52, 73, 94);
            DataGridInscripcion.CellBorderStyle = DataGridViewCellBorderStyle.None;
            DataGridInscripcion.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DataGridInscripcion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridInscripcion.Dock = DockStyle.Fill;
            DataGridInscripcion.Location = new Point(0, 278);
            DataGridInscripcion.Name = "DataGridInscripcion";
            DataGridInscripcion.ReadOnly = true;
            DataGridInscripcion.RowHeadersWidth = 15;
            DataGridInscripcion.Size = new Size(1264, 428);
            DataGridInscripcion.TabIndex = 0;
            DataGridInscripcion.TabStop = false;
            // 
            // menuMain
            // 
            menuMain.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem });
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Padding = new Padding(0);
            menuMain.RenderMode = ToolStripRenderMode.Professional;
            menuMain.Size = new Size(1264, 24);
            menuMain.TabIndex = 2;
            menuMain.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.AutoToolTip = true;
            archivoToolStripMenuItem.BackColor = Color.Transparent;
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { salirToolStripMenuItem });
            archivoToolStripMenuItem.ForeColor = Color.Black;
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Padding = new Padding(0);
            archivoToolStripMenuItem.Size = new Size(52, 24);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(96, 22);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += SalirToolStripMenuItem_Click;
            // 
            // statusStripMain
            // 
            statusStripMain.GripMargin = new Padding(0);
            statusStripMain.Items.AddRange(new ToolStripItem[] { labelStatus });
            statusStripMain.Location = new Point(0, 706);
            statusStripMain.Name = "statusStripMain";
            statusStripMain.Size = new Size(1264, 22);
            statusStripMain.SizingGrip = false;
            statusStripMain.TabIndex = 0;
            // 
            // labelStatus
            // 
            labelStatus.BackColor = Color.Transparent;
            labelStatus.DisplayStyle = ToolStripItemDisplayStyle.Text;
            labelStatus.ForeColor = Color.FromArgb(192, 0, 0);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(0, 17);
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(1264, 254);
            panel1.TabIndex = 10;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tboxEscuderia);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(tboxMarca);
            groupBox2.Controls.Add(tboxAlias);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(botonBorraCoche);
            groupBox2.Controls.Add(botonBorraPiloto);
            groupBox2.Controls.Add(botonEditaCoche);
            groupBox2.Controls.Add(botonEditaPiloto);
            groupBox2.Controls.Add(botonNuevoCoche);
            groupBox2.Controls.Add(botonNuevoPiloto);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(comboCoches);
            groupBox2.Controls.Add(comboPilotos);
            groupBox2.Location = new Point(3, 130);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(667, 121);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            // 
            // tboxEscuderia
            // 
            tboxEscuderia.BackColor = Color.FromArgb(52, 73, 94);
            tboxEscuderia.BorderStyle = BorderStyle.FixedSingle;
            tboxEscuderia.ForeColor = Color.White;
            tboxEscuderia.Location = new Point(318, 38);
            tboxEscuderia.Name = "tboxEscuderia";
            tboxEscuderia.ReadOnly = true;
            tboxEscuderia.Size = new Size(213, 23);
            tboxEscuderia.TabIndex = 0;
            tboxEscuderia.TabStop = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.ForeColor = Color.White;
            label12.Location = new Point(318, 19);
            label12.Name = "label12";
            label12.Size = new Size(93, 15);
            label12.TabIndex = 0;
            label12.Text = "Club / Escudería";
            // 
            // tboxMarca
            // 
            tboxMarca.BackColor = Color.FromArgb(52, 73, 94);
            tboxMarca.BorderStyle = BorderStyle.FixedSingle;
            tboxMarca.ForeColor = Color.White;
            tboxMarca.Location = new Point(272, 84);
            tboxMarca.Name = "tboxMarca";
            tboxMarca.ReadOnly = true;
            tboxMarca.Size = new Size(132, 23);
            tboxMarca.TabIndex = 0;
            tboxMarca.TabStop = false;
            tboxMarca.TextAlign = HorizontalAlignment.Right;
            // 
            // tboxAlias
            // 
            tboxAlias.BackColor = Color.FromArgb(52, 73, 94);
            tboxAlias.BorderStyle = BorderStyle.FixedSingle;
            tboxAlias.ForeColor = Color.White;
            tboxAlias.Location = new Point(272, 37);
            tboxAlias.Name = "tboxAlias";
            tboxAlias.ReadOnly = true;
            tboxAlias.Size = new Size(41, 23);
            tboxAlias.TabIndex = 0;
            tboxAlias.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.White;
            label8.Location = new Point(272, 65);
            label8.Name = "label8";
            label8.Size = new Size(40, 15);
            label8.TabIndex = 0;
            label8.Text = "Marca";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.White;
            label9.Location = new Point(272, 18);
            label9.Name = "label9";
            label9.Size = new Size(32, 15);
            label9.TabIndex = 0;
            label9.Text = "Alias";
            // 
            // botonBorraCoche
            // 
            botonBorraCoche.BackColor = Color.FromArgb(52, 73, 94);
            botonBorraCoche.BackgroundImageLayout = ImageLayout.Zoom;
            botonBorraCoche.Cursor = Cursors.Hand;
            botonBorraCoche.Enabled = false;
            botonBorraCoche.FlatStyle = FlatStyle.Flat;
            botonBorraCoche.ForeColor = Color.Transparent;
            botonBorraCoche.Location = new Point(496, 76);
            botonBorraCoche.Name = "botonBorraCoche";
            botonBorraCoche.Size = new Size(35, 35);
            botonBorraCoche.TabIndex = 0;
            botonBorraCoche.TabStop = false;
            botonBorraCoche.UseVisualStyleBackColor = false;
            botonBorraCoche.Click += BotonBorraCoche_Click;
            // 
            // botonBorraPiloto
            // 
            botonBorraPiloto.BackColor = Color.FromArgb(52, 73, 94);
            botonBorraPiloto.BackgroundImageLayout = ImageLayout.Zoom;
            botonBorraPiloto.Cursor = Cursors.Hand;
            botonBorraPiloto.Enabled = false;
            botonBorraPiloto.FlatStyle = FlatStyle.Flat;
            botonBorraPiloto.ForeColor = Color.Transparent;
            botonBorraPiloto.Location = new Point(622, 29);
            botonBorraPiloto.Name = "botonBorraPiloto";
            botonBorraPiloto.Size = new Size(35, 35);
            botonBorraPiloto.TabIndex = 0;
            botonBorraPiloto.TabStop = false;
            botonBorraPiloto.UseVisualStyleBackColor = false;
            botonBorraPiloto.Click += BotonBorraPiloto_Click;
            // 
            // botonEditaCoche
            // 
            botonEditaCoche.BackColor = Color.FromArgb(52, 73, 94);
            botonEditaCoche.BackgroundImageLayout = ImageLayout.Zoom;
            botonEditaCoche.Cursor = Cursors.Hand;
            botonEditaCoche.Enabled = false;
            botonEditaCoche.FlatStyle = FlatStyle.Flat;
            botonEditaCoche.ForeColor = Color.Transparent;
            botonEditaCoche.Location = new Point(455, 76);
            botonEditaCoche.Name = "botonEditaCoche";
            botonEditaCoche.Size = new Size(35, 35);
            botonEditaCoche.TabIndex = 0;
            botonEditaCoche.TabStop = false;
            botonEditaCoche.UseVisualStyleBackColor = false;
            botonEditaCoche.Click += BotonEditaCoche_Click;
            // 
            // botonEditaPiloto
            // 
            botonEditaPiloto.BackColor = Color.FromArgb(52, 73, 94);
            botonEditaPiloto.BackgroundImageLayout = ImageLayout.None;
            botonEditaPiloto.Cursor = Cursors.Hand;
            botonEditaPiloto.Enabled = false;
            botonEditaPiloto.FlatStyle = FlatStyle.Flat;
            botonEditaPiloto.ForeColor = Color.Transparent;
            botonEditaPiloto.Location = new Point(581, 29);
            botonEditaPiloto.Name = "botonEditaPiloto";
            botonEditaPiloto.Size = new Size(35, 35);
            botonEditaPiloto.TabIndex = 0;
            botonEditaPiloto.TabStop = false;
            botonEditaPiloto.UseVisualStyleBackColor = false;
            botonEditaPiloto.Click += BotonEditaPiloto_Click;
            // 
            // botonNuevoCoche
            // 
            botonNuevoCoche.BackColor = Color.FromArgb(52, 73, 94);
            botonNuevoCoche.BackgroundImageLayout = ImageLayout.Zoom;
            botonNuevoCoche.Cursor = Cursors.Hand;
            botonNuevoCoche.Enabled = false;
            botonNuevoCoche.FlatStyle = FlatStyle.Flat;
            botonNuevoCoche.ForeColor = Color.Transparent;
            botonNuevoCoche.Location = new Point(414, 76);
            botonNuevoCoche.Name = "botonNuevoCoche";
            botonNuevoCoche.Size = new Size(35, 35);
            botonNuevoCoche.TabIndex = 0;
            botonNuevoCoche.TabStop = false;
            botonNuevoCoche.UseVisualStyleBackColor = false;
            botonNuevoCoche.Click += BotonNuevoCoche_Click;
            // 
            // botonNuevoPiloto
            // 
            botonNuevoPiloto.BackColor = Color.FromArgb(52, 73, 94);
            botonNuevoPiloto.BackgroundImageLayout = ImageLayout.Zoom;
            botonNuevoPiloto.Cursor = Cursors.Hand;
            botonNuevoPiloto.Enabled = false;
            botonNuevoPiloto.FlatStyle = FlatStyle.Flat;
            botonNuevoPiloto.ForeColor = Color.Transparent;
            botonNuevoPiloto.Location = new Point(540, 29);
            botonNuevoPiloto.Name = "botonNuevoPiloto";
            botonNuevoPiloto.Size = new Size(35, 35);
            botonNuevoPiloto.TabIndex = 0;
            botonNuevoPiloto.TabStop = false;
            botonNuevoPiloto.UseVisualStyleBackColor = false;
            botonNuevoPiloto.Click += BotonNuevoPiloto_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.White;
            label10.Location = new Point(6, 65);
            label10.Name = "label10";
            label10.Size = new Size(48, 15);
            label10.TabIndex = 0;
            label10.Text = "Modelo";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = Color.White;
            label11.Location = new Point(6, 18);
            label11.Name = "label11";
            label11.Size = new Size(38, 15);
            label11.TabIndex = 0;
            label11.Text = "Piloto";
            // 
            // comboCoches
            // 
            comboCoches.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboCoches.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCoches.Enabled = false;
            comboCoches.FormattingEnabled = true;
            comboCoches.Location = new Point(6, 83);
            comboCoches.MaxLength = 50;
            comboCoches.Name = "comboCoches";
            comboCoches.Size = new Size(260, 23);
            comboCoches.TabIndex = 3;
            comboCoches.SelectedIndexChanged += ComboCoches_SelectedIndexChanged;
            // 
            // comboPilotos
            // 
            comboPilotos.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboPilotos.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPilotos.Enabled = false;
            comboPilotos.FormattingEnabled = true;
            comboPilotos.Location = new Point(6, 36);
            comboPilotos.MaxLength = 50;
            comboPilotos.Name = "comboPilotos";
            comboPilotos.Size = new Size(260, 23);
            comboPilotos.TabIndex = 3;
            comboPilotos.SelectedIndexChanged += ComboPilotos_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tboxTmax);
            groupBox1.Controls.Add(tboxTramos);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(tboxEtapas);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(tboxPuntuaciones);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(botonBorraPrueba);
            groupBox1.Controls.Add(botonBorraCampeonato);
            groupBox1.Controls.Add(botonEditaPrueba);
            groupBox1.Controls.Add(botonEditaCampeonato);
            groupBox1.Controls.Add(botonNuevaPrueba);
            groupBox1.Controls.Add(botonNuevoCampeonato);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(lblCto);
            groupBox1.Controls.Add(comboPruebas);
            groupBox1.Controls.Add(comboCampeonatos);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(667, 121);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            // 
            // tboxTmax
            // 
            tboxTmax.BackColor = Color.FromArgb(52, 73, 94);
            tboxTmax.BorderStyle = BorderStyle.FixedSingle;
            tboxTmax.ForeColor = Color.White;
            tboxTmax.Location = new Point(364, 84);
            tboxTmax.Name = "tboxTmax";
            tboxTmax.ReadOnly = true;
            tboxTmax.Size = new Size(40, 23);
            tboxTmax.TabIndex = 0;
            tboxTmax.TabStop = false;
            tboxTmax.TextAlign = HorizontalAlignment.Right;
            // 
            // tboxTramos
            // 
            tboxTramos.BackColor = Color.FromArgb(52, 73, 94);
            tboxTramos.BorderStyle = BorderStyle.FixedSingle;
            tboxTramos.ForeColor = Color.White;
            tboxTramos.Location = new Point(318, 84);
            tboxTramos.Name = "tboxTramos";
            tboxTramos.ReadOnly = true;
            tboxTramos.Size = new Size(40, 23);
            tboxTramos.TabIndex = 0;
            tboxTramos.TabStop = false;
            tboxTramos.TextAlign = HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(364, 65);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 0;
            label5.Text = "tº max.";
            // 
            // tboxEtapas
            // 
            tboxEtapas.BackColor = Color.FromArgb(52, 73, 94);
            tboxEtapas.BorderStyle = BorderStyle.FixedSingle;
            tboxEtapas.ForeColor = Color.White;
            tboxEtapas.Location = new Point(272, 84);
            tboxEtapas.Name = "tboxEtapas";
            tboxEtapas.ReadOnly = true;
            tboxEtapas.Size = new Size(40, 23);
            tboxEtapas.TabIndex = 0;
            tboxEtapas.TabStop = false;
            tboxEtapas.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(316, 65);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 0;
            label4.Text = "Tramos";
            // 
            // tboxPuntuaciones
            // 
            tboxPuntuaciones.BackColor = Color.FromArgb(52, 73, 94);
            tboxPuntuaciones.BorderStyle = BorderStyle.FixedSingle;
            tboxPuntuaciones.ForeColor = Color.White;
            tboxPuntuaciones.Location = new Point(272, 37);
            tboxPuntuaciones.Name = "tboxPuntuaciones";
            tboxPuntuaciones.ReadOnly = true;
            tboxPuntuaciones.Size = new Size(260, 23);
            tboxPuntuaciones.TabIndex = 0;
            tboxPuntuaciones.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(272, 65);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 0;
            label3.Text = "Etapas";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(272, 18);
            label1.Name = "label1";
            label1.Size = new Size(259, 15);
            label1.TabIndex = 0;
            label1.Text = "Puntuación: ptos1º, ptos2º,...[ptos Power Stage]";
            // 
            // botonBorraPrueba
            // 
            botonBorraPrueba.BackColor = Color.FromArgb(52, 73, 94);
            botonBorraPrueba.BackgroundImageLayout = ImageLayout.Zoom;
            botonBorraPrueba.Cursor = Cursors.Hand;
            botonBorraPrueba.Enabled = false;
            botonBorraPrueba.FlatStyle = FlatStyle.Flat;
            botonBorraPrueba.ForeColor = Color.Transparent;
            botonBorraPrueba.Location = new Point(496, 76);
            botonBorraPrueba.Name = "botonBorraPrueba";
            botonBorraPrueba.Size = new Size(35, 35);
            botonBorraPrueba.TabIndex = 0;
            botonBorraPrueba.TabStop = false;
            botonBorraPrueba.UseVisualStyleBackColor = false;
            botonBorraPrueba.Click += BotonBorraPrueba_Click;
            // 
            // botonBorraCampeonato
            // 
            botonBorraCampeonato.BackColor = Color.FromArgb(52, 73, 94);
            botonBorraCampeonato.BackgroundImageLayout = ImageLayout.Zoom;
            botonBorraCampeonato.Cursor = Cursors.Hand;
            botonBorraCampeonato.Enabled = false;
            botonBorraCampeonato.FlatStyle = FlatStyle.Flat;
            botonBorraCampeonato.ForeColor = Color.Transparent;
            botonBorraCampeonato.Location = new Point(622, 29);
            botonBorraCampeonato.Name = "botonBorraCampeonato";
            botonBorraCampeonato.Size = new Size(35, 35);
            botonBorraCampeonato.TabIndex = 0;
            botonBorraCampeonato.TabStop = false;
            botonBorraCampeonato.UseVisualStyleBackColor = false;
            botonBorraCampeonato.Click += BotonBorraCampeonato_Click;
            // 
            // botonEditaPrueba
            // 
            botonEditaPrueba.BackColor = Color.FromArgb(52, 73, 94);
            botonEditaPrueba.BackgroundImageLayout = ImageLayout.Zoom;
            botonEditaPrueba.Cursor = Cursors.Hand;
            botonEditaPrueba.Enabled = false;
            botonEditaPrueba.FlatStyle = FlatStyle.Flat;
            botonEditaPrueba.ForeColor = Color.Transparent;
            botonEditaPrueba.Location = new Point(455, 76);
            botonEditaPrueba.Name = "botonEditaPrueba";
            botonEditaPrueba.Size = new Size(35, 35);
            botonEditaPrueba.TabIndex = 0;
            botonEditaPrueba.TabStop = false;
            botonEditaPrueba.UseVisualStyleBackColor = false;
            botonEditaPrueba.Click += BotonEditaPrueba_Click;
            // 
            // botonEditaCampeonato
            // 
            botonEditaCampeonato.BackColor = Color.FromArgb(52, 73, 94);
            botonEditaCampeonato.BackgroundImageLayout = ImageLayout.None;
            botonEditaCampeonato.Cursor = Cursors.Hand;
            botonEditaCampeonato.Enabled = false;
            botonEditaCampeonato.FlatStyle = FlatStyle.Flat;
            botonEditaCampeonato.ForeColor = Color.Transparent;
            botonEditaCampeonato.Location = new Point(581, 29);
            botonEditaCampeonato.Name = "botonEditaCampeonato";
            botonEditaCampeonato.Size = new Size(35, 35);
            botonEditaCampeonato.TabIndex = 0;
            botonEditaCampeonato.TabStop = false;
            botonEditaCampeonato.UseVisualStyleBackColor = false;
            botonEditaCampeonato.Click += BotonEditaCampeonato_Click;
            // 
            // botonNuevaPrueba
            // 
            botonNuevaPrueba.BackColor = Color.FromArgb(52, 73, 94);
            botonNuevaPrueba.BackgroundImageLayout = ImageLayout.Zoom;
            botonNuevaPrueba.Cursor = Cursors.Hand;
            botonNuevaPrueba.Enabled = false;
            botonNuevaPrueba.FlatStyle = FlatStyle.Flat;
            botonNuevaPrueba.ForeColor = Color.Transparent;
            botonNuevaPrueba.Location = new Point(414, 76);
            botonNuevaPrueba.Name = "botonNuevaPrueba";
            botonNuevaPrueba.Size = new Size(35, 35);
            botonNuevaPrueba.TabIndex = 0;
            botonNuevaPrueba.TabStop = false;
            botonNuevaPrueba.UseVisualStyleBackColor = false;
            botonNuevaPrueba.Click += BotonNuevaPrueba_Click;
            // 
            // botonNuevoCampeonato
            // 
            botonNuevoCampeonato.BackColor = Color.FromArgb(52, 73, 94);
            botonNuevoCampeonato.BackgroundImageLayout = ImageLayout.Zoom;
            botonNuevoCampeonato.Cursor = Cursors.Hand;
            botonNuevoCampeonato.Enabled = false;
            botonNuevoCampeonato.FlatStyle = FlatStyle.Flat;
            botonNuevoCampeonato.ForeColor = Color.Transparent;
            botonNuevoCampeonato.Location = new Point(540, 29);
            botonNuevoCampeonato.Name = "botonNuevoCampeonato";
            botonNuevoCampeonato.Size = new Size(35, 35);
            botonNuevoCampeonato.TabIndex = 0;
            botonNuevoCampeonato.TabStop = false;
            botonNuevoCampeonato.UseVisualStyleBackColor = false;
            botonNuevoCampeonato.Click += BotonNuevoCampeonato_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(6, 65);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 0;
            label2.Text = "Prueba (Rally)";
            // 
            // lblCto
            // 
            lblCto.AutoSize = true;
            lblCto.ForeColor = Color.White;
            lblCto.Location = new Point(6, 18);
            lblCto.Name = "lblCto";
            lblCto.Size = new Size(76, 15);
            lblCto.TabIndex = 0;
            lblCto.Text = "Campeonato";
            // 
            // comboPruebas
            // 
            comboPruebas.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboPruebas.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPruebas.Enabled = false;
            comboPruebas.FormattingEnabled = true;
            comboPruebas.Location = new Point(6, 83);
            comboPruebas.MaxLength = 50;
            comboPruebas.Name = "comboPruebas";
            comboPruebas.Size = new Size(260, 23);
            comboPruebas.TabIndex = 2;
            comboPruebas.SelectedIndexChanged += ComboPruebas_SelectedIndexChanged;
            // 
            // comboCampeonatos
            // 
            comboCampeonatos.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboCampeonatos.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCampeonatos.FormattingEnabled = true;
            comboCampeonatos.Location = new Point(6, 36);
            comboCampeonatos.MaxLength = 50;
            comboCampeonatos.Name = "comboCampeonatos";
            comboCampeonatos.Size = new Size(260, 23);
            comboCampeonatos.TabIndex = 1;
            comboCampeonatos.SelectedIndexChanged += ComboCampeonatos_SelectedIndexChanged;
            // 
            // panel3
            // 
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(pictureBox2);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(1083, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(181, 254);
            panel3.TabIndex = 12;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.avslot_logo;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Dock = DockStyle.Bottom;
            pictureBox1.Location = new Point(0, 130);
            pictureBox1.Margin = new Padding(50);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(181, 124);
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            pictureBox1.WaitOnLoad = true;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.rkn;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Dock = DockStyle.Top;
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Margin = new Padding(50);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(181, 128);
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 670);
            panel2.Name = "panel2";
            panel2.Size = new Size(1264, 36);
            panel2.TabIndex = 11;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 62, 80);
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1264, 728);
            Controls.Add(panel2);
            Controls.Add(DataGridInscripcion);
            Controls.Add(panel1);
            Controls.Add(menuMain);
            Controls.Add(statusStripMain);
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
            panel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView DataGridInscripcion;
        private MenuStrip menuMain;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private StatusStrip statusStripMain;
        private ToolStripStatusLabel labelStatus;
        private ToolStripMenuItem salirToolStripMenuItem;
        private Panel panel1;
        private Panel panel2;
        private GroupBox groupBox2;
        private TextBox tboxEscuderia;
        private Label label12;
        private TextBox tboxMarca;
        private TextBox tboxAlias;
        private Label label8;
        private Label label9;
        private Button botonBorraCoche;
        private Button botonBorraPiloto;
        private Button botonEditaCoche;
        private Button botonEditaPiloto;
        private Button botonNuevoCoche;
        private Button botonNuevoPiloto;
        private Label label10;
        private Label label11;
        private ComboBox comboCoches;
        private ComboBox comboPilotos;
        private GroupBox groupBox1;
        private TextBox tboxTmax;
        private TextBox tboxTramos;
        private Label label5;
        private TextBox tboxEtapas;
        private Label label4;
        private TextBox tboxPuntuaciones;
        private Label label3;
        private Label label1;
        private Button botonBorraPrueba;
        private Button botonBorraCampeonato;
        private Button botonEditaPrueba;
        private Button botonEditaCampeonato;
        private Button botonNuevaPrueba;
        private Button botonNuevoCampeonato;
        private Label label2;
        private Label lblCto;
        private ComboBox comboPruebas;
        private ComboBox comboCampeonatos;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Panel panel3;
    }
}