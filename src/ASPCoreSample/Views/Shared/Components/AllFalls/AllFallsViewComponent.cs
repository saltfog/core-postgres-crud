using ASPCoreSample.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreSample.Shared.Components.OpenToPublic
{
    public class AllFallsViewComponent : ViewComponent
    {
        private readonly FallsRepository fallsRepository;

        public AllFallsViewComponent(IConfiguration configuration)
        {
            fallsRepository = new FallsRepository(configuration);

        }

        public IViewComponentResult Invoke()
        {
            var allFalls = fallsRepository.FindAll();
            return View(allFalls);
        }
    }
}
