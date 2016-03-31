using System;

namespace ULFlowApiHelpers.Data
{
    public class Intraday
    {
        public IObservable<IntradayTrade> IntradayTradeObservable { get; private set; }

        public IObservable<HistoryState> HistoryStateObservable { get; private set; }

        public IDisposable MarketDataSubscription { get; set; }

        public Intraday(IObservable<IntradayTrade> intradayTradeObservable, IObservable<HistoryState> historyStateObservable, IDisposable marketDataSubscription)
        {
            IntradayTradeObservable = intradayTradeObservable;
            HistoryStateObservable = historyStateObservable;
            MarketDataSubscription = marketDataSubscription;
        }
    }
}
