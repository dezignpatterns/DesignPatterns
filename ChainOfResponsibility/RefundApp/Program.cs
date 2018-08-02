using System;

namespace RefundApp
{
    static class Program
    {
        static void Main(string[] args)
        {
            ApprovalHandler you = new BasicApproval(new Approver("you", 10));

            //Start chaining the handler
            you.RegisterNext(new ManagerApproval(new Approver("Manager", 200)))
            .RegisterNext(new VicePresidentApproval(new Approver("Vice President", 500)))
            .RegisterNext(new PresidentApproval(new Approver("President", 9000)));

            //try to approve $300
            ApprovalResult result = you.Approve(300);
            
            Console.WriteLine("Trying to get $300 approved, The result is " + result);

            //try to approve $10000
            result = you.Approve(10000);

            Console.WriteLine("Trying to get $10000 approved, The result is " + result);

            Console.ReadKey();
        }
    }
}
