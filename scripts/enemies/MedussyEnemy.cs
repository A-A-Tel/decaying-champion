namespace DecayingChampion.scripts;

public partial class MedussyEnemy : Enemy
{
	//Canonically baddest B in the game//  TODO: Fuck Medusa
    public override short MaxHealth => 7500;
	
    protected override float Speed => 250f;
    protected override short Damage => 90;
}