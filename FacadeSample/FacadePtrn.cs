using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeSample
{
    /*Defines a simplified interface over a complex subsystem
     * Imagine a Motgage system encapsulating the complexity of bank worthiness, credit worthiness, previous loans
     * */
    class FacadePtrn
    {
        static void Main(string[] args)
        {
            Motgage mgt = new Motgage();

            Console.WriteLine(mgt.IsEligible(4566));
            Console.ReadLine();
        }
    }

    public class Bank
    {
        public bool HasSufficientBalance(double amount)
        {
            return true;
        }

    }

    public class CreditScore
    {
        public bool HasGoodCredit()
        {
            return true;
        }
    }

    public class Loan
    {
        public bool HasBadCredit()
        {
            return true;
        }
    }

    public class Motgage
    {
        private Bank _bank = new Bank();
        private CreditScore _creditScore = new CreditScore();
        private Loan _loan = new Loan();

        public bool IsEligible(double amount)
        {
            bool eligible = true;

            if (_bank.HasSufficientBalance(amount))
            {
                eligible = false;    
            }

            if (_creditScore.HasGoodCredit())
            {
                eligible = false;

            }
            if (_loan.HasBadCredit())
            {
                eligible = false;
            }

            return eligible;
        }

    }
}
