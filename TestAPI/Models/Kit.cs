namespace TestAPI.Models;

public partial class Kit
{
    public int KitId { get; set; }

    public string KitName { get; set; } = null!;

    public int KitCount { get; set; }

    public DateOnly KitFinishDate { get; set; }

    public List<Part> Parts { get; set; } = new List<Part>();

    public List<BuildPlace> BuildPlaces { get; set; } = new List<BuildPlace>();

    public List<Invoice> Invoices { get; set; } = new List<Invoice>();
}
