using Ecommerce.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using BeautyStore.Application.Product.Commands.CreateProduct;

namespace Ecommerce.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly IMediator _mediator;

        public DashboardController(ILogger<DashboardController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        [Route("/Product/Create")]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
