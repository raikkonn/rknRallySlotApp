using Microsoft.EntityFrameworkCore;
using rknRallySlotApp.Datos;
using rknRallySlotApp.Modelos;
using rknRallySlotApp.Utilidades;

namespace rknRallySlotApp.Vistas;

public partial class FormCampeonato : Form
{
    private readonly ToolTip _toolTip = new();
    public int? IdSelected = null;  // ID del campeonato seleccionado (null si es un nuevo registro)

    public FormCampeonato(String? titulo = null, object? id = null)
    {
        InitializeComponent();
        BotonesInit();  // Asignacion de imagenes a los botones
        ConfigurarToolTips();

        lblForm.Text = titulo ?? String.Empty;
        
        if ((id is int idSel) && (idSel > 0))  
        {
            ConsultaCampeonato(idSel);
            IdSelected = idSel;
        }
        else
        {
            tboxCampeonato.Text = String.Empty;
            tboxPuntuacion.Text = String.Empty;
        }

        botonSave.Enabled = !string.IsNullOrWhiteSpace(tboxCampeonato.Text);
    }

    private void BotonesInit()
    {
        botonSave.Image = Properties.Resources.save_b.Zoom(botonSave.Width - 5, botonSave.Height - 5);
        botonSave.ImageAlign = ContentAlignment.MiddleCenter;
        botonSave.Enabled = false;

        botonCancel.Image = Properties.Resources.cancel_r.Zoom(botonCancel.Width - 15, botonCancel.Height - 15);
        botonCancel.ImageAlign = ContentAlignment.MiddleCenter;
        botonCancel.Enabled = true;
    }

    private void ConfigurarToolTips()
    {
        _toolTip.SetToolTip(botonSave, "Grabar");
        _toolTip.SetToolTip(botonCancel, "Cancelar");
    }

    private void ConsultaCampeonato(int id)
    {
        using var db = new AppDbContext();

        // Consultamos y proyectamos únicamente las dos columnas necesarias
        var cto = db.Campeonatos
                    .Where(c => c.Id == id)
                    .Select(c => new
                    {
                        c.Nombre,
                        c.SistemaPuntuacion
                    })
                    .FirstOrDefault();

        if (cto != null)
        {
            tboxCampeonato.Text = cto.Nombre ?? string.Empty;
            tboxPuntuacion.Text = cto.SistemaPuntuacion ?? string.Empty;
        }
        else // Si no se encuentra el registro o se pasa un ID no válido
        {
            tboxCampeonato.Text = string.Empty;
            tboxPuntuacion.Text = string.Empty;
        }
    }

    private void TboxCampeonato_TextChanged(object sender, EventArgs e)
    {
        botonSave.Enabled = !string.IsNullOrWhiteSpace(tboxCampeonato.Text);
    }

    private void BotonCancel_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void BotonSave_Click(object sender, EventArgs e)
    {
        // Saneado texto
        string nombreLimpio = TxtTools.TrimCleanAndTitle(tboxCampeonato.Text);

        using var db = new AppDbContext();

        // Comprueba si existe ese nombre PERO excluyendo el campeonato que estamos editando actualmente
        bool existe = db.Campeonatos.Any( c =>
            (c.Nombre.ToLower() == nombreLimpio.ToLower())
            && (!IdSelected.HasValue || c.Id != IdSelected.Value));

        if (existe)
        {
            MessageBox.Show($"Ya existe un campeonato registrado como '{nombreLimpio}'.",
                            "Nombre Duplicado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
            tboxCampeonato.Focus();
            tboxCampeonato.SelectAll();
        }
        else
        { 
            try
            {
                Campeonato? campeonatoActual;

                if (IdSelected.HasValue) // Si tenemos un ID, estamos en MODO EDICION
                {
                    campeonatoActual = db.Campeonatos.Find(IdSelected.Value);

                    if (campeonatoActual == null)
                    {
                        MessageBox.Show("NO existe ese campeonato en la base de datos.",
                                        "Registro no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Sobrescribimos sus propiedades. EF Core detecta estos cambios automáticamente.
                    campeonatoActual.Nombre = nombreLimpio;
                    campeonatoActual.SistemaPuntuacion = TxtTools.TrimAndClean(tboxPuntuacion.Text);
                }
                else // Si no tenemos un ID, estamos en MODO ALTA 
                {
                    campeonatoActual = new Campeonato
                    {
                        Nombre = nombreLimpio,
                        SistemaPuntuacion = TxtTools.TrimAndClean(tboxPuntuacion.Text)
                    };

                    db.Campeonatos.Add(campeonatoActual);   // Añadir registro nuevo (INSERT)
                }

                // Si Alta, hace un INSERT. Si Edición, hace un UPDATE solo de los campos modificados.
                db.SaveChanges();

                // Capturamos el ID para devolverlo al FormMain (sea el recién creado o el que acabamos de editar)
                IdSelected = campeonatoActual.Id;

                // Retornamos OK y cerramos la ventana modal
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"Error al guardar en la base de datos: {ex.Message}",
                                "Error de Persistencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

    }

    private void All_tbox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            // Evita el sonido 'beep' por defecto de Windows
            e.SuppressKeyPress = true;

            // Ejecuta el click del botón si está habilitado
            if (botonSave.Enabled)
            {
                botonSave.PerformClick();
            }
        }

        if (e.KeyCode == Keys.Escape)
        {
            // Evita el sonido 'beep' por defecto de Windows
            e.SuppressKeyPress = true;

            // Ejecuta el click del botón si está habilitado
            if (botonCancel.Enabled)
            {
                botonCancel.PerformClick();
            }
        }
    }
}
