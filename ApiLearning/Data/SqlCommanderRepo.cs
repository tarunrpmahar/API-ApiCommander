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

        public void CreateCommand(Command cmd)
        {
            if(cmd==null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.tblCommands.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.tblCommands.Remove(cmd);
            //_context.SaveChanges();
        }

        public IEnumerable<Command> GetAllCommand()
        {
            return _context.tblCommands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.tblCommands.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()>=0);
        }

        public void UpdateCommand(Command cmd)
        {
            //Nothing
        }
    }
}
