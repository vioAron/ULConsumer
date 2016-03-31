using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using ULFlowApiHelpers.Data;

namespace ULFlowApiHelpers
{
    public class IntradayAdapter
    {
        public Task<Intraday> GetTradesAsync()
        {
            return Task.Factory.StartNew(GetTrades, TaskCreationOptions.LongRunning);
        }

        public Intraday GetTrades()
        {
            Thread.Sleep(1000);
            return new Intraday(GetIntradayTrades(), GetHistoryStates(), Disposable.Create(() => Console.WriteLine("Request disposed!")));
        }

        private static IObservable<IntradayTrade> GetIntradayTrades()
        {
            return Observable.Create<IntradayTrade>(o =>
            {
                o.OnNext(new IntradayTrade(1, 1));
                o.OnNext(new IntradayTrade(2, 2));
                o.OnNext(new IntradayTrade(3, 3));
                return Disposable.Empty;
            });
        }

        private static IObservable<HistoryState> GetHistoryStates()
        {
            return Observable.Create<HistoryState>(o =>
            {
                o.OnNext(HistoryState.NoStarted);
                o.OnNext(HistoryState.Active);
                return Disposable.Empty;
            });
        }
    }
}
