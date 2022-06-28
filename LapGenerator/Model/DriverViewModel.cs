using System;
using System.Collections.Generic;

namespace LapGenerator.Model
{
    public partial class DriverViewModel
    {
        public DriverViewModel()
        {
            Drivers = new HashSet<DriverViewModel>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<DriverViewModel> Drivers { get; set; }
    }
}
