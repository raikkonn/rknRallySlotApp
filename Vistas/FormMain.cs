using Microsoft.EntityFrameworkCore;
using rknRallySlotApp.Datos;
using rknRallySlotApp.Utilidades;

namespace rknRallySlotApp.Vistas;

public partial class FormMain : Form
{
    private readonly ToolTip _toolTip = new();
    public int? IdCampeonatoSeleccionado = null;    // ID del campeonato seleccionado (null con selección vacía)
    public int? IdPruebaSeleccionada = null;        // ID de la prueba seleccionada (null con selección vacía)
    public int? IdPilotoSeleccionado = null;        // ID del piloto seleccionado (null con selección vacía)
    public int? IdCocheSeleccionado = null;         // ID del coche seleccionado (null con selección vacía)

    public FormMain()
    {
        InitializeComponent();
        BotonesInit();
        ConfigurarToolTips();

        // inicializamos los ComboBox al cargar el formulario
        ComboCampeonatosInit();
        ComboPruebasInit();
        ComboPilotosInit();
        ComboCochesInit();
    }

    #region Botones Init

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
    }

    private void ControlesEnableDisable()
    {
        // Evaluamos el estado de cada ComboBox de forma individual con nombres únicos
        bool hayCampeonato = comboCampeonatos.SelectedValue is int idCamp && idCamp > 0;
        bool hayPrueba = comboPruebas.SelectedValue is int idPrueba && idPrueba > 0;
        bool hayPiloto = comboPilotos.SelectedValue is int idPiloto && idPiloto > 0;
        bool hayCoche = comboCoches.SelectedValue is int idCoche && idCoche > 0;

        // Asignamos los estados a los comboBoxes
        comboCampeonatos.Enabled = true;            // Siempre habilitado
        comboPruebas.Enabled = hayCampeonato;       // Habilitado solo si hay campeonato seleccionado
        comboPilotos.Enabled =  true;               // Siempre habilitado
        comboCoches.Enabled = true;                 // Siempre habilitado

        // Asignamos los estados a los botones
        // Campeonatos
        botonNuevoCampeonato.Enabled = true;
        botonEditaCampeonato.Enabled = hayCampeonato;
        botonBorraCampeonato.Enabled = hayCampeonato;

        // Pruebas (Nueva Prueba depende de Campeonato, Edición/Borrado de Prueba)
        botonNuevaPrueba.Enabled = hayCampeonato;
        botonEditaPrueba.Enabled = hayPrueba;
        botonBorraPrueba.Enabled = hayPrueba;

        // Pilotos
        botonNuevoPiloto.Enabled = true;
        botonEditaPiloto.Enabled = hayPiloto;
        botonBorraPiloto.Enabled = hayPiloto;

        // Coches
        botonNuevoCoche.Enabled = true;
        botonEditaCoche.Enabled = hayCoche;
        botonBorraCoche.Enabled = hayCoche;
    }

    #endregion

    #region ComboBox Init

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

            // Dejar Selección Vacia
            comboCampeonatos.SelectedIndex = -1;
            ControlesEnableDisable();
        }
        finally
        {
            // Reconectamos el evento después de la inicialización
            comboCampeonatos.SelectedIndexChanged += ComboCampeonatos_SelectedIndexChanged;
        }
    }

    private void ComboPruebasInit()
    {
        if (IdCampeonatoSeleccionado == null)
        {
            comboPruebas.DataSource = null; // Limpiamos el ComboBox si no hay campeonato seleccionado
            ControlesEnableDisable();
            return;
        } 

        // Desconectamos el evento para evitar que se dispare durante la inicialización
        comboPruebas.SelectedIndexChanged -= ComboPruebas_SelectedIndexChanged;

        try
        {
            using var db = new AppDbContext();

            // Obtenemos la lista de pruebas desde la base de datos
            var listaPruebas = db.Pruebas
                .Where(p => p.IdCampeonato == IdCampeonatoSeleccionado)
                .Select(p => new { p.Id, p.Nombre })
                .ToList();

            // Agregamos un elemento "comodín" al final de la lista
            listaPruebas.Add(new { Id = -5, Nombre = "- Añadir nuevo -" });

            // Asignamos la lista al ComboBox
            comboPruebas.DataSource = listaPruebas;
            comboPruebas.DisplayMember = "Nombre";
            comboPruebas.ValueMember = "Id";

            // Dejar Selección Vacia
            comboPruebas.SelectedIndex = -1;
            ControlesEnableDisable();
        }
        finally
        {
            comboPruebas.SelectedIndexChanged += ComboPruebas_SelectedIndexChanged;
        }
    }

    private void ComboPilotosInit()
    {
        // Desconectamos el evento para evitar que se dispare durante la inicialización
        comboPilotos.SelectedIndexChanged -= ComboPilotos_SelectedIndexChanged;

        try
        {
            using var db = new AppDbContext();

            // Obtenemos la lista de pilotos desde la base de datos
            var listaPilotos = db.Pilotos               
                .Select(p => new { p.Id, p.Nombre })
                .ToList();

            // Agregamos un elemento "comodín" al final de la lista
            listaPilotos.Add(new { Id = -5, Nombre = "- Añadir nuevo -" });

            // Asignamos la lista al ComboBox
            comboPilotos.DataSource = listaPilotos;
            comboPilotos.DisplayMember = "Nombre";
            comboPilotos.ValueMember = "Id";

            // Dejar Selección Vacia
            comboPilotos.SelectedIndex = -1;
            ControlesEnableDisable();
        }
        finally
        {
            comboPilotos.SelectedIndexChanged += ComboPilotos_SelectedIndexChanged;
        }
    }

    private void ComboCochesInit()
    {
        // Desconectamos el evento para evitar que se dispare durante la inicialización
        comboCoches.SelectedIndexChanged -= ComboCoches_SelectedIndexChanged;

        try
        {
            using var db = new AppDbContext();

            // Obtenemos la lista de coches desde la base de datos
            var listaCoches = db.Coches
                .Select(c => new { c.Id, c.Modelo })
                .ToList();

            // Agregamos un elemento "comodín" al final de la lista
            listaCoches.Add(new { Id = -5, Modelo = "- Añadir nuevo -" });

            // Asignamos la lista al ComboBox
            comboCoches.DataSource = listaCoches;
            comboCoches.DisplayMember = "Modelo";
            comboCoches.ValueMember = "Id";

            // Dejar Selección Vacia
            comboCoches.SelectedIndex = -1;
            ControlesEnableDisable();
        }
        finally
        {
            comboCoches.SelectedIndexChanged += ComboCoches_SelectedIndexChanged;
        }
    }

    #endregion

    #region comboBox SelectedIndexChanged Events    

    private void ComboCampeonatos_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (comboCampeonatos.SelectedValue is int idSel)
        {
            if (idSel > 0)                              // ID es válido 
            {
                IdCampeonatoSeleccionado = idSel;       // Guardamos el ID del campeonato seleccionado en miembro público
                Rellena_DatosCampeonato();              // Consultamos la DB para rellenar el TextBox de puntuaciones
                ComboPruebasInit();                     // Inicializamos el ComboBox de pruebas para el campeonato seleccionado
            }
            else if (idSel == -5)                       // opcion "- Añadir nuevo -" seleccionada, abrir formulario de alta
            {
                botonNuevoCampeonato.PerformClick();    // Simulamos click en el botón de nuevo campeonato      
            }
            else                                        // ID inválido, limpiar selecciones y TextBox
            {
                comboCampeonatos.SelectedIndex = -1;    // Limpiamos la selección del ComboBox de campeonatos
                comboPruebas.SelectedIndex = -1;        // Limpiamos la selección del ComboBox de pruebas

                IdCampeonatoSeleccionado = null;        // Limpiamos el ID del campeonato seleccionado
                IdPruebaSeleccionada = null;            // Limpiamos el ID de la prueba seleccionada

                Limpia_DatosCampeonato();               // Limpiamos el TextBox de puntuaciones
                Limpia_DatosPrueba();                   // Limpiamos los TextBox de datos de la prueba
            }
        }

        ControlesEnableDisable();                       // Actualizamos los controles después de la operación
    }

    private void ComboPruebas_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (comboPruebas.SelectedValue is int idSel)
        {
            if (idSel > 0)                          // si ID es válido 
            {
                IdPruebaSeleccionada = idSel;       // Guardamos el ID de la prueba seleccionada en miembro público
                Rellena_DatosPrueba();              // Consultamos la DB para rellenar los TextBox de datos de la prueba
            }
            else if (idSel == -5)                   // opcion "- Añadir nuevo -" seleccionada, abrir formulario de alta
            {
                botonNuevaPrueba.PerformClick();    // Simulamos click en el botón de nueva prueba      
            }
            else                                    // ID inválido, limpiar seleccines y TextBox
            {
                comboPruebas.SelectedIndex = -1;    // Limpiamos la selección del ComboBox de pruebas
                IdPruebaSeleccionada = null;        // Limpiamos el ID de la prueba seleccionada
                Limpia_DatosPrueba();               // Limpiamos los TextBox de datos de la prueba
            }

            ControlesEnableDisable();               // Actualizamos los controles después de la operación
        }
    }

    private void ComboPilotos_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (comboPilotos.SelectedValue is int idSel)
        {
            if (idSel > 0)                          // si ID es válido 
            {
                IdPilotoSeleccionado = idSel;       // Guardamos el ID del piloto seleccionado en miembro público
                Rellena_DatosPiloto();              // Consultamos la DB para rellenar los TextBox de datos del piloto
            }
            else if (idSel == -5)                   // opcion "- Añadir nuevo -" seleccionada, abrir formulario de alta
            {
                botonNuevoPiloto.PerformClick();    // Simulamos click en el botón de nuevo piloto      
            }
            else                                    // ID inválido, limpiar seleccines y TextBox
            {
                comboPilotos.SelectedIndex = -1;    // Limpiamos la selección del ComboBox de pilotos
                IdPilotoSeleccionado = null;        // Limpiamos el ID del piloto seleccionado
                Limpia_DatosPiloto();               // Limpiamos los TextBox de datos del piloto
            }

            ControlesEnableDisable();               // Actualizamos los controles después de la operación
        }
    }

    private void ComboCoches_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (comboCoches.SelectedValue is int idSel)
        {
            if (idSel > 0)                          // si ID es válido 
            {
                IdCocheSeleccionado = idSel;       // Guardamos el ID del coche seleccionado en miembro público
                Rellena_DatosCoche();              // Consultamos la DB para rellenar los TextBox de datos del coche
            }
            else if (idSel == -5)                   // opcion "- Añadir nuevo -" seleccionada, abrir formulario de alta
            {
                botonNuevoCoche.PerformClick();    // Simulamos click en el botón de nuevo coche      
            }
            else                                    // ID inválido, limpiar seleccines y TextBox
            {
                comboCoches.SelectedIndex = -1;    // Limpiamos la selección del ComboBox de coches
                IdCocheSeleccionado = null;        // Limpiamos el ID del coche seleccionado
                Limpia_DatosCoche();               // Limpiamos los TextBox de datos del coche
            }

            ControlesEnableDisable();               // Actualizamos los controles después de la operación
        }
    }

    #endregion

    #region Rellenar TextBox

    private void Rellena_DatosCampeonato()
    {
        using var db = new AppDbContext();

        var puntuaciones = db.Campeonatos
                            .Where(c => c.Id == IdCampeonatoSeleccionado)
                            .Select(c => c.SistemaPuntuacion)
                            .FirstOrDefault();

        tboxPuntuaciones.Text = string.IsNullOrEmpty(puntuaciones) ? "NO definido" : puntuaciones;
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
                                p.TiempoMaximo
                            })
                            .FirstOrDefault();

        if (prueba != null)
        {
            tboxEtapas.Text = string.IsNullOrEmpty(prueba.NumEtapas.ToString()) ? "NO def." : prueba.NumEtapas.ToString();
            tboxTramos.Text = string.IsNullOrEmpty(prueba.TramosPorEtapa.ToString()) ? "NO def." : prueba.TramosPorEtapa.ToString();
            tboxTmax.Text = string.IsNullOrEmpty(prueba.TiempoMaximo.ToString()) ? "NO def." : prueba.TiempoMaximo.ToString();
        }
        else
        {
            tboxEtapas.Clear();
            tboxTramos.Clear();
            tboxTmax.Clear();
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
            tboxAlias.Clear();
            tboxEscuderia.Clear();
        }
    }

    private void Rellena_DatosCoche()
    {
        using var db = new AppDbContext();

        var marca = db.Coches
                    .Where(c => c.Id == IdCocheSeleccionado)
                    .Select(c => c.Marca)
                    .FirstOrDefault();

        tboxMarca.Text = string.IsNullOrEmpty(marca) ? String.Empty : marca;
    }

    #endregion

    #region Limpiar TextBox

    private void Limpia_DatosCampeonato()
    {
        tboxPuntuaciones.Clear();
    }

    private void Limpia_DatosPrueba()
    {
        tboxEtapas.Clear();
        tboxTramos.Clear();
        tboxTmax.Clear();
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

    #endregion

    #region Botones Nuevo Click

    private void BotonNuevoCampeonato_Click(object sender, EventArgs e)
    {
        var valorPorSiCancela = comboCampeonatos.SelectedValue;     // Guardamos el valor actual por si el usuario cancela la operación

        comboCampeonatos.SelectedIndex = -1;                        // Limpiar la selección para el ALTA y evitar confusión 
        ControlesEnableDisable();                                   // Actualizar los controles después de la operación

        using var formAlta = new FormCampeonato("Nuevo Campeonato");

        formAlta.StartPosition = FormStartPosition.Manual;
        formAlta.Location = gBoxCampeonatoPrueba.PointToScreen(new Point(6,8));

        if (formAlta.ShowDialog(this) == DialogResult.OK)
        {
            ComboCampeonatosInit();                                         // Si el usuario guardó con éxito, refrescamos combo
            comboCampeonatos.SelectedValue = formAlta.IdSelected ?? -1;     // seleccionamos el nuevo campeonato creado
            MostrarMensajeEstado("Campeonato creado OK");
        }
        else
        {
            comboCampeonatos.SelectedValue = valorPorSiCancela ?? -1;       // Restauramos el valor anterior si el usuario cancela
            MostrarMensajeEstado("Operacion Cancelada");
        }

        ControlesEnableDisable();                                           // Actualizamos los controles después de la operación
    }

    private void BotonNuevaPrueba_Click(object sender, EventArgs e)
    {
        var valorPorSiCancela = comboPruebas.SelectedValue;     // Guardamos el valor actual por si el usuario cancela la operación

        comboPruebas.SelectedIndex = -1;                        // Limpiar la selección para el ALTA y evitar confusión
        ControlesEnableDisable();                               // Actualizar los controles después de la operación

        using var formAlta = new FormPrueba("Nueva Prueba");

        formAlta.StartPosition = FormStartPosition.Manual;
        formAlta.Location = gBoxCampeonatoPrueba.PointToScreen(new Point(6,8));

        if (formAlta.ShowDialog(this) == DialogResult.OK)
        {
            ComboPruebasInit();                                         // Si el usuario guardó con éxito, refrescamos combo
            comboPruebas.SelectedValue = formAlta.IdSelected ?? -1;     // seleccionamos la nueva prueba creada
            MostrarMensajeEstado("Prueba creada OK");
        }
        else
        {
            comboPruebas.SelectedValue = valorPorSiCancela ?? -1;       // Restauramos el valor anterior si el usuario cancela
            MostrarMensajeEstado("Operacion Cancelada");
        }

        ControlesEnableDisable();                                       // Actualizamos los controles después de la operación
    }

    private void BotonNuevoPiloto_Click(object sender, EventArgs e)
    {
        var valorPorSiCancela = comboPilotos.SelectedValue;     // Guardamos el valor actual por si el usuario cancela la operación

        comboPilotos.SelectedIndex = -1;                        // Limpiar la selección para el ALTA y evitar confusión
        ControlesEnableDisable();                               // Actualizar los controles después de la operación

        using var formAlta = new FormPiloto("Nuevo Piloto");

        formAlta.StartPosition = FormStartPosition.Manual;
        formAlta.Location = gBoxCampeonatoPrueba.PointToScreen(new Point(6,8));

        if (formAlta.ShowDialog(this) == DialogResult.OK)
        {
            ComboPilotosInit();                                         // Si el usuario guardó con éxito, refrescamos combo
            comboPilotos.SelectedValue = formAlta.IdSelected ?? -1;     // seleccionamos el nuevo piloto creado
            MostrarMensajeEstado("Piloto creado OK");
        }
        else
        {
            comboPilotos.SelectedValue = valorPorSiCancela ?? -1;  // Restauramos el valor anterior si el usuario cancela
            MostrarMensajeEstado("Operacion Cancelada");
        }

        ControlesEnableDisable();                                       // Actualizamos los controles después de la operación
    }

    private void BotonNuevoCoche_Click(object sender, EventArgs e)
    {
        var valorPorSiCancela = comboCoches.SelectedValue;      // Guardamos el valor actual por si el usuario cancela la operación

        comboCoches.SelectedIndex = -1;                         // Limpiar la selección para el ALTA y evitar confusión 
        ControlesEnableDisable();                               // Actualizar los controles después de la operación

        using var formAlta = new FormCoche("Nuevo Coche");

        formAlta.StartPosition = FormStartPosition.Manual;
        formAlta.Location = gBoxCampeonatoPrueba.PointToScreen(new Point(6, 8));

        if (formAlta.ShowDialog(this) == DialogResult.OK)
        {
            ComboCochesInit();                                          // Si el usuario guardó con éxito, refrescamos combo
            comboCoches.SelectedValue = formAlta.IdSelected ?? -1;      // seleccionamos el nuevo coche creado
            MostrarMensajeEstado("Coche creado OK");
        }
        else
        {
            comboCoches.SelectedValue = valorPorSiCancela ?? -1;         // Restauramos el valor anterior si el usuario cancela
            MostrarMensajeEstado("Operacion Cancelada");
        }

        ControlesEnableDisable();                                       // Actualizamos los controles después de la operación
    }

    #endregion

    #region Botones Editar Click

    private void BotonEditaCampeonato_Click(object sender, EventArgs e)
    {
        using var formEdicion = new FormCampeonato("Modificar Campeonato", comboCampeonatos.SelectedValue);

        formEdicion.StartPosition = FormStartPosition.Manual;
        formEdicion.Location = gBoxCampeonatoPrueba.PointToScreen(new Point(6,8));

        if (formEdicion.ShowDialog(this) == DialogResult.OK)
        {
            ComboCampeonatosInit();                                         // Si el usuario guardó con éxito, refrescamos este combo
            comboCampeonatos.SelectedValue = formEdicion.IdSelected ?? -1;  // seleccionamos el campeonato editado o ninguno si es null
            ControlesEnableDisable();                                       // Actualizamos los controles después de la operación
            MostrarMensajeEstado("Campeonato modificado OK");
        }
    }

    private void BotonEditaPrueba_Click(object sender, EventArgs e)
    {
        using var formEdicion = new FormPrueba("Modificar Prueba", comboPruebas.SelectedValue);

        formEdicion.StartPosition = FormStartPosition.Manual;
        formEdicion.Location = gBoxCampeonatoPrueba.PointToScreen(new Point(6,8));

        if (formEdicion.ShowDialog(this) == DialogResult.OK)
        {
            ComboPruebasInit();                                         // Si el usuario guardó con éxito, refrescamos este combo
            comboPruebas.SelectedValue = formEdicion.IdSelected ?? -1;  // seleccionamos la prueba editada o ninguna si es null
            ControlesEnableDisable();                                   // Actualizamos los controles después de la operación
            MostrarMensajeEstado("Prueba modificada OK");
        }
    }

    private void BotonEditaPiloto_Click(object sender, EventArgs e)
    {
        using var formEdicion = new FormPiloto("Modificar Piloto", comboPilotos.SelectedValue);
        
        formEdicion.StartPosition = FormStartPosition.Manual;
        formEdicion.Location = gBoxCampeonatoPrueba.PointToScreen(new Point(6,8));

        if (formEdicion.ShowDialog(this) == DialogResult.OK)
        {
            ComboPilotosInit();                                             // Si el usuario guardó con éxito, refrescamos este combo
            comboPilotos.SelectedValue = formEdicion.IdSelected ?? -1;      // seleccionamos el piloto editado o ninguno si es null
            ControlesEnableDisable();                                       // Actualizamos los controles después de la operación
            MostrarMensajeEstado("Piloto modificado OK");
        }
    }

    private void BotonEditaCoche_Click(object sender, EventArgs e)
    {
        using var formEdicion = new FormCoche("Modificar Coche", comboCoches.SelectedValue);

        formEdicion.StartPosition = FormStartPosition.Manual;
        formEdicion.Location = gBoxCampeonatoPrueba.PointToScreen(new Point(6, 8));

        if (formEdicion.ShowDialog(this) == DialogResult.OK)
        {
            ComboCochesInit();                                              // Si el usuario guardó con éxito, refrescamos este combo
            comboCoches.SelectedValue = formEdicion.IdSelected ?? -1;       // seleccionamos el coche editado o ninguno si es null
            ControlesEnableDisable();                                       // Actualizamos los controles después de la operación
            MostrarMensajeEstado("Coche modificado OK");
        }
    }

    #endregion

    #region Botones Borrar Click

    private void BotonBorraCampeonato_Click(object sender, EventArgs e)
    {
        // Validar ID campeonato seleccionado en ComboBox
        if (comboCampeonatos.SelectedValue is int idSel && idSel > 0)
        {
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
                    using var db = new AppDbContext();  // Contexto DB

                    var ctoParaBorrado = db.Campeonatos.Find(idSel);    // DB, buscar por ID

                    if (ctoParaBorrado != null)
                    {
                        db.Campeonatos.Remove(ctoParaBorrado);  // DB, marcar para borrado
                        db.SaveChanges();                       // SQLite, guardar cambios 
                        ComboCampeonatosInit();                 // Actualizar interfaz

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
        else
        {
            MostrarMensajeEstado("Selecciona campeonato válido");
        }
    }

    private void BotonBorraPrueba_Click(object sender, EventArgs e)
    {
        // Validar ID prueba seleccionada en ComboBox
        if (comboPruebas.SelectedValue is int idSel && idSel > 0)
        {
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
                    using var db = new AppDbContext();              // Contexto DB

                    var pruebaParaBorrado = db.Pruebas.Find(idSel); // DB, buscar por ID

                    if (pruebaParaBorrado != null)
                    {
                        db.Pruebas.Remove(pruebaParaBorrado);       // DB, marcar para borrado
                        db.SaveChanges();                           // SQLite, guardar cambios 
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
        else
        {
            MostrarMensajeEstado("Selecciona prueba válida");
        }
    }

    private void BotonBorraPiloto_Click(object sender, EventArgs e)
    {
        // Validar ID piloto seleccionado en ComboBox
        if (comboPilotos.SelectedValue is int idSel && idSel > 0)
        {
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
                    using var db = new AppDbContext();  // Contexto DB

                    var pilotoParaBorrado = db.Pilotos.Find(idSel);    // DB, buscar por ID

                    if (pilotoParaBorrado != null)
                    {
                        db.Pilotos.Remove(pilotoParaBorrado);           // DB, marcar para borrado
                        db.SaveChanges();                               // SQLite, guardar cambios 
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
        else
        {
            MostrarMensajeEstado("Selecciona piloto válido");
        }
    }

    private void BotonBorraCoche_Click(object sender, EventArgs e)
    {
        // Validar ID coche seleccionado en ComboBox
        if (comboCoches.SelectedValue is int idSel && idSel > 0)
        {
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
        else
        {
            MostrarMensajeEstado("Selecciona coche válido");
        }
    }

    #endregion

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

    #region otros

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

    #endregion
}
