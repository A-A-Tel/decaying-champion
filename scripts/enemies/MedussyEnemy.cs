using Godot;

namespace DecayingChampion.scripts;

public partial class MedussyEnemy : Boss
{
	//Canonically baddest B in the game//  TODO: Fuck Medusa
    public override short MaxHealth => 7500;
	
    protected override float Speed => 250f;
    protected override short Damage => 90;

    private Timer _spawnTimer;

    private Enemy _minion;
    
    protected override void BossProcess()
    {
	    if (_spawnTimer.IsStopped())
	    {
		    Enemy enemy = (Enemy) _minion.Duplicate();
		    enemy.GlobalPosition = GlobalPosition;
		    GetParent().AddChild(enemy);
		    _spawnTimer.Start();
	    } 
    }

    protected override void BossReady()
    {
	    _spawnTimer = GetNode<Timer>("SpawnTimer");
	    _minion = ResourceLoader.Load<PackedScene>("res://scenes/LemureEnemy.tscn").Instantiate<LemureEnemy>();
    }
}