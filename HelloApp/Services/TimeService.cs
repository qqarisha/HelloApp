namespace HelloApp.Services
{
    public class TimeService : ITimeService
    {
        public DateTime GetTime()
        {
            return DateTime.UtcNow;
        }
    }
}