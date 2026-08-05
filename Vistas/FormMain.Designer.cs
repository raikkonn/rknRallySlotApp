using rknRallySlotApp.Utilidades;

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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            dataGridInscripcion = new DataGridView();
            menuMain = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            statusStripMain = new StatusStrip();
            labelStatus = new ToolStripStatusLabel();
            panel1 = new Panel();
            groupBox4 = new ColoredGroupBox();
            botonNuevaInscripcion = new Button();
            checkVerificado = new CheckBox();
            groupBoxCate = new ColoredGroupBox();
            botonBorraCategoria = new Button();
            label7 = new Label();
            botonEditaCategoria = new Button();
            comboCategorias = new ComboBox();
            botonNuevaCategoria = new Button();
            groupBox2 = new ColoredGroupBox();
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
            groupBoxCto = new GroupBox();
            tboxPwrStg = new TextBox();
            tboxTmax = new TextBox();
            label6 = new Label();
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
            ((System.ComponentModel.ISupportInitialize)dataGridInscripcion).BeginInit();
            menuMain.SuspendLayout();
            statusStripMain.SuspendLayout();
            panel1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBoxCate.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBoxCto.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // dataGridInscripcion
            // 
            dataGridInscripcion.AllowUserToAddRows = false;
            dataGridInscripcion.AllowUserToDeleteRows = false;
            dataGridInscripcion.AllowUserToOrderColumns = true;
            dataGridInscripcion.AllowUserToResizeRows = false;
            dataGridInscripcion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridInscripcion.BackgroundColor = Color.FromArgb(40, 40, 40);
            dataGridInscripcion.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridInscripcion.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(53, 53, 53);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(53, 53, 53);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridInscripcion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridInscripcion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(53, 53, 53);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridInscripcion.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridInscripcion.Dock = DockStyle.Fill;
            dataGridInscripcion.EditMode = DataGridViewEditMode.EditOnF2;
            dataGridInscripcion.EnableHeadersVisualStyles = false;
            dataGridInscripcion.GridColor = Color.White;
            dataGridInscripcion.Location = new Point(0, 275);
            dataGridInscripcion.Name = "dataGridInscripcion";
            dataGridInscripcion.ReadOnly = true;
            dataGridInscripcion.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(53, 53, 53);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridInscripcion.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridInscripcion.RowHeadersWidth = 15;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(53, 53, 53);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridInscripcion.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridInscripcion.Size = new Size(1264, 431);
            dataGridInscripcion.TabIndex = 0;
            dataGridInscripcion.TabStop = false;
            dataGridInscripcion.CellDoubleClick += DataGridInscripcion_CellDoubleClick;
            dataGridInscripcion.DataBindingComplete += DataGridInscripcion_DataBindingComplete;
            dataGridInscripcion.RowPostPaint += DataGridInscripcion_RowPostPaint;
            dataGridInscripcion.SelectionChanged += DataGridInscripcion_SelectionChanged;
            dataGridInscripcion.Sorted += DataGridInscripcion_Sorted;
            // 
            // menuMain
            // 
            menuMain.Font = new Font("Segoe UI", 9F);
            menuMain.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem });
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Padding = new Padding(0);
            menuMain.Size = new Size(1264, 24);
            menuMain.TabIndex = 0;
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.AutoToolTip = true;
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { salirToolStripMenuItem });
            archivoToolStripMenuItem.Font = new Font("Segoe UI", 10F);
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Padding = new Padding(0);
            archivoToolStripMenuItem.Size = new Size(59, 24);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.AutoToolTip = true;
            salirToolStripMenuItem.BackColor = Color.FromArgb(28, 28, 28);
            salirToolStripMenuItem.Font = new Font("Segoe UI", 12F);
            salirToolStripMenuItem.ForeColor = Color.White;
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Padding = new Padding(0);
            salirToolStripMenuItem.Size = new Size(110, 24);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += SalirToolStripMenuItem_Click;
            // 
            // statusStripMain
            // 
            statusStripMain.Font = new Font("Segoe UI", 12F);
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
            panel1.Controls.Add(groupBox4);
            panel1.Controls.Add(groupBoxCate);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBoxCto);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(1264, 251);
            panel1.TabIndex = 10;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.FromArgb(40, 40, 40);
            groupBox4.BorderColor = Color.FromArgb(123, 113, 197);
            groupBox4.Controls.Add(botonNuevaInscripcion);
            groupBox4.Controls.Add(checkVerificado);
            groupBox4.FlatStyle = FlatStyle.Flat;
            groupBox4.Location = new Point(701, 127);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(200, 121);
            groupBox4.TabIndex = 24;
            groupBox4.TabStop = false;
            // 
            // botonNuevaInscripcion
            // 
            botonNuevaInscripcion.BackColor = Color.FromArgb(53, 53, 53);
            botonNuevaInscripcion.BackgroundImageLayout = ImageLayout.Zoom;
            botonNuevaInscripcion.Cursor = Cursors.Hand;
            botonNuevaInscripcion.Enabled = false;
            botonNuevaInscripcion.FlatStyle = FlatStyle.Flat;
            botonNuevaInscripcion.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            botonNuevaInscripcion.ForeColor = Color.Lime;
            botonNuevaInscripcion.Location = new Point(10, 62);
            botonNuevaInscripcion.Name = "botonNuevaInscripcion";
            botonNuevaInscripcion.Size = new Size(180, 49);
            botonNuevaInscripcion.TabIndex = 23;
            botonNuevaInscripcion.TabStop = false;
            botonNuevaInscripcion.Text = "Inscribir";
            botonNuevaInscripcion.UseVisualStyleBackColor = false;
            botonNuevaInscripcion.Click += BotonNuevaInscripcion_Click;
            // 
            // checkVerificado
            // 
            checkVerificado.Anchor = AnchorStyles.None;
            checkVerificado.AutoSize = true;
            checkVerificado.CheckAlign = ContentAlignment.MiddleRight;
            checkVerificado.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkVerificado.ForeColor = Color.Lime;
            checkVerificado.Location = new Point(41, 24);
            checkVerificado.Name = "checkVerificado";
            checkVerificado.Size = new Size(117, 29);
            checkVerificado.TabIndex = 0;
            checkVerificado.TabStop = false;
            checkVerificado.Text = "Verificado";
            checkVerificado.TextAlign = ContentAlignment.MiddleRight;
            checkVerificado.UseVisualStyleBackColor = true;
            // 
            // groupBoxCate
            // 
            groupBoxCate.BackColor = Color.FromArgb(40, 40, 40);
            groupBoxCate.BorderColor = Color.FromArgb(123, 113, 197);
            groupBoxCate.Controls.Add(botonBorraCategoria);
            groupBoxCate.Controls.Add(label7);
            groupBoxCate.Controls.Add(botonEditaCategoria);
            groupBoxCate.Controls.Add(comboCategorias);
            groupBoxCate.Controls.Add(botonNuevaCategoria);
            groupBoxCate.FlatStyle = FlatStyle.Flat;
            groupBoxCate.Location = new Point(701, 7);
            groupBoxCate.Name = "groupBoxCate";
            groupBoxCate.Size = new Size(200, 117);
            groupBoxCate.TabIndex = 14;
            groupBoxCate.TabStop = false;
            // 
            // botonBorraCategoria
            // 
            botonBorraCategoria.BackColor = Color.FromArgb(53, 53, 53);
            botonBorraCategoria.BackgroundImageLayout = ImageLayout.Zoom;
            botonBorraCategoria.Cursor = Cursors.Hand;
            botonBorraCategoria.Enabled = false;
            botonBorraCategoria.FlatStyle = FlatStyle.Flat;
            botonBorraCategoria.ForeColor = Color.Transparent;
            botonBorraCategoria.Location = new Point(155, 72);
            botonBorraCategoria.Name = "botonBorraCategoria";
            botonBorraCategoria.Size = new Size(35, 35);
            botonBorraCategoria.TabIndex = 21;
            botonBorraCategoria.TabStop = false;
            botonBorraCategoria.UseVisualStyleBackColor = false;
            botonBorraCategoria.Click += BotonBorraCategoria_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label7.ForeColor = Color.Lime;
            label7.Location = new Point(10, 14);
            label7.Name = "label7";
            label7.Size = new Size(66, 17);
            label7.TabIndex = 5;
            label7.Text = "Categoría";
            // 
            // botonEditaCategoria
            // 
            botonEditaCategoria.BackColor = Color.FromArgb(53, 53, 53);
            botonEditaCategoria.BackgroundImageLayout = ImageLayout.None;
            botonEditaCategoria.Cursor = Cursors.Hand;
            botonEditaCategoria.Enabled = false;
            botonEditaCategoria.FlatStyle = FlatStyle.Flat;
            botonEditaCategoria.ForeColor = Color.Transparent;
            botonEditaCategoria.Location = new Point(114, 72);
            botonEditaCategoria.Name = "botonEditaCategoria";
            botonEditaCategoria.Size = new Size(35, 35);
            botonEditaCategoria.TabIndex = 22;
            botonEditaCategoria.TabStop = false;
            botonEditaCategoria.UseVisualStyleBackColor = false;
            botonEditaCategoria.Click += BotonEditaCategoria_Click;
            // 
            // comboCategorias
            // 
            comboCategorias.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboCategorias.DrawMode = DrawMode.OwnerDrawFixed;
            comboCategorias.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCategorias.Enabled = false;
            comboCategorias.Font = new Font("Segoe UI", 11F);
            comboCategorias.FormattingEnabled = true;
            comboCategorias.Location = new Point(10, 32);
            comboCategorias.MaxLength = 50;
            comboCategorias.Name = "comboCategorias";
            comboCategorias.Size = new Size(180, 28);
            comboCategorias.TabIndex = 5;
            comboCategorias.DrawItem += ComboCategorias_DrawItem;
            comboCategorias.SelectedIndexChanged += ComboCategorias_SelectedIndexChanged;
            // 
            // botonNuevaCategoria
            // 
            botonNuevaCategoria.BackColor = Color.FromArgb(53, 53, 53);
            botonNuevaCategoria.BackgroundImageLayout = ImageLayout.Zoom;
            botonNuevaCategoria.Cursor = Cursors.Hand;
            botonNuevaCategoria.Enabled = false;
            botonNuevaCategoria.FlatStyle = FlatStyle.Flat;
            botonNuevaCategoria.ForeColor = Color.Transparent;
            botonNuevaCategoria.Location = new Point(73, 72);
            botonNuevaCategoria.Name = "botonNuevaCategoria";
            botonNuevaCategoria.Size = new Size(35, 35);
            botonNuevaCategoria.TabIndex = 23;
            botonNuevaCategoria.TabStop = false;
            botonNuevaCategoria.UseVisualStyleBackColor = false;
            botonNuevaCategoria.Click += BotonNuevaCategoria_Click;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.FromArgb(40, 40, 40);
            groupBox2.BorderColor = Color.FromArgb(123, 113, 197);
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
            groupBox2.FlatStyle = FlatStyle.Flat;
            groupBox2.Location = new Point(3, 127);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(692, 121);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            // 
            // tboxEscuderia
            // 
            tboxEscuderia.BackColor = Color.FromArgb(53, 53, 53);
            tboxEscuderia.BorderStyle = BorderStyle.FixedSingle;
            tboxEscuderia.Font = new Font("Segoe UI", 11F);
            tboxEscuderia.ForeColor = Color.White;
            tboxEscuderia.Location = new Point(364, 38);
            tboxEscuderia.Name = "tboxEscuderia";
            tboxEscuderia.ReadOnly = true;
            tboxEscuderia.Size = new Size(187, 27);
            tboxEscuderia.TabIndex = 0;
            tboxEscuderia.TabStop = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.ForeColor = Color.White;
            label12.Location = new Point(364, 21);
            label12.Name = "label12";
            label12.Size = new Size(93, 15);
            label12.TabIndex = 0;
            label12.Text = "Club / Escudería";
            // 
            // tboxMarca
            // 
            tboxMarca.BackColor = Color.FromArgb(53, 53, 53);
            tboxMarca.BorderStyle = BorderStyle.FixedSingle;
            tboxMarca.Font = new Font("Segoe UI", 11F);
            tboxMarca.ForeColor = Color.White;
            tboxMarca.Location = new Point(303, 83);
            tboxMarca.Name = "tboxMarca";
            tboxMarca.ReadOnly = true;
            tboxMarca.Size = new Size(248, 27);
            tboxMarca.TabIndex = 0;
            tboxMarca.TabStop = false;
            // 
            // tboxAlias
            // 
            tboxAlias.BackColor = Color.FromArgb(53, 53, 53);
            tboxAlias.BorderStyle = BorderStyle.FixedSingle;
            tboxAlias.Font = new Font("Segoe UI", 11F);
            tboxAlias.ForeColor = Color.White;
            tboxAlias.Location = new Point(303, 37);
            tboxAlias.Name = "tboxAlias";
            tboxAlias.ReadOnly = true;
            tboxAlias.Size = new Size(55, 27);
            tboxAlias.TabIndex = 0;
            tboxAlias.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.White;
            label8.Location = new Point(303, 69);
            label8.Name = "label8";
            label8.Size = new Size(40, 15);
            label8.TabIndex = 0;
            label8.Text = "Marca";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.White;
            label9.Location = new Point(303, 20);
            label9.Name = "label9";
            label9.Size = new Size(32, 15);
            label9.TabIndex = 0;
            label9.Text = "Alias";
            // 
            // botonBorraCoche
            // 
            botonBorraCoche.BackColor = Color.FromArgb(53, 53, 53);
            botonBorraCoche.BackgroundImageLayout = ImageLayout.Zoom;
            botonBorraCoche.Cursor = Cursors.Hand;
            botonBorraCoche.Enabled = false;
            botonBorraCoche.FlatStyle = FlatStyle.Flat;
            botonBorraCoche.ForeColor = Color.Transparent;
            botonBorraCoche.Location = new Point(647, 76);
            botonBorraCoche.Name = "botonBorraCoche";
            botonBorraCoche.Size = new Size(35, 35);
            botonBorraCoche.TabIndex = 0;
            botonBorraCoche.TabStop = false;
            botonBorraCoche.UseVisualStyleBackColor = false;
            botonBorraCoche.Click += BotonBorraCoche_Click;
            // 
            // botonBorraPiloto
            // 
            botonBorraPiloto.BackColor = Color.FromArgb(53, 53, 53);
            botonBorraPiloto.BackgroundImageLayout = ImageLayout.Zoom;
            botonBorraPiloto.Cursor = Cursors.Hand;
            botonBorraPiloto.Enabled = false;
            botonBorraPiloto.FlatStyle = FlatStyle.Flat;
            botonBorraPiloto.ForeColor = Color.Transparent;
            botonBorraPiloto.Location = new Point(647, 29);
            botonBorraPiloto.Name = "botonBorraPiloto";
            botonBorraPiloto.Size = new Size(35, 35);
            botonBorraPiloto.TabIndex = 0;
            botonBorraPiloto.TabStop = false;
            botonBorraPiloto.UseVisualStyleBackColor = false;
            botonBorraPiloto.Click += BotonBorraPiloto_Click;
            // 
            // botonEditaCoche
            // 
            botonEditaCoche.BackColor = Color.FromArgb(53, 53, 53);
            botonEditaCoche.BackgroundImageLayout = ImageLayout.Zoom;
            botonEditaCoche.Cursor = Cursors.Hand;
            botonEditaCoche.Enabled = false;
            botonEditaCoche.FlatStyle = FlatStyle.Flat;
            botonEditaCoche.ForeColor = Color.Transparent;
            botonEditaCoche.Location = new Point(606, 76);
            botonEditaCoche.Name = "botonEditaCoche";
            botonEditaCoche.Size = new Size(35, 35);
            botonEditaCoche.TabIndex = 0;
            botonEditaCoche.TabStop = false;
            botonEditaCoche.UseVisualStyleBackColor = false;
            botonEditaCoche.Click += BotonEditaCoche_Click;
            // 
            // botonEditaPiloto
            // 
            botonEditaPiloto.BackColor = Color.FromArgb(53, 53, 53);
            botonEditaPiloto.BackgroundImageLayout = ImageLayout.None;
            botonEditaPiloto.Cursor = Cursors.Hand;
            botonEditaPiloto.Enabled = false;
            botonEditaPiloto.FlatStyle = FlatStyle.Flat;
            botonEditaPiloto.ForeColor = Color.Transparent;
            botonEditaPiloto.Location = new Point(606, 29);
            botonEditaPiloto.Name = "botonEditaPiloto";
            botonEditaPiloto.Size = new Size(35, 35);
            botonEditaPiloto.TabIndex = 0;
            botonEditaPiloto.TabStop = false;
            botonEditaPiloto.UseVisualStyleBackColor = false;
            botonEditaPiloto.Click += BotonEditaPiloto_Click;
            // 
            // botonNuevoCoche
            // 
            botonNuevoCoche.BackColor = Color.FromArgb(53, 53, 53);
            botonNuevoCoche.BackgroundImageLayout = ImageLayout.Zoom;
            botonNuevoCoche.Cursor = Cursors.Hand;
            botonNuevoCoche.Enabled = false;
            botonNuevoCoche.FlatStyle = FlatStyle.Flat;
            botonNuevoCoche.ForeColor = Color.Transparent;
            botonNuevoCoche.Location = new Point(565, 76);
            botonNuevoCoche.Name = "botonNuevoCoche";
            botonNuevoCoche.Size = new Size(35, 35);
            botonNuevoCoche.TabIndex = 0;
            botonNuevoCoche.TabStop = false;
            botonNuevoCoche.UseVisualStyleBackColor = false;
            botonNuevoCoche.Click += BotonNuevoCoche_Click;
            // 
            // botonNuevoPiloto
            // 
            botonNuevoPiloto.BackColor = Color.FromArgb(53, 53, 53);
            botonNuevoPiloto.BackgroundImageLayout = ImageLayout.Zoom;
            botonNuevoPiloto.Cursor = Cursors.Hand;
            botonNuevoPiloto.Enabled = false;
            botonNuevoPiloto.FlatStyle = FlatStyle.Flat;
            botonNuevoPiloto.ForeColor = Color.Transparent;
            botonNuevoPiloto.Location = new Point(565, 29);
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
            label10.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label10.ForeColor = Color.Lime;
            label10.Location = new Point(6, 65);
            label10.Name = "label10";
            label10.Size = new Size(54, 17);
            label10.TabIndex = 0;
            label10.Text = "Modelo";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label11.ForeColor = Color.Lime;
            label11.Location = new Point(6, 18);
            label11.Name = "label11";
            label11.Size = new Size(43, 17);
            label11.TabIndex = 0;
            label11.Text = "Piloto";
            // 
            // comboCoches
            // 
            comboCoches.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboCoches.BackColor = Color.FromArgb(192, 255, 192);
            comboCoches.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCoches.Enabled = false;
            comboCoches.Font = new Font("Segoe UI", 11F);
            comboCoches.FormattingEnabled = true;
            comboCoches.Location = new Point(6, 83);
            comboCoches.MaxLength = 50;
            comboCoches.Name = "comboCoches";
            comboCoches.Size = new Size(291, 28);
            comboCoches.TabIndex = 4;
            comboCoches.SelectedIndexChanged += ComboCoches_SelectedIndexChanged;
            // 
            // comboPilotos
            // 
            comboPilotos.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboPilotos.BackColor = Color.FromArgb(192, 255, 192);
            comboPilotos.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPilotos.Enabled = false;
            comboPilotos.Font = new Font("Segoe UI", 11F);
            comboPilotos.FormattingEnabled = true;
            comboPilotos.Location = new Point(6, 36);
            comboPilotos.MaxLength = 50;
            comboPilotos.Name = "comboPilotos";
            comboPilotos.Size = new Size(291, 28);
            comboPilotos.TabIndex = 3;
            comboPilotos.SelectedIndexChanged += ComboPilotos_SelectedIndexChanged;
            // 
            // groupBoxCto
            // 
            groupBoxCto.BackColor = Color.FromArgb(40, 40, 40);
            groupBoxCto.Controls.Add(tboxPwrStg);
            groupBoxCto.Controls.Add(tboxTmax);
            groupBoxCto.Controls.Add(label6);
            groupBoxCto.Controls.Add(tboxTramos);
            groupBoxCto.Controls.Add(label5);
            groupBoxCto.Controls.Add(tboxEtapas);
            groupBoxCto.Controls.Add(label4);
            groupBoxCto.Controls.Add(tboxPuntuaciones);
            groupBoxCto.Controls.Add(label3);
            groupBoxCto.Controls.Add(label1);
            groupBoxCto.Controls.Add(botonBorraPrueba);
            groupBoxCto.Controls.Add(botonBorraCampeonato);
            groupBoxCto.Controls.Add(botonEditaPrueba);
            groupBoxCto.Controls.Add(botonEditaCampeonato);
            groupBoxCto.Controls.Add(botonNuevaPrueba);
            groupBoxCto.Controls.Add(botonNuevoCampeonato);
            groupBoxCto.Controls.Add(label2);
            groupBoxCto.Controls.Add(lblCto);
            groupBoxCto.Controls.Add(comboPruebas);
            groupBoxCto.Controls.Add(comboCampeonatos);
            groupBoxCto.FlatStyle = FlatStyle.Flat;
            groupBoxCto.Location = new Point(3, 3);
            groupBoxCto.Name = "groupBoxCto";
            groupBoxCto.Size = new Size(692, 121);
            groupBoxCto.TabIndex = 12;
            groupBoxCto.TabStop = false;
            // 
            // tboxPwrStg
            // 
            tboxPwrStg.BackColor = Color.FromArgb(53, 53, 53);
            tboxPwrStg.BorderStyle = BorderStyle.FixedSingle;
            tboxPwrStg.Font = new Font("Segoe UI", 11F);
            tboxPwrStg.ForeColor = Color.White;
            tboxPwrStg.Location = new Point(410, 84);
            tboxPwrStg.Name = "tboxPwrStg";
            tboxPwrStg.ReadOnly = true;
            tboxPwrStg.Size = new Size(141, 27);
            tboxPwrStg.TabIndex = 19;
            tboxPwrStg.TabStop = false;
            // 
            // tboxTmax
            // 
            tboxTmax.BackColor = Color.FromArgb(53, 53, 53);
            tboxTmax.BorderStyle = BorderStyle.FixedSingle;
            tboxTmax.Font = new Font("Segoe UI", 11F);
            tboxTmax.ForeColor = Color.White;
            tboxTmax.Location = new Point(364, 84);
            tboxTmax.Name = "tboxTmax";
            tboxTmax.ReadOnly = true;
            tboxTmax.Size = new Size(40, 27);
            tboxTmax.TabIndex = 0;
            tboxTmax.TabStop = false;
            tboxTmax.TextAlign = HorizontalAlignment.Right;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.White;
            label6.Location = new Point(412, 68);
            label6.Name = "label6";
            label6.Size = new Size(72, 15);
            label6.TabIndex = 20;
            label6.Text = "Power Stage";
            // 
            // tboxTramos
            // 
            tboxTramos.BackColor = Color.FromArgb(53, 53, 53);
            tboxTramos.BorderStyle = BorderStyle.FixedSingle;
            tboxTramos.Font = new Font("Segoe UI", 11F);
            tboxTramos.ForeColor = Color.White;
            tboxTramos.Location = new Point(318, 84);
            tboxTramos.Name = "tboxTramos";
            tboxTramos.ReadOnly = true;
            tboxTramos.Size = new Size(40, 27);
            tboxTramos.TabIndex = 0;
            tboxTramos.TabStop = false;
            tboxTramos.TextAlign = HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(366, 67);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 0;
            label5.Text = "tº max.";
            // 
            // tboxEtapas
            // 
            tboxEtapas.BackColor = Color.FromArgb(53, 53, 53);
            tboxEtapas.BorderStyle = BorderStyle.FixedSingle;
            tboxEtapas.Font = new Font("Segoe UI", 11F);
            tboxEtapas.ForeColor = Color.White;
            tboxEtapas.Location = new Point(272, 84);
            tboxEtapas.Name = "tboxEtapas";
            tboxEtapas.ReadOnly = true;
            tboxEtapas.Size = new Size(40, 27);
            tboxEtapas.TabIndex = 0;
            tboxEtapas.TabStop = false;
            tboxEtapas.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(318, 67);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 0;
            label4.Text = "Tramos";
            // 
            // tboxPuntuaciones
            // 
            tboxPuntuaciones.BackColor = Color.FromArgb(53, 53, 53);
            tboxPuntuaciones.BorderStyle = BorderStyle.FixedSingle;
            tboxPuntuaciones.Font = new Font("Segoe UI", 11F);
            tboxPuntuaciones.ForeColor = Color.White;
            tboxPuntuaciones.Location = new Point(272, 37);
            tboxPuntuaciones.Name = "tboxPuntuaciones";
            tboxPuntuaciones.ReadOnly = true;
            tboxPuntuaciones.Size = new Size(279, 27);
            tboxPuntuaciones.TabIndex = 0;
            tboxPuntuaciones.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(271, 67);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 0;
            label3.Text = "Etapas";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(272, 21);
            label1.Name = "label1";
            label1.Size = new Size(259, 15);
            label1.TabIndex = 0;
            label1.Text = "Puntuación: ptos1º, ptos2º,...[ptos Power Stage]";
            // 
            // botonBorraPrueba
            // 
            botonBorraPrueba.BackColor = Color.FromArgb(53, 53, 53);
            botonBorraPrueba.BackgroundImageLayout = ImageLayout.Zoom;
            botonBorraPrueba.Cursor = Cursors.Hand;
            botonBorraPrueba.Enabled = false;
            botonBorraPrueba.FlatStyle = FlatStyle.Flat;
            botonBorraPrueba.ForeColor = Color.Transparent;
            botonBorraPrueba.Location = new Point(647, 76);
            botonBorraPrueba.Name = "botonBorraPrueba";
            botonBorraPrueba.Size = new Size(35, 35);
            botonBorraPrueba.TabIndex = 0;
            botonBorraPrueba.TabStop = false;
            botonBorraPrueba.UseVisualStyleBackColor = false;
            botonBorraPrueba.Click += BotonBorraPrueba_Click;
            // 
            // botonBorraCampeonato
            // 
            botonBorraCampeonato.BackColor = Color.FromArgb(53, 53, 53);
            botonBorraCampeonato.BackgroundImageLayout = ImageLayout.Zoom;
            botonBorraCampeonato.Cursor = Cursors.Hand;
            botonBorraCampeonato.Enabled = false;
            botonBorraCampeonato.FlatStyle = FlatStyle.Flat;
            botonBorraCampeonato.ForeColor = Color.Transparent;
            botonBorraCampeonato.Location = new Point(647, 29);
            botonBorraCampeonato.Name = "botonBorraCampeonato";
            botonBorraCampeonato.Size = new Size(35, 35);
            botonBorraCampeonato.TabIndex = 0;
            botonBorraCampeonato.TabStop = false;
            botonBorraCampeonato.UseVisualStyleBackColor = false;
            botonBorraCampeonato.Click += BotonBorraCampeonato_Click;
            // 
            // botonEditaPrueba
            // 
            botonEditaPrueba.BackColor = Color.FromArgb(53, 53, 53);
            botonEditaPrueba.BackgroundImageLayout = ImageLayout.Zoom;
            botonEditaPrueba.Cursor = Cursors.Hand;
            botonEditaPrueba.Enabled = false;
            botonEditaPrueba.FlatStyle = FlatStyle.Flat;
            botonEditaPrueba.ForeColor = Color.Transparent;
            botonEditaPrueba.Location = new Point(606, 76);
            botonEditaPrueba.Name = "botonEditaPrueba";
            botonEditaPrueba.Size = new Size(35, 35);
            botonEditaPrueba.TabIndex = 0;
            botonEditaPrueba.TabStop = false;
            botonEditaPrueba.UseVisualStyleBackColor = false;
            botonEditaPrueba.Click += BotonEditaPrueba_Click;
            // 
            // botonEditaCampeonato
            // 
            botonEditaCampeonato.BackColor = Color.FromArgb(53, 53, 53);
            botonEditaCampeonato.BackgroundImageLayout = ImageLayout.None;
            botonEditaCampeonato.Cursor = Cursors.Hand;
            botonEditaCampeonato.Enabled = false;
            botonEditaCampeonato.FlatStyle = FlatStyle.Flat;
            botonEditaCampeonato.ForeColor = Color.Transparent;
            botonEditaCampeonato.Location = new Point(606, 29);
            botonEditaCampeonato.Name = "botonEditaCampeonato";
            botonEditaCampeonato.Size = new Size(35, 35);
            botonEditaCampeonato.TabIndex = 0;
            botonEditaCampeonato.TabStop = false;
            botonEditaCampeonato.UseVisualStyleBackColor = false;
            botonEditaCampeonato.Click += BotonEditaCampeonato_Click;
            // 
            // botonNuevaPrueba
            // 
            botonNuevaPrueba.BackColor = Color.FromArgb(53, 53, 53);
            botonNuevaPrueba.BackgroundImageLayout = ImageLayout.Zoom;
            botonNuevaPrueba.Cursor = Cursors.Hand;
            botonNuevaPrueba.Enabled = false;
            botonNuevaPrueba.FlatStyle = FlatStyle.Flat;
            botonNuevaPrueba.ForeColor = Color.Transparent;
            botonNuevaPrueba.Location = new Point(565, 76);
            botonNuevaPrueba.Name = "botonNuevaPrueba";
            botonNuevaPrueba.Size = new Size(35, 35);
            botonNuevaPrueba.TabIndex = 0;
            botonNuevaPrueba.TabStop = false;
            botonNuevaPrueba.UseVisualStyleBackColor = false;
            botonNuevaPrueba.Click += BotonNuevaPrueba_Click;
            // 
            // botonNuevoCampeonato
            // 
            botonNuevoCampeonato.BackColor = Color.FromArgb(53, 53, 53);
            botonNuevoCampeonato.BackgroundImageLayout = ImageLayout.Zoom;
            botonNuevoCampeonato.Cursor = Cursors.Hand;
            botonNuevoCampeonato.Enabled = false;
            botonNuevoCampeonato.FlatStyle = FlatStyle.Flat;
            botonNuevoCampeonato.ForeColor = Color.Transparent;
            botonNuevoCampeonato.Location = new Point(565, 29);
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
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.ForeColor = Color.Lime;
            label2.Location = new Point(6, 65);
            label2.Name = "label2";
            label2.Size = new Size(91, 17);
            label2.TabIndex = 0;
            label2.Text = "Prueba (Rally)";
            // 
            // lblCto
            // 
            lblCto.AutoSize = true;
            lblCto.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblCto.ForeColor = Color.Lime;
            lblCto.Location = new Point(6, 18);
            lblCto.Name = "lblCto";
            lblCto.Size = new Size(86, 17);
            lblCto.TabIndex = 0;
            lblCto.Text = "Campeonato";
            // 
            // comboPruebas
            // 
            comboPruebas.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboPruebas.BackColor = Color.FromArgb(192, 255, 192);
            comboPruebas.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPruebas.Enabled = false;
            comboPruebas.Font = new Font("Segoe UI", 11F);
            comboPruebas.FormattingEnabled = true;
            comboPruebas.Location = new Point(6, 83);
            comboPruebas.MaxLength = 50;
            comboPruebas.Name = "comboPruebas";
            comboPruebas.Size = new Size(260, 28);
            comboPruebas.TabIndex = 2;
            comboPruebas.SelectedIndexChanged += ComboPruebas_SelectedIndexChanged;
            // 
            // comboCampeonatos
            // 
            comboCampeonatos.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboCampeonatos.BackColor = Color.FromArgb(192, 255, 192);
            comboCampeonatos.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCampeonatos.Font = new Font("Segoe UI", 11F);
            comboCampeonatos.FormattingEnabled = true;
            comboCampeonatos.Location = new Point(6, 36);
            comboCampeonatos.MaxLength = 50;
            comboCampeonatos.Name = "comboCampeonatos";
            comboCampeonatos.Size = new Size(260, 28);
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
            panel3.Size = new Size(181, 251);
            panel3.TabIndex = 12;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.avslot_logo;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Dock = DockStyle.Bottom;
            pictureBox1.Location = new Point(0, 127);
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
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 28);
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1264, 728);
            Controls.Add(dataGridInscripcion);
            Controls.Add(panel1);
            Controls.Add(menuMain);
            Controls.Add(statusStripMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuMain;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "rkN RallySlot";
            ((System.ComponentModel.ISupportInitialize)dataGridInscripcion).EndInit();
            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            statusStripMain.ResumeLayout(false);
            statusStripMain.PerformLayout();
            panel1.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBoxCate.ResumeLayout(false);
            groupBoxCate.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBoxCto.ResumeLayout(false);
            groupBoxCto.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridInscripcion;
        private MenuStrip menuMain;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private StatusStrip statusStripMain;
        private ToolStripStatusLabel labelStatus;
        private ToolStripMenuItem salirToolStripMenuItem;
        private Panel panel1;
        private ColoredGroupBox groupBox2;
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
        private GroupBox groupBoxCto;
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
        private TextBox tboxPwrStg;
        private Label label6;
        private CheckBox checkVerificado;
        private ColoredGroupBox groupBoxCate;
        private Button botonBorraCategoria;
        private Label label7;
        private Button botonEditaCategoria;
        private ComboBox comboCategorias;
        private Button botonNuevaCategoria;
        private ColoredGroupBox groupBox4;
        private Button botonNuevaInscripcion;
    }
}