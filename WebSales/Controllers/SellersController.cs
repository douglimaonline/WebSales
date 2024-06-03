using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSales.Data;
using WebSales.Models;
using WebSales.Models.ViewModels;
using WebSales.Services;

namespace WebSales.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly WebSalesContext _context;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, WebSalesContext context, DepartmentService departmentService)
        {
            _context = context;
            _sellerService = sellerService;
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var listSellers = _sellerService.FindAll();
            var listDepartments = _context.Department.ToList();
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

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var seller = _context.Seller.Include(s => s.Department).FirstOrDefault(s => s.Id == id);
            return View(seller);
            
        }

        public IActionResult Edit (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var seller = _context.Seller.Include(s => s.Department).FirstOrDefault(s => s.Id == id);
            var editViewModel = new EditViewSeller
            {
                Seller = seller,
                Departments = _context.Department.ToList()
            };
            return View(editViewModel);
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
            var seller = _context.Seller.FirstOrDefault(s => s.Id == id);
            return View(seller);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Seller seller)
        {
            _sellerService.Delete(seller);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit (Seller seller)
        {
            _sellerService.Update(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
