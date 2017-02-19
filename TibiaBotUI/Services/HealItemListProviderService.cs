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
    public static class HealItemListProviderService
    {
        public static IEnumerable<HealItem> LoadHealItems()
        {
            Stream fileStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TibiaBotUI.Resources.HealItems.json");
            if (fileStream == null) return new List<HealItem>();
            try
            {
                StreamReader reader = new StreamReader(fileStream);
                string json = reader.ReadToEnd();

                if (string.IsNullOrWhiteSpace(json)) return new List<HealItem>();

                IEnumerable<HealItem> healItems = JsonConvert.DeserializeObject<IEnumerable<HealItem>>(json);
                reader.Dispose();
                fileStream.Dispose();
                return healItems;
            }
            catch (Exception e)
            {
#if DEBUG
                Console.WriteLine($"{e.Message} at {nameof(LoadHealItems)}.");
#endif
#if RELEASE
                MessageBox.Show($"{e.Message} at {nameof(LoadHealItems)}.");
#endif
            }
            return new List<HealItem>();
        }
    }

}
