using Microsoft.AspNetCore.Mvc;
using WebSales.Models;
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

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 9, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = new DateTime(DateTime.Now.Year, 10, 31);
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new SalesRecord();
            return View(viewModel);
        }
    }
}
