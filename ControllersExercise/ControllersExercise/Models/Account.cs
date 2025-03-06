namespace ControllersExercise.Models
{
    public class Account
    {
        public int accountNumber {  get; set; }
        public string accountHolderName { get; set; }
        public int currentBalance { get; set; }
        
        public Account()
        {
            accountNumber = 1001;
            accountHolderName = "ClientName";
            currentBalance = 5000;
        }
    
    }
}
