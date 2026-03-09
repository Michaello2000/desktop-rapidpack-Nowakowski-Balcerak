namespace RapidPack;

public class ParcelCalculator
{
    public string CalculatePrice(int height, int width, int depth, int weight, bool express, string shipmentType)
    {
        if (height <= 0)
        {
            return "Błąd: Wysokość musi być większa od 0.";
        }

        if (width <= 0)
        {
            return "Błąd: Szerokość musi być większa od 0.";
        }

        if (depth <= 0)
        {
            return "Błąd: Głębokość musi być większa od 0.";
        }

        if (weight <= 0)
        {
            return "Błąd: Waga musi być większa od 0.";
        }

        if (weight > 30)
        {
            return "Błąd: Waga przesyłki nie może przekraczać 30 kg.";
        }

        if (shipmentType != "Standardowa" && shipmentType != "Ostrożnie (szkło)" && shipmentType != "Paleta")
        {
            return "Błąd: Nieznany typ przesyłki.";
        }

        double price;
        int dimensionsSum = height + width + depth;

        if (shipmentType == "Paleta")
        {
            price = 100;
        }
        else
        {
            price = 10 + (weight * 2); //10 to cena bazowa a 2 to cena za kazdy kg packzi

            if (shipmentType == "Ostrożnie (szkło)")
            {
                price += 10;
            }

            if (dimensionsSum > 150)
            {
                price *= 1.5;
            }
        }

        if (express)
        {
            price += 15;
        }

        return "Podsumowanie wyceny:\n"
               + $"Wymiary: {height} x {width} x {depth} cm\n"
               + $"Suma wymiarów: {dimensionsSum} cm\n"
               + $"Waga: {weight} kg\n"
               + $"Typ przesyłki: {shipmentType}\n"
               + $"Ekspres: {(express ? "Tak" : "Nie")}\n"
               + $"Cena końcowa: {price:F2} zł";
    }
}