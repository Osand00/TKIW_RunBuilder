using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;
using TKIW_RunBuilder.Models;
using System.Linq;
using System.IO;
using System.Text;
using Microsoft.Win32;

namespace TKIW_RunBuilder.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Unit> _unit;

        public ObservableCollection<Unit> Units
        {
            get => _unit;
            set
            {
                _unit = value;
                OnPropertyChanged();
            }
        }

        

        

        private ObservableCollection<string> _waveType;

        public ObservableCollection<string> WaveTypes
        {
            get => _waveType;
            set
            {
                _waveType = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<string> _levelType;
        public ObservableCollection<string> LevelTypes
        {
            get => _levelType;
            set
            {
                _levelType = value;
                OnPropertyChanged();
            }
        }



        public ObservableCollection<WavePreset> WavePresets { get; set; }

        public ObservableCollection<WaveTemplate> WaveTemplates { get; set; }

        private string _selectedWaveType;
        public string SelectedWaveType
        {
            get => _selectedWaveType;
            set
            {
                _selectedWaveType = value;
                OnPropertyChanged();
            }
        }


        public MainWindowViewModel()
        {
            // Initialize the collection to avoid null reference exceptions
            Units = new ObservableCollection<Unit>
            {
                new Unit { idName = "anubis_warrior", displayName = "Anubis' Saber Master" },
                new Unit { idName = "assassin", displayName = "Assassin" },
                new Unit { idName = "ballista", displayName = "Ballista" },
                new Unit { idName = "balloon_bomber", displayName = "Baloon Bomber" },
                new Unit { idName = "barbarian", displayName = "Barbarian" },
                new Unit { idName = "bat_small", displayName = "Small Bat" },
                new Unit { idName = "black_sheep", displayName = "Black Sheep" },
                new Unit { idName = "black_swordsman", displayName = "Black Swordsman" },
                new Unit { idName = "bladecaster", displayName = "Bladecaster" },
                new Unit { idName = "boar_big", displayName = "Name" },
                new Unit { idName = "boar_junior", displayName = "unit_title_boar_junior" },
                new Unit { idName = "bogey", displayName = "Bogey" },
                new Unit { idName = "boss_masked_minion_1", displayName = "Bellringer's minion" },
                new Unit { idName = "boss_masked_minion_2", displayName = "Bellringer's minion" },
                new Unit { idName = "boss_witch_1", displayName = "Unholy Crones" },
                new Unit { idName = "boss_witch_2", displayName = "Unholy Crones" },
                new Unit { idName = "boss_witch_3", displayName = "Unholy Crones" },
                new Unit { idName = "boss_witch_4", displayName = "Unholy Crones" },
                new Unit { idName = "bumblebee", displayName = "Bumblebee" },
                new Unit { idName = "burning_skull", displayName = "Burning Skull" },
                new Unit { idName = "bursting_bug", displayName = "Bursting Beetle" },
                new Unit { idName = "bursting_guy", displayName = "Bursting Guy" },
                new Unit { idName = "cannon", displayName = "Cannon" },
                new Unit { idName = "cart", displayName = "Explosive Cart" },
                new Unit { idName = "catapult", displayName = "Catapult" },
                new Unit { idName = "cathead", displayName = "Cathead" },
                new Unit { idName = "chicken_rider", displayName = "Chicken Rider" },
                new Unit { idName = "claything", displayName = "Claything" },
                new Unit { idName = "cobra_mage", displayName = "Cobra Mage" },
                new Unit { idName = "corrupted_assassin", displayName = "Corrupted Assassin" },
                new Unit { idName = "corrupted_bumblebee", displayName = "Corrupted Bumblebee" },
                new Unit { idName = "corrupted_flour_dragon", displayName = "Corrupted Dragon" },
                new Unit { idName = "corrupted_goose_rider", displayName = "Corrupted Goose Rider" },
                new Unit { idName = "corrupted_madman", displayName = "Corrupted Madman" },
                new Unit { idName = "corrupted_mushroom_warrior", displayName = "Corrupted Mushroom Warrior" },
                new Unit { idName = "corrupted_peasant", displayName = "Corrupted Peasant" },
                new Unit { idName = "corrupted_ram", displayName = "Corrupted Ram" },
                new Unit { idName = "corrupted_unicorn", displayName = "Corrupted Unicorn" },
                new Unit { idName = "cow_rider", displayName = "Cow Rider" },
                new Unit { idName = "cronen_big", displayName = "Cronenberg" },
                new Unit { idName = "cronen_small", displayName = "Cronenberg Jr." },
                new Unit { idName = "cthulhu", displayName = "Depths' Dweller" },
                new Unit { idName = "cursed_ghost_1", displayName = "Cursed Ghost" },
                new Unit { idName = "cursed_ghost_2", displayName = "Cursed Ghost" },
                new Unit { idName = "cursed_ghost_3", displayName = "Cursed Ghost" },
                new Unit { idName = "cursed_lady", displayName = "Alexia" },
                new Unit { idName = "deadclops", displayName = "Deadclops" },
                new Unit { idName = "demon_boss", displayName = "Malathrax" },
                new Unit { idName = "dragon_boss", displayName = "Volkar" },
                new Unit { idName = "druid_badger_beast", displayName = "Druid of the Badger (Transformed)" },
                new Unit { idName = "druid_badger_human", displayName = "Druid of the Badger" },
                new Unit { idName = "druid_bear_beast", displayName = "Druid of the Bear (Transformed)" },
                new Unit { idName = "druid_bear_human", displayName = "Druid of the Bear" },
                new Unit { idName = "druid_owlcat_beast", displayName = "Druid of the Owl (Transformed)" },
                new Unit { idName = "druid_owlcat_human", displayName = "Druid of the Owl" },
                new Unit { idName = "ent", displayName = "Ent" },
                new Unit { idName = "explosive_spider", displayName = "Explosive Spider" },
                new Unit { idName = "fairy", displayName = "Fairy" },
                new Unit { idName = "fallen_hero", displayName = "Fallen Hero" },
                new Unit { idName = "fighting_ghost", displayName = "Fighting Ghost" },
                new Unit { idName = "fire_spider_boss", displayName = "Magma Widow" },
                new Unit { idName = "flour_dragon", displayName = "Flour dragon" },
                new Unit { idName = "flour_dragon_black", displayName = "Ash Dragon" },
                new Unit { idName = "frank", displayName = "Wretch" },
                new Unit { idName = "genie", displayName = "Jinn" },
                new Unit { idName = "gnome", displayName = "Gnome" },
                new Unit { idName = "goblin_bandit", displayName = "Goblin bandit" },
                new Unit { idName = "goblin_bat_rider", displayName = "Goblin bat rider" },
                new Unit { idName = "goblin_boss", displayName = "Goblins' Warlord Gorzog" },
                new Unit { idName = "goblin_builder", displayName = "Goblin Engineer" },
                new Unit { idName = "goblin_crab_rider", displayName = "Crab rider" },
                new Unit { idName = "goblin_crossbowman", displayName = "Goblin crossbowman" },
                new Unit { idName = "goblin_giant", displayName = "Goblin giant" },
                new Unit { idName = "goblin_lizard", displayName = "Goblin lizard" },
                new Unit { idName = "goblin_mage_fire", displayName = "Goblin Fire Mage" },
                new Unit { idName = "goblin_mage_healer", displayName = "Goblin Healer Mage" },
                new Unit { idName = "goblin_mage_lightning", displayName = "Goblin Lightning Mage" },
                new Unit { idName = "goblin_pig", displayName = "Goblin Pig" },
                new Unit { idName = "goblin_shaman", displayName = "Goblin Shaman" },
                new Unit { idName = "goblin_sharpshooter_boss", displayName = "Smokeeye" },
                new Unit { idName = "goblin_spitter_boss", displayName = "The Hungering Maw" },
                new Unit { idName = "goblin_swordsman", displayName = "Goblin Swordsman" },
                new Unit { idName = "goblin_wall_buster", displayName = "Wall Buster" },
                new Unit { idName = "goblin_wife_boss", displayName = "Margra" },
                new Unit { idName = "golden_dragon", displayName = "Golden Dragon" },
                new Unit { idName = "golem", displayName = "Stone Golem" },
                new Unit { idName = "goose_hydra", displayName = "Goose Hydra" },
                new Unit { idName = "goose_rider", displayName = "Goose Rider" },
                new Unit { idName = "grave_bearer", displayName = "Graveyard Golem" },
                new Unit { idName = "grave_digger", displayName = "Ruins Scout" },
                new Unit { idName = "griffin", displayName = "Griffin" },
                new Unit { idName = "hair_witch_boss", displayName = "Blademistress" },
                new Unit { idName = "harpy", displayName = "Harpy" },
                new Unit { idName = "hellclops", displayName = "Hellclops" },
                new Unit { idName = "horus", displayName = "Horus" },
                new Unit { idName = "human_centaur", displayName = "Centaur" },
                new Unit { idName = "human_crossbowman", displayName = "Crossbowman" },
                new Unit { idName = "human_horseman", displayName = "Horseman" },
                new Unit { idName = "human_militia", displayName = "Militia" },
                new Unit { idName = "human_militia_mega", displayName = "Brigade" },
                new Unit { idName = "human_peasant", displayName = "Peasant" },
                new Unit { idName = "human_swordsman", displayName = "Swordsman" },
                new Unit { idName = "hydra", displayName = "Hydra" },
                new Unit { idName = "immortal_longbowman", displayName = "Immortal Longbowman" },
                new Unit { idName = "immortal_swordsman", displayName = "Swordsman" },
                new Unit { idName = "imp_beholder", displayName = "Imp Beholder" },
                new Unit { idName = "imp_boss", displayName = "Infernal Overlord" },
                new Unit { idName = "imp_cacodaemon", displayName = "Cacodaemon" },
                new Unit { idName = "imp_commander", displayName = "Infernal General" },
                new Unit { idName = "imp_dog", displayName = "Imp Minion" },
                new Unit { idName = "imp_flyhead", displayName = "Imp Flying Head" },
                new Unit { idName = "imp_giant", displayName = "Imp Giant" },
                new Unit { idName = "imp_goliath", displayName = "Goliath" },
                new Unit { idName = "imp_houndmouth", displayName = "Imp Houndmouth" },
                new Unit { idName = "imp_skeleton_copper", displayName = "Imp Skeleton" },
                new Unit { idName = "infernal_bat", displayName = "Infernal bat" },
                new Unit { idName = "infernal_hoof", displayName = "Infernal hoof" },
                new Unit { idName = "iron_head", displayName = "Facelock" },
                new Unit { idName = "jason", displayName = "Psycho" },
                new Unit { idName = "jug", displayName = "Jug" },
                new Unit { idName = "kraken", displayName = "Kraken" },
                new Unit { idName = "lady_boss_spirit", displayName = "Wandering Spirit" },
                new Unit { idName = "lava_drowner", displayName = "Lava Drowner" },
                new Unit { idName = "lava_wraith", displayName = "Lava Wraith" },
                new Unit { idName = "leshy_spirit", displayName = "Alchemist Hermit" },
                new Unit { idName = "lich_boss", displayName = "Sir Mortifax" },
                new Unit { idName = "longbowman", displayName = "Longbowman" },
                new Unit { idName = "madman", displayName = "Madman" },
                new Unit { idName = "mage_fire", displayName = "Fire Mage" },
                new Unit { idName = "mage_healer", displayName = "Healer Mage" },
                new Unit { idName = "mage_lightning", displayName = "Lightning Mage" },
                new Unit { idName = "magma_spawn", displayName = "Magma Spawn" },
                new Unit { idName = "magma_worm_body_1", displayName = "Solvurm (body)" },
                new Unit { idName = "magma_worm_body_2", displayName = "Solvurm (body)" },
                new Unit { idName = "magma_worm_boss", displayName = "Solvurm" },
                new Unit { idName = "magma_worm_small", displayName = "Magma worm" },
                new Unit { idName = "magmafaced", displayName = "Magmafaced" },
                new Unit { idName = "masked_boss_stage_1", displayName = "Masked Tyrant" },
                new Unit { idName = "masked_boss_stage_2", displayName = "Masked Tyrant" },
                new Unit { idName = "masked_boss_stage_3", displayName = "Masked Tyrant" },
                new Unit { idName = "maya_bamboo_warrior", displayName = "Maya Bamboo Warrior" },
                new Unit { idName = "maya_brawler", displayName = "Maya Brawler" },
                new Unit { idName = "maya_fire_mage", displayName = "Maya Fire Shaman" },
                new Unit { idName = "maya_frog_rider", displayName = "Maya Frog Rider" },
                new Unit { idName = "maya_healer", displayName = "Maya Healer Shaman" },
                new Unit { idName = "maya_pikeman", displayName = "Maya Pikeman" },
                new Unit { idName = "maya_reaper", displayName = "Maya Reaper" },
                new Unit { idName = "maya_serpent", displayName = "Maya Serpent" },
                new Unit { idName = "maya_swordsman", displayName = "Maya Swordsman" },
                new Unit { idName = "maya_thunder_mage", displayName = "Maya Thunder Shaman" },
                new Unit { idName = "mecha_bat", displayName = "Mechanical Bat" },
                new Unit { idName = "mecha_mammoth", displayName = "Mechanical Mammoth" },
                new Unit { idName = "mind_slave", displayName = "Patricius" },
                new Unit { idName = "minotaur", displayName = "Minotaur" },
                new Unit { idName = "moonfaced", displayName = "Moonfaced" },
                new Unit { idName = "moth_fencer", displayName = "Moth fencer" },
                new Unit { idName = "mushroom_warrior", displayName = "Mushroom Warrior" },
                new Unit { idName = "musketeer", displayName = "Musketeer" },
                new Unit { idName = "naked_giant", displayName = "Giant" },
                new Unit { idName = "necro_fencer", displayName = "Decaying Fencer" },
                new Unit { idName = "necro_horseman", displayName = "Fallen Horseman" },
                new Unit { idName = "necro_soldier", displayName = "Fallen Soldier" },
                new Unit { idName = "octopus_boss", displayName = "O'Chtulpus" },
                new Unit { idName = "ogre_boss", displayName = "unit_title_ogre_boss" },
                new Unit { idName = "paladin_mage", displayName = "Paladin mage" },
                new Unit { idName = "pangolin", displayName = "Pangolin" },
                new Unit { idName = "pangolin_roll", displayName = "Pangolin (rolling form)" },
                new Unit { idName = "pharaoh", displayName = "Pharaoh" },
                new Unit { idName = "phoenix_boss", displayName = "Ashfeather" },
                new Unit { idName = "phoenix_stage_egg", displayName = "Ashfeather (Egg)" },
                new Unit { idName = "pig_rider", displayName = "Pig Rider" },
                new Unit { idName = "poison_snake", displayName = "Viper Baby" },
                new Unit { idName = "poisonous_crawler", displayName = "Toxic Crawler" },
                new Unit { idName = "pumpkin_warrior", displayName = "Pumpkin Warrior" },
                new Unit { idName = "ram", displayName = "Ram" },
                new Unit { idName = "reaper", displayName = "Mordain" },
                new Unit { idName = "red_eye", displayName = "Cyclops" },
                new Unit { idName = "relict", displayName = "Relict" },
                new Unit { idName = "sand_golem", displayName = "Sand Golem" },
                new Unit { idName = "sapphire_dragon", displayName = "Sapphire dragon" },
                new Unit { idName = "scarab", displayName = "Scarab" },
                new Unit { idName = "scarecrow", displayName = "Scarecrow" },
                new Unit { idName = "scarling_bandit", displayName = "Scarlet Bandit" },
                new Unit { idName = "scarling_bones", displayName = "Scarlet Bones" },
                new Unit { idName = "scarling_deathclaw", displayName = "Scarlet Deathclaw" },
                new Unit { idName = "scarling_fire_shooter", displayName = "Scarlet Fire shooter" },
                new Unit { idName = "scarling_gecko_rider", displayName = "Scarlet Gecko rider" },
                new Unit { idName = "scarling_mage_lightning", displayName = "Scarlet lightning mage" },
                new Unit { idName = "scarling_mage_tentacle", displayName = "Scarlet Empower mage" },
                new Unit { idName = "scarling_mage_toxic", displayName = "Scarlet toxic mage" },
                new Unit { idName = "scarling_mortar", displayName = "Scarlet Mortar" },
                new Unit { idName = "scarling_necromancer", displayName = "Scarlet Necromancer" },
                new Unit { idName = "scarling_rogue", displayName = "Scarlet Rogue" },
                new Unit { idName = "scarling_shieldman", displayName = "Scarlet Shieldsman" },
                new Unit { idName = "scarling_shieldman_roll", displayName = "Scarlet Shieldsman" },
                new Unit { idName = "scarling_slinger", displayName = "Scarlet Slinger" },
                new Unit { idName = "scarling_toad_rider", displayName = "Scarlet Toad rider" },
                new Unit { idName = "scorpion", displayName = "Scorpion" },
                new Unit { idName = "scorpion_rider", displayName = "Scorpion rider" },
                new Unit { idName = "sea_eel", displayName = "Eel" },
                new Unit { idName = "sea_fish_crooked", displayName = "Crooked Fish" },
                new Unit { idName = "sea_fish_rowdy", displayName = "Rowdy fish" },
                new Unit { idName = "sea_fish_thug", displayName = "Fish Thug" },
                new Unit { idName = "sea_hammer_shark", displayName = "Hammer shark" },
                new Unit { idName = "sea_octopus_gunner", displayName = "Octopus Gunner" },
                new Unit { idName = "sea_orca", displayName = "Orca" },
                new Unit { idName = "sea_stingray", displayName = "Stingray" },
                new Unit { idName = "sea_walking_shark", displayName = "Walking shark" },
                new Unit { idName = "serpent_reaper_boss", displayName = "Serpent Reaper" },
                new Unit { idName = "sharpshooter_spike_1", displayName = "Spike" },
                new Unit { idName = "sharpshooter_spike_2", displayName = "Spike" },
                new Unit { idName = "skeleton_big", displayName = "Big bones" },
                new Unit { idName = "skeleton_large", displayName = "Large Bones" },
                new Unit { idName = "skeleton_small", displayName = "Small bones" },
                new Unit { idName = "slime_blue_big", displayName = "Blue Slug" },
                new Unit { idName = "slime_blue_small", displayName = "Blue Slime" },
                new Unit { idName = "slime_green_big", displayName = "Green Slug" },
                new Unit { idName = "slime_green_small", displayName = "Green Slime" },
                new Unit { idName = "slime_sand_big", displayName = "Sand Slug" },
                new Unit { idName = "slime_sand_small", displayName = "Sand Slime" },
                new Unit { idName = "slinger", displayName = "Slinger" },
                new Unit { idName = "sludge_golem", displayName = "Sludge Golem" },
                new Unit { idName = "snow_golem", displayName = "Snow Golem" },
                new Unit { idName = "sobek", displayName = "Sobek's Servant" },
                new Unit { idName = "sorcerer_boss", displayName = "Vesper" },
                new Unit { idName = "sphinx", displayName = "Sphinx" },
                new Unit { idName = "sphinx_guardian", displayName = "Sphinx' guardian" },
                new Unit { idName = "stickwalker_boss", displayName = "Araknor" },
                new Unit { idName = "stickwalker_junior", displayName = "Onarak, Araknor's brother" },
                new Unit { idName = "sunfaced", displayName = "Sunfaced" },
                new Unit { idName = "tentacle_beetle_spawner", displayName = "Beetle Tentacle" },
                new Unit { idName = "tentacle_hitter", displayName = "Tentacle" },
                new Unit { idName = "tentacle_hitter_big", displayName = "Kraken Arm" },
                new Unit { idName = "tentacle_hitter_small", displayName = "Tendril" },
                new Unit { idName = "tentacle_mage", displayName = "Abyssal Oracle" },
                new Unit { idName = "tentacle_mage_jr", displayName = "Entrapped Adept" },
                new Unit { idName = "tentacle_poison_bag", displayName = "Venom Sack" },
                new Unit { idName = "tentacle_poison_shooter", displayName = "Blight Spitter" },
                new Unit { idName = "tentacle_serpent", displayName = "Awakened Serpent" },
                new Unit { idName = "tentacle_serpent_sleep", displayName = "Sleeping Serpent" },
                new Unit { idName = "tentacle_spiky", displayName = "Spiky Tentacle" },
                new Unit { idName = "tentacle_spore_guard", displayName = "Spore Guardian" },
                new Unit { idName = "tentacle_spore_tower", displayName = "Spore Tower" },
                new Unit { idName = "tentacle_turret", displayName = "Tentacle turret" },
                new Unit { idName = "tentacle_watcher", displayName = "Abyssal Watcher" },
                new Unit { idName = "tentacle_womb", displayName = "Brood Tentacle" },
                new Unit { idName = "three_headed_viper", displayName = "Venoxia" },
                new Unit { idName = "tiger_dragon", displayName = "Tiger Dragon" },
                new Unit { idName = "toad", displayName = "Toad" },
                new Unit { idName = "toothy", displayName = "Toothy" },
                new Unit { idName = "undead_apparition", displayName = "Undead Apparition" },
                new Unit { idName = "undead_archdemon", displayName = "Undead Archdemon" },
                new Unit { idName = "undead_axe", displayName = "Undead Axe" },
                new Unit { idName = "undead_bone_warrior", displayName = "Undead Bone Warrior" },
                new Unit { idName = "undead_bull", displayName = "Undead Bull" },
                new Unit { idName = "undead_cultist", displayName = "Undead Cultist" },
                new Unit { idName = "undead_dread_guard", displayName = "Undead Dread Guard" },
                new Unit { idName = "undead_grim_reaper", displayName = "Undead Grim Reaper" },
                new Unit { idName = "undead_wraith", displayName = "Undead Wraith" },
                new Unit { idName = "undead_wyvern", displayName = "Undead Wyvern" },
                new Unit { idName = "unicorn_black", displayName = "Black Unicorn" },
                new Unit { idName = "unicorn_white", displayName = "White Unicorn" },
                new Unit { idName = "vampire_lord_stage_1", displayName = "Lord Draven" },
                new Unit { idName = "vampire_lord_stage_2", displayName = "Lord Draven" },
                new Unit { idName = "vampire_lord_stage_3", displayName = "Lord Draven" },
                new Unit { idName = "vampire_swordsman", displayName = "Vampire Swordsman" },
                new Unit { idName = "walking_artillery", displayName = "Walking Artillery" },
                new Unit { idName = "whipman", displayName = "Whipman" },
                new Unit { idName = "witch_cat", displayName = "Witch's Cat" },
                new Unit { idName = "witch_cauldron", displayName = "Witch's Cauldron" },
                new Unit { idName = "witcher", displayName = "Hunter" },
                new Unit { idName = "womb_spawn", displayName = "Spikehead" },
                new Unit { idName = "worm_rider", displayName = "Worm Rider" },
                new Unit { idName = "zombie_1", displayName = "Zombie" },
                new Unit { idName = "zombie_2", displayName = "Zombie crawler" },
                new Unit { idName = "", displayName = "" }
            };
            WaveTypes = new ObservableCollection<string>
            {
                "prophecy",
                "shop",
                "boss",
                ""
            };
            LevelTypes = new ObservableCollection<string>
            {
                "village",
                "lava",
                "graveyard",
                "dark_realm",
                ""
            };
            WavePresets = new ObservableCollection<WavePreset>();
            WaveTemplates = new ObservableCollection <WaveTemplate>();
        }

        // Show an OpenFileDialog to pick a CSV and import WaveTemplates, replacing existing collection.
        // Returns (importedCount, errorMessage). If importedCount is 0 and errorMessage is null, user cancelled.
        public (int importedCount, string? errorMessage) TemplateImport()
        {
            var dlg = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".csv",
                Filter = "CSV files (.csv)|*.csv|All files (*.*)|*.*",
                Multiselect = false
            };

            bool? result = dlg.ShowDialog();
            if (result != true)
                return (0, null);

            try
            {
                var lines = File.ReadAllLines(dlg.FileName, Encoding.UTF8);
                var imported = new List<WaveTemplate>();
                foreach (var raw in lines)
                {

                    if (string.IsNullOrWhiteSpace(raw))
                        continue;
                    var fields = ParseCsvLine(raw).ToArray();
                    // Skip header rows where first field is not an int
                    if (fields.Length < 2) continue;
                    if (fields[0].Trim().ToLower() != "" && LevelTypes.Contains(fields[0].Trim().ToLower()))
                    {
                        SelectedWaveType = fields[0].Trim().ToLower();
                    }
                    if (!int.TryParse(fields[1], out var id))
                        continue;

                    var wt = new WaveTemplate();
                    wt.Id = id;
                    if (fields.Length > 2 && int.TryParse(fields[2], out var week)) wt.week = week;
                    wt.reqWaveId = fields.Length > 3 ? fields[3] : string.Empty;
                    wt.extraWaveId_1 = fields.Length > 4 ? fields[4] : null;
                    wt.extraWaveId_2 = fields.Length > 5 ? fields[5] : null;
                    var waveTypes = fields.Length > 6 ? fields[6].Split(',') : null;
                    if (waveTypes != null && waveTypes.Length > 0)
                    {
                        wt.waveType = waveTypes[0];
                        wt.secondaryWaveType = waveTypes.Length > 1 ? waveTypes[1] : string.Empty;
                        wt.tertiaryWaveType = waveTypes.Length > 2 ? waveTypes[2] : string.Empty;
                    }
                    else
                    {
                        wt.waveType = string.Empty;
                        wt.secondaryWaveType = string.Empty;
                        wt.tertiaryWaveType = string.Empty;
                    }
                    imported.Add(wt);

                }

                // Replace existing collection contents
                WaveTemplates.Clear();
                foreach (var it in imported)
                WaveTemplates.Add(it);

                return (imported.Count, null);
            }
            catch (System.Exception ex)
            {
                return (0, ex.Message);
            }
        }

        // Show an OpenFileDialog to pick a CSV and import WaveTemplates, replacing existing collection.
        // Returns (importedCount, errorMessage). If importedCount is 0 and errorMessage is null, user cancelled.
        public (int importedCount, string? errorMessage) UnitImport()
        {
            var dlg = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".csv",
                Filter = "CSV files (.csv)|*.csv|All files (*.*)|*.*",
                Multiselect = false
            };

            bool? result = dlg.ShowDialog();
            if (result != true)
                return (0, null);

            try
            {
                var lines = File.ReadAllLines(dlg.FileName, Encoding.UTF8);
                var imported = new List<WavePreset>();
                foreach (var raw in lines)
                {

                    if (string.IsNullOrWhiteSpace(raw))
                        continue;
                    var fields = ParseCsvLine(raw).ToArray();
                    // Skip header rows where first field is not an int
                    if (fields.Length < 2) continue;
                    if (fields[0].Trim().ToLower() != "" && LevelTypes.Contains(fields[0].Trim().ToLower()))
                    {
                        SelectedWaveType = fields[0].Trim().ToLower();
                    }
                    if (!int.TryParse(fields[1], out var id))
                        continue;

                    var wp = new WavePreset();
                    wp.Id = id;
                    wp.unit_1 = fields.Length > 5 ? UnitMatcher(fields[5]) : UnitMatcher(string.Empty);
                    if (fields.Length > 6 && int.TryParse(fields[6], out var qty1)) wp.qty_1 = qty1;
                    wp.unit_2 = fields.Length > 7 ? UnitMatcher(fields[7]) : UnitMatcher(string.Empty);
                    if (fields.Length > 8 && int.TryParse(fields[8], out var qty2)) wp.qty_2 = qty2;
                    wp.unit_3 = fields.Length > 9 ? UnitMatcher(fields[9]) : UnitMatcher(string.Empty);
                    if (fields.Length > 10 && int.TryParse(fields[10], out var qty3)) wp.qty_3 = qty3;
                    wp.unit_4 = fields.Length > 11 ? UnitMatcher(fields[11]) : UnitMatcher(string.Empty);
                    if (fields.Length > 12 && int.TryParse(fields[12], out var qty4)) wp.qty_4 = qty4;
                    wp.unit_5 = fields.Length > 13 ? UnitMatcher(fields[13]) : UnitMatcher(string.Empty);
                    if (fields.Length > 14 && int.TryParse(fields[14], out var qty5)) wp.qty_5 = qty5;
                    wp.unit_6 = fields.Length > 15 ? UnitMatcher(fields[15]) : UnitMatcher(string.Empty);
                    if (fields.Length > 16 && int.TryParse(fields[16], out var qty6)) wp.qty_6 = qty6;
                    imported.Add(wp);

                }

                // Replace existing collection contents
                WavePresets.Clear();
                foreach (var it in imported)
                    WavePresets.Add(it);

                return (imported.Count, null);
            }
            catch (System.Exception ex)
            {
                return (0, ex.Message);
            }
        }

        private Unit UnitMatcher(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var match = Units?.FirstOrDefault(u => u.idName == id);
                if (match != null)
                    return match;
                else
                    return new Unit { idName = id, displayName = id };
            }
            else
            {
                return new Unit { idName = string.Empty, displayName = string.Empty };
            }
        }

        // Very small CSV parser that supports quoted fields and escaped quotes
        private static IEnumerable<string> ParseCsvLine(string line)
        {
            if (line == null) yield break;
            var sb = new StringBuilder();
            bool inQuotes = false;
            for (int i = 0; i < line.Length; i++)
            {
                var c = line[i];
                if (c == '"')
                {
                    if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                    {
                        // escaped quote
                        sb.Append('"');
                        i++; // skip next
                    }
                    else
                    {
                        inQuotes = !inQuotes;
                    }
                }
                else if (c == ',' && !inQuotes)
                {
                    yield return sb.ToString();
                    sb.Clear();
                }
                else
                {
                    sb.Append(c);
                }
            }
            yield return sb.ToString();
        }

        // Create a new WavePreset with the next Id. The DataGrid will add it to the collection when needed.
        public WavePreset CreateNewPreset()
        {
            int maxId = WavePresets.Any() ? WavePresets.Max(item => item.Id) : 0;
            return new WavePreset { Id = maxId + 1 };
        }

        public WaveTemplate CreateNewTemplate()
        {
            int maxId = WaveTemplates.Any() ? WaveTemplates.Max(item => item.Id) : 0;
            return new WaveTemplate { Id = maxId + 1 };
        }

        // Export WaveTemplates to a text file (CSV-style). The View handles prompting for a path.
        public void ExportFlagData(string path)
        {
            using (var writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                writer.WriteLine("Level Name, Wave Number, Week, Required, Medium Waves, Hard Waves, Tags");
                
                for (int i = 0; i < WaveTemplates.Count; i++)
                {
                    string line = "";
                    var tblRow = WaveTemplates[i];
                    if (i == 0)
                    {
                        line += SelectedWaveType + ",";
                    }
                    else
                    {
                        line += ",";
                    }
                    
                    string waveTypes = tblRow.waveType + (!string.IsNullOrEmpty(tblRow.secondaryWaveType) ? "," + tblRow.secondaryWaveType : "") + (!string.IsNullOrEmpty(tblRow.tertiaryWaveType) ? "," + tblRow.tertiaryWaveType : "");
                    line += string.Join(",",
                        tblRow.Id,
                        tblRow.week,
                        Escape(tblRow.reqWaveId),
                        Escape(tblRow.extraWaveId_1),
                        Escape(tblRow.extraWaveId_2),
                        Escape(waveTypes)
                    );
                    writer.WriteLine(line);
                }
            }
        }

        // Export Unit presets to a text file (CSV-style). The View handles prompting for a path.
        public void ExportUnitData(string path)
        {
            using (var writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                writer.WriteLine("Level Name, Wave Preset ID, Mathematical Cumulative Strength, Cumulative Strength, NA, Unit, Qty, Unit, Qty, Unit, Qty, Unit, Qty, Unit, Qty, Unit, Qty");

                for (int i = 0; i < WavePresets.Count; i++)
                {
                    string line = "";
                    var tblRow = WavePresets[i];
                    if (i == 0)
                    {
                        line += SelectedWaveType + ",";
                    }
                    else
                    {
                        line += ",";
                    }

                        line += string.Join(",",
                        tblRow.Id,
                        "",
                        "",
                        "",
                         Escape(tblRow.unit_1.idName), tblRow.qty_1,
                         Escape(tblRow.unit_2.idName), tblRow.qty_2,
                         Escape(tblRow.unit_3.idName), tblRow.qty_3,
                         Escape(tblRow.unit_4.idName), tblRow.qty_4,
                         Escape(tblRow.unit_5.idName), tblRow.qty_5,
                         Escape(tblRow.unit_6.idName), tblRow.qty_6
                    );
                    writer.WriteLine(line);
                }
            }
        }

        // Show a SaveFileDialog, export if the user chooses a path.
        // Returns (exported, errorMessage). If exported is false and errorMessage is null, user cancelled.
        public (bool exported, string? errorMessage) ExportTemplate()
        {
            var dlg = new SaveFileDialog
            {
                FileName = "Wave_templates_" + SelectedWaveType,
                DefaultExt = ".csv",
                Filter = "Comma Seperated Values (.csv)|*.csv|All files (*.*)|*.*"
            };

            bool? result = dlg.ShowDialog();
            if (result != true)
            {
                return (false, null);
            }

            try
            {
                ExportFlagData(dlg.FileName);
                return (true, null);
            }
            catch (System.Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool exported, string? errorMessage) ExportUnit()
        {
            var dlg = new SaveFileDialog
            {
                FileName = "Wave_presets_" + SelectedWaveType,
                DefaultExt = ".csv",
                Filter = "Comma Seperated Values (.csv)|*.csv|All files (*.*)|*.*"
            };

            bool? result = dlg.ShowDialog();
            if (result != true)
            {
                return (false, null);
            }

            try
            {
                ExportUnitData(dlg.FileName);
                return (true, null);
            }
            catch (System.Exception ex)
            {
                return (false, ex.Message);
            }
        }

        private static string Escape(string? s)
        {
            if (s == null) return string.Empty;
            return s.Contains(",") ? '"' + s.Replace("\"", "\"\"") + '"' : s;
        }

        //propertyChanged event
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
