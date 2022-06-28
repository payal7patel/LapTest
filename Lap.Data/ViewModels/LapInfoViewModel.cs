using LapAPI.Models;
using System;
using System.Collections.Generic;

namespace LapAPI.ViewModels
{
    public partial class LapInfoViewModel
    {
        public long Id { get; set; }
        public long DriverId { get; set; }
        public string? DriverName { get; set; } = null!;

        public long CarId { get; set; }
        public string? CarNumber { get; set; } = null!;

        public long Time { get; set; }
        public long LapNumber { get; set; }
        public long RaceId { get; set; }
        public string? RaceName { get; set; } = null!;
    }
}
