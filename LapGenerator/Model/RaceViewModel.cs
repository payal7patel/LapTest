using System;
using System.Collections.Generic;

namespace LapGenerator.Model
{
    public partial class RaceViewModel
    {
        public RaceViewModel()
        {
            Races = new HashSet<RaceViewModel>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<RaceViewModel> Races { get; set; }
    }
}
