namespace TestAPI.Models;

public partial class BuildPlace
{
    public int BuildPlaceId { get; set; }

    public int PartId { get; set; }

    public int KitId { get; set; }

    public virtual Kit Kit { get; set; } = null!;

    public virtual Part Part { get; set; } = null!;
}
