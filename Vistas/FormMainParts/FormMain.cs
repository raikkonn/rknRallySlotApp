using Microsoft.EntityFrameworkCore;
using rknRallySlotApp.Datos;
using rknRallySlotApp.Logica;
using rknRallySlotApp.Modelos;
using rknRallySlotApp.Utilidades;
using System.ComponentModel;
using System.Data;

namespace rknRallySlotApp.Vistas;

public partial class FormMain : Form
{

    #region Miembros Privados, Publicos y Constructor
    //-------------------------------------------------------------------------
    // DECLARACIONES A NIVEL DE CLASE (Ámbito global dentro del formulario)
    private readonly ToolTip toolTip = new();

    private readonly ContextMenuStrip ctxMenu_dataGridMain_Inscripcion = new();
    private readonly ToolStripMenuItem opcion_ctxMenu_BorrarInscripcion = new("Borrar esta Inscripción");
    private readonly ToolStripMenuItem opcion_ctxMenu_Penalizar = new("Penalizar este Piloto");

    public int? IdCampeonatoSeleccionado { get; private set; } = null;    // ID del campeonato seleccionado (null con selección vacía)
    public int? IdPruebaSeleccionada { get; private set; } = null;        // ID de la prueba seleccionada (null con selección vacía)
    public int? IdPilotoSeleccionado { get; private set; } = null;        // ID del piloto seleccionado (null con selección vacía)
    public int? IdCocheSeleccionado { get; private set; } = null;         // ID del coche seleccionado (null con selección vacía)
    public int? IdCategoriaSeleccionada { get; private set; } = null;     // ID de la categoría seleccionada (null con selección vacía)

    //-------------------------------------------------------------------------
    // Constructor del formulario principal
    public FormMain()
    {
        InitializeComponent();

        // ==========================================
        // Inicialiación Controles
        Botones_Init();
        ToolTips_Init();
        MenuAndStatus_Init();
        ContextMenu_Init();
        DataGridMain_Init();

        // ==========================================
        // inicializamos los ComboBox
        ComboCampeonatos_Init();
        ComboPruebas_Init();
        ComboPilotos_Init();
        ComboCoches_Init();
        ComboCategorias_Init();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        _ctsMensaje?.Dispose();
        base.OnFormClosing(e);
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

    #region Enable/Disable Controles
    //-------------------------------------------------------------------------
    private void Controles_EnableAndDisable()
    {
        // Evaluamos el estado de cada ComboBox
        bool hayCampeonato = comboCampeonatos.SelectedValue is int idCto && idCto > 0;
        bool hayPrueba = comboPruebas.SelectedValue is int idPrueba && idPrueba > 0;
        bool hayPiloto = comboPilotos.SelectedValue is int idPiloto && idPiloto > 0;
        bool hayCoche = comboCoches.SelectedValue is int idCoche && idCoche > 0;
        bool hayCategoria = comboCategorias.SelectedValue is int idCategoria && idCategoria > 0;
        bool hayDatosDeInscripcion = dataGridMain.RowCount > 0;

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

        if (checkAbrirRally.Enabled) {
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
        } else
        {
            checkAbrirRally.BackColor = Color.FromArgb(40, 40, 40);     // fondo gris más oscuro
            checkAbrirRally.ForeColor = Color.FromArgb(18, 18, 24);     // frente gris más oscuro
        }
    }
    //-------------------------------------------------------------------------
    #endregion

    #region SelectedIndexChanged Events    
    //-------------------------------------------------------------------------
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
        DataGridMain_Init_Inscripcion();    // consulta DB para rellenar DataGridView Inscripciones
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
        DataGridMain_Init_Inscripcion();    // consulta DB para rellenar DataGridView Inscripciones
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
        formAlta.Location = groupBoxCampeonato.PointToScreen(new Point(12, 8));

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
        formAlta.Location = groupBoxCampeonato.PointToScreen(new Point(12, 8));

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
        formAlta.Location = groupBoxCampeonato.PointToScreen(new Point(12, 8));

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
        formAlta.Location = groupBoxCampeonato.PointToScreen(new Point(12, 8));

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
        formAlta.Location = groupBoxCategoria.PointToScreen(new Point(0, 0));

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

            DataGridMain_Init_Inscripcion();        // Refrescamos el DataGridView para mostrar la nueva inscripción
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
        formEdicion.Location = groupBoxCampeonato.PointToScreen(new Point(12, 8));

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
        formEdicion.Location = groupBoxCampeonato.PointToScreen(new Point(12, 8));

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
        formEdicion.Location = groupBoxCampeonato.PointToScreen(new Point(12, 8));

        if (formEdicion.ShowDialog(this) == DialogResult.OK)
        {
            ComboPilotos_Init();                                             // Si el usuario guardó con éxito, refrescamos este combo
            comboPilotos.SelectedValue = formEdicion.IdSelected ?? -1;      // seleccionamos el piloto editado o ninguno si es null
            MostrarMensajeEstado("Piloto modificado OK");
            DataGridMain_Init_Inscripcion();
        }
    }

