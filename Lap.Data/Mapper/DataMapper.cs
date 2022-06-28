using LapAPI.Models;
using LapAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lap.Data.Mapper
{
    public static class DataMapper
    {
        public static LapInfoViewModel ToViewModel(this LapInfo dataModel)
        {
            if (dataModel == null)
                return null;

            LapInfoViewModel viewModel = new LapInfoViewModel
            {
                Id = dataModel.Id,
                DriverId = dataModel.DriverId,
                DriverName = dataModel.Driver != null ? dataModel.Driver.Name : "",
                CarId = dataModel.CarId,
                CarNumber = dataModel.Car != null ? dataModel.Car.Number : "",
                Time = dataModel.Time,
                LapNumber = dataModel.LapNumber,
                RaceId = dataModel.RaceId,
                RaceName = dataModel.Race != null ? dataModel.Race.Name : ""
            };
            return viewModel;
        }

        public static List<LapInfoViewModel> ToViewModel(this List<LapInfo> dataModel)
        {
            return dataModel.Select(x => ToViewModel(x)).ToList();
        }

        public static LapInfo ToDataModel(this LapInfoViewModel viewModel)
        {
            if (viewModel == null)
                return null;

            LapInfo dataModel = new LapInfo
            {
                Id = viewModel.Id,
                DriverId = viewModel.DriverId,
                CarId = viewModel.CarId,
                Time = viewModel.Time,
                LapNumber = viewModel.LapNumber,
                RaceId = viewModel.RaceId
            };
            return dataModel;
        }

        public static DriverViewModel ToViewModel(this Driver dataModel)
        {
            if (dataModel == null)
                return null;
            DriverViewModel viewModel = new DriverViewModel
            {
                Id = dataModel.Id,
                Name = dataModel.Name
            };
            return viewModel;
        }

        public static List<DriverViewModel> ToViewModel(this List<Driver> dataModel)
        {
            return dataModel.Select(x => ToViewModel(x)).ToList();
        }

        public static RaceViewModel ToViewModel(this Race dataModel)
        {
            if (dataModel == null)
                return null;
            RaceViewModel viewModel = new RaceViewModel
            {
                Id = dataModel.Id,
                Name = dataModel.Name
            };
            return viewModel;
        }

        public static List<RaceViewModel> ToViewModel(this List<Race> dataModel)
        {
            return dataModel.Select(x => ToViewModel(x)).ToList();
        }

        public static CarViewModel ToViewModel(this Car dataModel)
        {
            if (dataModel == null)
                return null;

            CarViewModel viewModel = new CarViewModel
            {
                Id = dataModel.Id,
                Number = dataModel.Number
            };
            return viewModel;
        }

        public static List<CarViewModel> ToViewModel(this List<Car> dataModel)
        {
            return dataModel.Select(x => ToViewModel(x)).ToList();
        }
    }
}
