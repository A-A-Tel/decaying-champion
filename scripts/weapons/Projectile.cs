using Godot;

namespace DecayingChampion.scripts;

public partial class Projectile : StaticBody2D
{
    public short Damage;
    
    protected virtual float Speed => 0;
        
    private Timer DespawnTimer;
    
    public override void _Ready()
    {
        DespawnTimer = GetNode<Timer>("DespawnTimer");
    }

    public override void _PhysicsProcess(double delta)
    {
        Move((float)delta);
        Despawn();
    }

    public void DeleteThis()
    {
        GetParent().RemoveChild(this);
        QueueFree();
    }

    protected virtual void Move(float delta)
    {
        Position += -Transform.Y * Speed * delta;
    }

    protected virtual void Despawn()
    {
        if (DespawnTimer.IsStopped()) DeleteThis();
    }
}