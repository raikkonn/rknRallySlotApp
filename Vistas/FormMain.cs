using Microsoft.EntityFrameworkCore;
using rknRallySlotApp.Datos;
using rknRallySlotApp.Modelos;

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
            using (var context = new AppDbContext())
            {
                // El método mágico: revisa los planos de tu código y, si el archivo .db 
                // está vacío o no tiene las tablas, las crea todas al vuelo inmediatamente.
                context.Database.Migrate();
            }

            // Ejecutamos la prueba dentro de un bloque try/catch por si la BD falla
            try
            {
                // 1. Instanciamos el contexto de datos (equivalente a abrir la conexión)
                using var db = new AppDbContext();

                // 2. Controlamos si ya existe el campeonato de prueba para no duplicar (por el índice UNIQUE)
                if (!db.Campeonatos.Any(c => c.Nombre == "AVSLOT SUMMER 2026"))
                {
                    // 3. Instanciamos un objeto de prueba
                    var nuevoCampeonato = new Campeonato
                    {
                        Nombre = "AVSLOT SUMMER 2026"
                    };

                    // 4. Le decimos a EF Core que lo prepare para insertar
                    db.Campeonatos.Add(nuevoCampeonato);

                    // 5. Se ejecutan los comandos SQL reales contra SQLite
                    db.SaveChanges();

                    MessageBox.Show("¡Base de datos conectada! Se ha insertado el campeonato de prueba.",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // 6. Si ya existía, lo leemos para verificar la lectura
                    var campExistente = db.Campeonatos.First(c => c.Nombre == "AVSLOT SUMMER 2026");
                    MessageBox.Show($"Conexión OK. Leído de la BD: {campExistente.Nombre} (ID: {campExistente.Id})",
                                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Si te equivocaste en la Fluent API, el nombre de una propiedad o falta la migración, saltará aquí
                MessageBox.Show($"Error al conectar a la base de datos: {ex.Message}\n\nDetalle: {ex.InnerException?.Message}",
                                "Error de Persistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }    
    }
}
