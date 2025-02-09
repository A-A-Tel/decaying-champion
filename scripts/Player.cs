using Godot;

namespace DecayingChampion.scripts;

public partial class Player : Entity
{
    protected override float Speed { get; set; } = 335f;
    
    public override void _Ready()
    {
        ResetValues();
        Sprite = GetNode<Sprite2D>("Sprite2D");
        AnimationTimer = GetNode<Timer>("AnimationTimer");
        AnimationCount = 2;
        CalculateTextureCount();
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

    public void ResetValues()
    {
        Health = MaxHealth;
    }
}