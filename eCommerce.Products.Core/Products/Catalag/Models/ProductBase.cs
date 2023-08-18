using eCommerce.Products.Core.Products.Catalag.Enums;

namespace eCommerce.Products.Core.Products.Catalag.Models;

public abstract class ProductBase
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Category Category { get; set; }
    public BillingType BillingType { get; set; }
    public Status Status { get; set; }

    // TODO: Refactor in a future
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime UpdatedOn { get; set; }
}
