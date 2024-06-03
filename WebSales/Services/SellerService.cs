using WebSales.Data;
using WebSales.Models;

namespace WebSales.Services
{
    public class SellerService
    {
        private readonly WebSalesContext _context;

        public SellerService(WebSalesContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public void Delete(Seller seller)
        {
            _context.Remove(seller);
            _context.SaveChanges();
        }
        public void Update(Seller seller)
        {
            _context.Update(seller);
            _context.SaveChanges();
        }
    }
}
