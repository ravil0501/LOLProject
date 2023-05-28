using System;
using System.Collections.Generic;

namespace LOLProject.Model;

public partial class ItemsDifference
{
    public int Id { get; set; }

    public int? IdItem { get; set; }

    public int? IdDiff { get; set; }

    public virtual ItemsDifferent? IdDiffNavigation { get; set; }

    public virtual Item? IdItemNavigation { get; set; }
}
