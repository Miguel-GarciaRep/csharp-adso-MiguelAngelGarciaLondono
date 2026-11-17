using System.Globalization;

namespace Tarea;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        cmbOrigen.Items.AddRange(ConversorTemperatura.Unidades);
        cmbDestino.Items.AddRange(ConversorTemperatura.Unidades);
    }

    private void btnConvertir_Click(object sender, EventArgs e)
    {
        errorProvider1.Clear();
        lblResultado.Text = "";
        bool valido = true;

        if (!TryLeerNumero(txtValor.Text, out double valor))
        {
            errorProvider1.SetError(txtValor, "Escribe un número válido.");
            valido = false;
        }
        if (cmbOrigen.SelectedItem is null)
        {
            errorProvider1.SetError(cmbOrigen, "Elige la unidad de origen.");
            valido = false;
        }
        if (cmbDestino.SelectedItem is null)
        {
            errorProvider1.SetError(cmbDestino, "Elige la unidad de destino.");
            valido = false;
        }
        if (!valido) return;

        string origen = cmbOrigen.SelectedItem!.ToString()!;
        string destino = cmbDestino.SelectedItem!.ToString()!;

        if (!ConversorTemperatura.EsTemperaturaValida(valor, origen))
        {
            errorProvider1.SetError(txtValor, "Esa temperatura está por debajo del cero absoluto.");
            return;
        }

        double resultado = ConversorTemperatura.Convertir(valor, origen, destino);
        lblResultado.Text = $"{valor:0.##} {origen} = {resultado:0.##} {destino}";
    }

    // Acepta coma o punto como separador decimal
    private static bool TryLeerNumero(string texto, out double numero)
    {
        return double.TryParse(texto, NumberStyles.Float, CultureInfo.CurrentCulture, out numero)
            || double.TryParse(texto, NumberStyles.Float, CultureInfo.InvariantCulture, out numero);
    }
}
