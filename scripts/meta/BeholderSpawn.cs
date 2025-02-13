using Godot;

namespace DecayingChampion.scripts;

public partial class BeholderSpawn : Sprite2D
{
    private int _increment;
    private Timer _animationTimer;
    private byte _currentAnimation;

    public override void _Ready()
    {
        _increment = 80;
        _animationTimer = GetNode<Timer>("AnimationTimer");
    }
    
    public override void _Process(double delta)
    {
        if (_currentAnimation != 15 && _animationTimer.IsStopped())
        {
            _currentAnimation++;
            RegionRect = new Rect2(RegionRect.Position.X + _increment, RegionRect.Position.Y, RegionRect.Size);
            _animationTimer.Start();
        } else if (_currentAnimation == 15)
        {
            RegionRect = new Rect2(2560, 0, 80, 80);
        }
    }
}