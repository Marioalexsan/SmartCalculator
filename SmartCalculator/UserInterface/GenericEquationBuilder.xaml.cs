using SmartCalculator.Algorithm.Equations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

public class InputDomain
{
    public string Min { get; set; } = "";
    public string Max { get; set; } = "";
}

public class GenericEquationBuilderViewModel
{
    private IEquation? _equation;
    public IEquation? Equation
    {
        get => _equation;
        set
        {
            _equation = value;
            InputDomains.Clear();

            if (_equation != null)
            {
                for (int i = 0; i < _equation.InputCount; i++)
                {
                    var (min, max) = _equation.GetDomain(i);

                    InputDomains.Add(new InputDomain()
                    {
                        Min = min.ToString(),
                        Max = max.ToString()
                    });
                }
            }
        }
    }

    public ObservableCollection<InputDomain> InputDomains { get; } = new();
}

/// <summary>
/// Interaction logic for GenericEquationBuilder.xaml
/// </summary>
public partial class GenericEquationBuilder : UserControl
{
    public GenericEquationBuilderViewModel ViewModel { get; }

    public GenericEquationBuilder()
    {
        InitializeComponent();
        ViewModel = (GenericEquationBuilderViewModel)DataContext;
    }
}
