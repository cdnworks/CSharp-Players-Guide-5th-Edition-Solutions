namespace FinalBattle;


//Unraveling attack, used by The Uncoded One
public class UnravelingAttack : AttackAction
{
    public UnravelingAttack() : base()
    {
        Name = "UNRAVELING";

        //Unraveling deals 0 to 2 damage
        Random random = new Random();
        Damage = random.Next(3);

    }


}
