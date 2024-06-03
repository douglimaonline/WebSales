namespace WebSales.Models.ViewModels
{
    public class EditViewSeller
    {
        public Seller Seller { get; set; }
        public IEnumerable<Department> Departments { get; set; }
    }
}
