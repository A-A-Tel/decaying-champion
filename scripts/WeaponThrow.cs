using Godot;

namespace DecayingChampion.scripts;

public partial class WeaponThrow : Sprite2D
{
    
    public override void _Process(double delta)
    {
        SetRotation();
        ShootThrow();
    }

    private void SetRotation()
    {
        LookAt(GetGlobalMousePosition());
        Rotation += 1.5708f;
    }

    private void ShootThrow()
    {   
        if (Input.IsMouseButtonPressed(MouseButton.Left))
        {
            var scene = ResourceLoader.Load<PackedScene>("res://scenes/ThrowProjectile.tscn");
            var projectile = scene.Instantiate<StaticBody2D>();
            
            projectile.Rotation = Rotation;
            projectile.Position = GlobalPosition;
            
            GetTree().Root.AddChild(projectile);
        }
    }
}