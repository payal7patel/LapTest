using System;
using System.Collections.Generic;

namespace LapGenerator.Model
{
    public partial class CarViewModel
    {
        public CarViewModel()
        {
            Cars = new HashSet<CarViewModel>();
        }

        public long Id { get; set; }
        public string Number { get; set; } = null!;

        public virtual ICollection<CarViewModel> Cars { get; set; }
    }
}
