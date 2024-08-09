using Frontend.Models;
using Frontend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class BpkbController : Controller
    {
        private readonly IApiService _apiService;

        public BpkbController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var locations = await _apiService.GetLocationsAsync();
            var viewModel = new BpkbViewModel
            {
                Bpkb = new TrBpkb(),
                Locations = locations
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BpkbViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var success = await _apiService.CreateBpkbAsync(viewModel.Bpkb);

                if (success)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Unable to save data");
            }

            viewModel.Locations = await _apiService.GetLocationsAsync();
            return View(viewModel);
        }
    }
}
