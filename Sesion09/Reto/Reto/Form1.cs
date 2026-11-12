namespace Reto
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        public string Titular;
        public string Numero;
        public decimal Saldo;

        public Form1(string titular, string numero, decimal saldoInicial = 0)
        {

            InitializeComponent();

            if (string.IsNullOrWhiteSpace(titular))
                throw new ArgumentException("El titular no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("El número de cuenta no puede estar vacío.");
            if (saldoInicial < 0)
                throw new ArgumentException("El saldo inicial no puede ser negativo.");

            Titular = titular.Trim();
            Numero = numero.Trim();
            Saldo = saldoInicial;
        }

        public bool Depositar(decimal monto)
        {
            if (monto <= 0 || monto % 10000 != 0) return false;

            Saldo += monto;
            return true;
        }

        public bool Retirar(decimal monto)
        {
            if (monto <= 0 || monto > Saldo || monto % 10000 != 0) return false;

            Saldo -= monto;
            return true;
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtMonto.Text, out decimal monto)) return;

            if (Depositar(monto))
            {
                txtSaldo.Text = Saldo.ToString();

                lstMovimientos.Items.Insert(0 , $"{DateTime.Now:HH:mm} - Depósito - ${monto}");
            } else
            {
                MessageBox.Show("Error: el monto debia cumplir con ser multiplo de 10.000", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtMonto.Text, out decimal monto)) return;

            if (Retirar(monto))
            {
                txtSaldo.Text = Saldo.ToString();
                lstMovimientos.Items.Insert(0, $"{DateTime.Now:HH:mm} - Retiro - ${monto}");
            }
            else
            {
                MessageBox.Show("Error: Saldo insuficiente o no es multiplo de 10.000", "Operación Fallida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
