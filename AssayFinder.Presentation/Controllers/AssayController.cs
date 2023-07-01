﻿using Microsoft.AspNetCore.JsonPatch;
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
        public async Task<IActionResult> GetAssaysForLaboratory(Guid laboratoryId)
        {
            var assays = await _service.AssayService.GetAssaysAsync(laboratoryId, trackChanges: false);

            return Ok(assays);
        }

        // api/laboratories/{laboratoryId}/assays/{assayId}
        [HttpGet("{id:Guid}", Name = "GetAssayForLaboratory")]
        public async Task<IActionResult> GetAssayForLaboratory(Guid laboratoryId, Guid id)
        {
            var assay = await _service.AssayService.GetAssayAsync(laboratoryId, id, trackChanges: false);

            return Ok(assay);
        }

        // api/laboratories/{laboratoryId}/assays
        [HttpPost]
        public async Task<IActionResult> CreateAssayForLaboratory(Guid laboratoryId, [FromBody] AssayForCreationDTO assay)
        {
            if (assay is null)
            {
                return BadRequest("AssayForCreationDTO object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var assayToReturn = await _service.AssayService.CreateAssayForLaboratoryAsync(laboratoryId, assay, trackChanges: false);

            return CreatedAtRoute("GetAssayForLaboratory", new { laboratoryId, id = assayToReturn.AssayId }, assayToReturn);
        }

        // api/laboratories/{laboratoryId}/assays/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAssayForLaboratory(Guid laboratoryId, Guid id)
        {
            await _service.AssayService.DeleteAssayForLaboratoryAsync(laboratoryId, id, trackChanges: false);

            return NoContent();
        }

        // api/laboratories/{laboratoryId}/assays/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAssayForLaboratoryAsync(Guid laboratoryid, Guid id, [FromBody] AssayForUpdateDTO assay)
        {
            if (assay is null)
            {
                return BadRequest("AssayForUpdateDTO object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            await _service.AssayService.UpdateAssayForLaboratoryAsync(laboratoryid, id, assay,
                labTrackChanges: false, assayTrackChanges: true);

            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartialUpdateAssayForLaboratory(Guid laboratoryId, Guid Id, [FromBody] JsonPatchDocument<AssayForUpdateDTO> patchDoc)
        {
            if (patchDoc is null)
            {
                return BadRequest("patchDoc object sent from client is null.");
            }

            var result = await _service.AssayService.GetAssayForPatchAsync(laboratoryId, Id, labTrackChanges: false, assayTrackChanges: true);

            patchDoc.ApplyTo(result.assayToPatch, ModelState);

            TryValidateModel(result.assayToPatch);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _service.AssayService.SaveChangesForPatchAsync(result.assayToPatch, result.assayEntity);

            return NoContent();
        }


    }
}
