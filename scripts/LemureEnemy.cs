namespace DecayingChampion.scripts;

public partial class LemureEnemy : Enemy
{
    protected override float Speed => 250f;
    protected override bool HasAnimation => false;
    protected override short Damage => 1;

    protected override void Attack()
    {
        if (DamageTimer.IsStopped())
        {
            Player.DealDamage(Damage);
            DamageTimer.Start();
        }
    }
}