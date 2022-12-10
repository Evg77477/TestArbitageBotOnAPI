using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestArbitageBotOnAPI.Entity
{
    public enum SpreadFormulas
    {
        /// <summary>
        /// Price.инстр 1 - Price.инстр 2
        /// </summary>
        Prices_mines,

        /// <summary>
        /// ( А(фьючерс) - А(спот) ) / А(спот)
        /// </summary>
        Percent        
    }
}
