using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestArbitageBotOnAPI.ViewModel;

namespace TestArbitageBotOnAPI.Entity
{
    public class Code : BaseVM
    {

        public Code(string code)
        {
            StringCode = code;
        }


        public string StringCode
        {
            get => _stringCode;
            set
            {
                _stringCode = value;
                OnPropertyChanged(nameof(StringCode));
            }
        }
        private string _stringCode = string.Empty;
    }
}
