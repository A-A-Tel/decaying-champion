namespace DecayingChampion.scripts;

using System;
using System.Net;
using System.Threading.Tasks;
using Godot;

public partial class ThrowProjectile : StaticBody2D
{
	private const float Speed = 900f;
	
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
			GetTree().Root.RemoveChild(this);
		}
		catch (Exception e)
		{
			GD.PrintErr(e);
		}
	}
}
