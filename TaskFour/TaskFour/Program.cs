namespace TaskFour
{
    public class Account
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public Account(string Name = "Unnamed Account", double Balance = 0.0)
        {
            this.Name = Name;
            this.Balance = Balance;
        }

        public virtual bool Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                return true;
            }
            return false;
        }

        public virtual bool Withdraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
        public static Account operator +(Account lhs, Account rhs)
        {         
           Account account = new Account(lhs.Name,lhs.Balance + rhs.Balance);
            return account;
        }
        public override string ToString()
        {
            return $"Account name:{Name}, the balance is :{Balance} ";
        }
    }
    public static class AccountUtil
    {
        // Utility helper functions for Account class

        public static void Display(List<Account> accounts)
        {
            Console.WriteLine("\n=== Accounts ==========================================");
            foreach (var acc in accounts)
            {
                Console.WriteLine(acc);
            }
        }

        public static void Deposit(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc}");
            }
        }

        public static void Withdraw(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
            }
        }
    }

    class SavingsAccount : Account
    {
        public SavingsAccount(string name = "Unnamed Account", double balance = 0, double rate = 0) : base(name, balance)
        {
            Rate = rate;
        }

        public double Rate { get; set; }

        public override bool Withdraw(double amount)
        {

            return base.Withdraw(amount + (amount * Rate));

        }
        public override string ToString()
        {
            return $"{base.ToString()}, Rate: {Rate}";
        }
    }


    class CheckingAccount : Account
    {
        public CheckingAccount(string name = "Unnamed Account", double balance = 0) : base(name, balance) { }
                     
        
        public const double Fee = 1.50;

        public override bool Withdraw(double amount)
        {
            if (Balance - (amount + Fee) >= 0)
            {
                Balance -= amount + Fee;
                return true;
            }
            return false;
        }
        

    }

    class TrustAccount : Account
    {
        public TrustAccount(string name = "Unnamed Account", double balance = 0, double rate = 0) : base(name, balance) 
        {
            Rate = rate;
            withdrawalCount = 0;
        }

        public double Rate { get; set; }
        private int withdrawalCount;  
        private const int MaxWithdrawalsPerYear = 3;
        private const double MaxWithdrawalPercentage = 0.2;

        public override bool Deposit(double amount)
        {
            if (amount <= 0) 
            {
                return false;
            }

            if (amount >= 5000) 
            {
                Balance += amount + 50;
            }
            else
            {
                Balance += amount;
            }

            return true; 
        }
        public override bool Withdraw(double amount)
        {
            if (withdrawalCount >= MaxWithdrawalsPerYear)
            {
                Console.WriteLine("Withdrawal limit reached for this year.");
                return false;  
            }

            if (amount > Balance * MaxWithdrawalPercentage)
            {
                Console.WriteLine("Withdrawal exceeds the 20% limit of the account balance.");
                return false;  
            }

            if (Balance >= amount)  
            {
                Balance -= amount; 
                withdrawalCount++;  
                return true;
            }

            return false;  

        }
        public override string ToString()
        {
            return $"{base.ToString()}, Rate: {Rate}";
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Accounts
            var accounts = new List<Account>();
            accounts.Add(new Account());
            accounts.Add(new Account("Larry"));
            accounts.Add(new Account("Moe", 2000));
            accounts.Add(new Account("Curly", 5000));

            AccountUtil.Display(accounts);
            AccountUtil.Deposit(accounts, 1000);
            AccountUtil.Withdraw(accounts, 2000);

            // Savings
            var savAccounts = new List<Account>();
            savAccounts.Add(new SavingsAccount());
            savAccounts.Add(new SavingsAccount("Superman"));
            savAccounts.Add(new SavingsAccount("Batman", 2000));
            savAccounts.Add(new SavingsAccount("Wonderwoman", 5000, 0.05));

            AccountUtil.Display(savAccounts);
            AccountUtil.Deposit(savAccounts, 1000);
            AccountUtil.Withdraw(savAccounts, 2000);

            // Checking
            var checAccounts = new List<Account>();
            checAccounts.Add(new CheckingAccount());
            checAccounts.Add(new CheckingAccount("Larry2"));
            checAccounts.Add(new CheckingAccount("Moe2", 2000));
            checAccounts.Add(new CheckingAccount("Curly2", 5000));

            AccountUtil.Display(checAccounts);
            AccountUtil.Deposit(checAccounts, 1000);
            AccountUtil.Withdraw(checAccounts, 2000);
            AccountUtil.Withdraw(checAccounts, 2000);

            // Trust
            var trustAccounts = new List<Account>();
            trustAccounts.Add(new TrustAccount());
            trustAccounts.Add(new TrustAccount("Superman2"));
            trustAccounts.Add(new TrustAccount("Batman2", 2000));
            trustAccounts.Add(new TrustAccount("Wonderwoman2", 5000, 0.05));

            AccountUtil.Display(trustAccounts);
            AccountUtil.Deposit(trustAccounts, 1000);
            AccountUtil.Deposit(trustAccounts, 6000);
            AccountUtil.Withdraw(trustAccounts, 2000);
            AccountUtil.Withdraw(trustAccounts, 3000);
            AccountUtil.Withdraw(trustAccounts, 500);

            Console.WriteLine("------------");
             
            Account totalBalanceAccounts = new Account("Total accounts", 0);

            for (int i = 0; i < accounts.Count; i++)
            {
                totalBalanceAccounts = totalBalanceAccounts + accounts[i];
            }
            Console.WriteLine(totalBalanceAccounts);
        }
    }
}
