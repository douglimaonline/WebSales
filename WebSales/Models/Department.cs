using System.ComponentModel.DataAnnotations;

namespace WebSales.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {
        }

        public Department(int id, string? name)
        {
            Id = id;
            Name = name;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales (DateTime initialDate, DateTime endDate)
        {
            return Sellers.Sum(s => s.TotalSales(initialDate, endDate));
        }
    }
}
