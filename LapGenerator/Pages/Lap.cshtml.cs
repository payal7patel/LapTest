using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LapGenerator.Model;
using LapGenerator.ServiceClient;
using Microsoft.AspNetCore.Mvc.Rendering;
using LapGenerator.Helper;

namespace LapGenerator.Pages
{
    public class LapModel : PageModel
    {
        private SelectList _races;
        private SelectList _drivers;
        private SelectList _cars;
        private LapSyncClient _lapSyncClient;

        public SelectList Races
        {
            get { return _races; }
            set { _races = value; }
        }

        public SelectList Drivers
        {
            get { return _drivers; }
            set { _drivers = value; }
        }
        public SelectList Cars
        {
            get { return _cars; }
            set { _cars = value; }
        }

        public string Errors
        { get; set; }

        [BindProperty]
        public LapInfoViewModel LapData
        {
            get;
            set;
        }
        public LapModel()
        {
            _lapSyncClient = new LapSyncClient();
        }

        public IActionResult OnGet(int? id)
        {
            BindDropdowns();
            if(id.HasValue && id > 0)
            {
                //Create get with id
               
                LapData = _lapSyncClient.GetLapById(id.Value);
                LapData.DatePickerTime = LapData.TimeSpan;
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                BindDropdowns();

                return Page();
            }
            LapData.Time = LapData.DatePickerTime.ToLong();

            if (LapData.Id > 0)
                _lapSyncClient.UpdateLap(LapData);
            else
            {
                LapData.Id = 0;
                var errors = _lapSyncClient.AddLap(LapData);
                if (!string.IsNullOrEmpty(errors))
                {
                    Errors = errors;
                    BindDropdowns();
                    return Page();
                }
            }
            return RedirectToPage("./Index");
        }

        private void BindDropdowns()
        {
            Races = new SelectList(_lapSyncClient.GetRaces(), "Id", "Name", -1);
            Drivers = new SelectList(_lapSyncClient.GetDrivers(), "Id", "Name", -1);
            Cars = new SelectList(_lapSyncClient.GetCars(), "Id", "Number", -1);
        }
    }
}