    private void BotonEditaCoche_Click(object sender, EventArgs e)
    {
        using var formEdicion = new FormCoche("Modificar Coche", comboCoches.SelectedValue);

        formEdicion.StartPosition = FormStartPosition.Manual;
        formEdicion.Location = groupBoxCampeonato.PointToScreen(new Point(12, 8));

        if (formEdicion.ShowDialog(this) == DialogResult.OK)
        {
            ComboCoches_Init();                                              // Si el usuario guardó con éxito, refrescamos este combo
            comboCoches.SelectedValue = formEdicion.IdSelected ?? -1;       // seleccionamos el coche editado o ninguno si es null
            MostrarMensajeEstado("Coche modificado OK");
            DataGridMain_Init_Inscripcion();
        }
    }

    private void BotonEditaCategoria_Click(object sender, EventArgs e)
    {
        using var formEdicion = new FormCategoria("Modificar Categoria", comboCategorias.SelectedValue);

        formEdicion.StartPosition = FormStartPosition.Manual;
        formEdicion.Location = groupBoxCategoria.PointToScreen(new Point(0, 0));

        if (formEdicion.ShowDialog(this) == DialogResult.OK)
        {
            ComboCategorias_Init();                                             // Si el usuario guardó con éxito, refrescamos este combo
            comboCategorias.SelectedValue = formEdicion.IdSelected ?? -1;      // seleccionamos la categoria editada o ninguna si es null
            MostrarMensajeEstado("Categoria modificada OK");
            DataGridMain_Init_Inscripcion();
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
    public async void MostrarMensajeEstado(string msg, int ms = 6000)
    {
        try
        {
            // Cancela la espera del mensaje anterior si aún estaba corriendo
            _ctsMensaje?.Cancel();
            _ctsMensaje = new CancellationTokenSource();

            labelStatus.Text = msg;

            // Pasa el Token de cancelación a Task.Delay
            await Task.Delay(ms, _ctsMensaje.Token);
            labelStatus.Text = string.Empty; // Limpia al terminar el tiempo
        }
        catch (TaskCanceledException)
        {
            // Ocurre cuando un nuevo mensaje interrumpe la espera actual
        }
        catch (Exception ex)
        {
            // Capturar cualquier otro posible error
            System.Diagnostics.Debug.WriteLine($"Error en mensaje de estado: {ex.Message}");
        }
    }

    private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void ComboCategorias_DrawItem(object sender, DrawItemEventArgs e)
    {
        // Si no hay elementos en el combo, salimos
        if (sender is not ComboBox combo) return;
        if (e.Index < 0) return;

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
    //-------------------------------------------------------------------------

    private void DataGridMain_Init_Inscripcion()
    {
        // ==========================================
        // Suscripcion eventos DataGridMain para INSCRIPCIONES
        dataGridMain.CellMouseUp -= DataGridMain_CellMouseUp;           // Evitamos suscripciones duplicadas
        dataGridMain.CellMouseUp += DataGridMain_CellMouseUp;           // Suscribimos al evento para mostrar el menú contextual al hacer clic derecho
        dataGridMain.CellDoubleClick -= DataGridMain_CellDoubleClick;   // Evitamos suscripciones duplicadas
        dataGridMain.CellDoubleClick += DataGridMain_CellDoubleClick;   // Suscribimos al evento para manejar el doble clic 
        dataGridMain.DataBindingComplete -= Colorear_dataGridMain_DataBindingComplete; // Evitamos suscripciones duplicadas
        dataGridMain.DataBindingComplete += Colorear_dataGridMain_DataBindingComplete; // Suscribimos al evento para colorear filas según la categoría

        // ==========================================
        // Inicializa DataGridMain para INSCRIPCIONES
        // ==========================================

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
                Id = i.Id!,
                Dorsal = i.Dorsal!,
                Alias = i.AliasPiloto,                              // Ahora sí tiene datos gracias al Include
                Piloto = i.NombrePiloto,                            // Ahora sí tiene datos gracias al Include
                Coche = i.DescripcionCoche,                         // Usamos propiedad [NotMapped] que ya formatea "Modelo [Marca]"
                Categoria = i.Categoria?.Nombre ?? string.Empty,    // Extraemos el texto del nombre explícitamente, no el objeto
                Verificado = i.Verificado!,
                Penalizacion_seg = i.PenalizacionSEG,
                ColorFila = string.IsNullOrWhiteSpace(i.Categoria?.ColorHex) ? "#FFFFFF" : i.Categoria.ColorHex
            })
            .ToDataTable();

        // Vinculamos el resultado al DataGridView
        dataGridMain.DataSource = listaGrid;

        // Ocultamos columnas NO UTILES para el usuario
        dataGridMain.Columns["Id"]!.Visible = false;
        dataGridMain.Columns["ColorFila"]!.Visible = false;

        // autoajustamos el tamaño de las columnas para que se vean todos los datos
        dataGridMain.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        // ancho manual para Penalizacion_seg
        dataGridMain.Columns["Penalizacion_seg"]!.Width = 155;

        // Igualar el color de "selección" de la cabecera con su color normal
        dataGridMain.ColumnHeadersDefaultCellStyle.SelectionBackColor = dataGridMain.ColumnHeadersDefaultCellStyle.BackColor;
        dataGridMain.ColumnHeadersDefaultCellStyle.SelectionForeColor = dataGridMain.ColumnHeadersDefaultCellStyle.ForeColor;

        // Visualizar encabezado de fila
        dataGridMain.RowHeadersVisible = true;

        // Define ancho encabezado de fila
        dataGridMain.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        dataGridMain.RowHeadersWidth = 20;

        // Alinear columnas 
        dataGridMain.Columns["Dorsal"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridMain.Columns["Alias"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridMain.Columns["Penalizacion_seg"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        // Alinear encabezados columna
        dataGridMain.Columns["Dorsal"]!.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridMain.Columns["Alias"]!.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridMain.Columns["Penalizacion_seg"]!.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        // Ordenamiento inicial por DORSAL Ascendente
        dataGridMain.Sort(dataGridMain.Columns["Dorsal"]!, ListSortDirection.Ascending);

        // Revisar habilitacion controles 
        Controles_EnableAndDisable();
    }

    private void Colorear_dataGridMain_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
    {
        // Iteramos por todas las filas creadas en el DataGrid
        foreach (DataGridViewRow fila in dataGridMain.Rows)
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
        dataGridMain.ClearSelection();   // Limpiamos selección por defecto 
    }

    private void Ordenar_dataGridMain_Sorted(object sender, EventArgs e)
    {
        // Elimina la selección automática impuesta al terminar de ordenar por columna
        dataGridMain.CurrentCell = null; // Esto desactiva el foco y oculta el glifo del RowHeader
        dataGridMain.ClearSelection();
    }

    private void Resaltar_dataGridMain_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
    {
        // Verificamos si la fila actual está seleccionada
        if (dataGridMain.Rows[e.RowIndex].Selected)
        {
            // Obtenemos el rectángulo de visualización de la fila completa 
            // (Este método de WinForms gestiona automáticamente el scroll horizontal y las columnas visibles)
            Rectangle rowRect = dataGridMain.GetRowDisplayRectangle(e.RowIndex, true);

            if (rowRect.Width > 0 && rowRect.Height > 0)
            {
                // 1. Obtenemos el ancho total real que suman todas las columnas visibles juntas
                int anchoColumnasVisibles = dataGridMain.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);

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

    private void Seleccion_dataGridMain_SelectionChanged(object sender, EventArgs e)
    {
        // Forzamos el redibujado completo del grid en cada cambio de selección.
        // Esto borra inmediatamente el borde rojo de la fila anterior y dibuja solo el nuevo.
        dataGridMain.Invalidate();
    }

    // ==========================================
    // BORRAR INSCRIPCION
    // Evento Click opción menu contexto "Borrar esta Inscripción"
    private async void Opcion_ctxMenu_BorrarInscripcion_Click(object? sender, EventArgs e)
    {
        // Validar que hay una y sólo una fila seleccionada 
        if (dataGridMain.SelectedRows.Count != 1) return;

        // Extraer el Id de la fila seleccionada
        int idInscripcionSelected = Convert.ToInt32(dataGridMain.SelectedRows[0].Cells["Id"].Value);
        string dorsalSelected = dataGridMain.SelectedRows[0].Cells["Dorsal"].Value?.ToString() ?? "N/A";
        string pilotoSelected = dataGridMain.SelectedRows[0].Cells["Piloto"].Value?.ToString() ?? "Desconocido";

        // Trabajar de forma asíncrona con el DbContext
        using var db = new AppDbContext();

        // Comprobar si existen tiempos asociados de forma ultra rápida
        bool tieneCronos = await db.Cronos.AnyAsync(c => c.IdInscripcion == idInscripcionSelected);

        // 5. Preparar el mensaje de advertencia dinámico
        string mensaje = $"Dorsal [{dorsalSelected}] - {pilotoSelected}\n\n ¿Seguro quieres BORRAR esta inscripción?";
        string titulo = "Confirmar Borrado";
        MessageBoxIcon icono = MessageBoxIcon.Question;

        if (tieneCronos)
        {
            mensaje = $"¡ATENCIÓN! El Dorsal [{dorsalSelected}] - {pilotoSelected}\n " +
                      $"ya tiene tiempos registrados en esta prueba.\n\n" +
                      $"Si eliminas esta inscripción\n " +
                      $"SE BORRARÁN SUS TIEMPOS EN ESTA PRUEBA de forma irreversible.\n\n" +
                      $"¿Continuar con el BORRADO de todos modos?";
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
                    DataGridMain_Init_Inscripcion();
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

    // ==========================================
    // PENALIZAR PILOTO (menu contexto)
    // Evento Click para la opción del menú contextual "Penalizar este Piloto"
    private void Opcion_ctxMenu_Penalizar_Click(object? sender, EventArgs e)
    {
        // 1. Asegurarnos de que el dataGridView tiene una fila seleccionada actualmente
        if (dataGridMain.SelectedRows.Count != 1)
            return;

        // 2. Obtener la fila actual (usando la celda actual o la fila seleccionada)
        int fila = dataGridMain.SelectedRows[0].Index;
        int colu = dataGridMain.Columns["Penalizacion_seg"]?.Index ?? -1;

        // Validar que los índices sean correctos
        if (fila < 0 || colu < 0)
            return;

        // 3. Obtener el ID de la inscripción de la fila seleccionada (igual que en el doble clic)
        int idInscripcionActual = Convert.ToInt32(dataGridMain.Rows[fila].Cells["Id"].Value);

        // 4. Llamar al mismo método que ya usas para la edición flotante
        Tto_Penalizacion(dataGridMain, fila, colu, idInscripcionActual);
    }

    // ==========================================
    // Evento CellMouseUp para el DataGridMain, para mostrar el menú contextual al hacer clic derecho
    private void DataGridMain_CellMouseUp(object? sender, DataGridViewCellMouseEventArgs e)
    {
        // Validar que sea un clic derecho y que no se haya hecho clic en las cabeceras (RowIndex -1)
        if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
        {
            // Limpiar selecciones previas y seleccionar la fila actual bajo el ratón
            dataGridMain.ClearSelection();
            dataGridMain.Rows[e.RowIndex].Selected = true;

            // Mostrar el menú contextual exactamente en la posición actual del cursor en la pantalla
            ctxMenu_dataGridMain_Inscripcion.Show(Cursor.Position);
        }
    }

    // ==========================================
    // Controla el doble clic para columnas VERIFICADO y PENALIZACION_SEG
    private async void DataGridMain_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        int fila = e.RowIndex;
        int colu = e.ColumnIndex;

        // Si clic en cabeceras, sale
        if (fila < 0 || colu < 0)
            return;

        DataGridView dgv = (DataGridView)sender!;
        string nombreColumna = dgv.Columns[colu].Name;

        // Si no es columna permitida, sale 
        if (nombreColumna != "Verificado" && nombreColumna != "Penalizacion_seg")
            return;

        // Obtener el ID de la inscripción de la fila del GRID.
        int idInscripcionActual = Convert.ToInt32(dgv.Rows[fila].Cells["Id"].Value);

        // Tratamiento según la columna
        if (nombreColumna == "Verificado")
        {
            using AppDbContext db = new();
            var inscripcionDB = await db.Inscripciones.FindAsync(idInscripcionActual);

            if (inscripcionDB == null)
                return;

            object? valorCelda = dgv.Rows[fila].Cells[colu].Value;
            bool valorActual = valorCelda != null && valorCelda != DBNull.Value && Convert.ToBoolean(valorCelda);
            bool nuevoValor = !valorActual;

            inscripcionDB.Verificado = nuevoValor;
            dgv.Rows[fila].Cells[colu].Value = nuevoValor;

            // Guardamos los cambios en DB de forma asíncrona
            await db.SaveChangesAsync();
        }
        else if (nombreColumna == "Penalizacion_seg")
        {
            Tto_Penalizacion(dgv, fila, colu, idInscripcionActual);
        }
    }

    // ==========================================
    // Tto de las penalizaciones de pilotos
    private void Tto_Penalizacion(DataGridView dgv, int fila, int colu, int idInscripcionActual)
    {
        // Consultamos el valor actual solo para pintar el texto inicial
        int penalizacionValor = 0;
        using (AppDbContext dbTemp = new())
        {
            var insTemp = dbTemp.Inscripciones.Find(idInscripcionActual);
            if (insTemp == null) return;
            penalizacionValor = insTemp.PenalizacionSEG;
        }

        Rectangle rectCelda = dgv.GetCellDisplayRectangle(colu, fila, true);

        TextBox tboxPenalizacion = new()
        {
            Location = rectCelda.Location,
            Size = rectCelda.Size,
            Text = penalizacionValor.ToString(),
            TextAlign = HorizontalAlignment.Right
        };

        // Bandera para evitar ejecuciones múltiples del guardado (LostFocus + Enter simultáneos)
        bool isSavingOrClosing = false;

        // Método local para limpiar y destruir el TextBox de forma segura
        void CerrarEditor()
        {
            if (isSavingOrClosing) return;
            isSavingOrClosing = true;

            if (dgv.Controls.Contains(tboxPenalizacion))
            {
                dgv.Controls.Remove(tboxPenalizacion);
                tboxPenalizacion.Dispose();
                dgv.Invalidate();
            }
        }

        // Método local para guardar los cambios
        async Task GuardarCambiosAsync()
        {
            if (isSavingOrClosing) return;

            if (int.TryParse(tboxPenalizacion.Text, out int valorPenalizacion) && valorPenalizacion >= 0)
            {
                try
                {
                    using AppDbContext db = new();
                    var inscripcionDB = await db.Inscripciones.FindAsync(idInscripcionActual);

                    if (inscripcionDB != null)
                    {
                        inscripcionDB.PenalizacionSEG = valorPenalizacion;
                        await db.SaveChangesAsync();

                        // Reflejar el cambio visualmente en el grid
                        dgv.Rows[fila].Cells[colu].Value = valorPenalizacion;
                    }
                }
                catch (Exception ex)
                {
                    MostrarMensajeEstado($"Error al guardar la penalización: {ex.Message}");
                }
            }

            CerrarEditor();
        }

        // Validar solo números y gestionar teclas especiales (Enter / Escape)
        tboxPenalizacion.PreviewKeyDown += (sender, e) =>
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Forzamos a que el sistema considere que la tecla fue procesada aquí
                e.IsInputKey = true;
            }
        };

        tboxPenalizacion.KeyPress += async (sender, e) =>
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                await GuardarCambiosAsync();
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
                CerrarEditor();
            }
            else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        };

        // Al perder el foco, guardamos y cerramos
        tboxPenalizacion.LostFocus += async (sender, e) =>
        {
            await GuardarCambiosAsync();
        };

        dgv.Controls.Add(tboxPenalizacion);
        tboxPenalizacion.Font = dgv.Rows[fila].Cells[colu].Style.Font
                        ?? dgv.DefaultCellStyle.Font
                        ?? dgv.Font;
        tboxPenalizacion.BringToFront();
        tboxPenalizacion.Focus();
        tboxPenalizacion.SelectAll();
    }
    
    //-------------------------------------------------------------------------
    #endregion

    #region Scratch
    //-------------------------------------------------------------------------
    private async void CheckAbrirRally_CheckedChanged(object? sender, EventArgs e)
    {
        // rally abierto si checkbox está marcado
        bool rallyAbierto = checkAbrirRally.Checked;

        // Habilitar Inscripcion SÓLO si el Rally está cerrado
        groupBoxCampeonato.Enabled = !rallyAbierto;
        groupBoxPiloto.Enabled = !rallyAbierto;
        groupBoxCategoria.Enabled = !rallyAbierto;
        groupBoxInscripcion.Enabled = !rallyAbierto;
        Controles_EnableAndDisable();

        if (rallyAbierto)
        {
            // Se intenta inicializar Cronos con la prueba seleccionada
            DialogResult resultado = await GestionDatos.PoblarCronosAsync(IdPruebaSeleccionada);

            if (resultado == DialogResult.OK)
            {
                // despejar combos y controles
                comboPilotos.SelectedIndex = -1;
                comboCoches.SelectedIndex = -1;
                comboCategorias.SelectedIndex = -1;
                Controles_EnableAndDisable();

                // mensaje de estado Rally Abierto
                string rallySeleccionado = $"| {comboPruebas.Text} ({comboCampeonatos.Text}) |";
                MostrarMensajeEstado($"{rallySeleccionado} Rally Abierto: Las inscripciones estan bloqueadas", 10000);

                // ==========================================
                // Tratamiento rally ABIERTO
                DataGridMain_Init_Cronos();
                // ==========================================
            }
            else    // no se pudo inicializar Cronos, - Cerrar el Rally -
            {
                rallyAbierto = false;   // rally cerrado

                // DESUSCRIBIMOS EL EVENTO temporalmente para evitar el bucle/anidamiento
                checkAbrirRally.CheckedChanged -= CheckAbrirRally_CheckedChanged;

                checkAbrirRally.Checked = false;
                checkAbrirRally.Invalidate();

                Controles_EnableAndDisable();

                // Desbloquear Inscripcion cuando el Rally está Cerrado
                groupBoxCampeonato.Enabled = true;
                groupBoxPiloto.Enabled = true;
                groupBoxCategoria.Enabled = true;
                groupBoxInscripcion.Enabled = true;

                MostrarMensajeEstado("Operacion Cancelada: No se pudo inicializar Cronos");

                // VOLVEMOS A SUSCRIBIR EL EVENTO
                checkAbrirRally.CheckedChanged += CheckAbrirRally_CheckedChanged;

                // ==========================================
                // Tratamiento rally CERRADO
                DataGridMain_Init_Inscripcion();
                // ==========================================
            }
        }
        else
        {
            MostrarMensajeEstado("Rally Cerrado: Se permite modificar la inscripción");

            // ==========================================
            // Tratamiento rally CERRADO
            DataGridMain_Init_Inscripcion();
            // ==========================================
        }
    }

    private void DataGridMain_Init_Cronos()
    {
        // ==========================================
        // Suscripción eventos DataGridMain para CRONOS 
        // ==========================================
        dataGridMain.CellMouseUp -= DataGridMain_CellMouseUp;               // deshabilitar menú contextual
        dataGridMain.CellDoubleClick -= DataGridMain_CellDoubleClick;       // deshabilitar doble clic

        int idPruebaActual = IdPruebaSeleccionada ?? 0;

        using var db = new AppDbContext();

        // 1. Obtenemos la metadata de la prueba para saber la estructura jerárquica
        var pruebaActual = db.Pruebas.FirstOrDefault(p => p.Id == idPruebaActual);
        if (pruebaActual == null) return;

        // 2. FASE SQL (EF Core): Extraemos inscripciones y sus cronos
        var inscripcionesDb = db.Inscripciones
            .Include(i => i.Piloto)
            .Include(i => i.Categoria)
            .Include(i => i.Cronos) 
            .Where(i => i.IdPrueba == idPruebaActual)
            .ToList();

        // 3. FASE C# (Memoria): Calculamos tiempo total del rally (Cronos + Penalizaciones) y ordenamos
        var clasificacionGeneral = inscripcionesDb
            .Select(i => new
                {
                    Inscripcion = i,
                    // Sumamos los milisegundos de cada tramo y añadimos los segundos de penalización convertidos a milisegundos
                    TiempoTotalRally = i.Cronos.Sum(c => c.CronoMS) + (i.PenalizacionSEG * 1000)
                })
            // Ordenamos: primero los que no tienen tiempo (al final) y luego por tiempo ascendente
            .OrderBy(x => x.TiempoTotalRally == 0)
            .ThenBy(x => x.TiempoTotalRally)
            .ToList();

        // ==========================================
        // 4. Construimos el DataTable dinámico
        DataTable dt = new();

        // 4.1 Crear Columnas
        // Columnas base
        dt.Columns.Add("ColorFila", typeof(string));
        dt.Columns.Add("Pos", typeof(string));
        dt.Columns.Add("Alias", typeof(string));

        // Columnas calculadas 
        dt.Columns.Add("tº Total", typeof(string));
        dt.Columns.Add("Dif. 1º", typeof(string));
        dt.Columns.Add("Dif. Ant.", typeof(string));

        dt.Columns.Add("Cat", typeof(string));

        // Generamos columnas dinámicas para Etapas y Tramos
        for (int E = 1; E <= pruebaActual.NumEtapas; E++)
        {
            for (int T = 1; T <= pruebaActual.TramosPorEtapa; T++)
            {
                dt.Columns.Add($"E{E} T{T}", typeof(string));
            }
            dt.Columns.Add($"Total E{E}", typeof(string));
        }

        dt.Columns.Add("Dor", typeof(int));

        // ==========================================
        // Función local para formatear milisegundos a string (ssss.fff)
        static string FormatTime(int t_ms)
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(t_ms);

            // (int)ts.TotalSeconds extrae todos los segundos acumulados sin importar los minutos
            // ts.Milliseconds extrae el remanente de milisegundos (0-999)
            return $"{(int)ts.TotalSeconds:00}.{ts.Milliseconds:000}";
        }
        // ==========================================

        // 5. Rellenamos las filas y calculamos los Gaps en memoria (100% seguro)
        int tiempoLider = clasificacionGeneral.FirstOrDefault(x => x.TiempoTotalRally > 0)?.TiempoTotalRally ?? 0;
        int tiempoAnterior = 0;
        int posicion = 1;

        foreach (var item in clasificacionGeneral)
        {
            DataRow row = dt.NewRow();
            var inscripcion = item.Inscripcion;

            row["ColorFila"] = string.IsNullOrWhiteSpace(inscripcion.Categoria?.ColorHex)
                                    ? "#FFFFFF"
                                    : inscripcion.Categoria.ColorHex;

            row["Dor"] = inscripcion.Dorsal;
            row["Alias"] = inscripcion.AliasPiloto; 
            row["Cat"] = inscripcion.Categoria?.Nombre ?? "";

            bool tieneTiempos = item.TiempoTotalRally > 0;

            // Lógica de cálculo de Gaps
            if (tieneTiempos)
            {
                row["Pos"] = $"{posicion}º";

                if (posicion == 1)
                {
                    row["Dif. 1º"] = "---";
                    row["Dif. Ant."] = "---";
                }
                else
                {
                    row["Dif. 1º"] = "+" + FormatTime(item.TiempoTotalRally - tiempoLider);
                    row["Dif. Ant."] = "+" + FormatTime(item.TiempoTotalRally - tiempoAnterior);
                }

                tiempoAnterior = item.TiempoTotalRally;
                posicion++;
            }
            else
            {
                row["Pos"] = "sin tº";
                row["Dif. 1º"] = "sin tº";
                row["Dif. Ant."] = "sin tº";
            }

            // Tiempos individuales y por etapa
            for (int E = 1; E <= pruebaActual.NumEtapas; E++)
            {
                int totalEtapaMS = 0;
                for (int T = 1; T <= pruebaActual.TramosPorEtapa; T++)
                {
                    // Buscamos el crono específico con el nuevo modelo Crono
                    var crono = inscripcion.Cronos.FirstOrDefault(c => c.Etapa == E && c.Tramo == T);

                    if (crono != null && crono.CronoMS > 0)
                    {
                        row[$"E{E} T{T}"] = FormatTime(crono.CronoMS);
                        totalEtapaMS += crono.CronoMS;
                    }
                    else
                    {
                        row[$"E{E} T{T}"] = "00.000";
                    }
                }
                row[$"Total E{E}"] = totalEtapaMS > 0 ? FormatTime(totalEtapaMS) : "00.000";
            }

            row["tº Total"] = tieneTiempos ? FormatTime(item.TiempoTotalRally) : "00.000";

            dt.Rows.Add(row);
        }

        // ==========================================
        // Renderizado visual en DataGridView
        // ==========================================
        dataGridMain.DataSource = dt;

        // Ocultar la columna del color
        if (dataGridMain.Columns.Contains("ColorFila"))
        {
            dataGridMain.Columns["ColorFila"]?.Visible = false;
        }

        // Ajuste de anchos y visuales
        dataGridMain.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        // Ajustes visuales de cabeceras de columnas y filas
        dataGridMain.ColumnHeadersDefaultCellStyle.SelectionBackColor = dataGridMain.ColumnHeadersDefaultCellStyle.BackColor;
        dataGridMain.ColumnHeadersDefaultCellStyle.SelectionForeColor = dataGridMain.ColumnHeadersDefaultCellStyle.ForeColor;
        dataGridMain.RowHeadersVisible = true;
        dataGridMain.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        dataGridMain.RowHeadersWidth = 20;

        // Alineaciones para columnas estáticas (centro)
        string[] columnasCentradas = ["Pos", "Dor", "Alias", "Cat"];
        foreach (var colName in columnasCentradas)
        {
            if (dataGridMain.Columns[colName] != null)
            {
                dataGridMain.Columns[colName]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridMain.Columns[colName]!.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // Alineaciones para columnas de tiempos (derecha)
        foreach (DataGridViewColumn col in dataGridMain.Columns)
        {
            if (col.Name.Contains('E') || col.Name.Contains("Total") || col.Name.Contains("Dif."))
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        // Revisar habilitacion controles
        Controles_EnableAndDisable();
    }

    //-------------------------------------------------------------------------
    #endregion
}

