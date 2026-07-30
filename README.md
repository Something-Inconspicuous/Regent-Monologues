# Regent-Monologues

The Regent (and others) will properly trash talk their foes when using His Majesty's Monologue skill.

## Your writing sucks!

Yeah; I am obviously not a part of nor in contact with any of the writing staff of MegaCrit. 
The monologues this mod comes with are just what I could come up with off the top of my head 
that seem vaguely in-character.

Please do not open issues or pull requests just to change the monologues. Unless you work for MegaCrit; in that case feel free to berate me for character assassination or something.

## Adding Monologues

To add monologues to either base game characters or your own, simply follow the format.
In your `characters.json` file, add your monologue lines, like so:

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