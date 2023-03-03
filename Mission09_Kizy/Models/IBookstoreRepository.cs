﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_Kizy.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<Project> Projects { get; }
    }
}
