using HelloApp.Interfaces;

namespace HelloApp.Services
{
    public class PingService: IPingService
    {
        public List<DateTime> Pings { get; set; } = new List<DateTime>();

        public void Ping()
        {
            Pings.Add(DateTime.UtcNow);
        }

        public List<DateTime> GetPings()
        {
            return Pings;
        }
    }
}
