using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Linq;

namespace api.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        public HomeController(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }

        [HttpGet]
        public IActionResult GetRoutes()
        {
            var apiDescription = "Prod by Jahor Šykaviec. All rights are not reserved. Free for use. gOoD lUcK =)";

            var routes = _actionDescriptorCollectionProvider.ActionDescriptors.Items
                .GroupBy(
                    ad => ad.RouteValues["Controller"], // Группировка по контроллеру
                    ad => ad.RouteValues["Action"],     // Выбор действий для каждого контроллера
                    (controller, actions) => new
                    {
                        Controller = $"/aucusoft/{controller}",
                        Actions = actions.Distinct().OrderBy(x => x).ToList() // Уникальные и упорядоченные действия
                    })
                .OrderBy(item => item.Controller) // Сортировка по контроллеру для упорядоченного вывода
                .ToList();

            var result = new
            {
                Description = apiDescription,
                Routes = routes
            };

            return Ok(result);
        }
    }
}
