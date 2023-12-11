using API_Lab14_Guerrero.Models.Requests;
using API_Lab14_Guerrero.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Lab14_Guerrero.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerCustomController : ControllerBase
    {
        private InvoiceContext _context;

        public CustomerCustomController(InvoiceContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void InsertCustomer(CustomerRequestV1 request)
        {
            Customer model = new Customer();
            model.FirstName = request.FirstName;
            model.LastName = request.LastName;
            model.DocumentNumber = request.DocumentNumber;
            _context.Customers.Add(model);
            _context.SaveChanges();
        }


        [HttpPost]
        public void DeleteCustomer(CustomerRequestV2 request)
        {
            var model = _context.Customers.Where(x => x.CustomerID == request.CustomerID).FirstOrDefault();
            _context.Entry(model).State = EntityState.Modified;
            model.Active = 0;
            _context.SaveChanges();

        }


        [HttpPost]
        public void UpdateNumberDoc(CustomerRequestV3 request)
        {
            var model = _context.Customers.Where(x => x.CustomerID == request.CustomerID).FirstOrDefault();
            _context.Entry(model).State = EntityState.Modified;
            model.DocumentNumber = request.DocumentNumber;
            _context.SaveChanges();

        }
    }
}
