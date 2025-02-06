namespace DecayingChampion.scripts;

using Godot;

public partial class Enemy : CharacterBody2D
{
	public float Health = 100f;
	
	
	protected virtual float Speed { get; set; } = 200f;
	protected virtual float Damage { get; set; } = 20f;
	protected virtual float AuraDamage { get; set; } = 5f;
	protected virtual bool TakeAuraDamage { get; set; } = true;
	
	private Vector2 _velocity;
	private Player _player;
	private Timer AuraTimer;
	
	public override void _Ready()
	{
		_player = GetNode<Player>("../Player");
		AuraTimer = GetNode<Timer>("AuraTimer");
	}
	
	public override void _PhysicsProcess(double delta)
	{
		Move();

		Velocity = _velocity;
		MoveAndSlide();
		CheckIfDead();
	}

	private void Move()
	{
		var direction = (_player.GlobalPosition - GlobalPosition).Normalized();
		_velocity = direction * Speed;
	}

	public void HitByProjectile(ThrowProjectile proj)
	{
		Health -= proj.damage;
	}

	public void HitByPlayer()
	{
		if (AuraTimer.IsStopped())
		{
			if (TakeAuraDamage) Health -= _player.AuraDamage;
			_player.DealDamage((byte) AuraDamage);
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
