using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace Wpf_Lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = "Data Source=LAB1504-11\\SQLEXPRESS;Initial Catalog=Neptuno;User ID=userTecsup;Password=123456";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("InsertarProductos", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idproducto", int.Parse(txtIdProducto.Text));
                    cmd.Parameters.AddWithValue("@nombreProducto", txtNombreProducto.Text);
                    cmd.Parameters.AddWithValue("@idProveedor", int.Parse(txtIdProveedor.Text));
                    cmd.Parameters.AddWithValue("@idCategoria", int.Parse(txtIdCategoria.Text));
                    cmd.Parameters.AddWithValue("@cantidadPorUnidad", txtCantidadUnidad.Text);
                    cmd.Parameters.AddWithValue("@precioUnidad", int.Parse(txtPrecioUnidad.Text));
                    cmd.Parameters.AddWithValue("@unidadesEnExistencia", int.Parse(txtUnidadExistencia.Text));
                    cmd.Parameters.AddWithValue("@unidadesEnPedido", int.Parse(txtUnidadPedido.Text));
                    cmd.Parameters.AddWithValue("@nivelNuevoPedido", int.Parse(txtNivelNuevoPedido.Text));
                    cmd.Parameters.AddWithValue("@suspendido", int.Parse(txtSuspendido.Text));
                    cmd.Parameters.AddWithValue("@categoriaProducto", txtCategoriaProducto.Text);



                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Producto ingresada correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar el producto: " + ex.Message);
            }
        }

        private void Button_Click_Listar(object sender, RoutedEventArgs e)
        {
            Window window = new Window1();
            window.Show();
        }
    }
}
