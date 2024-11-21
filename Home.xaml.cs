using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProyectoWPF
{
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void ProductoButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button != null && int.TryParse(button.Tag.ToString(), out int productoId))
            {
                Producto producto = ObtenerProductoPorId(productoId);

                if (producto != null)
                {
                    InformacionProducto ventanaInformacion = new InformacionProducto(producto);

                    ventanaInformacion.Show();
                }
                else
                {
                    MessageBox.Show("Producto no encontrado.");
                }
            }
            else
            {
                MessageBox.Show("Error al obtener el ID del producto.");
            }
        }

        private Producto ObtenerProductoPorId(int id)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=ProyectoWPF;Integrated Security=True";

            string query = "SELECT Id, Nombre, Tamano, Descripcion, Precio, ImagenPath FROM Productos WHERE Id = @Id";

            Producto producto = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        producto = new Producto
                        {
                            Id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0,
                            Nombre = reader["Nombre"] != DBNull.Value ? Convert.ToString(reader["Nombre"]) : string.Empty,
                            Tamano = reader["Tamano"] != DBNull.Value ? Convert.ToInt32(reader["Tamano"]) : 0,
                            Descripcion = reader["Descripcion"] != DBNull.Value ? Convert.ToString(reader["Descripcion"]) : string.Empty,
                            Precio = reader["Precio"] != DBNull.Value ? Convert.ToSingle(reader["Precio"]) : 0f,
                            ImagenPath = reader["ImagenPath"] != DBNull.Value ? Convert.ToString(reader["ImagenPath"]) : string.Empty
                        };
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar la base de datos: " + ex.Message);
                }
            }

            return producto;
        }
    }
}
