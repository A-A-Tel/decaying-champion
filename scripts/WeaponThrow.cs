using Godot;

namespace DecayingChampion.scripts;

public partial class WeaponThrow : Sprite2D
{
    public override void _Process(double delta)
    {
        var mouseVector = GetLocalMousePosition();
        var angle = Mathf.Atan2(mouseVector.Y, mouseVector.X);
        
        Rotation = angle;
    }
}