using System.Drawing;

namespace LOLProject.Models
{
    public class AddItemModel
    {
        public string ItemName { get; set; } = null!;

        public byte[]? ImageItem { get; set; }

        public IFormFile? image { get; set; }

        public int? Ad { get; set; }

        public int? Crit { get; set; }

        public int? Ap { get; set; }

        public int? AttackSpeed { get; set; }

        public int? Movement { get; set; }

        public int? Armor { get; set; }

        public int? Hp { get; set; }

        public string? Modificators { get; set; }

        public int IdDiff { get; set; }

        public string? Error { get; set; }

        public int? ErrorCount { get; set; }
    }
}
