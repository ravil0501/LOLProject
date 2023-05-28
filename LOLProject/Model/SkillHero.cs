using System;
using System.Collections.Generic;

namespace LOLProject.Model;

public partial class SkillHero
{
    public string Nameskill { get; set; } = null!;

    public string NameHero { get; set; } = null!;

    public int Id { get; set; }

    public virtual Hero NameHeroNavigation { get; set; } = null!;

    public virtual Skill NameskillNavigation { get; set; } = null!;
}
