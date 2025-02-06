namespace DecayingChampion.scripts;

using Godot;

public partial class Boss : CharacterBody2D
{
	private bool isLeft = false;
	private Timer _animationTimer;
	private Sprite2D _sprite;
	
	public override void _Ready()
	{
		Velocity = new Vector2(0, 70f);
		_animationTimer = GetNode<Timer>("AnimationTimer");
		_sprite = GetNode<Sprite2D>("Sprite2D");
	}

	public override void _Process(double delta)
	{
		MoveAndSlide();

		if (_animationTimer.IsStopped())
		{
			if (isLeft)
			{
				_sprite.RegionRect = new Rect2(12, 2, 47, 71);
			}
			else
			{
				_sprite.RegionRect = new Rect2(93, 3, 47, 71);
			}
			_animationTimer.Start();
			isLeft = !isLeft;
		}
	}
}
