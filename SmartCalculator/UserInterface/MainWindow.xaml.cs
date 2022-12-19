using SmartCalculator.Algorithm.Equations;
using SmartCalculator.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartCalculator.UserInterface;

public class MainWindowViewModel
{
    public IEquation? Equation { get; set; }
}

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindowViewModel ViewModel { get; }

    public MainWindow()
    {
        InitializeComponent();
        ViewModel = (MainWindowViewModel)DataContext;
    }

    private void MenuAbout_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show(string.Join(Environment.NewLine, new []
        {
            "Smart Calculator",
            "Inteligență Artificială 2022, TUIAȘI",
            "- Miron Alexandru, 1410A",
            "- Dămian Gabriel-Mihai, 1410A",
            "- Robert Țuțuianu, 1410A"
        }), "Despre aplicație");
    }

    private void InputEquation_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        EquationPanel.Items.Clear();

        Control? control = InputEquation.SelectedIndex switch
        {
            0 => new GenericEquationBuilder() { ViewModel = { Equation = ViewModel.Equation = new BasicEquation() } },
            _ => null
        };

        if (control != null)
            EquationPanel.Items.Add(control);

        else
        {
            ViewModel.Equation = null;
        }
    }

    private void RunAlgorithmButton_Click(object sender, RoutedEventArgs e)
    {
        if (ViewModel.Equation != null)
        {

        }
        else
        {
            SimulationResults.Text = "Please select an algorithm!";
        }
    }
}
