using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCalculator.Algorithm;

public class DifferentialEvolutionData
{
    private float _mutationRate = 0.1f;
    public float MutationRate
    {
        get => _mutationRate;
        set => _mutationRate = Math.Clamp(value, 0f, 1f);
    }

    private float _ampFactor = 2f;
    public float AmplificationFactor
    {
        get => _ampFactor;
        set => _ampFactor = Math.Clamp(value, 0.01f, 2f);
    }

    public uint PopulationSize { get; set; } = 100;

    public List<(double min, double max)> InputDomains { get; } = new();

    public Func<double, IEnumerable<double>>? OptimizationFunction { get; set; }
}
