using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioElectronicos
{
    public class ProductoElectronico
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int CantidadEnStock { get; set; }

        public ProductoElectronico(string nombre, decimal precio, int cantidadEnStock)
        {
            Nombre = nombre;
            Precio = precio;
            CantidadEnStock = cantidadEnStock;
        }
    }
}