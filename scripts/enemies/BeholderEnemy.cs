using Godot;

namespace DecayingChampion.scripts;

public partial class BeholderEnemy : Boss
{
    public override short MaxHealth => 7600;
	
    protected override float Speed { get; set; } = 700f;
    protected override short Damage => 50;
	
    protected override bool HasAnimation => false;
    
    private Sprite2D _sprite;
    private Texture2D _texture;
    private Timer _spawnTimer;
    private bool _spawned;

    protected override void BossReady()
    {
	    Speed = 0;
	    _spawnTimer = GetNode<Timer>("SpawnTimer");
	    _sprite = GetNode<Sprite2D>("Sprite2D");
	    _texture = _sprite.Texture;
	    _sprite.Texture = null;
    }

    protected override void BossProcess()
    {
	    if (!_spawned && _spawnTimer.IsStopped())
	    {
		    _spawned = true;
		    _sprite.Texture = _texture;
		    Speed = 700f;
	    }
    }
}