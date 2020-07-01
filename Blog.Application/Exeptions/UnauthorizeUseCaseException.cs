using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Exeptions
{
    public class UnauthorizeUseCaseException : Exception
    {

        public UnauthorizeUseCaseException(IUseCase usecase,IApplicationActor actor)
            :base($"Actor wiht  id: {actor.Id}-{actor.Identity} tried to execute {usecase.Name}")
        {

        }
    }
}
