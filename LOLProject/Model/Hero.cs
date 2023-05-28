using System;
using System.Collections.Generic;

namespace LOLProject.Model;

public partial class Hero
{
    public string NameHero { get; set; } = null!;

    public byte[]? ImageHero { get; set; }

    public byte[]? ImageHeroIcon { get; set; }

    public virtual ICollection<BaseScale> BaseScales { get; set; } = new List<BaseScale>();

    public virtual ICollection<Scale> Scales { get; set; } = new List<Scale>();

    public virtual ICollection<SkillHero> SkillHeroes { get; set; } = new List<SkillHero>();
}
