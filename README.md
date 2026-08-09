# LetMeSpawnCamp

A BepInEx mod for Ultimate Chicken Horse that allows you to aim trap ranges directly at the spawn point!

In the base game, you are not allowed to place items if their attack range or swinging arc touches the spawn zone. This prevents players from placing a Boxing Glove or a Wrecking Ball right next to the spawn point, even if the physical base block is placed in a perfectly legal location. 

This mod removes that restriction specifically for the attack ranges of traps. With LetMeSpawnCamp, you can place a Boxing Glove so that it punches straight into the spawn, or place a Wrecking Ball so that it swings right through where players start. 

## How It Works

This mod patches the collision checks during the placement phase to ignore the spawn zone **only for the non-solid attack range indicators** of traps. 

It does **not** allow you to place solid blocks or pure hazards directly inside the spawn area. For example:
- You **can** place a Boxing Glove nearby so its punch hits the spawn.
- You **cannot** place the solid base of the Boxing Glove inside the spawn.
- You **can** place a Wrecking Ball nearby so its ball swings through the spawn.
- You **cannot** place Spikes or Barbed Wire directly on the spawn, as those are full hazard blocks and have no solid base to distinguish them from an attack range.

This ensures you can still set up aggressive, lethal spawn traps without allowing players to drop massive solid blocks or inescapable hazards directly onto the starting area.

## Before & After

### Vanilla Behavior (Before)
The game blocks you from finalizing a trap placement if its attack range touches the start zone.
![Vanilla Behavior](https://raw.githubusercontent.com/KRWCLASSIC/LetMeSpawnCamp/refs/heads/main/media/WithoutTheMod.png)

### Modded Behavior (After)
You can perfectly place traps so their range reaches directly into the spawn zone.
![Modded Behavior](https://raw.githubusercontent.com/KRWCLASSIC/LetMeSpawnCamp/refs/heads/main/media/WithTheMod.png)
