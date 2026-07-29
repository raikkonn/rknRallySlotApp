using Microsoft.EntityFrameworkCore;
using rknRallySlotApp.Datos;
using rknRallySlotApp.Modelos;
using rknRallySlotApp.Utilidades;

namespace rknRallySlotApp.Vistas;

public partial class FormCoche : Form
{
    private readonly ToolTip _toolTip = new();
    public int? IdSelected = null;  // ID del coche seleccionado (null si es un nuevo registro)

    public FormCoche(String? titulo = null, object? id = null)
    {
        InitializeComponent();
        BotonesInit();              // Asignacion de imagenes a los botones
        ConfigurarToolTips();

        lblForm.Text = titulo ?? String.Empty;

        if ((id is int idSel) && (idSel > 0))
        {
            IdSelected = idSel;
            RellenaCoche(idSel);
        }
        else
        {
            IdSelected = null;
            tboxModelo.Text = String.Empty;
            tboxMarca.Text = String.Empty;
        }

        ControlesEnableDisable();
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

    private void ControlesEnableDisable()
    {
        botonSave.Enabled = !string.IsNullOrWhiteSpace(tboxModelo.Text);
    }

    private void RellenaCoche(int id)
    {
        using var db = new AppDbContext();

        var coche = db.Coches
                        .Where(c => c.Id == id)
                        .Select(c => new
                        {
                            c.Modelo,
                            c.Marca
                        })
                        .FirstOrDefault();

        if (coche != null)
        {
            tboxModelo.Text = coche.Modelo ?? string.Empty;
            tboxMarca.Text = coche.Marca ?? string.Empty;
        }
        else // Si no se encuentra el registro o se pasa un ID no válido
        {
            tboxModelo.Text = string.Empty;
            tboxMarca.Text = string.Empty;
        }
    }

    private void TboxModelo_Leave(object sender, EventArgs e)
    {
        // Saneado texto
        string modeloLimpio = TxtTools.TrimCleanAndTitle(tboxModelo.Text);
        tboxModelo.Text = modeloLimpio;
    }

    private void TboxMarca_Leave(object sender, EventArgs e)
    {
        // Saneado texto
        string marcaLimpia = TxtTools.TrimAndClean(tboxMarca.Text).ToUpper();
        tboxMarca.Text = marcaLimpia;
    }

    private void TboxCoche_TextChanged(object sender, EventArgs e)
    {
        ControlesEnableDisable();
    }

    private void BotonCancel_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void BotonSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(tboxModelo.Text))
        {
            tboxModelo.Focus();
            tboxModelo.SelectAll();
            return;
        }

        // Saneado texto
        string modeloLimpio = TxtTools.TrimCleanAndTitle(tboxModelo.Text);
        tboxModelo.Text = modeloLimpio;

        string marcaLimpia = TxtTools.TrimAndClean(tboxMarca.Text).ToUpper();
        tboxMarca.Text = marcaLimpia;

        using var db = new AppDbContext();

        try
        {
            Coche? cocheActual;

            if (IdSelected.HasValue) // Si tenemos un ID, estamos en MODO EDICION
            {
                cocheActual = db.Coches.Find(IdSelected.Value);

                if (cocheActual == null)
                {
                    MessageBox.Show("NO existe ese coche en la base de datos.",
                                    "Registro no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Sobrescribimos sus propiedades. EF Core detecta estos cambios automáticamente.
                cocheActual.Modelo = modeloLimpio;
                cocheActual.Marca = marcaLimpia;
            }
            else // Si no tenemos un ID, estamos en MODO ALTA 
            {
                cocheActual = new Coche
                {
                    Modelo = modeloLimpio,
                    Marca = marcaLimpia
                };

                db.Coches.Add(cocheActual);   // Añadir registro nuevo (INSERT)
            }

            // Si Alta, hace un INSERT. Si Edición, hace un UPDATE solo de los campos modificados.
            db.SaveChanges();

            // Capturamos el ID para devolverlo al FormMain (sea el recién creado o el que acabamos de editar)
            IdSelected = cocheActual.Id;

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
