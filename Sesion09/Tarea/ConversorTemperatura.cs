namespace Tarea;

public static class ConversorTemperatura
{
    public const string Celsius = "°C";
    public const string Fahrenheit = "°F";
    public const string Kelvin = "K";

    public static readonly string[] Unidades = { Celsius, Fahrenheit, Kelvin };

    private const double CeroAbsolutoCelsius = -273.15;

    // Todas las conversiones pasan por Celsius: así solo hay 3 fórmulas de ida y 3 de vuelta
    public static double Convertir(double valor, string origen, string destino)
    {
        double celsius = ACelsius(valor, origen);

        return destino switch
        {
            Celsius => celsius,
            Fahrenheit => celsius * 9 / 5 + 32,
            Kelvin => celsius - CeroAbsolutoCelsius,
            _ => throw new ArgumentException($"Unidad de destino no válida: {destino}")
        };
    }

    // Una temperatura por debajo del cero absoluto no existe
    public static bool EsTemperaturaValida(double valor, string unidad)
    {
        return ACelsius(valor, unidad) >= CeroAbsolutoCelsius - 1e-9;
    }

    private static double ACelsius(double valor, string unidad)
    {
        return unidad switch
        {
            Celsius => valor,
            Fahrenheit => (valor - 32) * 5 / 9,
            Kelvin => valor + CeroAbsolutoCelsius,
            _ => throw new ArgumentException($"Unidad de origen no válida: {unidad}")
        };
    }
}
