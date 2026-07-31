/// RegentMonologues, to let characters monologue.
///     Copyright (C) 2026  Something Inconspicuous
///
///     This program is free software: you can redistribute it and/or modify
///     it under the terms of the GNU General Public License as published by
///     the Free Software Foundation, either version 3 of the License, or
///     (at your option) any later version.
///
///     This program is distributed in the hope that it will be useful,
///     but WITHOUT ANY WARRANTY; without even the implied warranty of
///     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
///     GNU General Public License for more details.
///
///     You should have received a copy of the GNU General Public License
///     along with this program.  If not, see <https://www.gnu.org/licenses/>.

using System.Text.RegularExpressions;
using BaseLib.Abstracts;
using BaseLib.Extensions;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Nodes.Vfx;
using MegaCrit.Sts2.Core.Random;

namespace RegentMonologues.Code;

public class MonologueSingleton() : CustomSingletonModel(HookType.Combat)
{
    /// <summary>
    /// All possible monologues for each character from the LocTable, including monologues added by mods.
    /// </summary>
    /// <param name="character">The character to get monologues for.</param>
    /// <returns>An array of <see cref="LocString"/>s containing the character's possible monologues.</returns>
    public static readonly SpireField<CharacterModel, LocString[]> Monologues = new(LoadMonologues);

    /// <summary>
    /// Gets all possible monologues for the character from the LocTable, including monologues added by mods.
    /// </summary>
    /// <param name="character">The character to get monologues for.</param>
    /// <returns>An array of <see cref="LocString"/>s containing the character's possible monologues.</returns>
    public static LocString[] GetMonologues(CharacterModel character)
    {
        return Monologues[character]!;
    }

    private static Rng? rng;

    public override Task BeforeCardPlayed(CardPlay cardPlay)
    {
        if (cardPlay.Player.HasPower<MonologuePower>())
        {
            LocString[] monologues = GetMonologues(cardPlay.Player.Character);

            rng ??= Rng.Chaotic;

            LocString? monologue = rng.NextItem(monologues);

            if (monologue != null)
            {
                TalkCmd.Play(monologue, cardPlay.Player.Creature, cardPlay.Player.Character.SpeechBubbleColor, VfxDuration.Short);
            }
        }

        return Task.CompletedTask;
    }

    private static LocString[] LoadMonologues(CharacterModel character)
    {
        string name = character.Id.Entry;
        IEnumerable<string> keys = LocManager.Instance.GetTable("characters").Keys;

        // Matches strings that have the mod id before the name of a character followed by .monologue
        // "REGENT_MONOLOGUES-IRONCLAD.monologue.0" or "DOWNFALL_MONOLOGUES-DOWNFALL-HERMIT.monologue.0", for example
        Regex monologueKeyRegex = new(@$"^.*-{name}\.monologue");
        return keys.Where(key => monologueKeyRegex.IsMatch(key))
                   .Select(static key => new LocString("characters", key))
                   .ToArray();
    }
}