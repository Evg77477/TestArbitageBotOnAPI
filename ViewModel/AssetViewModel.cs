using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestArbitageBotOnAPI.ViewModel
{
    public class AssetViewModel : BaseVM
    {
        private string asset;
        public string Asset
        {
            get { return asset; }
            set
            {
                asset = value;
                OnPropertyChanged(nameof(Asset));
            }
        }

        private decimal free;
        public decimal Free
        {
            get { return free; }
            set
            {
                free = value;
                OnPropertyChanged(nameof(Free));
            }
        }

        private decimal locked;
        public decimal Locked
        {
            get { return locked; }
            set
            {
                locked = value;
                OnPropertyChanged(nameof(Locked));
            }
        }
    }
}
