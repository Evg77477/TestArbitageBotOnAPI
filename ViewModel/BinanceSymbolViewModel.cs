﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestArbitageBotOnAPI.ViewModel
{
    public class BinanceSymbolViewModel : BaseVM
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



        private decimal priceChangePercent;
        public decimal PriceChangePercent
        {
            get { return priceChangePercent; }
            set
            {
                priceChangePercent = value;
                OnPropertyChanged(nameof(PriceChangePercent));
            }
        }

        private decimal highPrice;
        public decimal HighPrice
        {
            get { return highPrice; }
            set
            {
                highPrice = value;
                OnPropertyChanged(nameof(HighPrice));
            }
        }

        private decimal lowPrice;
        public decimal LowPrice
        {
            get { return lowPrice; }
            set
            {
                lowPrice = value;
                OnPropertyChanged(nameof(LowPrice));
            }
        }

        private decimal volume;
        public decimal Volume
        {
            get { return volume; }
            set
            {
                volume = value;
                OnPropertyChanged(nameof(Volume));
            }
        }

        private decimal tradeAmount;
        public decimal TradeAmount
        {
            get { return tradeAmount; }
            set
            {
                tradeAmount = value;
                OnPropertyChanged(nameof(TradeAmount));
            }
        }

        private decimal tradePrice;
        public decimal TradePrice
        {
            get { return tradePrice; }
            set
            {
                tradePrice = value;
                OnPropertyChanged(nameof(TradePrice));
            }
        }

        public List<OrderSpotVM> SpotOrdersForOpen = new List<OrderSpotVM>();
        public List<OrderSpotVM> SpotOrdersForClose = new List<OrderSpotVM>();

        public ObservableCollection<OrderSpotVM> SpotOrders
        {
            get => _spotOrders;
            set
            {
                _spotOrders = value;
                OnPropertyChanged(nameof(SpotOrders));
            }
        }
        private ObservableCollection<OrderSpotVM> _spotOrders = new ObservableCollection<OrderSpotVM>();

        private ObservableCollection<Position> _spotPositions = new ObservableCollection<Position>();
        public ObservableCollection<Position> SpotPositions
        {
            get => _spotPositions;
            set
            {
                _spotPositions = value;
                OnPropertyChanged(nameof(SpotPositions));
            }
        }


        private ObservableCollection<OrderFuturesVM> _futuresOrders = new ObservableCollection<OrderFuturesVM>();
        public ObservableCollection<OrderFuturesVM> FuturesOrders
        {
            get => _futuresOrders;
            set
            {
                _futuresOrders = value;
                OnPropertyChanged(nameof(FuturesOrders));
            }
        }


        private ObservableCollection<Position> _futuresPositions = new ObservableCollection<Position>();
        public ObservableCollection<Position> FuturesPositions
        {
            get => _futuresPositions;
            set
            {
                _futuresPositions = value;
                OnPropertyChanged(nameof(FuturesPositions));
            }
        }

        public BinanceSymbolViewModel(string symbol, decimal price)
        {
            this._symbol = symbol;
            this._price = price;
        }

        public void AddOrder(OrderSpotVM order)
        {
            SpotOrders.Add(order);
            SpotOrders.OrderByDescending(o => o.Time);
            OnPropertyChanged(nameof(SpotOrders));
        }

        public void AddOrder(OrderFuturesVM order)
        {
            FuturesOrders.Add(order);
            FuturesOrders.OrderByDescending(o => o.CreateTime);
            OnPropertyChanged(nameof(FuturesOrders));
        }

        public void AddPositon(Position position)
        {
            SpotPositions.Add(position);
            SpotPositions.OrderByDescending(o => o.Timestamp); 
            OnPropertyChanged(nameof(SpotPositions));
        }
        
    }
}
