# Regent-Monologues

The Regent (and others) will properly trash talk their foes when using His Majesty's Monologue skill.

## Installing

There are two main ways to install a mod for Slay the Spire 2:

 1. Through the Steam Workshop
 2. Manually

### Installing through the Steam Workshop

 1. Go to the "Regent Monologues" [item](https://steamcommunity.com/sharedfiles/filedetails/?id=3774233159) on the steam workshop.
 2. Click the big green "+ Subscribe" button.

### Manually Installing

 1. Go to the [Releases](https://github.com/Something-Inconspicuous/Regent-Monologues/releases/) section on this github, and find the latest one.
 2. Download either the `.zip` file, or download the `.dll`, `.json`, and `.pck` files.
 3. Put/Extract the files into a folder named `RegentMonologues` in your mods folder.
 
#### Addendum: how to find your mods folder

 1. Right click on Slay the Spire 2 in your games list on the left in Steam.
 2. Click on `Manage > Browse local files`
 3. Find the folder named `mods`. If it is absent, just create a folder named `mods` here.

## Your writing sucks!

Yeah; I am obviously not a part of nor in contact with any of the writing staff of MegaCrit. 
The monologues this mod comes with are just what I could come up with off the top of my head 
that seem vaguely in-character.

Please do not open issues or pull requests just to change the monologues. Unless you work for MegaCrit; in that case feel free to berate me for character assassination or something.

## Adding Monologues

To add monologues to either base game characters or your own, one would make an additional mod, sort of as an addon.
This addon does not actually need any content, just the `.pck` file. Still, it might be easiest to use one of the
[mod templates](https://github.com/Alchyr/ModTemplate-StS2) anyway. Of course, mods that add content also can add 
monologues, but if you do so don't make this mod a dependency; the loc strings can just sit unused.

In your mod's `characters.json` file, add your monologue lines, like so:

```json
"<MOD_ID>-<CHAR_ID>.monologue.0": "Some monologuing.",
"<MOD_ID>-<CHAR_ID>.monologue.1": "Some more monologuing.",
"<MOD_ID>-<CHAR_ID>.monologue.2": "Yet more monologuing.",
"<MOD_ID>-<CHAR_ID>.monologue.3": "Et cetera."
```

 * `<MOD_ID>` will be your mod's id, although it doesn't *have* to be so. Any (hopefully) unique string will do, as it is only there to prevent collisions.
 * `<CHAR_ID>` will be the character's id. This will include mod prefixes for modded characters.

For example, to add the line "Foo" to the Necrobinder's monologues in a mod called "Bar", one would use 

```json
"BAR-NECROBINDER.monologue.0": "Foo"
```

Or, if one made a mod titled "Monologue Extras" to add "I'm watching you" to [The Watcher](https://github.com/lamali292/WatcherMod), one would use

```json
"MONOLOGUE_EXTRAS-WATCHER-WATCHER.monologue.0": "I'm watching you"
```