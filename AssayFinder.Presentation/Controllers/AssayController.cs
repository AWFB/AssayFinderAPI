using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Shared.DTOs;

namespace AssayFinder.Presentation.Controllers
{
    [Route("api/laboratories/{laboratoryId}/assays")]
    [ApiController]
    public class AssayController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AssayController(IServiceManager service)
        {
            _service = service;
        }

        // api/laboratories/{laboratoryId}/assays
        [HttpGet]
        public IActionResult GetAssaysForLaboratory(Guid laboratoryId)
        {
            var assays = _service.AssayService.GetAssays(laboratoryId, trackChanges: false);

            return Ok(assays);
        }

        // api/laboratories/{laboratoryId}/assays/{assayId}
        [HttpGet("{id:Guid}", Name = "GetAssayForLaboratory")]
        public IActionResult GetAssayForLaboratory(Guid laboratoryId, Guid id)
        {
            var assay = _service.AssayService.GetAssay(laboratoryId, id, trackChanges: false);

            return Ok(assay);
        }

        // api/laboratories/{laboratoryId}/assays
        [HttpPost]
        public IActionResult CreateAssayForLaboratory(Guid laboratoryId, [FromBody] AssayForCreationDTO assay)
        {
            if (assay is null)
            {
                return BadRequest("AssayForCreationDTO object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var assayToReturn = _service.AssayService.CreateAssayForLaboratory(laboratoryId, assay, trackChanges: false);

            return CreatedAtRoute("GetAssayForLaboratory", new { laboratoryId, id = assayToReturn.AssayId }, assayToReturn);
        }

        // api/laboratories/{laboratoryId}/assays/{id}
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteAssayForLaboratory(Guid laboratoryId, Guid id)
        {
            _service.AssayService.DeleteAssayForLaboratory(laboratoryId, id, trackChanges: false);

            return NoContent();
        }

        // api/laboratories/{laboratoryId}/assays/{id}
        [HttpPut("{id:guid}")]
        public IActionResult UpdateAssayForLaboratory(Guid laboratoryid, Guid id, [FromBody] AssayForUpdateDTO assay)
        {
            if (assay is null)
            {
                return BadRequest("AssayForUpdateDTO object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            _service.AssayService.UpdateAssayForLaboratory(laboratoryid, id, assay,
                labTrackChanges: false, assayTrackChanges: true);

            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        public IActionResult PartialUpdateAssayForLaboratory(Guid laboratoryId, Guid Id, [FromBody] JsonPatchDocument<AssayForUpdateDTO> patchDoc)
        {
            if (patchDoc is null)
            {
                return BadRequest("patchDoc object sent from client is null.");
            }

            var result = _service.AssayService.GetAssayForPatch(laboratoryId, Id, labTrackChanges: false, assayTrackChanges: true);

            patchDoc.ApplyTo(result.assayToPatch, ModelState);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _service.AssayService.SaveChangesForPatch(result.assayToPatch, result.assayEntity);

            return NoContent();
        }


    }
}
