using Ecommerce.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using BeautyStore.Application.Product.Commands.CreateProduct;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize(Roles = "Admin")]
        [Route("/Dashboard")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [Route("/Dashboard/Product/Create")]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("/Dashboard/Product/Create")]
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
