using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCalculator.Algorithm.Equations
{
    public class TrigonometricEquation : IEquation
    {
        public int InputCount => 1;

        public double ValueA { get; set; } = 2;
        public double ValueB { get; set; } = 3;

        public string TextDisplay
        {
            get { return $"sin({ValueA}x) + cos({ValueB}x)"; }
        }

        public (double min, double max) GetDomain(int input) => input switch
        {
            0 => (-100, 100),
            _ => throw new ArgumentException($"Input {input} is not used by function.")
        };

        public double Solve(IEnumerable<double> inputs)
        {
            double x = inputs.First();

            return Math.Sin(ValueA * x) + Math.Cos(ValueB * x);
        }
    }

}
