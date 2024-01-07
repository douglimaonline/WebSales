namespace WebSales.Models.ViewModels
{
    public class CreateViewSellers
    {
        public Seller Seller { get; set; }
        public IEnumerable<Department> Departments { get; set; }
    }
}
