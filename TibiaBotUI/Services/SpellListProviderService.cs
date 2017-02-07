using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using TibiaBotUI.Models;

namespace TibiaBotUI.Services
{
    public static class SpellListProviderService
    {
        public static IEnumerable<Spell> LoadSpells(SpellGroup filter)
        {
            Stream fileStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TibiaBotUI.Resources.spells.json");
            if (fileStream == null) return new List<Spell>();
            try
            {
                StreamReader reader = new StreamReader(fileStream);
                string json = reader.ReadToEnd();

                if (string.IsNullOrWhiteSpace(json)) return new List<Spell>();

                IEnumerable<Spell> spells = JsonConvert.DeserializeObject<IEnumerable<Spell>>(json);
                reader.Dispose();
                fileStream.Dispose();
                return string.IsNullOrEmpty(filter.ToString())
                    ? spells
                    : spells.Where(s => s.Group == filter.ToString());
            }
            catch (Exception e)
            {
#if DEBUG
                Console.WriteLine($"{e.Message} at {nameof(LoadSpells)}.");
#endif
#if RELEASE
                MessageBox.Show($"{e.Message} at {nameof(LoadSpells)}.");
#endif
            }
            return new List<Spell>();
        }
    }

}
