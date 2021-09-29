using BusinessLayer.ComputerService;
using BusinessLayer.Lifecycle;
using BusinessLayer.Models;
using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        private readonly IComputerService _computerService;

        private readonly ITransientInterface _transientInterface1;
        private readonly ITransientInterface _transientInterface2;

        private readonly ISingletonInterface _singletonInterface1;
        private readonly ISingletonInterface _singletonInterface2;

        private readonly IScopedInterface _scopedInterface1;
        private readonly IScopedInterface _scopedInterface2;

        public ComputerController(IComputerService computerService,
            ITransientInterface transientInterface1,
            ITransientInterface transientInterface2,

            IScopedInterface scopedInterface1,
            IScopedInterface scopedInterface2,

            ISingletonInterface singletonInterface1,
            ISingletonInterface singletonInterface2
            )
        {
            _computerService = computerService;

            _transientInterface1 = transientInterface1;
            _transientInterface2 = transientInterface2;

            _scopedInterface1 = scopedInterface1;
            _scopedInterface2 = scopedInterface2;

            _singletonInterface1 = singletonInterface1;
            _singletonInterface2 = singletonInterface2;
        }

        [HttpGet]
        [Route("display-lifetime")]
        public ActionResult<object> DisplayLifetime()
        {
            var _scopedGuid1 = _scopedInterface1.GetGuid();
            var _scopedGuid2 = _scopedInterface2.GetGuid();

            var _singletonGuid1 = _singletonInterface1.GetGuid();
            var _singletonGuid2 = _singletonInterface2.GetGuid();

            var _transientGuid1 = _transientInterface1.GetGuid();
            var _transientGuid2 = _transientInterface2.GetGuid();

            return new ActionResult<object>(
                new { _scopedGuid1, _scopedGuid2, _singletonGuid1, _singletonGuid2, _transientGuid1, _transientGuid2 });
        }

        [HttpPost]
        public ActionResult<string> AddManufactyrer(ComputerManufactyrerDto computerManufactyrer)
        {
            if(computerManufactyrer.ManufactyrerName != null)
            {
               // return _computerService.AddManufactyrer(computerManufactyrer);
            }
            return BadRequest("You've tried to add an invalid data");
        }

        
        
        [HttpGet]
        public ActionResult<List<ComputerManufactyrerDto>> GetManufactyrers()
        {
            return _computerService.GetComputerManufactyrers();
        }

        [HttpDelete]
        public ActionResult<bool> RemoveManufactyrer(string id)
        {
            //var isSuccess = _computerService.DeleteManufactyrer(id);
            //if (isSuccess)
            //    return Ok();
            return BadRequest($"A manufactyrer wath {id} id doesn't exist!");
        }
    }
}
