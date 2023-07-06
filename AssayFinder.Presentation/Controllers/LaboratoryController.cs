using AssayFinder.Presentation.ActionFilters;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> GetLaboratories()
        {
            var labs = await _service.LaboratoryService.GetAllLaboratoriesAsync(trackChanges: false);

            return Ok(labs);
        }

        //api/laboratories/{id}
        [HttpGet("{id:Guid}", Name = "LaboratoryById")]
        public async Task<IActionResult> GetLaboratory(Guid id)
        {
            var company = await _service.LaboratoryService.GetLaboratoryAsync(id, trackChanges: false);
            return Ok(company);
        }

        //api/laboratories
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateLaboratory([FromBody] LaboratoryForCreationDTO laboratory)
        {
            var createdLab = await _service.LaboratoryService.CreateLaboratoryAsync(laboratory);

            return CreatedAtRoute("LaboratoryById", new { id = createdLab.Id }, createdLab);
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateLaboratory(Guid id, [FromBody] LaboratoryForUpdateDTO laboratory)
        {
            await _service.LaboratoryService.UpdateLaboratoryAsync(id, laboratory, trackChanges: true);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteLaboratory(Guid id)
        {
            await _service.LaboratoryService.DeleteLaboratoryAsync(id, trackChanges: false);

            return NoContent();
        }

        

        
    }
}
