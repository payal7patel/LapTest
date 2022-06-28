using System;
using System.Collections.Generic;

namespace LapAPI.Models
{
    public partial class Car
    {
        public Car()
        {
            LapInfos = new HashSet<LapInfo>();
        }

        public long Id { get; set; }
        public string Number { get; set; } = null!;

        public virtual ICollection<LapInfo> LapInfos { get; set; }
    }
}
