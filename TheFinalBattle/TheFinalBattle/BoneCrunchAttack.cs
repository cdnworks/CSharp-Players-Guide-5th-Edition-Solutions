namespace FinalBattle;

//Bone crunch attack used by the skeleton
public class BoneCrunchAttack : AttackAction
{
    public BoneCrunchAttack() : base()
    {
        Name = "BONE CRUNCH";

        // Bone crunch does between 0 and 1 damage per attack
        Random random = new Random();
        Damage = random.Next(2);

    }

    
}
