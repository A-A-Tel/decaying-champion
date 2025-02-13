namespace DecayingChampion.scripts;

public partial class BeholderEnemy : Boss
{
    public override short MaxHealth => 5600;
	
    protected override float Speed { get; set; } = 700f;
    protected override short Damage => 50;
	
    protected override bool HasAnimation => false;
}