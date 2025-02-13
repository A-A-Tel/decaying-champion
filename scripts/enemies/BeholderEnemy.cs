namespace DecayingChampion.scripts;

public partial class BeholderEnemy : Enemy
{
    public override short MaxHealth => 7600;
	
    protected override float Speed => 700f;
    protected override short Damage => 50;
	
    protected override bool HasAnimation => false;
}