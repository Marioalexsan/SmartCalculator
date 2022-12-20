using SmartCalculator.Algorithm.Equations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace SmartCalculator.Algorithm;

public static class DifferentialEvolution
{
    public static List<double[]> RunSolver(DifferentialEvolutionData data)
    {
        if (data.OptimizationFunction == null)
            throw new ArgumentNullException(nameof(data));

        Random random = new();

        // todo uniformity
        var population = Enumerable.Range(0, data.PopulationSize)
            .Select(x => data.InputDomains.Select(x => x.min + random.NextDouble() * (x.max - x.min)))
            .Select(x => x.ToArray())
            .ToList();

        // Precalculate optimization function values
        var functionValues = population
            .Select(x => data.OptimizationFunction(x))
            .ToList();

        int populationSize = data.PopulationSize;
        int inputs = data.InputDomains.Count;

        int certainIndex = random.Next(0, inputs);

        for (int gen = 0; gen < data.Generations; gen++)
        {
            for (int i = 0; i < populationSize; i++)
            {
                // Mutate + Crossover combined step (thanks Wikipedia)

                var (a, b, c) = SelectThree(populationSize, random);

                var u = new double[inputs];

                for (int j = 0; j < inputs; j++)
                {
                    bool replace = j == certainIndex || random.NextDouble() < data.CrossoverRate;

                    u[j] = replace ? a + data.AmplificationFactor * (b - c) : population[i][j];
                }

                // Select step

                double newFunctionValue = data.OptimizationFunction(u);

                if (newFunctionValue <= functionValues[i])
                {
                    // New data is better
                    population[i] = u;
                    functionValues[i] = newFunctionValue;
                }
            }
        }

        var bugs = population.Zip(functionValues).OrderBy(x => x.Second).ToList();

        return population.Zip(functionValues).OrderBy(x => x.Second).Select(x => x.First).ToList();
    }

    private static (double a, double b, double c) SelectThree(int count, Random random)
    {
        int a, b, c = 0, tries = 50;

        do
        {
            a = random.Next(0, count);
            b = random.Next(0, count);

            if (a == b) 
                continue;

            c = random.Next(0, count);

            if (a == c || b == c)
                continue;

            break;
        }
        while (--tries > 0);

        return (a, b, c);
    }
}
