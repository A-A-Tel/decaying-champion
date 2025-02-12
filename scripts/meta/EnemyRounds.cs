using Godot;

namespace DecayingChampion.scripts;

public static class EnemyRounds
{
    public record EnemyWave(Enemy Enemy, short Amount);

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

    private static readonly EnemyWave[][][] EnemyGroups =
    {
        new[]
        {
            new[]
            {
                new EnemyWave(Lemure, 15),
            }, 
            new[]
            {
                new EnemyWave(Lion, 4),
                new EnemyWave(Lioness, 2)
            },
            new[]
            {
                new EnemyWave(Medussy, 1),
            },
            new[]
            {
                new EnemyWave(Cyclops, 1)
            }
        }
    };

    public static EnemyWave[][] GetRound(short round)
    {
        return EnemyGroups[round];
    }
}