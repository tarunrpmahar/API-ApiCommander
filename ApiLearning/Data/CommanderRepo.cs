﻿using ApiLearning.Models;
using System.Collections.Generic;

namespace ApiLearning.Data
{
    public class CommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAllCommand()
        {
            var commands = new List<Command>
            {
                 new Command { Id = 0, HowTo = "tarun singh mahar", Line = "Mahar singh tarun", Platform = "singh mahar tarun" },
                 new Command { Id = 1, HowTo = "tarun  mahar", Line = "Mahar singh", Platform = "singh tarun" },
                 new Command { Id = 2, HowTo = "singh mahar", Line = "Mahar tarun", Platform = "singh" },
            };
            return commands;
        }


        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "tarun singh mahar", Line = "Mahar singh tarun", Platform = "singh mahar tarun" };
        }
    }
}