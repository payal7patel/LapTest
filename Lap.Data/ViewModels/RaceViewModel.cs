using System;
using System.Collections.Generic;

namespace LapAPI.ViewModels
{
    public partial class RaceViewModel
    {
        public RaceViewModel()
        {
            LapInfos = new HashSet<LapInfoViewModel>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<LapInfoViewModel> LapInfos { get; set; }
    }
}
