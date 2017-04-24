using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MediviaBotUI.Models;
using Newtonsoft.Json;

namespace MediviaBotUI.Services
{
    public class MonsterListProvider
    {
        public static IEnumerable<Monster> LoadMonsters()
        {
            Stream fileStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MediviaBotUI.Resources.monsters.json");
            if (fileStream == null) return new List<Monster>();
            try
            {
                StreamReader reader = new StreamReader(fileStream);
                string json = reader.ReadToEnd();

                if (string.IsNullOrWhiteSpace(json)) return new List<Monster>();

                IEnumerable<Monster> monsters = JsonConvert.DeserializeObject<IEnumerable<Monster>>(json);
                reader.Dispose();
                fileStream.Dispose();

                return monsters;
            }
            catch (Exception e)
            {
#if DEBUG
                Console.WriteLine($"{e.Message} at {nameof(LoadMonsters)}.");
#endif
#if RELEASE
                MessageBox.Show($"{e.Message} at {nameof(LoadMonsters)}.");
#endif
            }
            return new List<Monster>();
        }
    }
}
