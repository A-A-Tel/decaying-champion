using Godot;

namespace DecayingChampion.scripts;

public partial class PlayerHud : Control
{
    private Player _player;
    private TextureProgressBar _healthBar;
    
    private Texture2D[] _BarTextures;
    
    public override void _Ready()
    {
        _player = GetNode<Player>("../../");
        _healthBar = GetNode<TextureProgressBar>("HealthBar");
        
        _BarTextures = new[]
        {
            ResourceLoader.Load<Texture2D>("res://assets/Ui/BarShieldFull.png"),
            ResourceLoader.Load<Texture2D>("res://assets/Ui/BarShieldQuarter.png"),
            ResourceLoader.Load<Texture2D>("res://assets/Ui/BarShieldHalf.png"),
            ResourceLoader.Load<Texture2D>("res://assets/Ui/BarShieldBroken.png")
        };
    }

    public override void _Process(double delta)
    {
        UpdateProgressbar();
    }

    private void UpdateProgressbar()
    {
        byte value = (byte) ((double) _player.Health / _player.MaxHealth * 100);
        
        _healthBar.Value = value;

        _healthBar.TextureOver = value switch
        {
            >= 100 => _BarTextures[0],
            >= 51 => _BarTextures[1],
            >= 16 => _BarTextures[2],
            _ => _BarTextures[3]
        };
    }
}