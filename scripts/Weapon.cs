using Godot;

namespace DecayingChampion.scripts;

public partial class Weapon : Sprite2D
{
	protected virtual short Damage => 10;
	protected bool IsRanged;
	protected Player Player;
	protected Timer CooldownTimer;

	public override void _Ready()
	{
		Player = GetNode<Player>("../");
		CooldownTimer = GetNode<Timer>("CooldownTimer");
		
	}
	
	public override void _Process(double delta)
	{
		LookAt(GetGlobalMousePosition());
		Rotation += 1.5708f;
		if (Input.IsActionJustPressed("WeaponUse") && CooldownTimer.IsStopped()) UseWeapon();
	}

	protected virtual void UseWeapon()
	{
		
	}
}
