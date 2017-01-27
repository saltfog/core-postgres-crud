using ASPCoreSample.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreSample.Shared.Components.OpenToPublic
{
    public class PrivateViewComponent : ViewComponent
    {
        private readonly FallsRepository fallsRepository;

        public PrivateViewComponent(IConfiguration configuration)
        {
            fallsRepository = new FallsRepository(configuration);

        }

        public IViewComponentResult Invoke()
        {
            var privateFalls = fallsRepository.Private();
            return View(privateFalls);
        }
    }
}
