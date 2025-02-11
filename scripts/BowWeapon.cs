using Godot;

namespace DecayingChampion.scripts;

public partial class BowWeapon : Weapon
{
	protected override short Damage => 65;

	protected override void UseWeapon()
	{
		Projectile proj = ResourceLoader.Load<PackedScene>("res://scenes/ArrowProjectile.tscn").Instantiate<StaticBody2D>() as Projectile;
		
		proj.Damage = Damage;
		proj.GlobalRotation = GlobalRotation;
		proj.GlobalPosition = GlobalPosition + Transform.Y * (Offset.Y / 1.5f) * Scale.Y;
		
		CooldownTimer.Start();
		GetParent().GetParent().AddChild(proj);
	}
}
