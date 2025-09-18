

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
/* stats2[0] = standardAttack(stats1[2], stats2[0]);

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
 */

int choice = chooseCharachter();
List<int> mainCharacter;
List<int> enemy;
if (choice == 1)
{
    mainCharacter = stats1;
    enemy = stats2;
}
else
{
    mainCharacter = stats2;
    enemy = stats1;
}

startGame(mainCharacter, enemy);


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


static int chooseCharachter()
{
    int choice;
    bool correct = false;
    do
    {
        Console.WriteLine("Do you want to play as character 1 or character 2");
        string ans = Console.ReadLine();
        choice = 0;
        try
        {
            int.TryParse(ans, out choice);
        }
        catch (Exception e)
        {
            choice = -1;
        }

        switch (choice)
        {
            case 1:
            case 2:
                correct = true;
                break;
            default:
                Console.WriteLine("That choice is not valid ");
                correct = false;
                break;
        }
    } while (!correct);
    Console.WriteLine($"You chose character {choice}");
    return choice;
}


static void startGame(List<int> mainCharacter, List<int> enemy)
{
    Console.WriteLine("FIGHT START");
    while (mainCharacter[0] > 0 && enemy[0] > 0)
    {
        int NewHP = standardAttack(mainCharacter[2], enemy[0]);
        enemy[0] = NewHP;
        Console.WriteLine($"Enemy now has {enemy[0]}");

        NewHP = standardAttack(enemy[2], mainCharacter[0]);
        enemy[0] = NewHP;
        Console.WriteLine($"you now has {mainCharacter[0]}");
    }

}

//TODO CHOSE attack randomy enemy

/*
    TODO FIX game loop in seperate method 
        Start with user interaction
        After let AI hit back with random choice
        If time: Make Ai more clever choice
*/