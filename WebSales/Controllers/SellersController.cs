using Microsoft.AspNetCore.Mvc;
using WebSales.Data;
using WebSales.Models.ViewModels;
using WebSales.Services;

namespace WebSales.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly WebSalesContext _departments;

        public SellersController (SellerService sellerService, WebSalesContext departments)
        {
            _sellerService = sellerService;
            _departments = departments;
        }
        public IActionResult Index()
        {
            var listSellers = _sellerService.FindAll();
            var listDepartments = _departments.Department.ToList();
            var viewWebSellers = new WebViewSellers
            {
                Sellers = listSellers,
                Departments = listDepartments
            };
            return View(viewWebSellers);
        }
    }
}
