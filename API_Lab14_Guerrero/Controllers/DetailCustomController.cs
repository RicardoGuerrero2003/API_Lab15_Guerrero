using API_Lab14_Guerrero.Models.Requests;
using API_Lab14_Guerrero.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Lab14_Guerrero.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DetailCustomController : ControllerBase
    {
        private InvoiceContext _context;

        public DetailCustomController(InvoiceContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void InsertDetail(int InvoiceId, List<DetailRequestV1> request)
        {
            var inv = _context.Invoices.Where(x => x.InvoiceID == InvoiceId).FirstOrDefault();
            foreach (var detail in request)
            {
                var prod = _context.Products.Where(x => x.ProductID == detail.ProductId).FirstOrDefault();
                Detail model = new Detail();
                model.Amount = detail.Amount;
                model.Price = prod.Price;
                model.SubTotal = detail.Amount * prod.Price;
                model.InvoiceID = InvoiceId;
                model.ProductId = detail.ProductId;
                _context.Details.Add(model);
                inv.Details.Add(model);
            }
            _context.SaveChanges();
            
        }


    }
}
