using rknRallySlotApp.Utilidades;

namespace rknRallySlotApp.Vistas;

public partial class FormMain : Form
{
    private void Botones_Init()
    {
        botonNuevoCampeonato.CfgBotonIcono(Properties.Resources.new_b);
        botonEditaCampeonato.CfgBotonIcono(Properties.Resources.pencil_b);
        botonBorraCampeonato.CfgBotonIcono(Properties.Resources.del_r);

        botonNuevaPrueba.CfgBotonIcono(Properties.Resources.new_b);
        botonEditaPrueba.CfgBotonIcono(Properties.Resources.pencil_b);
        botonBorraPrueba.CfgBotonIcono(Properties.Resources.del_r);

        botonNuevoPiloto.CfgBotonIcono(Properties.Resources.helmetN_v);
        botonEditaPiloto.CfgBotonIcono(Properties.Resources.pencil_v);
        botonBorraPiloto.CfgBotonIcono(Properties.Resources.del_r);

        botonNuevoCoche.CfgBotonIcono(Properties.Resources.carN_g);
        botonEditaCoche.CfgBotonIcono(Properties.Resources.pencil_g);
        botonBorraCoche.CfgBotonIcono(Properties.Resources.del_r);

        botonNuevaCategoria.CfgBotonIcono(Properties.Resources.inglesaN_o);
        botonEditaCategoria.CfgBotonIcono(Properties.Resources.pencil_o);
        botonBorraCategoria.CfgBotonIcono(Properties.Resources.del_r);
    }

    private void ToolTips_Init()
    {
        toolTip.SetToolTip(botonNuevoCampeonato, "Nuevo Campeonato");
        toolTip.SetToolTip(botonEditaCampeonato, "Modificar Campeonato");
        toolTip.SetToolTip(botonBorraCampeonato, "Borrar Campeonato");

        toolTip.SetToolTip(botonNuevaPrueba, "Nueva Prueba");
        toolTip.SetToolTip(botonEditaPrueba, "Modificar Prueba");
        toolTip.SetToolTip(botonBorraPrueba, "Borrar Prueba");

        toolTip.SetToolTip(botonNuevoPiloto, "Nuevo Piloto");
        toolTip.SetToolTip(botonEditaPiloto, "Modificar Piloto");
        toolTip.SetToolTip(botonBorraPiloto, "Borrar Piloto");

        toolTip.SetToolTip(botonNuevoCoche, "Nuevo Coche");
        toolTip.SetToolTip(botonEditaCoche, "Modificar Coche");
        toolTip.SetToolTip(botonBorraCoche, "Borrar Coche");

        toolTip.SetToolTip(botonNuevaCategoria, "Nueva Categoría");
        toolTip.SetToolTip(botonEditaCategoria, "Modificar Categoría");
        toolTip.SetToolTip(botonBorraCategoria, "Borrar Categoría");

        toolTip.SetToolTip(botonNuevaInscripcion, "Inscribir Piloto");

        toolTip.SetToolTip(checkAbrirRally, "Abrir Cronometraje");
    }

    private void MenuAndStatus_Init()
    {
        // ==========================================
        // inicializar menu y status bar
        // ==========================================
        // Define colores
        Color fondoPrincipal = Color.FromArgb(28, 28, 28);      // Gris muy oscuro 
        Color fondoHover = Color.FromArgb(80, 80, 85);          // Un poco más claro para el ratón
        Color bordeColor = Color.FromArgb(80, 80, 85);          // Un poco más claro para el borde

        var colorTable = new MyColorTable(fondoPrincipal, fondoHover, bordeColor);

        // Aplicar al Menu
        menuMain.Renderer = new ToolStripProfessionalRenderer(colorTable);
        menuMain.BackColor = fondoPrincipal;
        menuMain.ForeColor = Color.White;

        // Aplicar al Status
        statusStripMain.Renderer = new ToolStripProfessionalRenderer(colorTable);
        statusStripMain.BackColor = fondoPrincipal;
        statusStripMain.ForeColor = Color.White;
    }

    private void ContextMenu_Init()
    {
        // ==========================================
        // Menú Contextual del DGV Inscripciones
        // Suscribir opciones a sus eventos Click 
        opcion_ctxMenu_BorrarInscripcion.Click += Opcion_ctxMenu_BorrarInscripcion_Click;
        opcion_ctxMenu_Penalizar.Click += Opcion_ctxMenu_Penalizar_Click;

        // Añadir opciones al menú contextual
        ctxMenu_dataGridMain_Inscripcion.Items.Add(opcion_ctxMenu_Penalizar);
        ctxMenu_dataGridMain_Inscripcion.Items.Add(opcion_ctxMenu_BorrarInscripcion);
    }

    private void DataGridMain_Init()
    {
        // ==========================================
        // inicialar DataGridView
        dataGridMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        dataGridMain.AllowUserToResizeColumns = true;

        typeof(DataGridView)
            .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)?
            .SetValue(dataGridMain, true, null);
    }
}

