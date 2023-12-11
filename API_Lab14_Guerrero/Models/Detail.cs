namespace API_Lab14_Guerrero.Models
{
    public class Detail
    {
        public int DetailID { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public float SubTotal { get; set; }

        public int InvoiceID { get; set; }
        public Invoice Invoice { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
