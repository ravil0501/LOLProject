using System;
using System.Collections.Generic;

namespace LOLProject.Model;

public partial class Skill
{
    public string NameSkills { get; set; } = null!;

    public string? Opisanie { get; set; }

    public byte[]? ImageSkill { get; set; }

    public int Id { get; set; }

    public virtual ICollection<KeySkill> KeySkills { get; set; } = new List<KeySkill>();

    public virtual ICollection<LevelSkill> LevelSkills { get; set; } = new List<LevelSkill>();

    public virtual ICollection<SkillHero> SkillHeroes { get; set; } = new List<SkillHero>();
}
