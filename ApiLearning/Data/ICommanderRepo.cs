using ApiLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLearning.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAllCommand();
        Command GetCommandById(int id);
    }
}
