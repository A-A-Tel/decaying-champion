namespace DecayingChampion.scripts;

public partial class LemureEnemy : Enemy
{
	protected override float Speed => 300f;
	protected override bool HasAnimation => true;
	protected override short Damage => 1;
	protected override byte AnimationCount => 2;
	protected override bool HasSound => true;
	
}
