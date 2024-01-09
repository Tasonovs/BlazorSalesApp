using System.ComponentModel.DataAnnotations;

namespace BlazorSalesApp.Domain.Models.Common;

public class BaseLookupEntity : BaseEntity
{
    [Required]
    [MaxLength(255)]
    public string Label { get; set; }
}
