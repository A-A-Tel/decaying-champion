using Godot;

namespace DecayingChampion.scripts;

public static class EnemyRounds
{

    public record EnemyWave(Enemy enemy, short amount);
    
    private static readonly Enemy Lemure = ResourceLoader.Load<PackedScene>("res://scenes/LemureEnemy.tscn").Instantiate<LemureEnemy>();
    private static readonly Enemy Lion = ResourceLoader.Load<PackedScene>("res://scenes/LionEnemy.tscn").Instantiate<LemureEnemy>();
    private static readonly Enemy Lioness = ResourceLoader.Load<PackedScene>("res://scenes/LionessEnemy.tscn").Instantiate<LemureEnemy>();

    private static readonly EnemyWave[][] EnemyGroups =
    {
        new[]
        {
            new EnemyWave(Lemure, 10),
            new EnemyWave(Lion, 2),
            new EnemyWave(Lioness, 1)
        }
    };

    public static EnemyWave[] GetRound(short round)
    {
        return EnemyGroups[round];
    }
}