using Godot;

namespace DecayingChampion.scripts;

public static class EnemyRounds
{
    public record EnemyData(Enemy Enemy, short Amount);

    private static readonly Enemy Lemure = ResourceLoader.Load<PackedScene>("res://scenes/LemureEnemy.tscn")
        .Instantiate<LemureEnemy>();

    private static readonly Enemy Lion = ResourceLoader.Load<PackedScene>("res://scenes/LionEnemy.tscn")
        .Instantiate<LionEnemy>();

    private static readonly Enemy Lioness =
        ResourceLoader.Load<PackedScene>("res://scenes/LionessEnemy.tscn").Instantiate<LionessEnemy>();
    
    private static readonly Enemy Medussy =
        ResourceLoader.Load<PackedScene>("res://scenes/MedussyEnemy.tscn").Instantiate<MedussyEnemy>();
    
    private static readonly Enemy Cyclops =
        ResourceLoader.Load<PackedScene>("res://scenes/CyclopsEnemy.tscn").Instantiate<CyclopsEnemy>();

    private static readonly EnemyData[][][] EnemyGroups =
    {
        new[]
        {
            new[]
            {
                new EnemyData(Lemure, 15)
            },
            new[]
            {
                new EnemyData(Lemure, 10),
                new EnemyData(Lion, 3)
            },
            new[]
            {
                new EnemyData(Lemure, 10),
                new EnemyData(Lioness, 3)
            },
            new[]
            {
                new EnemyData(Lemure, 15),
                new EnemyData(Lion, 4),
                new EnemyData(Lioness, 4)
            },
            new[] 
            {
                new EnemyData(Lion, 10)
            }
        }
    };

    public static EnemyData[][] GetRound(short round)
    {
        return EnemyGroups[round];
    }
}