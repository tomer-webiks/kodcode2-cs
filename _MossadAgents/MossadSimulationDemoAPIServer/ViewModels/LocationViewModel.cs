namespace MossadSimulationDemoAPIServer.ViewModels
{
    //[Owned]
    public class LocationViewModel
    {
        public int X { get; set; }
        public int Y { get; set; }

        public LocationViewModel() { }
        public LocationViewModel(int x, int y) {
            X = x;
            Y = y;
        }
    }
}
