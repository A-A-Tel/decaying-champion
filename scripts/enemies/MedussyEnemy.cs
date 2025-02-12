namespace DecayingChampion.scripts;

public partial class MedussyEnemy : Enemy
{
	//Canonically baddest B in the game//  TODO: Fuck Medusa
    public override short MaxHealth => 1200;
	
    protected override float Speed => 250f;
    protected override short Damage => 90;
	
    protected override bool HasAnimation => false;
}