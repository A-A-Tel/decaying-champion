namespace DecayingChampion.scripts;

using Godot;
using System;

public partial class Ux : Control
{

	private Player _player;
	private Label _labelHealth;
	
	public override void _Ready()
	{
		_player = GetNode<Player>("../../../Player");
		
		_labelHealth = GetNode<Label>("Health");
	}
	
	public override void _Process(double delta)
	{
		_labelHealth.Text = $"{_player.Health} / {_player.MaxHealth} Health";
	}
}
