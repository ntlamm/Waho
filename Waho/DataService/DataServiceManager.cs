using Waho.DataService;
using Waho.WahoModels;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Waho.DataService
{
    public class DataServiceManager 
    {
        private readonly WahoContext _context;
        public DataServiceManager(WahoContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
