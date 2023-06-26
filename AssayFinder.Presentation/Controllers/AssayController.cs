using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [HttpGet("{id:Guid}")]
        public IActionResult GetAssayForLaboratory(Guid laboratoryId, Guid id)
        {
            var assay = _service.AssayService.GetAssay(laboratoryId, id, trackChanges: false);

            return Ok(assay);
        }

    }
}
