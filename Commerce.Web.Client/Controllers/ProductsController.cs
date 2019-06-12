using Commerce.Contracts.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Web.Client.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        // GET: Products
        //public async Task<IActionResult> Index()
        //{
        //    return View(await Task<ICollection<Product>>.Factory.StartNew(() => _repository.GetAllProducts()));
        //}

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Name,Price,Description,Id")] Product product)
        //{
        //    if (ModelState.IsValid)
        //        if (await Task<bool>.Factory.StartNew(() => _repository.AddProduct(product)))
        //            return RedirectToAction(nameof(Index));
        //    return View(product);
        //}
    }
}