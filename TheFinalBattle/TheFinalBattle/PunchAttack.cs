namespace FinalBattle;


//Punch attack, used by the TrueProgrammer
public class PunchAttack : AttackAction
{
    public PunchAttack() : base()
    {
        Name = "PUNCH";

        //Punch is a basic attack, dealing 1 damage
        Damage = 1;

    }


}
