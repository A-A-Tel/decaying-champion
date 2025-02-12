using Godot;

namespace DecayingChampion.scripts;

public partial class SwordWeapon : Weapon
{
    
    protected override short Damage => 80;

    protected override void UseWeapon()
    {
        if (!IsDebuffed) SetDebuff();
        Projectile proj = ResourceLoader.Load<PackedScene>("res://scenes/SlashProjectile.tscn").Instantiate<StaticBody2D>() as Projectile;
		
        proj.Damage = (short) (Damage * DebuffManager.GetDebuff(Debuffs.Damage));
        proj.GlobalRotation = GlobalRotation;
        proj.GlobalPosition = GlobalPosition + Transform.Y * (Offset.Y / 1.5f) * Scale.Y;
		
        CooldownTimer.Start();
        GetParent().GetParent().AddChild(proj);
    }

    protected override void SetDebuff()
    {
        double debuff = DebuffManager.GetDebuff(Debuffs.Sword);

        if (debuff != 1)
        {
            CooldownTimer.SetWaitTime(CooldownTimer.WaitTime * debuff);
            IsDebuffed = true;
        }
    }
}