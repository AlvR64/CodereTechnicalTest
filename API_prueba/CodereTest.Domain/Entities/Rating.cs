﻿using CodereTest.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTest.Domain.Entities
{
    public class Rating : BaseEntity
    {
        public double Average { get; set; }
    }
}
