using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoWPF
{
    /// <summary>
    /// Lógica de interacción para Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        // Método para el botón de "My Melody"
        private void MyMelodyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Has seleccionado el peluche My Melody.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Método para el botón de "Kuromi"
        private void KuromiButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Has seleccionado el peluche Kuromi.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Método para el botón de "Cinamoroll"
        private void CinamorollButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Has seleccionado el peluche Cinamoroll.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Método para el botón de "Hello Kitty"
        private void KittyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Has seleccionado el peluche Hello Kitty.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Método para el botón de "PomPomPurin"
        private void PomPomPurinButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Has seleccionado el peluche PomPomPurin.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
