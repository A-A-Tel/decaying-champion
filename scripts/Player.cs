namespace DecayingChampion.scripts;

using Godot;
using System;
public partial class Player : CharacterBody2D
{
	private const float Speed = 300.0f;
	private const float JumpVelocity = -400.0f;
	private bool _isInAir = false;


	public override void _Ready()
	{
		
	}

	public override void _Process(double delta)
	{
		Position += Velocity * (float)delta;
		Move((float)delta);
	}

	private void Move(float delta)
	{
		if (IsOnFloor()) _isInAir = false;
		
		if (Input.IsKeyPressed(Key.A))
		{
			Velocity = new Vector2(0, -Speed);
		}
		else if (Input.IsKeyPressed(Key.D))
		{
			Position += Velocity * delta;
		}

		if (Input.IsKeyPressed(Key.W) && !_isInAir)
		{
			Velocity = new Vector2(JumpVelocity, 0);
			_isInAir = true;
		}
	}
}
