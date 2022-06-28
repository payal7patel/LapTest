using LapGenerator.Model;
using LapGenerator.ServiceClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LapGenerator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private List<LapInfoViewModel> _laps;
        private LapSyncClient _lapSyncClient;

        public List<LapInfoViewModel> Laps
        {
            get { return _laps; }  
            set { _laps = value; }
        }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _laps = new List<LapInfoViewModel>();
            _lapSyncClient = new LapSyncClient();
        }

        public void OnGet()
        {
            _laps = _lapSyncClient.GetLaps();
        }
    }
}