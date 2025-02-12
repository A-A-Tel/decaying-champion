using Godot;

namespace DecayingChampion.scripts;

public partial class PlayerHud : Control
{
    private Player _player;
    private Arena _arena;
    private TextureProgressBar _healthBar;
    private RichTextLabel _roundCount;
    
    private Texture2D[] _barTextures;
    
    public override void _Ready()
    {
        _arena = (Arena)GetNode("../");
        _player = GetNode<Player>("../Player");
        _healthBar = GetNode<TextureProgressBar>("HealthBar");
        _roundCount = GetNode<RichTextLabel>("RoundCount");
        
        _barTextures = new[]
        {
            ResourceLoader.Load<Texture2D>("res://assets/Ui/BarShieldFull.png"),
            ResourceLoader.Load<Texture2D>("res://assets/Ui/BarShieldQuarter.png"),
            ResourceLoader.Load<Texture2D>("res://assets/Ui/BarShieldHalf.png"),
            ResourceLoader.Load<Texture2D>("res://assets/Ui/BarShieldBroken.png")
        };
    }

    public override void _Process(double delta)
    {
        GlobalPosition = _player.GlobalPosition - new Vector2(1152f, 648f);
        UpdateProgressbar();
        UpdateCount();
    }

    private void UpdateProgressbar()
    {
        byte value = (byte) ((double) _player.Health / _player.MaxHealth * 100);
        
        _healthBar.Value = value;

        _healthBar.TextureOver = value switch
        {
            >= 100 => _barTextures[0],
            >= 51 => _barTextures[1],
            >= 16 => _barTextures[2],
            _ => _barTextures[3]
        };
    }

    private void UpdateCount()
    {
        _roundCount.Text = $"Round: {_arena.Round}, Wave: {_arena.Wave}";
        GD.Print("we");
    }
}