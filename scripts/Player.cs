namespace DecayingChampion.scripts;

using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private Vector2 _velocity;
	
	private float _speed = 500f;
	
	public byte Health { get; private set; } = 100;
	public byte MaxHealth { get; private set; } = 100;
	
	public float AuraDamage { get; private set; } = 10f;
	public float WeaponDamage { get; private set; } = 20f;

	public override void _Ready()
	{
		Health = 100;
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
		else if (Input.IsKeyPressed(Key.S))
		{
			_velocity += new Vector2(0, _speed);

			vertical = true;
		}
		if (Input.IsKeyPressed(Key.A))
		{
			_velocity -= new Vector2(_speed, 0f);
			
			horizontal = true;
		}
		else if (Input.IsKeyPressed(Key.D))
		{
			_velocity += new Vector2(_speed, Scale.Y);
			
			horizontal = true;
		}

		if (vertical && horizontal)
		{
			_velocity /= (float)Math.Sqrt(2);
		}
		Velocity = _velocity;
	}

	public void DealDamage(byte amount)
	{
		Health -= amount;
	}
}
