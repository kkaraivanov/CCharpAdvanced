namespace Stealer
{
    public class Hacker
    {
        public string username = "securityGod82";
        private string password = "mySuperSecretPassw0rd";
        private double bankAccountBalance;

        private int Id { get; set; }

        public string Password 
        { 
            set => password = value;
        }

        private double BankAccountBalance
        {
            set => bankAccountBalance = value;
        }

        public void DownloadAllBankAccountsInTheWorld()
        {

        }

    }
}