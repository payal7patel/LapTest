using LapAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lap.Data.Repositories
{
    public interface ILapRepository
    {
        public List<LapInfoViewModel> GetLapInfos();
        public List<LapInfoViewModel> GetLapInfosReport();
        public LapInfoViewModel GetLapInfoById(int id);
        public void AddLapInfo(LapInfoViewModel lapInfoViewModel);
        public void UpdateLapInfo(LapInfoViewModel lapInfoViewModel);

        public List<RaceViewModel> GetRaces();

        public List<DriverViewModel> GetDrivers();
        public List<CarViewModel> GetCars();
    }
}
