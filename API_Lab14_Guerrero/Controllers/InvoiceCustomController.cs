using API_Lab14_Guerrero.Models.Requests;
using API_Lab14_Guerrero.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Lab14_Guerrero.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoiceCustomController : ControllerBase
    {
        private InvoiceContext _context;

        public InvoiceCustomController(InvoiceContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void InsertInvoice(InvoiceRequestV1 request)
        {
            Invoice model = new Invoice();
            model.CustomerId = request.CustomerId;
            model.Date = request.Date;
            model.InvoiceNumber = request.InvoiceNumber;
            model.Total= request.Total;
            _context.Invoices.Add(model);
            _context.SaveChanges();
        }



        [HttpPost]
        public void ListInvoicesToCustomer(int CustomerID, List<InvoiceRequestV2> invoices)
        {
            var customer = _context.Customers.Where(x => x.CustomerID == CustomerID).FirstOrDefault();

            if (customer == null)
            {
                Console.WriteLine($"No se encontró el cliente con ID {CustomerID}");
                return;
            }

            foreach (var invoice in invoices)
            {
                Invoice model = new Invoice();
                model.CustomerId = CustomerID;
                model.Date= invoice.Date;
                model.InvoiceNumber = invoice.InvoiceNumber;
                model.Total= invoice.Total;
                _context.Invoices.Add(model);
            }

            _context.SaveChanges();
        }
    }
}
