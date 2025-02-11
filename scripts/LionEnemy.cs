namespace DecayingChampion.scripts;

public partial class LionEnemy : Enemy
{
    protected override bool HasAnimation => false;
    
    protected override void Attack()
    {
        if (DamageTimer.IsStopped())
        {
            Player.DealDamage(Damage);
            DamageTimer.Start();
        }
    }
}