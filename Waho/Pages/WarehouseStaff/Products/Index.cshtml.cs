using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Waho.WahoModels;

namespace Waho.Pages.WarehouseStaff.Products
{
    public class IndexModel : PageModel
    {
        private readonly Waho.WahoModels.WahoContext _context;

        public IndexModel(Waho.WahoModels.WahoContext context)  
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;
        [BindProperty]
        public int numerOfList { get; set; } = 10;
        [BindProperty]
        public string textSearch { get;set; }
        public async Task OnGetAsync()
        {
            
            //get product list default
            if (_context.Products != null)
            {
                Product = await _context.Products
                            .Where(p => p.SubCategory.CategoryId == 1)
                            .Include(p => p.SubCategory)
                            .ThenInclude(s => s.Category)
                            .ToListAsync();
            }
        }
    }
}
