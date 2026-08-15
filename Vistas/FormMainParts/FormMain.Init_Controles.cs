using rknRallySlotApp.Utilidades;

namespace rknRallySlotApp.Vistas;

public partial class FormMain : Form
{
    private void Botones_Init()
    {
        botonNuevoCampeonato.CfgIconoBoton(Properties.Resources.new_b);
        botonEditaCampeonato.CfgIconoBoton(Properties.Resources.pencil_b);
        botonBorraCampeonato.CfgIconoBoton(Properties.Resources.del_r);

        botonNuevaPrueba.CfgIconoBoton(Properties.Resources.new_b);
        botonEditaPrueba.CfgIconoBoton(Properties.Resources.pencil_b);
        botonBorraPrueba.CfgIconoBoton(Properties.Resources.del_r);

        botonNuevoPiloto.CfgIconoBoton(Properties.Resources.helmetN_v);
        botonEditaPiloto.CfgIconoBoton(Properties.Resources.pencil_v);
        botonBorraPiloto.CfgIconoBoton(Properties.Resources.del_r);

        botonNuevoCoche.CfgIconoBoton(Properties.Resources.carN_g);
        botonEditaCoche.CfgIconoBoton(Properties.Resources.pencil_g);
        botonBorraCoche.CfgIconoBoton(Properties.Resources.del_r);

        botonNuevaCategoria.CfgIconoBoton(Properties.Resources.inglesaN_o);
        botonEditaCategoria.CfgIconoBoton(Properties.Resources.pencil_o);
        botonBorraCategoria.CfgIconoBoton(Properties.Resources.del_r);
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
        opcion_BorrarInscripcion.Click += Opcion_BorrarInscripcion_Click;
        opcion_Penalizar.Click += Opcion_Penalizar_Click;

        // Añadir opciones al menú contextual
        menuCtx_dgv_Inscripcion.Items.Add(opcion_Penalizar);
        menuCtx_dgv_Inscripcion.Items.Add(opcion_BorrarInscripcion);
    }

    private void Dgv_Inscripcion_Init()
    {
        // ==========================================
        // inicialar DataGridView Inscripciones
        dgv_Inscripcion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv_Inscripcion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        dgv_Inscripcion.AllowUserToResizeColumns = true;

        typeof(DataGridView)
            .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)?
            .SetValue(dgv_Inscripcion, true, null);
    }

    private void Controles_EnableAndDisable()
    {
        // Evaluamos el estado de cada ComboBox
        bool hayCampeonato = comboCampeonatos.SelectedValue is int idCto && idCto > 0;
        bool hayPrueba = comboPruebas.SelectedValue is int idPrueba && idPrueba > 0;
        bool hayPiloto = comboPilotos.SelectedValue is int idPiloto && idPiloto > 0;
        bool hayCoche = comboCoches.SelectedValue is int idCoche && idCoche > 0;
        bool hayCategoria = comboCategorias.SelectedValue is int idCategoria && idCategoria > 0;
        bool hayDatosDeInscripcion = dgv_Inscripcion.RowCount > 0;

        // limpiar textbox de datos si no hay selección válida
        if (!hayCampeonato)
        {
            comboCampeonatos.SelectedIndex = -1;
            Limpia_DatosCampeonato();
        }
        if (!hayPrueba)
        {
            comboPruebas.SelectedIndex = -1;
            Limpia_DatosPrueba();
        }
        if (!hayPiloto)
        {
            comboPilotos.SelectedIndex = -1;
            Limpia_DatosPiloto();
        }
        if (!hayCoche)
        {
            comboCoches.SelectedIndex = -1;
            Limpia_DatosCoche();
        }
        if (!hayCategoria)
        {
            comboCategorias.SelectedIndex = -1;
            Limpiar_Color_Categoria();
        }

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

        // Prueba (Nueva Prueba depende de Campeonato, Edición y Borrado dependen de Prueba)
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

        checkVerificado.Enabled = botonNuevaInscripcion.Enabled;

        if (!checkVerificado.Enabled)
        {
            checkVerificado.Checked = false;        // Desmarcar si DISABLED
        }

        // check Abrir Rally
        checkAbrirRally.Enabled = hayDatosDeInscripcion;

        if (checkAbrirRally.Enabled)
        {
            if (checkAbrirRally.Checked)
            {
                checkAbrirRally.Text = "STOP Rally";
                toolTip.SetToolTip(checkAbrirRally, "Detener Cronometraje");

                checkAbrirRally.BackColor = Color.FromArgb(53, 53, 53); // fondo gris oscuro
                checkAbrirRally.ForeColor = Color.FromArgb(255, 0, 0);  // frente rojo
            }
            else
            {
                checkAbrirRally.Text = "Abrir Rally";
                toolTip.SetToolTip(checkAbrirRally, "Abrir Cronometraje");

                checkAbrirRally.BackColor = Color.FromArgb(53, 53, 53); // fondo gris oscuro
                checkAbrirRally.ForeColor = Color.FromArgb(0, 255, 0);  // frente verde 
            }
        }
        else
        {
            checkAbrirRally.BackColor = Color.FromArgb(40, 40, 40);     // fondo gris más oscuro
            checkAbrirRally.ForeColor = Color.FromArgb(18, 18, 24);     // frente gris más oscuro
        }
    }

}

