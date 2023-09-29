using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Lab5
{
    public class Producto
    {
        public int ID { get; set; }

        public string Nombre { get; set; }

        public int Proveedor { get; set; }
        public int Categoria { get; set; }
        public string Cantidad { get; set; }
        public int Precio { get; set; }
        public int Existencia { get; set; }
        public int Pedido { get; set; }
        public int Nivel { get; set; }

        public int Suspendido { get; set; }
        public string CategoriaProducto { get; set; }

        public int Activo { get; set; }
    }
}
