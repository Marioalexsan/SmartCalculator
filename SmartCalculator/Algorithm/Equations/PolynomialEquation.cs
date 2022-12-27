using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCalculator.Algorithm.Equations;

public class PolynomialEquation : IEquation
{
    public int InputCount => 1;

    public double[] Coefficients { get; } = new double[]
    {
        1, -6, 8
    };

    public string GetDisplay()
    {
        StringBuilder builder = new();

        for (int i = 0; i < Coefficients.Length; i++)
        {
            if (Coefficients[i] == 0)
                continue;

            if (Math.Abs(Coefficients[i]) == 1)
            {
                builder.Append(Coefficients[i] == 1 ? "" : "-");
            }
            else
            {
                builder.Append(Coefficients[i]);
            }

            int pow = Coefficients.Length - i - 1;

            if (pow != 0)
            {
                if (Math.Abs(Coefficients[i]) != 1)
                    builder.Append('*');

                builder.Append('x');
                
                if (pow != 1)
                {
                    builder.Append('^');
                    builder.Append(pow);
                }
            }

            if (i < Coefficients.Length - 1 && Coefficients[i + 1] > 0)
            {
                builder.Append('+');
            }
        }

        return builder.ToString();
    }

    public (double min, double max) GetDomain(int input) => input switch
    {
        0 => (-100, 100),
        _ => throw new ArgumentException($"Input {input} is not used by function.")
    };

    public double Solve(IEnumerable<double> inputs)
    {
        double x = inputs.First();
        double pow = 1;
        double sum = 0;

        for (int i = Coefficients.Length - 1; i >= 0; i--)
        {
            sum += pow * Coefficients[i];
            pow *= x;
        }

        return sum;
    }
}
