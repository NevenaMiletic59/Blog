﻿using Blog.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Search
{
    public class CategorySearch
    {
        public string Keyword { get; set; }
        public bool? OnlyActive { get; set; }


        public int PerPage { get; set; } = 2;
        public int PageNumber { get; set; } = 1;

    }
}
