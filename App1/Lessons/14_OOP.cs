// LESSON: MASTERING OBJECT-ORIENTED PROGRAMMING (OOP)
//
// CONTEXT:
// Up until now, we have written "Procedural Code" (Step 1, Step 2, Step 3).
// OOP is "Structural Code". We build objects that mirror the real world.
//
// THE 4 PILLARS OF OOP:
// 1. Encapsulation: Protecting data (we did this with Properties).
// 2. Inheritance: Sharing code between related classes (The "Is-A" relationship).
// 3. Polymorphism: Treating different objects the same way (The "Shape-Shifter").
// 4. Abstraction: Hiding complex details and forcing specific designs.
//
// PLUS: Interfaces (The "Can-Do" relationship).



namespace Lessons
{
    // 1. ABSTRACTION (The Blueprint)
    // We want to make Warriors and Mages. They are both "Characters".
    // Problem: It makes no sense to have a generic "Character" in the game. 
    // You can't just be "a character" — you must be a specific TYPE.
    //
    // Solution: The 'abstract' keyword.
    // - You CANNOT create a 'new Character()'.
    // - You CAN inherit from it.
    
    public abstract class Character
    {
        // ENCAPSULATION (Protecting Data)
        public string Name { get; set; }
        public int Health { get; protected set; } // 'protected' = Only me and my Children can touch this.

        public Character(string name, int health)
        {
            Name = name;
            Health = health;
        }

        // VIRTUAL METHOD (Polymorphism)
        // 'virtual' means: "I have a default behavior, but my children can change it if they want."
        public virtual void TakeDamage(int amount)
        {
            Health -= amount;
            Console.WriteLine($"{Name} took {amount} damage! HP: {Health}");
        }

        // ABSTRACT METHOD (Forced Behavior)
        // 'abstract' means: "I have no idea how to do this. My children MUST define this logic."
        // There is no code body { } here.
        public abstract void SpecialAttack();
    }

    // 2. INTERFACES (The Contract)
    // Sometimes, unrelated things share a generic ability.
    // A 'Chest' is not a 'Character', but both can be 'Unlocked'.
    // Inheritance doesn't fit here. Interfaces do.
    //
    // Rule: "I don't care WHAT you are. If you have this Interface, I know what you can DO."

    public interface IHealer
    {
        void Heal(Character target); // Anyone with this interface MUST have this method.
    }

    // 3. INHERITANCE (The Children)
    // "Warrior IS A Character"
    
    public class Warrior : Character
    {
        public int Armor { get; set; }

        // 'base' calls the Parent's constructor
        public Warrior(string name, int health, int armor) : base(name, health)
        {
            Armor = armor;
        }

        // OVERRIDE (Changing the Parent's Virtual logic)
        public override void TakeDamage(int amount)
        {
            // Warriors use Armor to reduce damage.
            int reducedDamage = amount - Armor;
            if (reducedDamage < 0) reducedDamage = 0;

            // Call the parent's base logic to actually subtract the HP
            base.TakeDamage(reducedDamage); 
            Console.WriteLine($"(Armor blocked {Armor} damage)");
        }

        // Implementing the Abstract method (REQUIRED)
        public override void SpecialAttack()
        {
            Console.WriteLine($"{Name} swings a Giant Axe!");
        }
    }

    // "Mage IS A Character AND can Heal"
    public class Mage : Character, IHealer
    {
        public int Mana { get; set; }

        public Mage(string name, int health, int mana) : base(name, health)
        {
            Mana = mana;
        }

        // Mage is physically weak. They take EXTRA damage.
        public override void TakeDamage(int amount)
        {
            base.TakeDamage(amount + 5); 
            Console.WriteLine("(Mage creates no defense!)");
        }

        public override void SpecialAttack()
        {
            if (Mana >= 10)
            {
                Console.WriteLine($"{Name} casts Fireball!");
                Mana -= 10;
            }
            else
            {
                Console.WriteLine($"{Name} tries to cast but fizzles... (No Mana)");
            }
        }

        // Implementing the Interface
        public void Heal(Character target)
        {
            Console.WriteLine($"{Name} casts Healing Light on {target.Name}.");
            // Since Health is 'protected', we can't change it directly on OTHER characters usually.
            // But for this demo, assume we have a way (or use a method like target.ReceiveHeal).
            // (In real code, you'd add a 'HealAmount' method to Character).
        }
    }

    // 4. POLYMORPHISM (The Magic)
    
    class GameEngine
    {
        public static void Run()
        {
            Console.WriteLine("=== OOP BATTLE SIMULATOR ===\n");

            // We can put different types into a SINGLE list because they share a Parent.
            List<Character> party =
            [
                new Warrior("Conan", 100, 5), // Armor 5
                new Mage("Gandalf", 60, 50),  // Mana 50
            ];

            // POLYMORPHISM IN ACTION
            // We treat them all as "Character", but they behave like themselves.
            
            foreach (Character member in party)
            {
                Console.WriteLine($"--- Turn: {member.Name} ---");
                
                // 1. The Abstract Method Check
                // We don't know if it's an Axe or Fireball, and we don't care.
                // The object knows what to do.
                member.SpecialAttack();

                // 2. The Interface Check.
                // We want to see if this character is a Healer.
                if (member is IHealer healer)
                {
                    // Cast it safely to use Healer-specific methods
                    healer.Heal(member); // Heals self for demo
                }
            }

            Console.WriteLine("\n--- ENEMY ATTACKS! ---");
            // Hit everyone for 20 damage.
            // Watch how Warrior blocks some, but Mage takes extra.
            foreach (Character member in party)
            {
                member.TakeDamage(20); 
            }
        }
    }

    class OOPDemo
    {
        public static void RunOOPDemo()
        {
            GameEngine.Run();
        }
    }
}