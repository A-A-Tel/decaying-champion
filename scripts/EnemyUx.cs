namespace DecayingChampion.scripts;

using Godot;

public partial class EnemyUx : Control
{
	private Enemy _enemy;
	private Label _labelHealth;

	public override void _Ready()
	{
		_enemy = GetNode<Enemy>("../");
		_labelHealth = GetNode<Label>("LabelHealth");
	}

	public override void _Process(double delta)
	{
		_labelHealth.Text = $"{_enemy.Health} / {_enemy.MaxHealth} Health";
	}
}
