using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using ULFlowApiHelpers;

namespace ULConsumer
{
    public partial class IntradayTradesForm : Form
    {
        private readonly BindingList<IntradayTrade> _intradayTrades = new BindingList<IntradayTrade>();

        private IDisposable _marketDataDisposable;

        public IntradayTradesForm()
        {
            InitializeComponent();

            var adapter = new IntradayAdapter();

            dataGridView1.DataSource = _intradayTrades;
            adapter.GetTradesAsync().ContinueWith(intradayTask =>
            {
                _marketDataDisposable = intradayTask.Result.MarketDataSubscription;
                intradayTask.Result.IntradayTradeObservable.Subscribe(t =>
                    {
                        _intradayTrades.Add(t);
                    });
                intradayTask.Result.HistoryStateObservable.Subscribe(s => lblHistoryState.Text = s.ToString());
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(components != null)
                    components.Dispose();
                _marketDataDisposable.Dispose();

            }
            base.Dispose(disposing);
        }
    }
}
