namespace DAL.Model
{
    public class Expenses
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public double Amount { get; set; }
        public string? Description { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; }
    }
}
