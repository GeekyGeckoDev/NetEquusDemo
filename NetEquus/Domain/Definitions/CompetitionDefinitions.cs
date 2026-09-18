using Domain.Definitions;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.StaticClasses
{
    public static class CompetitionDefinitions
    {
        public static readonly List<CompetitionClassDefinition> Dressage =
        [
            new()
        {
            Name = "Beginner",
            Level = 1,
            Requirements =
            [
                new() { Stat = GenerationStat.Gaits, Weight = 0.40 },
                new() { Stat = GenerationStat.Stride, Weight = 0.35 },
                new() { Stat = GenerationStat.Agility, Weight = 0.25 }
            ]
        },

        new()
        {
            Name = "Intermediate",
            Level = 2,
            Requirements =
            [
                new() { Stat = GenerationStat.Gaits, Weight = 0.30 },
                new() { Stat = GenerationStat.Stride, Weight = 0.25 },
                new() { Stat = GenerationStat.Agility, Weight = 0.25 },
                new() { Stat = GenerationStat.Endurance, Weight = 0.20 }
            ]
        },

        new()
        {
            Name = "Grand Prix",
            Level = 3,
            Requirements =
            [
                new() { Stat = GenerationStat.Gaits, Weight = 0.20 },
                new() { Stat = GenerationStat.Stride, Weight = 0.20 },
                new() { Stat = GenerationStat.Agility, Weight = 0.20 },
                new() { Stat = GenerationStat.Endurance, Weight = 0.25 },
                new() { Stat = GenerationStat.Trainability, Weight = 0.15 }
            ]
        }
        ];
    }
}
