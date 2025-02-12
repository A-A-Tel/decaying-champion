using System;
using Godot;

namespace DecayingChampion.scripts;

public partial class Player : Entity
{
    public override short MaxHealth { get; protected set; } = 9000;

    protected override float Speed { get; set; } = 350f * (float)DebuffManager.GetDebuff(Debuffs.Move);

    protected override bool HasWeapon => true;

    private byte _currentWeapon;

    private Weapon[] _weapons;

    private bool _healthDebuffed;
    private bool _speedDebuffed;
    

    public override void _Ready()
    {
        ResetValues();
        Sprite = GetNode<Sprite2D>("Sprite2D");
        AnimationTimer = GetNode<Timer>("AnimationTimer");
        CalculateTextureCount();

        _weapons = new[]
        {
            ResourceLoader.Load<PackedScene>("res://scenes/BowWeapon.tscn").Instantiate<Weapon>() as Weapon,
            ResourceLoader.Load<PackedScene>("res://scenes/SwordWeapon.tscn").Instantiate<Weapon>() as Weapon,
        };
    }

    protected override void Move()
    {
        Velocity = Vector2.Zero;
        IsMoving = false;

        if (Input.IsActionPressed("MoveUp"))
        {
            Velocity += Vector2.Up;
        }

        if (Input.IsActionPressed("MoveLeft"))
        {
            Velocity += Vector2.Left;
        }

        if (Input.IsActionPressed("MoveDown"))
        {
            Velocity += Vector2.Down;
        }

        if (Input.IsActionPressed("MoveRight"))
        {
            Velocity += Vector2.Right;
        }

        if (!Velocity.Equals(Vector2.Zero)) IsMoving = true;
        Velocity = Velocity.Normalized() * Speed;
    }

    protected override void ChangeWeapon()
    {
        if (Input.IsActionJustPressed("Weapon1"))
        {
            RemoveWeapon();
            AddChild(_weapons[0]);
        }

        if (Input.IsActionJustPressed("Weapon2"))
        {
            RemoveWeapon();
            AddChild(_weapons[1]);
        }
    }

    public void ResetValues()
    {
        double debuffHealth = DebuffManager.GetDebuff(Debuffs.Health);
        double debuffSpeed = DebuffManager.GetDebuff(Debuffs.Move);

        if (debuffHealth != 1 && !_healthDebuffed)
        {
            MaxHealth = (short)(MaxHealth * debuffHealth);
            _healthDebuffed = true;
        }

        if (debuffSpeed != 1 && !_speedDebuffed)
        {
            Speed *= (float)debuffSpeed;
            _speedDebuffed = true;
        }

        Health = MaxHealth;
    }

    public void DealDamage(short damage)
    {
        Health -= damage;
    }

    private void RemoveWeapon()
    {
        foreach (Node node in GetChildren())
        {
            if (node is Weapon weapon)
            {
                RemoveChild(weapon);
                break;
            }
        }
    }
}