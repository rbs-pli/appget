﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AppGet.Options;
using NLog;

namespace AppGet.Commands
{
    public interface ICommandExecutor
    {
        void ExecuteCommand(CommandOptions options);
    }

    public class CommandExecutor : ICommandExecutor
    {
        private readonly Logger _logger;
        private readonly List<ICommandHandler> _consoleCommands;


        public CommandExecutor(IEnumerable<ICommandHandler> consoleCommands, Logger logger)
        {
            _logger = logger;
            _consoleCommands = consoleCommands.ToList();
        }

        public void ExecuteCommand(CommandOptions arguments)
        {
            var commandHandler = _consoleCommands.FirstOrDefault(c => c.CanExecute(arguments));

            if (commandHandler == null)
            {
                throw new UnknownCommandException(arguments.CommandName);
            }

            _logger.Debug("starting {0}", arguments.CommandName);

            var stopwatch = Stopwatch.StartNew();
            commandHandler.Execute(arguments);
            stopwatch.Stop();

            _logger.Info("completed {0}. took: {1:N}s", arguments.CommandName, stopwatch.Elapsed.TotalSeconds);
        }
    }
}