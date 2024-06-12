using Microsoft.AspNetCore.Mvc;
using WebSales.Services;

namespace WebSales.Controllers
{
    public class SalesRecordController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            var result = await _salesRecordService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}
