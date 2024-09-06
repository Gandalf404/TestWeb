using System.Text.Json.Serialization;

namespace TestAPI.Models;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public int PartId { get; set; }

    public int KitId { get; set; }

    public DateOnly InvoiceFinishDate { get; set; }

    public string InvoiceStatus { get; set; } = null!;

    public int PartCount { get; set; }

    public int KitCount { get; set; }
}
