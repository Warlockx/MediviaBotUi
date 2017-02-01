using System;
using System.Collections.Generic;
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
        private CavebotViewModel _cavebotViewModel;

        public CavebotService(CavebotViewModel cavebotViewModel)
        {
            _cavebotViewModel = cavebotViewModel;
        }


        public void Start()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    if (!_cavebotViewModel.CavebotEnabled) continue;


                    if (_cavebotViewModel.CurrentWaypoint == null)
                        _cavebotViewModel.CurrentWaypoint = _cavebotViewModel.WaypointList.First();

                    Waypoint currentWaypoint = _cavebotViewModel.CurrentWaypoint;
                    string debugString = currentWaypoint.Type == WaypointType.Action
                        ? $"Id = {currentWaypoint.Id} | Waypoint Type action, waiting 1000ms"
                        : $"Id = {currentWaypoint.Id} | Walked into {currentWaypoint.Location.ToString()}";

                    Console.WriteLine(debugString);
                    Thread.Sleep(1000);

                    _cavebotViewModel.CurrentWaypoint = currentWaypoint == _cavebotViewModel.WaypointList.Last() ? _cavebotViewModel.WaypointList.First() : _cavebotViewModel.WaypointList[currentWaypoint.Id + 1]; 
                }

            });
        }
    }
}
