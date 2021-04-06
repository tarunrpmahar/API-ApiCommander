using ApiLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLearning.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }
        public IEnumerable<Command> GetAllCommand()
        {
            return _context.tblCommands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.tblCommands.FirstOrDefault(p => p.Id == id);
        }
    }
}
