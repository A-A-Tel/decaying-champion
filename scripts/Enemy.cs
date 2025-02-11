using System.Linq;
using Godot;

namespace DecayingChampion.scripts;

public partial class Enemy : Entity
{
	protected Player Player;
	protected Timer DamageTimer;
	protected virtual short Damage => 100;
	
	private Area2D _aura;
	
	protected virtual bool HasWeapon => false;

	public override void _Ready()
	{
		if (HasAnimation)
		{
			Sprite = GetNode<Sprite2D>("Sprite2D");
			AnimationTimer = GetNode<Timer>("AnimationTimer");
			CalculateTextureCount();
		}
		Player = GetNode("../Player") as Player;
		_aura = GetNode<Area2D>("Aura");
		DamageTimer = GetNode<Timer>("DamageTimer");
		Health = MaxHealth;
		
	}

	public override void _Process(double delta)
	{
		CheckForPlayer();
	}

	protected override void Move()
	{
		IsMoving = true;
		Velocity = (Player.GlobalPosition - GlobalPosition).Normalized() * Speed;
	}

	protected virtual void Attack()
	{
	}

	private void GotHit(Projectile proj)
	{
		Health -= proj.Damage;
		proj.DeleteThis();
	}

	private void CheckForPlayer()
	{
		foreach (Node2D node in _aura.GetOverlappingBodies())
		{
			switch (node)
			{
				case Player player:
					Attack();
					break;
				case Projectile proj:
					GotHit(proj);
					break;
			}
		}
	}
}
