namespace API_Lab14_Guerrero.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public float Active { get; set; } = 1;
        
    }
}
