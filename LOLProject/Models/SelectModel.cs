using LOLProject.Model;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LOLProject.Models
{
    public class SelectModel
    {
        [BindProperty]
        public int selectedValue { get; set; }
        public byte[]? ImageHero { get; set; }
        public LolprojectContext Context { get; set; } = new LolprojectContext();

        
    }
}
