using ApiLearning.Data;
using ApiLearning.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLearning.Controllers
{
    [Route("api/[controller]")]   // api/commands
    [ApiController]
    public class CommandsController : Controller
    {
        private readonly ICommanderRepo _repo;

        //private readonly CommanderRepo _repo = new CommanderRepo();

        public CommandsController(ICommanderRepo repo)
        {
            _repo = repo;
        }

        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repo.GetAllCommand();

            return Ok(commandItems);
        }

        [Route("{id}")]  //GET api/commands/5
        [HttpGet]   //  [HttpGet("{id}")]
        public ActionResult <Command> GetCommandById(int id)
        {
            var commandItems = _repo.GetCommandById(id);

            return Ok(commandItems);
        }
    }
}
