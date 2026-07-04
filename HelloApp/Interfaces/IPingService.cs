namespace HelloApp.Interfaces
{
    public interface IPingService
    {
        public List<DateTime> Pings { set; get; }

        public void Ping();

        public List<DateTime> GetPings();
    }
}
