using System;
using System.Data.SqlClient;
using System.Windows;

namespace ProyectoWPF
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            string usuario = UsuarioTextBox.Text.Trim();
            string contrasena = PasswordBox.Password.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Campos Vacíos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=ProyectoWPF;Integrated Security=True;"))
                {
                    connection.Open();
                    string query = "SELECT COUNT(1) FROM Login WHERE Usuario = @Usuario AND Contrasena = @Contrasena";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Usuario", usuario);
                        command.Parameters.AddWithValue("@Contrasena", contrasena);

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        if (count == 1)
                        {
                            MessageBox.Show("Inicio de sesión exitoso.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                            Home homeWindow = new Home();
                            homeWindow.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Inicio de Sesión", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
