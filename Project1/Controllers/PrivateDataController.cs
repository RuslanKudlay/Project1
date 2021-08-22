using BusinessLayer.Models;
using BusinessLayer.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IUserService _userService;
        public PrivateDataController(IUserService userService)
        {
            _userService = userService;
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
        [Authorize]
        public List<User> GetAllUsers()
        {
            return _userService.GetAll();
        }

    }
}
