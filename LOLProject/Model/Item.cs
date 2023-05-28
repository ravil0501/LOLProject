using System;
using System.Collections.Generic;

namespace LOLProject.Model;

public partial class Item
{
    public string ItemName { get; set; } = null!;

    public byte[]? ImageItem { get; set; }

    public int? Ad { get; set; }

    public int? Crit { get; set; }

    public int? Ap { get; set; }

    public int? AttackSpeed { get; set; }

    public int? Movement { get; set; }

    public int? Armor { get; set; }

    public int? Hp { get; set; }

    public string? Modificators { get; set; }

    public int Id { get; set; }

    public virtual ICollection<ItemsDifference> ItemsDifferences { get; set; } = new List<ItemsDifference>();
}
