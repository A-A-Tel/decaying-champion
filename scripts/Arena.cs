using Godot;

namespace DecayingChampion.scripts;

public partial class Arena : Node2D
{
	public byte Round { get; private set; }
	public byte Wave { get; private set; }
	public bool HasStarted { get; private set; }

	private Vector2 _playerSpawn = new(0f, 1015f);
	private Vector2[] _enemySpawns;

	private Enemy[][] _enemyGroups;
	private Boss[][] _bossGroups;
	
	private Timer _waveTimer;

	public override void _Ready()
	{
		_waveTimer = GetNode<Timer>("WaveTimer");
	}
	
	public override void _Process(double delta)
	{	
	}

	public void StartRound()
	{
		if (!HasStarted)
		{
			Round++;
			HasStarted = true;
		}
	}

	private void SpawnEnemies()
	{
		
	}

	private void SkipWave()
	{
		
	}
}
