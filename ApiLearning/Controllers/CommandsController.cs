using ApiLearning.Data;
using ApiLearning.Dtos;
using ApiLearning.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
        private readonly IMapper _mapper;

        //private readonly CommanderRepo _repo = new CommanderRepo();

        public CommandsController(ICommanderRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repo.GetAllCommand();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        [Route("{id}", Name = "GetCommandById")]  //GET api/commands/5
        [HttpGet]   //  [HttpGet("{id}")]
        public ActionResult <CommandReadDto> GetCommandById(int id)
        {
            var commandItems = _repo.GetCommandById(id);
            if(commandItems!=null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItems));
            }
            return NotFound();
        }

        //POST api/commands
        [HttpPost]
        public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repo.CreateCommand(commandModel);
            _repo.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            //creates a new filed in postman with name Location 
            return CreatedAtRoute(nameof(GetCommandById), new { Id= commandReadDto.Id}, commandReadDto);
            //return Ok(commandReadDto);
        }

        //PUT api/commands
        [HttpPut("{id}")]
        public ActionResult<CommandUpdateDto> UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repo.GetCommandById(id);
            if(commandModelFromRepo==null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            _repo.UpdateCommand(commandModelFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDocument)
        {
            var commandModelFromRepo = _repo.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDocument.ApplyTo(commandToPatch, ModelState);
            
            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repo.UpdateCommand(commandModelFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repo.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            _repo.DeleteCommand(commandModelFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }
    }
}
