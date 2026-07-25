using Microsoft.EntityFrameworkCore;
using rknRallySlotApp.Datos;
using rknRallySlotApp.Utilidades;

namespace rknRallySlotApp.Vistas;

public partial class FormMain : Form
{
    private readonly ToolTip _toolTip = new();
    public int? IdCampeonatoActual = null;  // ID del campeonato seleccionado (null con selección vacía)
    public int? IdPruebaActual = null;      // ID de la prueba seleccionada (null con selección vacía)

    public FormMain()
    {
        InitializeComponent();
        BotonesInit();
        ConfigurarToolTips();
        ComboCampeonatosInit();
    }

    private void BotonesInit()
    {
        botonNuevoCampeonato.Image = Properties.Resources.new_b.Zoom(botonEditaCampeonato.Width - 5, botonEditaCampeonato.Height - 5);
        botonNuevoCampeonato.ImageAlign = ContentAlignment.MiddleCenter;

        botonEditaCampeonato.Image = Properties.Resources.pencil_b.Zoom(botonEditaCampeonato.Width - 5, botonEditaCampeonato.Height - 5);
        botonEditaCampeonato.ImageAlign = ContentAlignment.MiddleCenter;

        botonBorraCampeonato.Image = Properties.Resources.del_r.Zoom(botonEditaCampeonato.Width - 5, botonEditaCampeonato.Height - 5);
        botonBorraCampeonato.ImageAlign = ContentAlignment.MiddleCenter;

        botonNuevaPrueba.Image = Properties.Resources.new_b.Zoom(botonEditaCampeonato.Width - 5, botonEditaCampeonato.Height - 5);
        botonNuevaPrueba.ImageAlign = ContentAlignment.MiddleCenter;

        botonEditaPrueba.Image = Properties.Resources.pencil_b.Zoom(botonEditaCampeonato.Width - 5, botonEditaCampeonato.Height - 5);
        botonEditaPrueba.ImageAlign = ContentAlignment.MiddleCenter;

        botonBorraPrueba.Image = Properties.Resources.del_r.Zoom(botonEditaCampeonato.Width - 5, botonEditaCampeonato.Height - 5);
        botonBorraPrueba.ImageAlign = ContentAlignment.MiddleCenter;
    }

    private void ConfigurarToolTips()
    {
        _toolTip.SetToolTip(botonNuevoCampeonato, "Nuevo Campeonato");
        _toolTip.SetToolTip(botonEditaCampeonato, "Modificar Campeonato");
        _toolTip.SetToolTip(botonBorraCampeonato, "Borrar Campeonato");
        _toolTip.SetToolTip(botonNuevaPrueba, "Nueva Prueba");
        _toolTip.SetToolTip(botonEditaPrueba, "Modificar Prueba");
        _toolTip.SetToolTip(botonBorraPrueba, "Borrar Prueba");
    }

    private void ControlesEnableDisable()
    {
        if (comboCampeonatos.SelectedValue is int idCto && idCto > 0)
        {
            botonNuevoCampeonato.Enabled = true;
            botonEditaCampeonato.Enabled = true;
            botonBorraCampeonato.Enabled = true;

            comboPruebas.Enabled = true;

            if (comboPruebas.SelectedValue is int iPrueba && iPrueba > 0)
            {
                botonNuevaPrueba.Enabled = true;
                botonEditaPrueba.Enabled = true;
                botonBorraPrueba.Enabled = true;
            }
            else
            {
                botonNuevaPrueba.Enabled = true;
                botonEditaPrueba.Enabled = false;
                botonBorraPrueba.Enabled = false;
            }
        }
        else
        {
            tboxPuntuaciones.Clear();

            botonNuevoCampeonato.Enabled = true;
            botonEditaCampeonato.Enabled = false;
            botonBorraCampeonato.Enabled = false;

            comboPruebas.Enabled = false;

            botonNuevaPrueba.Enabled = false;
            botonEditaPrueba.Enabled = false;
            botonBorraPrueba.Enabled = false;
        }
    }

