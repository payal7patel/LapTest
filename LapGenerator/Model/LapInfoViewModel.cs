using LapGenerator.Helper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LapGenerator.Model
{
    public partial class LapInfoViewModel
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [Required]
        [JsonProperty("driverId")]
        [Range(0,long.MaxValue,ErrorMessage ="Please select Driver")]
        public long DriverId { get; set; }
        public string? DriverName { get; set; } = null!;

        [Required]
        [JsonProperty("carId")]
        [Range(0, long.MaxValue, ErrorMessage = "Please select Car")]
        public long CarId { get; set; }
        public string? CarNumber { get; set; } = null!;


        [JsonProperty("time")]
        public long Time { get; set; }


        [Required(ErrorMessage = "Please enter Lap Number")]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid Lap Number")]
        [JsonProperty("lapNumber")]
        public long? LapNumber { get; set; }
        
        [Required]
        [JsonProperty("raceId")]
        [Range(0, long.MaxValue, ErrorMessage = "Please select Race")]
        public long RaceId { get; set; }
        public string? RaceName { get; set; } = null!;

        private string? _time;
        public string? TimeSpan { get { return Time.ToTimeString(); } }

        [Required(ErrorMessage = "Please enter Lap Time in mm:ss format")]
        public string DatePickerTime { get; set; }
    }
}
