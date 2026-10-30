using Infrastructure;
using Domain.Entities.Models.HorseAppereances;
using Microsoft.EntityFrameworkCore;

var factory = new NetEquusDbContextFactory();

await using var db = factory.CreateDbContext(Array.Empty<string>());
await using var transaction = await db.Database.BeginTransactionAsync();

var horseNames = new[] { "Prince", "Lucky", "Snowy" };

var horses = await db.Horses
    .Where(h => horseNames.Contains(h.HorseName))
    .ToListAsync();

if (horseNames.Any(name =>
    horses.Count(h => h.HorseName == name) != 1))
{
    throw new InvalidOperationException(
        "Expected exactly one Prince, one Lucky and one Snowy. No changes committed.");
}

async Task<HorseAppearance> GetOrCreateAppearanceAsync(string image)
{
    var appearance = await db.HorseAppearances
        .FirstOrDefaultAsync(a => a.Image == image);

    if (appearance is not null)
        return appearance;

    appearance = new HorseAppearance
    {
        AppearanceId = Guid.NewGuid(),
        Image = image
    };

    db.HorseAppearances.Add(appearance);
    await db.SaveChangesAsync();

    Console.WriteLine($"Created appearance: {image}");
    return appearance;
}

var stallionAppearance =
    await GetOrCreateAppearanceAsync("/images/ShetlandStallionTrans.png");

var mareAppearance =
    await GetOrCreateAppearanceAsync("/images/shetlandMare.png");

foreach (var horse in horses)
{
    var appearance = horse.HorseName == "Snowy"
        ? mareAppearance
        : stallionAppearance;

    horse.AppearanceId = appearance.AppearanceId;

    Console.WriteLine($"{horse.HorseName} -> {appearance.Image}");
}

await db.SaveChangesAsync();
await transaction.CommitAsync();

Console.WriteLine("All three horses have been assigned images!");
