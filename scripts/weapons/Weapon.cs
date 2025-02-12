using Godot;

namespace DecayingChampion.scripts;

public partial class Weapon : Sprite2D
{
	protected virtual short Damage => 10;
	protected bool IsRanged;
	protected Player Player;
	protected Timer CooldownTimer;
	protected bool IsDebuffed;

	public override void _Ready()
	{
		Player = GetNode<Player>("../");
		CooldownTimer = GetNode<Timer>("CooldownTimer");
		
	}

	public override void _Process(double delta)
	{
		LookAt(GetGlobalMousePosition());
		Rotation += 1.5708f;
		
		Vector2 texture = GetTexture().GetSize();
		if (CooldownTimer.IsStopped())
		{
			RegionRect = new Rect2(texture.X / 2, 0, texture.X / 2, texture.Y);
			
			if (Input.IsActionJustPressed("WeaponUse")) UseWeapon();
		}
		else
		{
			RegionRect = new Rect2(0, 0, texture.X / 2, texture.Y);
		}
	}

	protected virtual void UseWeapon()
	{
		
	}

	protected virtual void SetDebuff()
	{
		
	}
}
