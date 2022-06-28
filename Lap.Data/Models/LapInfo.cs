using FluentValidation;
using System;
using System.Collections.Generic;

namespace LapAPI.Models
{
    public partial class LapInfo
    {
        public long Id { get; set; }
        public long DriverId { get; set; }
        public long CarId { get; set; }
        public long Time { get; set; }
        public long LapNumber { get; set; }
        public long RaceId { get; set; }

        public virtual Car Car { get; set; } = null!;
        public virtual Driver Driver { get; set; } = null!;
        public virtual Race Race { get; set; } = null!;
    }

    public class LapInfoValidator : AbstractValidator<LapInfo>
    {
        public LapInfoValidator()
        {
            RuleFor(x => x.DriverId).NotNull().GreaterThan(0).WithMessage("Please select Driver");
            RuleFor(x => x.CarId).NotNull().GreaterThan(0).WithMessage("Please select Car");
            RuleFor(x => x.RaceId).NotNull().GreaterThan(0).WithMessage("Please select Race");
            RuleFor(x => x.LapNumber).NotNull().NotEmpty().GreaterThan(0).WithMessage("Please enter Lap Number");
            RuleFor(x => x.Time).NotNull().NotEmpty().GreaterThan(0).WithMessage("Please enter Time");
            RuleFor(x => x.LapNumber).InclusiveBetween(1, long.MaxValue).WithMessage("Please enter positive Lap Number");

        }
    }
}
