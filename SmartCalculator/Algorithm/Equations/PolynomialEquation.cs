using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace SmartCalculator.Algorithm.Equations;

public class PolynomialEquation : IEquation
{
    public int InputCount => 1;

    public double[] Coefficients { get; set; } = new double[]
    {
        1, -6, 8
    };

    public string TextDisplay
    {
        get
        {
            StringBuilder builder = new();
            bool started = false;

            for (int i = 0; i < Coefficients.Length; i++)
            {
                if (Coefficients[i] == 0)
                    continue;

                bool isOne = Math.Abs(Coefficients[i]) == 1;
                bool isPositive = Coefficients[i] > 0;
                int pow = Coefficients.Length - i - 1;

                if (isOne)
                {
                    if (started || !isPositive)
                    {
                        builder.Append(isPositive ? '+' : '-');
                    }

                    if (pow == 0)
                    {
                        builder.Append('1');
                    }
                }
                else
                {
                    if (started && isPositive)
                        builder.Append('+');

                    builder.Append(Coefficients[i]);
                }

                if (pow != 0)
                {
                    if (!isOne)
                        builder.Append('*');

                    builder.Append('x');

                    if (pow != 1)
                    {
                        builder.Append('^');
                        builder.Append(pow);
                    }
                }

                started = true;

                builder.Append(' ');
            }

            if (builder.Length == 0)
                builder.Append("<All coefficients are zero!>");

            else builder.Length -= 1;

            return builder.ToString();
        }
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
