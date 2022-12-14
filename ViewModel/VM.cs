using Binance.Net.Clients;
using Binance.Net.Enums;
using Binance.Net.Objects;
using Binance.Net.Objects.Models.Spot.Socket;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.CommonObjects;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using TestArbitageBotOnAPI.Commands;
using TestArbitageBotOnAPI.Entity;
using TestArbitageBotOnAPI.UserControl;
using static TestArbitageBotOnAPI.ViewModel.VM;


namespace TestArbitageBotOnAPI.ViewModel
{
    public class VM : BaseVM
    {
        public VM() 
        {
            messageBoxService = new MessageBoxService();
            orderLock = new object();
        }

        #region Properties =========================================

        #region Bot Setting Properties ===========


        /// <summary>
        /// Режим работы бота
        /// </summary>
        public Regims Regim
        {
            get => _regim;
            set
            {
                _regim = value;
                OnPropertyChanged(nameof(Regim));
            }
        }
        private Regims _regim;


        public List<Regims> BotRegim { get; set; } = new List<Regims>()
        {
            Regims.ON, Regims.ONLI_CLOSE
        };

        /// <summary>
        /// Обычный спред для выбранной пары инструментов
        /// </summary>
        public decimal BaseSpread
        {
            get => _baseSpread;
            set
            {
                _baseSpread = value;
                OnPropertyChanged(nameof(BaseSpread));
            }
        }
        private decimal _baseSpread;


        /// <summary>
        /// Спред, при котором бот должен открыть позиции
        /// </summary>
        public decimal SpreadForTrade
        {
            get => _spreadForTrade;
            set
            {
                _spreadForTrade = value;
                OnPropertyChanged(nameof(SpreadForTrade));
            }
        }
        private decimal _spreadForTrade;

        /// <summary>
        /// Объем для одной сделки
        /// </summary>
        public decimal Lot
        {
            get => _lot;
            set
            {
                _lot = value;
                OnPropertyChanged(nameof(Lot));
            }
        }
        private decimal _lot;

        /// <summary>
        /// Выбрать или задать формулу расчета спреда (варианты: разница цен (Price 1 - Price 2); 
        /// в процентах (Price(future) - Price(spot)) * 100 / Price(spot)
        /// </summary>
        public SpreadFormulas Formula
        {
            get => _formula;
            set
            {
                _formula = value;
                OnPropertyChanged(nameof(Formula));
            }
        }
        private SpreadFormulas _formula;

        public List<SpreadFormulas> Formulas { get; set; } = new List<SpreadFormulas>()
        {
            SpreadFormulas.DeltaPrices, SpreadFormulas.Percent
        };


        /// <summary>
        /// Изменение в процентах спреда, при котором бот открыл позиции. 
        /// При достижении указанного изменения бот открывает дополнительные позиции.
        /// </summary>
        public decimal SpreadForNewTrade
        {
            get => _spreadForNewTrade;
            set
            {
                _spreadForNewTrade = value;
                OnPropertyChanged(nameof(SpreadForNewTrade));
            }
        }
        private decimal _spreadForNewTrade;

        #endregion ============


        #region Futures Properties =======================

        public ObservableCollection<BinanceSymbolViewModel> AllSecurityesFutures
        {
            get => _allSecurityesFutures;
            set
            {
                _allSecurityesFutures = value;
                //if (AllSecurityes != null)
                //{
                //    AllSecurityes.Clear();
                //}

                AllSecurityes = AllSecurityesFutures;
                OnPropertyChanged(nameof(AllSecurityesFutures));
                OnPropertyChanged(nameof(AllSecurityes));


            }
        }
        private ObservableCollection<BinanceSymbolViewModel> _allSecurityesFutures;


        public BinanceSymbolViewModel SelectedFuturesSymbol
        {
            get => _selectedFuturesSymbol;
            set
            {
                _selectedFuturesSymbol = value;
                OnPropertyChanged(nameof(SelectedFuturesSymbol));
            }
        }
        private BinanceSymbolViewModel _selectedFuturesSymbol;


        public int PositonsFuturesCount
        {
            get => _positonsFuturesCount;
            set
            {
                _positonsFuturesCount = value;
                OnPropertyChanged(nameof(PositonsFuturesCount));
            }
        }
        private int _positonsFuturesCount;

        public PositionSide PositonsFuturesSide
        {
            get => _positonsFuturesSide;
            set
            {
                _positonsFuturesSide = value;
                OnPropertyChanged(nameof(PositonsFuturesSide));
            }
        }
        private PositionSide _positonsFuturesSide = PositionSide.Non;

