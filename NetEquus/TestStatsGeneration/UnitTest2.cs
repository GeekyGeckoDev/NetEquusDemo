using Newtonsoft.Json.Linq;
using Xunit;

namespace TestStatsGeneration;

public class UnitTest2
{
    [Fact]

    public void RunFoalConfGenerationTest()
    {

        var dam = new ConformationAttributes
        {
            // Movement
            Legs = 8,
            Shoulders = 6.2,
            Hindquarters = 5.8,
            Pasterns = 7.9,
            BackAndLoin = 7.0,

            // Type
            Head = 7.4,
            Neck = 7.0,
            ChestAndBarrel = 7.8,
            BackAndTopline = 6.9,
        };

        var sire = new ConformationAttributes
        {
            // Movement
            Legs = 6.1,
            Shoulders = 7.2,
            Hindquarters = 7.8,
            Pasterns = 6.9,
            BackAndLoin = 8.0,

            // Type
            Head = 6.4,
            Neck = 8,
            ChestAndBarrel = 6.8,
            BackAndTopline = 7.9,
        };

        Console.WriteLine("DAM");
        PrintHorse(dam);

        Console.WriteLine();
        Console.WriteLine("SIRE");
        PrintHorse(sire);

        List<ConformationAttributes> foals = new();


        for (int i = 1; i <= 25; i++)
        {
            var foal = GenerateConfFoalFromParents(
                dam,
                sire);

            foals.Add(foal);

            Console.WriteLine($"FOAL {i}");
            PrintHorse(foal);
            Console.WriteLine();
        }

        Console.WriteLine("---------------------------");
        Console.WriteLine($"Average Total : {foals.Average(AverageMove):0.00}");
        Console.WriteLine($"Highest Total : {foals.Max(AverageMove):0.00}");
        Console.WriteLine($"Lowest Total  : {foals.Min(AverageMove):0.00}");

        Console.WriteLine($"Average Total : {foals.Average(AverageType):0.00}");
        Console.WriteLine($"Highest Total : {foals.Max(AverageType):0.00}");
        Console.WriteLine($"Lowest Total  : {foals.Min(AverageType):0.00}");

                Console.WriteLine($"Average Total : {foals.Average(AverageOverall):0.00}");
        Console.WriteLine($"Highest Total : {foals.Max(AverageOverall):0.00}");
        Console.WriteLine($"Lowest Total  : {foals.Min(AverageOverall):0.00}");



    }

    private static void PrintHorse(ConformationAttributes horse)
    {
        Console.WriteLine($"Gaits         {horse.Legs}");
        Console.WriteLine($"Scope         {horse.Shoulders}");
        Console.WriteLine($"Speed         {horse.Hindquarters}");
        Console.WriteLine($"Agility       {horse.Pasterns}");
        Console.WriteLine($"Endurance     {horse.BackAndLoin}");

        Console.WriteLine($"Gaits         {horse.Head}");
        Console.WriteLine($"Scope         {horse.Neck}");
        Console.WriteLine($"Speed         {horse.ChestAndBarrel}");
        Console.WriteLine($"Agility       {horse.BackAndTopline}");

    }

    private static double AverageMove(ConformationAttributes move)
    {
        return move.MovementScore;
    }
    private static double AverageType(ConformationAttributes move)
    {
        return move.TypeScore;
    }

    private static double AverageOverall(ConformationAttributes move)
    {
        return move.OverallProportions;
    }


    public static ConformationAttributes GenerateConfFoalFromParents (ConformationAttributes dam, ConformationAttributes sire)
    {
        Random rnd = new Random();

        //double inheritanceVariance = (rnd.NextDouble() * 0.20) - 0.10;

        double[] damMoveStats = { dam.Legs, dam.Shoulders, dam.Hindquarters, dam.Pasterns, dam.BackAndLoin };

        double[] sireMoveStats = { sire.Legs, sire.Shoulders, sire.Hindquarters, sire.Pasterns, sire.BackAndLoin };

        double[] foalMoveStats = new double[damMoveStats.Length];

        double[] damTypeStats = { dam.Head, dam.Neck, dam.ChestAndBarrel, dam.BackAndTopline};

        double[] sireTypeStats = { sire.Head, sire.Neck, sire.ChestAndBarrel, sire.BackAndTopline};

        double[] foalTypeStats = new double[damTypeStats.Length];


        // Entire foal resembles one parent a little more.
        double movementBias = (rnd.NextDouble() * 0.20) - 0.10; // -0.10 -> +0.10

        double typeBias = (rnd.NextDouble() * 0.20) - 0.10;



        for (int i = 0; i < damMoveStats.Length; i++)
        {
            double maxVariance = i switch
            {
                // Legs
                0 => 0.25,

                // Shoulders
                1 => 0.28,

                // Hindquarters
                2 => 0.28,

                // Pasterns
                3 => 0.25,

                // Back & Loin
                4 => 0.30,

                _ => 0.30
            };

            // Small variation for this individual stat.
            double inheritanceVariance =
                (rnd.NextDouble() * maxVariance * 2) - maxVariance;

            double totalBias = movementBias + inheritanceVariance;

            double damWeight = Math.Clamp(0.5 + totalBias, 0.35, 0.65);
            double sireWeight = 1.0 - damWeight;

            double value =
                damMoveStats[i] * damWeight +
                sireMoveStats[i] * sireWeight;

            // Tiny natural variation
            value += (rnd.NextDouble() * 0.10) - 0.05;

            value = Math.Clamp(value, 1.0, 10.0);

            foalMoveStats[i] = Math.Round(value, 1);

           
        }

        for (int i = 0; i < damTypeStats.Length; i++)
        {
            double maxVariance = i switch
            {
                0 => 0.35, // Head
                1 => 0.32, // Neck
                2 => 0.30, // Chest
                3 => 0.28, // Back & Topline
                _ => 0.30
            };

            double inheritanceVariance =
               (rnd.NextDouble() * maxVariance * 2) - maxVariance;

            double totalBias = typeBias + inheritanceVariance;

            double damWeight = Math.Clamp(0.5 + totalBias, 0.35, 0.65);
            double sireWeight = 1.0 - damWeight;

            double value = damTypeStats[i] * damWeight +
                sireTypeStats[i] * sireWeight;

            value += (rnd.NextDouble() * 0.04) - 0.02;

            value = Math.Clamp(value, 1.0, 10.0);

            foalTypeStats[i] = Math.Round(value, 1);



        }

        return new ConformationAttributes
        {
            Legs = Math.Round(foalMoveStats[0], 1),
            Shoulders = Math.Round(foalMoveStats[1], 1),
            Hindquarters = Math.Round(foalMoveStats[2], 1),
            Pasterns = Math.Round(foalMoveStats[3], 1),
            BackAndLoin = Math.Round(foalMoveStats[4], 1),

            Head = Math.Round(foalTypeStats[0], 1),
            Neck = Math.Round(foalTypeStats[1], 1),
            ChestAndBarrel = Math.Round(foalTypeStats[2], 1),
            BackAndTopline = Math.Round(foalTypeStats[3], 1)

        };
    }
}
