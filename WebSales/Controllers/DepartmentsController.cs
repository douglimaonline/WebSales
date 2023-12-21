using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebSales.Models;

namespace WebSales.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<Department> departments = new List<Department>
            {
                new Department { Name = "Eletronics", Id = 1},
                new Department { Name = "Home", Id = 2}
            };
            return View(departments);
        }
    }
}
