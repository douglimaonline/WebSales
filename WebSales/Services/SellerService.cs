using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task<Seller> FindByIdAsync(int? id)
        {
            return await _context.Seller.Include(s => s.Department).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task InsertAsync(Seller seller)
        {
            _context.Add(seller);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Seller seller)
        {
            _context.Remove(seller);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Seller seller)
        {
            _context.Update(seller);
            await _context.SaveChangesAsync();
        }
    }
}
