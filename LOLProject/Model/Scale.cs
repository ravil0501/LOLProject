using System;
using System.Collections.Generic;

namespace LOLProject.Model;

public partial class Scale
{
    public string NameHero { get; set; } = null!;

    public double? Damage { get; set; }

    public double? Armor { get; set; }

    public int Id { get; set; }

    public double? Health { get; set; }

    public double? Mana { get; set; }

    public double? ResistMagic { get; set; }

    public virtual Hero NameHeroNavigation { get; set; } = null!;
}
