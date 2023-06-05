using Microsoft.AspNetCore.Mvc;
using FluxFileManagerCore.Services.Abstract;
using FluxFileManagerCore.ModelData.Models;
using System;

namespace FluxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FluxFileManagerController : ControllerBase
    {
        private readonly IFluxFileManagerService _fluxFileManagerService;

        public FluxFileManagerController(IFluxFileManagerService fluxFileManagerService)
        {
            _fluxFileManagerService = fluxFileManagerService;
        }

        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost,Route("upload-new-image")]
        public Guid UploadNewImage([FromBody] NewUploadFile newUploadFile)
        {   
            var gameid = new Guid();
            gameid = default(Guid);

            gameid =  _fluxFileManagerService.AddNewFluxImage(newUploadFile);
            return gameid;
        }
    }
}
