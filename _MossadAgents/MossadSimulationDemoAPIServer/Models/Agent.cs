using MossadSimulationDemoAPIServer.ViewModels;

namespace MossadSimulationDemoAPIServer.Models
{
    public class Agent
    {
        public int? Id { get; set; }
        public LocationViewModel? Location { get; set; } = new LocationViewModel();
        public string Nickname { get; set; }
        public string PhotoUrl { get; set; }
    }
}
