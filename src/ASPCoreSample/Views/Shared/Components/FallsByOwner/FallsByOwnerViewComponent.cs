using ASPCoreSample.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreSample.Shared.Components.OpenToPublic
{
    public class FallsByOwnerViewComponent : ViewComponent
    {
        private readonly FallsRepository fallsRepository;

        public FallsByOwnerViewComponent(IConfiguration configuration)
        {
            fallsRepository = new FallsRepository(configuration);

        }

        public IViewComponentResult Invoke()
        {
            var byOwnerFalls = fallsRepository.FallsByOwner();
            return View(byOwnerFalls);
        }
    }
}
