using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCalculator.Algorithm.Equations
{
    public class ComplexCaseEquation : IEquation
    {
        public int InputCount => 1;

        public double ValueA { get; set; } = 1;
        public double ValueB { get; set; } = 1;
        public double ValueC { get; set; } = 1;
        public double ValueD { get; set; } = 1;
        public double ValueE { get; set; } = 1;

        public string TextDisplay
        {
            get { return $"ln({ValueA}*x + {ValueB}*tg(Pi/x)) / ({ValueC}*{ValueD})^({ValueE}*x+sqrt(e*x))"; }
        }

        public (double min, double max) GetDomain(int input) => input switch
        {
            0 => (-100, 100),
            _ => throw new ArgumentException($"Input {input} is not used by function.")
        };

        public double Solve(IEnumerable<double> inputs)
        {
            double x = inputs.First();

            return Math.Log(ValueA * x + ValueB * Math.Tan(Math.PI / x)) / Math.Pow(ValueC * ValueD, ValueE * x + Math.Sqrt(Math.E * x));
        }
    }

}
