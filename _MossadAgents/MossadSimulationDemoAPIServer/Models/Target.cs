using MossadSimulationDemoAPIServer.ViewModels;

namespace MossadSimulationDemoAPIServer.Models
{
    public class Target
    {
        public int? Id { get; set; }
        public LocationViewModel? Location { get; set; } = new LocationViewModel();
        public string Name { get; set; }
        public string Position { get; set; }
        public string PhotoUrl { get; set; }
    }
}
