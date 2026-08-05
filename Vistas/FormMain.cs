using Microsoft.EntityFrameworkCore;
using rknRallySlotApp.Datos;
using rknRallySlotApp.Modelos;
using rknRallySlotApp.Utilidades;
using System.ComponentModel;

namespace rknRallySlotApp.Vistas;

public partial class FormMain : Form
{
    #region Miembros Privados, Publicos y Constructor
    //-------------------------------------------------------------------------
    private readonly ToolTip _toolTip = new();

    public int? IdCampeonatoSeleccionado = null;    // ID del campeonato seleccionado (null con selección vacía)
    public int? IdPruebaSeleccionada = null;        // ID de la prueba seleccionada (null con selección vacía)
    public int? IdPilotoSeleccionado = null;        // ID del piloto seleccionado (null con selección vacía)
    public int? IdCocheSeleccionado = null;         // ID del coche seleccionado (null con selección vacía)
    public int? IdCategoriaSeleccionada = null;     // ID de la categoría seleccionada (null con selección vacía)

    public FormMain()
    {
        InitializeComponent();

        // ==========================================
        // inicializar menu y status bar
        // ==========================================
        // Define colores
        Color fondoPrincipal = Color.FromArgb(28, 28, 28);      // Gris muy oscuro 
        Color fondoHover = Color.FromArgb(80, 80, 85);          // Un poco más claro para el ratón
        Color bordeColor = Color.FromArgb(80, 80, 85);          // Un poco más claro para el borde

        var colorTable = new MyColorTable(fondoPrincipal, fondoHover, bordeColor);

        // Aplicar al MenuStrip
        menuMain.Renderer = new ToolStripProfessionalRenderer(colorTable);
        menuMain.BackColor = fondoPrincipal;
        menuMain.ForeColor = Color.White;

        // Aplicar al StatusStrip
        statusStripMain.Renderer = new ToolStripProfessionalRenderer(colorTable);
        statusStripMain.BackColor = fondoPrincipal;
        statusStripMain.ForeColor = Color.White;
        // ==========================================

        // ==========================================
        // inicializamos los botones y tooltips
        BotonesInit();
        ConfigurarToolTips();

        // ==========================================
        // inicializamos los ComboBox
        ComboCampeonatos_Init();
        ComboPruebas_Init();
        ComboPilotos_Init();
        ComboCoches_Init();
        ComboCategorias_Init();

        // ==========================================
        // inicializamos el DataGridView
        dataGridInscripcion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridInscripcion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        dataGridInscripcion.AllowUserToResizeColumns = true;

        // Declarar el menú y la opción
        ContextMenuStrip menuContextualDgvInscripcion = new();
        ToolStripMenuItem opcionBorrarInscripcion = new("Borrar esta Inscripción");

        // Suscribir la opción a un evento Click para definir qué hará
        opcionBorrarInscripcion.Click += (s, args) =>
        {
            // Lógica a ejecutar cuando se haga clic en la opción
            BorrarInscripcion();
        };

        // Añadir la opción al menú contextual
        menuContextualDgvInscripcion.Items.Add(opcionBorrarInscripcion);

        // Suscribir el DataGridView al evento CellMouseUp
        dataGridInscripcion.CellMouseUp += (sender, e) =>
        {
            // Validar que sea un clic derecho y que no se haya hecho clic en las cabeceras (RowIndex -1)
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                // Limpiar selecciones previas y seleccionar la fila actual bajo el ratón
                dataGridInscripcion.ClearSelection();
                dataGridInscripcion.Rows[e.RowIndex].Selected = true;

                // Mostrar el menú contextual exactamente en la posición actual del cursor en la pantalla
                menuContextualDgvInscripcion.Show(Cursor.Position);
            }
        };
        // ==========================================
    }
    //-------------------------------------------------------------------------
    #endregion

    #region Init Botones y Tooltips
    //-------------------------------------------------------------------------
    private void BotonesInit()
    {
        botonNuevoCampeonato.Image = Properties.Resources.new_b.Zoom(botonNuevoCampeonato.Width - 5, botonNuevoCampeonato.Height - 5);
        botonNuevoCampeonato.ImageAlign = ContentAlignment.MiddleCenter;
        botonEditaCampeonato.Image = Properties.Resources.pencil_b.Zoom(botonEditaCampeonato.Width - 5, botonEditaCampeonato.Height - 5);
        botonEditaCampeonato.ImageAlign = ContentAlignment.MiddleCenter;
        botonBorraCampeonato.Image = Properties.Resources.del_r.Zoom(botonBorraCampeonato.Width - 5, botonBorraCampeonato.Height - 5);
        botonBorraCampeonato.ImageAlign = ContentAlignment.MiddleCenter;

        botonNuevaPrueba.Image = Properties.Resources.new_b.Zoom(botonNuevaPrueba.Width - 5, botonNuevaPrueba.Height - 5);
        botonNuevaPrueba.ImageAlign = ContentAlignment.MiddleCenter;
        botonEditaPrueba.Image = Properties.Resources.pencil_b.Zoom(botonEditaPrueba.Width - 5, botonEditaPrueba.Height - 5);
        botonEditaPrueba.ImageAlign = ContentAlignment.MiddleCenter;
        botonBorraPrueba.Image = Properties.Resources.del_r.Zoom(botonBorraPrueba.Width - 5, botonBorraPrueba.Height - 5);
        botonBorraPrueba.ImageAlign = ContentAlignment.MiddleCenter;

        botonNuevoPiloto.Image = Properties.Resources.helmetN_v.Zoom(botonNuevoPiloto.Width - 5, botonNuevoPiloto.Height - 5);
        botonNuevoPiloto.ImageAlign = ContentAlignment.MiddleCenter;
        botonEditaPiloto.Image = Properties.Resources.pencil_v.Zoom(botonEditaPiloto.Width - 5, botonEditaPiloto.Height - 5);
        botonEditaPiloto.ImageAlign = ContentAlignment.MiddleCenter;
        botonBorraPiloto.Image = Properties.Resources.del_r.Zoom(botonBorraPiloto.Width - 5, botonBorraPiloto.Height - 5);
        botonBorraPiloto.ImageAlign = ContentAlignment.MiddleCenter;

        botonNuevoCoche.Image = Properties.Resources.carN_g.Zoom(botonNuevoCoche.Width - 5, botonNuevoCoche.Height - 5);
        botonNuevoCoche.ImageAlign = ContentAlignment.MiddleCenter;
        botonEditaCoche.Image = Properties.Resources.pencil_g.Zoom(botonEditaCoche.Width - 5, botonEditaCoche.Height - 5);
        botonEditaCoche.ImageAlign = ContentAlignment.MiddleCenter;
        botonBorraCoche.Image = Properties.Resources.del_r.Zoom(botonBorraCoche.Width - 5, botonBorraCoche.Height - 5);
        botonBorraCoche.ImageAlign = ContentAlignment.MiddleCenter;

        botonNuevaCategoria.Image = Properties.Resources.inglesaN_o.Zoom(botonNuevaCategoria.Width - 5, botonNuevaCategoria.Height - 5);
        botonNuevaCategoria.ImageAlign = ContentAlignment.MiddleCenter;
        botonEditaCategoria.Image = Properties.Resources.pencil_o.Zoom(botonEditaCategoria.Width - 5, botonEditaCategoria.Height - 5);
        botonEditaCategoria.ImageAlign = ContentAlignment.MiddleCenter;
        botonBorraCategoria.Image = Properties.Resources.del_r.Zoom(botonBorraCategoria.Width - 5, botonBorraCategoria.Height - 5);
        botonBorraCategoria.ImageAlign = ContentAlignment.MiddleCenter;
    }

    private void ConfigurarToolTips()
    {
        _toolTip.SetToolTip(botonNuevoCampeonato, "Nuevo Campeonato");
        _toolTip.SetToolTip(botonEditaCampeonato, "Modificar Campeonato");
        _toolTip.SetToolTip(botonBorraCampeonato, "Borrar Campeonato");

        _toolTip.SetToolTip(botonNuevaPrueba, "Nueva Prueba");
        _toolTip.SetToolTip(botonEditaPrueba, "Modificar Prueba");
        _toolTip.SetToolTip(botonBorraPrueba, "Borrar Prueba");

        _toolTip.SetToolTip(botonNuevoPiloto, "Nuevo Piloto");
        _toolTip.SetToolTip(botonEditaPiloto, "Modificar Piloto");
        _toolTip.SetToolTip(botonBorraPiloto, "Borrar Piloto");

        _toolTip.SetToolTip(botonNuevoCoche, "Nuevo Coche");
        _toolTip.SetToolTip(botonEditaCoche, "Modificar Coche");
        _toolTip.SetToolTip(botonBorraCoche, "Borrar Coche");

        _toolTip.SetToolTip(botonNuevaCategoria, "Nueva Categoría");
        _toolTip.SetToolTip(botonEditaCategoria, "Modificar Categoría");
        _toolTip.SetToolTip(botonBorraCategoria, "Borrar Categoría");

        _toolTip.SetToolTip(botonNuevaInscripcion, "Inscribir Piloto");
    }
    //-------------------------------------------------------------------------
    #endregion

    #region ComboBox Inits
    //-------------------------------------------------------------------------
    private void ComboCampeonatos_Init()
    {
        // Desconectamos el evento para evitar que se dispare durante la inicialización
        comboCampeonatos.SelectedIndexChanged -= ComboCampeonatos_SelectedIndexChanged;

        try
        {
            using var db = new AppDbContext();

            // Obtenemos la lista de campeonatos desde la base de datos
            var listaCampeonatos = db.Campeonatos
                .Select(c => new { c.Id, c.Nombre })
                .OrderBy(c => c.Nombre)
                .ToList();

            // Agregamos un elemento "comodín" al final de la lista
            listaCampeonatos.Add(new { Id = -5, Nombre = "- Añadir nuevo -" });

            // Asignamos la lista al ComboBox
            comboCampeonatos.DataSource = listaCampeonatos;
            comboCampeonatos.DisplayMember = "Nombre";
            comboCampeonatos.ValueMember = "Id";
        }
        finally
        {
            // Reconectamos el evento después de la inicialización
            comboCampeonatos.SelectedIndexChanged += ComboCampeonatos_SelectedIndexChanged;
            // Dejar Selección Vacia
            comboCampeonatos.SelectedIndex = -1;
        }
    }

    private void ComboPruebas_Init()
    {
        if (comboCampeonatos.SelectedValue is not int idCto || idCto <= 0)    //SIN Campeonato válido salir
        {
            comboPruebas.DataSource = null;     // Limpiamos el ComboBox 
            comboPruebas.SelectedIndex = -1;    // Dejar Selección Vacia
            return;
        }

        // Desconectamos el evento para evitar que se dispare durante la inicialización
        comboPruebas.SelectedIndexChanged -= ComboPruebas_SelectedIndexChanged;

        try
        {
            using var db = new AppDbContext();

            // Obtenemos la lista de pruebas desde DB filtrando por el campeonato seleccionado
            var listaPruebas = db.Pruebas
                .Where(p => p.IdCampeonato == idCto)
                .Select(p => new { p.Id, p.Nombre })
                .OrderBy(p => p.Nombre)
                .ToList();

            // Agregamos un elemento "comodín" al final de la lista
            listaPruebas.Add(new { Id = -5, Nombre = "- Añadir nuevo -" });

            // Asignamos la lista al ComboBox
            comboPruebas.DataSource = listaPruebas;
            comboPruebas.DisplayMember = "Nombre";
            comboPruebas.ValueMember = "Id";
        }
        finally
        {
            // Reconectamos el evento después de la inicialización
            comboPruebas.SelectedIndexChanged += ComboPruebas_SelectedIndexChanged;
            // Dejar Selección Vacia
            comboPruebas.SelectedIndex = -1;
        }
    }

    private void ComboPilotos_Init()
    {
        // Desconectamos el evento para evitar que se dispare durante la inicialización
        comboPilotos.SelectedIndexChanged -= ComboPilotos_SelectedIndexChanged;

        try
        {
            using var db = new AppDbContext();

            // Obtenemos la lista de pilotos desde DB
            var listaPilotos = db.Pilotos
                .Select(p => new { p.Id, p.Nombre })
                .OrderBy(p => p.Nombre)
                .ToList();

            // Agregamos un elemento "comodín" al final de la lista
            listaPilotos.Add(new { Id = -5, Nombre = "- Añadir nuevo -" });

            // Asignamos la lista al ComboBox
            comboPilotos.DataSource = listaPilotos;
            comboPilotos.DisplayMember = "Nombre";
            comboPilotos.ValueMember = "Id";
        }
        finally
        {
            // Reconectamos el evento después de la inicialización
            comboPilotos.SelectedIndexChanged += ComboPilotos_SelectedIndexChanged;
            // Dejar Selección Vacia
            comboPilotos.SelectedIndex = -1;
        }
    }

    private void ComboCoches_Init()
    {
        // Desconectamos el evento para evitar que se dispare durante la inicialización
        comboCoches.SelectedIndexChanged -= ComboCoches_SelectedIndexChanged;

        try
        {
            using var db = new AppDbContext();

            // Obtenemos la lista de coches desde DB
            var listaCoches = db.Coches
                .OrderBy(c => c.Modelo)
                .ThenBy(c => c.Marca)
                .AsEnumerable()             // Pasamos a memoria para poder usar propiedades [NotMapped] si es necesario
                .Select(c => new { c.Id, c.DescripcionCompleta })
                .ToList();

            // Agregamos un elemento "comodín" al final de la lista
            listaCoches.Add(new { Id = -5, DescripcionCompleta = "- Añadir nuevo -" });

            // Asignamos la lista al ComboBox
            comboCoches.DataSource = listaCoches;
            comboCoches.DisplayMember = "DescripcionCompleta";
            comboCoches.ValueMember = "Id";
        }
        finally
        {
            // Reconectamos el evento después de la inicialización
            comboCoches.SelectedIndexChanged += ComboCoches_SelectedIndexChanged;
            // Dejar Selección Vacia
            comboCoches.SelectedIndex = -1;
        }
    }

    private void ComboCategorias_Init()
    {
        // Desconectamos el evento para evitar que se dispare durante la inicialización
        comboCategorias.SelectedIndexChanged -= ComboCategorias_SelectedIndexChanged;

        try
        {
            using var db = new AppDbContext();

            // Obtenemos la lista de coches desde DB
            var listaCategorias = db.Categorias
                .Select(c => new { c.Id, c.Nombre })
                .OrderBy(c => c.Nombre)
                .ToList();

            // Agregamos un elemento "comodín" al final de la lista
            listaCategorias.Add(new { Id = -5, Nombre = "- Añadir nueva -" });

            // Asignamos la lista al ComboBox
            comboCategorias.DataSource = listaCategorias;
            comboCategorias.DisplayMember = "Nombre";
            comboCategorias.ValueMember = "Id";
        }
        finally
        {
            // Reconectamos el evento después de la inicialización
            comboCategorias.SelectedIndexChanged += ComboCategorias_SelectedIndexChanged;
            // Dejar Selección Vacia
            comboCategorias.SelectedIndex = -1;
        }
    }

    //-------------------------------------------------------------------------
    #endregion

    #region Rellenar y Limpiar TextBox
    //-------------------------------------------------------------------------
    private void Rellena_DatosCampeonato()
    {
        using var db = new AppDbContext();

        var puntos = db.Campeonatos
                     .Where(c => c.Id == IdCampeonatoSeleccionado)
                     .Select(c => c.SistemaPuntuacion)
                     .FirstOrDefault();

        tboxPuntuaciones.Text = string.IsNullOrEmpty(puntos) ? "NO definido" : puntos;
    }

    private void Rellena_DatosPrueba()
    {
        using var db = new AppDbContext();

        var prueba = db.Pruebas
                            .Where(p => p.Id == IdPruebaSeleccionada)
                            .Select(p => new
                            {
                                p.NumEtapas,
                                p.TramosPorEtapa,
                                p.TiempoMaximo,
                                p.PowerStage
                            })
                            .FirstOrDefault();

        if (prueba != null)
        {
            tboxEtapas.Text = prueba.NumEtapas.ToString() ?? "NO def.";
            tboxTramos.Text = prueba.TramosPorEtapa.ToString() ?? "NO def.";
            tboxTmax.Text = prueba.TiempoMaximo.ToString() ?? "NO def.";
            tboxPwrStg.Text = prueba.PowerStage ?? string.Empty;
        }
        else
        {
            Limpia_DatosPrueba();
        }
    }

    private void Rellena_DatosPiloto()
    {
        using var db = new AppDbContext();

        var piloto = db.Pilotos
                            .Where(p => p.Id == IdPilotoSeleccionado)
                            .Select(p => new
                            {
                                p.Alias,
                                p.Escuderia,
                            })
                            .FirstOrDefault();

        if (piloto != null)
        {
            tboxAlias.Text = piloto.Alias ?? String.Empty;
            tboxEscuderia.Text = piloto.Escuderia ?? String.Empty;
        }
        else
        {
            Limpia_DatosPiloto();
        }
    }

    private void Rellena_DatosCoche()
    {
        using var db = new AppDbContext();

        var marca = db.Coches
                    .Where(c => c.Id == IdCocheSeleccionado)
                    .Select(c => c.Marca)
                    .FirstOrDefault();

        tboxMarca.Text = marca ?? String.Empty;
    }

    private void Colorear_Categoria()
    {
        using var db = new AppDbContext();

        var colorFondo = db.Categorias
                        .Where(c => c.Id == IdCategoriaSeleccionada)
                        .Select(c => c.ColorHex)
                        .FirstOrDefault();

        comboCategorias.BackColor = ColorTranslator.FromHtml(colorFondo ?? "#FFFFFF");
        comboCategorias.ForeColor = ColorTools.GetBestContrast(comboCategorias.BackColor);
    }

    private void Limpia_DatosCampeonato()
    {
        tboxPuntuaciones.Clear();
    }

    private void Limpia_DatosPrueba()
    {
        tboxEtapas.Clear();
        tboxTramos.Clear();
        tboxTmax.Clear();
        tboxPwrStg.Clear();
    }

    private void Limpia_DatosPiloto()
    {
        tboxAlias.Clear();
        tboxEscuderia.Clear();
    }

    private void Limpia_DatosCoche()
    {
        tboxMarca.Clear();
    }

    private void Limpiar_Color_Categoria()
    {
        comboCategorias.BackColor = SystemColors.Window;
        comboCategorias.ForeColor = SystemColors.WindowText;
    }
    //-------------------------------------------------------------------------
    #endregion

    #region SelectedIndexChanged Events    
    //-------------------------------------------------------------------------
    private void Controles_EnableAndDisable()
    {
        // Evaluamos el estado de cada ComboBox
        bool hayCampeonato = comboCampeonatos.SelectedValue is int idCto && idCto > 0;
        bool hayPrueba = comboPruebas.SelectedValue is int idPrueba && idPrueba > 0;
        bool hayPiloto = comboPilotos.SelectedValue is int idPiloto && idPiloto > 0;
        bool hayCoche = comboCoches.SelectedValue is int idCoche && idCoche > 0;
        bool hayCategoria = comboCategorias.SelectedValue is int idCategoria && idCategoria > 0;

        // Estados comboBox
        comboCampeonatos.Enabled = true;            // Siempre habilitado
        comboPruebas.Enabled = hayCampeonato;       // Habilitado solo si hay campeonato seleccionado
        comboPilotos.Enabled = true;                // Siempre habilitado
        comboCoches.Enabled = true;                 // Siempre habilitado
        comboCategorias.Enabled = true;             // Siempre habilitado

        // Asignamos los estados a los botones
        // Campeonato
        botonNuevoCampeonato.Enabled = true;
        botonEditaCampeonato.Enabled = hayCampeonato;
        botonBorraCampeonato.Enabled = hayCampeonato;

        // Prueba (Nueva Prueba depende de Campeonato, Edición y Borrado de Prueba)
        botonNuevaPrueba.Enabled = hayCampeonato;
        botonEditaPrueba.Enabled = hayPrueba;
        botonBorraPrueba.Enabled = hayPrueba;

        // Piloto
        botonNuevoPiloto.Enabled = true;
        botonEditaPiloto.Enabled = hayPiloto;
        botonBorraPiloto.Enabled = hayPiloto;

        // Coche
        botonNuevoCoche.Enabled = true;
        botonEditaCoche.Enabled = hayCoche;
        botonBorraCoche.Enabled = hayCoche;

        // Categoría
        botonNuevaCategoria.Enabled = true;
        botonEditaCategoria.Enabled = hayCategoria;
        botonBorraCategoria.Enabled = hayCategoria;

        // Inscripción
        botonNuevaInscripcion.Enabled = hayPrueba && hayPiloto && hayCoche && hayCategoria;
        botonNuevaInscripcion.BackColor = botonNuevaInscripcion.Enabled ? Color.FromArgb(53, 53, 53) : Color.FromArgb(40, 40, 40);
        botonNuevaInscripcion.ForeColor = botonNuevaInscripcion.Enabled ? Color.FromArgb(0, 255, 0) : Color.FromArgb(18, 18, 24);

        checkVerificado.Enabled = hayPrueba && hayPiloto && hayCoche && hayCategoria;

        if (!botonNuevaInscripcion.Enabled)
        {
            checkVerificado.Checked = false; // Desmarcar si no hay inscripción válida
        }
    }

    private void ComboCampeonatos_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (comboCampeonatos.SelectedValue is int idSel)
        {
            if (idSel > 0)                              // Selección Válida 
            {
                IdCampeonatoSeleccionado = idSel;       // guardar ID en miembro público
                Rellena_DatosCampeonato();              // consulta DB para rellenar TextBox

                comboPruebas.SelectedIndex = -1;        // Limpiar selección Pruebas
                IdPruebaSeleccionada = null;            // Limpiar ID Prueba 
                Limpia_DatosPrueba();                   // Limpiar TextBox datos Prueba

                ComboPruebas_Init();                     // Init ComboBox Pruebas para Campeonato seleccionado
            }
            else                                        // ID inválido, limpiar selecciones y TextBox
            {
                comboCampeonatos.SelectedIndex = -1;    // Limpiar selección Campeonatos
                IdCampeonatoSeleccionado = null;        // Limpiar ID Campeonato 
                Limpia_DatosCampeonato();               // Limpiar TextBox datos Campeonato

                comboPruebas.SelectedIndex = -1;        // Limpiar selección Pruebas
                IdPruebaSeleccionada = null;            // Limpiar ID Prueba 
                Limpia_DatosPrueba();                   // Limpiar TextBox datos Prueba

                if (idSel == -5)                        // opcion "- Añadir nuevo -" seleccionada, abrir formulario de alta
                {
                    botonNuevoCampeonato.PerformClick();    // Simulamos click en el botón de NUEVO Campeonato      
                }
            }
        }
        Controles_EnableAndDisable();       // Actualizamos los controles después de la operación
        DataGridInscripcion_Init();          // consulta DB para rellenar DataGridView Inscripciones
    }

    private void ComboPruebas_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (comboPruebas.SelectedValue is int idSel)
        {
            if (idSel > 0)                              // Selección Válida 
            {
                IdPruebaSeleccionada = idSel;           // guardar ID en miembro público
                Rellena_DatosPrueba();                  // consulta DB para rellenar TextBox
            }
            else                                        // ID inválido, limpiar selecciones y TextBox
            {
                comboPruebas.SelectedIndex = -1;        // Limpiar selección Pruebas
                IdPruebaSeleccionada = null;            // Limpiar ID Prueba 
                Limpia_DatosPrueba();                   // Limpiar TextBox datos Prueba

                if (idSel == -5)                        // opcion "- Añadir nuevo -" seleccionada, abrir formulario de alta
                {
                    botonNuevaPrueba.PerformClick();    // Simulamos click en el botón de NUEVA Prueba      
                }
            }
        }
        Controles_EnableAndDisable();       // Actualizamos los controles después de la operación
        DataGridInscripcion_Init();          // consulta DB para rellenar DataGridView Inscripciones
    }

    private void ComboPilotos_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (comboPilotos.SelectedValue is int idSel)
        {
            if (idSel > 0)                              // Selección Válida 
            {
                IdPilotoSeleccionado = idSel;           // guardar ID en miembro público
                Rellena_DatosPiloto();                  // consulta DB para rellenar TextBox
            }
            else                                        // ID inválido, limpiar selecciones y TextBox
            {
                comboPilotos.SelectedIndex = -1;        // Limpiar selección Pilotos
                IdPilotoSeleccionado = null;            // Limpiar ID Piloto 
                Limpia_DatosPiloto();                   // Limpiar TextBox datos Piloto

                if (idSel == -5)                        // opcion "- Añadir nuevo -" seleccionada, abrir formulario de alta
                {
                    botonNuevoPiloto.PerformClick();    // Simulamos click en el botón de NUEVO Piloto      
                }
            }
        }
        Controles_EnableAndDisable();                   // Actualizamos los controles después de la operación
    }

    private void ComboCoches_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (comboCoches.SelectedValue is int idSel)
        {
            if (idSel > 0)                              // Selección Válida 
            {
                IdCocheSeleccionado = idSel;            // guardar ID en miembro público
                Rellena_DatosCoche();                   // consulta DB para rellenar TextBox
            }
            else                                        // ID inválido, limpiar selecciones y TextBox
            {
                comboCoches.SelectedIndex = -1;         // Limpiar selección Coches
                IdCocheSeleccionado = null;             // Limpiar ID Coche 
                Limpia_DatosCoche();                    // Limpiar TextBox datos Coche

                if (idSel == -5)                        // opcion "- Añadir nuevo -" seleccionada, abrir formulario de alta
                {
                    botonNuevoCoche.PerformClick();     // Simulamos click en el botón de NUEVO Coche      
                }
            }
        }
        Controles_EnableAndDisable();                   // Actualizamos los controles después de la operación
    }

    private void ComboCategorias_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (comboCategorias.SelectedValue is int idSel)
        {
            if (idSel > 0)                              // Selección Válida 
            {
                IdCategoriaSeleccionada = idSel;        // guardar ID en miembro público
                Colorear_Categoria();                   // consulta DB para colorear comboBox Categorías
            }
            else                                        // ID inválido, limpiar selecciones y Colores
            {
                comboCategorias.SelectedIndex = -1;     // Limpiar selección Categorías
                IdCategoriaSeleccionada = null;         // Limpiar ID Categoría 
                Limpiar_Color_Categoria();              // Limpiar Color comboBox Categorías

                if (idSel == -5)                        // opcion "- Añadir nueva -" seleccionada, abrir formulario de alta
                {
                    botonNuevaCategoria.PerformClick(); // Simulamos click en el botón de NUEVA Categoría      
                }
            }
        }
        Controles_EnableAndDisable();                   // Actualizamos los controles después de la operación
    }

    //-------------------------------------------------------------------------
    #endregion

    #region Botones Nuevo
    //-------------------------------------------------------------------------
    private void BotonNuevoCampeonato_Click(object sender, EventArgs e)
    {
        // Guardamos los valores actuales por si el usuario cancela la operación
        var valorCtoSiCancela = (comboCampeonatos.SelectedValue is int idCto && idCto > 0) ? idCto : -1;
        var valorPruebaSiCancela = (comboPruebas.SelectedValue is int idPrueba && idPrueba > 0) ? idPrueba : -1;

        comboCampeonatos.SelectedIndex = -1;    // Limpiar la selección para el ALTA y evitar confusión 
        Limpia_DatosCampeonato();               // Limpiar TextBox
        comboPruebas.SelectedIndex = -1;        // Limpiar la selección para el ALTA y evitar confusión 
        Limpia_DatosPrueba();                   // Limpiar TextBox 

        using var formAlta = new FormCampeonato("Nuevo Campeonato");

        formAlta.StartPosition = FormStartPosition.Manual;
        formAlta.Location = groupBoxCto.PointToScreen(new Point(12, 8));

        if (formAlta.ShowDialog(this) == DialogResult.OK)
        {
            ComboCampeonatos_Init();                                         // Si el usuario guardó con éxito, refrescamos combo
            comboCampeonatos.SelectedValue = formAlta.IdSelected ?? -1;     // seleccionamos el nuevo campeonato creado
            MostrarMensajeEstado("Campeonato creado OK");
        }
        else
        {
            comboCampeonatos.SelectedValue = valorCtoSiCancela;             // Restauramos el valor anterior si el usuario cancela
            comboPruebas.SelectedValue = valorPruebaSiCancela;              // Restauramos el valor anterior si el usuario cancela
            MostrarMensajeEstado("Operacion Cancelada");
        }
    }

    private void BotonNuevaPrueba_Click(object sender, EventArgs e)
    {
        // Guardamos los valores actuales por si el usuario cancela la operación
        var valorPruebaSiCancela = (comboPruebas.SelectedValue is int idPrueba && idPrueba > 0) ? idPrueba : -1;

        comboPruebas.SelectedIndex = -1;    // Limpiar la selección para el ALTA y evitar confusión 
        Limpia_DatosPrueba();               // Limpiar TextBox 

        using var formAlta = new FormPrueba("Nueva Prueba");

        formAlta.StartPosition = FormStartPosition.Manual;
        formAlta.Location = groupBoxCto.PointToScreen(new Point(12, 8));

        if (formAlta.ShowDialog(this) == DialogResult.OK)
        {
            ComboPruebas_Init();                                         // Si el usuario guardó con éxito, refrescamos combo
            comboPruebas.SelectedValue = formAlta.IdSelected ?? -1;     // seleccionamos la nueva prueba creada
            MostrarMensajeEstado("Prueba creada OK");
        }
        else
        {
            comboPruebas.SelectedValue = valorPruebaSiCancela;       // Restauramos el valor anterior si el usuario cancela
            MostrarMensajeEstado("Operacion Cancelada");
        }
    }

    private void BotonNuevoPiloto_Click(object sender, EventArgs e)
    {
        // Guardamos el valor actual por si el usuario cancela la operación
        var valorPilotoSiCancela = (comboPilotos.SelectedValue is int idPiloto && idPiloto > 0) ? idPiloto : -1;

        comboPilotos.SelectedIndex = -1;    // Limpiar la selección para el ALTA y evitar confusión
        Limpia_DatosPiloto();               // Limpiar TextBox 

        using var formAlta = new FormPiloto("Nuevo Piloto");

        formAlta.StartPosition = FormStartPosition.Manual;
        formAlta.Location = groupBoxCto.PointToScreen(new Point(12, 8));

        if (formAlta.ShowDialog(this) == DialogResult.OK)
        {
            ComboPilotos_Init();                                         // Si el usuario guardó con éxito, refrescamos combo
            comboPilotos.SelectedValue = formAlta.IdSelected ?? -1;     // seleccionamos el nuevo piloto creado
            MostrarMensajeEstado("Piloto creado OK");
        }
        else
        {
            comboPilotos.SelectedValue = valorPilotoSiCancela;          // Restauramos el valor anterior si el usuario cancela
            MostrarMensajeEstado("Operacion Cancelada");
        }
    }

    private void BotonNuevoCoche_Click(object sender, EventArgs e)
    {
        // Guardamos el valor actual por si el usuario cancela la operación
        var valorCocheSiCancela = (comboCoches.SelectedValue is int idCoche && idCoche > 0) ? idCoche : -1;

        comboCoches.SelectedIndex = -1;     // Limpiar la selección para el ALTA y evitar confusión 
        Limpia_DatosCoche();                // Limpiar TextBox 

        using var formAlta = new FormCoche("Nuevo Coche");

        formAlta.StartPosition = FormStartPosition.Manual;
        formAlta.Location = groupBoxCto.PointToScreen(new Point(12, 8));

        if (formAlta.ShowDialog(this) == DialogResult.OK)
        {
            ComboCoches_Init();                                          // Si el usuario guardó con éxito, refrescamos combo
            comboCoches.SelectedValue = formAlta.IdSelected ?? -1;      // seleccionamos el nuevo coche creado
            MostrarMensajeEstado("Coche creado OK");
        }
        else
        {
            comboCoches.SelectedValue = valorCocheSiCancela;            // Restauramos el valor anterior si el usuario cancela
            MostrarMensajeEstado("Operacion Cancelada");
        }
    }

    private void BotonNuevaCategoria_Click(object sender, EventArgs e)
    {
        // Guardamos el valor actual por si el usuario cancela la operación
        var valorCategoriaSiCancela = (comboCategorias.SelectedValue is int idCategoria && idCategoria > 0) ? idCategoria : -1;

        comboCategorias.SelectedIndex = -1;     // Limpiar la selección para el ALTA y evitar confusión 

        using var formAlta = new FormCategoria("Nueva Categoria");

        formAlta.StartPosition = FormStartPosition.Manual;
        formAlta.Location = groupBoxCate.PointToScreen(new Point(0, 0));

        if (formAlta.ShowDialog(this) == DialogResult.OK)
        {
            ComboCategorias_Init();                                          // Si el usuario guardó con éxito, refrescamos combo
            comboCategorias.SelectedValue = formAlta.IdSelected ?? -1;      // seleccionamos la nueva categoria creada
            MostrarMensajeEstado("Categoria creada OK");
        }
        else
        {
            comboCategorias.SelectedValue = valorCategoriaSiCancela;            // Restauramos el valor anterior si el usuario cancela
            MostrarMensajeEstado("Operacion Cancelada");
        }
    }

    private void BotonNuevaInscripcion_Click(object sender, EventArgs e)
    {
        bool hayPrueba = IdPruebaSeleccionada.HasValue && IdPruebaSeleccionada.Value > 0;
        bool hayPiloto = IdPilotoSeleccionado.HasValue && IdPilotoSeleccionado.Value > 0;
        bool hayCoche = IdCocheSeleccionado.HasValue && IdCocheSeleccionado.Value > 0;
        bool hayCategoria = IdCategoriaSeleccionada.HasValue && IdCategoriaSeleccionada.Value > 0;

        if (!hayPrueba || !hayPiloto || !hayCoche || !hayCategoria)
        {
            MessageBox.Show("Por favor, seleccione todos los campos requeridos.",
                            "Campos Incompletos",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
            return;
        }

        // Variables locales con los IDs seleccionados
        int idPruebaActual = IdPruebaSeleccionada!.Value;
        int idPilotoActual = IdPilotoSeleccionado!.Value;
        int idCocheActual = IdCocheSeleccionado!.Value;
        int idCategoriaActual = IdCategoriaSeleccionada!.Value;
        bool verificadoActual = checkVerificado.Checked;

        // DBContext para realizar las operaciones de base de datos
        using var db = new AppDbContext();

        // Comprobamos si ya existe una inscripción para ese piloto en esa prueba
        bool yaInscrito = db.Inscripciones.Any(i =>
            i.IdPrueba == idPruebaActual &&
            i.IdPiloto == idPilotoActual
        );

        if (yaInscrito)
        {
            MessageBox.Show(
                "Este piloto ya se encuentra inscrito en esta prueba.",
                "Aviso de Inscripción Duplicada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
            return; // Cancelamos el proceso de alta
        }

        // Obtenemos el dorsal más alto registrado para esta prueba específica
        int maxDorsal = db.Inscripciones
            .Where(i => i.IdPrueba == idPruebaActual)
            .Select(i => (int?)i.Dorsal)    // Proyectamos a int? (nullable) por seguridad
            .Max() ?? 0;                    // Si devuelve null (no hay inscripciones), asigna 0 por defecto

        try
        {
            Inscripcion inscripcionActual = new()
            {
                IdPrueba = idPruebaActual,
                IdPiloto = idPilotoActual,
                IdCoche = idCocheActual,
                IdCategoria = idCategoriaActual,
                Dorsal = maxDorsal + 1,                 // Asignamos el siguiente dorsal disponible
                Verificado = verificadoActual
            };

            db.Inscripciones.Add(inscripcionActual);    // Añadir registro nuevo (INSERT)
            db.SaveChanges();                           // ALTA en fichero DB

            DataGridInscripcion_Init();             // Refrescamos el DataGridView para mostrar la nueva inscripción
            comboPilotos.SelectedIndex = -1;        // Limpiar selección Pilotos
            comboCoches.SelectedIndex = -1;         // Limpiar selección Coches
            comboCategorias.SelectedIndex = -1;     // Limpiar selección Categorías

            MostrarMensajeEstado("Inscripción registrada OK");
        }
        catch (DbUpdateException ex)
        {
            MessageBox.Show($"Error al guardar en la base de datos: {ex.Message}",
                            "Error de Persistencia",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
    }
    //-------------------------------------------------------------------------
    #endregion

    #region Botones Editar 
    //-------------------------------------------------------------------------
    private void BotonEditaCampeonato_Click(object sender, EventArgs e)
    {
        using var formEdicion = new FormCampeonato("Modificar Campeonato", comboCampeonatos.SelectedValue);

        formEdicion.StartPosition = FormStartPosition.Manual;
        formEdicion.Location = groupBoxCto.PointToScreen(new Point(12, 8));

        if (formEdicion.ShowDialog(this) == DialogResult.OK)
        {
            var valorPruebaPorsi = (comboPruebas.SelectedValue is int idPrueba && idPrueba > 0) ? idPrueba : -1;

            ComboCampeonatos_Init();                                         // Si el usuario guardó con éxito, refrescamos este combo
            comboCampeonatos.SelectedValue = formEdicion.IdSelected ?? -1;  // seleccionamos el campeonato editado o ninguno si es null
            comboPruebas.SelectedValue = valorPruebaPorsi;                  // Restauramos la selección de prueba anterior
            MostrarMensajeEstado("Campeonato modificado OK");
        }
    }

    private void BotonEditaPrueba_Click(object sender, EventArgs e)
    {
        using var formEdicion = new FormPrueba("Modificar Prueba", comboPruebas.SelectedValue);

        formEdicion.StartPosition = FormStartPosition.Manual;
        formEdicion.Location = groupBoxCto.PointToScreen(new Point(12, 8));

        if (formEdicion.ShowDialog(this) == DialogResult.OK)
        {
            ComboPruebas_Init();                                         // Si el usuario guardó con éxito, refrescamos este combo
            comboPruebas.SelectedValue = formEdicion.IdSelected ?? -1;  // seleccionamos la prueba editada o ninguna si es null
            MostrarMensajeEstado("Prueba modificada OK");
        }
    }

    private void BotonEditaPiloto_Click(object sender, EventArgs e)
    {
        using var formEdicion = new FormPiloto("Modificar Piloto", comboPilotos.SelectedValue);

        formEdicion.StartPosition = FormStartPosition.Manual;
        formEdicion.Location = groupBoxCto.PointToScreen(new Point(12, 8));

        if (formEdicion.ShowDialog(this) == DialogResult.OK)
        {
            ComboPilotos_Init();                                             // Si el usuario guardó con éxito, refrescamos este combo
            comboPilotos.SelectedValue = formEdicion.IdSelected ?? -1;      // seleccionamos el piloto editado o ninguno si es null
            MostrarMensajeEstado("Piloto modificado OK");
            DataGridInscripcion_Init();
        }
    }

    private void BotonEditaCoche_Click(object sender, EventArgs e)
    {
        using var formEdicion = new FormCoche("Modificar Coche", comboCoches.SelectedValue);

        formEdicion.StartPosition = FormStartPosition.Manual;
        formEdicion.Location = groupBoxCto.PointToScreen(new Point(12, 8));

        if (formEdicion.ShowDialog(this) == DialogResult.OK)
        {
            ComboCoches_Init();                                              // Si el usuario guardó con éxito, refrescamos este combo
            comboCoches.SelectedValue = formEdicion.IdSelected ?? -1;       // seleccionamos el coche editado o ninguno si es null
            MostrarMensajeEstado("Coche modificado OK");
            DataGridInscripcion_Init();
        }
    }

    private void BotonEditaCategoria_Click(object sender, EventArgs e)
    {
        using var formEdicion = new FormCategoria("Modificar Categoria", comboCategorias.SelectedValue);

        formEdicion.StartPosition = FormStartPosition.Manual;
        formEdicion.Location = groupBoxCate.PointToScreen(new Point(0, 0));

        if (formEdicion.ShowDialog(this) == DialogResult.OK)
        {
            ComboCategorias_Init();                                             // Si el usuario guardó con éxito, refrescamos este combo
            comboCategorias.SelectedValue = formEdicion.IdSelected ?? -1;      // seleccionamos la categoria editada o ninguna si es null
            MostrarMensajeEstado("Categoria modificada OK");
            DataGridInscripcion_Init();
        }
    }
    //-------------------------------------------------------------------------
    #endregion

    #region Botones Borrar 
    //-------------------------------------------------------------------------
    private void BotonBorraCampeonato_Click(object sender, EventArgs e)
    {
        // Validar ID campeonato seleccionado en ComboBox
        if (comboCampeonatos.SelectedValue is not int idSel || idSel <= 0)
        {
            MostrarMensajeEstado("Selecciona campeonato válido");
            return;
        }

        // Confirmación usuario 
        DialogResult confirmacion = MessageBox.Show(
            $"¿Estás seguro de que deseas eliminar este campeonato?\n\nEsta acción no se podrá deshacer.",
            "Confirmar eliminación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

        if (confirmacion == DialogResult.Yes)
        {
            try
            {
                using var db = new AppDbContext();                  // Contexto DB
                var ctoParaBorrado = db.Campeonatos.Find(idSel);    // DB, buscar por ID

                if (ctoParaBorrado != null)
                {
                    db.Campeonatos.Remove(ctoParaBorrado);      // DB, marcar para borrado
                    db.SaveChanges();                           // SQLite, guardar cambios 

                    Limpia_DatosCampeonato();                   // Limpiar TextBox 
                    ComboCampeonatos_Init();                     // Actualizar interfaz

                    Limpia_DatosPrueba();                       // Limpiar TextBox 
                    ComboPruebas_Init();                         // Actualizar interfaz

                    MostrarMensajeEstado("Campeonato borrado OK");
                }
                else
                {
                    MostrarMensajeEstado("Campeonato NO existe");
                }
            }
            catch (DbUpdateException)
            {
                // Control de integridad referencial
                MessageBox.Show("No se puede eliminar el campeonato porque tiene pruebas o inscripciones asociadas.\n" +
                                "Elimina primero las pruebas vinculadas a este campeonato.",
                                "Error de Integridad", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado al eliminar: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void BotonBorraPrueba_Click(object sender, EventArgs e)
    {
        // Validar ID prueba seleccionado en ComboBox
        if (comboPruebas.SelectedValue is not int idSel || idSel <= 0)
        {
            MostrarMensajeEstado("Selecciona prueba válida");
            return;
        }

        // Confirmación usuario 
        DialogResult confirmacion = MessageBox.Show(
            $"¿Estás seguro de que deseas eliminar esta prueba?\n\nEsta acción no se podrá deshacer.",
            "Confirmar eliminación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

        if (confirmacion == DialogResult.Yes)
        {
            try
            {
                using var db = new AppDbContext();                  // Contexto DB
                var pruebaParaBorrado = db.Pruebas.Find(idSel);     // DB, buscar por ID

                if (pruebaParaBorrado != null)
                {
                    db.Pruebas.Remove(pruebaParaBorrado);       // DB, marcar para borrado
                    db.SaveChanges();                           // SQLite, guardar cambios 

                    Limpia_DatosPrueba();                       // Limpiar TextBox 
                    ComboPruebas_Init();                         // Actualizar interfaz

                    MostrarMensajeEstado("Prueba borrada OK");
                }
                else
                {
                    MostrarMensajeEstado("Prueba NO existe");
                }
            }
            catch (DbUpdateException)
            {
                // Control de integridad referencial
                MessageBox.Show("No se puede eliminar la prueba porque tiene inscripciones asociadas.\n" +
                                "Elimina primero las inscripciones vinculadas a esta prueba.",
                                "Error de Integridad", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado al eliminar: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void BotonBorraPiloto_Click(object sender, EventArgs e)
    {
        // Validar ID piloto seleccionado en ComboBox
        if (comboPilotos.SelectedValue is not int idSel || idSel <= 0)
        {
            MostrarMensajeEstado("Selecciona piloto válido");
            return;
        }

        // Confirmación usuario 
        DialogResult confirmacion = MessageBox.Show(
                $"¿Estás seguro de que deseas eliminar este piloto?\n\nEsta acción no se podrá deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

        if (confirmacion == DialogResult.Yes)
        {
            try
            {
                using var db = new AppDbContext();                  // Contexto DB
                var pilotoParaBorrado = db.Pilotos.Find(idSel);     // DB, buscar por ID

                if (pilotoParaBorrado != null)
                {
                    db.Pilotos.Remove(pilotoParaBorrado);           // DB, marcar para borrado
                    db.SaveChanges();                               // SQLite, guardar cambios 

                    Limpia_DatosPiloto();                           // Limpiar TextBox 
                    ComboPilotos_Init();                             // Actualizar interfaz

                    MostrarMensajeEstado("Piloto borrado OK");
                }
                else
                {
                    MostrarMensajeEstado("Piloto NO existe");
                }
            }
            catch (DbUpdateException)
            {
                // Control de integridad referencial
                MessageBox.Show("No se puede eliminar el piloto porque tiene inscripciones asociadas.\n" +
                                "Elimina primero las inscripciones vinculadas a este piloto.",
                                "Error de Integridad", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado al eliminar: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void BotonBorraCoche_Click(object sender, EventArgs e)
    {
        // Validar ID coche seleccionado en ComboBox
        if (comboCoches.SelectedValue is not int idSel || idSel <= 0)
        {
            MostrarMensajeEstado("Selecciona coche válido");
            return;
        }

        // Confirmación usuario 
        DialogResult confirmacion = MessageBox.Show(
                $"¿Estás seguro de que deseas eliminar este coche?\n\nEsta acción no se podrá deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

        if (confirmacion == DialogResult.Yes)
        {
            try
            {
                using var db = new AppDbContext();              // Contexto DB
                var cocheParaBorrado = db.Coches.Find(idSel);   // DB, buscar por ID

                if (cocheParaBorrado != null)
                {
                    db.Coches.Remove(cocheParaBorrado);         // DB, marcar para borrado
                    db.SaveChanges();                           // SQLite, guardar cambios
                                                                // 
                    Limpia_DatosCoche();                        // Limpiar TextBox 
                    ComboCoches_Init();                          // Actualizar interfaz

                    MostrarMensajeEstado("Coche borrado OK");
                }
                else
                {
                    MostrarMensajeEstado("Coche NO existe");
                }
            }
            catch (DbUpdateException)
            {
                // Control de integridad referencial
                MessageBox.Show("No se puede eliminar el coche porque tiene inscripciones asociadas.\n" +
                                "Elimina primero las inscripciones vinculadas a este coche.",
                                "Error de Integridad", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado al eliminar: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void BotonBorraCategoria_Click(object sender, EventArgs e)
    {
        // Validar ID categoria seleccionada en ComboBox
        if (comboCategorias.SelectedValue is not int idSel || idSel <= 0)
        {
            MostrarMensajeEstado("Selecciona categoria válida");
            return;
        }

        // Confirmación usuario 
        DialogResult confirmacion = MessageBox.Show(
                $"¿Estás seguro de que deseas eliminar esta categoria?\n\nEsta acción no se podrá deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

        if (confirmacion == DialogResult.Yes)
        {
            try
            {
                using var db = new AppDbContext();                      // Contexto DB
                var categoriaParaBorrado = db.Categorias.Find(idSel);   // DB, buscar por ID

                if (categoriaParaBorrado != null)
                {
                    db.Categorias.Remove(categoriaParaBorrado);     // DB, marcar para borrado
                    db.SaveChanges();                               // SQLite, guardar cambios

                    ComboCategorias_Init();                          // Actualizar interfaz

                    MostrarMensajeEstado("Categoria borrada OK");
                }
                else
                {
                    MostrarMensajeEstado("Categoria NO existe");
                }
            }
            catch (DbUpdateException)
            {
                // Control de integridad referencial
                MessageBox.Show("No se puede eliminar la categoria porque tiene inscripciones asociadas.\n" +
                                "Elimina primero las inscripciones vinculadas a esta categoria.",
                                "Error de Integridad", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado al eliminar: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    //-------------------------------------------------------------------------
    #endregion

    #region otros
    //-------------------------------------------------------------------------
    private CancellationTokenSource? _ctsMensaje;
    public async void MostrarMensajeEstado(string msg, int ms = 4000)
    {
        // Cancela la espera del mensaje anterior si aún estaba corriendo
        _ctsMensaje?.Cancel();
        _ctsMensaje = new CancellationTokenSource();

        labelStatus.Text = msg;

        try
        {
            // Pasa el Token de cancelación a Task.Delay
            await Task.Delay(ms, _ctsMensaje.Token);
            labelStatus.Text = string.Empty; // Limpia al terminar el tiempo
        }
        catch (TaskCanceledException)
        {
            // Ocurre cuando un nuevo mensaje interrumpe la espera actual
        }
    }

    private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void ComboCategorias_DrawItem(object sender, DrawItemEventArgs e)
    {
        // Si no hay elementos en el combo, salimos
        if (e.Index < 0) return;
        if (sender is not ComboBox combo) return;

        // 1. Obtener de forma segura el texto del elemento
        string texto = combo.GetItemText(combo.Items[e.Index]) ?? string.Empty;

        // 2. Comprobar si el elemento está seleccionado en la lista Y el combo está desplegado
        bool esItemResaltado = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
        bool estaDesplegado = combo.DroppedDown;

        // Definir colores según el estado
        Color colorFondo;
        Color colorTexto;

        if (!estaDesplegado)                    // && e.Index == combo.SelectedIndex
        {
            colorFondo = combo.BackColor;       // Fondo deseado
            colorTexto = combo.ForeColor;       // Color del texto
        }
        else if (estaDesplegado && esItemResaltado)
        {
            // Estilo cuando pasas el ratón por encima en la lista desplegada
            colorFondo = Color.FromArgb(0, 122, 204);       // Azul clásico de selección
            colorTexto = Color.White;                       // Texto blanco obligado
        }
        else
        {
            // La lista y su contenido cuando el ratón NO está sobre el elemento (Fondo normal de la lista)
            colorFondo = Color.FromArgb(192, 255, 192);     // Fondo "menta"
            colorTexto = Color.Black;                       // Color del texto
        }

        // 3. Pintar el fondo del ítem
        using (SolidBrush brushFondo = new(colorFondo))
        {
            e.Graphics.FillRectangle(brushFondo, e.Bounds);
        }

        // 4. Dibujar el texto de forma segura con la fuente correcta
        Font fuenteSegura = e.Font ?? combo.Font ?? this.Font;
        using (SolidBrush brushTexto = new(colorTexto))
        {
            // Ajustamos ligeramente la posición Y para centrar el texto verticalmente
            float posY = e.Bounds.Y + (e.Bounds.Height - fuenteSegura.Height) / 2f;
            e.Graphics.DrawString(texto, fuenteSegura, brushTexto, e.Bounds.X + 4, posY);
        }

        // 5. Dibujar el rectángulo de foco si lo requiere el sistema
        e.DrawFocusRectangle();
    }
    //-------------------------------------------------------------------------
    #endregion

    #region DataGridView

    private void DataGridInscripcion_Init()
    {
        int idPruebaActual = IdPruebaSeleccionada ?? 0;

        using var db = new AppDbContext();

        var listaGrid = db.Inscripciones

            // 1. OBLIGAMOS a EF Core a traer los datos relacionados (Eager Loading)
            .Include(i => i.Piloto)
            .Include(i => i.Coche)
            .Include(i => i.Categoria)

            .Where(i => i.IdPrueba == idPruebaActual)

            // 2. PASAMOS a memoria para evaluar las propiedades [NotMapped] sin errores de traducción SQL
            .AsEnumerable()

            .Select(i => new
            {
                Id = i.Id,
                Dorsal = i.Dorsal,
                Alias = i.AliasPiloto,          // Ahora sí tiene datos gracias al Include
                Piloto = i.NombrePiloto,        // Ahora sí tiene datos gracias al Include
                Coche = i.DescripcionCoche,     // Usamos tu propiedad [NotMapped] que ya formatea "Modelo [Marca]"
                Categoria = i.Categoria?.Nombre ?? string.Empty, // Extraemos el texto del nombre explícitamente, no el objeto
                Verificado = i.Verificado,
                ColorFila = string.IsNullOrWhiteSpace(i.Categoria?.ColorHex) ? "#FFFFFF" : i.Categoria.ColorHex
            })
            .ToDataTable();

        // Vinculamos el resultado al DataGridView
        dataGridInscripcion.DataSource = listaGrid;

        // Ocultamos columnas NO UTILES para el usuario
        dataGridInscripcion.Columns["Id"]!.Visible = false;
        dataGridInscripcion.Columns["ColorFila"]!.Visible = false;

        // autoajustamos el tamaño de las columnas para que se vean todos los datos
        dataGridInscripcion.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        // Igualar el color de "selección" de la cabecera con su color normal
        dataGridInscripcion.ColumnHeadersDefaultCellStyle.SelectionBackColor = dataGridInscripcion.ColumnHeadersDefaultCellStyle.BackColor;
        dataGridInscripcion.ColumnHeadersDefaultCellStyle.SelectionForeColor = dataGridInscripcion.ColumnHeadersDefaultCellStyle.ForeColor;

        // Visualizar encabezado de fila
        dataGridInscripcion.RowHeadersVisible = true;

        // Define el ancho del encabezado de la fila en píxeles
        dataGridInscripcion.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        dataGridInscripcion.RowHeadersWidth = 20;

        // Alineamos columnas Dorsal y Alias al centro
        dataGridInscripcion.Columns["Dorsal"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridInscripcion.Columns["Alias"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        dataGridInscripcion.Columns["Dorsal"]!.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridInscripcion.Columns["Alias"]!.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        // Ordenamiento inicial por DORSAL Ascendente
        dataGridInscripcion.Sort(dataGridInscripcion.Columns["Dorsal"]!, ListSortDirection.Ascending);
    }

    private void DataGridInscripcion_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        // Iteramos por todas las filas creadas en el DataGrid
        foreach (DataGridViewRow fila in dataGridInscripcion.Rows)
        {
            // Evitamos la fila de "nuevo registro" si está habilitada
            if (fila.IsNewRow) continue;

            // Recuperamos el valor de la columna oculta que creamos en el Select()
            var hexCode = fila.Cells["ColorFila"].Value?.ToString();

            if (!string.IsNullOrEmpty(hexCode))
            {
                try
                {
                    Color backColor_Categoria = ColorTranslator.FromHtml(hexCode);
                    Color foreColor_Categoria = ColorTools.GetBestContrast(backColor_Categoria);

                    fila.DefaultCellStyle.BackColor = backColor_Categoria;
                    fila.DefaultCellStyle.ForeColor = foreColor_Categoria;

                    fila.DefaultCellStyle.SelectionBackColor = backColor_Categoria;
                    fila.DefaultCellStyle.SelectionForeColor = foreColor_Categoria;
                }
                catch (Exception)
                {
                    // Si el formato Hex era incorrecto o no se pudo parsear, 
                    // lo ignoramos para que la aplicación no se rompa y deje el fondo por defecto.
                }
            }
        }
        dataGridInscripcion.ClearSelection();   // Limpiamos selección por defecto 
    }

    private void DataGridInscripcion_Sorted(object sender, EventArgs e)
    {
        // Elimina la selección automática impuesta al terminar de ordenar por columna
        dataGridInscripcion.CurrentCell = null; // Esto desactiva el foco y oculta el glifo del RowHeader
        dataGridInscripcion.ClearSelection();
    }

    private void DataGridInscripcion_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
    {
        // Verificamos si la fila actual está seleccionada
        if (dataGridInscripcion.Rows[e.RowIndex].Selected)
        {
            // Obtenemos el rectángulo de visualización de la fila completa 
            // (Este método de WinForms gestiona automáticamente el scroll horizontal y las columnas visibles)
            Rectangle rowRect = dataGridInscripcion.GetRowDisplayRectangle(e.RowIndex, true);

            if (rowRect.Width > 0 && rowRect.Height > 0)
            {
                // 1. Obtenemos el ancho total real que suman todas las columnas visibles juntas
                int anchoColumnasVisibles = dataGridInscripcion.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);

                // 2. Acotamos el ancho para que el rectángulo rojo mida exactamente 
                // lo que ocupan las columnas (la fracción de la ventana), sin desbordarse al espacio vacío.
                int anchoFinal = Math.Min(rowRect.Width, anchoColumnasVisibles);

                // Creamos el lápiz rojo con el grosor deseado (ej. 2 píxeles)
                using Pen pen = new(Color.Red, 2);

                // Dibujamos el rectángulo ajustado al borde de la fila
                e.Graphics.DrawRectangle(pen, new Rectangle(rowRect.X, rowRect.Y, anchoFinal + 20 - 1, rowRect.Height - 1));
            }
        }
    }

    private void DataGridInscripcion_SelectionChanged(object sender, EventArgs e)
    {
        // Forzamos el redibujado completo del grid en cada cambio de selección.
        // Esto borra inmediatamente el borde rojo de la fila anterior y dibuja solo el nuevo.
        dataGridInscripcion.Invalidate();
    }

    private async void DataGridInscripcion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        // Validar que no se haya hecho clic en las cabeceras (RowIndex = -1, ColumnIndex = -1)
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

        var dgv = (DataGridView)sender;

        // Comprobar que la celda clicada corresponde a la columna "Verificado"
        if (dgv.Columns[e.ColumnIndex].Name != "Verificado") return;

        // Obtener el ID de la inscripción de la fila actual.
        int idInscripcionActual = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["Id"].Value);

        // Leer el valor actual del CheckBox y calcular el opuesto (toggle)
        object? cellValue = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        bool valorActual = cellValue != null && cellValue != DBNull.Value && Convert.ToBoolean(cellValue);
        bool nuevoValor = !valorActual;

        // Instanciar el contexto y actualizar la base de datos de forma asíncrona
        using var db = new Datos.AppDbContext();

        // Buscamos el registro exacto usando su clave primaria Id en el DbSet de Inscripciones
        var inscripcionDb = await db.Inscripciones.FindAsync(idInscripcionActual);

        if (inscripcionDb != null)
        {
            // Alternamos el valor booleano de la propiedad Verificado 
            inscripcionDb.Verificado = nuevoValor;

            // Guardamos los cambios físicamente en la base de datos SQLite
            await db.SaveChangesAsync();

            // Reflejar el cambio visualmente en el DataGrid inmediatamente 
            // sin necesidad de recargar toda la consulta de la base de datos
            dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = nuevoValor;
        }
    }

    private async void BorrarInscripcion()
    {
        // Validar que hay una fila seleccionada (gracias a nuestro CellMouseUp previo)
        if (dataGridInscripcion.SelectedRows.Count != 1)
        {
            return;
        }

        // Extraer el Id de la fila seleccionada
        int idInscripcionSelected = Convert.ToInt32(dataGridInscripcion.SelectedRows[0].Cells["Id"].Value);
        string dorsalSelected = dataGridInscripcion.SelectedRows[0].Cells["Dorsal"].Value?.ToString() ?? "N/A";
        string pilotoSelected = dataGridInscripcion.SelectedRows[0].Cells["Piloto"].Value?.ToString() ?? "Desconocido";

        // Trabajar de forma asíncrona con el DbContext
        using var db = new AppDbContext();

        // Comprobar si existen tiempos asociados de forma ultra rápida
        bool tieneTiempos = await db.TiemposTramos
                                    .AnyAsync(t => t.IdInscripcion == idInscripcionSelected);

        // 5. Preparar el mensaje de advertencia dinámico
        string mensaje = $"Dorsal [{dorsalSelected}] - {pilotoSelected}\n ¿Seguro quieres BORRAR esta inscripción?";
        string titulo = "Confirmar Borrado";
        MessageBoxIcon icono = MessageBoxIcon.Question;

        if (tieneTiempos)
        {
            mensaje = $"¡ATENCIÓN! El Dorsal [{dorsalSelected}] - {pilotoSelected}\n ya tiene tiempos registrados.\n\n" +
                      $"Si eliminas esta inscripción\n SE BORRARÁN TODOS SUS TIEMPOS de forma irreversible.\n\n" +
                      $"¿Deseas continuar de todos modos?";
            titulo = "PELIGRO - Pérdida de Datos";
            icono = MessageBoxIcon.Warning;
        }

        // Mostrar advertencia al usuario
        DialogResult resultado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, icono, MessageBoxDefaultButton.Button2);

        if (resultado == DialogResult.Yes)
        {
            try
            {
                // Activamos el cursor de espera para toda la ventana
                this.Cursor = Cursors.WaitCursor;

                // Buscar la inscripción en la base de datos
                var inscripcionABorrar = await db.Inscripciones.FindAsync(idInscripcionSelected);

                if (inscripcionABorrar != null)
                {
                    // Ejecutar el borrado (EF Core y SQLite se encargarán de la cascada)
                    db.Inscripciones.Remove(inscripcionABorrar);
                    await db.SaveChangesAsync();

                    // Refrescar el DataGridView llamando a tu método Init
                    DataGridInscripcion_Init();
                    MostrarMensajeEstado("Inscripción borrada OK");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al intentar borrar: {ex.Message}", 
                                "Error de Base de Datos", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
            }
            finally
            {
                // Restauramos el cursor por defecto SIEMPRE, haya ocurrido un error o no
                this.Cursor = Cursors.Default;
            }
        }
    }

    #endregion
}
