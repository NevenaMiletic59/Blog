using Blog.Application;
using Blog.DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Logging
{
    public class UseCaseLogger : IUseCaseLogger
    {
        private readonly BlogContext _context;

        public UseCaseLogger(BlogContext context)
        {
            _context = context;
        }
        public void Log(IUseCase useCase, IApplicationActor actor, object data)
        {
            _context.UseCaseLogs.Add(new Domain.UseCaseLog
            {
                Actor = actor.Identity,
                Data = JsonConvert.SerializeObject(data),
                Date = DateTime.UtcNow,
                UseCaseName = useCase.Name

            });

            _context.SaveChanges();
        }
    }
}
