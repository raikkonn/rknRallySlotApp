using Microsoft.EntityFrameworkCore;
using rknRallySlotApp.Datos;
using rknRallySlotApp.Utilidades;

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
        BotonesInit();
        ConfigurarToolTips();

        // inicializamos los ComboBox
        ComboCampeonatosInit();
        ComboPruebasInit();
        ComboPilotosInit();
        ComboCochesInit();
        ComboCategoriasInit();
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
    private void ComboCampeonatosInit()
    {
        // Desconectamos el evento para evitar que se dispare durante la inicialización
        comboCampeonatos.SelectedIndexChanged -= ComboCampeonatos_SelectedIndexChanged;

        try
        {
            using var db = new AppDbContext();

            // Obtenemos la lista de campeonatos desde la base de datos
            var listaCampeonatos = db.Campeonatos
                .Select(c => new { c.Id, c.Nombre })
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

    private void ComboPruebasInit()
    {
        if (comboCampeonatos.SelectedValue is not int idCto || idCto <= 0)    //SIN Campeonato válido seleccionado salir
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

    private void ComboPilotosInit()
    {
        // Desconectamos el evento para evitar que se dispare durante la inicialización
        comboPilotos.SelectedIndexChanged -= ComboPilotos_SelectedIndexChanged;

        try
        {
            using var db = new AppDbContext();

            // Obtenemos la lista de pilotos desde DB
            var listaPilotos = db.Pilotos
                .Select(p => new { p.Id, p.Nombre })
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

    private void ComboCochesInit()
    {
        // Desconectamos el evento para evitar que se dispare durante la inicialización
        comboCoches.SelectedIndexChanged -= ComboCoches_SelectedIndexChanged;

        try
        {
            using var db = new AppDbContext();

            // Obtenemos la lista de coches desde DB
            var listaCoches = db.Coches
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

    private void ComboCategoriasInit()
    {
        // Desconectamos el evento para evitar que se dispare durante la inicialización
        comboCategorias.SelectedIndexChanged -= ComboCategorias_SelectedIndexChanged;

        try
        {
            using var db = new AppDbContext();

            // Obtenemos la lista de coches desde DB
            var listaCategorias = db.Categorias
                .Select(c => new { c.Id, c.Nombre })
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

    private void DataGridInscripcionInit()
    {
        using var db = new AppDbContext();

        // Hacemos la consulta trayendo datos de ambas tablas gracias a la relación
        var listaGrid = db.Inscripciones
            .Select(i => new
            {
                i.Dorsal,
                Piloto = i.NombrePiloto,
                i.Coche,
                Cat = i.Categoria,
                Verif = i.Verificado
            })
            .ToList();

        // Vinculamos el resultado al DataGridView
        DataGridInscripcion.DataSource = listaGrid;
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
        botonNuevaInscripcion.Enabled = hayCampeonato && hayPrueba && hayPiloto && hayCoche && hayCategoria;
    }

    private void ComboCampeonatos_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (comboCampeonatos.SelectedValue is int idSel)
        {
            if (idSel > 0)                              // Selección Válida 
            {
                IdCampeonatoSeleccionado = idSel;       // guardar ID en miembro público
                Rellena_DatosCampeonato();              // consulta DB para rellenar TextBox
                ComboPruebasInit();                     // Init ComboBox Pruebas para Campeonato seleccionado
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
        Controles_EnableAndDisable();                   // Actualizamos los controles después de la operación
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
        Controles_EnableAndDisable();                   // Actualizamos los controles después de la operación
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
            }
            else                                        // ID inválido, limpiar selecciones y TextBox si hubiera
            {
                comboCategorias.SelectedIndex = -1;     // Limpiar selección Categorías
                IdCategoriaSeleccionada = null;         // Limpiar ID Categoría 

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
            ComboCampeonatosInit();                                         // Si el usuario guardó con éxito, refrescamos combo
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
            ComboPruebasInit();                                         // Si el usuario guardó con éxito, refrescamos combo
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
            ComboPilotosInit();                                         // Si el usuario guardó con éxito, refrescamos combo
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
            ComboCochesInit();                                          // Si el usuario guardó con éxito, refrescamos combo
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
            ComboCategoriasInit();                                          // Si el usuario guardó con éxito, refrescamos combo
            comboCategorias.SelectedValue = formAlta.IdSelected ?? -1;      // seleccionamos la nueva categoria creada
            MostrarMensajeEstado("Categoria creada OK");
        }
        else
        {
            comboCategorias.SelectedValue = valorCategoriaSiCancela;            // Restauramos el valor anterior si el usuario cancela
            MostrarMensajeEstado("Operacion Cancelada");
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

            ComboCampeonatosInit();                                         // Si el usuario guardó con éxito, refrescamos este combo
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
            ComboPruebasInit();                                         // Si el usuario guardó con éxito, refrescamos este combo
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
            ComboPilotosInit();                                             // Si el usuario guardó con éxito, refrescamos este combo
            comboPilotos.SelectedValue = formEdicion.IdSelected ?? -1;      // seleccionamos el piloto editado o ninguno si es null
            MostrarMensajeEstado("Piloto modificado OK");
        }
    }

    private void BotonEditaCoche_Click(object sender, EventArgs e)
    {
        using var formEdicion = new FormCoche("Modificar Coche", comboCoches.SelectedValue);

        formEdicion.StartPosition = FormStartPosition.Manual;
        formEdicion.Location = groupBoxCto.PointToScreen(new Point(12, 8));

        if (formEdicion.ShowDialog(this) == DialogResult.OK)
        {
            ComboCochesInit();                                              // Si el usuario guardó con éxito, refrescamos este combo
            comboCoches.SelectedValue = formEdicion.IdSelected ?? -1;       // seleccionamos el coche editado o ninguno si es null
            MostrarMensajeEstado("Coche modificado OK");
        }
    }

    private void BotonEditaCategoria_Click(object sender, EventArgs e)
    {
        using var formEdicion = new FormCategoria("Modificar Categoria", comboCategorias.SelectedValue);

        formEdicion.StartPosition = FormStartPosition.Manual;
        formEdicion.Location = groupBoxCate.PointToScreen(new Point(0, 0));

        if (formEdicion.ShowDialog(this) == DialogResult.OK)
        {
            ComboCategoriasInit();                                             // Si el usuario guardó con éxito, refrescamos este combo
            comboCategorias.SelectedValue = formEdicion.IdSelected ?? -1;      // seleccionamos la categoria editada o ninguna si es null
            MostrarMensajeEstado("Categoria modificada OK");
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
                    ComboCampeonatosInit();                     // Actualizar interfaz

                    Limpia_DatosPrueba();                       // Limpiar TextBox 
                    ComboPruebasInit();                         // Actualizar interfaz

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
                    ComboPruebasInit();                         // Actualizar interfaz

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
                    ComboPilotosInit();                             // Actualizar interfaz

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
                    ComboCochesInit();                          // Actualizar interfaz

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

                    ComboCategoriasInit();                          // Actualizar interfaz

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
}
