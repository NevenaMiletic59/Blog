﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Application.Core
{
    public class FakeApiActor : IApplicationActor
    {
        public int Id => 1;

        public string Identity => "Test Api User";

        public IEnumerable<int> AllowUseCases => new List<int> { 1};
    }
    public class AdminApiActor : IApplicationActor
    {
        public int Id =>2;

        public string Identity => "Fake Admin";

        public IEnumerable<int> AllowUseCases => Enumerable.Range(1,20);
    }
}
