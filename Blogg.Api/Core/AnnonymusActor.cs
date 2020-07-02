﻿using Blog.Application;
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

        public IEnumerable<int> AllowUseCases => new List<int> { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21 };
        //20,2
    }
}
