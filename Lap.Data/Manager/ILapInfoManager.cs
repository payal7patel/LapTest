namespace LapAPI.Models
{
    public interface ILapInfoManager
    {
        public FluentValidation.Results.ValidationResult Manage(LapInfo lapInfo);
    }
}