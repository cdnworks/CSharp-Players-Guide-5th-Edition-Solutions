namespace FinalBattle;

// The attack action is a type of action, but there are many possible types of attacks,
// but fundementally all attacks will at the least have:
// the attacker, an attack name and a target (along some bespoke effect)
public abstract class AttackAction : ICharacterAction
{
    public string Name { get; set; }


    public void Execute(BattleGame battle, Character source, Character target)
    {
        Console.WriteLine($"{source.Name} used {this.Name} on {target.Name}.");
    }
}