using Microsoft.EntityFrameworkCore;
using rknRallySlotApp.Datos;
using System.Reflection;

namespace rknRallySlotApp.Vistas;

public partial class FormSplash : Form
{
    public FormSplash()
    {
        InitializeComponent();
    }

    private async void FormSplash_Shown(object? sender, EventArgs e)
    {
        try
        {
            string nombreApp = Assembly.GetExecutingAssembly().GetName().Name ?? "unknown";                 // Nombre de la aplicación
            string versionApp = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "unknown"; // Versión de la aplicación

            lblTitulo.Text = $"{nombreApp} - v{versionApp}";    // Mostramos en el splash

            if (lblEstado != null)      
            {
                lblEstado.Text = "Comprobando y actualizando base de datos...";
                lblEstado.Refresh();    // Forzar dibujado UI
            }
            this.Refresh();             // FORZAR repintado

            // Migración Asíncrona DB
            using (var db = new AppDbContext())     
            {
                await db.Database.MigrateAsync();   
            }

            if (lblEstado != null)      
            {
                lblEstado.Text = "Iniciando aplicación...";
                lblEstado.Refresh();    // Forzar dibujado UI
            }
            this.Refresh();             // FORZAR repintado

            await Task.Delay(600);      // espera estética

            // Instanciamos y mostramos el formulario principal
            var formMain = new FormMain();

            // Al cerrar FormMain cerramos el splash y la aplicación
            formMain.FormClosed += (s, args) => this.Close();

            formMain.Show();
            this.Hide();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Error crítico al migrar la base de datos:\n{ex.Message}",
                "Error de Inicio",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            Application.Exit();
        }
    }
}
