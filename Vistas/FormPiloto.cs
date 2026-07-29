using Microsoft.EntityFrameworkCore;
using rknRallySlotApp.Datos;
using rknRallySlotApp.Modelos;
using rknRallySlotApp.Utilidades;

namespace rknRallySlotApp.Vistas;

public partial class FormPiloto : Form
{
    private readonly ToolTip _toolTip = new();
    public int? IdSelected = null;  // ID del piloto seleccionado (null si es un nuevo registro)

    public FormPiloto(String? titulo = null, object? id = null)
    {
        InitializeComponent();
        BotonesInit();  // Asignacion de imagenes a los botones
        ConfigurarToolTips();

        lblForm.Text = titulo ?? String.Empty;

        if ((id is int idSel) && (idSel > 0))
        {
            IdSelected = idSel;
            RellenaPiloto(idSel);
        }
        else
        {
            IdSelected = null;
            tboxPiloto.Text = String.Empty;
            tboxAlias.Text = String.Empty;
            tboxEscuderia.Text = String.Empty;
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
        botonSave.Enabled = !string.IsNullOrWhiteSpace(tboxPiloto.Text)
                            && !string.IsNullOrWhiteSpace(tboxAlias.Text);
    }

    private void RellenaPiloto(int id)
    {
        using var db = new AppDbContext();

        // Consultamos y proyectamos únicamente las columnas necesarias
        var piloto = db.Pilotos
                        .Where(p => p.Id == id)
                        .Select(p => new
                        {
                            p.Nombre,
                            p.Alias,
                            p.Escuderia
                        })
                        .FirstOrDefault();

        if (piloto != null)
        {
            tboxPiloto.Text = piloto.Nombre ?? string.Empty;
            tboxAlias.Text = piloto.Alias ?? string.Empty;
            tboxEscuderia.Text = piloto.Escuderia ?? string.Empty;
        }
        else // Si no se encuentra el registro o se pasa un ID no válido
        {
            tboxPiloto.Text = string.Empty;
            tboxAlias.Text = string.Empty;
            tboxEscuderia.Text = string.Empty;
        }
    }

    private void TboxPiloto_Leave(object sender, EventArgs e)
    {
        // Saneado texto
        string nombreLimpio = TxtTools.TrimCleanAndTitle(tboxPiloto.Text);
        tboxPiloto.Text = nombreLimpio;

        using var db = new AppDbContext();

        // Comprueba si DUPLICA: si EXISTE en DB excluyendo el piloto en edición 
        bool existe = db.Pilotos.Any(p =>
            (p.Nombre.ToLower() == nombreLimpio.ToLower())
            && (!IdSelected.HasValue || p.Id != IdSelected.Value));

        if (existe)
        {
            MessageBox.Show($"Piloto '{nombreLimpio}' ya registrado.",
                            "Piloto Duplicado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
            tboxPiloto.Focus();
            tboxPiloto.SelectAll();
            return;
        }

        // Generamos un alias automáticamente solo si estamos en modo ALTA (no edición)
        if (!IdSelected.HasValue)
        {
            var servicioAlias = new GeneradorAlias(db);
            tboxAlias.Text = servicioAlias.GenerarAliasUnico(tboxPiloto.Text);
        }
    }

    private void TboxAlias_Leave(object sender, EventArgs e)
    {
        // Saneado texto
        string aliasLimpio = TxtTools.TrimAndClean(tboxAlias.Text).ToUpper();
        tboxAlias.Text = aliasLimpio;

        using var db = new AppDbContext();

        // Comprueba si DUPLICA: si EXISTE en DB excluyendo el piloto en edición 
        bool existe = db.Pilotos.Any(p =>
            (p.Alias.ToLower() == aliasLimpio.ToLower())
            && (!IdSelected.HasValue || p.Id != IdSelected.Value));

        if (existe)
        {
            MessageBox.Show($"Alias '{aliasLimpio}' ya registrado.",
                            "Alias Duplicado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
            tboxAlias.Focus();
            tboxAlias.SelectAll();
            return;
        }
    }

    private void TboxPiloto_TextChanged(object sender, EventArgs e)
    {
        ControlesEnableDisable();
    }

    private void TboxAlias_TextChanged(object sender, EventArgs e)
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
        // Saneado texto
        string pilotoLimpio = TxtTools.TrimCleanAndTitle(tboxPiloto.Text);
        tboxPiloto.Text = pilotoLimpio;   
        string aliasLimpio = TxtTools.TrimAndClean(tboxAlias.Text).ToUpper();
        tboxAlias.Text = aliasLimpio;

        using var db = new AppDbContext();

        // Comprueba si DUPLICA: si EXISTE PILOTO en DB excluyendo el piloto en edición    
        bool existePiloto = db.Pilotos.Any(p =>
            (p.Nombre.ToLower() == pilotoLimpio.ToLower())
            && (!IdSelected.HasValue || p.Id != IdSelected.Value));

        if (existePiloto)
        {
            MessageBox.Show($"Piloto '{pilotoLimpio}' ya registrado.",
                            "Piloto Duplicado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
            tboxPiloto.Focus();
            tboxPiloto.SelectAll();
            return;
        }

        // Comprueba si DUPLICA: si EXISTE ALIAS en DB excluyendo el piloto en edición    
        bool existeAlias = db.Pilotos.Any(p =>
            (p.Alias.ToLower() == aliasLimpio.ToLower())
            && (!IdSelected.HasValue || p.Id != IdSelected.Value));

        if (existeAlias)
        {
            MessageBox.Show($"Alias '{aliasLimpio}' ya registrado.",
                            "Alias Duplicado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
            tboxAlias.Focus();
            tboxAlias.SelectAll();
            return;
        }

        try
        {
            Piloto? pilotoActual;

            if (IdSelected.HasValue) // Si tenemos un ID, estamos en MODO EDICION
            {
                pilotoActual = db.Pilotos.Find(IdSelected.Value);

                if (pilotoActual == null)
                {
                    MessageBox.Show("NO existe ese piloto en la base de datos.",
                                    "Registro no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Sobrescribimos sus propiedades. EF Core detecta estos cambios automáticamente.
                pilotoActual.Nombre = pilotoLimpio;
                pilotoActual.Alias = aliasLimpio;
                pilotoActual.Escuderia = TxtTools.TrimCleanAndTitle(tboxEscuderia.Text);
            }
            else // Si no tenemos un ID, estamos en MODO ALTA 
            {
                pilotoActual = new Piloto
                {
                    Nombre = pilotoLimpio,
                    Alias = aliasLimpio,
                    Escuderia = TxtTools.TrimCleanAndTitle (tboxEscuderia.Text)
                };

                db.Pilotos.Add(pilotoActual);   // Añadir registro nuevo (INSERT)
            }

            // Si Alta, hace un INSERT. Si Edición, hace un UPDATE solo de los campos modificados.
            db.SaveChanges();

            // Capturamos el ID para devolverlo al FormMain (sea el recién creado o el que acabamos de editar)
            IdSelected = pilotoActual.Id;

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