        public decimal FuturesEntryPrice
        {
            get => _futuresEntryPrice;
            set
            {
                _futuresEntryPrice = value;
                OnPropertyChanged(nameof(FuturesEntryPrice));
            }
        }
        private decimal _futuresEntryPrice;

        public decimal PositionFuturesQuantity
        {
            get => _positionFuturesQuantity;
            set
            {
                _positionFuturesQuantity = value;
                OnPropertyChanged(nameof(PositionFuturesQuantity));
            }
        }
        private decimal _positionFuturesQuantity;

        public decimal PositionFuturesMargin
        {
            get => _positionFuturesMargin;
            set
            {
                _positionFuturesMargin = value;
                OnPropertyChanged(nameof(PositionFuturesMargin));
            }
        }
        private decimal _positionFuturesMargin;

        #endregion =========


        public bool IsRun
        {
            get => _isRun;
            set
            {
                _isRun = value;
                if (IsRun)
                {
                    IsReadOnly = true;
                }
                else
                {
                    IsReadOnly = false;
                }
                OnPropertyChanged(nameof(IsRun));
               
            }
        }
        private bool _isRun = false;

        public bool IsReadOnly
        {
            get => _isReadOnly;
            set
            {
                _isReadOnly = value;
                OnPropertyChanged(nameof(IsReadOnly));
            }
        }
        private bool _isReadOnly = false;


        public string StateOfConnect
        {
            get => _stateOfConnect;
            set
            {
                _stateOfConnect = value;
                OnPropertyChanged(nameof(StateOfConnect));
            }
        }
        private string _stateOfConnect = "Disconnect";


        public string ApiKey
        {
            get => apiKey;
            set
            {
                apiKey = value;
                OnPropertyChanged(nameof(ApiKey));
                //RaisePropertyChangedEvent("CredentialsEntered");
            }
        }
        private string apiKey;


        public string ApiSecret
        {
            get => apiSecret;
            set
            {
                apiSecret = value;
                OnPropertyChanged(nameof(ApiSecret));
                //RaisePropertyChangedEvent("CredentialsEntered");
            }
        }
        private string apiSecret;



        private ObservableCollection<AssetViewModel> _assets;
        public ObservableCollection<AssetViewModel> Assets
        {
            get => _assets; 
            set
            {
                _assets = value;
                OnPropertyChanged(nameof(Assets));
            }
        }

        public BinanceSymbolViewModel SelectedSpotSymbol
        {
            get => _selectedSpotSymbol; 
            set
            {
                _selectedSpotSymbol = value;                
                OnPropertyChanged(nameof(SelectedSpotSymbol));
            }
        }
        private BinanceSymbolViewModel _selectedSpotSymbol;

       
        public ObservableCollection<BinanceSymbolViewModel> AllSecurityes
        {
            get => _allSecurityes;
            set
            {
               _allSecurityes = value;
                OnPropertyChanged(nameof(AllSecurityes));
            }
        }
        private ObservableCollection<BinanceSymbolViewModel> _allSecurityes;

        public ObservableCollection<BinanceSymbolViewModel> AllSecurityesSpot
        {
            get => _allSecurityesSpot;
            set
            {
                _allSecurityesSpot = value;
                //if (AllSecurityes != null)
                //{
                //    AllSecurityes.Clear();
                //}
               
                AllSecurityes = AllSecurityesSpot;
                OnPropertyChanged(nameof(AllSecurityesSpot));
                OnPropertyChanged(nameof(AllSecurityes));

            }
        }
        private ObservableCollection<BinanceSymbolViewModel> _allSecurityesSpot;

       
        public BinanceSymbolViewModel SelectedSymbol
        {
            get => _selectedSymbol;
            set
            {
                _selectedSymbol = value;                
                OnPropertyChanged(nameof(SelectedSymbol));

                if (TypeOff == "Spot")
                {
                    SelectedSpotSymbol = SelectedSymbol;
                    OnPropertyChanged(nameof(SelectedSpotSymbol));
                }
                else if (TypeOff == "Futures")
                {
                    SelectedFuturesSymbol = SelectedSymbol;
                }

                

            }
        }
        private BinanceSymbolViewModel _selectedSymbol;

        public string TypeOff
        {
            get => _typeOff;
            set
            {
                _typeOff = value;
                OnPropertyChanged(nameof(TypeOff));

                if (TypeOff != null)
                {
                    GetSecurities();
                }
            }
        }
        private string _typeOff;

