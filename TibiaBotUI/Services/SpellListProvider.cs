using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using MediviaBotUI.Models;
using Newtonsoft.Json;

namespace MediviaBotUI.Services
{
    public static class SpellListProvider
    {
        public static IEnumerable<Spell> LoadSpells(string filter)
        {
            Stream fileStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MediviaBotUI.Resources.spells.json");
            if (fileStream == null) return new List<Spell>();
            try
            {
                StreamReader reader = new StreamReader(fileStream);
                string json = reader.ReadToEnd();

                if (string.IsNullOrWhiteSpace(json)) return new List<Spell>();

                IEnumerable<Spell> spells = JsonConvert.DeserializeObject<IEnumerable<Spell>>(json);
                reader.Dispose();
                fileStream.Dispose();
                
                return spells.Where(s=> s.Type.Equals(filter));
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
