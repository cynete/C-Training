namespace JP.JsonLearning
{
    public class Employees
    {
        public Emp[] employees { get; set; }
    }

    public class Emp
    {
        public string name { get; set; }
        public string email { get; set; }
        public int age { get; set; }
    }
}