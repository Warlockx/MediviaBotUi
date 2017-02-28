using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MediviaBotUI.Models
{
    public class Monster
    {
        [JsonIgnore]
        public string ImageUrl { get; }
        public string Name { get; }
        public int Experience { get; }
        public int Hitpoints { get; }
        public int SummonCost { get; set; }
        public int ConvinceCost { get; set; }
        public IEnumerable<MonsterAbility> Abilities { get; set; }
        public bool Pushable { get; set; }
        public bool CanPushObjects { get; set; }
        public IEnumerable<Element> CanWalkOn { get; set; }
        public IEnumerable<DamageElement> Immunities { get; set; }
        public IEnumerable<DamageElement> NeutralTo { get; set; }
        public int DamagePerTurn { get; set; }
        public IEnumerable<string> Sounds { get; set; }
        public string Notes { get; set; }
        public IEnumerable<string> WhereToFind { get; set; }
        public string Strategy { get; set; }
        public IEnumerable<Loot> Loot { get; set; }

        public Monster(string imageUrl, string name, int experience, int hitpoints, int summonCost, int convinceCost, IEnumerable<MonsterAbility> abilities, bool pushable, bool canPushObjects, IEnumerable<Element> canWalkOn, IEnumerable<DamageElement> immunities, IEnumerable<DamageElement> neutralTo, int damagePerTurn, IEnumerable<string> sounds, string notes, IEnumerable<string> whereToFind, string strategy, IEnumerable<Loot> loot)
        {
            ImageUrl = imageUrl;
            Name = name;
            Experience = experience;
            Hitpoints = hitpoints;
            SummonCost = summonCost;
            ConvinceCost = convinceCost;
            Abilities = abilities;
            Pushable = pushable;
            CanPushObjects = canPushObjects;
            CanWalkOn = canWalkOn;
            Immunities = immunities;
            NeutralTo = neutralTo;
            DamagePerTurn = damagePerTurn;
            Sounds = sounds;
            Notes = notes;
            WhereToFind = whereToFind;
            Strategy = strategy;
            Loot = loot;
        }
    }
}
