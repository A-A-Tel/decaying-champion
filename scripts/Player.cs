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
    }

    protected override void Move()
    {
        Velocity = Vector2.Zero;
        IsMoving = false;

        var up = false;
        var left = false;
        Animation = 0;
        
        if (Input.IsActionPressed("MoveUp"))
        {
            Velocity += Vector2.Up;
            Animation += 4;
            up = true;
        }

        if (Input.IsActionPressed("MoveLeft"))
        {
            Velocity += Vector2.Left;
            Animation += 2;
            left = true;
        }

        if (Input.IsActionPressed("MoveDown"))
        {
            Velocity += Vector2.Down;
            if (up) Animation -= 4; else Animation += 1;
        }

        if (Input.IsActionPressed("MoveRight"))
        {
            Velocity += Vector2.Right;
            if (left) Animation -= 2; else Animation += 7;
        }
        Velocity = Velocity.Normalized() * Speed;
    }

    public void ResetValues()
    {
        Health = MaxHealth;
    }

    protected override void SetAnimation()
    {
        if (Animation != 0)
        {
            IsMoving = true;
            Sprite.RegionRect = new Rect2(0f, 0f + (Animation - 1f) * 38f, 30f, 38f);
        }
        else
        {
            IsMoving = false;
        }
    }

    protected override void PlayAnimation()
    {
        if (!IsMoving)
        {
            AnimationFrame = false;
            Sprite.RegionRect = new Rect2(0f, Sprite.RegionRect.Position.Y, 30f, 38f);
            return; 
        }
        
            var xOffset = AnimationFrame ? 60f : 30f;
            Sprite.RegionRect = new Rect2(xOffset, Sprite.RegionRect.Position.Y, 30f, 38f);

        if (AnimationTimer.IsStopped())
        {
            AnimationFrame = !AnimationFrame;
            AnimationTimer.Start();
        }
    }
}