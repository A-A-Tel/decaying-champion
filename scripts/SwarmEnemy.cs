namespace DecayingChampion.scripts;

public partial class SwarmEnemy : Enemy
{
    public float Health = 100f;
    
    protected override float Speed { get; set; } = 200f;
    protected override float Damage { get; set; }
    protected override float AuraDamage { get; set; } = 1f;
    protected override bool TakeAuraDamage { get; set; }
}