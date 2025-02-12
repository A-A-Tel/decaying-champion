namespace DecayingChampion.scripts;

public partial class LionessEnemy : Enemy
{
	public override short MaxHealth => 120;
	
	protected override float Speed => 450f;
	protected override short Damage => 50;
	
	protected override bool HasAnimation => false;
}
