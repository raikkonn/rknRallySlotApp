using Microsoft.EntityFrameworkCore;
using rknRallySlotApp.Datos;
using rknRallySlotApp.Utilidades;

namespace rknRallySlotApp.Vistas;

public partial class FormMain : Form
{
    private readonly ToolTip _toolTip = new();
    public int? IdCampeonatoSeleccionado = null;  // ID del campeonato seleccionado (null con selección vacía)
    public int? IdPruebaSeleccionada = null;      // ID de la prueba seleccionada (null con selección vacía)
    public int? IdPilotoSeleccionado = null;      // ID del piloto seleccionado (null con selección vacía)
    public int? IdCocheSeleccionado = null;      // ID del coche seleccionado (null con selección vacía)

    public FormMain()
    {
        InitializeComponent();
        BotonesInit();
        ConfigurarToolTips();
        ComboCampeonatosInit();
    }

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
        if (comboCampeonatos.SelectedValue is int idCto && idCto > 0)   // campeonato VÁlIDO seleccionado
        {
            IdCampeonatoSeleccionado = idCto;           // Guardamos el ID del campeonato seleccionado en miembro público   
            botonNuevoCampeonato.Enabled = true;        // Siempre habilitado para crear nuevos campeonatos
            botonEditaCampeonato.Enabled = true;        // Habilitado para editar el campeonato seleccionado
            botonBorraCampeonato.Enabled = true;        // Habilitado para borrar el campeonato seleccionado

            comboPruebas.Enabled = true;                // Habilitado para seleccionar pruebas del campeonato seleccionado

            if (comboPruebas.SelectedValue is int iPrueba && iPrueba > 0)   // prueba VÁLIDA seleccionada
            {
                IdPruebaSeleccionada = iPrueba;         // Guardamos el ID de la prueba seleccionada en miembro público
                botonNuevaPrueba.Enabled = true;        // Siempre habilitado para crear nuevas pruebas
                botonEditaPrueba.Enabled = true;        // Habilitado para editar la prueba seleccionada
                botonBorraPrueba.Enabled = true;        // Habilitado para borrar la prueba seleccionada
            }
            else    // prueba INVÁlIDA o SIN selección
            {
                IdPruebaSeleccionada = null;            // Limpiamos el ID de la prueba seleccionada
                comboPruebas.SelectedIndex = -1;        // Limpiamos la selección del ComboBox de pruebas

                tboxEtapas.Clear();                     // Sin selección activa, limpiar TextBox
                tboxTramos.Clear();
                tboxTmax.Clear();

                botonNuevaPrueba.Enabled = true;        // Siempre habilitado para crear nuevas pruebas
                botonEditaPrueba.Enabled = false;       // Deshabilitado SIN prueba seleccionada
                botonBorraPrueba.Enabled = false;       // Deshabilitado SIN prueba seleccionada
            }
        }
        else    // campeonato INVÁlIDO o SIN selección
        {
            IdCampeonatoSeleccionado = null;        // Limpiamos el ID del campeonato seleccionado
            comboCampeonatos.SelectedIndex = -1;    // Limpiamos la selección del ComboBox de campeonatos

            tboxPuntuaciones.Clear();               // Sin selección activa, limpiar TextBox    

            botonNuevoCampeonato.Enabled = true;    // Siempre habilitado para crear nuevos campeonatos
            botonEditaCampeonato.Enabled = false;   // Deshabilitado SIN campeonato seleccionado
            botonBorraCampeonato.Enabled = false;   // Deshabilitado SIN campeonato seleccionado

            IdPruebaSeleccionada = null;                  // Limpiamos el ID de la prueba seleccionada
            comboPruebas.SelectedIndex = -1;        // Limpiamos la selección del ComboBox de pruebas
            comboPruebas.Enabled = false;           // Deshabilitado SIN campeonato seleccionado

            tboxEtapas.Clear();                     // Sin selección activa, limpiar TextBox
            tboxTramos.Clear();
            tboxTmax.Clear();

            botonNuevaPrueba.Enabled = false;       // Deshabilitado SIN campeonato seleccionado
            botonEditaPrueba.Enabled = false;       // Deshabilitado SIN prueba seleccionada
            botonBorraPrueba.Enabled = false;       // Deshabilitado SIN prueba seleccionada
        }

        botonNuevoPiloto.Enabled = true;
        botonEditaPiloto.Enabled = true;
        botonBorraPiloto.Enabled = true;

