﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Contracts.V1.Responses
{
    public class ProductResponse
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}
