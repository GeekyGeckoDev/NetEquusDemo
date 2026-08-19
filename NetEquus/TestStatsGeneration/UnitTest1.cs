using TestStatsGeneration;
using Xunit;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class UnitTest1
{


    [Fact]

    public void RunFoalGenerationTest()
    {


        var dam = new PerformanceAttributes
        {
            Gaits =  3.0,
            Scope =  7.5,
            Speed =  7.0,
            Agility = 4.5,
            Endurance =   6.0,
            Stride = 5.0


        };

       var sire = new PerformanceAttributes
        {
            Gaits  = 4.5,
            Scope =   6.5,
            Speed =  7.0,
            Agility = 3.0,
            Endurance =  5.0,
            Stride = 7.0

        };

        Console.WriteLine("DAM");
        PrintHorse(dam);

        Console.WriteLine();
        Console.WriteLine("SIRE");
        PrintHorse(sire);

        Console.WriteLine();

        List<PerformanceAttributes> foals = new();

        for (int i = 1; i <= 25; i++)
        {
            var foal = GeneratePerfFoalFromParents(
                dam,
                sire,
                1.0);

            foals.Add(foal);

            Console.WriteLine($"FOAL {i}");
            PrintHorse(foal);
            Console.WriteLine();
        }

        Console.WriteLine("---------------------------");
        Console.WriteLine($"Average Total : {foals.Average(Total):0.00}");
        Console.WriteLine($"Highest Total : {foals.Max(Total):0.00}");
        Console.WriteLine($"Lowest Total  : {foals.Min(Total):0.00}");
    }

    private static void PrintHorse(PerformanceAttributes horse)
    {
        Console.WriteLine($"Gaits         {horse.Gaits}");
        Console.WriteLine($"Scope         {horse.Scope}");
        Console.WriteLine($"Speed         {horse.Speed}");
        Console.WriteLine($"Agility       {horse.Agility}");
        Console.WriteLine($"Endurance     {horse.Endurance}");
        Console.WriteLine($"Stride        {horse.Stride}");
        Console.WriteLine($"TOTAL         {Total(horse):0.0}");
    }

    private static double Total(PerformanceAttributes horse)
    {
        return horse.Gaits +
               horse.Scope +
               horse.Speed +
               horse.Agility +
               horse.Endurance +
               horse.Stride;
  
    }

    private static double GetMutationRange(double stat)
    {
        if (stat >= 9.5) return 0.05;
        if (stat >= 9.0) return 0.10;
        if (stat >= 8.0) return 0.20;
        if (stat >= 7.0) return 0.35;

        return 0.60;
    }

    private static double GetPositiveMutationChance(double stat)
    {
        if (stat < 4) return 0.30;
        if (stat < 6) return 0.45;
        if (stat < 8) return 0.50;
        if (stat < 9) return 0.60;

        return 0.70;
    }

    private static double ApplyHighStatResistance(double value, Random rnd)
    {
        if (value < 8)
            return value;

        double chance = value switch
        {
            < 8.5 => 0.75,
            < 9.0 => 0.50,
            < 9.5 => 0.25,
            < 10.0 => 0.05,
            _ => 0.00
        };

        if (rnd.NextDouble() > chance)
        {
            // Small regression
            value -= rnd.NextDouble() * 0.15;
        }

        return value;
    }

    public static PerformanceAttributes GeneratePerfFoalFromParents(PerformanceAttributes dam, PerformanceAttributes sire, double damInheritanceMultiplyer)
    {
        Random rnd = new Random();


        double[] damStats = { dam.Gaits, dam.Scope, dam.Speed, dam.Agility, dam.Endurance, dam.Stride, };
        double[] sireStats = { sire.Gaits, sire.Scope, sire.Speed, sire.Agility, sire.Endurance, sire.Stride,};
        // Get the number of items in damStats array.
        double[] foalStats = new double[damStats.Length];

        int maxedStatsCount = 0;

        for (int i = 0; i < damStats.Length; i++)
        {
            double damWeight = damStats[i] * 0.6;
            double sireWeight = sireStats[i] * 0.4;


            //Combining parents

            double geneticLuck = (rnd.NextDouble() - 0.5) * 0.6;

            double parentSum = damStats[i] + sireStats[i];

            double parentAverage = parentSum / 2;

            double value = damWeight + sireWeight;

            double mutationRange = GetMutationRange(value);

            double positiveChance = GetPositiveMutationChance(parentAverage);

            double mutations;

            if (rnd.NextDouble() < positiveChance)
            {
                mutations = rnd.NextDouble() * mutationRange;
            }
            else
            {
                mutations = -rnd.NextDouble() * mutationRange;
            }

            value += mutations;

            value += mutations * mutationRange;
            value += geneticLuck;

            value += (rnd.NextDouble() * mutationRange * 2) - mutationRange;

            foalStats[i] = ApplyHighStatResistance(value, rnd);
        }

        //Stat rules enforcements

        var lowIndexes = Enumerable.Range(0, foalStats.Length).Where(i => foalStats[i] < 4).ToList();

        int toRaise = Math.Min(2, lowIndexes.Count);

        for (int i = 0; i < toRaise; i++)
        {
            int index = lowIndexes[rnd.Next(lowIndexes.Count)];
            foalStats[index] = 4 + rnd.NextDouble();
            lowIndexes.Remove(index);

        }

        for (int i = 0; i < foalStats.Length; i++)
        {
            foalStats[i] = Math.Clamp(foalStats[i], 1.0, 10.0);
        }

        double sum = foalStats.Sum();

        while (sum > 52)
        {
            int index = rnd.Next(foalStats.Length);

            if (foalStats[index] > 1)
            {
                foalStats[index] -= 0.1;
                foalStats[index] = Math.Round(foalStats[index], 1);

                sum = foalStats.Sum();
            }


        }

        return new PerformanceAttributes
        {
            Gaits = Math.Round(foalStats[0], 1),
            Scope = Math.Round(foalStats[1], 1),
            Speed = Math.Round(foalStats[2], 1),
            Agility = Math.Round(foalStats[3], 1),
            Endurance = Math.Round(foalStats[4], 1),
            Stride = Math.Round(foalStats[5], 1),
 
        };


    }
}

