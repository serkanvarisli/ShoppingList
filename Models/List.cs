using System;
using System.Collections.Generic;

namespace ShoppingList.Models;

public partial class List
{
    public int ListId { get; set; }

    public string? ListName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
