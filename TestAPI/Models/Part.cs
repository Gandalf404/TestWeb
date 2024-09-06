namespace TestAPI.Models;

public partial class Part
{
    public int PartId { get; set; }

    public string PartName { get; set; } = null!;

    public int PartCount { get; set; }

    public DateOnly PartFinishDate { get; set; }

    public int KitId { get; set; }

    public Kit Kit { get; set; }

    public List<BuildPlace> BuildPlaces { get; set; } = new List<BuildPlace>();

    public List<Invoice> Invoices { get; set; } = new List<Invoice>();
}
