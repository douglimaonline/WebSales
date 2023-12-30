namespace WebSales.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales (SalesRecord record)
        {
            Sales.Add(record);
        }
        public void RemoveSales (SalesRecord record)
        {
            Sales.Remove(record);
        }
        public double TotalSales (DateTime initialDate, DateTime endDate)
        {
            return Sales.Where(s => s.Date >= initialDate && s.Date <= endDate).Sum(s => s.Amout);
        }
    }
}
