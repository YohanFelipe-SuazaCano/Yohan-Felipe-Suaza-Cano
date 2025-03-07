using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioElectronicos
{
    public partial class Form1 : Form
    {
        private List<ProductoElectronico> inventario;

        public Form1()
        {
            InitializeComponent();
            inventario = new List<ProductoElectronico>();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreProducto.Text;
            decimal precio = decimal.Parse(txtPrecioProducto.Text);
            int cantidad = int.Parse(txtCantidadStock.Text);

            ProductoElectronico producto = new ProductoElectronico(nombre, precio, cantidad);
            inventario.Add(producto);
            ActualizarLista();
        }

        private void ActualizarLista()
        {
            listBoxInventario.Items.Clear();
            foreach (var producto in inventario)
            {
                listBoxInventario.Items.Add($"{producto.Nombre} - ${producto.Precio} - Cantidad: {producto.CantidadEnStock}");
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscarProducto.Text.ToLower();
            var productosEncontrados = inventario.Where(p => p.Nombre.ToLower().Contains(nombre)).ToList();

            listBoxInventario.Items.Clear();
            foreach (var producto in productosEncontrados)
            {
                listBoxInventario.Items.Add($"{producto.Nombre} - ${producto.Precio} - Cantidad: {producto.CantidadEnStock}");
            }

            if (productosEncontrados.Count == 0)
            {
                MessageBox.Show("No se encontraron productos que coincidan con la búsqueda.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarLista();
            }
        }

        private void btnVenderProducto_Click_1(object sender, EventArgs e)
        {
            string nombre = txtBuscarProducto.Text;
            int cantidad = int.Parse(txtCantidadVenta.Text);

            var producto = inventario.FirstOrDefault(p => p.Nombre.ToLower() == nombre.ToLower());

            if (producto != null)
            {
                if (producto.CantidadEnStock >= cantidad)
                {
                    producto.CantidadEnStock -= cantidad;
                    ActualizarLista();
                    decimal totalVenta = cantidad * producto.Precio;
                    MessageBox.Show($"Se vendió {cantidad} unidades del producto '{producto.Nombre}' por un total de ${totalVenta}.", "Venta Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No hay suficiente stock para realizar esta venta.", "Error de Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("El producto no existe.", "Error de Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
 }
