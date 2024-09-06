namespace TestAPI.Models;

public partial class BuildPlace
{
    public int BuildPlaceId { get; set; }

    public int PartId { get; set; }

    public Part Part { get; set; }

    public int KitId { get; set; }

    public Kit Kit { get; set; }
}
