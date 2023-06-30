using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Shared.DTOs;

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
        [HttpGet("{id:Guid}", Name = "LaboratoryById")]
        public IActionResult GetLaboratory(Guid id)
        {
            var company = _service.LaboratoryService.GetLaboratory(id, trackChanges: false);
            return Ok(company);
        }

        //api/laboratories
        [HttpPost]
        public IActionResult CreateLaboratory([FromBody] LaboratoryForCreationDTO laboratory)
        {
            if (laboratory is null)
            {
                return BadRequest("LaboratoryForCreationDTO object is null");
            }

            var createdLab = _service.LaboratoryService.CreateLaboratory(laboratory);

            return CreatedAtRoute("LaboratoryById", new { id = createdLab.Id }, createdLab);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteLaboratory(Guid id)
        {
            _service.LaboratoryService.DeleteLaboratory(id, trackChanges: false);

            return NoContent();
        }

        

        
    }
}
