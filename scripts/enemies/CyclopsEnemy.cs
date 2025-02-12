﻿namespace DecayingChampion.scripts;

public partial class CyclopsEnemy : Enemy
{
    public override short MaxHealth => 1600;
	
    protected override float Speed => 160f;
    protected override short Damage => 250;
	
    protected override bool HasAnimation => false;
    
}