﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Queries
{
    public class GetProductByIdQuery
    {
        public Guid Id { get; set; }
    }
}
