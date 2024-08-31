namespace MossadSimulationDemoAPIServer.ViewModels
{
    public class DirectionViewModel
    {
        public string Direction { get; set; }

        public static LocationViewModel ToLocation(DirectionViewModel direction)
        {
            switch (direction.Direction.ToUpper())
            {
                case "N":
                    return new LocationViewModel(0, 1);  // Move up
                case "NE":
                    return new LocationViewModel(1, 1);  // Move up-right
                case "E":
                    return new LocationViewModel(1, 0);  // Move right
                case "SE":
                    return new LocationViewModel(1, -1); // Move down-right
                case "S":
                    return new LocationViewModel(0, -1); // Move down
                case "SW":
                    return new LocationViewModel(-1, -1); // Move down-left
                case "W":
                    return new LocationViewModel(-1, 0);  // Move left
                case "NW":
                    return new LocationViewModel(-1, 1);  // Move up-left
                default:
                    throw new ArgumentException("Invalid direction", nameof(direction));
            }
        }
    }
}
