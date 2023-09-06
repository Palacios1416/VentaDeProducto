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
    public partial class frmCredito : Form
    {
        static int[] letras = { 3, 6, 9, 12 };
        static string[] productos = { "Lavadora", "Refrigeradora", "Licuadora",
        "Extractora", "Radiograbadora", "DVD", "BluRay" };
        double tSubtotal;

        public frmCredito()
        {
            InitializeComponent();
        }

        private void frmCredito_Load(object sender, EventArgs e)
        {
            cboLetras.DataSource = letras;
            cboProducto.DataSource = productos;
            MostrarFecha();
            MostrarHora();
            lblNeto.Text = "0.00";
        }

        private void MostrarHora()
        {
            lblHora.Text = DateTime.Now.ToShortDateString();

        }

        private void MostrarFecha()
        {
            lblFecha.Text = DateTime.Now.ToShortDateString();   
        }

        private void btnAdquirir_Click(object sender, EventArgs e)
        {
            Credito objCr = new Credito();


            //Datos del cliente
            objCr.Cliente = txtCliente.Text;
            objCr.RUC = txtRuc.Text;
            objCr.Fecha = DateTime.Parse(lblFecha.Text);
            objCr.Hora = DateTime.Parse(lblHora.Text);

            //datos del producto

            objCr.Producto = cboProducto.Text;
            objCr.Cantidad = int.Parse(txtCantidad.Text);

            //Imprimiendo en la lista
            ListViewItem fila = new ListViewItem(objCr.GetX().ToString());
            fila.SubItems.Add(objCr.Producto);
            fila.SubItems.Add(objCr.Cantidad.ToString());
            fila.SubItems.Add(objCr.AsignaPrecio().ToString());
            fila.SubItems.Add(objCr.CalculaSubtotal().ToString());
            lvDetalle.Items.Add(fila);
            tSubtotal += objCr.CalculaSubtotal();
            lblNeto.Text = tSubtotal.ToString("0.00");
        }

        private void btnResumen_Click(object sender, EventArgs e)
        {
            int letras = int.Parse(cboLetras.Text);
            switch (letras)
            {
                case 3: MontoLetras(3); break;
                case 6: MontoLetras(6); break;
                case 9: MontoLetras(9); break;
                case 12: MontoLetras(12); break;

            }
        }

        private void MontoLetras(int le)
        {
            double montoMensual = double.Parse(lblNeto.Text)/le;
            lvResumen.Items.Clear();
            for (int i = 0; i <= le; i++)
            {
                ListViewItem fila = new ListViewItem(i.ToString());
                fila.SubItems.Add(montoMensual.ToString("C"));
                lvResumen.Items.Add(fila);
            }
        }
    }
}
