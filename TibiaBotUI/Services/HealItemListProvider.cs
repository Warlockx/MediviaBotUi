using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using MediviaBotUI.Models;
using Newtonsoft.Json;

namespace MediviaBotUI.Services
{
    public static class HealItemListProvider
    {
        public static IEnumerable<HealItem> LoadHealItems()
        {
            Stream fileStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MediviaBotUI.Resources.healitems.json");
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
