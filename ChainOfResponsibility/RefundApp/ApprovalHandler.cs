namespace RefundApp
{
    public abstract class ApprovalHandler
    {
        protected ApprovalHandler(Approver approver)
        {
            Approver = approver;
        }
        public ApprovalHandler RegisterNext(ApprovalHandler next)
        {
            Next = next;
            return Next;
        }

        public Approver Approver { get; set; }

        public abstract ApprovalResult Approve(int refund);

        protected ApprovalHandler Next { get; private set; }
    }
}
