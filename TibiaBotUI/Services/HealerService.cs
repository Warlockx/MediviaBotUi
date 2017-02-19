using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TibiaBotUI.Models;
using TibiaBotUI.ViewModels;

namespace TibiaBotUI.Services
{
    public class HealerService
    {
        private readonly HealerViewModel _healerViewModel;

        #region HealerVariables
        private bool HealerEnabled => _healerViewModel.HealerEnabled;
        private ObservableCollection<HealerRule> SpellHealerRules => _healerViewModel.SpellHealerRules;
        private ObservableCollection<HealerRule> ItemHealerRules => _healerViewModel.ItemHealerRules;
        #endregion
        public void Start()
        {
            Task.Factory.StartNew(() =>
            {
                while (HealerEnabled)
                {
                   //do healer stuff
                }

            });
        }

        public HealerService(HealerViewModel healerViewModel)
        {
            _healerViewModel = healerViewModel;
        }
    }
}
