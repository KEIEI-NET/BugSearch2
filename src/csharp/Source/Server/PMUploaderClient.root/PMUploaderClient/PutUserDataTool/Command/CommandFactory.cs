using System;
using System.Collections.Generic;
using System.Text;

namespace PutUserDataTool
{
    public class CommandFactory
    {
        public const string COMMAND_SQL_TYPE = "SQL";

        public const string COMMAND_FILE_TYPE = "FILE";

        private static CommandFactory _self;

        private CommandFactory()
        {
        }

        public static CommandFactory GetInstance()
        {
            if (_self == null)
            {
                _self = new CommandFactory();
            }
            return _self;
        }

        public ICommand GetCommand(List<Task> taskList)
        {
            AbstractChainCommand chainCommand = null,command = null;
            foreach (Task task in taskList)
            {
                if (task.TaskType == COMMAND_SQL_TYPE)
                {
                    if (chainCommand != null)
                    {
                        chainCommand.Chain = new SqlExecCommand(task);
                        chainCommand = chainCommand.Chain;
                    }
                    else
                    {
                        command = new SqlExecCommand(task);
                        chainCommand = command;
                    }
                }
                else if (task.TaskType == COMMAND_FILE_TYPE)
                {
                    if (chainCommand != null)
                    {
                        chainCommand.Chain = new FileUploadCommand(task);
                        chainCommand = chainCommand.Chain;
                    }
                    else
                    {
                        command = new FileUploadCommand(task);
                        chainCommand = command;
                    }
                }
            }
            return command;
        }
    }
}