        public decimal Spread
        {
            get => _spread;
            set
            {
                _spread = value;
                ChangeSpread?.Invoke(_spread);
                OnPropertyChanged(nameof(Spread));
            }
        }
        private decimal _spread;


        #endregion ================


        #region Fields =========================================

        private ApiSetting settings;

        private Emitents wind;

        private IMessageBoxService messageBoxService;

        private BinanceSocketClient socketClientSpot;

        private BinanceSocketClient socketClientFutures;        

        private object orderLock;

        /// <summary>
        /// Спред, при котором открылась позиция
        /// </summary>
        private decimal _tradeSpread;



        #endregion ================


        #region Commands =========================================

        private DelegateCommand commandSetApi;
        public DelegateCommand CommandSetApi
        {
            get
            {
                if (commandSetApi == null)
                {
                    commandSetApi = new DelegateCommand(SetApi);
                }
                return commandSetApi;
            }
        }


        private DelegateCommand commandConnect;
        public DelegateCommand CommandConnect
        {
            get
            {
                if (commandConnect == null)
                {
                    commandConnect = new DelegateCommand(Connect);
                }
                return commandConnect;
            }
        }

        private DelegateCommand commandStartStop;
        public DelegateCommand CommandStartStop
        {
            get
            {
                if (commandStartStop == null)
                {
                    commandStartStop = new DelegateCommand(StartStop);
                }
                return commandStartStop;
            }
        }

        private DelegateCommand _commandSelectSpotSecurity;
        public DelegateCommand CommandSelectSpotSecurity
        {
            get
            {
                if (_commandSelectSpotSecurity == null)
                {                   
                    _commandSelectSpotSecurity = new DelegateCommand(SelectSpotSecurity);                   
                }
                return _commandSelectSpotSecurity;
            }
        }

        private DelegateCommand _commandSelectFuturesSecurity;
        public DelegateCommand CommandSelectFuturesSecurity
        {
            get
            {
                if (_commandSelectFuturesSecurity == null)
                {                    
                    _commandSelectFuturesSecurity = new DelegateCommand(SelectFuturesSecurity);                   
                }
                return _commandSelectFuturesSecurity;
            }
        }


        #endregion ================


        #region Methods =========================================

        #region BaseLogic ===========

        private void SelectSpotSecurity(object obj)
        {
            if (IsRun)
            {
                MessageBoxResult result = MessageBox.Show("Бот запущен!\nВсе равно сменить инструмент?",
                    "Внимание!", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.No) return;
            }

            TypeOff = "Spot";
            OnPropertyChanged(nameof(TypeOff));
            wind = new Emitents(this);

            wind.ShowDialog();
        }

        private void SelectFuturesSecurity(object obj)
        {
            if (IsRun)
            {
                MessageBoxResult result = MessageBox.Show("Бот запущен!\nВсе равно сменить инструмент?",
                    "Внимание!", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.No) return;
            }

            TypeOff = "Futures";
            OnPropertyChanged(nameof(TypeOff));
            wind = new Emitents(this);

            wind.ShowDialog();
        }

