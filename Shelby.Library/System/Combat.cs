using FluentValidation;
using Shelby.Library.Model;
using Shelby.Library.Validation;

namespace Shelby.Library.System
{
    public class Combat
    {
        public const int Rounds = CombatSettings.Rounds;

        public List<Character> Players { get; }

        public Combat(List<Character> players)
        {
            Players = players;

            if (Players.Count < 2)
                throw new ArgumentException("Combat requires two players.");

            if (Players.Count > CombatSettings.MaxPlayers)
                throw new ArgumentException($"Combat only supports {CombatSettings.MaxPlayers} players.");
        }

        public Character? Battle()
        {
            //CombatValidator validator = new();
            //var result = validator.Validate(this, options => options.IncludeRuleSets("Constructor", "default"));
            //if (result.IsValid == false)
            //    throw new ValidationException(result.Errors);

            for (int round = 1; round <= Rounds; round++)
            {
                Console.WriteLine($"Round {round} / {Rounds}");
                Action(Players[0], Players[1], round);
                Action(Players[1], Players[0], round);

                foreach (var player in Players)
                {
                    Console.WriteLine($"{player.Name} ({player.Health} Health)");
                }
                Console.WriteLine();
            }

            return Players.Where(x => x.Health > 0).MaxBy(x => x.Health);
        }

        void Action(Character user, Character defender, int round)
        {
            int preHealth = defender.Health;
            defender.Health -= user.Strength;

            Console.WriteLine($"  {defender.Name} lost {preHealth - defender.Health}");
        }

    }
}
