namespace DecayingChampion.scripts;

public partial class SnakeEnemy : Enemy
{
	public override short MaxHealth => 150;
	
	protected override float Speed => 325f;
	protected override short Damage => 5;
	
	protected override bool HasAnimation => false;
}
