namespace WebApplication1.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Email { get; set; }

        public string Phone_Number { get; set; }

        public List<Counter>? Counters { get; set; }
    }
}
