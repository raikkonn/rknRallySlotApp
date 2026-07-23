using Microsoft.EntityFrameworkCore;
using rknRallySlotApp.Datos;

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
            // 1. Actualizamos texto y FORZAMOS el repintado inmediato en pantalla
            if (lblEstado != null)
            {
                lblEstado.Text = "Comprobando y actualizando base de datos...";
                lblEstado.Refresh(); // <-- Forzado de dibujado UI
            }
            this.Refresh(); // Garatiza que la imagen y controles del Splash estén pintados al 100%

            // 2. Ejecutamos la migración directamente de forma asíncrona
            using (var db = new AppDbContext())
            {
                await db.Database.MigrateAsync();
            }

            // 3. Actualizamos estado final
            if (lblEstado != null)
            {
                lblEstado.Text = "Iniciando aplicación...";
                lblEstado.Refresh();
            }
            this.Refresh(); // Garatiza que la imagen y controles del Splash estén pintados al 100%

            await Task.Delay(600);

            // 4. Instanciamos y mostramos el formulario principal
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