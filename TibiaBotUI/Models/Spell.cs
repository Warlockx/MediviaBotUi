using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TibiaBotUI.Models
{

    public class Spell
    {
        public string Name;
        public string Formula;
        public string[] VocationToCast;
        public string Group;
        public string Type;
        public string Cooldown;
        public string GroupCooldown;
        public int MinimunLevel;
        public int ManaCost;
        public int PriceToLearn;
        public string[] CitiesToLearn;
        public bool PremiumOnly;
        public int SoulPoints;
        public int Charges;
        public string DamageType;

        public Spell(string name, string formula, string[] vocationToCast, string group, string type, string cooldown, string groupCooldown, int minimunLevel, int manaCost, int priceToLearn, string[] citiesToLearn, bool premiumOnly, int soulPoints, int charges, string damageType)
        {
            Name = name;
            Formula = formula;
            VocationToCast = vocationToCast;
            Group = group;
            Type = type;
            Cooldown = cooldown;
            GroupCooldown = groupCooldown;
            MinimunLevel = minimunLevel;
            ManaCost = manaCost;
            PriceToLearn = priceToLearn;
            CitiesToLearn = citiesToLearn;
            PremiumOnly = premiumOnly;
            SoulPoints = soulPoints;
            Charges = charges;
            DamageType = damageType;
        }
    }

}
