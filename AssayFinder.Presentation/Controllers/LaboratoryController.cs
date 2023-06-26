using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace AssayFinder.Presentation.Controllers
{
    [Route("api/laboratories")]
    [ApiController]
    public class LaboratoryController : ControllerBase
    {
        private readonly IServiceManager _service;

        public LaboratoryController(IServiceManager service)
        {
            _service = service;
        }

        //api/laboratories
        [HttpGet]
        public IActionResult GetLaboratories()
        {
            var labs = _service.LaboratoryService.GetAllLaboratories(trackChanges: false);

            return Ok(labs);
        }

        //api/laboratories/{id}
        [HttpGet("{id:Guid}")]
        public IActionResult GetLaboratory(Guid id)
        {
            var company = _service.LaboratoryService.GetLaboratory(id, trackChanges: false);
            return Ok(company);
        }

        
    }
}
