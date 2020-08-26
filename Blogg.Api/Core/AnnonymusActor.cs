using Blog.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogg.Api.Core
{
    public class AnnonymusActor : IApplicationActor
    {
        public int Id => 0;

        public string Identity => "Unauthorized user";

        public IEnumerable<int> AllowUseCases => new List<int> { 20,2,9,10,13,22,16,4,12 };
        //20,2
    }
}
