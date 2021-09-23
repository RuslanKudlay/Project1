using BusinessLayer.ComputerService;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ComputerController(IComputerService computerService)
        {
            _computerService = computerService;
        }

        [HttpPost]
        public ActionResult<string> AddManufactyrer(ComputerManufactyrerDto computerManufactyrer)
        {
            if(computerManufactyrer.ManufactyrerName != null)
            {
                return _computerService.AddManufactyrer(computerManufactyrer);
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
            var isSuccess = _computerService.DeleteManufactyrer(id);
            if (isSuccess)
                return Ok();
            return BadRequest($"A manufactyrer wath {id} id doesn't exist!");
        }
    }
}
