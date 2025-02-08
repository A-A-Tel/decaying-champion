using System;
using System.Threading.Tasks;
using Godot;

namespace DecayingChampion.scripts;

public partial class ThrowProjectile : StaticBody2D
{
	public float damage = 20;
	
	private const float Speed = 900f;
	
	private bool deleted = false;
	
	public override void _Ready()
	{
		SetDespawnTimer();
	}

	public override void _Process(double delta)
	{
		Position += -Transform.Y * Speed * (float)delta;
	}
	
	private async void SetDespawnTimer() {
		try
		{
			await Task.Delay(TimeSpan.FromMilliseconds(470));
			if (!deleted) QueueFree();
		}
		catch (Exception e)
		{
			GD.PrintErr(e);
		}
	}

	public void DeleteThis()
	{
		if (!deleted)
		{
			QueueFree();
			deleted = true;
		}
	}
}
