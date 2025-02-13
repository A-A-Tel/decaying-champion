namespace DecayingChampion.scripts;

public partial class CyclopsEnemy : Enemy
{
    public override short MaxHealth => 8000;
	
    protected override float Speed => 160f;
    protected override short Damage => 250;
    
}