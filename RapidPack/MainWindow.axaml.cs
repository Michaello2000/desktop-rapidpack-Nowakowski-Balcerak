using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RapidPack;

public partial class MainWindow : Window
{
    private readonly ParcelCalculator _parcelCalculator = new();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void QuoteButton_Click(object? sender, RoutedEventArgs e)
    {
        if (!int.TryParse(HeightTextBox.Text, out int height))
        {
            OutputTextBlock.Text = "Błąd: Pole 'Wysokość' musi być liczbą całkowitą.";
            return;
        }

        if (!int.TryParse(WidthTextBox.Text, out int width))
        {
            OutputTextBlock.Text = "Błąd: Pole 'Szerokość' musi być liczbą całkowitą.";
            return;
        }

        if (!int.TryParse(DepthTextBox.Text, out int depth))
        {
            OutputTextBlock.Text = "Błąd: Pole 'Głębokość' musi być liczbą całkowitą.";
            return;
        }

        if (!int.TryParse(WeightTextBox.Text, out int weight))
        {
            OutputTextBlock.Text = "Błąd: Pole 'Waga' musi być liczbą całkowitą.";
            return;
        }

        var selectedItem = ShipmentTypeComboBox.SelectedItem as ComboBoxItem;
        string shipmentType = selectedItem?.Content?.ToString() ?? "Standardowa";
        bool express = ExpressCheckBox.IsChecked == true;

        OutputTextBlock.Text = _parcelCalculator.CalculatePrice(height, width, depth, weight, express, shipmentType);
    }
}