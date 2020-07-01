using Blog.Application.Exeptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Application
{
   public class UseCaseExecutor
    {
        private readonly IApplicationActor actor;
        private readonly IUseCaseLogger logger;

        public UseCaseExecutor(IApplicationActor actor, IUseCaseLogger logger = null)
        {
            this.actor = actor;
            this.logger = logger;
        }

        public TResult ExecuteQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search)
        {
            logger.Log(query, actor,search);

            if (!actor.AllowUseCases.Contains(query.Id))
            {
                throw new UnauthorizeUseCaseException(query, actor);
            }

            return query.Execute(search);
        }

        public void ExecuteCommand<TRequest>(ICommand<TRequest> command,TRequest request)
        {
            logger.Log(command, actor, request);
            if (!actor.AllowUseCases.Contains(command.Id))
            {
                throw new UnauthorizeUseCaseException(command,actor);
            }
            command.Execute(request);
        }
    }
}
