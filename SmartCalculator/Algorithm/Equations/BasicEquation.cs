using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCalculator.Algorithm.Equations;

public class BasicEquation : IEquation
{
    public int InputCount => 5;

    public (double min, double max) GetDomain(int input) => input switch
    {
        0 => (0, 100),
        1 => (0, 50),
        2 => (-50, 25),
        3 => (-1.2, 2.4),
        4 => (20, 45),
        _ => throw new ArgumentException($"Input {input} is not used by function.")
    };

    public double Solve(IEnumerable<double> inputs)
    {
        double[] x = inputs.Take(5).ToArray();

        // y = a^3 + b * c + (d + 2 * e) * (a - c)

        return x[0] * x[0] * x[0] + x[1] * x[2] + (x[3] + 2 * x[4]) * (x[0] - x[2]); 
    }
}
