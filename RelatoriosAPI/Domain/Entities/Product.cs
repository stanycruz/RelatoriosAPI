namespace RelatoriosAPI.Domain.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public string? ProductNumber { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
    }
}
