namespace API_Lab14_Guerrero.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public DateTime Date { get; set; }
        public string InvoiceNumber { get; set; }
        public float Total { get; set;}

        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public List<Detail>? Details { get; set; }
    }
}
