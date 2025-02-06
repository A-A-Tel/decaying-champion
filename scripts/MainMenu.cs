namespace DecayingChampion.scripts;

using Godot;
using System;

public partial class MainMenu : Control
{
		
	private Node _gameScene;

	private Button _mainMenuButton;
	
	
	
	public override void _Ready()
	{
		_gameScene = ResourceLoader.Load<PackedScene>("res://scenes/Arena.tscn").Instantiate();
		
		_mainMenuButton = GetNode<Button>("Play");

		_mainMenuButton.Pressed += OnButtonPressed;
	}

	private void OnButtonPressed()
	{
		GetTree().Root.AddChild(_gameScene);
		QueueFree();
	}
}
