using System;
using System.Collections.Generic;

namespace LapAPI.Models
{
    public partial class Driver
    {
        public Driver()
        {
            LapInfos = new HashSet<LapInfo>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<LapInfo> LapInfos { get; set; }
    }
}
