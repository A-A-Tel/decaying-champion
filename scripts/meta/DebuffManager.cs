using System;

namespace DecayingChampion.scripts;

public static class DebuffManager
{
    private static readonly double[] DebuffValues = { 1, 1, 1, 1, 1 };

    public static double GetDebuff(Debuffs debuff)
    {
        return DebuffValues[(int)debuff];
    }

    public static void SetDebuff(Debuffs debuff)
    {
        DebuffValues[(int)debuff] = debuff switch
        {
            Debuffs.Damage => 0.5,
            Debuffs.Arrow => 1.5,
            Debuffs.Sword => 1.7,
            Debuffs.Health => 0.5,
            Debuffs.Move => 0.8,
            _ => DebuffValues[(int)debuff]
        };
    }
}

public enum Debuffs
{
    Damage,
    Arrow,
    Sword,
    Health,
    Move
}