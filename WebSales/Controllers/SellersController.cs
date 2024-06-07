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
        public async Task<IActionResult> Index()
        {
            var listSellers = await _sellerService.FindAllAsync();
            var listDepartments = await _departmentService.FindAllAsync();
            var viewWebSellers = new WebViewSellers
            {
                Sellers = listSellers,
                Departments = listDepartments
            };
            return View(viewWebSellers);
        }

        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new CreateViewSellers { Departments = departments };
            return View(viewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {   
            if (id == null)
            {
                return NotFound();
            }
            var seller = await _sellerService.FindByIdAsync(id);
            return View(seller);
            
        }

        public async Task<IActionResult> Edit (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var seller = await _sellerService.FindByIdAsync(id);
            var editViewModel = new EditViewSeller
            {
                Seller = seller,
                Departments = _context.Department.ToList()
            };
            return View(editViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {
            await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var seller = await _sellerService.FindByIdAsync(id);
            return View(seller);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Seller seller)
        {
            await _sellerService.RemoveAsync(seller);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit (Seller seller)
        {
            await _sellerService.UpdateAsync(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
