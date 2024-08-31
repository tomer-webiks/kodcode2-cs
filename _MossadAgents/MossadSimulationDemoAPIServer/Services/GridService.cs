using MossadSimulationDemoAPIServer.Models;
using MossadSimulationDemoAPIServer.ViewModels;
using System.Collections.Concurrent;

namespace MossadSimulationDemoAPIServer.Services
{
    public interface IGridService
    {
        public List<Agent> Agents { get;  }
        public List<Target> Targets { get; }
        public List<Mission> Missions { get; }
        public int MaxMatrixX { get; }
        public int MaxMatrixY { get; }
    }

    public class GridService : IGridService
    {
        public List<Agent> Agents { get; } = new List<Agent>();
        public List<Target> Targets { get; } = new List<Target>();
        public List<Mission> Missions { get; } = new List<Mission>();
        public int MaxMatrixX { get; } = 25;
        public int MaxMatrixY { get; } = 25;
    }
}
