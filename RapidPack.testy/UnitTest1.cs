using Xunit;
using RapidPack;

namespace RapidPack.testy;

public class ParcelCalculatorTests
{
    private readonly ParcelCalculator _calculator = new();

    [Fact]
    public void Waga35DajeBlad()
    {
        string result = _calculator.CalculatePrice(30, 30, 30, 35, false, "Standardowa");
        
        Assert.Contains("Błąd", result);
    }

    [Fact]
    public void WiecejNiz150Dodaje50Procent()
    {
        string result = _calculator.CalculatePrice(50, 50, 60, 5, false, "Standardowa");
        
        Assert.Contains("Cena końcowa: 30,00 zł", result);
    }

    [Fact]
    public void PaletaZa100()
    {
        string result = _calculator.CalculatePrice(10, 10, 10, 20, false, "Paleta");

        Assert.Contains("Cena końcowa: 100,00 zł", result);
    }

    [Fact]
    public void EkspresDodaje15zl()
    {
        string result = _calculator.CalculatePrice(30, 30, 30, 5, true, "Standardowa");

        Assert.Contains("Cena końcowa: 35,00 zł", result);
    }
}