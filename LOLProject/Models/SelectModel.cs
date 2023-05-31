using LOLProject.Model;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LOLProject.Models
{
    public class SelectModel
    {
        
        public int selectedValue=1;
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [BindProperty]
        public int SelectedValue
        {
            get
            {
                return this.selectedValue;
            }

            set
            {
                if (value != this.selectedValue)
                {
                    this.selectedValue = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public LolprojectContext Context { get; set; } = new LolprojectContext();

        
    }
}
