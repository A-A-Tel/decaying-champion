using Godot;

namespace DecayingChampion.scripts;

public partial class Entity : CharacterBody2D
{
    public short Health { get; protected set; } = 100;
    public short MaxHealth { get; protected set; } = 100;
    public short Damage { get; protected set; } = 100;
    
    protected virtual float Speed { get; set; } = 100f;
    protected byte Animation = 0;
    protected bool AnimationFrame = false;
    protected bool IsMoving = false;

    protected Sprite2D Sprite;
    protected Timer AnimationTimer;

    public override void _PhysicsProcess(double delta)
    {
        CheckIfDead();
        Move();
        SetAnimation();
        PlayAnimation();
        MoveAndCollide(Velocity * (float)delta);
    }

    protected virtual void CheckIfDead()
    {
        if (Health <= 0)
        {
            GetParent().RemoveChild(this);
            QueueFree();
        }
    }
    
    protected virtual void Move() {}

    protected virtual void SetAnimation() {}

    protected virtual void PlayAnimation() {}
}