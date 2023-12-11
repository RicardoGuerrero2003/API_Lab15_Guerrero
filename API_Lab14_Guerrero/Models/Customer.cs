namespace API_Lab14_Guerrero.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }


        public float Active { get; set; } = 1;

       
    }
}
