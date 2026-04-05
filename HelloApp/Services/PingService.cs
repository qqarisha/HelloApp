namespace HelloApp.Services
{
    public interface IPingService
    {
        public List<DateTime> Pings { set;  get; }
        public void Ping();
        public List<DateTime> GetPings();
    }
    public class PingService: IPingService
    {
        public List<DateTime> Pings { get; set; }

        public PingService()
        {
            Pings = new List<DateTime>();
        }

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
