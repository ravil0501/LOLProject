using LOLProject.Model;
using Microsoft.AspNetCore.Mvc;

namespace LOLProject.Models
{
    public class ChoosenHero
    {
        public LolprojectContext Context = new LolprojectContext();

        public string NameHero { get; set; } = null!;
        
        public double? Health { get; set; }

        public double? Armor { get; set; }

        public double? Mana { get; set; }

        public double? Ad { get; set; }

        public double? ResistMagic { get; set; }

        public int? LevelHero { get; set; } = 1;

        public double? Crit { get; set; }

        public double? MoveSpeed { get; set; }

        public double? SpeedAttack { get; set; }

        public double? HealthScale { get; set; }

        public double? ArmorScale { get; set; }

        public double? ManaScale { get; set; }

        public double? AdScale { get; set; }

        public string? ItemName { get; set; }

        public double? ResistMagicScale { get; set; }

        public List<string> AddedItems { get; set; } = new List<string>();
    }
}
