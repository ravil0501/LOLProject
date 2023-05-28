using System;
using System.Collections.Generic;

namespace LOLProject.Model;

public partial class Key
{
    public int IdKeys { get; set; }

    public string KeySkill { get; set; } = null!;

    public virtual ICollection<KeySkill> KeySkills { get; set; } = new List<KeySkill>();
}
