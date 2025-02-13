using Godot;

namespace DecayingChampion.scripts;

public partial class Projectile : StaticBody2D
{
	public short Damage;
	
	protected virtual float Speed => 0;
		
	private Timer _despawnTimer;

	private bool _isDeleted;
	
	public override void _Ready()
	{
		_despawnTimer = GetNode<Timer>("DespawnTimer");
		Damage = (short) (Damage * DebuffManager.GetDebuff(Debuffs.Damage));
	}

	public override void _PhysicsProcess(double delta)
	{
		Move((float)delta);
		Despawn();
	}

	public void DeleteThis()
	{
		_isDeleted = true;
		GetParent().RemoveChild(this);
		QueueFree();
	}

	protected virtual void Move(float delta)
	{
		Position += -Transform.Y * Speed * delta;
	}

	protected virtual void Despawn()
	{
		if (_despawnTimer.IsStopped() && !_isDeleted) DeleteThis();
	}
}
