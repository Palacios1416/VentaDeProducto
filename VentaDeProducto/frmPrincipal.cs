namespace VentaDeProducto
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnContado_Click(object sender, EventArgs e)
        {
            frmContado frmContado = new frmContado();
            frmContado.ShowDialog();

        }

        private void btnCredito_Click(object sender, EventArgs e)
        {
            frmCredito frmCredito = new frmCredito();
            frmCredito.ShowDialog();
        }
    }
}