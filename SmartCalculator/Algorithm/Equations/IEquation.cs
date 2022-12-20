﻿using System;
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

    public string GetDisplay();
}

public static class EquationExtensions
{
    /// <summary>
    /// Build an optimization function that gives values close to zero for solutions that give results close to desired one.
    /// </summary>
    public static Func<IEnumerable<double>, double> GetOptimizationFunction(this IEquation equation, double result)
    {
        return (values) =>
        {
            return Math.Abs(equation.Solve(values) - result);
        };
    }
}