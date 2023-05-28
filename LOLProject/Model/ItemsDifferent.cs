using System;
using System.Collections.Generic;

namespace LOLProject.Model;

public partial class ItemsDifferent
{
    public string? ItemsDiff { get; set; }

    public int Id { get; set; }

    public virtual ICollection<ItemsDifference> ItemsDifferences { get; set; } = new List<ItemsDifference>();
}
