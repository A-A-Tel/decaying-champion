using System;
using Godot;

namespace DecayingChampion.scripts;

public partial class Prison : Control
{
    public Arena Arena;
    private Camera2D _camera;
    private bool _busy;

    public override void _Ready()
    {
        _camera = GetNode<Camera2D>("Camera2D");

        foreach (Node node in GetChildren())
        {
            if (node is TextureButton button)
            {
                button.Pressed += () => OnCardClicked(button);
            }
        }
    }

    public void Enter()
    {
        _camera.MakeCurrent();
    }

    private void OnCardClicked(TextureButton sender)
    {
        if (_busy) return;
        _busy = true;
        Debuffs debuff = (Debuffs)sender.ZIndex;
        RemoveChild(sender);
        DebuffManager.SetDebuff(debuff);
        Arena.Resume();
        _busy = false;
    }
}