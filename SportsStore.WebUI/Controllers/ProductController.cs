using System.Configuration;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using System.Web.Mvc;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        //public ProductController(IProductRepository productRepository)
        public ProductController()
        {
            //this.productRepository = productRepository;
            this.productRepository = new ProductRepository();
        }

        // GET: Product
        public ActionResult Index()
        {
            //return View();
            return RedirectToAction("List");
        }

        public ViewResult List()
        {
            return View(productRepository.List());
        }

        public ActionResult Delete(int id)
        {
            productRepository.Delete(id);

            return RedirectToAction("List");
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var product = productRepository.GetById(id);
            return View(product);
        }

        // GET: Pipo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pipo/Create
        [HttpPost]
        public ActionResult Create(ProductModel productModel)
        {
            try
            {
                var product = new Product
                {
                    Name = productModel.Name,
                    Description = productModel.Description,
                    Price = productModel.Price,
                    Category = productModel.Category
                };

                productRepository.Add(product);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pipo/Edit/5
        public ActionResult Edit(int id)
        {
            var product = productRepository.GetById(id);
            return View(product);
        }

        // POST: Pipo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductModel productModel)
        {
            try
            {
                var product = productRepository.GetById(id);
                product.Name = productModel.Name;
                product.Description = productModel.Description;
                product.Category = productModel.Category;
                product.Price = productModel.Price;

                productRepository.Update(product);

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

    }
}