using Godot;

namespace DecayingChampion.scripts;

public partial class Enemy : Entity
{
	private Player _player;
	private Timer _damageTimer;
	protected virtual short Damage => 100;
	protected virtual bool HasSound => false;

	private Area2D _aura;
	private AudioStreamPlayer2D _soundPlayer;


	public override void _Ready()
	{
		if (HasSound) _soundPlayer = GetNode<AudioStreamPlayer2D>("Audio");
		
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
		BossReady();
	}

	public override void _Process(double delta)
	{
		CheckForPlayer();
		BossProcess();
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
			if (HasSound) _soundPlayer.Play();
			_player.DealDamage(Damage);
			_damageTimer.Start();
		}
	}

	protected virtual void BossProcess()
	{
	}

	protected virtual void BossReady()
	{
		
	}

	private void GotHit(ArrowProjectile proj)
	{
		Health -= proj.Damage;
		proj.DeleteThis();
	}

	private void GotHit(SlashProjectile proj)
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
					GotHit(proj);
					break;
			}
		}
	}

	protected override void CheckOverlap(KinematicCollision2D collision, float delta)
	{
		if (collision != null)
		{
			if (collision.GetCollider() is Node2D other && other.IsInGroup("enemies")) // Check if it's another enemy
			{
				Vector2 pushDirection = (Position - other.Position).Normalized();
				MoveAndCollide(pushDirection * 10f * delta);
			}
		}
	}
	
}
