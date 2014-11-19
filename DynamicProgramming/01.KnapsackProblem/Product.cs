namespace _01.KnapsackProblem
{
    public class Product
    {
        public Product(string name, int cost, int weight)
        {
            this.Name = name;
            this.Cost = cost;
            this.Weight = weight;
        }

        public string Name { get; set; }

        public int Cost { get; set; }

        public int Weight { get; set; }
    }
}
