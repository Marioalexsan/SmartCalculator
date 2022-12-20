using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCalculator.Algorithm.Equations;

public class BasicEquation2 : IEquation
{
    public int InputCount => 1;

    public (double min, double max) GetDomain(int input) => input switch
    {
        0 => (-100, 100),
        _ => throw new ArgumentException($"Input {input} is not used by function.")
    };

    public double Solve(IEnumerable<double> inputs)
    {
        double x = inputs.First();

        // y = x^2 - 6 * x + 8

        return x * x - 6 * x + 8;
    }
}