        private async Task GetSecurities()
        {
            using (var client = new BinanceClient())
            {
                if (TypeOff == "Spot")
                {
                    var spotResult = await client.SpotApi.ExchangeData.GetPricesAsync();
                    if (spotResult.Success)
                    {
                        AllSecurityesSpot = new ObservableCollection<BinanceSymbolViewModel>(spotResult.Data.Select(r => new BinanceSymbolViewModel(r.Symbol, r.Price)).ToList());
                        await GetSpotInfo();
                    }
                    else
                    {
                        messageBoxService.ShowMessage($"Error requesting data: {spotResult.Error.Message}", 
                            "error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else if (TypeOff == "Futures")
                {
                    var futuresResult = await client.UsdFuturesApi.ExchangeData.GetPricesAsync();
                    if (futuresResult.Success)
                    {
                        AllSecurityesFutures = new ObservableCollection<BinanceSymbolViewModel>(futuresResult.Data.Select(r => new BinanceSymbolViewModel(r.Symbol, r.Price)).ToList());
                        await GetFuturesInfo();
                    }
                    else
                    {
                        messageBoxService.ShowMessage($"Error requesting data: {futuresResult.Error.Message}", 
                            "error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private async Task GetSpotInfo()
        {
            socketClientSpot = new BinanceSocketClient();

            var subscribeResult = await socketClientSpot.SpotStreams.SubscribeToAllTickerUpdatesAsync(data =>
            {
                foreach (var ud in data.Data)
                {
                    var symbol = AllSecurityesSpot.SingleOrDefault(p => p.Symbol == ud.Symbol);
                    if (symbol != null)
                        symbol.Price = ud.LastPrice;
                }
            });

            if (!subscribeResult.Success)
                messageBoxService.ShowMessage($"Failed to subscribe to price updates: {subscribeResult.Error}",
                    "error", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private async Task GetFuturesInfo()
        {
            socketClientFutures = new BinanceSocketClient();            

            var subscribe = await socketClientFutures.UsdFuturesStreams.SubscribeToAllTickerUpdatesAsync(data =>
            {
                foreach (var ud in data.Data)
                {
                    var symbol = AllSecurityesFutures.SingleOrDefault(p => p.Symbol == ud.Symbol);
                    if (symbol != null)
                        symbol.Price = ud.LastPrice;
                }

                if (SelectedSpotSymbol != null
                    && SelectedFuturesSymbol != null)
                {
                    CalculateSpread();
                }
            });
                       
            if (!subscribe.Success)
                messageBoxService.ShowMessage($"Failed to subscribe to price updates: {subscribe.Error}",
                    "error", MessageBoxButton.OK, MessageBoxImage.Error);            
        }

        private void CalculateSpread()
        {
            SpreadFormulas formula = Formula;

            if (formula == SpreadFormulas.DeltaPrices)
            {
                Spread = Math.Abs(SelectedSpotSymbol.Price - SelectedFuturesSymbol.Price);                
            }
            else if (formula == SpreadFormulas.Percent)
            {
                Spread = Math.Abs((SelectedFuturesSymbol.Price - SelectedSpotSymbol.Price) * 100
                    / SelectedSpotSymbol.Price);
            }
            OnPropertyChanged(nameof(Spread));
        }

        private void StartStop(object obj)
        {
            IsRun = !IsRun;

            if (IsRun
                && (SelectedSpotSymbol != null
                && SelectedFuturesSymbol != null)
                && StateOfConnect == "Connect") 
            {
                this.ChangeSpread += VM_ChangeSpread;               
            }
            if (!IsRun)
            {
                this.ChangeSpread -= VM_ChangeSpread;
            }
        }

       


        #endregion

        #region Setting&AccountLogic ================


        private void SetApi(object obj)
        {
            settings = new ApiSetting(this);
            settings.ShowDialog();
        }

        private async void Connect(object obj)
        {
            settings.Close();

            if (!string.IsNullOrEmpty(apiKey) && !string.IsNullOrEmpty(apiSecret))
            {
                BinanceClient.SetDefaultOptions(new BinanceClientOptions()
                {
                    ApiCredentials = new ApiCredentials(apiKey, apiSecret)      
                });
            }
            await SubscribeUserStream(); 
        }



        #endregion

        #region TradeLogic ==================

        private async void VM_ChangeSpread(decimal spread)
        {
            if (!IsRun)
            {
                return;
            }
            
            if (SpreadForTrade != 0
                && spread >= SpreadForTrade)
            {
                await GetFuturesPositions();
                await GetSpotPositions();

                if (Regim == Regims.ON                
                && SelectedFuturesSymbol.FuturesPositions.Count == 0)
                {
                    _tradeSpread = spread;
                    await TradeLogicOpen();
                }
                else if ((Regim == Regims.ON
                    || Regim == Regims.ONLI_CLOSE)                
                && SelectedFuturesSymbol.FuturesPositions.Count > 0)
                {
                    await TradeLogic(spread);
                }
            }      
        }

        private async Task TradeLogicOpen()
        {
            if (SelectedSpotSymbol.Price != 0
                && SelectedFuturesSymbol.Price != 0
                && SelectedSpotSymbol.Price > SelectedFuturesSymbol.Price)
            {
                await BuySpotEmitent(SelectedSpotSymbol);
                await SellFuturesEmitent(SelectedFuturesSymbol);
            }
            else if (SelectedSpotSymbol.Price != 0
                && SelectedFuturesSymbol.Price != 0
                && SelectedSpotSymbol.Price < SelectedFuturesSymbol.Price)
            {
                await SellSpotEmitent(SelectedSpotSymbol);
                await BuyFuturesEmitent(SelectedFuturesSymbol);
            }
        }              

        private async Task TradeLogic(decimal spread)
        {
            decimal сhangeSpreadInPercent = (spread - _tradeSpread) * 100 / _tradeSpread;

            if (spread <= BaseSpread)
            {
                await TradeLogicClose();
            }
            else if (spread > _tradeSpread
                    && SpreadForNewTrade >= сhangeSpreadInPercent
                    && Regim != Regims.ONLI_CLOSE)
            {
                _tradeSpread = spread;
                await TradeLogicOpen();
            }
        }

        private async Task TradeLogicClose()
        {

        }

        private async Task BuySpotEmitent(object o)
        {
            using (var client = new BinanceClient())
            {                
                var result = await client.SpotApi.Trading.PlaceOrderAsync(SelectedSpotSymbol.Symbol, 
                    OrderSide.Buy, SpotOrderType.Limit, Lot, price: SelectedSpotSymbol.Price, 
                    timeInForce: TimeInForce.GoodTillCanceled);
                if (result.Success)
                    messageBoxService.ShowMessage("Order placed!", "Sucess", MessageBoxButton.OK, 
                        MessageBoxImage.Information);
                else
                    messageBoxService.ShowMessage($"Order placing failed: {result.Error.Message}", 
                        "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task SellSpotEmitent(object o)
        {
            using (var client = new BinanceClient())
            {
                var result = await client.SpotApi.Trading.PlaceOrderAsync(SelectedSpotSymbol.Symbol, 
                    OrderSide.Sell, SpotOrderType.Limit, Lot, price: SelectedSpotSymbol.Price, 
                    timeInForce: TimeInForce.GoodTillCanceled);
                if (result.Success)
                    messageBoxService.ShowMessage("Order placed!", "Sucess", MessageBoxButton.OK, 
                        MessageBoxImage.Information);
                else
                    messageBoxService.ShowMessage($"Order placing failed: {result.Error.Message}", 
                        "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task BuyFuturesEmitent (object o)
        {
            using (var client = new BinanceClient())
            {
                var result = await client.UsdFuturesApi.Trading.PlaceOrderAsync(SelectedFuturesSymbol.Symbol, 
                    OrderSide.Buy, FuturesOrderType.Limit, Lot, price: SelectedFuturesSymbol.Price,
                    timeInForce: TimeInForce.GoodTillCanceled);


                if (result.Success)
                    messageBoxService.ShowMessage("Order Futures placed!", "Sucess", 
                        MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    messageBoxService.ShowMessage($"Order Futures placing failed: {result.Error.Message}", 
                        "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task SellFuturesEmitent(object o)
        {
            using (var client = new BinanceClient())
            {
                var result = await client.UsdFuturesApi.Trading.PlaceOrderAsync(SelectedFuturesSymbol.Symbol, 
                    OrderSide.Sell, FuturesOrderType.Limit, Lot, price: SelectedFuturesSymbol.Price,
                    timeInForce: TimeInForce.GoodTillCanceled);


                if (result.Success)
                    messageBoxService.ShowMessage("Order Futures placed!", "Sucess", MessageBoxButton.OK, 
                        MessageBoxImage.Information);
                else
                    messageBoxService.ShowMessage($"Order Futures placing failed: {result.Error.Message}", 
                        "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task GetFuturesPositions()
        {
            if (SelectedFuturesSymbol == null)
            {
                return;
            }

            using (var client = new BinanceClient())
            {
                var result = await client.UsdFuturesApi.Account.GetPositionInformationAsync(SelectedFuturesSymbol.Symbol);
                if (result.Success)
                {
                    SelectedFuturesSymbol.FuturesPositions = new ObservableCollection<Position>(result.Data.Select(o => new Position()
                    {
                        Symbol = o.Symbol,
                        EntryPrice = o.EntryPrice,
                        Leverage = o.Leverage,
                        PositionSide = o.PositionSide,
                        Quantity = o.Quantity,
                        LiquidationPrice = o.LiquidationPrice,
                        MarkPrice = o.MarkPrice                        
                    }));
                    CalculateFuturesPosition(SelectedFuturesSymbol.FuturesPositions);
                }
                else
                {
                    messageBoxService.ShowMessage($"Error requesting data: {result.Error.Message}",
                       "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                   
            }
        }


        private void CalculateFuturesPosition(ObservableCollection<Position> position)
        {
            if (position == null || position.Count == 0)
            {
                return;
            }

            PositonsFuturesCount = position.Count;

            var pos = position.Last();

            if (pos.Symbol != SelectedFuturesSymbol.Symbol)
            {
               return;
            }

            PositonsFuturesSide = pos.PositionSide;            
            FuturesEntryPrice = pos.EntryPrice;
            PositionFuturesQuantity = pos.Quantity;

            if (pos.PositionSide == PositionSide.Short)
            {
                PositionFuturesMargin = (pos.EntryPrice - SelectedFuturesSymbol.Price) * pos.Quantity;
            }
            else if (pos.PositionSide == PositionSide.Long)
            {
                PositionFuturesMargin = (SelectedFuturesSymbol.Price - pos.EntryPrice) * pos.Quantity;
            }

        }




        private async Task GetSpotPositions()
        {
            if (SelectedSpotSymbol == null)
            {
                return;
            }


        }


        #endregion




        public async Task Cancel(object o)
        {
            var order = (OrderSpotVM)o;
            using (var client = new BinanceClient())
            {
                var result = await client.SpotApi.Trading.CancelOrderAsync(SelectedSpotSymbol.Symbol, order.Id);
                if (result.Success)
                    messageBoxService.ShowMessage("Order canceled!", "Sucess", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    messageBoxService.ShowMessage($"Order canceling failed: {result.Error.Message}", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private async Task SubscribeUserStream()
        {
            if (ApiKey == null || ApiSecret == null)
            {
                StateOfConnect = "Disconnect";
                return;
            }
            

            using (var client = new BinanceClient())
            {                

                var startSpotOkay = await client.SpotApi.Account.StartUserStreamAsync();
                
                if (!startSpotOkay.Success)
                {
                    messageBoxService.ShowMessage($"Error starting user stream: {startSpotOkay.Error.Message}", 
                        "error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var startFuturesOkay = await client.UsdFuturesApi.Account.StartUserStreamAsync();
                if (!startFuturesOkay.Success)
                {
                    messageBoxService.ShowMessage($"Error starting user stream: {startFuturesOkay.Error.Message}", 
                        "error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (startSpotOkay.Success && startFuturesOkay.Success)
                {
                    StateOfConnect = "Connect";
                }
                else
                {
                    StateOfConnect = "Disconnect";
                }


                //var subSpotOkay = await socketClientSpot.SpotStreams.SubscribeToUserDataUpdatesAsync(startSpotOkay.Data, OnSpotOrderUpdate, null, 
                //    /*OnAccountUpdate, */null);
                //if (!subSpotOkay.Success)
                //{
                //    messageBoxService.ShowMessage($"Error subscribing to user stream: {subSpotOkay.Error.Message}", 
                //        "error", MessageBoxButton.OK, MessageBoxImage.Error);
                //    return;
                //}

                //var subFuturesOkay = await socketClientFutures.UsdFuturesStreams.SubscribeToUserDataUpdatesAsync(startFuturesOkay.Data, 
                //    OnSpotOrderUpdate, null, OnAccountUpdate, null);
                //if (!subSpotOkay.Success)
                //{
                //    messageBoxService.ShowMessage($"Error subscribing to user stream: {subFuturesOkay.Error.Message}", 
                //        "error", MessageBoxButton.OK, MessageBoxImage.Error);
                //    return;
                //}


                var accountSpotResult = await client.SpotApi.Account.GetAccountInfoAsync();
                if (accountSpotResult.Success)
                    Assets = new ObservableCollection<AssetViewModel>(accountSpotResult.Data.Balances.Where(b => b.Available != 0 | b.Locked != 0).Select(b => new AssetViewModel() 
                    { Asset = b.Asset, Free = b.Available, Locked = b.Locked }).ToList());
                else
                    messageBoxService.ShowMessage($"Error requesting account info: {accountSpotResult.Error.Message}", 
                        "error", MessageBoxButton.OK, MessageBoxImage.Error);

                var accountFuturesResult = await client.UsdFuturesApi.Account.GetAccountInfoAsync();


                //if (accountFuturesResult.Success)
                //    Assets = new ObservableCollection<AssetViewModel>(accountFuturesResult.Data. Where(b => b.Available != 0 | b.Locked != 0).Select(b => new AssetViewModel() { Asset = b.Asset, Free = b.Available, Locked = b.Locked }).ToList());
                //else
                //    messageBoxService.ShowMessage($"Error requesting account info: {accountFuturesResult.Error.Message}", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }







        #endregion ================


        #region Events ==============================================

        public delegate void changeSpread(decimal spread);

        public event changeSpread ChangeSpread;

        #endregion =======================
    }

}