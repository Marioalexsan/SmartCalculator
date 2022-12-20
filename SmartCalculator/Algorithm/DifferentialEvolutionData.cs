using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCalculator.Algorithm;

/// <summary>
/// Holds all of the essential data for the standard implmentation of the differential evolution algorithm.
/// </summary>
public class DifferentialEvolutionData
{
    private double _crossoverRate = 0.1;
    public double CrossoverRate
    {
        get => _crossoverRate;
        set => _crossoverRate = Math.Clamp(value, 0, 1);
    }

    private double _ampFactor = 0.8;
    public double AmplificationFactor
    {
        get => _ampFactor;
        set => _ampFactor = Math.Clamp(value, 0.01, 2);
    }

    public int PopulationSize { get; set; } = 100;

    public int Generations { get; set; } = 50;

    public List<(double min, double max)> InputDomains { get; set; } = new();

    public Func<IEnumerable<double>, double>? OptimizationFunction { get; set; }
}
