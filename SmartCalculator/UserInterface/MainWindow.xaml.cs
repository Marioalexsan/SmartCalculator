using SmartCalculator.Algorithm;
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

public class MainWindowViewModel : BaseViewModel
{
    private IEquation? _equation;
    public IEquation? Equation
    {
        get => _equation;
        set => Change(ref _equation, value);
    }
}

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindowViewModel ViewModel => (MainWindowViewModel)DataContext;

    public MainWindow()
    {
        InitializeComponent();
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

        Control? control = null;

        switch (InputEquation.SelectedIndex)
        {
            case 0:
                var builder = new PolynomialEquationBuilder();
                ViewModel.Equation = builder.ViewModel.Equation;
                control = builder;
                break;

            case 1:
                var builder_1 = new ExponentialEquationBuilder();
                ViewModel.Equation = builder_1.ViewModel.Equation;
                control = builder_1;
                break;

            case 2:
                var builder_2 = new TrigonometricEquationBuilder();
                ViewModel.Equation = builder_2.ViewModel.Equation;
                control = builder_2;
                break;

            case 3:
                var builder_3 = new RadicalEquationBuilder();
                ViewModel.Equation = builder_3.ViewModel.Equation;
                control = builder_3;
                break;

            case 4:
                var builder_4 = new LogarithmicEquationBuilder();
                ViewModel.Equation = builder_4.ViewModel.Equation;
                control = builder_4;
                break;
            case 5:
                var builder_5 = new ComplexCaseEquationBuilder();
                ViewModel.Equation = builder_5.ViewModel.Equation;
                control = builder_5;
                break;
        }

        if (control != null)
            EquationPanel.Items.Add(control);

        else ViewModel.Equation = null;
    }

    private void RunAlgorithmButton_Click(object sender, RoutedEventArgs e)
    {
        if (ViewModel.Equation != null)
        {
            double ampFactor = default;
            double crossRate = default;
            int gens = default;
            double targetValue = default;
            int popSize = default;

            bool success = double.TryParse(InputAmplificationFactor.Text, out ampFactor)
                && double.TryParse(InputCrossoverRate.Text, out crossRate)
                && int.TryParse(InputGenerations.Text, out gens)
                && double.TryParse(InputTargetEquationValue.Text, out targetValue)
                && int.TryParse(InputPopulationSize.Text, out popSize);

            if (!success)
            {
                MessageBox.Show("Invalid inputs!");
                return;
            }

            // TODO proper value parsing / validation
            DifferentialEvolutionData data = new()
            {
                AmplificationFactor = ampFactor,
                CrossoverRate = crossRate,
                Generations = gens,
                OptimizationFunction = ViewModel.Equation.GetOptimizationFunction(targetValue),
                PopulationSize = popSize,
                InputDomains = Enumerable.Range(0, ViewModel.Equation.InputCount).Select(x => ViewModel.Equation.GetDomain(x)).ToList()
            };

            var output = DifferentialEvolution.RunSolver(data);

            var cleanOutput = new List<double[]>();

            foreach (var value in output)
            {
                if (cleanOutput.Any(x => x.Zip(value).All(pair => Math.Abs(pair.First - pair.Second) < 0.001)))
                    continue;

                cleanOutput.Add(value);
            }

            SimulationResults.Text = "Potential results: " + Environment.NewLine;

            foreach (var solution in cleanOutput)
            {
                SimulationResults.Text += "[";
                SimulationResults.Text += string.Join(", ", solution.Select(y => string.Format("{0:F4}", y)));
                SimulationResults.Text += "]";
                SimulationResults.Text += " - f(X) = ";
                SimulationResults.Text += string.Format("{0:F4}", ViewModel.Equation.Solve(solution));
                SimulationResults.Text += Environment.NewLine;
            }
        }
        else
        {
            MessageBox.Show("Please select an algorithm!");
        }
    }
}
