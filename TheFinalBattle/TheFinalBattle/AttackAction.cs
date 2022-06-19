namespace FinalBattle;

// The attack action is a type of action, but there are many possible types of attacks,
// but fundementally all attacks will at the least have:
// the attacker, an attack name and a target (along some bespoke effect)
// attacks may deal damage, have a damage 'type', or other hostile effects
// By default attack actions only have a name and deal 0 damage. This is changed with specific attacks
public abstract class AttackAction : ICharacterAction
{
    public string Name { get; set; } = "Default Attack";
    public int Damage { get; set; } = 0;


    public void Execute(BattleGame battle, Character source, Character target)
    {
        //apply damage and effects to the target here
        target.CurrentHealth = target.CurrentHealth - Damage;

        //damage shouldn't reduce the target's health below 0, since they're already dead.
        if(target.CurrentHealth < 0) target.CurrentHealth = 0;

        //report what happened to the player
        Console.WriteLine($"{source.Name} used {this.Name} on {target.Name}.");
        Console.WriteLine($"{this.Name} did {this.Damage} damage to {target.Name}!");
        Console.WriteLine($"{target.Name} now has {target.CurrentHealth}/{target.MaxHealth} HP");

        // if the monster died, report that it died then remove it from it's team
        if (target.CurrentHealth == 0)
        {
            Console.WriteLine($"{target.Name} has been DESTROYED!");
            Party targetParty = battle.GetFriendlyPartyFor(target);
            targetParty.CharacterList.Remove(target);
        }


    }
}