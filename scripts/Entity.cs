using Godot;

namespace DecayingChampion.scripts;

public partial class Entity : CharacterBody2D
{
    public short Health { get; protected set; } = 100;
    public short MaxHealth { get; protected set; } = 100;
    public short Damage { get; protected set; } = 100;
    
    protected virtual float Speed { get; set; } = 100f;
    protected byte AnimationCount;
    protected bool HasAnimation = true;
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

    protected void CalculateTextureCount()
    {
        var textureSize = Sprite.Texture.GetSize();

        _animationSize = new Vector2(
            textureSize.X / (AnimationCount + 1f),
            textureSize.Y / 8f
        );
        GD.Print(_animationSize);
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

    private void SetAnimation()
    {
        if (IsMoving)
        {
            var direction = (byte)GetMovementDirection();

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

        var angle = Mathf.RadToDeg(Velocity.Angle());

        if (angle >= -112.5f && angle < -67.5f) return Direction.Up;
        if (angle >= 157.5f || angle < -157.5f) return Direction.Left;
        if (angle >= 67.5f && angle < 112.5f) return Direction.Down;
        if (angle >= -22.5f && angle < 22.5f) return Direction.Right;
        if (angle >= -157.5f && angle < -112.5f) return Direction.UpLeft;
        if (angle >= 112.5f && angle < 157.5f) return Direction.DownLeft;
        if (angle >= 22.5f && angle < 67.5f) return Direction.DownRight;
        if (angle >= -67.5f && angle < -22.5f) return Direction.UpRight;

        return Direction.Down;
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