namespace DecayingChampion.scripts;

using Godot;
using System;

public partial class EnemyAura : Area2D
{
	private Enemy _enemy;
	public override void _Ready()
	{
		_enemy = GetNode<Enemy>("../");
	}

	public override void _Process(double delta)
	{
		CheckObjs();
	}

	private void CheckObjs()
	{
		foreach (var node in GetOverlappingBodies())
		{
			switch (node)
			{
				case ThrowProjectile proj:
					proj.DeleteThis();
					_enemy.HitByProjectile(proj);
					break;
				case Player:
					_enemy.HitByPlayer();
					break;
			}
		}
	}
}