        botonNuevoCoche.Enabled = true; 
        botonEditaCoche.Enabled = true;
        botonBorraCoche.Enabled = true;
    }

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

    private void ComboCampeonatos_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (comboCampeonatos.SelectedValue is int idSel)
        {
            if (idSel > 0)                              // ID es válido 
            {
                IdCampeonatoSeleccionado = idSel;             // Guardamos el ID del campeonato seleccionado en miembro público
                Consulta_PuntuacionesCampeonato();      // Consultamos la DB para rellenar el TextBox de puntuaciones
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

                IdCampeonatoSeleccionado = null;              // Limpiamos el ID del campeonato seleccionado
                IdPruebaSeleccionada = null;                  // Limpiamos el ID de la prueba seleccionada
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
                Consulta_DatosPrueba();             // Consultamos la DB para rellenar los TextBox de datos de la prueba
            }
            else if (idSel == -5)                   // opcion "- Añadir nuevo -" seleccionada, abrir formulario de alta
            {
                botonNuevaPrueba.PerformClick();    // Simulamos click en el botón de nueva prueba      
            }
            else                                    // ID inválido, limpiar seleccines y TextBox
            {
                comboPruebas.SelectedIndex = -1;    // Limpiamos la selección del ComboBox de pruebas
                IdPruebaSeleccionada = null;        // Limpiamos el ID de la prueba seleccionada
            }

            ControlesEnableDisable();               // Actualizamos los controles después de la operación
        }
    }

    private void ComboPilotos_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void ComboCoches_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void Consulta_PuntuacionesCampeonato()
    {
        using var db = new AppDbContext();

        var puntuaciones = db.Campeonatos
                              .Where(c => c.Id == IdCampeonatoSeleccionado)
                              .Select(c => c.SistemaPuntuacion)
                              .FirstOrDefault();

        tboxPuntuaciones.Text = !string.IsNullOrEmpty(puntuaciones) ? puntuaciones : "NO definido";
    }

    private void Consulta_DatosPrueba()
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
            tboxEtapas.Text = !string.IsNullOrEmpty(prueba.NumEtapas.ToString()) ? prueba.NumEtapas.ToString() : "NO def.";
            tboxTramos.Text = !string.IsNullOrEmpty(prueba.TramosPorEtapa.ToString()) ? prueba.TramosPorEtapa.ToString() : "NO def.";
            tboxTmax.Text = !string.IsNullOrEmpty(prueba.TiempoMaximo.ToString()) ? prueba.TiempoMaximo.ToString() : "NO def.";
        }
        else
        {
            tboxEtapas.Clear();
            tboxTramos.Clear();
            tboxTmax.Clear();
        }
    }

    private void BotonNuevoCampeonato_Click(object sender, EventArgs e)
    {
        comboCampeonatos.SelectedIndex = -1;    // Limpiar la selección para evitar confusión 
        ControlesEnableDisable();               // Actualizar los controles después de la operación

        // Alta de un nuevo campeonato
        using var formAlta = new FormCampeonato("Nuevo Campeonato");

        if (formAlta.ShowDialog(this) == DialogResult.OK)
        {
            ComboCampeonatosInit();                                         // Si el usuario guardó con éxito, refrescamos combo
            comboCampeonatos.SelectedValue = formAlta.IdSelected ?? -1;     // seleccionamos el nuevo campeonato creado
            ControlesEnableDisable();                                       // Actualizamos los controles después de la operación
            MostrarMensajeEstado("Campeonato creado OK");
        }
        else
        {
            comboCampeonatos.SelectedIndex = -1;                            // Si canceló, vaciamos el combo
            ControlesEnableDisable();                                       // Actualizamos los controles después de la operación
            MostrarMensajeEstado("Operacion Cancelada");
        }
    }

    private void BotonNuevaPrueba_Click(object sender, EventArgs e)
    {
        comboPruebas.SelectedIndex = -1;        // Limpiar la selección para evitar confusión 
        ControlesEnableDisable();               // Actualizar los controles después de la operación

        // Alta de una nueva prueba
        using var formAlta = new FormPrueba("Nueva Prueba");

        if (formAlta.ShowDialog(this) == DialogResult.OK)
        {
            ComboPruebasInit();                                         // Si el usuario guardó con éxito, refrescamos combo
            comboPruebas.SelectedValue = formAlta.IdSelected ?? -1;     // seleccionamos la nueva prueba creada
            ControlesEnableDisable();                                   // Actualizamos los controles después de la operación
            MostrarMensajeEstado("Prueba creada OK");
        }
        else
        {
            comboCampeonatos.SelectedIndex = -1;                        // Si canceló, vaciamos el combo
            ControlesEnableDisable();                                   // Actualizamos los controles después de la operación
            MostrarMensajeEstado("Operacion Cancelada");
        }
    }

    private void BotonNuevoPiloto_Click(object sender, EventArgs e)
    {

    }

    private void BotonNuevoCoche_Click(object sender, EventArgs e)
    {

    }

    private void BotonEditaCampeonato_Click(object sender, EventArgs e)
    {
        using var formEdicion = new FormCampeonato("Modificar Campeonato", comboCampeonatos.SelectedValue);

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

    }

    private void BotonEditaCoche_Click(object sender, EventArgs e)
    {

    }

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
                MessageBoxIcon.Question);

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
                MessageBoxIcon.Question);

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

    }

    private void BotonBorraCoche_Click(object sender, EventArgs e)
    {

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
}
