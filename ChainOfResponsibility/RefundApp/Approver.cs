namespace RefundApp
{
    public class Approver
    {
        public Approver(string name, int limit)
        {
            Name = name;
            _limit = limit;
        }
        public ApprovalResult ApproveRefund(int refund)
        {
            if (refund > _limit)
            {
                return ApprovalResult.BeyondLimit;
            }
            else
            {
                return ApprovalResult.Approved;
            }
        }

        public string Name { get; set; }

        private readonly int _limit;
    }
}
