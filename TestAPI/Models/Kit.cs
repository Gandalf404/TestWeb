namespace TestAPI.Models;

public partial class Kit
{
    public int KitId { get; set; }

    public string KitName { get; set; } = null!;

    public int KitCount { get; set; }

    public DateOnly KitFinishDate { get; set; }

    public virtual ICollection<BuildPlace> BuildPlaces { get; set; } = new List<BuildPlace>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Part> Parts { get; set; } = new List<Part>();
}
