using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MediviaBotUI.Models
{
    public class MonsterAbility
    {
        public string Name { get; }
        public int MinRange { get; }
        public int MaxRange { get; }

        [JsonConstructor]
        public MonsterAbility(string name, int minRange, int maxRange)
        {
            Name = name;
            MinRange = minRange;
            MaxRange = maxRange;
        }

        public MonsterAbility(string name)
        {
            Name = name;
        }
    }
}
