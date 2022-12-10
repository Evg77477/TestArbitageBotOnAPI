using Binance.Net.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestArbitageBotOnAPI.ViewModel
{
    public class Position : BaseVM
    {
        public string? Id
        {
            get => _id; 
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        private string _id;

        public string Symbol
        {
            get => _simbol;
            set
            {
                _simbol = value;
                OnPropertyChanged(nameof(Symbol));
            }
        }
        private string _simbol;

        public decimal EntryPrice
        {
            get => _entryPrice;
            set
            {
                _entryPrice = value;
                OnPropertyChanged(nameof(EntryPrice));
            }
        }
        private decimal _entryPrice;

        public int Leverage
        {
            get => _leverrage;
            set
            {
                _leverrage = value;
                OnPropertyChanged(nameof(Leverage));
            }
        }
        private int _leverrage;

        public decimal UnrealizedPnl
        {
            get => _unrealizedPnL;
            set
            {
                _unrealizedPnL = value;
                OnPropertyChanged(nameof(UnrealizedPnl));
            }
        }
        private decimal _unrealizedPnL;

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

        public decimal Quantity
        {
            get => _quantity; 
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
        private decimal _quantity;

        public decimal LiquidationPrice
        {
            get => _liquidationPrice; 
            set
            {
                _liquidationPrice = value;
                OnPropertyChanged(nameof(LiquidationPrice));
            }
        }
        private decimal _liquidationPrice;

        public bool IsAutoAddMargin
        {
            get => _isAutoAddMargin; 
            set
            {
                _isAutoAddMargin = value;
                OnPropertyChanged(nameof(IsAutoAddMargin));
            }
        }
        private bool _isAutoAddMargin;

        public bool Isolated
        {
            get => _isolated; 
            set
            {
                _isolated = value;
                OnPropertyChanged(nameof(Isolated));
            }   
        }
        private bool _isolated;

        public decimal MarkPrice
        {
            get => _markPrice;
            set
            {
                _markPrice = value;
                OnPropertyChanged(nameof(MarkPrice));
            }
        }
        private decimal _markPrice;




    }
}
