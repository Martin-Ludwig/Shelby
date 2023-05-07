using FluentValidation;
using Shelby.Library.System;

namespace Shelby.Library.Validation
{
    public class CombatValidator : AbstractValidator<Combat>
    {
        public CombatValidator()
        {
            RuleSet("Constructor", () =>
            {
                RuleFor(x => x.Players).NotNull();
                RuleFor(x => x.Players.Count).LessThan(2).WithMessage("Combat requires two players.");
                RuleFor(x => x.Players.Count).GreaterThan(CombatSettings.MaxPlayers).WithMessage($"Combat only supports {CombatSettings.MaxPlayers} players.");
            });

        }

    }
}
