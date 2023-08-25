using System;
using System.Collections.Generic;

namespace ShoppingList.Models;

public partial class ProductDetail
{
    public int ProductDetailId { get; set; }

    public string? ProductId { get; set; }

    public string? ProductBrand { get; set; }

    public string? ProductQuantity { get; set; }

    public string? ProductDetail1 { get; set; }

    public virtual Product ProductDetailNavigation { get; set; } = null!;
}
