namespace RefundApp
{
    public class BasicApproval : ApprovalHandler
    {
        public BasicApproval(Approver approver) : base(approver)
        {
        }
        public override ApprovalResult Approve(int refund)
        {
            var result = Approver.ApproveRefund(refund);
            if (result == ApprovalResult.BeyondLimit)
            {
                return Next.Approve(refund);
            }

            return result;
        }
    }
    public class ManagerApproval : ApprovalHandler
    {
        public ManagerApproval(Approver approver) : base(approver)
        {
        }

        public override ApprovalResult Approve(int refund)
        {
            var result = Approver.ApproveRefund(refund);
            if (result == ApprovalResult.BeyondLimit)
            {
                //Do Managerial custom logic here if needed
                //eg. log approve activity in database

                return Next.Approve(refund);
            }
            return result;
        }
    }
    
    public class VicePresidentApproval : ApprovalHandler
    {
        public VicePresidentApproval(Approver approver) : base(approver)
        {
        }
        public override ApprovalResult Approve(int refund)
        {
            var result = Approver.ApproveRefund(refund);

            if (result == ApprovalResult.BeyondLimit)
            {
                //Do Vice President custom logic here if needed
                //This is pretty much same as BasicApproval and ManagerApproval
                //I'm trying to show that you can do customization here
                return Next.Approve(refund);
            }

            return result;
        }
    }
    public class PresidentApproval : ApprovalHandler
    {
        public PresidentApproval(Approver approver) : base(approver)
        {
        }
        public override ApprovalResult Approve(int refund)
        {
            var result = Approver.ApproveRefund(refund);

            if (result == ApprovalResult.BeyondLimit)
            {
                //since I am president! I can approve any limit lol!
                result = ApprovalResult.PresidentApproval;
            }

            return result;
        }
    }
}
