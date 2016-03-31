namespace ULFlowApiHelpers
{
    public class IntradayTrade
    {
        public int Qty { get; set; }

        public int Px { get; set; }

        public IntradayTrade(int qty, int px)
        {
            Qty = qty;
            Px = px;
        }
    }
}
