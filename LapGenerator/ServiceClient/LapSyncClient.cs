using LapGenerator.Model;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace LapGenerator.ServiceClient
{
    public class LapSyncClient
    {
        private readonly RestClient _restClient;
        private string _url;

        public LapSyncClient()
        {
            _url = "https://localhost:7046/api/Lap";
            _restClient = CreateClient();
        }

        public RestClient CreateClient()
        {
            var client = new RestClient(_url);
            
            return client;
        }

        public List<LapInfoViewModel> GetLaps()
        {
            var request = new RestRequest("", Method.Get);
            var response = _restClient.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                // need to figure how to change the logic here
                throw new Exception("Failed to call the service.");
                //return null;
            };

            var result = JsonConvert.DeserializeObject<List<LapInfoViewModel>>(response.Content);

            return result;
        }
        public List<LapInfoViewModel> GetLapsReport()
        {
            var request = new RestRequest("GetLapsReport", Method.Get);
            var response = _restClient.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                // need to figure how to change the logic here
                throw new Exception("Failed to call the service.");
                //return null;
            };

            var result = JsonConvert.DeserializeObject<List<LapInfoViewModel>>(response.Content);

            return result;
        }
        public LapInfoViewModel GetLapById(int id)
        {
            var request = new RestRequest($"GetLapById?id={id}", Method.Get);

            var response = _restClient.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                // need to figure how to change the logic here
                throw new Exception("Failed to call the service.");
                //return null;
            };

            var result = JsonConvert.DeserializeObject<LapInfoViewModel>(response.Content);

            return result;
        }

        public List<RaceViewModel> GetRaces()
        {
            var request = new RestRequest("GetRaces", Method.Get);
            var response = _restClient.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                // need to figure how to change the logic here
                throw new Exception("Failed to call the service.");
                //return null;
            };

            var result = JsonConvert.DeserializeObject<List<RaceViewModel>>(response.Content);

            return result;
        }

        public List<DriverViewModel> GetDrivers()
        {
            var request = new RestRequest("GetDrivers", Method.Get);
            var response = _restClient.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                // need to figure how to change the logic here
                throw new Exception("Failed to call the service.");
                //return null;
            };

            var result = JsonConvert.DeserializeObject<List<DriverViewModel>>(response.Content);

            return result;
        }

        public List<CarViewModel> GetCars()
        {
            var request = new RestRequest("GetCars", Method.Get);
            var response = _restClient.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                // need to figure how to change the logic here
                throw new Exception("Failed to call the service.");
                //return null;
            };

            var result = JsonConvert.DeserializeObject<List<CarViewModel>>(response.Content);

            return result;
        }
        public string AddLap(LapInfoViewModel lap)
        {
            var request = new RestRequest("",Method.Post);

            var json = JsonConvert.SerializeObject(lap);
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            var response = _restClient.Execute(request);

            var result = JsonConvert.DeserializeObject<ResponseResult<LapInfoViewModel>>(response.Content);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                // need to figure how to change the logic here
                throw new Exception("Failed to call the service.");
                //return null;
            }
            else if (response.StatusCode == HttpStatusCode.OK && !result.IsSuccess)
            {
                return result.Error.ToString();
            }
            return null;
        }
        public void UpdateLap(LapInfoViewModel lap)
        {
            var request = new RestRequest("",Method.Put);

            var json = JsonConvert.SerializeObject(lap);
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            var response = _restClient.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                // need to figure how to change the logic here
                throw new Exception("Failed to call the service.");
                //return null;
            };
        }
    }
}
