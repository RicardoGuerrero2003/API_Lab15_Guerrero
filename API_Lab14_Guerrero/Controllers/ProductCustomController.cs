using API_Lab14_Guerrero.Models;
using API_Lab14_Guerrero.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Lab14_Guerrero.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductCustomController : ControllerBase
    {


        private InvoiceContext _context;

        public ProductCustomController(InvoiceContext context) 
        {
            _context = context;
        }

        [HttpPost]
        public void InsertProduct(ProductRequestV1 request)
        {
            Product model = new Product();
            model.Price = (float)request.Price;
            model.Name = request.Name;
            _context.Products.Add(model);
            _context.SaveChanges();
        }

        [Authorize("Vendedor")]
        [HttpPost]
        public void DeleteProduct(ProductRequestV2 request)
        {
            var model = _context.Products.Where(x=>x.ProductID==request.ProductID).FirstOrDefault();
            _context.Entry(model).State = EntityState.Modified;
            model.Active= 0;
            _context.SaveChanges();
        
        }

        [HttpPost]
        public void UpdatePrice(ProductRequestV3 request)
        {
            var model = _context.Products.Where(x => x.ProductID == request.ProductID).FirstOrDefault();
            _context.Entry(model).State = EntityState.Modified;
            model.Price = request.Price;
            _context.SaveChanges();
        }


        [HttpPost]
        public void DeleteProducts(List<ProductRequestV2> request)
        {

            foreach (var prod in request)
            {
                var model = _context.Products.Where(x => x.ProductID == prod.ProductID).FirstOrDefault();
                _context.Entry(model).State = EntityState.Modified;
                model.Active = 0;
                _context.SaveChanges();
            }
        }
    }
}
