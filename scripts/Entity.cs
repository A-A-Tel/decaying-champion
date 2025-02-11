using Godot;

namespace DecayingChampion.scripts;

public partial class Entity : CharacterBody2D
{
	public short Health { get; protected set; } = 100;
	public virtual short MaxHealth { get; protected set; } = 100;
	
	protected virtual float Speed => 100f;
	protected virtual bool HasAnimation => true;
	protected virtual byte AnimationCount => 0;
	
	protected bool IsMoving;

	protected Sprite2D Sprite;
	protected Timer AnimationTimer;

	private byte _currentAnimation = 1;
	
	private Vector2 _animationSize;

	public override void _PhysicsProcess(double delta)
	{
		CheckIfDead();
		Move();
		if (HasAnimation)
		{
			SetAnimation();
			PlayAnimation();
		}
		MoveAndCollide(Velocity * (float)delta);
	}

	protected virtual void CheckIfDead()
	{
		if (Health <= 0)
		{
			GetParent().RemoveChild(this);
			QueueFree();
		}
	}
	
	protected virtual void Move() {}
	
	protected void CalculateTextureCount()
	{
		Vector2 textureSize = Sprite.Texture.GetSize();

		_animationSize = new Vector2(
			textureSize.X / (AnimationCount + 1f),
			textureSize.Y / 8f
		);
	}

	private void SetAnimation()
	{
		if (IsMoving)
		{
			byte direction = (byte)GetMovementDirection();

			Sprite.RegionRect = new Rect2(0f, _animationSize.Y * direction, _animationSize);
		}
	}

	private void PlayAnimation()
	{
		if (IsMoving)
		{
			Sprite.RegionRect = new Rect2(_animationSize.X * _currentAnimation, Sprite.RegionRect.Position.Y, _animationSize);

			if (AnimationTimer.IsStopped())
			{
				_currentAnimation++;
				if (_currentAnimation > AnimationCount) _currentAnimation = 1;
				AnimationTimer.Start();
			}
		}
		else
		{
			Sprite.RegionRect = new Rect2(0, Sprite.RegionRect.Position.Y, _animationSize);
		}
	}
	
	private Direction GetMovementDirection()
	{
		float angle = Mathf.RadToDeg(Velocity.Angle());

		return angle switch
		{
			>= -112.5f and < -67.5f => Direction.Up,
			>= 157.5f or < -157.5f => Direction.Left,
			>= 67.5f and < 112.5f => Direction.Down,
			>= -22.5f and < 22.5f => Direction.Right,
			>= -157.5f and < -112.5f => Direction.UpLeft,
			>= 112.5f and < 157.5f => Direction.DownLeft,
			>= 22.5f and < 67.5f => Direction.DownRight,
			>= -67.5f and < -22.5f => Direction.UpRight,
			_ => Direction.Down
		};
	}

	private enum Direction
	{
		Up,
		Left,
		Down,
		Right,
		UpLeft,
		DownLeft,
		DownRight,
		UpRight
	}
}
