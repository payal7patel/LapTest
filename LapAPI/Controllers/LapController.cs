using Lap.Data.Mapper;
using Lap.Data.Repositories;
using LapAPI.Models;
using LapAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LapController : ControllerBase
    {
        private readonly ILapRepository _lapRepository;
        private readonly ILapInfoManager _lapInfoManager;
        public LapController(ILapRepository lapRepository, ILapInfoManager lapInfoManager)
        {
            _lapRepository = lapRepository;
            _lapInfoManager = lapInfoManager;
        }

        [HttpGet]
        public IEnumerable<LapInfoViewModel> GetLaps()
        {
            var res = _lapRepository.GetLapInfos();
            return res;
        }

        [Route("GetLapsReport")]
        [HttpGet]
        public IEnumerable<LapInfoViewModel> GetLapsReport()
        {
            var res = _lapRepository.GetLapInfosReport();
            return res;
        }

        [Route("GetLapById")]
        [HttpGet]
        public LapInfoViewModel GetLapById(int id)
        {
            return _lapRepository.GetLapInfoById(id);
        }

        //[HttpPost]
        //public void AddLap(LapInfoViewModel lapInfoViewModel)
        //{
        //    _lapRepository.AddLapInfo(lapInfoViewModel);
        //}

        //[Route("PostWithValidation")]
        [HttpPost]
        public IActionResult AddLap(LapInfoViewModel lapInfoViewModel)
        {
            var result = new ResponseResult<LapInfoViewModel>()
            {
                IsSuccess = false,
                Error = "",
                Result = null
            };

            var dataModel = lapInfoViewModel.ToDataModel();
            var objResult = _lapInfoManager.Manage(dataModel);
            if (objResult.IsValid)
            {
                _lapRepository.AddLapInfo(lapInfoViewModel);
                result = new ResponseResult<LapInfoViewModel>()
                {
                    IsSuccess = true,
                    Error = "",
                    Result = lapInfoViewModel
                };
            }
            else
            {
                string errors = "";
                foreach(var error in objResult.Errors)
                {
                    errors += error + "\n";
                }
                result = new ResponseResult<LapInfoViewModel>()
                {
                    IsSuccess = false,
                    Error = errors,
                    Result = null
                };
            }
            return Ok(result);
        }

        [HttpPut]
        public void UpdateLap(LapInfoViewModel lapInfoViewModel)
        {
            _lapRepository.UpdateLapInfo(lapInfoViewModel);
        }

        [Route("GetRaces")]
        [HttpGet]
        public IEnumerable<RaceViewModel> GetRaces()
        {
            var res = _lapRepository.GetRaces();
            return res;
        }

        [Route("GetDrivers")]
        [HttpGet]
        public IEnumerable<DriverViewModel> GetDrivers()
        {
            var res = _lapRepository.GetDrivers();
            return res;
        }


        [Route("GetCars")]
        [HttpGet]
        public IEnumerable<CarViewModel> GetCars()
        {
            var res = _lapRepository.GetCars();
            return res;
        }


    }
}
