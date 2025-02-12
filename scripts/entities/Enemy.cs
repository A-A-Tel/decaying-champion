using Godot;

namespace DecayingChampion.scripts;

public partial class Enemy : Entity
{
	private Player _player;
	private Timer _damageTimer;
	protected virtual short Damage => 100;

	private Area2D _aura;


	public override void _Ready()
	{
		if (HasAnimation)
		{
			Sprite = GetNode<Sprite2D>("Sprite2D");
			AnimationTimer = GetNode<Timer>("AnimationTimer");
			CalculateTextureCount();
		}

		_player = GetNode("../Player") as Player;
		_aura = GetNode<Area2D>("Aura");
		_damageTimer = GetNode<Timer>("DamageTimer");
		Health = MaxHealth;
	}

	public override void _Process(double delta)
	{
		CheckForPlayer();
	}

	protected override void Move()
	{
		IsMoving = true;
		Velocity = (_player.GlobalPosition - GlobalPosition).Normalized() * Speed;
	}

	protected virtual void Attack()
	{
		if (_damageTimer.IsStopped())
		{
			_player.DealDamage(Damage);
			_damageTimer.Start();
		}
	}

	private void GotHit(Projectile proj)
	{
		Health -= proj.Damage;
		proj.DeleteThis();
	}

	private void SwordHit(Projectile proj)
	{
		Health -= proj.Damage;
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
				case ArrowProjectile proj:
					GotHit(proj);
					break;
				case SlashProjectile proj:
					SwordHit(proj);
					break;
			}
		}
	}

	protected override void CheckOverlap(KinematicCollision2D collision, float delta)
	{
		if (collision != null)
		{
			Node2D other = collision.GetCollider() as Node2D;

			if (other != null && other.IsInGroup("enemies"))
			{
				Velocity = other.GlobalPosition - GlobalPosition;
				MoveAndSlide();
			}
		}
	}
}
