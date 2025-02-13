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
    
    private static readonly Enemy Snake =
        ResourceLoader.Load<PackedScene>("res://scenes/SnakeEnemy.tscn").Instantiate<SnakeEnemy>();

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
        },
        
        //Round 2//
        
        new[]
        {
            new[]
            {
                new EnemyData(Lion, 5),
                new EnemyData(Lemure, 10),
                new EnemyData(Lioness, 5)
            },
            new[]
            {
                new EnemyData(Lemure, 15),
                new EnemyData(Lioness, 8)
            },
            new[]
            {
                new EnemyData(Lion, 12),
                new EnemyData(Lemure, 20)
            },
            new[]
            {
                new EnemyData(Lion, 10),
                new EnemyData(Lemure, 15),
                new EnemyData(Lioness, 10)
            },
            new[]
            {
                new EnemyData(Lion, 8),
                new EnemyData(Lemure, 15),
                new EnemyData(Lioness, 13)
            }
        },
        
        //Round 3//
        
        new[]
        {
            new[]
            {
            new EnemyData(Lion, 11),
            new EnemyData(Lemure, 20),
            new EnemyData(Lioness, 11)
            },
            new[]
            {
                new EnemyData(Lion, 12),
                new EnemyData(Lemure, 25),
                new EnemyData(Lioness, 11)
            },
            new[]
            {
                new EnemyData(Lion, 12),
                new EnemyData(Lemure, 30),
                new EnemyData(Lioness, 12)
            },
            new[]
            {
                new EnemyData(Lion, 13),
                new EnemyData(Lemure, 32),
                new EnemyData(Lioness, 12)
            },
            new[]
            {
                new EnemyData(Lion, 13),
                new EnemyData(Lemure, 35),
                new EnemyData(Lioness, 13)
            }
        },
        
        //Round 4//
        
        new[]
        {
            new[]
            {
                new EnemyData(Lion, 14),
                new EnemyData(Lemure, 37),
                new EnemyData(Lioness, 13)
            },
            new[]
            {
                new EnemyData(Lion, 14),
                new EnemyData(Lemure, 40),
                new EnemyData(Lioness, 14)
            },
            new[]
            {
                new EnemyData(Lion, 15),
                new EnemyData(Lemure, 42),
                new EnemyData(Lioness, 14)
            },
            new[]
            {
                new EnemyData(Lion, 15),
                new EnemyData(Lemure, 45),
                new EnemyData(Lioness, 15)
            },
            new[]
            {
                new EnemyData(Lion, 16),
                new EnemyData(Lemure, 50),
                new EnemyData(Lioness, 16)
            }
        },
        
        //Round 5//
        
        new[]
        {
            new[]
            {
                new EnemyData(Lion, 18),
                new EnemyData(Lioness, 18)
            },
            new[]
            {
                new EnemyData(Lemure, 150),
            },
            new[]
            {
                new EnemyData(Lion, 40)
            },
            new[]
            {
                new EnemyData(Lioness, 30)
            },
            new[]
            {
                new EnemyData(Medussy, 1),
                new EnemyData(Snake, 20)
            }
        },
        
        //Round 6//
        
        new[]
        {
            new[]
            {
                new EnemyData(Lion, 20),
                new EnemyData(Lioness, 20)
            },
            new[]
            {
                new EnemyData(Lemure, 150),
                new EnemyData(Lion, 20),
                new EnemyData(Lioness, 20)
            },
            new[]
            {
                new EnemyData(Lemure, 150),
                new EnemyData(Lioness, 10),
                new EnemyData(Lion, 40)
            },
            new[]
            {
                new EnemyData(Lemure, 150),
                new EnemyData(Lion, 10),
                new EnemyData(Lioness, 30)
            },
            new[]
            {
                new EnemyData(Lion, 50),
                new EnemyData(Snake, 20)
            }
        },
        
        //Round 7//
        
        new[]
        {
            new[]
            {
                new EnemyData(Lion, 50),
                new EnemyData(Lioness, 20)
            },
            new[]
            {
                new EnemyData(Lemure, 500)
            },
            new[]
            {
                new EnemyData(Lion, 100)
            },
            new[]
            {
                new EnemyData(Lioness, 100)
            },
            new[]
            {
                new EnemyData(Lion, 50),
                new EnemyData(Snake, 200)
            }
        },
        
        //Round 8//
        
        new[]
        {
            new[]
            {
                new EnemyData(Lion, 60),
                new EnemyData(Lioness, 30)
            },
            new[]
            {
                new EnemyData(Snake, 300)
            },
            new[]
            {
                new EnemyData(Lion, 200)
            },
            new[]
            {
                new EnemyData(Lioness, 200)
            },
            new[]
            {
                new EnemyData(Lion, 100),
                new EnemyData(Lioness, 100)
            }
        },
        
        //Round 9//
        
        new[]
        {
            new[]
            {
                new EnemyData(Medussy, 1),
                new EnemyData(Lemure, 300)
            },
            new[]
            {
                new EnemyData(Medussy, 1),
                new EnemyData(Snake, 300)
            },
            new[]
            {
                new EnemyData(Medussy, 1),
                new EnemyData(Lioness, 50)
            },
            new[]
            {
                new EnemyData(Medussy, 1),
                new EnemyData(Lion, 60)
            },
            new[]
            {
                new EnemyData(Medussy, 3)
            }
        },
        
        //Round 10//
        
        new[]
        {
            new[]
            {
                new EnemyData(Medussy, 1),
                new EnemyData(Lion, 50),
                new EnemyData(Lioness, 50)
            },
            new[]
            {
                new EnemyData(Medussy, 1),
                new EnemyData(Snake, 300),
                new EnemyData(Lion, 70)
            },
            new[]
            {
                new EnemyData(Medussy, 1),
                new EnemyData(Lioness, 70),
                new EnemyData(Lion, 60)
            },
            new[]
            {
                new EnemyData(Medussy, 1),
                new EnemyData(Lion, 100),
                new EnemyData(Lioness, 100),
                new EnemyData(Lemure, 200),
                new EnemyData(Snake, 200)
            },
            new[]
            {
                new EnemyData(Medussy, 10)
            }
        },
    };

    public static EnemyData[][] GetRound(short round)
    {
        return EnemyGroups[round];
    }
}