using Binance.Net.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestArbitageBotOnAPI.ViewModel
{
    public class OrderFuturesVM : BaseVM
    {
        
        public string Symbol
        {
            get => _symbol;
            set
            {
                _symbol = value;
                OnPropertyChanged(nameof(Symbol));
            }
        }
        private string _symbol;

        public string Pair
        {
            get => _pair;
            set
            {
                _pair = value;
                OnPropertyChanged(nameof(Pair));
            }
        }
        private string _pair;


        
        public long Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        private long _id;

        public string ClientOrderId
        {
            get => _clientOrderId;
            set
            {
                _clientOrderId = value;
                OnPropertyChanged(nameof(ClientOrderId));
            }
        }
        private string _clientOrderId;

                
        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        private decimal _price;


        public decimal AvgPrice
        {
            get => _avgPrice;
            set
            {
                _avgPrice = value;
                OnPropertyChanged(nameof(AvgPrice));
            }
        }
        private decimal _avgPrice;

        public decimal QuantityFilled
        {
            get => _quantityFilled;
            set
            {
                _quantityFilled = value;
                OnPropertyChanged(nameof(QuantityFilled));
            }
        }
        private decimal _quantityFilled;

        public decimal? QuoteQuantityFilled
        {
            get => _quoteQuantityFilled;
            set
            {
                _quoteQuantityFilled = value;
                OnPropertyChanged(nameof(QuoteQuantityFilled));
            }
        }
        private decimal? _quoteQuantityFilled;

               
        public decimal LastFilledQuantity
        {
            get => _lastFilledQuantity;
            set
            {
                _lastFilledQuantity = value;
                OnPropertyChanged(nameof(LastFilledQuantity));
            }
        }
        private decimal _lastFilledQuantity;

        
        public decimal Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
                //OnPropertyChanged(nameof(FullFilled));
            }
        }
        private decimal _quantity;

        public bool ReduceOnly
        {
            get => _reduceOnly;
            set
            {
                _reduceOnly = value;
                OnPropertyChanged(nameof(ReduceOnly));
            }
        }
        private bool _reduceOnly;

        public bool ClosePosition
        {
            get => _closePosition;
            set
            {
                _closePosition = value;
                OnPropertyChanged(nameof(ClosePosition));
            }
        }
        private bool _closePosition;

        
        public OrderSide Side
        {
            get => _side;
            set
            {
                _side = value;
                OnPropertyChanged(nameof(Side));
            }
        }
        private OrderSide _side;

        
        public OrderStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
                //OnPropertyChanged(nameof(CanCancel));
            }
        }
        private OrderStatus _status;

        public decimal? StopPrice
        {
            get => _stopPrice;
            set
            {
                _stopPrice = value;
                OnPropertyChanged(nameof(StopPrice));
            }
        }
        private decimal? _stopPrice;


        public TimeInForce TimeInForce
        {
            get => _timeInForce;
            set
            {
                _timeInForce = value;
                OnPropertyChanged(nameof(TimeInForce));
            }
        }
        private TimeInForce _timeInForce;

                        
        public FuturesOrderType Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
        private FuturesOrderType _type;

        public decimal? ActivatePrice
        {
            get => _activatePrice;
            set
            {
                _activatePrice = value;
                OnPropertyChanged(nameof(ActivatePrice));
            }
        }
        private decimal? _activatePrice;

        public DateTime CreateTime
        {
            get => _createTime;
            set
            {
                _createTime = value;
                OnPropertyChanged(nameof(CreateTime));
            }
        }
        private DateTime _createTime;

        public WorkingType WorkingType
        {
            get => _workingType; 
            set
            {
                _workingType = value;
                OnPropertyChanged(nameof(WorkingType));
            }
        }
        private WorkingType _workingType;

        public PositionSide PositionSide
        {
            get => _positionSide; 
            set
            {
                _positionSide = value;
                OnPropertyChanged(nameof(PositionSide));
            }   
        }
        private PositionSide _positionSide;

        public bool PriceProtect
        {
            get => _priceProtect; 
            set
            {
                _priceProtect = value;
                OnPropertyChanged(nameof(PriceProtect));
            }
        }
        private bool _priceProtect;









    }
}
