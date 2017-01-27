using ASPCoreSample.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreSample.Shared.Components.OpenToPublic
{
    public class OpenToPublicViewComponent : ViewComponent
    {
        private readonly FallsRepository fallsRepository;

        public OpenToPublicViewComponent(IConfiguration configuration)
        {
            fallsRepository = new FallsRepository(configuration);

        }

        public IViewComponentResult Invoke()
        {
            var publicFalls = fallsRepository.Public();
            return View(publicFalls);
        }
    }
}
