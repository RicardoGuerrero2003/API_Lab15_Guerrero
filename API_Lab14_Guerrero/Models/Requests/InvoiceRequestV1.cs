namespace API_Lab14_Guerrero.Models.Requests
{
    public class InvoiceRequestV1
    {
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public string InvoiceNumber { get; set; }
        public float Total { get; set; }
      

    }
}
