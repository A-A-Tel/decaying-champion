namespace DecayingChampion.scripts;

using Godot;

public partial class WeaponThrow : Sprite2D
{
	
	private Timer _cooldown;
	
	public override void _Process(double delta)
	{
		SetRotation();
		ShootThrow();
		_cooldown = GetNode<Timer>("Cooldown");
	}

	private void SetRotation()
	{
		LookAt(GetGlobalMousePosition());
		Rotation += 1.5708f;
	}

	private void ShootThrow()
	{   
		if (Input.IsMouseButtonPressed(MouseButton.Left) && _cooldown.IsStopped())
		{
			var scene = ResourceLoader.Load<PackedScene>("res://scenes/ThrowProjectile.tscn");
			var projectile = scene.Instantiate<StaticBody2D>();
			
			projectile.Rotation = Rotation;
			projectile.Position = GlobalPosition;
			
			GetTree().Root.AddChild(projectile);
			_cooldown.Start();
		}
	}
}
