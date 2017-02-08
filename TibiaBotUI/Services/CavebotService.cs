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
    public class CavebotService
    {
        private readonly CavebotViewModel _cavebotViewModel;

        private Waypoint CurrentWaypoint
        {
            get { return _cavebotViewModel.CurrentWaypoint; }
            set { _cavebotViewModel.CurrentWaypoint = value; }
        }

        #region CavebotVariables
        private bool CavebotEnabled => _cavebotViewModel.CavebotEnabled;
        private ObservableCollection<Waypoint> WaypointList => _cavebotViewModel.WaypointList;
        private int WalkOnFire => _cavebotViewModel.WalkOnFireThreshold;
        private int WalkOnPoison => _cavebotViewModel.WalkOnPoisonThreshold;
        private int WalkOnEnergy => _cavebotViewModel.WalkOnEnergyThreshold;
        #endregion
        public void Start()
        {
            Task.Factory.StartNew(() =>
            {
                while (CavebotEnabled)
                {
                    if (CurrentWaypoint == null)
                        CurrentWaypoint = _cavebotViewModel.WaypointList.First();

                    string debugString = CurrentWaypoint.Type == WaypointType.Action
                        ? $"Id = {CurrentWaypoint.Id} | Waypoint Type action, waiting 1000ms"
                        : $"Id = {CurrentWaypoint.Id} | Walked into {CurrentWaypoint.Location}";

                    Console.WriteLine(debugString);
                    Thread.Sleep(1000);

                    CurrentWaypoint = CurrentWaypoint == WaypointList.Last() ? WaypointList.First() : WaypointList[CurrentWaypoint.Id + 1];
                }

            });
        }



        public CavebotService(CavebotViewModel cavebotViewModel)
        {
            _cavebotViewModel = cavebotViewModel;
        }
    }
}
