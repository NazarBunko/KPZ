namespace WebApplication1.Models
{
    public class Counter
    {
        public int Id { get ; set; }

        public int Count { get; set; }

        public int CustomerId { get; set; }

        public Customer?  Customer { get; set; }

    }
}
