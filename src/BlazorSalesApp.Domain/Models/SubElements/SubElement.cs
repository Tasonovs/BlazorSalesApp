using System.ComponentModel.DataAnnotations.Schema;
using BlazorSalesApp.Domain.Models.Common;
using BlazorSalesApp.Domain.Models.Windows;

namespace BlazorSalesApp.Domain.Models.SubElements;

public class SubElement : BaseEntity
{
    public long WindowId { get; set; }
    [ForeignKey(nameof(WindowId))]
    public Window Window { get; set; }

    public long TypeId { get; set; }
    [ForeignKey(nameof(TypeId))]
    public SubElementTypeLookup Type { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }
}