using Godot;

namespace DecayingChampion.scripts;

public partial class Player : Entity
{
    protected override float Speed { get; set; } = 335f;
    
    public override void _Ready()
    {
        ResetValues();
    }

    protected override void Move()
    {
        Velocity = Vector2.Zero;
        
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
        
        Velocity = Velocity.Normalized() * Speed;
    }

    public void ResetValues()
    {
        Health = MaxHealth;
    }
}