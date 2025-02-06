namespace DecayingChampion.scripts;

using Godot;

public partial class Enemy : CharacterBody2D
{
	public float Health = 100f;
	
	protected Player Player;
	
	protected Timer AuraTimer;
	
	protected float Speed = 200f;
	protected float Damage = 20f;
	protected float AuraDamage = 5f;
	
	private Vector2 _velocity;
	
	public override void _Ready()
	{
		Player = GetNode<Player>("../Player");
		AuraTimer = GetNode<Timer>("AuraTimer");
	}
	
	public override void _PhysicsProcess(double delta)
	{
		Move();

		Velocity = _velocity;
		MoveAndSlide();
		CheckIfDead();
	}

	protected virtual void Move()
	{
		var direction = (Player.GlobalPosition - GlobalPosition).Normalized();
		_velocity = direction * Speed;
	}

	public virtual void HitByProjectile(ThrowProjectile proj)
	{
		Health -= proj.damage;
	}

	public void HitByPlayer()
	{
		if (AuraTimer.IsStopped())
		{
			Health -= Player.AuraDamage;
			Player.DealDamage((byte) AuraDamage);
			AuraTimer.Start();
		}
	}

	private void CheckIfDead()
	{
		if (Health <= 0)
		{
			QueueFree();
		}
	}
}
