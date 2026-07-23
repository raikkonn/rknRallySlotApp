using Microsoft.EntityFrameworkCore;
using rknRallySlotApp.Datos;
using rknRallySlotApp.Modelos;
using rknRallySlotApp.Utilidades;

namespace rknRallySlotApp.Vistas;

public partial class FormCto : Form
{
    private readonly ToolTip _toolTip = new();
    public int? IdSelected = null;  // ID del campeonato seleccionado (null si es un nuevo registro)

    public FormCto(String? titulo = null, object? idCto = null)
    {
        InitializeComponent();
        ConfigurarToolTips();

        lblFrmCto.Text = titulo ?? String.Empty;
        
        if ((idCto is int idSel) && (idSel > 0))  
        {
            ConsultaCto(idSel);
            IdSelected = idSel;
        }
        else
        {
            tboxCto.Text = String.Empty;
            tboxPuntos.Text = String.Empty;
        }
    }

    private void ConsultaCto(int idSelected)
    {
        using var db = new AppDbContext();

        // Consultamos y proyectamos únicamente las dos columnas necesarias
        var cto = db.Campeonatos
                    .Where(c => c.Id == idSelected)
                    .Select(c => new
                    {
                        c.Nombre,
                        c.SistemaPuntuacion
                    })
                    .FirstOrDefault();

        if (cto != null)
        {
            tboxCto.Text = cto.Nombre ?? string.Empty;
            tboxPuntos.Text = cto.SistemaPuntuacion ?? string.Empty;
        }
        else // Si no se encuentra el registro o se pasa un ID no válido
        {
            tboxCto.Text = string.Empty;
            tboxPuntos.Text = string.Empty;
        }
    }

    private void ConfigurarToolTips()
    {
        _toolTip.SetToolTip(btnSave, "Grabar");
        _toolTip.SetToolTip(btnCancel, "Cancelar");
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
        // Saneado texto
        string nombreLimpio = TxtTools.TrimCleanAndTitle(tboxCto.Text);

        using var db = new AppDbContext();

        // Comprueba si existe ese nombre PERO excluyendo el campeonato que estamos editando actualmente
        bool existe = db.Campeonatos.Any(c =>
            c.Nombre.ToLower() == nombreLimpio.ToLower()
            && (!IdSelected.HasValue || c.Id != IdSelected.Value));

        if (existe)
        {
            MessageBox.Show($"Ya existe un campeonato registrado como '{nombreLimpio}'.",
                            "Nombre Duplicado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
            tboxCto.Focus();
            tboxCto.SelectAll();
            return;
        }

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
                campeonatoActual.SistemaPuntuacion = TxtTools.TrimAndClean(tboxPuntos.Text);
            }
            else // Si no tenemos un ID, estamos en MODO ALTA 
            {
                campeonatoActual = new Campeonato
                {
                    Nombre = nombreLimpio,
                    SistemaPuntuacion = TxtTools.TrimAndClean(tboxPuntos.Text)
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

    private void BtnCancel_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }


    private void TboxCto_TextChanged(object sender, EventArgs e)
    {
        btnSave.Enabled = !string.IsNullOrWhiteSpace(tboxCto.Text);
    }

    private void All_tbox_KeyDown(object sender, KeyEventArgs e)
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

        if (e.KeyCode == Keys.Escape)
        {
            // Evita el sonido 'beep' por defecto de Windows
            e.SuppressKeyPress = true;

            // Ejecuta el click del botón si está habilitado
            if (btnCancel.Enabled)
            {
                btnCancel.PerformClick();
            }
        }
    }
}

