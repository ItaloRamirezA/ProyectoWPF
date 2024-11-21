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
using System.Windows.Navigation;
using System.Windows;

namespace ProyectoWPF
{
    public partial class InformacionProducto : Window
    {
        public InformacionProducto(Producto producto)
        {
            InitializeComponent();

            // Asignar los datos del producto a los controles
            NombreProducto.Text = producto.Nombre;
            TamanoProducto.Text = $"{producto.Tamano} cm";
            DescripcionProducto.Text = producto.Descripcion;
            PrecioProducto.Text = $"${producto.Precio:F2}";

            // Cargar la imagen usando la ruta relativa obtenida
            ImagenProducto.Source = new BitmapImage(new Uri(producto.ImagenPath, UriKind.Relative));
        }
    }
}

