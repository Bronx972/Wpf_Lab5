using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace Wpf_Lab5
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            McDataGrid.ItemsSource = ListarProductos("", "");
        }

        private static List<Producto> ListarProductos(string nombrecontacto, string ciudad)
        {
            string connectionString = "Data Source=LAB1504-11\\SQLEXPRESS;Initial Catalog=Neptuno;User ID=userTecsup;Password=123456";

            List<Producto> productos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                connection.Open();
                string query = "ListarProductos";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

     
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Verificar si hay filas
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Leer los datos de cada fila
                                productos.Add(new Producto
                                {
                                    ID = reader.GetInt32(reader.GetOrdinal("idproducto")),
                                    Nombre = reader["nombreProducto"].ToString(),
                                    Proveedor = reader.GetInt32(reader.GetOrdinal("idProveedor")),
                                    Categoria = reader.GetInt32(reader.GetOrdinal("idCategoria")),
                                    Cantidad = reader["cantidadPorUnidad"].ToString(),
                                    Precio = reader.GetInt32(reader.GetOrdinal("precioUnidad")),
                                    Existencia = reader.GetInt16(reader.GetOrdinal("unidadesEnExistencia")),
                                    Pedido = reader.GetInt16(reader.GetOrdinal("unidadesEnPedido")),
                                    Nivel = reader.GetInt16(reader.GetOrdinal("nivelNuevoPedido")),
                                    Suspendido = reader.GetInt16(reader.GetOrdinal("suspendido")),
                                    CategoriaProducto = reader["categoriaProducto"].ToString(),
                                    Activo = reader.GetInt32(reader.GetOrdinal("activo")),
                                });

                            }
                        }
                    }
                }

                // Cerrar la conexión
                connection.Close();
            }
            return productos;

        }
    }
}
