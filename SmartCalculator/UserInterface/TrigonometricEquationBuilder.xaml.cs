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
using SmartCalculator.Algorithm.Equations;

namespace SmartCalculator.UserInterface
{

    public class TrigonometricEquationBuilderViewModel : BaseViewModel
    {

        public TrigonometricEquation Equation { get; } = new();
        public string ValueA { get => _ValueA; set { _ValueA = value; NotifyChanged(null); } }
        public string ValueB { get => _ValueB; set { _ValueB = value; NotifyChanged(null); } }

        private string _ValueA = "2";
        private string _ValueB = "3";
        public TrigonometricEquationBuilderViewModel()
        {
            PropertyChanged += TrigonometricEquationBuilderViewModel_PropertyChanged;
        }

        private void TrigonometricEquationBuilderViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

            var value = ValueA;

            if (value == "")
                Equation.ValueA = 0;

            if (value == "+")
                Equation.ValueA = 1;

            if (value == "-")
                Equation.ValueA = -1;

            if (double.TryParse(value, out var num))
                Equation.ValueA = num;

            value = ValueB;

            if (value == "")
                Equation.ValueB = 0;

            if (value == "+")
                Equation.ValueB = 1;

            if (value == "-")
                Equation.ValueB = -1;

            if (double.TryParse(value, out num))
                Equation.ValueB = num;

        }


    }

    /// <summary>
    /// Interaction logic for ExponentialEquationBuilder.xaml
    /// </summary>
    public partial class TrigonometricEquationBuilder : UserControl
    {
        public TrigonometricEquationBuilderViewModel ViewModel => (TrigonometricEquationBuilderViewModel)DataContext;
        public TrigonometricEquationBuilder()
        {
            InitializeComponent();
        }
    }
}
