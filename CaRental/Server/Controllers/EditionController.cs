using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaRental.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class EditionController : ControllerBase
    {
        private readonly IEditionService _editionService;

        public EditionController(IEditionService editionService)
        {
            _editionService = editionService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Edition>>>> GetEditions()
        {
            var response = await _editionService.GetEditions();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Edition>>>> AddEdition(Edition edition)
        {
            var response = await _editionService.AddEdition(edition);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Edition>>>> UpdateEdition(Edition edition)
        {
            var response = await _editionService.UpdateEdition(edition);
            return Ok(response);
        }
    }
}
