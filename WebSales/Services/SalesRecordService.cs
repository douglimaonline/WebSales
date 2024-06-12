using Microsoft.EntityFrameworkCore;
using WebSales.Data;
using WebSales.Models;

namespace WebSales.Services
{
    public class SalesRecordService
    {
        private readonly WebSalesContext _context;

        public SalesRecordService (WebSalesContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync (DateTime? minDate, DateTime? maxDate)
        {
            var result = from s in _context.SalesRecords select s;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result
                .Include(s => s.Seller)
                .Include(s => s.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }
    }
}
