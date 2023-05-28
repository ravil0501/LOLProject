using System;
using System.Collections.Generic;

namespace LOLProject.Model;

public partial class KeySkill
{
    public string NameSkill { get; set; } = null!;

    public int KeySkill1 { get; set; }

    public int Id { get; set; }

    public virtual Key KeySkill1Navigation { get; set; } = null!;

    public virtual Skill NameSkillNavigation { get; set; } = null!;
}
