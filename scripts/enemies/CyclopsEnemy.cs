using Godot;

namespace DecayingChampion.scripts;

public partial class CyclopsEnemy : Boss
{
    public override short MaxHealth => 8000;
	
    protected override float Speed => 160f;
    protected override short Damage => 250;

    private byte _phase;

    protected override void BossReady()
    {
        
    }

    public override void TerminateChild()
    {
        if (_phase > 1)
        {
            base.TerminateChild();
        }
        else
        {
            _phase++;
            NextPhase();
        }
    }

    private async void NextPhase()
    {
        Sprite2D scene = ResourceLoader.Load<PackedScene>("res://scenes/DeadCyclops.tscn").Instantiate<Sprite2D>();
        scene.GlobalPosition = GlobalPosition;
        GetParent().AddChild(scene);
        QueueFree();
    }
}