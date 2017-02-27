using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MediviaBotUI.Models;
using MediviaBotUI.ViewModels;

namespace MediviaBotUI.Services
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
