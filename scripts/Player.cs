namespace DecayingChampion.scripts;

using Godot;
using System;

public partial class Player : CharacterBody2D
{

	private Vector2 _velocity;
	private float _speed = 250f;

	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		Move();
		
		MoveAndSlide();
	}

	private void Move()
	{
		var vertical = false;
		var horizontal = false;
		
		_velocity = Vector2.Zero;
		
		if (Input.IsKeyPressed(Key.W))
		{
			_velocity -= new Vector2(0, _speed);
			vertical = true;
		}
		if (Input.IsKeyPressed(Key.S))
		{
			_velocity += new Vector2(0, _speed);
			vertical = !vertical;
		}
		if (Input.IsKeyPressed(Key.A))
		{
			_velocity -= new Vector2(_speed, 0f);
			horizontal = true;
		}
		if (Input.IsKeyPressed(Key.D))
		{
			_velocity += new Vector2(_speed, 0f);
			horizontal = !horizontal;
		}

		if (vertical && horizontal)
		{
			_velocity /= (float)Math.Sqrt(2);
		}
		
		Velocity = _velocity;
	}
}
