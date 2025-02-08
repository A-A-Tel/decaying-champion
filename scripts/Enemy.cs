using System.Linq;
using Godot;

namespace DecayingChampion.scripts;

public partial class Enemy : Entity
{
	protected Player Player;
	protected Area2D Aura;
	protected virtual bool HasWeapon => false;

	public override void _Ready()
	{
		Player = GetNode<CharacterBody2D>("../Player") as Player;
		Aura = GetNode<Area2D>("Aura");
		
		Health = MaxHealth;
	}

	public override void _Process(double delta)
	{
		CheckForPlayer();
	}

	protected override void Move()
	{
		Velocity = (Player.GlobalPosition - GlobalPosition).Normalized() * Speed;
	}

	protected virtual void Attack()
	{
	}

	private void CheckForPlayer()
	{
		if (Aura.GetOverlappingBodies().OfType<Player>().Any()) Attack();
	}
}
