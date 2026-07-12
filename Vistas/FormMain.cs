using Microsoft.EntityFrameworkCore;
using rknRallySlotApp.Datos;
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

            // Asignacion de imagenes a los botones
            btnNewCto.Image = Properties.Resources.new_b.Redimensionar(btnEditCto.Width - 5, btnEditCto.Height - 5);
            btnNewCto.ImageAlign = ContentAlignment.MiddleCenter;
            btnNewCto.Enabled = true;

            btnEditCto.Image = Properties.Resources.pencil_b.Redimensionar(btnEditCto.Width - 5, btnEditCto.Height - 5);
            btnEditCto.ImageAlign = ContentAlignment.MiddleCenter;
            btnEditCto.Enabled = false;

            btnDelCto.Image = Properties.Resources.del_r.Redimensionar(btnEditCto.Width - 5, btnEditCto.Height - 5);
            btnDelCto.ImageAlign = ContentAlignment.MiddleCenter;
            btnDelCto.Enabled = false;

            btnNewPrueba.Image = Properties.Resources.new_b.Redimensionar(btnEditCto.Width - 5, btnEditCto.Height - 5);
            btnNewPrueba.ImageAlign = ContentAlignment.MiddleCenter;
            btnNewPrueba.Enabled = false;

            btnEditPrueba.Image = Properties.Resources.pencil_b.Redimensionar(btnEditCto.Width - 5, btnEditCto.Height - 5);
            btnEditPrueba.ImageAlign = ContentAlignment.MiddleCenter;
            btnEditPrueba.Enabled = false;

            btnDelPrueba.Image = Properties.Resources.del_r.Redimensionar(btnEditCto.Width - 5, btnEditCto.Height - 5);
            btnDelPrueba.ImageAlign = ContentAlignment.MiddleCenter;
            btnDelPrueba.Enabled = false;


            using (var db = new AppDbContext())
            {
                // Migracion de la base de datos para asegurarnos de que la estructura está actualizad
                db.Database.Migrate();

                // Hacemos la consulta trayendo datos de ambas tablas gracias a la relación
                var listaGrid = db.Inscripciones
                    .Select(i => new
                    {
                        Dorsal = i.Dorsal,
                        Piloto = i.NombrePiloto,
                        Coche = i.Coche,
                        Cat = i.Categoria,
                        Verif = i.Verificado
                    })
                    .ToList();

                // Vinculamos el resultado al DataGridView
                dgvCtoPrueba.DataSource = listaGrid;

                // cargamos el comboBox de Campeonatos con un elemento especial al final
                var listaCtos = db.Campeonatos
                    .Select(c => new SelectorItem
                    {
                        Id = c.Id,
                        Nombre = c.Nombre
                    })
                    .ToList();

                // Añadimos el elemento especial al final de la lista
                listaCtos.Add(new SelectorItem { Id = -9, Nombre = "[ nuevo ]" });

                cboxCto.DataSource = listaCtos;
                cboxCto.DisplayMember = "Nombre"; // Lo que se muestra en pantalla
                cboxCto.ValueMember = "Id";       // El valor real detrás del texto

                // INDEX -1 para limpiar la INTERFAZ
                cboxCto.SelectedIndex = -1;
            }
        }

        private void CBoxCto_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Comprobamos si hay un elemento seleccionado y si es nuestro "comodín"
            if ((cboxCto.SelectedValue is int idSeleccionado) && (idSeleccionado == -9))
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
                        cboxCto.SelectedIndex = 0;
                    }
                }
            }
        }

        private void btnNewCto_Click(object sender, EventArgs e)
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
                    cboxCto.SelectedIndex = 0;
                }
            }
        }
    }
}
