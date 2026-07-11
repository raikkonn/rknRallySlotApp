using Microsoft.EntityFrameworkCore;
using rknRallySlotApp.Datos;
using rknRallySlotApp.Modelos;
using rknRallySlotApp.Utilidades;

namespace rknRallySlotApp.Vistas
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

            using (var db = new AppDbContext())
            {
                // El método mágico: revisa los planos de tu código y, si el archivo .db 
                // está vacío o no tiene las tablas, las crea todas al vuelo inmediatamente.
                db.Database.Migrate();

                // Hacemos la consulta trayendo datos de ambas tablas gracias a la relación
                var listadoGrid = db.Pruebas
                    .Select(p => new
                    {
                        Campeonato = p.Campeonato!.Nombre, // <-- Aquí EF Core hace el JOIN automáticamente
                        IdPrueba = p.Id,
                        NombrePrueba = p.Nombre,
                        Etapas = p.NumEtapas,
                        Tramos = p.TramosPorEtapa,
                        Tmax = p.TiempoMaximo
                    })
                    .ToList();

                // Vinculamos el resultado al DataGridView
                dgvCtoPrueba.DataSource = listadoGrid;

                var listaCtos = db.Campeonatos
                    .Select(c => new SelectorItem
                    {
                        Id = c.Id,
                        Nombre = c.Nombre
                    })
                    .ToList();

                // Añadimos el elemento especial al final de la lista
                listaCtos.Add(new SelectorItem { Id = -1, Nombre = "[ nuevo ]" });

                cBoxCto.DataSource = listaCtos;
                cBoxCto.DisplayMember = "Nombre"; // Lo que se muestra en pantalla
                cBoxCto.ValueMember = "Id";       // El valor real detrás del texto

                // INDEX -1 para limpiar la INTERFAZ
                cBoxCto.SelectedIndex = -1;
            }
        }

        private void CBoxCto_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Comprobamos si hay un elemento seleccionado y si es nuestro "comodín"
            if ((cBoxCto.SelectedValue is int idSeleccionado) && (idSeleccionado == -1))
            {
                // Abrimos el formulario de alta como Modal (ShowDialog)
                using (var frmAlta = new FormCto())
                {
                    if (frmAlta.ShowDialog() == DialogResult.OK)
                    {
                        // Si el usuario guardó con éxito, refrescamos este combo
                        // RecargarComboCampeonatos();
                    }
                    else
                    {
                        // Si canceló, volvemos a seleccionar el primer elemento para no dejar el "- Añadir nuevo -" marcado
                        cBoxCto.SelectedIndex = 0;
                    }
                }
            }
        }
    }
}
