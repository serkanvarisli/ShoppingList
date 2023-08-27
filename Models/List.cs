using System;
using System.Collections.Generic;

namespace ShoppingList.Models;

public partial class List
{
    public int ListId { get; set; }

    public int UserId { get; set; }

    public string? ListName { get; set; }

    public virtual User User { get; set; } = null!;
}
