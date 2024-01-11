using Microsoft.AspNetCore.Mvc;
using WebSales.Data;
using WebSales.Models;
using WebSales.Models.ViewModels;
using WebSales.Services;

namespace WebSales.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly WebSalesContext _departments;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, WebSalesContext departments, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departments = departments;
            _departmentService = departmentService;
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

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new CreateViewSellers { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            var seller = _departments.Seller.FirstOrDefault(s => s.Id == id);
            return View(seller);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Seller seller)
        {
            _sellerService.Delete(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
