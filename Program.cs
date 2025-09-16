

Console.WriteLine("Welcome to my Fighting Game");

// Hp mana dmg 
List<int> stats1 = new List<int> { };
List<int> stats2 = new List<int> { };
stats1 = AddToStat(stats1);
stats2 = AddToStat(stats2);

Console.WriteLine($"""
        char 1 has {stats1[0]} hp, {stats1[1]} mana, {stats1[2]} DMG
        char 2 has {stats2[0]} hp, {stats2[1]} mana, {stats2[2]} DMG
        """);
stats2[0] = standardAttack(stats1[2], stats2[0]);

Console.WriteLine($"""
        char 1 has {stats1[0]} hp, {stats1[1]} mana, {stats1[2]} DMG
        char 2 has {stats2[0]} hp, {stats2[1]} mana, {stats2[2]} DMG
        """);

int[] hpMana = SpecialAttack(stats2[2], stats2[1], stats1[0]);
stats1[0] = hpMana[0];
stats2[1] = hpMana[1];
Console.WriteLine($"""
        char 1 has {stats1[0]} hp, {stats1[1]} mana, {stats1[2]} DMG
        char 2 has {stats2[0]} hp, {stats2[1]} mana, {stats2[2]} DMG
        """);
hpMana = SpecialAttack(stats2[2], stats2[1], stats1[0]);
stats1[0] = hpMana[0];
stats2[1] = hpMana[1];
Console.WriteLine($"""
        char 1 has {stats1[0]} hp, {stats1[1]} mana, {stats1[2]} DMG
        char 2 has {stats2[0]} hp, {stats2[1]} mana, {stats2[2]} DMG
        """);


//TODO: Fix gmaeloop


// METODER // 

static List<int> AddToStat(List<int> stats)
{
    stats.Add(100);
    for (var i = 0; i < 2; i++)
    {
        stats.Add(Random.Shared.Next(20, 81));
    }
    return stats;
}


static int standardAttack(int damageAttacker, int hpDefender)
{
    int chance = Random.Shared.Next(100);
    if (chance < 67)
    {
        hpDefender -= damageAttacker / 6;
        Console.WriteLine("Reg hit");
    }
    else
    {
        hpDefender -= damageAttacker;
        Console.WriteLine("Crit hit");
    }

    return hpDefender;
}

static int[] SpecialAttack(int damageAttacker, int manaAttacker, int hpDefender)
{
    if (manaAttacker - 20 < 0) Console.WriteLine("You are to low on mana, Special attack is not available");
    else
    {
        hpDefender = (int)(hpDefender - 0.25 * damageAttacker);
        manaAttacker -= 20;
        Console.WriteLine("Special attack");
    }
    int[] returnArray = [hpDefender, manaAttacker];

    return returnArray;
}

/*
    TODO FIX game loop in seperate method 
        Start with user interaction
        After let AI hit back with random choice
        If time: Make Ai more clever choice
*/