using Godot;

namespace DecayingChampion.scripts;

public partial class Arena : StaticBody2D
{
	public byte Round { get; private set; }
	public byte Wave { get; private set; }
	public bool HasStarted { get; private set; }

	private Vector2 _playerSpawn = new(0f, 1015f);

	private Vector2[] _enemySpawns =
	{
		new(-861, -635),
		new(-533, -807),
		new(550, -807),
		new(994, -610),
		new(1227, -280),
		new(1226, 398),
		new(961, 711),
		new(522, 890),
		new(-479, 959),
		new(-865, 774),
		new(-1201, 492),
		new(-1169, -340)
	};
	
	private Timer _waveTimer;

	public override void _Ready()
	{
		_waveTimer = GetNode<Timer>("WaveTimer");
		StartRound();
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
