IdleForge: Game Design Document (Roguelike Edition)
1. Game Overview
Concept: IdleForge is a 2D roguelike idle crafting and shop management game set in a grounded, dark fantasy world. Players take on the role of a blacksmith striving to achieve a significant objective within a set timeframe, such as amassing a fortune, gearing up the local town to withstand monstrous assaults, or averting a world-ending catastrophe. Each "run" presents unique challenges and opportunities, with gameplay revolving around mining resources, forging equipment, selling goods, making strategic upgrades (some randomized), and managing hires. Meta-progression allows players to unlock permanent advantages, making subsequent runs more manageable and enabling deeper exploration of the game's content.

Genre: Idle, Crafting Simulation, Shop Management, Roguelike, RPG-lite.

Target Audience: Players who enjoy incremental idle games, detailed crafting systems, economic simulation, roguelikes/roguelites (especially those with meta-progression like Vampire Survivors, Hades, Slay the Spire), and a dark fantasy aesthetic.

Art Style: "Grounded Dark Fantasy." Inspired by the grit and atmosphere of Darkest Dungeon and the detailed, somewhat realistic itemization of Diablo 2. Focus on:

Visuals: Detailed sprites with strong silhouettes, muted color palettes with occasional vibrant highlights (e.g., glowing embers, enchanted items, impactful event visuals). Environments should feel worn, functional, and atmospheric. UI elements will be clean but thematic, using textures like dark wood, stone, and aged parchment.

Atmosphere: A sense of urgency, toil, craftsmanship, and the quiet ambition of building a legacy against the odds in a harsh world.

Platform: Primarily PC (Steam), potentially mobile later (with UI adjustments).

Monetization (Optional - for consideration):

Primary: None (if premium game) or purely cosmetic (e.g., forge skins, unique hire appearances, run-start visual flairs).

Secondary (if F2P or with IAP): Focus on convenience for meta-progression (e.g., slight boost to meta-currency gain) or purely cosmetic. Crucially, avoid pay-to-win mechanics that directly sell power, best-in-slot gear, or significantly reduce the challenge of individual runs.

2. Core Gameplay Loop & Run Structure
The game is played in Runs. Each run has a primary objective and a deadline. The core loop within a run remains, but is now framed by daily and weekly events and the overarching run goal.

Run Objectives (Examples):

Economic Victory: Amass X Gold/Influence within Y days.

Town Defense: Forge enough quality gear for the Town Guard to survive Z waves of monster attacks by week W. This involves specific item type and quality quotas.

Avert Catastrophe: Craft a series of legendary artifacts or fulfill specific ancient prophecies to prevent a world-ending event by a final deadline (e.g., 100 days). This is a longer, multi-stage objective.

+---------------------------------------------------------------------+
|                             START RUN                               |
|                      (Select Objective, Potential Modifiers)        |
+----------------------------------+----------------------------------+
                                   | (Daily Cycle)
                                   v
+----------------------+     +-----------------+     +-----------------+
|      MINE            |---->|      FORGE      |---->|      SELL       |
| (Gather Resources)   |     | (Craft Items)   |     | (To Customers)  |
+----------------------+     +--------+--------+     +--------+--------+
      ^         ^                      |                       | (Gold/Reputation)
      | (Hires/Tools)                  | (Crafted Gear)        v
      |                                |                 +-----------------+
      |                                +---------------->|     UPGRADE     |
      |                                                  | (Forge, Shop,   |
      |                                                  |  Tools, Skills  |
      |                                                  |   *Randomized   |
      |                                                  |    Choices*)    |
      +--------------------------------------------------+-----------------+
                                   |
                                   v
+---------------------------------------------------------------------+
|                         END OF DAY EVENT                            |
|                  (Minor Boon/Bane, Customer Surge,                  |
|                   Resource Fluctuation, Randomized Upgrade Offer)   |
+----------------------------------+----------------------------------+
                                   | (Weekly Cycle)
                                   v
+---------------------------------------------------------------------+
|                         END OF WEEK EVENT                           |
|                  (Major Event: Monster Attack, Trade Caravan,       |
|                   Faction Interaction, Potential Run Ender/Changer) |
+----------------------------------+----------------------------------+
                                   |
                                   v
+---------------------------------------------------------------------+
|           RUN COMPLETION (Success/Failure) -> META-PROGRESSION      |
+---------------------------------------------------------------------+

Detailed Breakdown (Run-Focused):

MINE, FORGE, SELL, HIRE: These core activities remain central but are now performed under the pressure of the run's deadline and influenced by daily/weekly events and randomized upgrade paths.

UPGRADE (In-Run & Randomized):

