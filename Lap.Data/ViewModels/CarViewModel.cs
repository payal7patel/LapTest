using System;
using System.Collections.Generic;

namespace LapAPI.ViewModels
{
    public partial class CarViewModel
    {
        public CarViewModel()
        {
            LapInfos = new HashSet<LapInfoViewModel>();
        }

        public long Id { get; set; }
        public string Number { get; set; } = null!;

        public virtual ICollection<LapInfoViewModel> LapInfos { get; set; }
    }
}
