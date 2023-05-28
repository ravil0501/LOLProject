using System;
using System.Collections.Generic;

namespace LOLProject.Model;

public partial class Level
{
    public int LevelSkill { get; set; }

    public virtual ICollection<LevelSkill> LevelSkills { get; set; } = new List<LevelSkill>();
}
