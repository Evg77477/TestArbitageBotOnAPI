using Binance.Net.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestArbitageBotOnAPI.ViewModel
{
    public class OrderSpotVM : BaseVM    
    {
        private long _id;
        public long Id
        {
            get => _id; 
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _symbol;
        public string Symbol
        {
            get => _symbol; 
            set
            {
                _symbol = value;
                OnPropertyChanged(nameof(Symbol));
            }
        }

        private decimal _price;
        public decimal Price
        {
            get => _price; 
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        private decimal _originalQuantity;
        public decimal OriginalQuantity
        {
            get => _originalQuantity; 
            set
            {
                _originalQuantity = value;
                OnPropertyChanged(nameof(OriginalQuantity));
            }
        }

        private decimal _executedQuantity;
        public decimal ExecutedQuantity
        {
            get => _executedQuantity;
            set
            {
                _executedQuantity = value;
                OnPropertyChanged(nameof(ExecutedQuantity));
                OnPropertyChanged(nameof(FullFilled));
            }
        }

        public string FullFilled
        {
            get => ExecutedQuantity + "/" + OriginalQuantity; 
        }

        private OrderStatus _status;
        public OrderStatus Status
        {
            get => _status; 
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
                OnPropertyChanged(nameof(CanCancel));                
            }
        }

        private OrderSide _side;
        public OrderSide Side
        {
            get => _side; 
            set
            {
                _side = value;
                OnPropertyChanged(nameof(Side));
            }
        }

        private SpotOrderType _type;
        public SpotOrderType Type
        {
            get => _type; 
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        private DateTime _time;
        public DateTime Time
        {
            get => _time; 
            set
            {
                _time = value;
                OnPropertyChanged(nameof(Time));
            }
        }

        public bool CanCancel
        {
            get => Status == OrderStatus.New || Status == OrderStatus.PartiallyFilled;
        }
    }
}
