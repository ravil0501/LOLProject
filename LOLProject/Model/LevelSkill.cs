using System;
using System.Collections.Generic;

namespace LOLProject.Model;

public partial class LevelSkill
{
    public string NameSkill { get; set; } = null!;

    public int LevelSkill1 { get; set; }

    public int? Damageskills { get; set; }

    public int? Modificatorsskills { get; set; }

    public int Id { get; set; }

    public virtual Level LevelSkill1Navigation { get; set; } = null!;

    public virtual Skill NameSkillNavigation { get; set; } = null!;
}
