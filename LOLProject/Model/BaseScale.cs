using System;
using System.Collections.Generic;

namespace LOLProject.Model;

public partial class BaseScale
{
    public string? NameHero { get; set; }

    public double? Health { get; set; }

    public double? Armor { get; set; }

    public double? Man { get; set; }

    public double? Ad { get; set; }

    public double? ResistMagic { get; set; }

    public double? Crit { get; set; }

    public double? MoveSpeed { get; set; }

    public double? SpeedAttack { get; set; }

    public int Id { get; set; }

    public virtual Hero? NameHeroNavigation { get; set; }
}