Gold earned is reinvested into temporary, run-specific upgrades for the forge, shop, tools, and skills.

Vampire Survivors-Inspired Upgrades: At certain points (e.g., end of day, leveling up player smithing skill, completing a special order), players are presented with a choice of 2-4 randomized temporary upgrades. Examples:

"+20% Crafting Speed for Swords for 3 days."

"Next 5 sales have a 50% chance of double gold."

"Unlock a temporary 'Rapid Smelting' ability for the Smelter."

"All Iron Ore mined today is automatically 'Fine' quality."

"A mysterious benefactor offers a discount on your next Forge upgrade."

END OF DAY EVENTS (Minor):

A brief event occurs, offering small boons, banes, or choices.

Examples: Sudden rush of customers, a specific resource becomes temporarily cheaper/more expensive, a tool breaks, a traveling merchant offers a unique item, a choice of one of the randomized upgrades.

END OF WEEK EVENTS (Major):

Significant events that can drastically alter the run's trajectory or even end it if unprepared.

Examples:

Monster Attack: (If Town Defense objective) Requires the town to have met certain gear thresholds. Failure could mean loss of reputation, resources, or even a game over for the run.

Faction Emissary: A representative from a blacksmithing culture/faction arrives, offering unique recipes, materials, or challenges in exchange for specific crafted goods or allegiance.

Royal Decree: The King demands a large order of specific items, offering great rewards or severe penalties.

Natural Disaster: Earthquake damages mines, blight affects forests, etc., impacting resource availability.

Trade Caravan Arrival/Departure: Opportunity to buy rare goods or sell bulk items at good prices.

RUN CONCLUSION & META-PROGRESSION:

If the objective is met by the deadline: Success! Player earns a significant amount of meta-currency.

If the deadline is missed or a critical failure event occurs: Failure. Player earns a smaller amount of meta-currency based on progress.

Meta-currency is used to unlock permanent upgrades (see Meta-Progression section).

3. Key Features & Systems
3.1. The Forge & Crafting (Largely as before, but with run-specific context)
Crafting stations, recipes, material properties, item quality, active mini-games, fuel/maintenance remain crucial.

The urgency of the run objective will heavily influence what players choose to craft and research.

3.2. Resource Gathering & Management (Largely as before)
Mine networks, other gathering locations, resource tiers, and inventory are still vital.

Events can temporarily boost or hinder access to certain resources.

3.3. The Shop & Economy (Largely as before)
Customer AI, reputation, dynamic pricing, special orders are important for generating income for in-run upgrades.

Reputation might also contribute to certain run objectives (e.g., Influence).

3.4. Upgrades & Progression (Split into In-Run and Meta)
In-Run Upgrades:

Forge, Shop, Tool upgrades as previously defined, but these are temporary and reset at the end of a run.

Player Skills (In-Run): A simplified skill tree or set of perks that can be invested in during a run, resetting afterwards. These are augmented by the randomized upgrade choices.

Research (In-Run): Unlocking recipes or efficiencies for the current run only. Some rare blueprints might only be discoverable during a run.

Randomized Upgrade Choices:

Offered at intervals (end of day, level up, event reward).

Provide temporary but impactful boosts, new abilities, or resource windfalls.

Encourages adapting strategy on the fly.

Pool of available upgrades can expand via meta-progression.

3.5. Hires & Management (Largely as before)
Hires are crucial for automation and achieving objectives within the time limit.

Their levels and equipment are run-specific. Some rare, powerful Hires might only be available through meta-unlocks or specific in-run events.

3.6. World & Lore
Setting: Remains a gritty, low-magic world. The impending threat (for defense/catastrophe objectives) needs to be established.

Factions & Cultures of Blacksmithing:

Different regions or cultural groups (e.g., Dwarven Clans, Elven Artificers, Nomadic Steppe Smiths, Shadowy Underworld Forgers) have unique:

Smithing techniques (affecting item stats or special properties).

Preferred materials and exclusive recipes.

Aesthetic styles for gear.

Potential allies or rivals.

Players might align with a faction during a run for unique benefits, or their starting conditions could be influenced by a chosen "cultural background" (a meta-unlock).

Lore Integration: Item descriptions, customer dialogue, and event text will build the world and the stakes of the current run.

Events: Daily and Weekly events are now core to the roguelike experience, driving narrative and gameplay variance.

3.7. Meta-Progression System: "The Eternal Forge"
This replaces/expands the "Reforging the Soul" concept. After each run (success or failure), players earn "Soul Remnants" (or similar meta-currency).

Soul Remnants are spent at "The Eternal Forge" (a screen accessible between runs) to unlock permanent upgrades:

