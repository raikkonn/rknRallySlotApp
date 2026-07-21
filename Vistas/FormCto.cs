using Microsoft.EntityFrameworkCore;
using rknRallySlotApp.Datos;
using rknRallySlotApp.Modelos;
using rknRallySlotApp.Utilidades;

namespace rknRallySlotApp.Vistas;

public partial class FormCto : Form
{
    // Propiedad pública de lectura para devolver el ID recién creado al FormMain
    public int IdCampeonatoCreado { get; private set; }

    public FormCto()
    {
        InitializeComponent();
    }

    private void FormCto_Load(object sender, EventArgs e)
    {
        // Asignacion de imagenes a los botones
        BotonesInit();

    }

    private void BotonesInit()
    {
        btnSave.Image = Properties.Resources.save_b.Zoom(btnSave.Width - 5, btnSave.Height - 5);
        btnSave.ImageAlign = ContentAlignment.MiddleCenter;
        btnSave.Enabled = false;

        btnCancel.Image = Properties.Resources.cancel_r.Zoom(btnCancel.Width - 15, btnCancel.Height - 15);
        btnCancel.ImageAlign = ContentAlignment.MiddleCenter;
        btnCancel.Enabled = true;

    }

    private void BtnSave_Click(object sender, EventArgs e)
    {
        // 1. Sanitización de texto: elimina espacios múltiples/extremos y aplica TitleCase (Ej: "  rally  de  navidad " -> "Rally De Navidad")
        string nombreLimpio = TxtTools.TrimCleanAndTitle(tboxCto.Text);

        // 2. Operación de persistencia con EF Core
        using var db = new AppDbContext();

        // Validar que no exista otro campeonato con el mismo nombre (Ignorando mayúsculas/minúsculas)
        bool existe = db.Campeonatos.Any(c => c.Nombre.ToLower() == nombreLimpio.ToLower());

        if (existe)
        {
            MessageBox.Show($"Ya existe un campeonato registrado con el nombre '{nombreLimpio}'.",
                            "Nombre Duplicado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
            tboxCto.Focus();
            tboxCto.SelectAll();
            return;
        }

        // Crear la entidad
        var nuevoCampeonato = new Campeonato
        {
            Nombre = nombreLimpio,
            SistemaPuntuacion = TxtTools.TrimAndClean(tboxPuntos.Text)
        };

        try
        {
            db.Campeonatos.Add(nuevoCampeonato);
            db.SaveChanges(); // EF Core asigna el Id generado por SQLite al objeto automáticamente

            // Capturamos el ID para que el FormMain sepa cuál seleccionar
            IdCampeonatoCreado = nuevoCampeonato.Id;

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

    private void BtnCancel_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }


    private void TboxCto_TextChanged(object sender, EventArgs e)
    {
        btnSave.Enabled = !string.IsNullOrWhiteSpace(tboxCto.Text);
    }

    private void TboxCto_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            // Evita el sonido 'beep' por defecto de Windows
            e.SuppressKeyPress = true;

            // Ejecuta el click del botón si está habilitado
            if (btnSave.Enabled)
            {
                btnSave.PerformClick();
            }
        }
    }
}

