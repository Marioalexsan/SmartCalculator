using SmartCalculator.Algorithm.Equations;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
namespace SmartCalculator.UserInterface;

public class CoefficientViewModel
{
    public CoefficientViewModel(PolynomialEquationBuilderViewModel baseModel, int index)
    {
        BaseModel = baseModel;
        Index = index;
    }

    private string _value = "1";
    public string Value
    {
        get => _value;
        set
        {
            _value = value;
            BaseModel.NotifyChanged(null);
        }
    }

    public PolynomialEquationBuilderViewModel BaseModel { get; }
    public int Index { get; }
}

public class PolynomialEquationBuilderViewModel : BaseViewModel
{
    public PolynomialEquationBuilderViewModel()
    {
        PropertyChanged += PolynomialEquationBuilderViewModel_PropertyChanged;
    }

    private void PolynomialEquationBuilderViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        var array = Equation.Coefficients;
        Array.Resize(ref array, Coefficients.Count);
        Equation.Coefficients = array;

        for (int i = 0; i < Coefficients.Count; i++)
        {
            var value = Coefficients[i].Value;

            if (value == "")
                Equation.Coefficients[i] = 0;

            if (value == "+")
                Equation.Coefficients[i] = 1;

            if (value == "-")
                Equation.Coefficients[i] = -1;

            if (double.TryParse(value, out var num))
                Equation.Coefficients[i] = num;
        }
    }

    public PolynomialEquation Equation { get; } = new();

    public int CoefficientCount
    {
        get => Equation.Coefficients.Length;
        set
        {
            while (Coefficients.Count < value)
                Coefficients.Add(new CoefficientViewModel(this, Coefficients.Count));

            while (Coefficients.Count > value)
                Coefficients.RemoveAt(Coefficients.Count - 1);

            NotifyChanged(null);
        }
    }

    public ObservableCollection<CoefficientViewModel> Coefficients { get; private set; } = new();
}

/// <summary>
/// Interaction logic for GenericEquationBuilder.xaml
/// </summary>
public partial class PolynomialEquationBuilder : UserControl
{
    public PolynomialEquationBuilderViewModel ViewModel => (PolynomialEquationBuilderViewModel)DataContext;

    public PolynomialEquationBuilder()
    {
        InitializeComponent();
    }

    private void EquationGradeSlider_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
    {
        ViewModel.CoefficientCount = (int)e.NewValue;
    }
}
