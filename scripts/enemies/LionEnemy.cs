namespace DecayingChampion.scripts;

public partial class LionEnemy : Enemy
{
	public override short MaxHealth => 200;
	
	protected override float Speed => 335f;
	protected override short Damage => 70;
	
	protected override bool HasAnimation => false;
}
