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

    public class ComplexCaseEquationBuilderViewModel : BaseViewModel
    {

        public ComplexCaseEquation Equation { get; } = new();
        public string ValueA { get => _ValueA; set { _ValueA = value; NotifyChanged(null); } }
        public string ValueB { get => _ValueB; set { _ValueB = value; NotifyChanged(null); } }
        public string ValueC { get => _ValueC; set { _ValueC = value; NotifyChanged(null); } }
        public string ValueD { get => _ValueD; set { _ValueD = value; NotifyChanged(null); } }
        public string ValueE { get => _ValueE; set { _ValueE = value; NotifyChanged(null); } }

        private string _ValueA = "1";
        private string _ValueB = "1";
        private string _ValueC = "1";
        private string _ValueD = "1";
        private string _ValueE = "1";
        public ComplexCaseEquationBuilderViewModel()
        {
            PropertyChanged += ComplexCaseEquationBuilderViewModel_PropertyChanged;
        }

        private void ComplexCaseEquationBuilderViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
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


            value = ValueC;

            if (value == "")
                Equation.ValueC = 0;

            if (value == "+")
                Equation.ValueC = 1;

            if (value == "-")
                Equation.ValueC = -1;

            if (double.TryParse(value, out num))
                Equation.ValueC = num;


            value = ValueD;

            if (value == "")
                Equation.ValueD = 0;

            if (value == "+")
                Equation.ValueD = 1;

            if (value == "-")
                Equation.ValueD = -1;

            if (double.TryParse(value, out num))
                Equation.ValueD = num;


            value = ValueE;

            if (value == "")
                Equation.ValueE = 0;

            if (value == "+")
                Equation.ValueE = 1;

            if (value == "-")
                Equation.ValueE = -1;

            if (double.TryParse(value, out num))
                Equation.ValueE = num;

        }


    }

    /// <summary>
    /// Interaction logic for ExponentialEquationBuilder.xaml
    /// </summary>
    public partial class ComplexCaseEquationBuilder : UserControl
    {
        public ComplexCaseEquationBuilderViewModel ViewModel => (ComplexCaseEquationBuilderViewModel)DataContext;
        public ComplexCaseEquationBuilder()
        {
            InitializeComponent();
        }
    }
}
