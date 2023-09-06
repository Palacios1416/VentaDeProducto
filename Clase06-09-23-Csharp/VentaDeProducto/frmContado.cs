using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;

namespace VentaDeProducto
{
    public partial class frmContado : Form
    {
        private double tSubtotal;

        static string[] productos = { "Lavadora", "Refrigeradora", "Licuadora",
        "Extractora", "Radiograbadora", "DVD", "BluRay" };

        public frmContado()
        {
            InitializeComponent();
        }

        private void frmContado_Load(object sender, EventArgs e)
        {
            cboProducto.DataSource = productos;
            MostrarFecha();
            MostrarHora();
            lblNeto.Text = "0.00";
        }

        private void MostrarHora()
        {
            lblHora.Text = DateTime.Now.ToShortTimeString();
        }

        private void MostrarFecha()
        {
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }

        private void btnAdquirir_Click(object sender, EventArgs e)
        {
            //objeto de la clase contado
            Contado objC = new();

            //Datos del cliente
            objC.Cliente = txtCliente.Text;
            objC.RUC = txtRuc.Text;
            objC.Fecha = DateTime.Parse(lblFecha.Text);
            objC.Hora = DateTime.Parse(lblHora.Text);

            //datos del producto

            objC.Producto = cboProducto.Text;
            objC.Cantidad = int.Parse(txtCantidad.Text);

            //Imprimiendo en la lista
            ListViewItem fila = new ListViewItem(objC.GetN().ToString());
            fila.SubItems.Add(objC.Producto);
            fila.SubItems.Add(objC.Cantidad.ToString());
            fila.SubItems.Add(objC.AsignaPrecio().ToString());
            fila.SubItems.Add(objC.CalculaSubtotal().ToString());
            lvDetalle.Items.Add(fila);
            Listado(objC);

        }

        private void Listado(Contado objC)
        {
            tSubtotal += objC.CalculaSubtotal();
            lstResumen.Items.Clear();
            lstResumen.Items.Add("** RESUMEN DE VENTA **");
            lstResumen.Items.Add("-------------------------");
            lstResumen.Items.Add($" CLIENTE: {objC.Cliente}");
            lstResumen.Items.Add($" RUC: {objC.RUC}");
            lstResumen.Items.Add($" Fecha: {objC.Fecha}");
            lstResumen.Items.Add($" Hora: {objC.Hora}");
            lstResumen.Items.Add("-------------------------");
            lstResumen.Items.Add($"SUBTOTAL: {tSubtotal.ToString("C")}");
            double descuento = objC.CalculaDescuento(tSubtotal);
            double neto = objC.CalculaNeto(tSubtotal,descuento);
            lstResumen.Items.Add($"DESCUENTO: {descuento.ToString()}");
            lstResumen.Text = neto.ToString("c");
        }
    }
}
