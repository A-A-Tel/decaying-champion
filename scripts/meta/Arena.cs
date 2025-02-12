using System;
using System.Threading;
using Godot;
using Timer = Godot.Timer;

namespace DecayingChampion.scripts;

public partial class Arena : StaticBody2D
{
	public byte Round { get; private set; }
	public byte Wave { get; private set; }
	public bool HasStarted { get; private set; }

	private byte _waveNum;

	private Vector2 _playerSpawn = new(0f, 1015f);

	private Vector2[] _enemySpawns =
	{
		new(-835, -616),
		new(-515, -780),
		new(529, -780),
		new(963, -590),
		new(1196, -265),
		new(1196, 378),
		new(936, 687),
		new(505, 865),
		new(-460, 932),
		new(-835, 752),
		new(-1169, 474),
		new(-1140, -326)
	};

	private Timer _waveTimer;
	private EnemyRounds.EnemyData[][] _round;
	private Area2D _killZone;


	public override void _Ready()
	{
		_waveTimer = GetNode<Timer>("WaveTimer");
		_killZone = GetNode<Area2D>("KillZone");
		StartRound();
	}

	public override void _Process(double delta)
	{
		if (_waveNum > 4) HasStarted = false;
		if (HasStarted)
		{
			if (IsEverythingDead())
			{
				SpawnWave(_round[_waveNum]);
				_waveNum++;
			}
		}
		KillEntities();
	}

	public void StartRound()
	{
		_round = EnemyRounds.GetRound(Round);
		Round++;
		HasStarted = true;
	}

	private void SpawnWave(EnemyRounds.EnemyData[] wave)
	{
		Random rnd = new();

		foreach (EnemyRounds.EnemyData enemyData in wave)
		{
			GD.Print(enemyData.Enemy.Name);
			enemyData.Enemy.AddToGroup("enemies");

			for (short i = 0; i < enemyData.Amount; i++)
			{
				enemyData.Enemy.Position = _enemySpawns[rnd.Next(_enemySpawns.Length)];
				AddChild(enemyData.Enemy.Duplicate());
			}
		}

		if (_waveTimer.IsStopped())
		{
			_waveTimer.Start();
		}
		else
		{
			_waveTimer.Stop();
			_waveTimer.Start();
		}
	}

	private bool IsEverythingDead()
	{
		foreach (Node node in GetChildren())
		{
			if (node.IsInGroup("enemies")) return false;
		}

		return true;
	}

	private void KillEntities()
	{
		foreach (Node2D node in _killZone.GetOverlappingBodies())
		{
			if (node is Entity entity)
			{
				entity.TerminateChild();
			}
		}
	}
}
