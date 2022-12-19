using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCalculator.Algorithm.Equations;

// Operates in real domain, because complex domain sucks
public interface IEquation
{
    public int InputCount { get; }

    public (double min, double max) GetDomain(int input);

    public double Solve(IEnumerable<double> inputs);
}
