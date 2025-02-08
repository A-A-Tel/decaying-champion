using Godot;

namespace DecayingChampion.scripts;

public partial class Entity : CharacterBody2D
{
    public short Health { get; protected set; } = 100;
    public short MaxHealth { get; protected set; } = 100;
    public short Damage { get; protected set; } = 100;
    
    protected virtual float Speed { get; set; } = 100f;

    public override void _PhysicsProcess(double delta)
    {
        Move();
        MoveAndCollide(Velocity * (float)delta);
        CheckIfDead();
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
}