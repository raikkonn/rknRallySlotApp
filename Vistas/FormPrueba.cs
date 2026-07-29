using Microsoft.EntityFrameworkCore;
using rknRallySlotApp.Datos;
using rknRallySlotApp.Modelos;
using rknRallySlotApp.Utilidades;

namespace rknRallySlotApp.Vistas;

public partial class FormPrueba : Form
{
    private readonly ToolTip _toolTip = new();
    public int? IdSelected = null;  // ID de la Prueba/Rally seleccionado (null si es un nuevo registro)

    public FormPrueba(String? titulo = null, object? id = null)
    {
        InitializeComponent();
        BotonesInit();              // Asignacion de imagenes a los botones
        ConfigurarToolTips();

        lblForm.Text = titulo ?? String.Empty;

        if ((id is int idSel) && (idSel > 0))
        {
            IdSelected = idSel;
            RellenaPrueba(idSel);
        }
        else
        {
            TboxTextinit();
        }

        All_tbox_TextChanged(this, EventArgs.Empty);
    }

    private void TboxTextinit() 
    {
        tbox_Prueba.Text = $"Rally [{DateTime.Now:yyyy-MMM-d}]";
        tbox_nEtapas.Text = "3";
        tbox_nTramos.Text = "5";
        tbox_tMaxSeg.Text = "300";
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

    private void RellenaPrueba(int id)
    {
        using var db = new AppDbContext();

        // Consultamos y proyectamos únicamente las columnas necesarias
        var prueba = db.Pruebas
                    .Where(p => p.Id == id)
                    .Select(p => new
                    {
                        p.Nombre,
                        p.NumEtapas,
                        p.TramosPorEtapa,
                        p.TiempoMaximo
                    })
                    .FirstOrDefault();

        if (prueba != null)
        {
            tbox_Prueba.Text = prueba.Nombre ?? string.Empty;
            tbox_nEtapas.Text = prueba.NumEtapas.ToString();
            tbox_nTramos.Text = prueba.TramosPorEtapa.ToString();
            tbox_tMaxSeg.Text = prueba.TiempoMaximo.ToString();
        }
        else // Si no se encuentra el registro o se pasa un ID no válido
        {
            TboxTextinit();
        }
    }

    private void All_tbox_TextChanged(object sender, EventArgs e)
    {
        botonSave.Enabled = !string.IsNullOrWhiteSpace(tbox_Prueba.Text) 
                            && !string.IsNullOrWhiteSpace(tbox_nEtapas.Text)
                            && !string.IsNullOrWhiteSpace(tbox_nTramos.Text)
                            && !string.IsNullOrWhiteSpace(tbox_tMaxSeg.Text);   
    }

    private void BotonCancel_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void BotonSave_Click(object sender, EventArgs e)
    {
        int idCampeonatoActual = (this.Owner as FormMain)?.IdCampeonatoSeleccionado ?? 0;

        if (idCampeonatoActual <= 0)
        {
            MessageBox.Show("No se ha seleccionado un campeonato válido.", 
                            "Error", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
            return;
        }

        // Saneado texto
        string nombreLimpio = TxtTools.TrimCleanAndTitle(tbox_Prueba.Text);

        //validaciones campos numéricos
        if (!Helpers.EsEnteroValido(tbox_nEtapas.Text, out int nEtapas) || nEtapas <= 0)
        {
            (this.Owner as FormMain)?.MostrarMensajeEstado("El número de etapas debe ser entero positivo.");
            return;
        }

        if (!Helpers.EsEnteroValido(tbox_nTramos.Text, out int nTramos) || nTramos <= 0)
        {
            (this.Owner as FormMain)?.MostrarMensajeEstado("El número de tramos debe ser entero positivo.");
            return;
        }

        if (!Helpers.EsEnteroValido(tbox_tMaxSeg.Text, out int tMaxSeg) || tMaxSeg <= 0)
        {
            (this.Owner as FormMain)?.MostrarMensajeEstado("El tiempo máximo debe ser un entero positivo.");
            return;
        }

        using var db = new AppDbContext();

        // Comprueba si existe excluyendo registro actual (si estamos en modo edición)
        bool existe = db.Pruebas.Any(p =>
            p.IdCampeonato == idCampeonatoActual
            && p.Nombre.ToLower() == nombreLimpio.ToLower()
            && (!IdSelected.HasValue || p.Id != IdSelected.Value));

        if (existe)
        {
            MessageBox.Show($"Ya existe un rally registrado como '{nombreLimpio}' para el Campeonato seleccionado.",
                            "Nombre Duplicado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
            tbox_Prueba.Focus();
            tbox_Prueba.SelectAll();
            return;
        }
                
        try
        {
            Prueba? pruebaActual;

            if (IdSelected.HasValue) // Si tenemos un ID, estamos en MODO EDICION
            {
                pruebaActual = db.Pruebas.Find(IdSelected.Value);

                if (pruebaActual == null)
                {
                    MessageBox.Show("NO existe esa prueba en la base de datos.",
                                    "Registro no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Sobrescribimos sus propiedades. EF Core detecta estos cambios automáticamente.
                // pruebaActual.IdCampeonato = idCampeonatoActual; Es EDICION, no se DEBE cambiar el campeonato de una prueba ya creada

                pruebaActual.Nombre = nombreLimpio;
                pruebaActual.NumEtapas = nEtapas;
                pruebaActual.TramosPorEtapa = nTramos;
                pruebaActual.TiempoMaximo = tMaxSeg;
            }
            else // Si no tenemos un ID, estamos en MODO ALTA 
            {
                pruebaActual = new Prueba
                {
                    IdCampeonato = idCampeonatoActual,
                    Nombre = nombreLimpio,
                    NumEtapas = nEtapas,
                    TramosPorEtapa = nTramos,
                    TiempoMaximo = tMaxSeg
                };

                db.Pruebas.Add(pruebaActual);   // Añadir registro nuevo (INSERT)
            }

            // Si Alta, hace un INSERT. Si Edición, hace un UPDATE solo de los campos modificados.
            db.SaveChanges();

            // Capturamos el ID para devolverlo al FormMain (sea el recién creado o el que acabamos de editar)
            IdSelected = pruebaActual.Id;

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