Starting Bonuses: Begin new runs with more gold, basic resources, or a common blueprint.

Forge Endowments: Permanent small boosts to crafting speed, quality chance, or fuel efficiency across all runs.

Blueprint Archive: Unlock new recipes permanently, making them available to find or research in future runs.

Hire Network: Increase the pool of available hire types or their starting skill levels.

Expanded Upgrade Pool: Add new, more powerful options to the randomized in-run upgrade choices.

Cultural Attunement: Unlock the ability to start a run with a specific "Blacksmithing Culture" background, granting unique starting benefits and challenges.

Event Mitigation: Unlock ways to better prepare for or slightly lessen the negative impact of certain challenging weekly events.

"Checkpoint" Unlocks: For very long run objectives (e.g., "Save the World"), meta-progression can unlock the ability to start a new attempt at a later stage (e.g., "Start at Day 30 with X progress"), reducing the need to replay early parts repeatedly.

New Run Modifiers/Objectives: Unlock more challenging or varied run types.

3.8. Run Structure & Event System (NEW SECTION)
Run Initiation: Player chooses a run objective (from unlocked options). Potentially apply unlocked run modifiers (e.g., "Hardcore Mode: Resources are scarcer," "Artisan's Focus: Only weapon/armor orders").

Daily Cycle:

Gameplay proceeds through in-game days.

Each day concludes with a Minor Event. These are generally quick, offering a small choice, a minor resource shift, or a randomized upgrade offer.

Examples: "A grateful farmer gifts you a cart of high-quality wood." "Your apprentice accidentally discovers a slightly faster way to polish armor (+5% armor crafting speed for 1 day)." "A sudden downpour makes mining difficult (-10% ore yield tomorrow)."

Weekly Cycle:

Every 7 in-game days (or a similar interval), a Major Event occurs. These are significant and can heavily impact the run.

Examples: As listed in Core Gameplay Loop, including monster attacks, faction interactions, economic shifts.

Some major events might be telegraphed (e.g., "Rumors of goblin activity in the East - an attack is likely next week").

Deadline: Each run objective has a clear deadline (e.g., 30 days, 5 weeks). Failure to meet the objective by this time results in a failed run.

Run Length:

Shorter runs (e.g., X gold in 20 days) for quicker play sessions.

Medium runs (e.g., Town Defense in 5-7 weeks).

Long runs (e.g., Avert Catastrophe in 100+ days) that are challenging and rely on significant meta-progression to complete, potentially using the "checkpoint" system.

4. User Interface (UI) & User Experience (UX)
UI Style: Remains dark, thematic, and clear.

Key Screens & Layouts (Additions/Modifications):

Run Objective Tracker: Prominently displayed on the main UI, showing current objective, progress, and time remaining.

Event Notification System: Clear, non-intrusive pop-ups or banners for daily/weekly events and randomized upgrade choices.

Meta-Progression Screen ("The Eternal Forge"): A dedicated interface between runs for spending Soul Remnants on permanent upgrades.

Run Selection Screen: Interface to choose the next run objective and any unlocked modifiers.

End of Run Summary: Clearly shows success/failure, Soul Remnants earned, and highlights key achievements or failures.

UX Principles:

Clarity of Stakes: Player must always understand their current run objective, the deadline, and the potential consequences of events.

Meaningful Choices: Both in-run randomized upgrades and meta-progression choices should feel impactful.

Pacing: Balance the idle crafting loop with the tension of events and deadlines. Ensure meta-progression feels rewarding and enables access to new challenges.

Information Accessibility: Easy to check current buffs/debuffs from events or temporary upgrades.

5. Art & Sound Direction
Visuals:

Events should have distinct visual cues or brief illustrative art to enhance their impact.

Monster designs for attack events should fit the dark fantasy aesthetic.

Faction representatives should have culturally distinct appearances.

Audio:

Event-specific sound cues (e.g., alarm bells for attacks, a regal fanfare for a royal decree, ominous tones for negative events).

Music can shift intensity or theme based on current events or proximity to the deadline.

6. Potential Future Expansions (Post-Launch Ideas - now with roguelike context)
New Run Objectives & Modifiers: Continuously add variety to the core roguelike experience.

More Factions & Cultures: Expand the world and strategic options.

Leaderboards: For specific run types or challenges.

Daily/Weekly Challenge Runs: Pre-set run conditions for all players to compete on.

Expanded Event Pools: More daily and weekly events to keep runs feeling fresh.

This revised structure should provide the framework for the exciting roguelike version of IdleForge you're envisioning! The interplay between the core crafting loop, the pressure of run objectives, the variance from events and randomized upgrades, and the long-term goals of meta-progression should create a deeply engaging experience.