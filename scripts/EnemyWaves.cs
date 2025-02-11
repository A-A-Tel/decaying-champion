using Godot;

namespace DecayingChampion.scripts;

public static class EnemyWaves
{

    public record EnemyWave(PackedScene enemy, short amount);
    
    private static readonly PackedScene Lemure = ResourceLoader.Load<PackedScene>("res://scenes/LemureEnemy.tscn");

    private static readonly EnemyWave[][] EnemyGroups =
    {
        new[]
        {
            new EnemyWave(Lemure, 10)
        }
    };

    public static EnemyWave[] GetRound(short round)
    {
        return EnemyGroups[round];
    }
}