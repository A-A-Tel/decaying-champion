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

	private bool _hasPaused;

	private readonly Vector2[] _enemySpawns =
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
	private Player _player;
	private Prison _prison;


	public override void _Ready()
	{
		_player = GetNode<Player>("Player");
		_waveTimer = GetNode<Timer>("WaveTimer");
		_killZone = GetNode<Area2D>("KillZone");
		_prison = ResourceLoader.Load<PackedScene>("res://scenes/Prison.tscn").Instantiate<Prison>();
		_prison.Arena = this;
		
		StartRound();
	}

	public override void _Process(double delta)
	{
		if (_hasPaused) return;
		if (Wave > 4)
		{
			HasStarted = false;
			if (IsEverythingDead())
			{
				if (Round % 3 != 0)
				{
					_player.ResetValues();
					StartRound();
				}
				else
				{
					_hasPaused = true;
					AddChild(_prison);
					_prison.MoveToFront();
					_prison.Enter();
				}
			}
		}

		if (HasStarted)
		{
			if (IsEverythingDead())
			{
				Wave++;
				SpawnWave(_round[Wave]);
			}
		}

		KillEntities();
	}

	public void StartRound()
	{
		Wave = 0;
		_round = EnemyRounds.GetRound(Round);
		Round++;
		HasStarted = true;
		SpawnWave(_round[Wave]);
	}

	public void Resume()
	{
		_hasPaused = false;
		StartRound();
		_player.ResetValues();
		RemoveChild(_prison);
	}

	private void SpawnWave(EnemyRounds.EnemyData[] wave)
	{
		Random rnd = new();

		foreach (EnemyRounds.EnemyData enemyData in wave)
		{
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

	private void TerminateChildScenes()
	{
	}
}
