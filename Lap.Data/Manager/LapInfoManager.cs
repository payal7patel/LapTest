using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapAPI.Models
{
    public class LapInfoManager : ILapInfoManager
    {
        private readonly IValidator<LapInfo> _validator;
        public LapInfoManager(IValidator<LapInfo> validator)
        {
            this._validator = validator;
        }

        public FluentValidation.Results.ValidationResult Manage(LapInfo lapInfo)
        {
            return _validator.Validate(lapInfo);
        }
    }
}