    private void ComboCampeonatosInit()
    {
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
            comboCampeonatos.SelectedIndexChanged += ComboCampeonatos_SelectedIndexChanged;
        }
    }

    private void ComboPruebasInit()
    {
        comboPruebas.SelectedIndexChanged -= ComboPruebas_SelectedIndexChanged;

        try
        {
            using var db = new AppDbContext();

            // Obtenemos la lista de pruebas desde la base de datos
            var listaPruebas = db.Pruebas
                .Where(p => p.IdCampeonato == IdCampeonatoActual)
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

    private void ComboCampeonatos_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (comboCampeonatos.SelectedValue is int idSel)
        {
            if (idSel > 0)                              // si ID es válido 
            {
                IdCampeonatoActual = idSel;             // Guardamos el ID del campeonato seleccionado en miembro público
                Consulta_PuntuacionesCampeonato();      // consultar DB
                ComboPruebasInit();                     // Inicializamos Combo Pruebas para el campeonato seleccionado
            }
            else if (idSel == -5)                       // opcion "- Añadir nuevo -" seleccionada, abrir formulario de alta
            {
                botonNuevoCampeonato.PerformClick();    // Simulamos click en el botón de nuevo campeonato      
            }
            else                                        // ID inválido, limpiar selección y TextBox
            {
                IdCampeonatoActual = null;              // Limpiamos el ID del campeonato seleccionado
                tboxPuntuaciones.Clear();               // Sin selección activa, limpiamos el TextBox

                IdPruebaActual = null;                  // Limpiamos el ID de la prueba seleccionada
                // limpiar textos de la prueba si los hubiera

                ControlesEnableDisable();               // Actualizamos los controles después de la operación
            }
        }
    }

    private void Consulta_PuntuacionesCampeonato()
    {
        using var db = new AppDbContext();

        var puntuaciones = db.Campeonatos
                              .Where(c => c.Id == IdCampeonatoActual)
                              .Select(c => c.SistemaPuntuacion)
                              .FirstOrDefault();

        tboxPuntuaciones.Text = string.IsNullOrEmpty(puntuaciones) ? "NO definido" : puntuaciones;
    }

    private void AltaCampeonato()
    {
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
            comboCampeonatos.SelectedIndex = -1;        // Si canceló, vaciamos el combo
            ControlesEnableDisable();                   // Actualizamos los controles después de la operación
            MostrarMensajeEstado("Operacion Cancelada");
        }
    }

    private void BotonNuevoCampeonato_Click(object sender, EventArgs e)
    {
        comboCampeonatos.SelectedIndex = -1;    // Limpiar la selección para evitar confusión 
        tboxPuntuaciones.Clear();               // Sin selección activa, limpiar TextBox
        ControlesEnableDisable();               // Actualizar los controles después de la operación
        AltaCampeonato();                       // Abrir alta de un nuevo campeonato
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

    private void ComboPruebas_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (comboPruebas.SelectedValue is int idSel)
        {
            if (idSel > 0)                          // si ID es válido 
            {
                IdPruebaActual = idSel;             // Guardamos el ID de la prueba seleccionada en miembro público

                // consultar DB textos prueba y rellenar controles
            }
            else if (idSel == -5)                       // opcion "- Añadir nuevo -" seleccionada, abrir formulario de alta
            {
                botonNuevaPrueba.PerformClick();        // Simulamos click en el botón de nuevo prueba      
            }
            else                                        // ID inválido, limpiar selección y TextBox
            {
                IdPruebaActual = null;                  // Limpiamos el ID de la prueba seleccionada
                // Sin selección activa, limpiamos el TextBox
                ControlesEnableDisable();               // Actualizamos los controles después de la operación
            }
        }

    }

    private void BotonNuevaPrueba_Click(object sender, EventArgs e)
    {
        comboPruebas.SelectedIndex = -1;    // Limpiar la selección para evitar confusión 
        // Sin selección activa, limpiar TextBox
        ControlesEnableDisable();               // Actualizar los controles después de la operación
        AltaPrueba();                       // Abrir alta de un nuevo campeonato
    }

    private void AltaPrueba()
    {
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
            comboCampeonatos.SelectedIndex = -1;        // Si canceló, vaciamos el combo
            ControlesEnableDisable();                   // Actualizamos los controles después de la operación
            MostrarMensajeEstado("Operacion Cancelada");
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
}

