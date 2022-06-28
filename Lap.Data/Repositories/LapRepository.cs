using LapAPI.Data;
using LapAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lap.Data.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Lap.Data.Repositories
{
    public class LapRepository :ILapRepository
    {
        private readonly LapContext _context;

        public LapRepository(LapContext context)
        {
            _context = context;
        }
        public List<LapInfoViewModel> GetLapInfos()
        {
            var laps = _context.LapInfos.Include(x => x.Car).Include(x => x.Driver).Include(x => x.Race).ToList();
            return laps.ToViewModel();
        }
        public List<LapInfoViewModel> GetLapInfosReport()
        {
            var laps = _context.LapInfos
                       .GroupBy(x => new { x.RaceId, x.DriverId, x.CarId })
                       .Select(x => new LapInfoViewModel()
                       {
                           RaceId=x.Key.RaceId,
                           RaceName = _context.Races.Where(y => y.Id == x.Key.RaceId).FirstOrDefault().Name,
                           DriverId = x.Key.DriverId,
                           CarId = x.Key.CarId,
                           CarNumber = _context.Cars.Where(y => y.Id == x.Key.CarId).FirstOrDefault().Number,
                           DriverName = _context.Drivers.Where(y => y.Id == x.Key.DriverId).FirstOrDefault().Name,
                           Time = x.Sum(y => y.Time) / x.Count()
                       }).OrderBy(x => x.Time).ToList();

            return laps;
        }

        public LapInfoViewModel GetLapInfoById(int id)
        {
            var lap = _context.LapInfos.Where(x => x.Id == id).Include(x => x.Car).Include(x => x.Driver).Include(x => x.Race).FirstOrDefault();
            return lap.ToViewModel();
        }

        public async void AddLapInfo(LapInfoViewModel lapInfoViewModel)
        {
            var dataModel = lapInfoViewModel.ToDataModel();
            _context.LapInfos.Add(dataModel);
            _context.SaveChanges();
        }

        public void UpdateLapInfo(LapInfoViewModel lapInfoViewModel)
        {
            var dataModel = lapInfoViewModel.ToDataModel();
            _context.LapInfos.Update(dataModel);
            _context.SaveChanges();
        }

        public List<RaceViewModel> GetRaces()
        {
            var races = _context.Races.ToList();
            return races.ToViewModel();
        }

        public List<DriverViewModel> GetDrivers()
        {
            var drivers = _context.Drivers.ToList();
            return drivers.ToViewModel();
        }

        public List<CarViewModel> GetCars()
        {
            var cars = _context.Cars.ToList();
            return cars.ToViewModel();
        }
    }
}
