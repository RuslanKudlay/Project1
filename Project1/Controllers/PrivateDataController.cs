using BusinessLayer.ComputerService;
using BusinessLayer.Models;
using BusinessLayer.UserService;
using DataAccessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrivateDataController : ControllerBase
    {
        private readonly IComputerService _computerService;
        private readonly IUserService _userService;
        public PrivateDataController(IUserService userService, IComputerService computerService)
        {
            _userService = userService;
            _computerService = computerService;
        }
        [HttpGet]
        [Authorize]
        public IEnumerable<string> Get()
        {
            return new string[] { "First secret data string", "Secong secret data string" };
        }
        [HttpGet]
        [Route("editors-data")]
        [Authorize(Roles ="Editor")]
        public MessageData GetEditorsData()
        {
            MessageData result = new MessageData
            {
                Message = "This message can only be seen by editors"
            };
            return result;
        }

        [HttpGet]
        [Route("managers-data")]
        [Authorize(Roles = "Manager")]
        public MessageData GetManagersData()
        {
            MessageData result = new MessageData
            {
                Message = "This message can only be seen by editors"
            };
            return result;
        }

        [HttpGet]
        [Route("get-users")]
        //[Authorize]
        public List<User> GetAllUsers()
        {
            var manufactyrer = _computerService.GetComputerManufactyrers();
            return _userService.GetAll();
        }

    }
}
