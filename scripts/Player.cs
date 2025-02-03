namespace DecayingChampion.scripts;

using Godot;
using System;
public partial class Player : CharacterBody2D
{
	private const float Speed = 300.0f;
	private const float JumpVelocity = -400.0f;
	private bool _isInAir = true;


	public override void _Ready()
	{
		
	}

	public override void _PhysicsProcess(double delta)
	{
		Move((float)delta);
	}

	private void Move(float delta)
	{
		if (IsOnFloor())
		{
			_isInAir = false;
		}
		
		if (Input.IsKeyPressed(Key.A))
		{
			Velocity = new Vector2(0, -Speed * delta);
		}
		else if (Input.IsKeyPressed(Key.D))
		{
			Velocity = new Vector2(0, Speed * delta);
		}

		if (Input.IsKeyPressed(Key.W))
		{
			Velocity = new Vector2(JumpVelocity * delta, 0);
			_isInAir = true;
		}
	}
}
