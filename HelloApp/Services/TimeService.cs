namespace HelloApp.Services
{
    public interface ITimeService
    {
        public DateTime GetTime();
    }
    public class TimeService: ITimeService
    {
        public DateTime GetTime()
        {
            return DateTime.UtcNow;
        }
    }
}
