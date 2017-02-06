using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using TibiaBotUI.Models;

namespace TibiaBotUI.Services
{
    public class SpellListProviderService
    {
        public static IEnumerable<Spell> LoadSpells(string filter)
        {
            string fileLocation = $@"{Directory.GetCurrentDirectory()}\spells.json";
            if (File.Exists(fileLocation))
            {
                try
                {
                    string json = File.ReadAllText(fileLocation);

                    IEnumerable<Spell> spells = JsonConvert.DeserializeObject<IEnumerable<Spell>>(json);

                    return string.IsNullOrEmpty(filter) ? spells : spells.Where(s => s.Type == filter);
                }
                catch (Exception e)
                {
                    MessageBox.Show($"{e.Message} at {nameof(LoadSpells)}.");
                }
            }
            else
            {
                MessageBox.Show($"Error: spell.json couldnt be found at = {fileLocation}.");
            }
            return new List<Spell>();
        }
    }
}
