namespace Stealer
{
    public class Hacker
    {
        public string username = "securityGod82";
        private string password = "mySuperSecretPassw0rd";

        public int Id { get;}

        private string Password 
        { 
            set => password = value;
        }

        private double BankAccountBalance { get;}

        private void DownloadAllBankAccountsInTheWorld()
        {

        }

    }
}