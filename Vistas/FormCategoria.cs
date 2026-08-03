using Microsoft.EntityFrameworkCore;
using rknRallySlotApp.Componentes;
using rknRallySlotApp.Datos;
using rknRallySlotApp.Modelos;
using rknRallySlotApp.Utilidades;

namespace rknRallySlotApp.Vistas;

public partial class FormCategoria : Form
{
    private readonly ToolTip _toolTip = new();
    public int? IdSelected = null;              // ID categoria seleccionada (null si es un nuevo registro)
    public Color ColorSelected = Color.Empty;   // Variable para almacenar el color elegido

    public FormCategoria(String? titulo = null, object? id = null)
    {
        InitializeComponent();
        BotonesInit();  // Asignacion de imagenes a los botones
        ConfigurarToolTips();

        lblForm.Text = titulo ?? String.Empty;

        if ((id is int idSel) && (idSel > 0))
        {
            IdSelected = idSel;
            RellenaCategoria(idSel);
        }
        else
        {
            IdSelected = null;
            tboxCategoria.Text = String.Empty;
        }

        ColorSelected = tboxCategoria.BackColor;
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
        _toolTip.SetToolTip(botonColorCategoria, "Elegir Color Resaltado");
    }

    private void ControlesEnableDisable()
    {
        botonSave.Enabled = !string.IsNullOrWhiteSpace(tboxCategoria.Text);
    }

    private void RellenaCategoria(int id)
    {
        using var db = new AppDbContext();

        var categoria = db.Categorias
                        .Where(c => c.Id == id)
                        .Select(p => new { p.Nombre, p.ColorHex })
                        .FirstOrDefault();

        if (categoria != null)
        {
            // Obtener el color almacenado en la base de datos y aplicarlo al TextBox
            Color colorElegido = ColorTranslator.FromHtml(categoria.ColorHex);

            tboxCategoria.BackColor = colorElegido;
            tboxCategoria.ForeColor = ColorTools.GetBestContrast(colorElegido); // Ajusta el color del texto para que sea legible

            tboxCategoria.Text = string.IsNullOrEmpty(categoria.Nombre) ? string.Empty : categoria.Nombre;
        }
        else // Si no se encuentra el registro o se le pasa un ID inválido
        {
            tboxCategoria.Text = string.Empty;
        }
    }

    private void TboxCategoria_TextChanged(object sender, EventArgs e)
    {
        ControlesEnableDisable();
    }

    private void TboxCategoria_Leave(object sender, EventArgs e)
    {
        // Saneado texto
        string categoriaLimpia = TxtTools.TrimAndClean(tboxCategoria.Text).ToUpper();
        tboxCategoria.Text = categoriaLimpia;
    }

    private void BotonCancel_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void BotonSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(tboxCategoria.Text))
        {
            tboxCategoria.Focus();
            tboxCategoria.SelectAll();
            return;
        }

        // Saneado texto
        string categoriaLimpia = TxtTools.TrimAndClean(tboxCategoria.Text).ToUpper();
        tboxCategoria.Text = categoriaLimpia;

        using var db = new AppDbContext();

        // Comprueba si DUPLICA: si EXISTE CATEGORIA en DB excluyendo la categoria en edición    
        bool existeCategoria = db.Categorias.Any(c =>
            (c.Nombre.ToLower() == categoriaLimpia.ToLower())
            && (!IdSelected.HasValue || c.Id != IdSelected.Value));

        if (existeCategoria)
        {
            MessageBox.Show($"Categoría '{categoriaLimpia}' ya registrada.",
                            "Categoría Duplicada",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
            tboxCategoria.Focus();
            tboxCategoria.SelectAll();
            return;
        }

        try
        {
            Categoria? categoriaActual;

            if (IdSelected.HasValue) // Si tenemos un ID, estamos en MODO EDICION
            {
                categoriaActual = db.Categorias.Find(IdSelected.Value);

                if (categoriaActual == null)
                {
                    MessageBox.Show("NO existe esa categoría en la base de datos.",
                                    "Registro no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Sobrescribimos sus propiedades. EF Core detecta estos cambios automáticamente.
                categoriaActual.Nombre = categoriaLimpia;
                categoriaActual.ColorHex = ColorTranslator.ToHtml(ColorSelected);
            }
            else // Si NO tenemos un ID, estamos en MODO ALTA 
            {
                categoriaActual = new Categoria
                {
                    Nombre = categoriaLimpia,
                    ColorHex = ColorTranslator.ToHtml(ColorSelected)
                };

                db.Categorias.Add(categoriaActual);   // Añadir registro nuevo (INSERT)
            }

            // Si Alta, hace un INSERT. Si Edición, hace un UPDATE solo de los campos modificados.
            db.SaveChanges();

            // Capturamos el ID para devolverlo al FormMain (sea el recién creado o el que acabamos de editar)
            IdSelected = categoriaActual.Id;

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

    private void BotonColorCategoria_Click(object sender, EventArgs e)
    {
        using ColorDialog dlg = new();
        dlg.Color = tboxCategoria.BackColor;        // Configurar un color inicial preseleccionado

        if (dlg.ShowDialog() == DialogResult.OK)    // Mostrar diálogo y verificar si clic en "Aceptar"
        {
            ColorSelected = dlg.Color;              // El color elegido pasa a la variable global pública

            // Aplicación en la UI
            tboxCategoria.BackColor = ColorSelected;
            tboxCategoria.ForeColor = ColorTools.GetBestContrast(ColorSelected);    // Mejora legiblilidad
        }
    }
}
